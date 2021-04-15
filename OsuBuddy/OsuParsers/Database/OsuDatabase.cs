using System;
using System.Collections.Generic;
using OsuParsers.Database.Objects;
using OsuParsers.Encoders;
using OsuParsers.Enums.Database;

namespace OsuParsers.Database
{
	// Token: 0x02000066 RID: 102
	public class OsuDatabase
	{
		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060001D7 RID: 471 RVA: 0x00002D54 File Offset: 0x00002D54
		// (set) Token: 0x060001D8 RID: 472 RVA: 0x00002D5C File Offset: 0x00002D5C
		public int OsuVersion { get; set; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060001D9 RID: 473 RVA: 0x00002D65 File Offset: 0x00002D65
		// (set) Token: 0x060001DA RID: 474 RVA: 0x00002D6D File Offset: 0x00002D6D
		public int FolderCount { get; set; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060001DB RID: 475 RVA: 0x00002D76 File Offset: 0x00002D76
		// (set) Token: 0x060001DC RID: 476 RVA: 0x00002D7E File Offset: 0x00002D7E
		public bool AccountUnlocked { get; set; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060001DD RID: 477 RVA: 0x00002D87 File Offset: 0x00002D87
		// (set) Token: 0x060001DE RID: 478 RVA: 0x00002D8F File Offset: 0x00002D8F
		public DateTime UnlockDate { get; set; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060001DF RID: 479 RVA: 0x00002D98 File Offset: 0x00002D98
		// (set) Token: 0x060001E0 RID: 480 RVA: 0x00002DA0 File Offset: 0x00002DA0
		public string PlayerName { get; set; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060001E1 RID: 481 RVA: 0x00002DA9 File Offset: 0x00002DA9
		// (set) Token: 0x060001E2 RID: 482 RVA: 0x00002DB1 File Offset: 0x00002DB1
		public int BeatmapCount { get; set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060001E3 RID: 483 RVA: 0x00002DBA File Offset: 0x00002DBA
		// (set) Token: 0x060001E4 RID: 484 RVA: 0x00002DC2 File Offset: 0x00002DC2
		public List<DbBeatmap> Beatmaps { get; set; } = new List<DbBeatmap>();

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060001E5 RID: 485 RVA: 0x00002DCB File Offset: 0x00002DCB
		// (set) Token: 0x060001E6 RID: 486 RVA: 0x00002DD3 File Offset: 0x00002DD3
		public Permissions Permissions { get; set; }

		// Token: 0x060001E7 RID: 487 RVA: 0x00002DDC File Offset: 0x00002DDC
		public void Save(string path)
		{
			DatabaseEncoder.EncodeOsuDatabase(path, this);
		}
	}
}
