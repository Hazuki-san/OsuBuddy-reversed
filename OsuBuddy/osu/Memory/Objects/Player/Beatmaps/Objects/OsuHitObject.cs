using System;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace osu.Memory.Objects.Player.Beatmaps.Objects
{
	// Token: 0x0200009C RID: 156
	public class OsuHitObject
	{
		// Token: 0x1700013B RID: 315
		// (get) Token: 0x06000426 RID: 1062 RVA: 0x00004348 File Offset: 0x00002548
		// (set) Token: 0x06000427 RID: 1063 RVA: 0x00004350 File Offset: 0x00002550
		public int StartTime { get; set; }

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x06000428 RID: 1064 RVA: 0x00004359 File Offset: 0x00002559
		// (set) Token: 0x06000429 RID: 1065 RVA: 0x00004361 File Offset: 0x00002561
		public int EndTime { get; set; }

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x0600042A RID: 1066 RVA: 0x0000436A File Offset: 0x0000256A
		// (set) Token: 0x0600042B RID: 1067 RVA: 0x00004372 File Offset: 0x00002572
		public Vector2 Position { get; set; }

		// Token: 0x0600042C RID: 1068 RVA: 0x0000437B File Offset: 0x0000257B
		public OsuHitObject(int startTime, int endTime, Vector2 position)
		{
			this.StartTime = startTime;
			this.EndTime = endTime;
			this.Position = position;
		}

		// Token: 0x04000355 RID: 853
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int AStartTimek__BackingField;

		// Token: 0x04000356 RID: 854
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int AEndTimek__BackingField;

		// Token: 0x04000357 RID: 855
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Vector2 APositionk__BackingField;
	}
}
