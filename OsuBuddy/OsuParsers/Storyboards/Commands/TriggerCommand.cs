using System;
using OsuParsers.Storyboards.Interfaces;

namespace OsuParsers.Storyboards.Commands
{
	// Token: 0x0200002D RID: 45
	public class TriggerCommand : IHasCommands
	{
		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060000F4 RID: 244 RVA: 0x000026F6 File Offset: 0x000026F6
		public CommandGroup Commands { get; } = new CommandGroup();

		// Token: 0x060000F5 RID: 245 RVA: 0x000026FE File Offset: 0x000026FE
		public TriggerCommand(string triggerName, int startTime, int endTime, int groupNumber)
		{
			this.TriggerName = triggerName;
			this.TriggerStartTime = startTime;
			this.TriggerEndTime = endTime;
			this.GroupNumber = groupNumber;
		}

		// Token: 0x04000107 RID: 263
		public string TriggerName;

		// Token: 0x04000108 RID: 264
		public int TriggerStartTime;

		// Token: 0x04000109 RID: 265
		public int TriggerEndTime;

		// Token: 0x0400010A RID: 266
		public int GroupNumber;
	}
}
