using System;
using OsuParsers.Enums.Storyboards;
using OsuParsers.Storyboards.Commands;
using OsuParsers.Storyboards.Interfaces;

namespace OsuParsers.Storyboards.Objects
{
	// Token: 0x02000024 RID: 36
	public class StoryboardAnimation : IStoryboardObject, IHasCommands
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x060000C1 RID: 193 RVA: 0x00002478 File Offset: 0x00002478
		public CommandGroup Commands { get; } = new CommandGroup();

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x060000C2 RID: 194 RVA: 0x00002480 File Offset: 0x00002480
		// (set) Token: 0x060000C3 RID: 195 RVA: 0x00002488 File Offset: 0x00002488
		public string FilePath { get; set; }

		// Token: 0x060000C4 RID: 196 RVA: 0x0000A1AC File Offset: 0x0000A1AC
		public StoryboardAnimation(Origins origin, string filePath, float x, float y, int frameCount, double frameDelay, LoopType loopType)
		{
			this.Origin = origin;
			this.FilePath = filePath;
			this.X = x;
			this.Y = y;
			this.FrameCount = frameCount;
			this.FrameDelay = frameDelay;
			this.LoopType = loopType;
		}

		// Token: 0x040000E7 RID: 231
		public Origins Origin;

		// Token: 0x040000E9 RID: 233
		public float X;

		// Token: 0x040000EA RID: 234
		public float Y;

		// Token: 0x040000EB RID: 235
		public int FrameCount;

		// Token: 0x040000EC RID: 236
		public double FrameDelay;

		// Token: 0x040000ED RID: 237
		public LoopType LoopType;
	}
}
