using System;
using System.Collections.Generic;
using System.Numerics;
using OsuParsers.Enums.Beatmaps;

namespace OsuParsers.Beatmaps.Objects
{
	// Token: 0x0200007A RID: 122
	public class Slider : HitObject
	{
		// Token: 0x0600034C RID: 844 RVA: 0x000108C8 File Offset: 0x000108C8
		public Slider(Vector2 position, int startTime, int endTime, HitSoundType hitSound, CurveType type, List<Vector2> points, int repeats, double pixelLength, bool isNewCombo, int comboOffset, List<HitSoundType> edgeHitSounds = null, List<Tuple<SampleSet, SampleSet>> edgeAdditions = null, Extras extras = null) : base(position, startTime, endTime, hitSound, extras, isNewCombo, comboOffset)
		{
			this.CurveType = type;
			this.SliderPoints = points;
			this.Repeats = repeats;
			this.PixelLength = pixelLength;
			this.EdgeHitSounds = edgeHitSounds;
			this.EdgeAdditions = edgeAdditions;
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x0600034D RID: 845 RVA: 0x00003A6D File Offset: 0x00003A6D
		// (set) Token: 0x0600034E RID: 846 RVA: 0x00003A75 File Offset: 0x00003A75
		public CurveType CurveType { get; set; }

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x0600034F RID: 847 RVA: 0x00003A7E File Offset: 0x00003A7E
		// (set) Token: 0x06000350 RID: 848 RVA: 0x00003A86 File Offset: 0x00003A86
		public List<Vector2> SliderPoints { get; set; } = new List<Vector2>();

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x06000351 RID: 849 RVA: 0x00003A8F File Offset: 0x00003A8F
		// (set) Token: 0x06000352 RID: 850 RVA: 0x00003A97 File Offset: 0x00003A97
		public int Repeats { get; set; }

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x06000353 RID: 851 RVA: 0x00003AA0 File Offset: 0x00003AA0
		// (set) Token: 0x06000354 RID: 852 RVA: 0x00003AA8 File Offset: 0x00003AA8
		public double PixelLength { get; set; }

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x06000355 RID: 853 RVA: 0x00003AB1 File Offset: 0x00003AB1
		// (set) Token: 0x06000356 RID: 854 RVA: 0x00003AB9 File Offset: 0x00003AB9
		public List<HitSoundType> EdgeHitSounds { get; set; }

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x06000357 RID: 855 RVA: 0x00003AC2 File Offset: 0x00003AC2
		// (set) Token: 0x06000358 RID: 856 RVA: 0x00003ACA File Offset: 0x00003ACA
		public List<Tuple<SampleSet, SampleSet>> EdgeAdditions { get; set; }
	}
}
