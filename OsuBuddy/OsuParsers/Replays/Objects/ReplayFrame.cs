﻿using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using OsuParsers.Enums.Replays;

namespace OsuParsers.Replays.Objects
{
	// Token: 0x02000034 RID: 52
	public class ReplayFrame
	{
		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000139 RID: 313 RVA: 0x000028FC File Offset: 0x00000AFC
		// (set) Token: 0x0600013A RID: 314 RVA: 0x00002904 File Offset: 0x00000B04
		public float X { get; set; }

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x0600013B RID: 315 RVA: 0x0000290D File Offset: 0x00000B0D
		// (set) Token: 0x0600013C RID: 316 RVA: 0x00002915 File Offset: 0x00000B15
		public float Y { get; set; }

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x0600013D RID: 317 RVA: 0x0000291E File Offset: 0x00000B1E
		// (set) Token: 0x0600013E RID: 318 RVA: 0x00002926 File Offset: 0x00000B26
		public int TimeDiff { get; set; }

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x0600013F RID: 319 RVA: 0x0000292F File Offset: 0x00000B2F
		// (set) Token: 0x06000140 RID: 320 RVA: 0x00002937 File Offset: 0x00000B37
		public int Time { get; set; }

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000141 RID: 321 RVA: 0x00002940 File Offset: 0x00000B40
		// (set) Token: 0x06000142 RID: 322 RVA: 0x00002948 File Offset: 0x00000B48
		public StandardKeys StandardKeys { get; set; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000143 RID: 323 RVA: 0x00002951 File Offset: 0x00000B51
		// (set) Token: 0x06000144 RID: 324 RVA: 0x00002959 File Offset: 0x00000B59
		public TaikoKeys TaikoKeys { get; set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000145 RID: 325 RVA: 0x00002962 File Offset: 0x00000B62
		// (set) Token: 0x06000146 RID: 326 RVA: 0x0000296A File Offset: 0x00000B6A
		public CatchKeys CatchKeys { get; set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000147 RID: 327 RVA: 0x00002973 File Offset: 0x00000B73
		// (set) Token: 0x06000148 RID: 328 RVA: 0x0000297B File Offset: 0x00000B7B
		public ManiaKeys ManiaKeys { get; set; }

		// Token: 0x04000136 RID: 310
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float AXk__BackingField;

		// Token: 0x04000137 RID: 311
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float AYk__BackingField;

		// Token: 0x04000138 RID: 312
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int ATimeDiffk__BackingField;

		// Token: 0x04000139 RID: 313
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int ATimek__BackingField;

		// Token: 0x0400013A RID: 314
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private StandardKeys AStandardKeysk__BackingField;

		// Token: 0x0400013B RID: 315
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaikoKeys ATaikoKeysk__BackingField;

		// Token: 0x0400013C RID: 316
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private CatchKeys ACatchKeysk__BackingField;

		// Token: 0x0400013D RID: 317
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ManiaKeys AManiaKeysk__BackingField;
	}
}
