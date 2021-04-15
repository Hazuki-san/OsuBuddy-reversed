using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using OsuParsers.Enums;
using OsuParsers.Enums.Beatmaps;

namespace OsuParsers.Helpers
{
	// Token: 0x0200003A RID: 58
	internal static class ParseHelper
	{
		// Token: 0x0600015C RID: 348 RVA: 0x0000AF24 File Offset: 0x00009124
		public static FileSections GetCurrentSection(string line)
		{
			FileSections result = FileSections.None;
			Enum.TryParse<FileSections>(line.Trim(new char[]
			{
				'[',
				']'
			}), true, out result);
			return result;
		}

		// Token: 0x0600015D RID: 349 RVA: 0x0000AF58 File Offset: 0x00009158
		public static CurveType GetCurveType(char c)
		{
			if (c <= 'C')
			{
				if (c == 'B')
				{
					return CurveType.Bezier;
				}
				if (c == 'C')
				{
					return CurveType.Catmull;
				}
			}
			else
			{
				if (c == 'L')
				{
					return CurveType.Linear;
				}
				if (c == 'P')
				{
					return CurveType.PerfectCurve;
				}
			}
			return CurveType.PerfectCurve;
		}

		// Token: 0x0600015E RID: 350 RVA: 0x0000AFA0 File Offset: 0x000091A0
		public static List<Vector2> GetSliderPoints(string[] segments)
		{
			List<Vector2> list = new List<Vector2>();
			foreach (string text in segments.Skip(1))
			{
				string[] array = text.Split(new char[]
				{
					':'
				});
				bool flag = array.Length == 2;
				if (flag)
				{
					int num = Convert.ToInt32(array[0], CultureInfo.InvariantCulture);
					int num2 = Convert.ToInt32(array[1], CultureInfo.InvariantCulture);
					list.Add(new Vector2((float)num, (float)num2));
				}
			}
			return list;
		}

		// Token: 0x0600015F RID: 351 RVA: 0x0000B04C File Offset: 0x0000924C
		public static Color ParseColour(string line)
		{
			int[] array = line.Split(new char[]
			{
				','
			}).Select(new Func<string, int>(ParseHelper.Ac.A9.AParseColourb__3_0)).ToArray<int>();
			return Color.FromArgb((array.Length == 4) ? array[3] : 255, array[0], array[1], array[2]);
		}

		// Token: 0x06000160 RID: 352 RVA: 0x0000B0B8 File Offset: 0x000092B8
		public static bool IsLineValid(string line, FileSections currentSection)
		{
			bool result;
			switch (currentSection)
			{
			case FileSections.Format:
				result = line.ToLower().Contains("osu file format v");
				break;
			case FileSections.General:
			case FileSections.Editor:
			case FileSections.Metadata:
			case FileSections.Difficulty:
			case FileSections.Fonts:
			case FileSections.Mania:
				result = line.Contains(":");
				break;
			case FileSections.Events:
			case FileSections.TimingPoints:
			case FileSections.HitObjects:
				result = line.Contains(",");
				break;
			case FileSections.Colours:
			case FileSections.CatchTheBeat:
				result = (line.Contains(',') && line.Contains(':'));
				break;
			default:
				result = false;
				break;
			}
			return result;
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00002A02 File Offset: 0x00000C02
		public static bool ToBool(this string value)
		{
			return value == "1" || value.ToLower() == "true";
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00002A24 File Offset: 0x00000C24
		public static float ToFloat(this string value)
		{
			return float.Parse(value, NumberStyles.Float, CultureInfo.InvariantCulture);
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00002A36 File Offset: 0x00000C36
		public static double ToDouble(this string value)
		{
			return double.Parse(value, NumberStyles.Float, CultureInfo.InvariantCulture);
		}

		// Token: 0x0200003B RID: 59
		[CompilerGenerated]
		[Serializable]
		private sealed class Ac
		{
			// Token: 0x06000166 RID: 358 RVA: 0x00002A54 File Offset: 0x00000C54
			internal int AParseColourb__3_0(string c)
			{
				return Convert.ToInt32(c);
			}

			// Token: 0x04000143 RID: 323
			public static readonly ParseHelper.Ac A9 = new ParseHelper.Ac();

			// Token: 0x04000144 RID: 324
			public static Func<string, int> A9__3_0;
		}
	}
}
