using System;
using OsuParsers.Helpers;

namespace OsuParsers.Beatmaps.Sections
{
	// Token: 0x02000075 RID: 117
	public class BeatmapMetadataSection
	{
		// Token: 0x170000CC RID: 204
		// (get) Token: 0x0600030F RID: 783 RVA: 0x000037FB File Offset: 0x000037FB
		// (set) Token: 0x06000310 RID: 784 RVA: 0x00003803 File Offset: 0x00003803
		public string Title { get; set; }

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000311 RID: 785 RVA: 0x0000380C File Offset: 0x0000380C
		// (set) Token: 0x06000312 RID: 786 RVA: 0x00003814 File Offset: 0x00003814
		public string TitleUnicode { get; set; }

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000313 RID: 787 RVA: 0x0000381D File Offset: 0x0000381D
		// (set) Token: 0x06000314 RID: 788 RVA: 0x00003825 File Offset: 0x00003825
		public string Artist { get; set; }

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000315 RID: 789 RVA: 0x0000382E File Offset: 0x0000382E
		// (set) Token: 0x06000316 RID: 790 RVA: 0x00003836 File Offset: 0x00003836
		public string ArtistUnicode { get; set; }

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x06000317 RID: 791 RVA: 0x0000383F File Offset: 0x0000383F
		// (set) Token: 0x06000318 RID: 792 RVA: 0x00003847 File Offset: 0x00003847
		public string Creator { get; set; }

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000319 RID: 793 RVA: 0x00003850 File Offset: 0x00003850
		// (set) Token: 0x0600031A RID: 794 RVA: 0x00003858 File Offset: 0x00003858
		public string Version { get; set; }

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x0600031B RID: 795 RVA: 0x00003861 File Offset: 0x00003861
		// (set) Token: 0x0600031C RID: 796 RVA: 0x00003869 File Offset: 0x00003869
		public string Source { get; set; }

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x0600031D RID: 797 RVA: 0x00003872 File Offset: 0x00003872
		// (set) Token: 0x0600031E RID: 798 RVA: 0x0000387A File Offset: 0x0000387A
		public string[] Tags { get; set; }

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x0600031F RID: 799 RVA: 0x00003883 File Offset: 0x00003883
		// (set) Token: 0x06000320 RID: 800 RVA: 0x00003892 File Offset: 0x00003892
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
		// (get) Token: 0x06000321 RID: 801 RVA: 0x000038AC File Offset: 0x000038AC
		// (set) Token: 0x06000322 RID: 802 RVA: 0x000038B4 File Offset: 0x000038B4
		public int BeatmapID { get; set; }

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x06000323 RID: 803 RVA: 0x000038BD File Offset: 0x000038BD
		// (set) Token: 0x06000324 RID: 804 RVA: 0x000038C5 File Offset: 0x000038C5
		public int BeatmapSetID { get; set; }
	}
}
