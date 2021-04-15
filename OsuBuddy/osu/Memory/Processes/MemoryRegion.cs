using osu.Memory.Processes.Enums;
using System;
using static osu.Memory.Processes.MemoryBasicInformation;

namespace osu.Memory.Processes
{
    public class MemoryRegion
    {
        public UIntPtr BaseAddress { get; private set; }
        public UIntPtr RegionSize { get; private set; }
        public UIntPtr Start { get; private set; }
        public UIntPtr End { get; private set; }
        public MemoryState State { get; private set; }
        public MemoryProtect Protect { get; private set; }
        public MemoryType Type { get; private set; }

        public MemoryRegion(MEMORY_BASIC_INFORMATION_32 basicInformation)
        {
            BaseAddress = basicInformation.BaseAddress;
            RegionSize = basicInformation.RegionSize;
            State = basicInformation.State;
            Protect = basicInformation.Protect;
            Type = basicInformation.Type;
        }
    }
}
