using System;
using System.Collections.Generic;
using OsuParsers.Encoders;
using OsuParsers.Enums;
using OsuParsers.Replays.Objects;

namespace OsuParsers.Replays
{
	// Token: 0x02000031 RID: 49
	public class Replay
	{
		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000103 RID: 259 RVA: 0x0000274B File Offset: 0x0000274B
		// (set) Token: 0x06000104 RID: 260 RVA: 0x00002753 File Offset: 0x00002753
		public Ruleset Ruleset { get; set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000105 RID: 261 RVA: 0x0000275C File Offset: 0x0000275C
		// (set) Token: 0x06000106 RID: 262 RVA: 0x00002764 File Offset: 0x00002764
		public int OsuVersion { get; set; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000107 RID: 263 RVA: 0x0000276D File Offset: 0x0000276D
		// (set) Token: 0x06000108 RID: 264 RVA: 0x00002775 File Offset: 0x00002775
		public string BeatmapMD5Hash { get; set; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000109 RID: 265 RVA: 0x0000277E File Offset: 0x0000277E
		// (set) Token: 0x0600010A RID: 266 RVA: 0x00002786 File Offset: 0x00002786
		public string PlayerName { get; set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600010B RID: 267 RVA: 0x0000278F File Offset: 0x0000278F
		// (set) Token: 0x0600010C RID: 268 RVA: 0x00002797 File Offset: 0x00002797
		public string ReplayMD5Hash { get; set; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600010D RID: 269 RVA: 0x000027A0 File Offset: 0x000027A0
		// (set) Token: 0x0600010E RID: 270 RVA: 0x000027A8 File Offset: 0x000027A8
		public ushort Count300 { get; set; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600010F RID: 271 RVA: 0x000027B1 File Offset: 0x000027B1
		// (set) Token: 0x06000110 RID: 272 RVA: 0x000027B9 File Offset: 0x000027B9
		public ushort Count100 { get; set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000111 RID: 273 RVA: 0x000027C2 File Offset: 0x000027C2
		// (set) Token: 0x06000112 RID: 274 RVA: 0x000027CA File Offset: 0x000027CA
		public ushort Count50 { get; set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000113 RID: 275 RVA: 0x000027D3 File Offset: 0x000027D3
		// (set) Token: 0x06000114 RID: 276 RVA: 0x000027DB File Offset: 0x000027DB
		public ushort CountGeki { get; set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000115 RID: 277 RVA: 0x000027E4 File Offset: 0x000027E4
		// (set) Token: 0x06000116 RID: 278 RVA: 0x000027EC File Offset: 0x000027EC
		public ushort CountKatu { get; set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000117 RID: 279 RVA: 0x000027F5 File Offset: 0x000027F5
		// (set) Token: 0x06000118 RID: 280 RVA: 0x000027FD File Offset: 0x000027FD
		public ushort CountMiss { get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000119 RID: 281 RVA: 0x00002806 File Offset: 0x00002806
		// (set) Token: 0x0600011A RID: 282 RVA: 0x0000280E File Offset: 0x0000280E
		public int ReplayScore { get; set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600011B RID: 283 RVA: 0x00002817 File Offset: 0x00002817
		// (set) Token: 0x0600011C RID: 284 RVA: 0x0000281F File Offset: 0x0000281F
		public ushort Combo { get; set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600011D RID: 285 RVA: 0x00002828 File Offset: 0x00002828
		// (set) Token: 0x0600011E RID: 286 RVA: 0x00002830 File Offset: 0x00002830
		public bool PerfectCombo { get; set; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600011F RID: 287 RVA: 0x00002839 File Offset: 0x00002839
		// (set) Token: 0x06000120 RID: 288 RVA: 0x00002841 File Offset: 0x00002841
		public Mods Mods { get; set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000121 RID: 289 RVA: 0x0000284A File Offset: 0x0000284A
		// (set) Token: 0x06000122 RID: 290 RVA: 0x00002852 File Offset: 0x00002852
		public DateTime ReplayTimestamp { get; set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000123 RID: 291 RVA: 0x0000285B File Offset: 0x0000285B
		// (set) Token: 0x06000124 RID: 292 RVA: 0x00002863 File Offset: 0x00002863
		public int ReplayLength { get; set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000125 RID: 293 RVA: 0x0000286C File Offset: 0x0000286C
		// (set) Token: 0x06000126 RID: 294 RVA: 0x00002874 File Offset: 0x00002874
		public List<ReplayFrame> ReplayFrames { get; set; } = new List<ReplayFrame>();

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000127 RID: 295 RVA: 0x0000287D File Offset: 0x0000287D
		// (set) Token: 0x06000128 RID: 296 RVA: 0x00002885 File Offset: 0x00002885
		public List<LifeFrame> LifeFrames { get; set; } = new List<LifeFrame>();

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000129 RID: 297 RVA: 0x0000288E File Offset: 0x0000288E
		// (set) Token: 0x0600012A RID: 298 RVA: 0x00002896 File Offset: 0x00002896
		public int Seed { get; set; }

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600012B RID: 299 RVA: 0x0000289F File Offset: 0x0000289F
		// (set) Token: 0x0600012C RID: 300 RVA: 0x000028A7 File Offset: 0x000028A7
		public long OnlineId { get; set; }

		// Token: 0x0600012D RID: 301 RVA: 0x000028B0 File Offset: 0x000028B0
		public void Save(string path)
		{
			ReplayEncoder.Encode(this, path);
		}
	}
}
