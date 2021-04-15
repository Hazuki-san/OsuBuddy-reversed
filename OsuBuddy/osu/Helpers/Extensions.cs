using System;
using System.Collections.Generic;
using System.Diagnostics;
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

		// Token: 0x06000442 RID: 1090 RVA: 0x0001244C File Offset: 0x0001244C
		public static List<IntPtr> GetWindowHandles(this Process process, bool ignoreInvisible = true)
		{
			List<IntPtr> handles = new List<IntPtr>();
			Extensions.EnumThreadDelegate <>9__0;
			foreach (object obj in process.Threads)
			{
				ProcessThread processThread = (ProcessThread)obj;
				int id = processThread.Id;
				Extensions.EnumThreadDelegate lpfn;
				if ((lpfn = <>9__0) == null)
				{
					lpfn = (<>9__0 = delegate(IntPtr hWnd, IntPtr lParam)
					{
						bool flag = !ignoreInvisible || Extensions.IsWindowVisible(hWnd);
						if (flag)
						{
							handles.Add(hWnd);
						}
						return true;
					});
				}
				Extensions.EnumThreadWindows(id, lpfn, IntPtr.Zero);
			}
			return handles;
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x000124FC File Offset: 0x000124FC
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
	}
}
