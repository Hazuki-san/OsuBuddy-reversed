using System;
using System.Collections.Generic;
using System.Linq;
using OsuParsers.Helpers;

namespace OsuParsers.Beatmaps.Sections
{
	// Token: 0x02000071 RID: 113
	public class BeatmapEditorSection
	{
		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060002CF RID: 719 RVA: 0x000035B1 File Offset: 0x000035B1
		// (set) Token: 0x060002D0 RID: 720 RVA: 0x000035B9 File Offset: 0x000035B9
		public int[] Bookmarks { get; set; }

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060002D1 RID: 721 RVA: 0x000035C2 File Offset: 0x000035C2
		// (set) Token: 0x060002D2 RID: 722 RVA: 0x00010794 File Offset: 0x00010794
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
				this.Bookmarks = list.ConvertAll<int>((string e) => Convert.ToInt32(e)).ToArray();
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060002D3 RID: 723 RVA: 0x000035D1 File Offset: 0x000035D1
		// (set) Token: 0x060002D4 RID: 724 RVA: 0x000035D9 File Offset: 0x000035D9
		public double DistanceSpacing { get; set; }

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060002D5 RID: 725 RVA: 0x000035E2 File Offset: 0x000035E2
		// (set) Token: 0x060002D6 RID: 726 RVA: 0x000035EA File Offset: 0x000035EA
		public int BeatDivisor { get; set; }

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060002D7 RID: 727 RVA: 0x000035F3 File Offset: 0x000035F3
		// (set) Token: 0x060002D8 RID: 728 RVA: 0x000035FB File Offset: 0x000035FB
		public int GridSize { get; set; }

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060002D9 RID: 729 RVA: 0x00003604 File Offset: 0x00003604
		// (set) Token: 0x060002DA RID: 730 RVA: 0x0000360C File Offset: 0x0000360C
		public float TimelineZoom { get; set; }
	}
}
