using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using OsuParsers.Beatmaps.Sections.Events;
using OsuParsers.Storyboards;

namespace OsuParsers.Beatmaps.Sections
{
	// Token: 0x02000073 RID: 115
	public class BeatmapEventsSection
	{
		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060002DF RID: 735 RVA: 0x00003621 File Offset: 0x00001821
		// (set) Token: 0x060002E0 RID: 736 RVA: 0x00003629 File Offset: 0x00001829
		public string BackgroundImage { get; set; }

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060002E1 RID: 737 RVA: 0x00003632 File Offset: 0x00001832
		// (set) Token: 0x060002E2 RID: 738 RVA: 0x0000363A File Offset: 0x0000183A
		public string Video { get; set; }

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060002E3 RID: 739 RVA: 0x00003643 File Offset: 0x00001843
		// (set) Token: 0x060002E4 RID: 740 RVA: 0x0000364B File Offset: 0x0000184B
		public int VideoOffset { get; set; }

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060002E5 RID: 741 RVA: 0x00003654 File Offset: 0x00001854
		// (set) Token: 0x060002E6 RID: 742 RVA: 0x0000365C File Offset: 0x0000185C
		public List<BeatmapBreakEvent> Breaks { get; set; } = new List<BeatmapBreakEvent>();

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060002E7 RID: 743 RVA: 0x00003665 File Offset: 0x00001865
		// (set) Token: 0x060002E8 RID: 744 RVA: 0x0000366D File Offset: 0x0000186D
		public Storyboard Storyboard { get; set; } = new Storyboard();

		// Token: 0x040002C3 RID: 707
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string ABackgroundImagek__BackingField;

		// Token: 0x040002C4 RID: 708
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string AVideok__BackingField;

		// Token: 0x040002C5 RID: 709
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int AVideoOffsetk__BackingField;

		// Token: 0x040002C6 RID: 710
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private List<BeatmapBreakEvent> ABreaksk__BackingField;

		// Token: 0x040002C7 RID: 711
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Storyboard AStoryboardk__BackingField;
	}
}
