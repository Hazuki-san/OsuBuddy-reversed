using System;
using System.Collections.Generic;
using System.Drawing;

namespace OsuParsers.Beatmaps.Sections
{
	// Token: 0x0200006F RID: 111
	public class BeatmapColoursSection
	{
		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x060002BB RID: 699 RVA: 0x00003504 File Offset: 0x00003504
		// (set) Token: 0x060002BC RID: 700 RVA: 0x0000350C File Offset: 0x0000350C
		public List<Color> ComboColours { get; set; } = new List<Color>();

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x060002BD RID: 701 RVA: 0x00003515 File Offset: 0x00003515
		// (set) Token: 0x060002BE RID: 702 RVA: 0x0000351D File Offset: 0x0000351D
		public Color SliderTrackOverride { get; set; }

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060002BF RID: 703 RVA: 0x00003526 File Offset: 0x00003526
		// (set) Token: 0x060002C0 RID: 704 RVA: 0x0000352E File Offset: 0x0000352E
		public Color SliderBorder { get; set; }
	}
}
