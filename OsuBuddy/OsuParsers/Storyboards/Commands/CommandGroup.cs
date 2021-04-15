using System;
using System.Collections.Generic;

namespace OsuParsers.Storyboards.Commands
{
	// Token: 0x0200002B RID: 43
	public class CommandGroup
	{
		// Token: 0x060000EF RID: 239 RVA: 0x0000A27C File Offset: 0x0000A27C
		public TriggerCommand AddTrigger(string triggerName, int startTime, int endTime, int groupNumber)
		{
			TriggerCommand triggerCommand = new TriggerCommand(triggerName, startTime, endTime, groupNumber);
			this.Triggers.Add(triggerCommand);
			return triggerCommand;
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x0000A2A8 File Offset: 0x0000A2A8
		public LoopCommand AddLoop(int startTime, int loopCount)
		{
			LoopCommand loopCommand = new LoopCommand(startTime, loopCount);
			this.Loops.Add(loopCommand);
			return loopCommand;
		}

		// Token: 0x04000101 RID: 257
		public List<Command> Commands = new List<Command>();

		// Token: 0x04000102 RID: 258
		public List<TriggerCommand> Triggers = new List<TriggerCommand>();

		// Token: 0x04000103 RID: 259
		public List<LoopCommand> Loops = new List<LoopCommand>();
	}
}
