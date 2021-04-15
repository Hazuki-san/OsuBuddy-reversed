using System;
using OsuParsers.Storyboards.Interfaces;

namespace OsuParsers.Storyboards.Commands
{
	// Token: 0x0200002C RID: 44
	public class LoopCommand : IHasCommands
	{
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060000F2 RID: 242 RVA: 0x000026CB File Offset: 0x000026CB
		public CommandGroup Commands { get; } = new CommandGroup();

		// Token: 0x060000F3 RID: 243 RVA: 0x000026D3 File Offset: 0x000026D3
		public LoopCommand(int startTime, int loopCount)
		{
			this.LoopStartTime = startTime;
			this.LoopCount = loopCount;
		}

		// Token: 0x04000104 RID: 260
		public int LoopStartTime;

		// Token: 0x04000105 RID: 261
		public int LoopCount;
	}
}
