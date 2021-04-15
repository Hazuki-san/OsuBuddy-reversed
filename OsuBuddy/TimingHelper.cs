using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace OsuBuddy
{
	// Token: 0x020000B6 RID: 182
	public class TimingHelper
	{
		// Token: 0x060004AE RID: 1198
		[DllImport("Winmm.dll", CharSet = CharSet.Auto)]
		private static extern uint timeSetEvent(uint uDelay, uint uResolution, TimingHelper.TimerCallback lpTimeProc, UIntPtr dwUser, uint fuEvent);

		// Token: 0x060004AF RID: 1199
		[DllImport("Winmm.dll", CharSet = CharSet.Auto)]
		private static extern uint timeKillEvent(uint uTimerID);

		// Token: 0x060004B0 RID: 1200 RVA: 0x00017DA4 File Offset: 0x00017DA4
		public static void Delay(uint milliseconds)
		{
			uint uTimerID = TimingHelper.timeSetEvent(milliseconds, 0U, TimingHelper.callback, UIntPtr.Zero, 0U);
			TimingHelper.autoResetEvent.WaitOne();
			TimingHelper.timeKillEvent(uTimerID);
		}

		// Token: 0x0400048F RID: 1167
		private static AutoResetEvent autoResetEvent = new AutoResetEvent(false);

		// Token: 0x04000490 RID: 1168
		private static TimingHelper.TimerCallback callback = delegate(uint uTimerID, uint msg, UIntPtr dwUser, UIntPtr dw1, UIntPtr dw2)
		{
			TimingHelper.autoResetEvent.Set();
		};

		// Token: 0x020000B7 RID: 183
		// (Invoke) Token: 0x060004B4 RID: 1204
		private delegate void TimerCallback(uint uTimerID, uint uMsg, UIntPtr dwUser, UIntPtr dw1, UIntPtr dw2);
	}
}
