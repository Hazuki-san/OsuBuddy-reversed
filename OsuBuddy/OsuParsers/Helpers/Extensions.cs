using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace OsuParsers.Helpers
{
	// Token: 0x02000035 RID: 53
	internal static class Extensions
	{
		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600014A RID: 330 RVA: 0x00002984 File Offset: 0x00000B84
		private static NumberFormatInfo NumFormat
		{
			get
			{
				return new CultureInfo("en-US", false).NumberFormat;
			}
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00002996 File Offset: 0x00000B96
		public static int ToInt32(this bool value)
		{
			return value ? 1 : 0;
		}

		// Token: 0x0600014C RID: 332 RVA: 0x0000299F File Offset: 0x00000B9F
		public static string Format(this float value)
		{
			return value.ToString(Extensions.NumFormat);
		}

		// Token: 0x0600014D RID: 333 RVA: 0x000029AD File Offset: 0x00000BAD
		public static string Format(this double value)
		{
			return value.ToString(Extensions.NumFormat);
		}

		// Token: 0x0600014E RID: 334 RVA: 0x000029BB File Offset: 0x00000BBB
		public static string Format(this int value)
		{
			return value.ToString(Extensions.NumFormat);
		}

		// Token: 0x0600014F RID: 335 RVA: 0x0000AD34 File Offset: 0x00008F34
		public static string Join(this IEnumerable<string> stringGroup, char splitter = ' ')
		{
			Extensions.Ac__DisplayClass6_0 ac__DisplayClass6_ = new Extensions.Ac__DisplayClass6_0();
			ac__DisplayClass6_.splitter = splitter;
			bool flag = stringGroup != null;
			string result;
			if (flag)
			{
				Extensions.Ac__DisplayClass6_1 ac__DisplayClass6_2 = new Extensions.Ac__DisplayClass6_1();
				ac__DisplayClass6_2.CS$A8__locals1 = ac__DisplayClass6_;
				ac__DisplayClass6_2.ret = string.Empty;
				stringGroup.ToList<string>().ForEach(new Action<string>(ac__DisplayClass6_2.AJoinb__0));
				result = ac__DisplayClass6_2.ret.TrimEnd(new char[]
				{
					ac__DisplayClass6_2.CS$A8__locals1.splitter
				});
			}
			else
			{
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0000ADB4 File Offset: 0x00008FB4
		public static string Join(this IEnumerable<int> intGroup, char splitter = ' ')
		{
			bool flag = intGroup != null;
			string result;
			if (flag)
			{
				result = intGroup.ToList<int>().ConvertAll<string>(new Converter<int, string>(Extensions.Ac.A9.AJoinb__7_0)).Join(splitter);
			}
			else
			{
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x06000151 RID: 337 RVA: 0x0000AE08 File Offset: 0x00009008
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

		// Token: 0x02000036 RID: 54
		[CompilerGenerated]
		private sealed class Ac__DisplayClass6_0
		{
			// Token: 0x0400013E RID: 318
			public char splitter;
		}

		// Token: 0x02000037 RID: 55
		[CompilerGenerated]
		private sealed class Ac__DisplayClass6_1
		{
			// Token: 0x06000154 RID: 340 RVA: 0x000029C9 File Offset: 0x00000BC9
			internal void AJoinb__0(string line)
			{
				this.ret = this.ret + line + this.CS$A8__locals1.splitter.ToString();
			}

			// Token: 0x0400013F RID: 319
			public string ret;

			// Token: 0x04000140 RID: 320
			public Extensions.Ac__DisplayClass6_0 CS$A8__locals1;
		}

		// Token: 0x02000038 RID: 56
		[CompilerGenerated]
		[Serializable]
		private sealed class Ac
		{
			// Token: 0x06000157 RID: 343 RVA: 0x000029F9 File Offset: 0x00000BF9
			internal string AJoinb__7_0(int e)
			{
				return e.ToString();
			}

			// Token: 0x04000141 RID: 321
			public static readonly Extensions.Ac A9 = new Extensions.Ac();

			// Token: 0x04000142 RID: 322
			public static Converter<int, string> A9__7_0;
		}
	}
}
