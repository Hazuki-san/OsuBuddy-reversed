using System;
using OsuParsers.Beatmaps;
using OsuParsers.Beatmaps.Objects;

namespace OsuParsers.Helpers
{
	// Token: 0x02000039 RID: 57
	internal class MathHelper
	{
		// Token: 0x06000158 RID: 344 RVA: 0x0000AE5C File Offset: 0x0000905C
		public static double Clamp(double value, double min, double max)
		{
			bool flag = value > max;
			double result;
			if (flag)
			{
				result = max;
			}
			else
			{
				bool flag2 = value < min;
				if (flag2)
				{
					result = min;
				}
				else
				{
					result = value;
				}
			}
			return result;
		}

		// Token: 0x06000159 RID: 345 RVA: 0x0000AE88 File Offset: 0x00009088
		public static double CalculateBpmMultiplier(TimingPoint timingPoint)
		{
			bool flag = timingPoint.BeatLength >= 0.0;
			double result;
			if (flag)
			{
				result = 1.0;
			}
			else
			{
				result = MathHelper.Clamp((double)((float)(-(float)timingPoint.BeatLength)), 10.0, 1000.0) / 100.0;
			}
			return result;
		}

		// Token: 0x0600015A RID: 346 RVA: 0x0000AEE8 File Offset: 0x000090E8
		public static int CalculateEndTime(Beatmap beatmap, int startTime, int repeats, double pixelLength)
		{
			int num = (int)(pixelLength / (100.0 * beatmap.DifficultySection.SliderMultiplier) * (double)repeats * beatmap.BeatLengthAt(startTime));
			return startTime + num;
		}
	}
}
