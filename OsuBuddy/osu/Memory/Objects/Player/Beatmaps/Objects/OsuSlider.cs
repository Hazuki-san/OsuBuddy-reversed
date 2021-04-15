using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using osu.Enums.Beatmaps;

namespace osu.Memory.Objects.Player.Beatmaps.Objects
{
	// Token: 0x0200009D RID: 157
	public class OsuSlider : OsuHitObject
	{
		// Token: 0x1700013E RID: 318
		// (get) Token: 0x0600042D RID: 1069 RVA: 0x0000439D File Offset: 0x0000259D
		// (set) Token: 0x0600042E RID: 1070 RVA: 0x000043A5 File Offset: 0x000025A5
		public List<ValueTuple<Vector2, Vector2>> SliderCurveSmoothLines { get;  set; }

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x0600042F RID: 1071 RVA: 0x000043AE File Offset: 0x000025AE
		// (set) Token: 0x06000430 RID: 1072 RVA: 0x000043B6 File Offset: 0x000025B6
		public List<double> CumulativeLengths { get; set; }

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x06000431 RID: 1073 RVA: 0x000043BF File Offset: 0x000025BF
		// (set) Token: 0x06000432 RID: 1074 RVA: 0x000043C7 File Offset: 0x000025C7
		public int Repeats { get; set; }

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x06000433 RID: 1075 RVA: 0x000043D0 File Offset: 0x000025D0
		// (set) Token: 0x06000434 RID: 1076 RVA: 0x000043D8 File Offset: 0x000025D8
		public double PixelLength { get; set; }

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x06000435 RID: 1077 RVA: 0x000043E1 File Offset: 0x000025E1
		// (set) Token: 0x06000436 RID: 1078 RVA: 0x000043E9 File Offset: 0x000025E9
		public CurveType CurveType { get; set; }

		// Token: 0x06000437 RID: 1079 RVA: 0x000043F2 File Offset: 0x000025F2
		public OsuSlider(int startTime, int endTime, Vector2 position, int repeats, double pixelLength, CurveType curveType, List<ValueTuple<Vector2, Vector2>> sliderCurveSmoothLines, List<double> cumulativeLengths) : base(startTime, endTime, position)
		{
			this.Repeats = repeats;
			this.PixelLength = pixelLength;
			this.CurveType = curveType;
			this.SliderCurveSmoothLines = sliderCurveSmoothLines;
			this.CumulativeLengths = cumulativeLengths;
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x00012150 File Offset: 0x00010350
		public Vector2 PositionAtTime(int time)
		{
			bool flag = this.SliderCurveSmoothLines.Count == 0;
			Vector2 result;
			if (flag)
			{
				result = base.Position;
			}
			else
			{
				bool flag2 = time < base.StartTime || time > base.EndTime;
				if (flag2)
				{
					result = base.Position;
				}
				else
				{
					float num = (float)(time - base.StartTime) / ((float)(base.EndTime - base.StartTime) / (float)this.Repeats);
					bool flag3 = num % 2f > 1f;
					if (flag3)
					{
						num = 1f - num % 1f;
					}
					else
					{
						num %= 1f;
					}
					float length = (float)(this.PixelLength * (double)num);
					result = this.positionAtLength(length);
				}
			}
			return result;
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x00012204 File Offset: 0x00010404
		private Vector2 positionAtLength(float length)
		{
			bool flag = this.SliderCurveSmoothLines.Count == 0 || this.CumulativeLengths.Count == 0;
			Vector2 result;
			if (flag)
			{
				result = base.Position;
			}
			else
			{
				bool flag2 = length == 0f;
				if (flag2)
				{
					result = this.SliderCurveSmoothLines[0].Item1;
				}
				else
				{
					double num = this.CumulativeLengths[this.CumulativeLengths.Count - 1];
					bool flag3 = (double)length >= num;
					if (flag3)
					{
						result = this.SliderCurveSmoothLines[this.SliderCurveSmoothLines.Count - 1].Item2;
					}
					else
					{
						int num2 = this.CumulativeLengths.BinarySearch((double)length);
						bool flag4 = num2 < 0;
						if (flag4)
						{
							num2 = Math.Min(~num2, this.CumulativeLengths.Count - 1);
						}
						double num3 = this.CumulativeLengths[num2];
						double num4 = (num2 == 0) ? 0.0 : this.CumulativeLengths[num2 - 1];
						Vector2 vector = this.SliderCurveSmoothLines[num2].Item1;
						bool flag5 = num3 != num4;
						if (flag5)
						{
							vector += (this.SliderCurveSmoothLines[num2].Item2 - this.SliderCurveSmoothLines[num2].Item1) * (float)(((double)length - num4) / (num3 - num4));
						}
						result = vector;
					}
				}
			}
			return result;
		}

		// Token: 0x04000358 RID: 856
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private List<ValueTuple<Vector2, Vector2>> ASliderCurveSmoothLinesk__BackingField;

		// Token: 0x04000359 RID: 857
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private List<double> ACumulativeLengthsk__BackingField;

		// Token: 0x0400035A RID: 858
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int ARepeatsk__BackingField;

		// Token: 0x0400035B RID: 859
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double APixelLengthk__BackingField;

		// Token: 0x0400035C RID: 860
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private CurveType ACurveTypek__BackingField;
	}
}
