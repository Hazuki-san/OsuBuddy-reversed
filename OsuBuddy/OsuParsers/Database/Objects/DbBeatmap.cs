using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using OsuParsers.Enums;
using OsuParsers.Enums.Database;

namespace OsuParsers.Database.Objects
{
	// Token: 0x0200006A RID: 106
	public class DbBeatmap
	{
		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060001FC RID: 508 RVA: 0x00002EC4 File Offset: 0x000010C4
		// (set) Token: 0x060001FD RID: 509 RVA: 0x00002ECC File Offset: 0x000010CC
		public int BytesOfBeatmapEntry { get; set; }

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060001FE RID: 510 RVA: 0x00002ED5 File Offset: 0x000010D5
		// (set) Token: 0x060001FF RID: 511 RVA: 0x00002EDD File Offset: 0x000010DD
		public string Artist { get; set; }

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000200 RID: 512 RVA: 0x00002EE6 File Offset: 0x000010E6
		// (set) Token: 0x06000201 RID: 513 RVA: 0x00002EEE File Offset: 0x000010EE
		public string ArtistUnicode { get; set; }

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000202 RID: 514 RVA: 0x00002EF7 File Offset: 0x000010F7
		// (set) Token: 0x06000203 RID: 515 RVA: 0x00002EFF File Offset: 0x000010FF
		public string Title { get; set; }

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06000204 RID: 516 RVA: 0x00002F08 File Offset: 0x00001108
		// (set) Token: 0x06000205 RID: 517 RVA: 0x00002F10 File Offset: 0x00001110
		public string TitleUnicode { get; set; }

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06000206 RID: 518 RVA: 0x00002F19 File Offset: 0x00001119
		// (set) Token: 0x06000207 RID: 519 RVA: 0x00002F21 File Offset: 0x00001121
		public string Creator { get; set; }

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000208 RID: 520 RVA: 0x00002F2A File Offset: 0x0000112A
		// (set) Token: 0x06000209 RID: 521 RVA: 0x00002F32 File Offset: 0x00001132
		public string Difficulty { get; set; }

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x0600020A RID: 522 RVA: 0x00002F3B File Offset: 0x0000113B
		// (set) Token: 0x0600020B RID: 523 RVA: 0x00002F43 File Offset: 0x00001143
		public string AudioFileName { get; set; }

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x0600020C RID: 524 RVA: 0x00002F4C File Offset: 0x0000114C
		// (set) Token: 0x0600020D RID: 525 RVA: 0x00002F54 File Offset: 0x00001154
		public string MD5Hash { get; set; }

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x0600020E RID: 526 RVA: 0x00002F5D File Offset: 0x0000115D
		// (set) Token: 0x0600020F RID: 527 RVA: 0x00002F65 File Offset: 0x00001165
		public string FileName { get; set; }

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000210 RID: 528 RVA: 0x00002F6E File Offset: 0x0000116E
		// (set) Token: 0x06000211 RID: 529 RVA: 0x00002F76 File Offset: 0x00001176
		public RankedStatus RankedStatus { get; set; }

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000212 RID: 530 RVA: 0x00002F7F File Offset: 0x0000117F
		// (set) Token: 0x06000213 RID: 531 RVA: 0x00002F87 File Offset: 0x00001187
		public ushort CirclesCount { get; set; }

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000214 RID: 532 RVA: 0x00002F90 File Offset: 0x00001190
		// (set) Token: 0x06000215 RID: 533 RVA: 0x00002F98 File Offset: 0x00001198
		public ushort SlidersCount { get; set; }

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000216 RID: 534 RVA: 0x00002FA1 File Offset: 0x000011A1
		// (set) Token: 0x06000217 RID: 535 RVA: 0x00002FA9 File Offset: 0x000011A9
		public ushort SpinnersCount { get; set; }

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000218 RID: 536 RVA: 0x00002FB2 File Offset: 0x000011B2
		// (set) Token: 0x06000219 RID: 537 RVA: 0x00002FBA File Offset: 0x000011BA
		public DateTime LastModifiedTime { get; set; }

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x0600021A RID: 538 RVA: 0x00002FC3 File Offset: 0x000011C3
		// (set) Token: 0x0600021B RID: 539 RVA: 0x00002FCB File Offset: 0x000011CB
		public float ApproachRate { get; set; }

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x0600021C RID: 540 RVA: 0x00002FD4 File Offset: 0x000011D4
		// (set) Token: 0x0600021D RID: 541 RVA: 0x00002FDC File Offset: 0x000011DC
		public float CircleSize { get; set; }

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x0600021E RID: 542 RVA: 0x00002FE5 File Offset: 0x000011E5
		// (set) Token: 0x0600021F RID: 543 RVA: 0x00002FED File Offset: 0x000011ED
		public float HPDrain { get; set; }

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000220 RID: 544 RVA: 0x00002FF6 File Offset: 0x000011F6
		// (set) Token: 0x06000221 RID: 545 RVA: 0x00002FFE File Offset: 0x000011FE
		public float OverallDifficulty { get; set; }

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000222 RID: 546 RVA: 0x00003007 File Offset: 0x00001207
		// (set) Token: 0x06000223 RID: 547 RVA: 0x0000300F File Offset: 0x0000120F
		public double SliderVelocity { get; set; }

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000224 RID: 548 RVA: 0x00003018 File Offset: 0x00001218
		// (set) Token: 0x06000225 RID: 549 RVA: 0x00003020 File Offset: 0x00001220
		public Dictionary<Mods, double> StandardStarRating { get; set; }

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000226 RID: 550 RVA: 0x00003029 File Offset: 0x00001229
		// (set) Token: 0x06000227 RID: 551 RVA: 0x00003031 File Offset: 0x00001231
		public Dictionary<Mods, double> TaikoStarRating { get; set; }

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000228 RID: 552 RVA: 0x0000303A File Offset: 0x0000123A
		// (set) Token: 0x06000229 RID: 553 RVA: 0x00003042 File Offset: 0x00001242
		public Dictionary<Mods, double> CatchStarRating { get; set; }

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x0600022A RID: 554 RVA: 0x0000304B File Offset: 0x0000124B
		// (set) Token: 0x0600022B RID: 555 RVA: 0x00003053 File Offset: 0x00001253
		public Dictionary<Mods, double> ManiaStarRating { get; set; }

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x0600022C RID: 556 RVA: 0x0000305C File Offset: 0x0000125C
		// (set) Token: 0x0600022D RID: 557 RVA: 0x00003064 File Offset: 0x00001264
		public int DrainTime { get; set; }

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x0600022E RID: 558 RVA: 0x0000306D File Offset: 0x0000126D
		// (set) Token: 0x0600022F RID: 559 RVA: 0x00003075 File Offset: 0x00001275
		public int TotalTime { get; set; }

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000230 RID: 560 RVA: 0x0000307E File Offset: 0x0000127E
		// (set) Token: 0x06000231 RID: 561 RVA: 0x00003086 File Offset: 0x00001286
		public int AudioPreviewTime { get; set; }

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000232 RID: 562 RVA: 0x0000308F File Offset: 0x0000128F
		// (set) Token: 0x06000233 RID: 563 RVA: 0x00003097 File Offset: 0x00001297
		public List<DbTimingPoint> TimingPoints { get; private set; } = new List<DbTimingPoint>();

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000234 RID: 564 RVA: 0x000030A0 File Offset: 0x000012A0
		// (set) Token: 0x06000235 RID: 565 RVA: 0x000030A8 File Offset: 0x000012A8
		public int BeatmapId { get; set; }

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000236 RID: 566 RVA: 0x000030B1 File Offset: 0x000012B1
		// (set) Token: 0x06000237 RID: 567 RVA: 0x000030B9 File Offset: 0x000012B9
		public int BeatmapSetId { get; set; }

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000238 RID: 568 RVA: 0x000030C2 File Offset: 0x000012C2
		// (set) Token: 0x06000239 RID: 569 RVA: 0x000030CA File Offset: 0x000012CA
		public int ThreadId { get; set; }

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x0600023A RID: 570 RVA: 0x000030D3 File Offset: 0x000012D3
		// (set) Token: 0x0600023B RID: 571 RVA: 0x000030DB File Offset: 0x000012DB
		public Grade StandardGrade { get; set; }

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x0600023C RID: 572 RVA: 0x000030E4 File Offset: 0x000012E4
		// (set) Token: 0x0600023D RID: 573 RVA: 0x000030EC File Offset: 0x000012EC
		public Grade TaikoGrade { get; set; }

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x0600023E RID: 574 RVA: 0x000030F5 File Offset: 0x000012F5
		// (set) Token: 0x0600023F RID: 575 RVA: 0x000030FD File Offset: 0x000012FD
		public Grade CatchGrade { get; set; }

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000240 RID: 576 RVA: 0x00003106 File Offset: 0x00001306
		// (set) Token: 0x06000241 RID: 577 RVA: 0x0000310E File Offset: 0x0000130E
		public Grade ManiaGrade { get; set; }

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000242 RID: 578 RVA: 0x00003117 File Offset: 0x00001317
		// (set) Token: 0x06000243 RID: 579 RVA: 0x0000311F File Offset: 0x0000131F
		public short LocalOffset { get; set; }

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000244 RID: 580 RVA: 0x00003128 File Offset: 0x00001328
		// (set) Token: 0x06000245 RID: 581 RVA: 0x00003130 File Offset: 0x00001330
		public float StackLeniency { get; set; }

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000246 RID: 582 RVA: 0x00003139 File Offset: 0x00001339
		// (set) Token: 0x06000247 RID: 583 RVA: 0x00003141 File Offset: 0x00001341
		public Ruleset Ruleset { get; set; }

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06000248 RID: 584 RVA: 0x0000314A File Offset: 0x0000134A
		// (set) Token: 0x06000249 RID: 585 RVA: 0x00003152 File Offset: 0x00001352
		public string Source { get; set; }

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x0600024A RID: 586 RVA: 0x0000315B File Offset: 0x0000135B
		// (set) Token: 0x0600024B RID: 587 RVA: 0x00003163 File Offset: 0x00001363
		public string Tags { get; set; }

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x0600024C RID: 588 RVA: 0x0000316C File Offset: 0x0000136C
		// (set) Token: 0x0600024D RID: 589 RVA: 0x00003174 File Offset: 0x00001374
		public short OnlineOffset { get; set; }

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x0600024E RID: 590 RVA: 0x0000317D File Offset: 0x0000137D
		// (set) Token: 0x0600024F RID: 591 RVA: 0x00003185 File Offset: 0x00001385
		public string TitleFont { get; set; }

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000250 RID: 592 RVA: 0x0000318E File Offset: 0x0000138E
		// (set) Token: 0x06000251 RID: 593 RVA: 0x00003196 File Offset: 0x00001396
		public bool IsUnplayed { get; set; }

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000252 RID: 594 RVA: 0x0000319F File Offset: 0x0000139F
		// (set) Token: 0x06000253 RID: 595 RVA: 0x000031A7 File Offset: 0x000013A7
		public DateTime LastPlayed { get; set; }

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000254 RID: 596 RVA: 0x000031B0 File Offset: 0x000013B0
		// (set) Token: 0x06000255 RID: 597 RVA: 0x000031B8 File Offset: 0x000013B8
		public bool IsOsz2 { get; set; }

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x06000256 RID: 598 RVA: 0x000031C1 File Offset: 0x000013C1
		// (set) Token: 0x06000257 RID: 599 RVA: 0x000031C9 File Offset: 0x000013C9
		public string FolderName { get; set; }

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000258 RID: 600 RVA: 0x000031D2 File Offset: 0x000013D2
		// (set) Token: 0x06000259 RID: 601 RVA: 0x000031DA File Offset: 0x000013DA
		public DateTime LastCheckedAgainstOsuRepo { get; set; }

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x0600025A RID: 602 RVA: 0x000031E3 File Offset: 0x000013E3
		// (set) Token: 0x0600025B RID: 603 RVA: 0x000031EB File Offset: 0x000013EB
		public bool IgnoreBeatmapSound { get; set; }

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x0600025C RID: 604 RVA: 0x000031F4 File Offset: 0x000013F4
		// (set) Token: 0x0600025D RID: 605 RVA: 0x000031FC File Offset: 0x000013FC
		public bool IgnoreBeatmapSkin { get; set; }

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x0600025E RID: 606 RVA: 0x00003205 File Offset: 0x00001405
		// (set) Token: 0x0600025F RID: 607 RVA: 0x0000320D File Offset: 0x0000140D
		public bool DisableStoryboard { get; set; }

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000260 RID: 608 RVA: 0x00003216 File Offset: 0x00001416
		// (set) Token: 0x06000261 RID: 609 RVA: 0x0000321E File Offset: 0x0000141E
		public bool DisableVideo { get; set; }

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000262 RID: 610 RVA: 0x00003227 File Offset: 0x00001427
		// (set) Token: 0x06000263 RID: 611 RVA: 0x0000322F File Offset: 0x0000142F
		public bool VisualOverride { get; set; }

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000264 RID: 612 RVA: 0x00003238 File Offset: 0x00001438
		// (set) Token: 0x06000265 RID: 613 RVA: 0x00003240 File Offset: 0x00001440
		public byte ManiaScrollSpeed { get; set; }

		// Token: 0x04000256 RID: 598
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int ABytesOfBeatmapEntryk__BackingField;

		// Token: 0x04000257 RID: 599
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string AArtistk__BackingField;

		// Token: 0x04000258 RID: 600
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string AArtistUnicodek__BackingField;

		// Token: 0x04000259 RID: 601
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string ATitlek__BackingField;

		// Token: 0x0400025A RID: 602
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string ATitleUnicodek__BackingField;

		// Token: 0x0400025B RID: 603
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string ACreatork__BackingField;

		// Token: 0x0400025C RID: 604
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string ADifficultyk__BackingField;

		// Token: 0x0400025D RID: 605
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string AAudioFileNamek__BackingField;

		// Token: 0x0400025E RID: 606
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string AMD5Hashk__BackingField;

		// Token: 0x0400025F RID: 607
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string AFileNamek__BackingField;

		// Token: 0x04000260 RID: 608
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private RankedStatus ARankedStatusk__BackingField;

		// Token: 0x04000261 RID: 609
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ushort ACirclesCountk__BackingField;

		// Token: 0x04000262 RID: 610
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ushort ASlidersCountk__BackingField;

		// Token: 0x04000263 RID: 611
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ushort ASpinnersCountk__BackingField;

		// Token: 0x04000264 RID: 612
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime ALastModifiedTimek__BackingField;

		// Token: 0x04000265 RID: 613
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float AApproachRatek__BackingField;

		// Token: 0x04000266 RID: 614
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float ACircleSizek__BackingField;

		// Token: 0x04000267 RID: 615
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float AHPDraink__BackingField;

		// Token: 0x04000268 RID: 616
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float AOverallDifficultyk__BackingField;

		// Token: 0x04000269 RID: 617
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double ASliderVelocityk__BackingField;

		// Token: 0x0400026A RID: 618
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Dictionary<Mods, double> AStandardStarRatingk__BackingField;

		// Token: 0x0400026B RID: 619
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Dictionary<Mods, double> ATaikoStarRatingk__BackingField;

		// Token: 0x0400026C RID: 620
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Dictionary<Mods, double> ACatchStarRatingk__BackingField;

		// Token: 0x0400026D RID: 621
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Dictionary<Mods, double> AManiaStarRatingk__BackingField;

		// Token: 0x0400026E RID: 622
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int ADrainTimek__BackingField;

		// Token: 0x0400026F RID: 623
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int ATotalTimek__BackingField;

		// Token: 0x04000270 RID: 624
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int AAudioPreviewTimek__BackingField;

		// Token: 0x04000271 RID: 625
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private List<DbTimingPoint> ATimingPointsk__BackingField;

		// Token: 0x04000272 RID: 626
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int ABeatmapIdk__BackingField;

		// Token: 0x04000273 RID: 627
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int ABeatmapSetIdk__BackingField;

		// Token: 0x04000274 RID: 628
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int AThreadIdk__BackingField;

		// Token: 0x04000275 RID: 629
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Grade AStandardGradek__BackingField;

		// Token: 0x04000276 RID: 630
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Grade ATaikoGradek__BackingField;

		// Token: 0x04000277 RID: 631
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Grade ACatchGradek__BackingField;

		// Token: 0x04000278 RID: 632
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Grade AManiaGradek__BackingField;

		// Token: 0x04000279 RID: 633
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private short ALocalOffsetk__BackingField;

		// Token: 0x0400027A RID: 634
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float AStackLeniencyk__BackingField;

		// Token: 0x0400027B RID: 635
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Ruleset ARulesetk__BackingField;

		// Token: 0x0400027C RID: 636
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string ASourcek__BackingField;

		// Token: 0x0400027D RID: 637
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string ATagsk__BackingField;

		// Token: 0x0400027E RID: 638
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private short AOnlineOffsetk__BackingField;

		// Token: 0x0400027F RID: 639
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string ATitleFontk__BackingField;

		// Token: 0x04000280 RID: 640
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool AIsUnplayedk__BackingField;

		// Token: 0x04000281 RID: 641
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime ALastPlayedk__BackingField;

		// Token: 0x04000282 RID: 642
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool AIsOsz2k__BackingField;

		// Token: 0x04000283 RID: 643
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string AFolderNamek__BackingField;

		// Token: 0x04000284 RID: 644
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime ALastCheckedAgainstOsuRepok__BackingField;

		// Token: 0x04000285 RID: 645
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool AIgnoreBeatmapSoundk__BackingField;

		// Token: 0x04000286 RID: 646
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool AIgnoreBeatmapSkink__BackingField;

		// Token: 0x04000287 RID: 647
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool ADisableStoryboardk__BackingField;

		// Token: 0x04000288 RID: 648
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool ADisableVideok__BackingField;

		// Token: 0x04000289 RID: 649
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool AVisualOverridek__BackingField;

		// Token: 0x0400028A RID: 650
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private byte AManiaScrollSpeedk__BackingField;
	}
}
