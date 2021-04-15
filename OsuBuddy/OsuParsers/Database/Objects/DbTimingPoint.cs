using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace OsuParsers.Database.Objects
{
	// Token: 0x0200006B RID: 107
	public class DbTimingPoint
	{
		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000267 RID: 615 RVA: 0x0000325D File Offset: 0x0000145D
		// (set) Token: 0x06000268 RID: 616 RVA: 0x00003265 File Offset: 0x00001465
		public double BPM { get; set; }

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000269 RID: 617 RVA: 0x0000326E File Offset: 0x0000146E
		// (set) Token: 0x0600026A RID: 618 RVA: 0x00003276 File Offset: 0x00001476
		public double Offset { get; set; }

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x0600026B RID: 619 RVA: 0x0000327F File Offset: 0x0000147F
		// (set) Token: 0x0600026C RID: 620 RVA: 0x00003287 File Offset: 0x00001487
		public bool Inherited { get; set; }

		// Token: 0x0400028B RID: 651
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double ABPMk__BackingField;

		// Token: 0x0400028C RID: 652
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double AOffsetk__BackingField;

		// Token: 0x0400028D RID: 653
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool AInheritedk__BackingField;
	}
}
