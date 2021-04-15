using osu.Memory.Processes.Enums;
using System;
using System.Runtime.InteropServices;

namespace osu.Memory.Processes
{
    public class MemoryBasicInformation
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct MEMORY_BASIC_INFORMATION_32
        {
            public UIntPtr BaseAddress;
            public UIntPtr AllocationBase;
            public uint AllocationProtect;
            public UIntPtr RegionSize;
            public MemoryState State;
            public MemoryProtect Protect;
            public MemoryType Type;
        }
    }
}
