using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace osu.Helpers
{
	// Token: 0x020000A1 RID: 161
	internal static class Extensions
	{
		// Token: 0x0600043E RID: 1086
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

		// Token: 0x0600043F RID: 1087
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int GetWindowTextLength(IntPtr hWnd);

		// Token: 0x06000440 RID: 1088
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool IsWindowVisible(IntPtr hWnd);

		// Token: 0x06000441 RID: 1089
		[DllImport("user32.dll")]
		private static extern bool EnumThreadWindows(int dwThreadId, Extensions.EnumThreadDelegate lpfn, IntPtr lParam);

		// Token: 0x06000442 RID: 1090 RVA: 0x0001244C File Offset: 0x0001064C
		public static List<IntPtr> GetWindowHandles(this Process process, bool ignoreInvisible = true)
		{
			Extensions.Ac__DisplayClass5_0 ac__DisplayClass5_ = new Extensions.Ac__DisplayClass5_0();
			ac__DisplayClass5_.ignoreInvisible = ignoreInvisible;
			ac__DisplayClass5_.handles = new List<IntPtr>();
			foreach (object obj in process.Threads)
			{
				ProcessThread processThread = (ProcessThread)obj;
				int id = processThread.Id;
				Extensions.EnumThreadDelegate lpfn;
				if ((lpfn = ac__DisplayClass5_.A9__0) == null)
				{
					lpfn = (ac__DisplayClass5_.A9__0 = new Extensions.EnumThreadDelegate(ac__DisplayClass5_.AGetWindowHandlesb__0));
				}
				Extensions.EnumThreadWindows(id, lpfn, IntPtr.Zero);
			}
			return ac__DisplayClass5_.handles;
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x000124FC File Offset: 0x000106FC
		public static string GetWindowTitleByHandle(this Process process, IntPtr handle)
		{
			int num = Extensions.GetWindowTextLength(handle) + 1;
			StringBuilder stringBuilder = new StringBuilder(num);
			Extensions.GetWindowText(handle, stringBuilder, num);
			return stringBuilder.ToString();
		}

		// Token: 0x020000A2 RID: 162
		// (Invoke) Token: 0x06000445 RID: 1093
		private delegate bool EnumThreadDelegate(IntPtr hWnd, IntPtr lParam);

		// Token: 0x020000A3 RID: 163
		[CompilerGenerated]
		private sealed class Ac__DisplayClass5_0
		{
			// Token: 0x06000449 RID: 1097 RVA: 0x00012530 File Offset: 0x00010730
			internal bool AGetWindowHandlesb__0(IntPtr hWnd, IntPtr lParam)
			{
				bool flag = !this.ignoreInvisible || Extensions.IsWindowVisible(hWnd);
				if (flag)
				{
					this.handles.Add(hWnd);
				}
				return true;
			}

			// Token: 0x040003A4 RID: 932
			public bool ignoreInvisible;

			// Token: 0x040003A5 RID: 933
			public List<IntPtr> handles;

			// Token: 0x040003A6 RID: 934
			public Extensions.EnumThreadDelegate A9__0;
		}
	}
}
