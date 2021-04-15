using osu.Memory.Processes.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using static osu.Memory.Processes.MemoryBasicInformation;

namespace osu.Memory.Processes
{
    public class OsuProcess
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool ReadProcessMemory(IntPtr hProcess, UIntPtr lpBaseAddress, [Out] byte[] lpBuffer, uint dwSize, out UIntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteProcessMemory(IntPtr hProcess, UIntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);

        //TODO: x64 support
        [DllImport("kernel32.dll")]
        public static extern int VirtualQueryEx(IntPtr hProcess, UIntPtr lpAddress, out MEMORY_BASIC_INFORMATION_32 lpBuffer, uint dwLength);

        public Process Process { get; private set; }

        public OsuProcess(Process process) => Process = process;

        private List<MemoryRegion> cachedMemoryRegions;

        public bool FindPattern(string pattern, out UIntPtr result)
        {
            var parsedPattern = Pattern.Parse(pattern);
            var lastOccurenceTable = generateLastOccurenceTable(parsedPattern);
            var mainModule = Process.MainModule;

            const int bufferSize = 0x80000;
            var buffer = new byte[bufferSize + parsedPattern.Bytes.Length - 1];

            var regions = cachedMemoryRegions ?? (cachedMemoryRegions = EnumerateMemoryRegions());
            foreach (var region in regions)
            {
                if ((uint)region.BaseAddress < (uint)mainModule.BaseAddress)
                    continue;

                ulong start = region.BaseAddress.ToUInt64();
                ulong end = region.BaseAddress.ToUInt64() + region.RegionSize.ToUInt64();
                for (ulong i = start; i < end; i += bufferSize)
                {
                    var currentBufferLen = Math.Min((uint)buffer.Length, end - i);
                    ReadMemory(new UIntPtr(i), buffer, (uint)currentBufferLen);
                    if (findMatch(parsedPattern, buffer, lastOccurenceTable, out UIntPtr match, (int)currentBufferLen))
                    {
                        result = new UIntPtr(i + match.ToUInt64());
                        return true;
                    }
                }
            }

            result = UIntPtr.Zero;
            return false;
        }

        public List<MemoryRegion> EnumerateMemoryRegions()
        {
            var regions = new List<MemoryRegion>();
            UIntPtr address = UIntPtr.Zero;

            while (VirtualQueryEx(Process.Handle, address, out MEMORY_BASIC_INFORMATION_32 basicInformation, (uint)Marshal.SizeOf(typeof(MEMORY_BASIC_INFORMATION_32))) != 0)
            {
                if (basicInformation.State != MemoryState.MemFree && !basicInformation.Protect.HasFlag(MemoryProtect.PageGuard))
                    regions.Add(new MemoryRegion(basicInformation));

                address = (UIntPtr)(basicInformation.BaseAddress.ToUInt32() + basicInformation.RegionSize.ToUInt32());
            }

            return regions;
        }

        public byte[] ReadMemory(UIntPtr address, uint size)
        {
            byte[] result = new byte[size];
            ReadProcessMemory(Process.Handle, address, result, size, out UIntPtr bytesRead);
            return result;
        }

        public UIntPtr ReadMemory(UIntPtr address, byte[] buffer, uint size)
        {
            UIntPtr bytesRead;
            ReadProcessMemory(Process.Handle, address, buffer, size, out bytesRead);
            return bytesRead;
        }

        public void WriteMemory(UIntPtr address, byte[] data, uint length)
        {
            WriteProcessMemory(Process.Handle, address, data, length, out UIntPtr bytesWritten);
        }

        public int ReadInt32(UIntPtr address) => BitConverter.ToInt32(ReadMemory(address, sizeof(int)), 0);

        public uint ReadUInt32(UIntPtr address) => BitConverter.ToUInt32(ReadMemory(address, sizeof(uint)), 0);

        public long ReadInt64(UIntPtr address) => BitConverter.ToInt64(ReadMemory(address, sizeof(long)), 0);

        public ulong ReadUInt64(UIntPtr address) => BitConverter.ToUInt64(ReadMemory(address, sizeof(ulong)), 0);

        public float ReadFloat(UIntPtr address) => BitConverter.ToSingle(ReadMemory(address, sizeof(float)), 0);

        public double ReadDouble(UIntPtr address) => BitConverter.ToDouble(ReadMemory(address, sizeof(double)), 0);

        public bool ReadBool(UIntPtr address) => BitConverter.ToBoolean(ReadMemory(address, sizeof(bool)), 0);

        public string ReadString(UIntPtr address, bool multiply = false, Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;
            UIntPtr stringAddress = (UIntPtr)ReadUInt32(address);
            int length = ReadInt32(stringAddress + 0x4) * (multiply ? 2 : 1);

            return encoding.GetString(ReadMemory(stringAddress + 0x8, (uint)length)).Replace("\0", string.Empty);
        }

        private int[] generateLastOccurenceTable(Pattern pattern)
        {
            var table = new int[256];

            for (int k = 0; k < table.Length; k++)
                table[k] = -1;

            for (int k = 0; k < pattern.Bytes.Length; k++)
                if (pattern.Mask[k])
                    table[pattern.Bytes[k]] = k;

            return table;
        }

        private unsafe bool findMatch(Pattern pattern, byte[] buffer, int[] lastOccurenceTable, out UIntPtr result, int bufferLength = -1)
        {
            result = UIntPtr.Zero;

            int patternLength = pattern.Bytes.Length;
            bufferLength = bufferLength != -1 ? bufferLength : buffer.Length;
            int patternLastIndex = patternLength - 1;

            fixed (int* lastOccurenceTablePtr = lastOccurenceTable)
            {
                fixed (byte* bufferPtr = buffer)
                {
                    fixed (bool* maskPtr = pattern.Mask)
                    {
                        fixed (byte* patternPtr = pattern.Bytes)
                        {
                            int j = patternLastIndex;
                            for (int i = patternLastIndex; i < bufferLength; i += patternLength - Math.Min(j, 1 + lastOccurenceTablePtr[bufferPtr[i]]))
                            {
                                for (j = patternLastIndex; j > 0; i--, j--)
                                {
                                    if (!maskPtr[j] || patternPtr[j] == bufferPtr[i])
                                        continue;

                                    goto loopEnd;
                                }

                                result = (UIntPtr)i;
                                return true;

                                loopEnd:;
                            }
                        }
                    }
                }
            }

            return false;
        }
    }
}
