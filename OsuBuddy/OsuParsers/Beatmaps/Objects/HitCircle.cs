using System;
using System.Numerics;
using OsuParsers.Enums.Beatmaps;

namespace OsuParsers.Beatmaps.Objects
{
	// Token: 0x02000078 RID: 120
	public class HitCircle : HitObject
	{
		// Token: 0x06000337 RID: 823 RVA: 0x0000399D File Offset: 0x00001B9D
		public HitCircle(Vector2 position, int startTime, int endTime, HitSoundType hitSound, Extras extras, bool isNewCombo, int comboOffset) : base(position, startTime, endTime, hitSound, extras, isNewCombo, comboOffset)
		{
		}
	}
}
