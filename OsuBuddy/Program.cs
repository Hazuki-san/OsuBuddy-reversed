using System;

namespace OsuBuddy
{
	// Token: 0x020000B5 RID: 181
	internal class Program
	{
		// Token: 0x060004AC RID: 1196 RVA: 0x0000477C File Offset: 0x0000297C
		[STAThread]
		private static void Main(string[] args)
		{
			Program.osuBuddy = new OsuBuddy();
			Program.osuBuddy.run();
		}

		// Token: 0x0400048E RID: 1166
		private static OsuBuddy osuBuddy;
	}
}
