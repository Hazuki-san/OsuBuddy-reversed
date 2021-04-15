using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using OsuParsers.Database.Objects;
using OsuParsers.Encoders;

namespace OsuParsers.Database
{
	// Token: 0x02000068 RID: 104
	public class ScoresDatabase
	{
		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060001EF RID: 495 RVA: 0x00002E3C File Offset: 0x0000103C
		// (set) Token: 0x060001F0 RID: 496 RVA: 0x00002E44 File Offset: 0x00001044
		public int OsuVersion { get; set; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060001F1 RID: 497 RVA: 0x00002E4D File Offset: 0x0000104D
		// (set) Token: 0x060001F2 RID: 498 RVA: 0x00002E55 File Offset: 0x00001055
		public List<Tuple<string, List<Score>>> Scores { get; set; } = new List<Tuple<string, List<Score>>>();

		// Token: 0x060001F3 RID: 499 RVA: 0x00002E5E File Offset: 0x0000105E
		public void Save(string path)
		{
			DatabaseEncoder.EncodeScoresDatabase(path, this);
		}

		// Token: 0x04000251 RID: 593
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int AOsuVersionk__BackingField;

		// Token: 0x04000252 RID: 594
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private List<Tuple<string, List<Score>>> AScoresk__BackingField;
	}
}
