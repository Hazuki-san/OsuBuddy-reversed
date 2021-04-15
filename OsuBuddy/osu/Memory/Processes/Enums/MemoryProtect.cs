using System;

namespace osu.Memory.Processes.Enums
{
	// Token: 0x02000090 RID: 144
	public enum MemoryProtect
	{
		// Token: 0x0400032B RID: 811
		PageNoAccess = 1,
		// Token: 0x0400032C RID: 812
		PageReadonly,
		// Token: 0x0400032D RID: 813
		PageReadWrite = 4,
		// Token: 0x0400032E RID: 814
		PageWriteCopy = 8,
		// Token: 0x0400032F RID: 815
		PageExecute = 16,
		// Token: 0x04000330 RID: 816
		PageExecuteRead = 32,
		// Token: 0x04000331 RID: 817
		PageExecuteReadWrite = 64,
		// Token: 0x04000332 RID: 818
		PageExecuteWriteCopy = 128,
		// Token: 0x04000333 RID: 819
		PageGuard = 256,
		// Token: 0x04000334 RID: 820
		PageNoCache = 512,
		// Token: 0x04000335 RID: 821
		PageWriteCombine = 1024
	}
}
