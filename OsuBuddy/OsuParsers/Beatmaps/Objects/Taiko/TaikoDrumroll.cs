using System;
using System.Collections.Generic;
using System.Numerics;
using OsuParsers.Enums.Beatmaps;

namespace OsuParsers.Beatmaps.Objects.Taiko
{
	// Token: 0x0200007D RID: 125
	public class TaikoDrumroll : Slider
	{
		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x0600036B RID: 875 RVA: 0x0001092C File Offset: 0x0000EB2C
		// (set) Token: 0x0600036C RID: 876 RVA: 0x00010954 File Offset: 0x0000EB54
		public bool IsBig
		{
			get
			{
				return base.HitSound.HasFlag(HitSoundType.Finish);
			}
			set
			{
				bool flag = value && !base.HitSound.HasFlag(HitSoundType.Finish);
				if (flag)
				{
					base.HitSound += 4;
				}
				else
				{
					bool flag2 = base.HitSound.HasFlag(HitSoundType.Finish);
					if (flag2)
					{
						base.HitSound -= 4;
					}
				}
			}
		}

		// Token: 0x0600036D RID: 877 RVA: 0x000109C0 File Offset: 0x0000EBC0
		public TaikoDrumroll(Vector2 position, int startTime, int endTime, HitSoundType hitSound, CurveType type, List<Vector2> points, int repeats, double pixelLength, List<HitSoundType> edgeHitSounds, List<Tuple<SampleSet, SampleSet>> edgeAdditions, Extras extras, bool isNewCombo, int comboOffset) : base(position, startTime, endTime, hitSound, type, points, repeats, pixelLength, isNewCombo, comboOffset, edgeHitSounds, edgeAdditions, extras)
		{
		}

		// Token: 0x0600036E RID: 878 RVA: 0x000109EC File Offset: 0x0000EBEC
		public TaikoDrumroll(Vector2 position, int startTime, int endTime, HitSoundType hitSound, CurveType type, List<Vector2> points, int repeats, double pixelLength, bool isNewCombo, int comboOffset) : base(position, startTime, endTime, hitSound, type, points, repeats, pixelLength, isNewCombo, comboOffset, null, null, null)
		{
		}
	}
}
