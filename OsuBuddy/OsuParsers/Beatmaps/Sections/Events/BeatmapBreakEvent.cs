using System;

namespace OsuParsers.Beatmaps.Sections.Events
{
	// Token: 0x02000076 RID: 118
	public class BeatmapBreakEvent
	{
		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x06000326 RID: 806 RVA: 0x000038CE File Offset: 0x000038CE
		// (set) Token: 0x06000327 RID: 807 RVA: 0x000038D6 File Offset: 0x000038D6
		public int StartTime { get; private set; }

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x06000328 RID: 808 RVA: 0x000038DF File Offset: 0x000038DF
		// (set) Token: 0x06000329 RID: 809 RVA: 0x000038E7 File Offset: 0x000038E7
		public int EndTime { get; private set; }

		// Token: 0x0600032A RID: 810 RVA: 0x000038F0 File Offset: 0x000038F0
		public BeatmapBreakEvent(int startTime, int endTime)
		{
			this.StartTime = startTime;
			this.EndTime = endTime;
		}
	}
}
