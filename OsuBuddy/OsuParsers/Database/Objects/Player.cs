using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using OsuParsers.Enums;
using OsuParsers.Enums.Database;

namespace OsuParsers.Database.Objects
{
	// Token: 0x0200006C RID: 108
	public class Player
	{
		// Token: 0x17000082 RID: 130
		// (get) Token: 0x0600026E RID: 622 RVA: 0x00003290 File Offset: 0x00001490
		// (set) Token: 0x0600026F RID: 623 RVA: 0x00003298 File Offset: 0x00001498
		public int UserId { get; set; }

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000270 RID: 624 RVA: 0x000032A1 File Offset: 0x000014A1
		// (set) Token: 0x06000271 RID: 625 RVA: 0x000032A9 File Offset: 0x000014A9
		public string Username { get; set; }

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000272 RID: 626 RVA: 0x000032B2 File Offset: 0x000014B2
		// (set) Token: 0x06000273 RID: 627 RVA: 0x000032BA File Offset: 0x000014BA
		public int Timezone { get; set; }

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000274 RID: 628 RVA: 0x000032C3 File Offset: 0x000014C3
		// (set) Token: 0x06000275 RID: 629 RVA: 0x000032CB File Offset: 0x000014CB
		public byte CountryCode { get; set; }

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000276 RID: 630 RVA: 0x000032D4 File Offset: 0x000014D4
		// (set) Token: 0x06000277 RID: 631 RVA: 0x000032DC File Offset: 0x000014DC
		public Permissions Permissions { get; set; }

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000278 RID: 632 RVA: 0x000032E5 File Offset: 0x000014E5
		// (set) Token: 0x06000279 RID: 633 RVA: 0x000032ED File Offset: 0x000014ED
		public Ruleset Ruleset { get; set; }

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x0600027A RID: 634 RVA: 0x000032F6 File Offset: 0x000014F6
		// (set) Token: 0x0600027B RID: 635 RVA: 0x000032FE File Offset: 0x000014FE
		public float Longitude { get; set; }

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x0600027C RID: 636 RVA: 0x00003307 File Offset: 0x00001507
		// (set) Token: 0x0600027D RID: 637 RVA: 0x0000330F File Offset: 0x0000150F
		public float Latitude { get; set; }

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x0600027E RID: 638 RVA: 0x00003318 File Offset: 0x00001518
		// (set) Token: 0x0600027F RID: 639 RVA: 0x00003320 File Offset: 0x00001520
		public int Rank { get; set; }

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000280 RID: 640 RVA: 0x00003329 File Offset: 0x00001529
		// (set) Token: 0x06000281 RID: 641 RVA: 0x00003331 File Offset: 0x00001531
		public DateTime LastUpdateTime { get; set; }

		// Token: 0x0400028E RID: 654
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int AUserIdk__BackingField;

		// Token: 0x0400028F RID: 655
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string AUsernamek__BackingField;

		// Token: 0x04000290 RID: 656
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int ATimezonek__BackingField;

		// Token: 0x04000291 RID: 657
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private byte ACountryCodek__BackingField;

		// Token: 0x04000292 RID: 658
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Permissions APermissionsk__BackingField;

		// Token: 0x04000293 RID: 659
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Ruleset ARulesetk__BackingField;

		// Token: 0x04000294 RID: 660
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float ALongitudek__BackingField;

		// Token: 0x04000295 RID: 661
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float ALatitudek__BackingField;

		// Token: 0x04000296 RID: 662
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int ARankk__BackingField;

		// Token: 0x04000297 RID: 663
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime ALastUpdateTimek__BackingField;
	}
}
