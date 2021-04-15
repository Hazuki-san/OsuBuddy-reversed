using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace OsuParsers.Helpers
{
	// Token: 0x02000035 RID: 53
	internal static class Extensions
	{
		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600014A RID: 330 RVA: 0x00002984 File Offset: 0x00002984
		private static NumberFormatInfo NumFormat
		{
			get
			{
				return new CultureInfo("en-US", false).NumberFormat;
			}
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00002996 File Offset: 0x00002996
		public static int ToInt32(this bool value)
		{
			return value ? 1 : 0;
		}

		// Token: 0x0600014C RID: 332 RVA: 0x0000299F File Offset: 0x0000299F
		public static string Format(this float value)
		{
			return value.ToString(Extensions.NumFormat);
		}

		// Token: 0x0600014D RID: 333 RVA: 0x000029AD File Offset: 0x000029AD
		public static string Format(this double value)
		{
			return value.ToString(Extensions.NumFormat);
		}

		// Token: 0x0600014E RID: 334 RVA: 0x000029BB File Offset: 0x000029BB
		public static string Format(this int value)
		{
			return value.ToString(Extensions.NumFormat);
		}

		// Token: 0x0600014F RID: 335 RVA: 0x0000AD34 File Offset: 0x0000AD34
		public static string Join(this IEnumerable<string> stringGroup, char splitter = ' ')
		{
			bool flag = stringGroup != null;
			string result;
			if (flag)
			{
				string ret = string.Empty;
				stringGroup.ToList<string>().ForEach(delegate(string line)
				{
					ret = ret + line + splitter.ToString();
				});
				result = ret.TrimEnd(new char[]
				{
					splitter
				});
			}
			else
			{
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0000ADB4 File Offset: 0x0000ADB4
		public static string Join(this IEnumerable<int> intGroup, char splitter = ' ')
		{
			bool flag = intGroup != null;
			string result;
			if (flag)
			{
				result = intGroup.ToList<int>().ConvertAll<string>((int e) => e.ToString()).Join(splitter);
			}
			else
			{
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x06000151 RID: 337 RVA: 0x0000AE08 File Offset: 0x0000AE08
		public static IEnumerable<string> ReadAllLines(this Stream stream)
		{
			IEnumerable<string> result;
			using (StreamReader streamReader = new StreamReader(stream))
			{
				string text = streamReader.ReadToEnd();
				result = text.Split(new string[]
				{
					Environment.NewLine
				}, StringSplitOptions.None);
			}
			return result;
		}
	}
}
