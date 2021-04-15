using System;
using osu.Memory.Processes.Enums;

namespace osu.Memory.Processes
{
	// Token: 0x02000089 RID: 137
	public class MemoryBasicInformation
	{
		// Token: 0x0200008A RID: 138
		public struct MEMORY_BASIC_INFORMATION_32
		{
			// Token: 0x04000311 RID: 785
			public UIntPtr BaseAddress;

			// Token: 0x04000312 RID: 786
			public UIntPtr AllocationBase;

			// Token: 0x04000313 RID: 787
			public uint AllocationProtect;

			// Token: 0x04000314 RID: 788
			public UIntPtr RegionSize;

			// Token: 0x04000315 RID: 789
			public MemoryState State;

			// Token: 0x04000316 RID: 790
			public MemoryProtect Protect;

			// Token: 0x04000317 RID: 791
			public MemoryType Type;
		}
	}
}
