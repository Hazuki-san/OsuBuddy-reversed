using System;
using System.Collections.Generic;
using OsuParsers.Database.Objects;
using OsuParsers.Encoders;

namespace OsuParsers.Database
{
	// Token: 0x02000067 RID: 103
	public class PresenceDatabase
	{
		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060001E9 RID: 489 RVA: 0x00002DFB File Offset: 0x00002DFB
		// (set) Token: 0x060001EA RID: 490 RVA: 0x00002E03 File Offset: 0x00002E03
		public int OsuVersion { get; set; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060001EB RID: 491 RVA: 0x00002E0C File Offset: 0x00002E0C
		// (set) Token: 0x060001EC RID: 492 RVA: 0x00002E14 File Offset: 0x00002E14
		public List<Player> Players { get; set; } = new List<Player>();

		// Token: 0x060001ED RID: 493 RVA: 0x00002E1D File Offset: 0x00002E1D
		public void Save(string path)
		{
			DatabaseEncoder.EncodePresenceDatabase(path, this);
		}
	}
}
