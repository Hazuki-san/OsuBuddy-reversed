using System;
using System.Collections.Generic;
using osu.Enums;
using osu.Memory.Objects.Player.Beatmaps.Objects;

namespace osu.Memory.Objects.Player.Beatmaps
{
	// Token: 0x0200009A RID: 154
	public class OsuBeatmap : OsuObject
	{
		// Token: 0x1700012E RID: 302
		// (get) Token: 0x0600040A RID: 1034 RVA: 0x0000425E File Offset: 0x0000425E
		// (set) Token: 0x0600040B RID: 1035 RVA: 0x00004266 File Offset: 0x00004266
		public Ruleset Ruleset { get; set; }

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x0600040C RID: 1036 RVA: 0x0000426F File Offset: 0x0000426F
		// (set) Token: 0x0600040D RID: 1037 RVA: 0x00004277 File Offset: 0x00004277
		public string Checksum { get; set; }

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x0600040E RID: 1038 RVA: 0x00004280 File Offset: 0x00004280
		// (set) Token: 0x0600040F RID: 1039 RVA: 0x00004288 File Offset: 0x00004288
		public string Artist { get; set; }

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000410 RID: 1040 RVA: 0x00004291 File Offset: 0x00004291
		// (set) Token: 0x06000411 RID: 1041 RVA: 0x00004299 File Offset: 0x00004299
		public string Title { get; set; }

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06000412 RID: 1042 RVA: 0x000042A2 File Offset: 0x000042A2
		// (set) Token: 0x06000413 RID: 1043 RVA: 0x000042AA File Offset: 0x000042AA
		public string Creator { get; set; }

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x06000414 RID: 1044 RVA: 0x000042B3 File Offset: 0x000042B3
		// (set) Token: 0x06000415 RID: 1045 RVA: 0x000042BB File Offset: 0x000042BB
		public string Version { get; set; }

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x06000416 RID: 1046 RVA: 0x000042C4 File Offset: 0x000042C4
		// (set) Token: 0x06000417 RID: 1047 RVA: 0x000042CC File Offset: 0x000042CC
		public float ApproachRate { get; set; }

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x06000418 RID: 1048 RVA: 0x000042D5 File Offset: 0x000042D5
		// (set) Token: 0x06000419 RID: 1049 RVA: 0x000042DD File Offset: 0x000042DD
		public float CircleSize { get; set; }

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x0600041A RID: 1050 RVA: 0x000042E6 File Offset: 0x000042E6
		// (set) Token: 0x0600041B RID: 1051 RVA: 0x000042EE File Offset: 0x000042EE
		public float HPDrainRate { get; set; }

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x0600041C RID: 1052 RVA: 0x000042F7 File Offset: 0x000042F7
		// (set) Token: 0x0600041D RID: 1053 RVA: 0x000042FF File Offset: 0x000042FF
		public float OverallDifficulty { get; set; }

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x0600041E RID: 1054 RVA: 0x00004308 File Offset: 0x00004308
		// (set) Token: 0x0600041F RID: 1055 RVA: 0x00004310 File Offset: 0x00004310
		public double SliderMultiplier { get; set; }

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x06000420 RID: 1056 RVA: 0x00004319 File Offset: 0x00004319
		// (set) Token: 0x06000421 RID: 1057 RVA: 0x00004321 File Offset: 0x00004321
		public double SliderTickRate { get; set; }

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x06000422 RID: 1058 RVA: 0x0000432A File Offset: 0x0000432A
		// (set) Token: 0x06000423 RID: 1059 RVA: 0x00004332 File Offset: 0x00004332
		public List<OsuHitObject> HitObjects { get; set; }

		// Token: 0x06000424 RID: 1060 RVA: 0x00011D98 File Offset: 0x00011D98
		public OsuBeatmap() : base(null)
		{
		}
	}
}
