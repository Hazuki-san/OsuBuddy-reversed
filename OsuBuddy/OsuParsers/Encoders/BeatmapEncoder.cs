using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using OsuParsers.Beatmaps;
using OsuParsers.Beatmaps.Objects;
using OsuParsers.Beatmaps.Sections;
using OsuParsers.Beatmaps.Sections.Events;
using OsuParsers.Enums;
using OsuParsers.Enums.Storyboards;
using OsuParsers.Helpers;
using OsuParsers.Storyboards.Interfaces;
using OsuParsers.Storyboards.Objects;

namespace OsuParsers.Encoders
{
	// Token: 0x02000059 RID: 89
	internal class BeatmapEncoder
	{
		// Token: 0x06000180 RID: 384 RVA: 0x0000C2BC File Offset: 0x0000A4BC
		public static List<string> Encode(Beatmap beatmap)
		{
			BeatmapEncoder.Ac__DisplayClass0_0 ac__DisplayClass0_ = new BeatmapEncoder.Ac__DisplayClass0_0();
			List<List<string>> list = new List<List<string>>
			{
				BeatmapEncoder.GeneralSection(beatmap.GeneralSection),
				BeatmapEncoder.EditorSection(beatmap.EditorSection),
				BeatmapEncoder.MetadataSection(beatmap.MetadataSection),
				BeatmapEncoder.DifficultySection(beatmap.DifficultySection),
				BeatmapEncoder.EventsSection(beatmap.EventsSection),
				BeatmapEncoder.TimingPoints(beatmap.TimingPoints),
				BeatmapEncoder.Colours(beatmap.ColoursSection),
				BeatmapEncoder.HitObjects(beatmap.HitObjects)
			};
			ac__DisplayClass0_.contents = new List<string>
			{
				string.Format("osu file format v{0}", beatmap.Version)
			};
			list.ForEach(new Action<List<string>>(ac__DisplayClass0_.AEncodeb__0));
			return ac__DisplayClass0_.contents;
		}

		// Token: 0x06000181 RID: 385 RVA: 0x0000C3AC File Offset: 0x0000A5AC
		public static List<string> GeneralSection(BeatmapGeneralSection section)
		{
			List<string> list = WriteHelper.BaseListFormat("General");
			list.AddRange(new List<string>
			{
				"AudioFilename: " + section.AudioFilename,
				"AudioLeadIn: " + section.AudioLeadIn.ToString(),
				"PreviewTime: " + section.PreviewTime.ToString(),
				"Countdown: " + section.Countdown.ToInt32().ToString(),
				"SampleSet: " + section.SampleSet.ToString(),
				"StackLeniency: " + section.StackLeniency.Format(),
				"Mode: " + ((int)section.Mode).ToString(),
				"LetterboxInBreaks: " + section.LetterboxInBreaks.ToInt32().ToString()
			});
			bool storyFireInFront = section.StoryFireInFront;
			if (storyFireInFront)
			{
				list.Add("StoryFireInFront: " + section.StoryFireInFront.ToInt32().ToString());
			}
			bool useSkinSprites = section.UseSkinSprites;
			if (useSkinSprites)
			{
				list.Add("UseSkinSprites: " + section.UseSkinSprites.ToInt32().ToString());
			}
			bool epilepsyWarning = section.EpilepsyWarning;
			if (epilepsyWarning)
			{
				list.Add("EpilepsyWarning: " + section.EpilepsyWarning.ToInt32().ToString());
			}
			bool flag = section.Mode == Ruleset.Mania;
			if (flag)
			{
				list.Add("SpecialStyle: " + section.SpecialStyle.ToInt32().ToString());
			}
			list.Add("WidescreenStoryboard: " + section.WidescreenStoryboard.ToInt32().ToString());
			return list;
		}

		// Token: 0x06000182 RID: 386 RVA: 0x0000C5BC File Offset: 0x0000A7BC
		public static List<string> EditorSection(BeatmapEditorSection section)
		{
			List<string> list = WriteHelper.BaseListFormat("Editor");
			bool flag = section.Bookmarks != null;
			if (flag)
			{
				list.Add("Bookmarks: " + section.BookmarksString);
			}
			list.AddRange(new List<string>
			{
				"DistanceSpacing: " + section.DistanceSpacing.Format(),
				"BeatDivisor: " + section.BeatDivisor.Format(),
				"GridSize: " + section.GridSize.Format(),
				"TimelineZoom: " + section.TimelineZoom.Format()
			});
			return list;
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0000C67C File Offset: 0x0000A87C
		public static List<string> MetadataSection(BeatmapMetadataSection section)
		{
			return new List<string>
			{
				string.Empty,
				"[Metadata]",
				"Title:" + section.Title,
				"TitleUnicode:" + section.TitleUnicode,
				"Artist:" + section.Artist,
				"ArtistUnicode:" + section.ArtistUnicode,
				"Creator:" + section.Creator,
				"Version:" + section.Version,
				"Source:" + section.Source,
				"Tags:" + section.TagsString,
				"BeatmapID:" + section.BeatmapID.ToString(),
				"BeatmapSetID:" + section.BeatmapSetID.ToString()
			};
		}

		// Token: 0x06000184 RID: 388 RVA: 0x0000C7A4 File Offset: 0x0000A9A4
		public static List<string> DifficultySection(BeatmapDifficultySection section)
		{
			return new List<string>
			{
				string.Empty,
				"[Difficulty]",
				"HPDrainRate:" + section.HPDrainRate.Format(),
				"CircleSize:" + section.CircleSize.Format(),
				"OverallDifficulty:" + section.OverallDifficulty.Format(),
				"ApproachRate:" + section.ApproachRate.Format(),
				"SliderMultiplier:" + section.SliderMultiplier.Format(),
				"SliderTickRate:" + section.SliderTickRate.Format()
			};
		}

		// Token: 0x06000185 RID: 389 RVA: 0x0000C87C File Offset: 0x0000AA7C
		public static List<string> EventsSection(BeatmapEventsSection section)
		{
			BeatmapEncoder.Ac__DisplayClass5_0 ac__DisplayClass5_ = new BeatmapEncoder.Ac__DisplayClass5_0();
			ac__DisplayClass5_.list = WriteHelper.BaseListFormat("Events");
			ac__DisplayClass5_.list.AddRange(new List<string>
			{
				"//Background and Video events",
				"0,0,\"" + section.BackgroundImage + "\",0,0"
			});
			bool flag = section.Video != null;
			if (flag)
			{
				ac__DisplayClass5_.list.Add(string.Format("Video,{0},\"{1}\"", section.VideoOffset, section.Video));
			}
			ac__DisplayClass5_.list.Add("//Break Periods");
			bool flag2 = section.Breaks.Any<BeatmapBreakEvent>();
			if (flag2)
			{
				ac__DisplayClass5_.list.AddRange(section.Breaks.ConvertAll<string>(new Converter<BeatmapBreakEvent, string>(BeatmapEncoder.Ac.A9.AEventsSectionb__5_0)));
			}
			ac__DisplayClass5_.list.Add("//Storyboard Layer 0 (Background)");
			section.Storyboard.BackgroundLayer.ForEach(new Action<IStoryboardObject>(ac__DisplayClass5_.AEventsSectionb__1));
			ac__DisplayClass5_.list.Add("//Storyboard Layer 1 (Fail)");
			section.Storyboard.FailLayer.ForEach(new Action<IStoryboardObject>(ac__DisplayClass5_.AEventsSectionb__2));
			ac__DisplayClass5_.list.Add("//Storyboard Layer 2 (Pass)");
			section.Storyboard.PassLayer.ForEach(new Action<IStoryboardObject>(ac__DisplayClass5_.AEventsSectionb__3));
			ac__DisplayClass5_.list.Add("//Storyboard Layer 3 (Foreground)");
			section.Storyboard.ForegroundLayer.ForEach(new Action<IStoryboardObject>(ac__DisplayClass5_.AEventsSectionb__4));
			ac__DisplayClass5_.list.Add("//Storyboard Layer 4 (Overlay)");
			section.Storyboard.OverlayLayer.ForEach(new Action<IStoryboardObject>(ac__DisplayClass5_.AEventsSectionb__5));
			ac__DisplayClass5_.list.Add("//Storyboard Sound Samples");
			section.Storyboard.SamplesLayer.ForEach(new Action<IStoryboardObject>(ac__DisplayClass5_.AEventsSectionb__6));
			return ac__DisplayClass5_.list;
		}

		// Token: 0x06000186 RID: 390 RVA: 0x0000CA84 File Offset: 0x0000AC84
		public static List<string> TimingPoints(List<TimingPoint> timingPoints)
		{
			bool flag = timingPoints.Count == 0;
			List<string> result;
			if (flag)
			{
				result = new List<string>();
			}
			else
			{
				List<string> list = WriteHelper.BaseListFormat("TimingPoints");
				bool flag2 = timingPoints != null;
				if (flag2)
				{
					list.AddRange(timingPoints.ConvertAll<string>(new Converter<TimingPoint, string>(BeatmapEncoder.Ac.A9.ATimingPointsb__6_0)));
				}
				list.Add(string.Empty);
				result = list;
			}
			return result;
		}

		// Token: 0x06000187 RID: 391 RVA: 0x0000CAF8 File Offset: 0x0000ACF8
		public static List<string> Colours(BeatmapColoursSection section)
		{
			bool flag = section.ComboColours.Count == 0 && section.SliderTrackOverride == default(Color) && section.SliderBorder == default(Color);
			List<string> result;
			if (flag)
			{
				result = new List<string>();
			}
			else
			{
				List<string> list = WriteHelper.BaseListFormat("Colours");
				bool flag2 = section.ComboColours != null;
				if (flag2)
				{
					for (int i = 0; i < section.ComboColours.Count; i++)
					{
						list.Add(string.Format("Combo{0} : {1}", i + 1, WriteHelper.Colour(section.ComboColours[i])));
					}
				}
				bool flag3 = section.SliderTrackOverride != default(Color);
				if (flag3)
				{
					list.Add("SliderTrackOverride : " + WriteHelper.Colour(section.SliderTrackOverride));
				}
				bool flag4 = section.SliderBorder != default(Color);
				if (flag4)
				{
					list.Add("SliderBorder : " + WriteHelper.Colour(section.SliderBorder));
				}
				result = list;
			}
			return result;
		}

		// Token: 0x06000188 RID: 392 RVA: 0x0000CC28 File Offset: 0x0000AE28
		public static List<string> HitObjects(List<HitObject> hitObjects)
		{
			List<string> list = WriteHelper.BaseListFormat("HitObjects");
			bool flag = hitObjects != null;
			if (flag)
			{
				list.AddRange(hitObjects.ConvertAll<string>(new Converter<HitObject, string>(BeatmapEncoder.Ac.A9.AHitObjectsb__8_0)));
			}
			return list;
		}

		// Token: 0x0200005A RID: 90
		[CompilerGenerated]
		private sealed class Ac__DisplayClass0_0
		{
			// Token: 0x0600018B RID: 395 RVA: 0x0000CC7C File Offset: 0x0000AE7C
			internal void AEncodeb__0(List<string> stringList)
			{
				Action<string> action;
				if ((action = this.A9__1) == null)
				{
					action = (this.A9__1 = new Action<string>(this.AEncodeb__1));
				}
				stringList.ForEach(action);
			}

			// Token: 0x0600018C RID: 396 RVA: 0x00002B6D File Offset: 0x00000D6D
			internal void AEncodeb__1(string item)
			{
				this.contents.Add(item);
			}

			// Token: 0x04000228 RID: 552
			public List<string> contents;

			// Token: 0x04000229 RID: 553
			public Action<string> A9__1;
		}

		// Token: 0x0200005B RID: 91
		[CompilerGenerated]
		private sealed class Ac__DisplayClass5_0
		{
			// Token: 0x0600018E RID: 398 RVA: 0x00002B7C File Offset: 0x00000D7C
			internal void AEventsSectionb__1(IStoryboardObject sbObject)
			{
				this.list.AddRange(WriteHelper.StoryboardObject(sbObject, StoryboardLayer.Background));
			}

			// Token: 0x0600018F RID: 399 RVA: 0x00002B91 File Offset: 0x00000D91
			internal void AEventsSectionb__2(IStoryboardObject sbObject)
			{
				this.list.AddRange(WriteHelper.StoryboardObject(sbObject, StoryboardLayer.Fail));
			}

			// Token: 0x06000190 RID: 400 RVA: 0x00002BA6 File Offset: 0x00000DA6
			internal void AEventsSectionb__3(IStoryboardObject sbObject)
			{
				this.list.AddRange(WriteHelper.StoryboardObject(sbObject, StoryboardLayer.Pass));
			}

			// Token: 0x06000191 RID: 401 RVA: 0x00002BBB File Offset: 0x00000DBB
			internal void AEventsSectionb__4(IStoryboardObject sbObject)
			{
				this.list.AddRange(WriteHelper.StoryboardObject(sbObject, StoryboardLayer.Foreground));
			}

			// Token: 0x06000192 RID: 402 RVA: 0x00002BD0 File Offset: 0x00000DD0
			internal void AEventsSectionb__5(IStoryboardObject sbObject)
			{
				this.list.AddRange(WriteHelper.StoryboardObject(sbObject, StoryboardLayer.Overlay));
			}

			// Token: 0x06000193 RID: 403 RVA: 0x00002BE5 File Offset: 0x00000DE5
			internal void AEventsSectionb__6(IStoryboardObject sbObject)
			{
				this.list.AddRange(WriteHelper.StoryboardObject(sbObject, (sbObject as StoryboardSample).Layer));
			}

			// Token: 0x0400022A RID: 554
			public List<string> list;
		}

		// Token: 0x0200005C RID: 92
		[CompilerGenerated]
		[Serializable]
		private sealed class Ac
		{
			// Token: 0x06000196 RID: 406 RVA: 0x00002C10 File Offset: 0x00000E10
			internal string AEventsSectionb__5_0(BeatmapBreakEvent b)
			{
				return string.Format("2,{0},{1}", b.StartTime, b.EndTime);
			}

			// Token: 0x06000197 RID: 407 RVA: 0x00002C32 File Offset: 0x00000E32
			internal string ATimingPointsb__6_0(TimingPoint point)
			{
				return WriteHelper.TimingPoint(point);
			}

			// Token: 0x06000198 RID: 408 RVA: 0x00002C3A File Offset: 0x00000E3A
			internal string AHitObjectsb__8_0(HitObject obj)
			{
				return WriteHelper.HitObject(obj);
			}

			// Token: 0x0400022B RID: 555
			public static readonly BeatmapEncoder.Ac A9 = new BeatmapEncoder.Ac();

			// Token: 0x0400022C RID: 556
			public static Converter<BeatmapBreakEvent, string> A9__5_0;

			// Token: 0x0400022D RID: 557
			public static Converter<TimingPoint, string> A9__6_0;

			// Token: 0x0400022E RID: 558
			public static Converter<HitObject, string> A9__8_0;
		}
	}
}
