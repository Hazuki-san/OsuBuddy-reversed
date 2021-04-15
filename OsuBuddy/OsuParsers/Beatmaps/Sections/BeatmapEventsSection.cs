using System;
using System.Collections.Generic;
using OsuParsers.Beatmaps.Sections.Events;
using OsuParsers.Storyboards;

namespace OsuParsers.Beatmaps.Sections
{
	// Token: 0x02000073 RID: 115
	public class BeatmapEventsSection
	{
		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060002DF RID: 735 RVA: 0x00003621 File Offset: 0x00003621
		// (set) Token: 0x060002E0 RID: 736 RVA: 0x00003629 File Offset: 0x00003629
		public string BackgroundImage { get; set; }

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060002E1 RID: 737 RVA: 0x00003632 File Offset: 0x00003632
		// (set) Token: 0x060002E2 RID: 738 RVA: 0x0000363A File Offset: 0x0000363A
		public string Video { get; set; }

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060002E3 RID: 739 RVA: 0x00003643 File Offset: 0x00003643
		// (set) Token: 0x060002E4 RID: 740 RVA: 0x0000364B File Offset: 0x0000364B
		public int VideoOffset { get; set; }

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060002E5 RID: 741 RVA: 0x00003654 File Offset: 0x00003654
		// (set) Token: 0x060002E6 RID: 742 RVA: 0x0000365C File Offset: 0x0000365C
		public List<BeatmapBreakEvent> Breaks { get; set; } = new List<BeatmapBreakEvent>();

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060002E7 RID: 743 RVA: 0x00003665 File Offset: 0x00003665
		// (set) Token: 0x060002E8 RID: 744 RVA: 0x0000366D File Offset: 0x0000366D
		public Storyboard Storyboard { get; set; } = new Storyboard();
	}
}
