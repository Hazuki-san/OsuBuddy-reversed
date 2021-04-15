using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace OsuParsers.Beatmaps.Sections
{
	// Token: 0x0200006F RID: 111
	public class BeatmapColoursSection
	{
		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x060002BB RID: 699 RVA: 0x00003504 File Offset: 0x00001704
		// (set) Token: 0x060002BC RID: 700 RVA: 0x0000350C File Offset: 0x0000170C
		public List<Color> ComboColours { get; set; } = new List<Color>();

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x060002BD RID: 701 RVA: 0x00003515 File Offset: 0x00001715
		// (set) Token: 0x060002BE RID: 702 RVA: 0x0000351D File Offset: 0x0000171D
		public Color SliderTrackOverride { get; set; }

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060002BF RID: 703 RVA: 0x00003526 File Offset: 0x00001726
		// (set) Token: 0x060002C0 RID: 704 RVA: 0x0000352E File Offset: 0x0000172E
		public Color SliderBorder { get; set; }

		// Token: 0x040002B3 RID: 691
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private List<Color> AComboColoursk__BackingField;

		// Token: 0x040002B4 RID: 692
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Color ASliderTrackOverridek__BackingField;

		// Token: 0x040002B5 RID: 693
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Color ASliderBorderk__BackingField;
	}
}
