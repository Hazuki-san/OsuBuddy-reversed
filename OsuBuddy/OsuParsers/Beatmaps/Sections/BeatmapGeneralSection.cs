using System;
using OsuParsers.Enums;
using OsuParsers.Enums.Beatmaps;

namespace OsuParsers.Beatmaps.Sections
{
	// Token: 0x02000074 RID: 116
	public class BeatmapGeneralSection
	{
		// Token: 0x170000BA RID: 186
		// (get) Token: 0x060002EA RID: 746 RVA: 0x00003695 File Offset: 0x00003695
		// (set) Token: 0x060002EB RID: 747 RVA: 0x0000369D File Offset: 0x0000369D
		public string AudioFilename { get; set; }

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x060002EC RID: 748 RVA: 0x000036A6 File Offset: 0x000036A6
		// (set) Token: 0x060002ED RID: 749 RVA: 0x000036AE File Offset: 0x000036AE
		public int AudioLeadIn { get; set; }

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x060002EE RID: 750 RVA: 0x000036B7 File Offset: 0x000036B7
		// (set) Token: 0x060002EF RID: 751 RVA: 0x000036BF File Offset: 0x000036BF
		public int PreviewTime { get; set; } = -1;

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060002F0 RID: 752 RVA: 0x000036C8 File Offset: 0x000036C8
		// (set) Token: 0x060002F1 RID: 753 RVA: 0x000036D0 File Offset: 0x000036D0
		public bool Countdown { get; set; } = true;

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x060002F2 RID: 754 RVA: 0x000036D9 File Offset: 0x000036D9
		// (set) Token: 0x060002F3 RID: 755 RVA: 0x000036E1 File Offset: 0x000036E1
		public SampleSet SampleSet { get; set; } = SampleSet.Normal;

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x060002F4 RID: 756 RVA: 0x000036EA File Offset: 0x000036EA
		// (set) Token: 0x060002F5 RID: 757 RVA: 0x000036F2 File Offset: 0x000036F2
		public double StackLeniency { get; set; } = 0.699999988079071;

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x060002F6 RID: 758 RVA: 0x000036FB File Offset: 0x000036FB
		// (set) Token: 0x060002F7 RID: 759 RVA: 0x00003703 File Offset: 0x00003703
		public Ruleset Mode { get; set; } = Ruleset.Standard;

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x060002F8 RID: 760 RVA: 0x0000370C File Offset: 0x0000370C
		// (set) Token: 0x060002F9 RID: 761 RVA: 0x00003714 File Offset: 0x00003714
		public int ModeId { get; set; }

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x060002FA RID: 762 RVA: 0x0000371D File Offset: 0x0000371D
		// (set) Token: 0x060002FB RID: 763 RVA: 0x00003725 File Offset: 0x00003725
		public bool LetterboxInBreaks { get; set; }

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x060002FC RID: 764 RVA: 0x0000372E File Offset: 0x0000372E
		// (set) Token: 0x060002FD RID: 765 RVA: 0x00003736 File Offset: 0x00003736
		public bool WidescreenStoryboard { get; set; }

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x060002FE RID: 766 RVA: 0x0000373F File Offset: 0x0000373F
		// (set) Token: 0x060002FF RID: 767 RVA: 0x00003747 File Offset: 0x00003747
		public bool StoryFireInFront { get; set; }

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000300 RID: 768 RVA: 0x00003750 File Offset: 0x00003750
		// (set) Token: 0x06000301 RID: 769 RVA: 0x00003758 File Offset: 0x00003758
		public bool SpecialStyle { get; set; }

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000302 RID: 770 RVA: 0x00003761 File Offset: 0x00003761
		// (set) Token: 0x06000303 RID: 771 RVA: 0x00003769 File Offset: 0x00003769
		public bool EpilepsyWarning { get; set; }

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000304 RID: 772 RVA: 0x00003772 File Offset: 0x00003772
		// (set) Token: 0x06000305 RID: 773 RVA: 0x0000377A File Offset: 0x0000377A
		public bool UseSkinSprites { get; set; }

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000306 RID: 774 RVA: 0x00003783 File Offset: 0x00003783
		// (set) Token: 0x06000307 RID: 775 RVA: 0x0000378B File Offset: 0x0000378B
		public int CirclesCount { get; set; }

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000308 RID: 776 RVA: 0x00003794 File Offset: 0x00003794
		// (set) Token: 0x06000309 RID: 777 RVA: 0x0000379C File Offset: 0x0000379C
		public int SlidersCount { get; set; }

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x0600030A RID: 778 RVA: 0x000037A5 File Offset: 0x000037A5
		// (set) Token: 0x0600030B RID: 779 RVA: 0x000037AD File Offset: 0x000037AD
		public int SpinnersCount { get; set; }

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x0600030C RID: 780 RVA: 0x000037B6 File Offset: 0x000037B6
		// (set) Token: 0x0600030D RID: 781 RVA: 0x000037BE File Offset: 0x000037BE
		public int Length { get; set; }
	}
}
