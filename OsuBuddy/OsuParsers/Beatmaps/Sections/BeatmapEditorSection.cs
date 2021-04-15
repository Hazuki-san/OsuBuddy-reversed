using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using OsuParsers.Helpers;

namespace OsuParsers.Beatmaps.Sections
{
	// Token: 0x02000071 RID: 113
	public class BeatmapEditorSection
	{
		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060002CF RID: 719 RVA: 0x000035B1 File Offset: 0x000017B1
		// (set) Token: 0x060002D0 RID: 720 RVA: 0x000035B9 File Offset: 0x000017B9
		public int[] Bookmarks { get; set; }

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060002D1 RID: 721 RVA: 0x000035C2 File Offset: 0x000017C2
		// (set) Token: 0x060002D2 RID: 722 RVA: 0x00010794 File Offset: 0x0000E994
		public string BookmarksString
		{
			get
			{
				return this.Bookmarks.Join(',');
			}
			set
			{
				List<string> list = value.Split(new char[]
				{
					','
				}).ToList<string>();
				this.Bookmarks = list.ConvertAll<int>(new Converter<string, int>(BeatmapEditorSection.Ac.A9.Aset_BookmarksStringb__6_0)).ToArray();
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060002D3 RID: 723 RVA: 0x000035D1 File Offset: 0x000017D1
		// (set) Token: 0x060002D4 RID: 724 RVA: 0x000035D9 File Offset: 0x000017D9
		public double DistanceSpacing { get; set; }

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060002D5 RID: 725 RVA: 0x000035E2 File Offset: 0x000017E2
		// (set) Token: 0x060002D6 RID: 726 RVA: 0x000035EA File Offset: 0x000017EA
		public int BeatDivisor { get; set; }

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060002D7 RID: 727 RVA: 0x000035F3 File Offset: 0x000017F3
		// (set) Token: 0x060002D8 RID: 728 RVA: 0x000035FB File Offset: 0x000017FB
		public int GridSize { get; set; }

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060002D9 RID: 729 RVA: 0x00003604 File Offset: 0x00001804
		// (set) Token: 0x060002DA RID: 730 RVA: 0x0000360C File Offset: 0x0000180C
		public float TimelineZoom { get; set; }

		// Token: 0x040002BC RID: 700
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int[] ABookmarksk__BackingField;

		// Token: 0x040002BD RID: 701
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double ADistanceSpacingk__BackingField;

		// Token: 0x040002BE RID: 702
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int ABeatDivisork__BackingField;

		// Token: 0x040002BF RID: 703
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int AGridSizek__BackingField;

		// Token: 0x040002C0 RID: 704
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float ATimelineZoomk__BackingField;

		// Token: 0x02000072 RID: 114
		[CompilerGenerated]
		[Serializable]
		private sealed class Ac
		{
			// Token: 0x060002DE RID: 734 RVA: 0x00002A54 File Offset: 0x00000C54
			internal int Aset_BookmarksStringb__6_0(string e)
			{
				return Convert.ToInt32(e);
			}

			// Token: 0x040002C1 RID: 705
			public static readonly BeatmapEditorSection.Ac A9 = new BeatmapEditorSection.Ac();

			// Token: 0x040002C2 RID: 706
			public static Converter<string, int> A9__6_0;
		}
	}
}
