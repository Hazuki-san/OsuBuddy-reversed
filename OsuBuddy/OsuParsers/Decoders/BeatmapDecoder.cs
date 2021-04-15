using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using OsuParsers.Beatmaps;
using OsuParsers.Beatmaps.Objects;
using OsuParsers.Beatmaps.Objects.Catch;
using OsuParsers.Beatmaps.Objects.Mania;
using OsuParsers.Beatmaps.Objects.Taiko;
using OsuParsers.Beatmaps.Sections.Events;
using OsuParsers.Enums;
using OsuParsers.Enums.Beatmaps;
using OsuParsers.Enums.Storyboards;
using OsuParsers.Helpers;

namespace OsuParsers.Decoders
{
	// Token: 0x02000060 RID: 96
	public static class BeatmapDecoder
	{
		// Token: 0x060001AA RID: 426 RVA: 0x0000D9E8 File Offset: 0x0000D9E8
		public static Beatmap Decode(string path)
		{
			bool flag = File.Exists(path);
			if (flag)
			{
				return BeatmapDecoder.Decode(File.ReadAllLines(path));
			}
			throw new FileNotFoundException();
		}

		// Token: 0x060001AB RID: 427 RVA: 0x0000DA18 File Offset: 0x0000DA18
		public static Beatmap Decode(IEnumerable<string> lines)
		{
			BeatmapDecoder.Beatmap = new Beatmap();
			BeatmapDecoder.currentSection = FileSections.Format;
			BeatmapDecoder.sbLines.Clear();
			foreach (string text in lines)
			{
				bool flag = !string.IsNullOrWhiteSpace(text) && !text.StartsWith("//");
				if (flag)
				{
					bool flag2 = ParseHelper.GetCurrentSection(text) > FileSections.None;
					if (flag2)
					{
						BeatmapDecoder.currentSection = ParseHelper.GetCurrentSection(text);
					}
					else
					{
						bool flag3 = ParseHelper.IsLineValid(text, BeatmapDecoder.currentSection);
						if (flag3)
						{
							BeatmapDecoder.ParseLine(text);
						}
					}
				}
			}
			BeatmapDecoder.Beatmap.EventsSection.Storyboard = StoryboardDecoder.Decode(BeatmapDecoder.sbLines.ToArray());
			BeatmapDecoder.Beatmap.GeneralSection.CirclesCount = BeatmapDecoder.Beatmap.HitObjects.Count((HitObject c) => c is HitCircle || c is TaikoHit || c is ManiaNote || c is CatchFruit);
			BeatmapDecoder.Beatmap.GeneralSection.SlidersCount = BeatmapDecoder.Beatmap.HitObjects.Count((HitObject c) => c is Slider || c is TaikoDrumroll || c is ManiaHoldNote || c is CatchJuiceStream);
			BeatmapDecoder.Beatmap.GeneralSection.SpinnersCount = BeatmapDecoder.Beatmap.HitObjects.Count((HitObject c) => c is Spinner || c is TaikoSpinner || c is CatchBananaRain);
			BeatmapDecoder.Beatmap.GeneralSection.Length = (BeatmapDecoder.Beatmap.HitObjects.Any<HitObject>() ? BeatmapDecoder.Beatmap.HitObjects.Last<HitObject>().EndTime : 0);
			return BeatmapDecoder.Beatmap;
		}

		// Token: 0x060001AC RID: 428 RVA: 0x00002C60 File Offset: 0x00002C60
		public static Beatmap Decode(Stream stream)
		{
			return BeatmapDecoder.Decode(stream.ReadAllLines());
		}

		// Token: 0x060001AD RID: 429 RVA: 0x0000DBE8 File Offset: 0x0000DBE8
		private static void ParseLine(string line)
		{
			switch (BeatmapDecoder.currentSection)
			{
			case FileSections.Format:
				BeatmapDecoder.Beatmap.Version = Convert.ToInt32(line.Split(new string[]
				{
					"osu file format v"
				}, StringSplitOptions.None)[1]);
				break;
			case FileSections.General:
				BeatmapDecoder.ParseGeneral(line);
				break;
			case FileSections.Editor:
				BeatmapDecoder.ParseEditor(line);
				break;
			case FileSections.Metadata:
				BeatmapDecoder.ParseMetadata(line);
				break;
			case FileSections.Difficulty:
				BeatmapDecoder.ParseDifficulty(line);
				break;
			case FileSections.Events:
				BeatmapDecoder.ParseEvents(line);
				break;
			case FileSections.TimingPoints:
				BeatmapDecoder.ParseTimingPoints(line);
				break;
			case FileSections.Colours:
				BeatmapDecoder.ParseColours(line);
				break;
			case FileSections.HitObjects:
				BeatmapDecoder.ParseHitObjects(line);
				break;
			}
		}

		// Token: 0x060001AE RID: 430 RVA: 0x0000DCA0 File Offset: 0x0000DCA0
		private static void ParseGeneral(string line)
		{
			int num = line.IndexOf(':');
			string text = line.Remove(num).Trim();
			string text2 = line.Remove(0, num + 1).Trim();
			string text3 = text;
			string text4 = text3;
			uint num2 = <PrivateImplementationDetails>.ComputeStringHash(text4);
			if (num2 <= 1454601404U)
			{
				if (num2 <= 1037595928U)
				{
					if (num2 != 749010473U)
					{
						if (num2 != 906899804U)
						{
							if (num2 == 1037595928U)
							{
								if (text4 == "AudioLeadIn")
								{
									BeatmapDecoder.Beatmap.GeneralSection.AudioLeadIn = Convert.ToInt32(text2);
								}
							}
						}
						else if (text4 == "AudioFilename")
						{
							BeatmapDecoder.Beatmap.GeneralSection.AudioFilename = text2;
						}
					}
					else if (text4 == "WidescreenStoryboard")
					{
						BeatmapDecoder.Beatmap.GeneralSection.WidescreenStoryboard = text2.ToBool();
					}
				}
				else if (num2 != 1192550549U)
				{
					if (num2 != 1397651250U)
					{
						if (num2 == 1454601404U)
						{
							if (text4 == "EpilepsyWarning")
							{
								BeatmapDecoder.Beatmap.GeneralSection.EpilepsyWarning = text2.ToBool();
							}
						}
					}
					else if (text4 == "Mode")
					{
						BeatmapDecoder.Beatmap.GeneralSection.Mode = (Ruleset)Enum.Parse(typeof(Ruleset), text2);
						BeatmapDecoder.Beatmap.GeneralSection.ModeId = Convert.ToInt32(text2);
					}
				}
				else if (text4 == "SpecialStyle")
				{
					BeatmapDecoder.Beatmap.GeneralSection.SpecialStyle = text2.ToBool();
				}
			}
			else if (num2 <= 2576849862U)
			{
				if (num2 != 1665405120U)
				{
					if (num2 != 2167992445U)
					{
						if (num2 == 2576849862U)
						{
							if (text4 == "PreviewTime")
							{
								BeatmapDecoder.Beatmap.GeneralSection.PreviewTime = Convert.ToInt32(text2);
							}
						}
					}
					else if (text4 == "SampleSet")
					{
						BeatmapDecoder.Beatmap.GeneralSection.SampleSet = (SampleSet)Enum.Parse(typeof(SampleSet), text2);
					}
				}
				else if (text4 == "Countdown")
				{
					BeatmapDecoder.Beatmap.GeneralSection.Countdown = text2.ToBool();
				}
			}
			else if (num2 <= 3521092244U)
			{
				if (num2 != 2838924173U)
				{
					if (num2 == 3521092244U)
					{
						if (text4 == "StoryFireInFront")
						{
							BeatmapDecoder.Beatmap.GeneralSection.StoryFireInFront = text2.ToBool();
						}
					}
				}
				else if (text4 == "UseSkinSprites")
				{
					BeatmapDecoder.Beatmap.GeneralSection.UseSkinSprites = text2.ToBool();
				}
			}
			else if (num2 != 3626434118U)
			{
				if (num2 == 4088792625U)
				{
					if (text4 == "LetterboxInBreaks")
					{
						BeatmapDecoder.Beatmap.GeneralSection.LetterboxInBreaks = text2.ToBool();
					}
				}
			}
			else if (text4 == "StackLeniency")
			{
				BeatmapDecoder.Beatmap.GeneralSection.StackLeniency = text2.ToDouble();
			}
		}

		// Token: 0x060001AF RID: 431 RVA: 0x0000E054 File Offset: 0x0000E054
		private static void ParseEditor(string line)
		{
			int num = line.IndexOf(':');
			string text = line.Remove(num).Trim();
			string text2 = line.Remove(0, num + 1).Trim();
			string text3 = text;
			string a = text3;
			if (!(a == "Bookmarks"))
			{
				if (!(a == "DistanceSpacing"))
				{
					if (!(a == "BeatDivisor"))
					{
						if (!(a == "GridSize"))
						{
							if (a == "TimelineZoom")
							{
								BeatmapDecoder.Beatmap.EditorSection.TimelineZoom = text2.ToFloat();
							}
						}
						else
						{
							BeatmapDecoder.Beatmap.EditorSection.GridSize = Convert.ToInt32(text2);
						}
					}
					else
					{
						BeatmapDecoder.Beatmap.EditorSection.BeatDivisor = Convert.ToInt32(text2);
					}
				}
				else
				{
					BeatmapDecoder.Beatmap.EditorSection.DistanceSpacing = text2.ToDouble();
				}
			}
			else
			{
				BeatmapDecoder.Beatmap.EditorSection.Bookmarks = (from b in text2.Split(new char[]
				{
					','
				}, StringSplitOptions.RemoveEmptyEntries)
				select Convert.ToInt32(b)).ToArray<int>();
			}
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x0000E190 File Offset: 0x0000E190
		private static void ParseMetadata(string line)
		{
			int num = line.IndexOf(':');
			string text = line.Remove(num).Trim();
			string text2 = line.Remove(0, num + 1).Trim();
			string text3 = text;
			string text4 = text3;
			uint num2 = <PrivateImplementationDetails>.ComputeStringHash(text4);
			if (num2 <= 1992138944U)
			{
				if (num2 <= 1573770551U)
				{
					if (num2 != 617902505U)
					{
						if (num2 == 1573770551U)
						{
							if (text4 == "Version")
							{
								BeatmapDecoder.Beatmap.MetadataSection.Version = text2;
							}
						}
					}
					else if (text4 == "Title")
					{
						BeatmapDecoder.Beatmap.MetadataSection.Title = text2;
					}
				}
				else if (num2 != 1642243064U)
				{
					if (num2 != 1711094138U)
					{
						if (num2 == 1992138944U)
						{
							if (text4 == "Tags")
							{
								BeatmapDecoder.Beatmap.MetadataSection.Tags = text2.Split(new char[]
								{
									',',
									' '
								}, StringSplitOptions.RemoveEmptyEntries);
							}
						}
					}
					else if (text4 == "BeatmapSetID")
					{
						BeatmapDecoder.Beatmap.MetadataSection.BeatmapSetID = Convert.ToInt32(text2);
					}
				}
				else if (text4 == "Source")
				{
					BeatmapDecoder.Beatmap.MetadataSection.Source = text2;
				}
			}
			else if (num2 <= 2490816510U)
			{
				if (num2 != 2258803444U)
				{
					if (num2 == 2490816510U)
					{
						if (text4 == "Artist")
						{
							BeatmapDecoder.Beatmap.MetadataSection.Artist = text2;
						}
					}
				}
				else if (text4 == "TitleUnicode")
				{
					BeatmapDecoder.Beatmap.MetadataSection.TitleUnicode = text2;
				}
			}
			else if (num2 != 3198710089U)
			{
				if (num2 != 3382753380U)
				{
					if (num2 == 4291165879U)
					{
						if (text4 == "Creator")
						{
							BeatmapDecoder.Beatmap.MetadataSection.Creator = text2;
						}
					}
				}
				else if (text4 == "BeatmapID")
				{
					BeatmapDecoder.Beatmap.MetadataSection.BeatmapID = Convert.ToInt32(text2);
				}
			}
			else if (text4 == "ArtistUnicode")
			{
				BeatmapDecoder.Beatmap.MetadataSection.ArtistUnicode = text2;
			}
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x0000E438 File Offset: 0x0000E438
		private static void ParseDifficulty(string line)
		{
			int num = line.IndexOf(':');
			string text = line.Remove(num).Trim();
			string value = line.Remove(0, num + 1).Trim();
			string text2 = text;
			string a = text2;
			if (!(a == "HPDrainRate"))
			{
				if (!(a == "CircleSize"))
				{
					if (!(a == "OverallDifficulty"))
					{
						if (!(a == "ApproachRate"))
						{
							if (!(a == "SliderMultiplier"))
							{
								if (a == "SliderTickRate")
								{
									BeatmapDecoder.Beatmap.DifficultySection.SliderTickRate = value.ToDouble();
								}
							}
							else
							{
								BeatmapDecoder.Beatmap.DifficultySection.SliderMultiplier = value.ToDouble();
							}
						}
						else
						{
							BeatmapDecoder.Beatmap.DifficultySection.ApproachRate = value.ToFloat();
						}
					}
					else
					{
						BeatmapDecoder.Beatmap.DifficultySection.OverallDifficulty = value.ToFloat();
					}
				}
				else
				{
					BeatmapDecoder.Beatmap.DifficultySection.CircleSize = value.ToFloat();
				}
			}
			else
			{
				BeatmapDecoder.Beatmap.DifficultySection.HPDrainRate = value.ToFloat();
			}
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x0000E558 File Offset: 0x0000E558
		private static void ParseEvents(string line)
		{
			string[] array = line.Split(new char[]
			{
				','
			});
			EventType eventType;
			bool flag = Enum.TryParse<EventType>(array[0], out eventType);
			EventType eventType2;
			if (flag)
			{
				eventType2 = (EventType)Enum.Parse(typeof(EventType), array[0]);
			}
			else
			{
				bool flag2 = line.StartsWith(" ") || line.StartsWith("_");
				if (!flag2)
				{
					return;
				}
				eventType2 = EventType.StoryboardCommand;
			}
			switch (eventType2)
			{
			case EventType.Background:
				BeatmapDecoder.Beatmap.EventsSection.BackgroundImage = array[2].Trim(new char[]
				{
					'"'
				});
				break;
			case EventType.Video:
				BeatmapDecoder.Beatmap.EventsSection.Video = array[2].Trim(new char[]
				{
					'"'
				});
				BeatmapDecoder.Beatmap.EventsSection.VideoOffset = Convert.ToInt32(array[1]);
				break;
			case EventType.Break:
				BeatmapDecoder.Beatmap.EventsSection.Breaks.Add(new BeatmapBreakEvent(Convert.ToInt32(array[1]), Convert.ToInt32(array[2])));
				break;
			case EventType.Sprite:
			case EventType.Sample:
			case EventType.Animation:
			case EventType.StoryboardCommand:
				BeatmapDecoder.sbLines.Add(line);
				break;
			}
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x0000E69C File Offset: 0x0000E69C
		private static void ParseTimingPoints(string line)
		{
			string[] array = line.Split(new char[]
			{
				','
			});
			int offset = (int)array[0].ToFloat();
			double beatLength = array[1].ToDouble();
			TimeSignature timeSignature = TimeSignature.SimpleQuadruple;
			SampleSet sampleSet = SampleSet.None;
			int customSampleSet = 0;
			int volume = 100;
			bool inherited = true;
			Effects effects = Effects.None;
			bool flag = array.Length >= 3;
			if (flag)
			{
				timeSignature = (TimeSignature)Convert.ToInt32(array[2]);
			}
			bool flag2 = array.Length >= 4;
			if (flag2)
			{
				sampleSet = (SampleSet)Convert.ToInt32(array[3]);
			}
			bool flag3 = array.Length >= 5;
			if (flag3)
			{
				customSampleSet = Convert.ToInt32(array[4]);
			}
			bool flag4 = array.Length >= 6;
			if (flag4)
			{
				volume = Convert.ToInt32(array[5]);
			}
			bool flag5 = array.Length >= 7;
			if (flag5)
			{
				inherited = array[6].ToBool();
			}
			bool flag6 = array.Length >= 8;
			if (flag6)
			{
				effects = (Effects)Convert.ToInt32(array[7]);
			}
			BeatmapDecoder.Beatmap.TimingPoints.Add(new TimingPoint
			{
				Offset = offset,
				BeatLength = beatLength,
				TimeSignature = timeSignature,
				SampleSet = sampleSet,
				CustomSampleSet = customSampleSet,
				Volume = volume,
				Inherited = inherited,
				Effects = effects
			});
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x0000E7D0 File Offset: 0x0000E7D0
		private static void ParseColours(string line)
		{
			int num = line.IndexOf(':');
			string text = line.Remove(num).Trim();
			string line2 = line.Remove(0, num + 1).Trim();
			string text2 = text;
			string a = text2;
			if (!(a == "SliderTrackOverride"))
			{
				if (!(a == "SliderBorder"))
				{
					BeatmapDecoder.Beatmap.ColoursSection.ComboColours.Add(ParseHelper.ParseColour(line2));
				}
				else
				{
					BeatmapDecoder.Beatmap.ColoursSection.SliderBorder = ParseHelper.ParseColour(line2);
				}
			}
			else
			{
				BeatmapDecoder.Beatmap.ColoursSection.SliderTrackOverride = ParseHelper.ParseColour(line2);
			}
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x0000E874 File Offset: 0x0000E874
		private static void ParseHitObjects(string line)
		{
			string[] array = line.Split(new char[]
			{
				','
			});
			Vector2 position = new Vector2(array[0].ToFloat(), array[1].ToFloat());
			int num = Convert.ToInt32(array[2]);
			HitObjectType hitObjectType = (HitObjectType)int.Parse(array[3]);
			int comboOffset = (int)((hitObjectType & HitObjectType.ComboOffset) >> 4);
			hitObjectType &= (HitObjectType)(-113);
			bool isNewCombo = hitObjectType.HasFlag(HitObjectType.NewCombo);
			hitObjectType &= (HitObjectType)(-5);
			HitSoundType hitSound = (HitSoundType)Convert.ToInt32(array[4]);
			HitObject item = null;
			string[] array2 = array.Last<string>().Split(new char[]
			{
				':'
			});
			int num2 = hitObjectType.HasFlag(HitObjectType.Hold) ? 1 : 0;
			Extras extras;
			if (!array.Last<string>().Contains(":"))
			{
				extras = new Extras();
			}
			else
			{
				Extras extras2 = new Extras();
				extras2.SampleSet = (SampleSet)Convert.ToInt32(array2[num2]);
				extras2.AdditionSet = (SampleSet)Convert.ToInt32(array2[1 + num2]);
				extras2.CustomIndex = ((array2.Length > 2 + num2) ? Convert.ToInt32(array2[2 + num2]) : 0);
				extras2.Volume = ((array2.Length > 3 + num2) ? Convert.ToInt32(array2[3 + num2]) : 0);
				extras = extras2;
				extras2.SampleFileName = ((array2.Length > 4 + num2) ? array2[4 + num2] : string.Empty);
			}
			Extras extras3 = extras;
			HitObjectType hitObjectType2 = hitObjectType;
			HitObjectType hitObjectType3 = hitObjectType2;
			if (hitObjectType3 <= HitObjectType.Slider)
			{
				if (hitObjectType3 != HitObjectType.Circle)
				{
					if (hitObjectType3 == HitObjectType.Slider)
					{
						CurveType curveType = ParseHelper.GetCurveType(array[5].Split(new char[]
						{
							'|'
						})[0][0]);
						List<Vector2> sliderPoints = ParseHelper.GetSliderPoints(array[5].Split(new char[]
						{
							'|'
						}));
						int repeats = Convert.ToInt32(array[6]);
						double pixelLength = array[7].ToDouble();
						int endTime = MathHelper.CalculateEndTime(BeatmapDecoder.Beatmap, num, repeats, pixelLength);
						List<HitSoundType> edgeHitSounds = null;
						bool flag = array.Length > 8 && array[8].Length > 0;
						if (flag)
						{
							edgeHitSounds = new List<HitSoundType>();
							edgeHitSounds = Array.ConvertAll<string, HitSoundType>(array[8].Split(new char[]
							{
								'|'
							}), (string s) => (HitSoundType)Convert.ToInt32(s)).ToList<HitSoundType>();
						}
						List<Tuple<SampleSet, SampleSet>> list = null;
						bool flag2 = array.Length > 9 && array[9].Length > 0;
						if (flag2)
						{
							list = new List<Tuple<SampleSet, SampleSet>>();
							foreach (string text in array[9].Split(new char[]
							{
								'|'
							}))
							{
								list.Add(new Tuple<SampleSet, SampleSet>((SampleSet)Convert.ToInt32(text.Split(new char[]
								{
									':'
								}).First<string>()), (SampleSet)Convert.ToInt32(text.Split(new char[]
								{
									':'
								}).Last<string>())));
							}
						}
						bool flag3 = BeatmapDecoder.Beatmap.GeneralSection.Mode == Ruleset.Standard;
						if (flag3)
						{
							item = new Slider(position, num, endTime, hitSound, curveType, sliderPoints, repeats, pixelLength, isNewCombo, comboOffset, edgeHitSounds, list, extras3);
						}
						else
						{
							bool flag4 = BeatmapDecoder.Beatmap.GeneralSection.Mode == Ruleset.Taiko;
							if (flag4)
							{
								item = new TaikoDrumroll(position, num, endTime, hitSound, curveType, sliderPoints, repeats, pixelLength, edgeHitSounds, list, extras3, isNewCombo, comboOffset);
							}
							else
							{
								bool flag5 = BeatmapDecoder.Beatmap.GeneralSection.Mode == Ruleset.Fruits;
								if (flag5)
								{
									item = new CatchJuiceStream(position, num, endTime, hitSound, curveType, sliderPoints, repeats, pixelLength, isNewCombo, comboOffset, edgeHitSounds, list, extras3);
								}
								else
								{
									bool flag6 = BeatmapDecoder.Beatmap.GeneralSection.Mode == Ruleset.Mania;
									if (flag6)
									{
										item = new ManiaHoldNote(position, num, endTime, hitSound, extras3, isNewCombo, comboOffset);
									}
								}
							}
						}
					}
				}
				else
				{
					bool flag7 = BeatmapDecoder.Beatmap.GeneralSection.Mode == Ruleset.Standard;
					if (flag7)
					{
						item = new HitCircle(position, num, num, hitSound, extras3, isNewCombo, comboOffset);
					}
					else
					{
						bool flag8 = BeatmapDecoder.Beatmap.GeneralSection.Mode == Ruleset.Taiko;
						if (flag8)
						{
							item = new TaikoHit(position, num, num, hitSound, extras3, isNewCombo, comboOffset);
						}
						else
						{
							bool flag9 = BeatmapDecoder.Beatmap.GeneralSection.Mode == Ruleset.Fruits;
							if (flag9)
							{
								item = new CatchFruit(position, num, num, hitSound, extras3, isNewCombo, comboOffset);
							}
							else
							{
								bool flag10 = BeatmapDecoder.Beatmap.GeneralSection.Mode == Ruleset.Mania;
								if (flag10)
								{
									item = new ManiaNote(position, num, num, hitSound, extras3, isNewCombo, comboOffset);
								}
							}
						}
					}
				}
			}
			else if (hitObjectType3 != HitObjectType.Spinner)
			{
				if (hitObjectType3 == HitObjectType.Hold)
				{
					string[] array4 = array[5].Split(new char[]
					{
						':'
					});
					int endTime2 = Convert.ToInt32(array4[0].Trim());
					item = new ManiaHoldNote(position, num, endTime2, hitSound, extras3, isNewCombo, comboOffset);
				}
			}
			else
			{
				int endTime3 = Convert.ToInt32(array[5].Trim());
				bool flag11 = BeatmapDecoder.Beatmap.GeneralSection.Mode == Ruleset.Standard;
				if (flag11)
				{
					item = new Spinner(position, num, endTime3, hitSound, extras3, isNewCombo, comboOffset);
				}
				else
				{
					bool flag12 = BeatmapDecoder.Beatmap.GeneralSection.Mode == Ruleset.Taiko;
					if (flag12)
					{
						item = new TaikoSpinner(position, num, endTime3, hitSound, extras3, isNewCombo, comboOffset);
					}
					else
					{
						bool flag13 = BeatmapDecoder.Beatmap.GeneralSection.Mode == Ruleset.Fruits;
						if (flag13)
						{
							item = new CatchBananaRain(position, num, endTime3, hitSound, extras3, isNewCombo, comboOffset);
						}
					}
				}
			}
			BeatmapDecoder.Beatmap.HitObjects.Add(item);
		}

		// Token: 0x04000238 RID: 568
		private static Beatmap Beatmap;

		// Token: 0x04000239 RID: 569
		private static FileSections currentSection = FileSections.None;

		// Token: 0x0400023A RID: 570
		private static List<string> sbLines = new List<string>();
	}
}
