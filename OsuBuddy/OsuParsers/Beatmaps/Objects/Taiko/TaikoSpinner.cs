using System;
using System.Numerics;
using OsuParsers.Enums.Beatmaps;

namespace OsuParsers.Beatmaps.Objects.Taiko
{
	// Token: 0x0200007F RID: 127
	public class TaikoSpinner : Spinner
	{
		// Token: 0x06000374 RID: 884 RVA: 0x00003B70 File Offset: 0x00003B70
		public TaikoSpinner(Vector2 position, int startTime, int endTime, HitSoundType hitSound, Extras extras, bool isNewCombo, int comboOffset) : base(position, startTime, endTime, hitSound, extras, isNewCombo, comboOffset)
		{
		}
	}
}
