using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using OsuParsers.Enums.Beatmaps;

namespace OsuParsers.Beatmaps.Objects
{
	// Token: 0x0200007C RID: 124
	public class TimingPoint
	{
		// Token: 0x170000EE RID: 238
		// (get) Token: 0x0600035A RID: 858 RVA: 0x00003AD3 File Offset: 0x00001CD3
		// (set) Token: 0x0600035B RID: 859 RVA: 0x00003ADB File Offset: 0x00001CDB
		public int Offset { get; set; }

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x0600035C RID: 860 RVA: 0x00003AE4 File Offset: 0x00001CE4
		// (set) Token: 0x0600035D RID: 861 RVA: 0x00003AEC File Offset: 0x00001CEC
		public double BeatLength { get; set; }

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x0600035E RID: 862 RVA: 0x00003AF5 File Offset: 0x00001CF5
		// (set) Token: 0x0600035F RID: 863 RVA: 0x00003AFD File Offset: 0x00001CFD
		public TimeSignature TimeSignature { get; set; }

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x06000360 RID: 864 RVA: 0x00003B06 File Offset: 0x00001D06
		// (set) Token: 0x06000361 RID: 865 RVA: 0x00003B0E File Offset: 0x00001D0E
		public SampleSet SampleSet { get; set; }

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x06000362 RID: 866 RVA: 0x00003B17 File Offset: 0x00001D17
		// (set) Token: 0x06000363 RID: 867 RVA: 0x00003B1F File Offset: 0x00001D1F
		public int CustomSampleSet { get; set; }

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x06000364 RID: 868 RVA: 0x00003B28 File Offset: 0x00001D28
		// (set) Token: 0x06000365 RID: 869 RVA: 0x00003B30 File Offset: 0x00001D30
		public int Volume { get; set; }

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x06000366 RID: 870 RVA: 0x00003B39 File Offset: 0x00001D39
		// (set) Token: 0x06000367 RID: 871 RVA: 0x00003B41 File Offset: 0x00001D41
		public bool Inherited { get; set; }

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x06000368 RID: 872 RVA: 0x00003B4A File Offset: 0x00001D4A
		// (set) Token: 0x06000369 RID: 873 RVA: 0x00003B52 File Offset: 0x00001D52
		public Effects Effects { get; set; }

		// Token: 0x040002F8 RID: 760
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int AOffsetk__BackingField;

		// Token: 0x040002F9 RID: 761
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double ABeatLengthk__BackingField;

		// Token: 0x040002FA RID: 762
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TimeSignature ATimeSignaturek__BackingField;

		// Token: 0x040002FB RID: 763
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SampleSet ASampleSetk__BackingField;

		// Token: 0x040002FC RID: 764
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int ACustomSampleSetk__BackingField;

		// Token: 0x040002FD RID: 765
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int AVolumek__BackingField;

		// Token: 0x040002FE RID: 766
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool AInheritedk__BackingField;

		// Token: 0x040002FF RID: 767
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Effects AEffectsk__BackingField;
	}
}
