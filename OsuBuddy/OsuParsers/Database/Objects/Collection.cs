﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace OsuParsers.Database.Objects
{
	// Token: 0x02000069 RID: 105
	public class Collection
	{
		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060001F5 RID: 501 RVA: 0x00002E7D File Offset: 0x0000107D
		// (set) Token: 0x060001F6 RID: 502 RVA: 0x00002E85 File Offset: 0x00001085
		public string Name { get; set; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060001F7 RID: 503 RVA: 0x00002E8E File Offset: 0x0000108E
		// (set) Token: 0x060001F8 RID: 504 RVA: 0x00002E96 File Offset: 0x00001096
		public int Count { get; set; }

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060001F9 RID: 505 RVA: 0x00002E9F File Offset: 0x0000109F
		// (set) Token: 0x060001FA RID: 506 RVA: 0x00002EA7 File Offset: 0x000010A7
		public List<string> MD5Hashes { get; private set; } = new List<string>();

		// Token: 0x04000253 RID: 595
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string ANamek__BackingField;

		// Token: 0x04000254 RID: 596
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int ACountk__BackingField;

		// Token: 0x04000255 RID: 597
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private List<string> AMD5Hashesk__BackingField;
	}
}
