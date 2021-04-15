using System;

namespace OsuParsers.Beatmaps.Sections
{
	// Token: 0x02000070 RID: 112
	public class BeatmapDifficultySection
	{
		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060002C2 RID: 706 RVA: 0x0000354B File Offset: 0x0000354B
		// (set) Token: 0x060002C3 RID: 707 RVA: 0x00003553 File Offset: 0x00003553
		public float HPDrainRate { get; set; } = 5f;

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x060002C4 RID: 708 RVA: 0x0000355C File Offset: 0x0000355C
		// (set) Token: 0x060002C5 RID: 709 RVA: 0x00003564 File Offset: 0x00003564
		public float CircleSize { get; set; } = 5f;

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x060002C6 RID: 710 RVA: 0x0000356D File Offset: 0x0000356D
		// (set) Token: 0x060002C7 RID: 711 RVA: 0x00003575 File Offset: 0x00003575
		public float OverallDifficulty { get; set; } = 5f;

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x060002C8 RID: 712 RVA: 0x0000357E File Offset: 0x0000357E
		// (set) Token: 0x060002C9 RID: 713 RVA: 0x00003586 File Offset: 0x00003586
		public float ApproachRate { get; set; } = 5f;

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060002CA RID: 714 RVA: 0x0000358F File Offset: 0x0000358F
		// (set) Token: 0x060002CB RID: 715 RVA: 0x00003597 File Offset: 0x00003597
		public double SliderMultiplier { get; set; } = 1.4;

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060002CC RID: 716 RVA: 0x000035A0 File Offset: 0x000035A0
		// (set) Token: 0x060002CD RID: 717 RVA: 0x000035A8 File Offset: 0x000035A8
		public double SliderTickRate { get; set; } = 1.0;
	}
}
