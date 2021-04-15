using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
		// Token: 0x06000180 RID: 384 RVA: 0x0000C2BC File Offset: 0x0000C2BC
		public static List<string> Encode(Beatmap beatmap)
		{
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
			List<string> contents = new List<string>
			{
				string.Format("osu file format v{0}", beatmap.Version)
			};
			Action<string> <>9__1;
			list.ForEach(delegate(List<string> stringList)
			{
				Action<string> action;
				if ((action = <>9__1) == null)
				{
					action = (<>9__1 = delegate(string item)
					{
						contents.Add(item);
					});
				}
				stringList.ForEach(action);
			});
			return contents;
		}

		// Token: 0x06000181 RID: 385 RVA: 0x0000C3AC File Offset: 0x0000C3AC
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

		// Token: 0x06000182 RID: 386 RVA: 0x0000C5BC File Offset: 0x0000C5BC
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

		// Token: 0x06000183 RID: 387 RVA: 0x0000C67C File Offset: 0x0000C67C
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

		// Token: 0x06000184 RID: 388 RVA: 0x0000C7A4 File Offset: 0x0000C7A4
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

		// Token: 0x06000185 RID: 389 RVA: 0x0000C87C File Offset: 0x0000C87C
		public static List<string> EventsSection(BeatmapEventsSection section)
		{
			List<string> list = WriteHelper.BaseListFormat("Events");
			list.AddRange(new List<string>
			{
				"//Background and Video events",
				"0,0,\"" + section.BackgroundImage + "\",0,0"
			});
			bool flag = section.Video != null;
			if (flag)
			{
				list.Add(string.Format("Video,{0},\"{1}\"", section.VideoOffset, section.Video));
			}
			list.Add("//Break Periods");
			bool flag2 = section.Breaks.Any<BeatmapBreakEvent>();
			if (flag2)
			{
				list.AddRange(section.Breaks.ConvertAll<string>((BeatmapBreakEvent b) => string.Format("2,{0},{1}", b.StartTime, b.EndTime)));
			}
			list.Add("//Storyboard Layer 0 (Background)");
			section.Storyboard.BackgroundLayer.ForEach(delegate(IStoryboardObject sbObject)
			{
				list.AddRange(WriteHelper.StoryboardObject(sbObject, StoryboardLayer.Background));
			});
			list.Add("//Storyboard Layer 1 (Fail)");
			section.Storyboard.FailLayer.ForEach(delegate(IStoryboardObject sbObject)
			{
				list.AddRange(WriteHelper.StoryboardObject(sbObject, StoryboardLayer.Fail));
			});
			list.Add("//Storyboard Layer 2 (Pass)");
			section.Storyboard.PassLayer.ForEach(delegate(IStoryboardObject sbObject)
			{
				list.AddRange(WriteHelper.StoryboardObject(sbObject, StoryboardLayer.Pass));
			});
			list.Add("//Storyboard Layer 3 (Foreground)");
			section.Storyboard.ForegroundLayer.ForEach(delegate(IStoryboardObject sbObject)
			{
				list.AddRange(WriteHelper.StoryboardObject(sbObject, StoryboardLayer.Foreground));
			});
			list.Add("//Storyboard Layer 4 (Overlay)");
			section.Storyboard.OverlayLayer.ForEach(delegate(IStoryboardObject sbObject)
			{
				list.AddRange(WriteHelper.StoryboardObject(sbObject, StoryboardLayer.Overlay));
			});
			list.Add("//Storyboard Sound Samples");
			section.Storyboard.SamplesLayer.ForEach(delegate(IStoryboardObject sbObject)
			{
				list.AddRange(WriteHelper.StoryboardObject(sbObject, (sbObject as StoryboardSample).Layer));
			});
			return list;
		}

		// Token: 0x06000186 RID: 390 RVA: 0x0000CA84 File Offset: 0x0000CA84
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
					list.AddRange(timingPoints.ConvertAll<string>((TimingPoint point) => WriteHelper.TimingPoint(point)));
				}
				list.Add(string.Empty);
				result = list;
			}
			return result;
		}

		// Token: 0x06000187 RID: 391 RVA: 0x0000CAF8 File Offset: 0x0000CAF8
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

		// Token: 0x06000188 RID: 392 RVA: 0x0000CC28 File Offset: 0x0000CC28
		public static List<string> HitObjects(List<HitObject> hitObjects)
		{
			List<string> list = WriteHelper.BaseListFormat("HitObjects");
			bool flag = hitObjects != null;
			if (flag)
			{
				list.AddRange(hitObjects.ConvertAll<string>((HitObject obj) => WriteHelper.HitObject(obj)));
			}
			return list;
		}
	}
}
