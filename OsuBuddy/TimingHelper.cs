using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using OsuBuddy;

public class TimingHelper
{
	private delegate void TimerCallback(uint uTimerID, uint uMsg, UIntPtr dwUser, UIntPtr dw1, UIntPtr dw2);

	[Serializable]
	[CompilerGenerated]
	private sealed class Ac
	{
		public static readonly Ac A9 = new Ac();

		internal void A_002Ecctorb__7_0(uint uTimerID, uint msg, UIntPtr dwUser, UIntPtr dw1, UIntPtr dw2)
		{
			autoResetEvent.Set();
		}
	}

	private static AutoResetEvent autoResetEvent = new AutoResetEvent(initialState: false);

	private static TimerCallback callback = delegate
	{
		autoResetEvent.Set();
	};

	[DllImport("Winmm.dll", CharSet = CharSet.Auto)]
	private static extern uint timeSetEvent(uint uDelay, uint uResolution, TimerCallback lpTimeProc, UIntPtr dwUser, uint fuEvent);

	[DllImport("Winmm.dll", CharSet = CharSet.Auto)]
	private static extern uint timeKillEvent(uint uTimerID);

	public static void Delay(uint milliseconds)
	{
		uint uTimerID = timeSetEvent(milliseconds, 0u, callback, UIntPtr.Zero, 0u);
		autoResetEvent.WaitOne();
		timeKillEvent(uTimerID);
	}
}
