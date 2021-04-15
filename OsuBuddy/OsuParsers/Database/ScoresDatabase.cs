using System;
using System.Collections.Generic;
using OsuParsers.Database.Objects;
using OsuParsers.Encoders;

namespace OsuParsers.Database
{
	// Token: 0x02000068 RID: 104
	public class ScoresDatabase
	{
		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060001EF RID: 495 RVA: 0x00002E3C File Offset: 0x00002E3C
		// (set) Token: 0x060001F0 RID: 496 RVA: 0x00002E44 File Offset: 0x00002E44
		public int OsuVersion { get; set; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060001F1 RID: 497 RVA: 0x00002E4D File Offset: 0x00002E4D
		// (set) Token: 0x060001F2 RID: 498 RVA: 0x00002E55 File Offset: 0x00002E55
		public List<Tuple<string, List<Score>>> Scores { get; set; } = new List<Tuple<string, List<Score>>>();

		// Token: 0x060001F3 RID: 499 RVA: 0x00002E5E File Offset: 0x00002E5E
		public void Save(string path)
		{
			DatabaseEncoder.EncodeScoresDatabase(path, this);
		}
	}
}
