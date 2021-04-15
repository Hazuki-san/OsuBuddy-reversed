using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using OsuParsers.Helpers;

namespace OsuParsers.Beatmaps.Sections
{
	// Token: 0x02000075 RID: 117
	public class BeatmapMetadataSection
	{
		// Token: 0x170000CC RID: 204
		// (get) Token: 0x0600030F RID: 783 RVA: 0x000037FB File Offset: 0x000019FB
		// (set) Token: 0x06000310 RID: 784 RVA: 0x00003803 File Offset: 0x00001A03
		public string Title { get; set; }

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000311 RID: 785 RVA: 0x0000380C File Offset: 0x00001A0C
		// (set) Token: 0x06000312 RID: 786 RVA: 0x00003814 File Offset: 0x00001A14
		public string TitleUnicode { get; set; }

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000313 RID: 787 RVA: 0x0000381D File Offset: 0x00001A1D
		// (set) Token: 0x06000314 RID: 788 RVA: 0x00003825 File Offset: 0x00001A25
		public string Artist { get; set; }

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000315 RID: 789 RVA: 0x0000382E File Offset: 0x00001A2E
		// (set) Token: 0x06000316 RID: 790 RVA: 0x00003836 File Offset: 0x00001A36
		public string ArtistUnicode { get; set; }

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x06000317 RID: 791 RVA: 0x0000383F File Offset: 0x00001A3F
		// (set) Token: 0x06000318 RID: 792 RVA: 0x00003847 File Offset: 0x00001A47
		public string Creator { get; set; }

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000319 RID: 793 RVA: 0x00003850 File Offset: 0x00001A50
		// (set) Token: 0x0600031A RID: 794 RVA: 0x00003858 File Offset: 0x00001A58
		public string Version { get; set; }

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x0600031B RID: 795 RVA: 0x00003861 File Offset: 0x00001A61
		// (set) Token: 0x0600031C RID: 796 RVA: 0x00003869 File Offset: 0x00001A69
		public string Source { get; set; }

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x0600031D RID: 797 RVA: 0x00003872 File Offset: 0x00001A72
		// (set) Token: 0x0600031E RID: 798 RVA: 0x0000387A File Offset: 0x00001A7A
		public string[] Tags { get; set; }

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x0600031F RID: 799 RVA: 0x00003883 File Offset: 0x00001A83
		// (set) Token: 0x06000320 RID: 800 RVA: 0x00003892 File Offset: 0x00001A92
		public string TagsString
		{
			get
			{
				return this.Tags.Join(' ');
			}
			set
			{
				this.Tags = value.Split(new char[]
				{
					' '
				});
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06000321 RID: 801 RVA: 0x000038AC File Offset: 0x00001AAC
		// (set) Token: 0x06000322 RID: 802 RVA: 0x000038B4 File Offset: 0x00001AB4
		public int BeatmapID { get; set; }

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x06000323 RID: 803 RVA: 0x000038BD File Offset: 0x00001ABD
		// (set) Token: 0x06000324 RID: 804 RVA: 0x000038C5 File Offset: 0x00001AC5
		public int BeatmapSetID { get; set; }

		// Token: 0x040002DA RID: 730
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string ATitlek__BackingField;

		// Token: 0x040002DB RID: 731
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string ATitleUnicodek__BackingField;

		// Token: 0x040002DC RID: 732
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string AArtistk__BackingField;

		// Token: 0x040002DD RID: 733
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string AArtistUnicodek__BackingField;

		// Token: 0x040002DE RID: 734
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string ACreatork__BackingField;

		// Token: 0x040002DF RID: 735
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string AVersionk__BackingField;

		// Token: 0x040002E0 RID: 736
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string ASourcek__BackingField;

		// Token: 0x040002E1 RID: 737
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string[] ATagsk__BackingField;

		// Token: 0x040002E2 RID: 738
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int ABeatmapIDk__BackingField;

		// Token: 0x040002E3 RID: 739
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int ABeatmapSetIDk__BackingField;
	}
}
