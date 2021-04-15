using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace osu.Helpers
{
    internal static class Extensions
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern bool EnumThreadWindows(int dwThreadId, EnumThreadDelegate lpfn, IntPtr lParam);

        delegate bool EnumThreadDelegate(IntPtr hWnd, IntPtr lParam);

        public static List<IntPtr> GetWindowHandles(this Process process, bool ignoreInvisible = true)
        {
            var handles = new List<IntPtr>();

            foreach (ProcessThread thread in process.Threads)
            {
                EnumThreadWindows(thread.Id, (hWnd, lParam) =>
                {
                    if (!ignoreInvisible || IsWindowVisible(hWnd))
                        handles.Add(hWnd);

                    return true;
                }, IntPtr.Zero);
            }

            return handles;
        }

        public static string GetWindowTitleByHandle(this Process process, IntPtr handle)
        {
            var length = GetWindowTextLength(handle) + 1;
            var title = new StringBuilder(length);
            GetWindowText(handle, title, length);

            return title.ToString();
        }
    }
}
