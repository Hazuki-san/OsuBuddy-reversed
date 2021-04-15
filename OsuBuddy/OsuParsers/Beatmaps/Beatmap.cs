using System;
using System.Collections.Generic;
using System.IO;
using OsuParsers.Beatmaps.Objects;
using OsuParsers.Beatmaps.Sections;
using OsuParsers.Encoders;
using OsuParsers.Helpers;

namespace OsuParsers.Beatmaps
{
	// Token: 0x0200006E RID: 110
	public class Beatmap
	{
		// Token: 0x1700009D RID: 157
		// (get) Token: 0x060002A6 RID: 678 RVA: 0x0000345B File Offset: 0x0000345B
		// (set) Token: 0x060002A7 RID: 679 RVA: 0x00003463 File Offset: 0x00003463
		public int Version { get; set; } = 14;

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x060002A8 RID: 680 RVA: 0x0000346C File Offset: 0x0000346C
		// (set) Token: 0x060002A9 RID: 681 RVA: 0x00003474 File Offset: 0x00003474
		public BeatmapGeneralSection GeneralSection { get; set; } = new BeatmapGeneralSection();

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060002AA RID: 682 RVA: 0x0000347D File Offset: 0x0000347D
		// (set) Token: 0x060002AB RID: 683 RVA: 0x00003485 File Offset: 0x00003485
		public BeatmapEditorSection EditorSection { get; set; } = new BeatmapEditorSection();

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060002AC RID: 684 RVA: 0x0000348E File Offset: 0x0000348E
		// (set) Token: 0x060002AD RID: 685 RVA: 0x00003496 File Offset: 0x00003496
		public BeatmapMetadataSection MetadataSection { get; set; } = new BeatmapMetadataSection();

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060002AE RID: 686 RVA: 0x0000349F File Offset: 0x0000349F
		// (set) Token: 0x060002AF RID: 687 RVA: 0x000034A7 File Offset: 0x000034A7
		public BeatmapDifficultySection DifficultySection { get; set; } = new BeatmapDifficultySection();

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x060002B0 RID: 688 RVA: 0x000034B0 File Offset: 0x000034B0
		// (set) Token: 0x060002B1 RID: 689 RVA: 0x000034B8 File Offset: 0x000034B8
		public BeatmapEventsSection EventsSection { get; set; } = new BeatmapEventsSection();

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x060002B2 RID: 690 RVA: 0x000034C1 File Offset: 0x000034C1
		// (set) Token: 0x060002B3 RID: 691 RVA: 0x000034C9 File Offset: 0x000034C9
		public BeatmapColoursSection ColoursSection { get; set; } = new BeatmapColoursSection();

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x060002B4 RID: 692 RVA: 0x000034D2 File Offset: 0x000034D2
		// (set) Token: 0x060002B5 RID: 693 RVA: 0x000034DA File Offset: 0x000034DA
		public List<TimingPoint> TimingPoints { get; set; } = new List<TimingPoint>();

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060002B6 RID: 694 RVA: 0x000034E3 File Offset: 0x000034E3
		// (set) Token: 0x060002B7 RID: 695 RVA: 0x000034EB File Offset: 0x000034EB
		public List<HitObject> HitObjects { get; set; } = new List<HitObject>();

		// Token: 0x060002B8 RID: 696 RVA: 0x000105CC File Offset: 0x000105CC
		public double BeatLengthAt(int offset)
		{
			bool flag = this.TimingPoints.Count == 0;
			double result;
			if (flag)
			{
				result = 0.0;
			}
			else
			{
				int num = 0;
				int num2 = 0;
				for (int i = 0; i < this.TimingPoints.Count; i++)
				{
					bool flag2 = this.TimingPoints[i].Offset <= offset;
					if (flag2)
					{
						bool inherited = this.TimingPoints[i].Inherited;
						if (inherited)
						{
							num = i;
						}
						else
						{
							num2 = i;
						}
					}
				}
				double num3 = 1.0;
				bool flag3 = num2 > num && this.TimingPoints[num2].BeatLength < 0.0;
				if (flag3)
				{
					num3 = MathHelper.CalculateBpmMultiplier(this.TimingPoints[num2]);
				}
				result = this.TimingPoints[num].BeatLength * num3;
			}
			return result;
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x000034F4 File Offset: 0x000034F4
		public void Save(string path)
		{
			File.WriteAllLines(path, BeatmapEncoder.Encode(this));
		}

		// Token: 0x040002A9 RID: 681
		public const int LATEST_OSZ_VERSION = 14;
	}
}
