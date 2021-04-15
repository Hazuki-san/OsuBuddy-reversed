using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using osu.Memory.Processes.Enums;

namespace osu.Memory.Processes
{
	// Token: 0x0200008D RID: 141
	public class OsuProcess
	{
		// Token: 0x060003B6 RID: 950
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool ReadProcessMemory(IntPtr hProcess, UIntPtr lpBaseAddress, [Out] byte[] lpBuffer, uint dwSize, out UIntPtr lpNumberOfBytesRead);

		// Token: 0x060003B7 RID: 951
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool WriteProcessMemory(IntPtr hProcess, UIntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);

		// Token: 0x060003B8 RID: 952
		[DllImport("kernel32.dll")]
		public static extern int VirtualQueryEx(IntPtr hProcess, UIntPtr lpAddress, out MemoryBasicInformation.MEMORY_BASIC_INFORMATION_32 lpBuffer, uint dwLength);

		// Token: 0x060003B9 RID: 953
		[DllImport("user32.dll")]
		public static extern bool GetClientRect(IntPtr hwnd, ref Rect rectangle);

		// Token: 0x060003BA RID: 954
		[DllImport("user32.dll")]
		public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x060003BB RID: 955 RVA: 0x00003E11 File Offset: 0x00002011
		// (set) Token: 0x060003BC RID: 956 RVA: 0x00003E19 File Offset: 0x00002019
		public Process Process { get; private set; }

		// Token: 0x060003BD RID: 957 RVA: 0x00003E22 File Offset: 0x00002022
		public OsuProcess(Process process)
		{
			this.Process = process;
		}

		// Token: 0x060003BE RID: 958 RVA: 0x000111B4 File Offset: 0x0000F3B4
		public Rect getOsuClientRect()
		{
			Rect result = default(Rect);
			OsuProcess.GetClientRect(this.Process.MainWindowHandle, ref result);
			return result;
		}

		// Token: 0x060003BF RID: 959 RVA: 0x000111E4 File Offset: 0x0000F3E4
		public Rect getOsuWindowRect()
		{
			Rect result = default(Rect);
			OsuProcess.GetWindowRect(this.Process.MainWindowHandle, ref result);
			return result;
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x00011214 File Offset: 0x0000F414
		public bool FindPattern(string pattern, out UIntPtr result)
		{
			Pattern pattern2 = Pattern.Parse(pattern);
			int[] lastOccurenceTable = this.generateLastOccurenceTable(pattern2);
			ProcessModule mainModule = this.Process.MainModule;
			byte[] array = new byte[524288 + pattern2.Bytes.Length - 1];
			List<MemoryRegion> list;
			if ((list = this.cachedMemoryRegions) == null)
			{
				list = (this.cachedMemoryRegions = this.EnumerateMemoryRegions());
			}
			List<MemoryRegion> list2 = list;
			foreach (MemoryRegion memoryRegion in list2)
			{
				bool flag = (uint)memoryRegion.BaseAddress < (uint)((int)mainModule.BaseAddress);
				if (!flag)
				{
					ulong num = memoryRegion.BaseAddress.ToUInt64();
					ulong num2 = memoryRegion.BaseAddress.ToUInt64() + memoryRegion.RegionSize.ToUInt64();
					for (ulong num3 = num; num3 < num2; num3 += 524288UL)
					{
						ulong num4 = Math.Min((ulong)array.Length, num2 - num3);
						this.ReadMemory(new UIntPtr(num3), array, (uint)num4);
						UIntPtr uintPtr;
						bool flag2 = this.findMatch(pattern2, array, lastOccurenceTable, out uintPtr, (int)num4);
						if (flag2)
						{
							result = new UIntPtr(num3 + uintPtr.ToUInt64());
							return true;
						}
					}
				}
			}
			result = UIntPtr.Zero;
			return false;
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x0001138C File Offset: 0x0000F58C
		public List<MemoryRegion> EnumerateMemoryRegions()
		{
			List<MemoryRegion> list = new List<MemoryRegion>();
			UIntPtr lpAddress = UIntPtr.Zero;
			for (;;)
			{
				MemoryBasicInformation.MEMORY_BASIC_INFORMATION_32 memory_BASIC_INFORMATION_;
				bool flag = OsuProcess.VirtualQueryEx(this.Process.Handle, lpAddress, out memory_BASIC_INFORMATION_, (uint)Marshal.SizeOf(typeof(MemoryBasicInformation.MEMORY_BASIC_INFORMATION_32))) != 0;
				if (!flag)
				{
					break;
				}
				bool flag2 = memory_BASIC_INFORMATION_.State != MemoryState.MemFree && !memory_BASIC_INFORMATION_.Protect.HasFlag(MemoryProtect.PageGuard);
				if (flag2)
				{
					list.Add(new MemoryRegion(memory_BASIC_INFORMATION_));
				}
				lpAddress = (UIntPtr)(memory_BASIC_INFORMATION_.BaseAddress.ToUInt32() + memory_BASIC_INFORMATION_.RegionSize.ToUInt32());
			}
			return list;
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x0001143C File Offset: 0x0000F63C
		public byte[] ReadMemory(UIntPtr address, uint size)
		{
			byte[] array = new byte[size];
			UIntPtr uintPtr;
			OsuProcess.ReadProcessMemory(this.Process.Handle, address, array, size, out uintPtr);
			return array;
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x0001146C File Offset: 0x0000F66C
		public UIntPtr ReadMemory(UIntPtr address, byte[] buffer, uint size)
		{
			UIntPtr result;
			OsuProcess.ReadProcessMemory(this.Process.Handle, address, buffer, size, out result);
			return result;
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x00011498 File Offset: 0x0000F698
		public void WriteMemory(UIntPtr address, byte[] data, uint length)
		{
			UIntPtr uintPtr;
			OsuProcess.WriteProcessMemory(this.Process.Handle, address, data, length, out uintPtr);
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x00003E33 File Offset: 0x00002033
		public int ReadInt32(UIntPtr address)
		{
			return BitConverter.ToInt32(this.ReadMemory(address, 4U), 0);
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x00003E43 File Offset: 0x00002043
		public uint ReadUInt32(UIntPtr address)
		{
			return BitConverter.ToUInt32(this.ReadMemory(address, 4U), 0);
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x00003E53 File Offset: 0x00002053
		public long ReadInt64(UIntPtr address)
		{
			return BitConverter.ToInt64(this.ReadMemory(address, 8U), 0);
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x00003E63 File Offset: 0x00002063
		public ulong ReadUInt64(UIntPtr address)
		{
			return BitConverter.ToUInt64(this.ReadMemory(address, 8U), 0);
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x00003E73 File Offset: 0x00002073
		public float ReadFloat(UIntPtr address)
		{
			return BitConverter.ToSingle(this.ReadMemory(address, 4U), 0);
		}

		// Token: 0x060003CA RID: 970 RVA: 0x00003E83 File Offset: 0x00002083
		public double ReadDouble(UIntPtr address)
		{
			return BitConverter.ToDouble(this.ReadMemory(address, 8U), 0);
		}

		// Token: 0x060003CB RID: 971 RVA: 0x00003E93 File Offset: 0x00002093
		public bool ReadBool(UIntPtr address)
		{
			return BitConverter.ToBoolean(this.ReadMemory(address, 1U), 0);
		}

		// Token: 0x060003CC RID: 972 RVA: 0x000114BC File Offset: 0x0000F6BC
		public string ReadString(UIntPtr address, bool multiply = false, Encoding encoding = null)
		{
			encoding = (encoding ?? Encoding.UTF8);
			UIntPtr pointer = (UIntPtr)this.ReadUInt32(address);
			int size = this.ReadInt32(pointer + 4) * (multiply ? 2 : 1);
			return encoding.GetString(this.ReadMemory(pointer + 8, (uint)size)).Replace("\0", string.Empty);
		}

		// Token: 0x060003CD RID: 973 RVA: 0x00011520 File Offset: 0x0000F720
		private int[] generateLastOccurenceTable(Pattern pattern)
		{
			int[] array = new int[256];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = -1;
			}
			for (int j = 0; j < pattern.Bytes.Length; j++)
			{
				bool flag = pattern.Mask[j];
				if (flag)
				{
					array[(int)pattern.Bytes[j]] = j;
				}
			}
			return array;
		}

		// Token: 0x060003CE RID: 974 RVA: 0x00011588 File Offset: 0x0000F788
		private unsafe bool findMatch(Pattern pattern, byte[] buffer, int[] lastOccurenceTable, out UIntPtr result, int bufferLength = -1)
		{
			result = UIntPtr.Zero;
			int num = pattern.Bytes.Length;
			bufferLength = ((bufferLength != -1) ? bufferLength : buffer.Length);
			int num2 = num - 1;
			fixed (int* ptr4 = lastOccurenceTable)
			{
				fixed (byte* ptr3 = buffer)
				{
					fixed (bool* ptr = pattern.Mask)
					{
						fixed (byte* ptr2 = pattern.Bytes)
						{
							int num3 = num2;
							for (int i = num2; i < bufferLength; i += num - Math.Min(num3, 1 + ptr4[(int)ptr3[i]]))
							{
								num3 = num2;
								while (true)
								{
									if (num3 > 0)
									{
										if (ptr[num3] && ptr2[num3] != ptr3[i])
										{
											break;
										}
										i--;
										num3--;
										continue;
									}
									result = (UIntPtr)(ulong)i;
									return true;
								}
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x04000323 RID: 803
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Process AProcessk__BackingField;

		// Token: 0x04000324 RID: 804
		private List<MemoryRegion> cachedMemoryRegions;
	}
}
