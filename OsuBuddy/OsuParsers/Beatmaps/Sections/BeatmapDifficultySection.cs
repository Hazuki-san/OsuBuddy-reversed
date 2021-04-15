using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace OsuParsers.Beatmaps.Sections
{
	// Token: 0x02000070 RID: 112
	public class BeatmapDifficultySection
	{
		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060002C2 RID: 706 RVA: 0x0000354B File Offset: 0x0000174B
		// (set) Token: 0x060002C3 RID: 707 RVA: 0x00003553 File Offset: 0x00001753
		public float HPDrainRate { get; set; } = 5f;

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x060002C4 RID: 708 RVA: 0x0000355C File Offset: 0x0000175C
		// (set) Token: 0x060002C5 RID: 709 RVA: 0x00003564 File Offset: 0x00001764
		public float CircleSize { get; set; } = 5f;

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x060002C6 RID: 710 RVA: 0x0000356D File Offset: 0x0000176D
		// (set) Token: 0x060002C7 RID: 711 RVA: 0x00003575 File Offset: 0x00001775
		public float OverallDifficulty { get; set; } = 5f;

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x060002C8 RID: 712 RVA: 0x0000357E File Offset: 0x0000177E
		// (set) Token: 0x060002C9 RID: 713 RVA: 0x00003586 File Offset: 0x00001786
		public float ApproachRate { get; set; } = 5f;

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060002CA RID: 714 RVA: 0x0000358F File Offset: 0x0000178F
		// (set) Token: 0x060002CB RID: 715 RVA: 0x00003597 File Offset: 0x00001797
		public double SliderMultiplier { get; set; } = 1.4;

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060002CC RID: 716 RVA: 0x000035A0 File Offset: 0x000017A0
		// (set) Token: 0x060002CD RID: 717 RVA: 0x000035A8 File Offset: 0x000017A8
		public double SliderTickRate { get; set; } = 1.0;

		// Token: 0x040002B6 RID: 694
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float AHPDrainRatek__BackingField;

		// Token: 0x040002B7 RID: 695
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float ACircleSizek__BackingField;

		// Token: 0x040002B8 RID: 696
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float AOverallDifficultyk__BackingField;

		// Token: 0x040002B9 RID: 697
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float AApproachRatek__BackingField;

		// Token: 0x040002BA RID: 698
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double ASliderMultiplierk__BackingField;

		// Token: 0x040002BB RID: 699
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double ASliderTickRatek__BackingField;
	}
}
