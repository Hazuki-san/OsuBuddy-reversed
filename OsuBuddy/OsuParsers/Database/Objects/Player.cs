using System;
using OsuParsers.Enums;
using OsuParsers.Enums.Database;

namespace OsuParsers.Database.Objects
{
	// Token: 0x0200006C RID: 108
	public class Player
	{
		// Token: 0x17000082 RID: 130
		// (get) Token: 0x0600026E RID: 622 RVA: 0x00003290 File Offset: 0x00003290
		// (set) Token: 0x0600026F RID: 623 RVA: 0x00003298 File Offset: 0x00003298
		public int UserId { get; set; }

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000270 RID: 624 RVA: 0x000032A1 File Offset: 0x000032A1
		// (set) Token: 0x06000271 RID: 625 RVA: 0x000032A9 File Offset: 0x000032A9
		public string Username { get; set; }

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000272 RID: 626 RVA: 0x000032B2 File Offset: 0x000032B2
		// (set) Token: 0x06000273 RID: 627 RVA: 0x000032BA File Offset: 0x000032BA
		public int Timezone { get; set; }

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000274 RID: 628 RVA: 0x000032C3 File Offset: 0x000032C3
		// (set) Token: 0x06000275 RID: 629 RVA: 0x000032CB File Offset: 0x000032CB
		public byte CountryCode { get; set; }

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000276 RID: 630 RVA: 0x000032D4 File Offset: 0x000032D4
		// (set) Token: 0x06000277 RID: 631 RVA: 0x000032DC File Offset: 0x000032DC
		public Permissions Permissions { get; set; }

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000278 RID: 632 RVA: 0x000032E5 File Offset: 0x000032E5
		// (set) Token: 0x06000279 RID: 633 RVA: 0x000032ED File Offset: 0x000032ED
		public Ruleset Ruleset { get; set; }

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x0600027A RID: 634 RVA: 0x000032F6 File Offset: 0x000032F6
		// (set) Token: 0x0600027B RID: 635 RVA: 0x000032FE File Offset: 0x000032FE
		public float Longitude { get; set; }

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x0600027C RID: 636 RVA: 0x00003307 File Offset: 0x00003307
		// (set) Token: 0x0600027D RID: 637 RVA: 0x0000330F File Offset: 0x0000330F
		public float Latitude { get; set; }

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x0600027E RID: 638 RVA: 0x00003318 File Offset: 0x00003318
		// (set) Token: 0x0600027F RID: 639 RVA: 0x00003320 File Offset: 0x00003320
		public int Rank { get; set; }

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000280 RID: 640 RVA: 0x00003329 File Offset: 0x00003329
		// (set) Token: 0x06000281 RID: 641 RVA: 0x00003331 File Offset: 0x00003331
		public DateTime LastUpdateTime { get; set; }
	}
}
