using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace OsuParsers.Replays.Objects
{
	// Token: 0x02000033 RID: 51
	public class LifeFrame
	{
		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000134 RID: 308 RVA: 0x000028DA File Offset: 0x00000ADA
		// (set) Token: 0x06000135 RID: 309 RVA: 0x000028E2 File Offset: 0x00000AE2
		public int Time { get; set; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000136 RID: 310 RVA: 0x000028EB File Offset: 0x00000AEB
		// (set) Token: 0x06000137 RID: 311 RVA: 0x000028F3 File Offset: 0x00000AF3
		public float Percentage { get; set; }

		// Token: 0x04000134 RID: 308
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int ATimek__BackingField;

		// Token: 0x04000135 RID: 309
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float APercentagek__BackingField;
	}
}
