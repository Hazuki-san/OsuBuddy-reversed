using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using OsuParsers.Database.Objects;
using OsuParsers.Encoders;
using OsuParsers.Enums.Database;

namespace OsuParsers.Database
{
	// Token: 0x02000066 RID: 102
	public class OsuDatabase
	{
		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060001D7 RID: 471 RVA: 0x00002D54 File Offset: 0x00000F54
		// (set) Token: 0x060001D8 RID: 472 RVA: 0x00002D5C File Offset: 0x00000F5C
		public int OsuVersion { get; set; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060001D9 RID: 473 RVA: 0x00002D65 File Offset: 0x00000F65
		// (set) Token: 0x060001DA RID: 474 RVA: 0x00002D6D File Offset: 0x00000F6D
		public int FolderCount { get; set; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060001DB RID: 475 RVA: 0x00002D76 File Offset: 0x00000F76
		// (set) Token: 0x060001DC RID: 476 RVA: 0x00002D7E File Offset: 0x00000F7E
		public bool AccountUnlocked { get; set; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060001DD RID: 477 RVA: 0x00002D87 File Offset: 0x00000F87
		// (set) Token: 0x060001DE RID: 478 RVA: 0x00002D8F File Offset: 0x00000F8F
		public DateTime UnlockDate { get; set; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060001DF RID: 479 RVA: 0x00002D98 File Offset: 0x00000F98
		// (set) Token: 0x060001E0 RID: 480 RVA: 0x00002DA0 File Offset: 0x00000FA0
		public string PlayerName { get; set; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060001E1 RID: 481 RVA: 0x00002DA9 File Offset: 0x00000FA9
		// (set) Token: 0x060001E2 RID: 482 RVA: 0x00002DB1 File Offset: 0x00000FB1
		public int BeatmapCount { get; set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060001E3 RID: 483 RVA: 0x00002DBA File Offset: 0x00000FBA
		// (set) Token: 0x060001E4 RID: 484 RVA: 0x00002DC2 File Offset: 0x00000FC2
		public List<DbBeatmap> Beatmaps { get; set; } = new List<DbBeatmap>();

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060001E5 RID: 485 RVA: 0x00002DCB File Offset: 0x00000FCB
		// (set) Token: 0x060001E6 RID: 486 RVA: 0x00002DD3 File Offset: 0x00000FD3
		public Permissions Permissions { get; set; }

		// Token: 0x060001E7 RID: 487 RVA: 0x00002DDC File Offset: 0x00000FDC
		public void Save(string path)
		{
			DatabaseEncoder.EncodeOsuDatabase(path, this);
		}

		// Token: 0x04000247 RID: 583
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int AOsuVersionk__BackingField;

		// Token: 0x04000248 RID: 584
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int AFolderCountk__BackingField;

		// Token: 0x04000249 RID: 585
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool AAccountUnlockedk__BackingField;

		// Token: 0x0400024A RID: 586
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime AUnlockDatek__BackingField;

		// Token: 0x0400024B RID: 587
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string APlayerNamek__BackingField;

		// Token: 0x0400024C RID: 588
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int ABeatmapCountk__BackingField;

		// Token: 0x0400024D RID: 589
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private List<DbBeatmap> ABeatmapsk__BackingField;

		// Token: 0x0400024E RID: 590
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Permissions APermissionsk__BackingField;
	}
}
