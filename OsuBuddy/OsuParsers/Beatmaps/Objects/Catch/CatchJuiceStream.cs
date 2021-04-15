using System;
using System.Collections.Generic;
using System.Numerics;
using OsuParsers.Enums.Beatmaps;

namespace OsuParsers.Beatmaps.Objects.Catch
{
	// Token: 0x02000084 RID: 132
	public class CatchJuiceStream : Slider
	{
		// Token: 0x0600037D RID: 893 RVA: 0x00010BD4 File Offset: 0x0000EDD4
		public CatchJuiceStream(Vector2 position, int startTime, int endTime, HitSoundType hitSound, CurveType type, List<Vector2> points, int repeats, double pixelLength, bool isNewCombo, int comboOffset, List<HitSoundType> edgeHitSounds = null, List<Tuple<SampleSet, SampleSet>> edgeAdditions = null, Extras extras = null) : base(position, startTime, endTime, hitSound, type, points, repeats, pixelLength, isNewCombo, comboOffset, edgeHitSounds, edgeAdditions, extras)
		{
		}
	}
}
