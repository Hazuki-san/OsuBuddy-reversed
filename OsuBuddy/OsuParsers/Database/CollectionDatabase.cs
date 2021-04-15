﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using OsuParsers.Database.Objects;
using OsuParsers.Encoders;

namespace OsuParsers.Database
{
	// Token: 0x02000065 RID: 101
	public class CollectionDatabase
	{
		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060001CF RID: 463 RVA: 0x00002D02 File Offset: 0x00000F02
		// (set) Token: 0x060001D0 RID: 464 RVA: 0x00002D0A File Offset: 0x00000F0A
		public int OsuVersion { get; set; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060001D1 RID: 465 RVA: 0x00002D13 File Offset: 0x00000F13
		// (set) Token: 0x060001D2 RID: 466 RVA: 0x00002D1B File Offset: 0x00000F1B
		public int CollectionCount { get; set; }

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060001D3 RID: 467 RVA: 0x00002D24 File Offset: 0x00000F24
		// (set) Token: 0x060001D4 RID: 468 RVA: 0x00002D2C File Offset: 0x00000F2C
		public List<Collection> Collections { get; set; } = new List<Collection>();

		// Token: 0x060001D5 RID: 469 RVA: 0x00002D35 File Offset: 0x00000F35
		public void Save(string path)
		{
			DatabaseEncoder.EncodeCollectionDatabase(path, this);
		}

		// Token: 0x04000244 RID: 580
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int AOsuVersionk__BackingField;

		// Token: 0x04000245 RID: 581
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int ACollectionCountk__BackingField;

		// Token: 0x04000246 RID: 582
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private List<Collection> ACollectionsk__BackingField;
	}
}
