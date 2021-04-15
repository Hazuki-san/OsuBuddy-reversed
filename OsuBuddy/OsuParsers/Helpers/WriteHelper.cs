using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using OsuParsers.Beatmaps.Objects;
using OsuParsers.Beatmaps.Objects.Mania;
using OsuParsers.Enums.Beatmaps;
using OsuParsers.Enums.Storyboards;
using OsuParsers.Storyboards.Commands;
using OsuParsers.Storyboards.Interfaces;
using OsuParsers.Storyboards.Objects;

namespace OsuParsers.Helpers
{
	// Token: 0x0200003C RID: 60
	internal class WriteHelper
	{
		// Token: 0x06000167 RID: 359 RVA: 0x0000B150 File Offset: 0x00009350
		public static string TimingPoint(TimingPoint timingPoint)
		{
			int offset = timingPoint.Offset;
			string text = timingPoint.BeatLength.Format();
			int timeSignature = (int)timingPoint.TimeSignature;
			int sampleSet = (int)timingPoint.SampleSet;
			int customSampleSet = timingPoint.CustomSampleSet;
			int volume = timingPoint.Volume;
			int num = timingPoint.Inherited.ToInt32();
			int effects = (int)timingPoint.Effects;
			return string.Format("{0},{1},{2},{3},{4},{5},{6},{7}", new object[]
			{
				offset,
				text,
				timeSignature,
				sampleSet,
				customSampleSet,
				volume,
				num,
				effects
			});
		}

		// Token: 0x06000168 RID: 360 RVA: 0x0000B204 File Offset: 0x00009404
		public static string Colour(Color colour)
		{
			byte r = colour.R;
			byte g = colour.G;
			byte b = colour.B;
			return string.Format("{0},{1},{2}", r, g, b);
		}

		// Token: 0x06000169 RID: 361 RVA: 0x0000B24C File Offset: 0x0000944C
		public static string HitObject(HitObject hitObject)
		{
			float x = hitObject.Position.X;
			float y = hitObject.Position.Y;
			int startTime = hitObject.StartTime;
			int hitSound = (int)hitObject.HitSound;
			string text = WriteHelper.HitObjectExtras(hitObject.Extras);
			int num = WriteHelper.TypeByte(hitObject);
			string str = string.Format("{0},{1},{2},{3},{4}", new object[]
			{
				x,
				y,
				startTime,
				num,
				hitSound
			});
			string text2 = ",";
			bool flag = hitObject is HitCircle && !(hitObject is ManiaHoldNote);
			if (flag)
			{
				text2 += text;
			}
			Slider slider = hitObject as Slider;
			bool flag2 = slider != null;
			if (flag2)
			{
				text2 = text2 + WriteHelper.SliderProperties(slider) + ((slider.EdgeHitSounds == null || !slider.EdgeHitSounds.Any<HitSoundType>()) ? string.Empty : ("," + text));
			}
			Spinner spinner = hitObject as Spinner;
			bool flag3 = spinner != null;
			if (flag3)
			{
				text2 += string.Format("{0},{1}", spinner.EndTime, text);
			}
			ManiaHoldNote maniaHoldNote = hitObject as ManiaHoldNote;
			bool flag4 = maniaHoldNote != null;
			if (flag4)
			{
				text2 += string.Format("{0}:{1}", maniaHoldNote.EndTime, text);
			}
			return str + text2;
		}

		// Token: 0x0600016A RID: 362 RVA: 0x0000B3C8 File Offset: 0x000095C8
		public static string SliderProperties(Slider slider)
		{
			WriteHelper.Ac__DisplayClass3_0 ac__DisplayClass3_ = new WriteHelper.Ac__DisplayClass3_0();
			char c = WriteHelper.CurveType(slider.CurveType);
			ac__DisplayClass3_.sliderPoints = string.Empty;
			slider.SliderPoints.ForEach(new Action<Vector2>(ac__DisplayClass3_.ASliderPropertiesb__0));
			int repeats = slider.Repeats;
			string text = slider.PixelLength.Format();
			bool flag = slider.EdgeHitSounds != null && slider.EdgeHitSounds.Any<HitSoundType>();
			string result;
			if (flag)
			{
				WriteHelper.Ac__DisplayClass3_1 ac__DisplayClass3_2 = new WriteHelper.Ac__DisplayClass3_1();
				ac__DisplayClass3_2.edgeHitsounds = string.Empty;
				slider.EdgeHitSounds.ForEach(new Action<HitSoundType>(ac__DisplayClass3_2.ASliderPropertiesb__1));
				ac__DisplayClass3_2.edgeHitsounds = ac__DisplayClass3_2.edgeHitsounds.TrimEnd(new char[]
				{
					'|'
				});
				bool flag2 = slider.EdgeAdditions == null;
				if (flag2)
				{
					result = string.Format("{0}{1},{2},{3},{4}", new object[]
					{
						c,
						ac__DisplayClass3_.sliderPoints,
						repeats,
						text,
						ac__DisplayClass3_2.edgeHitsounds
					});
				}
				else
				{
					ac__DisplayClass3_2.edgeAdditions = string.Empty;
					slider.EdgeAdditions.ToList<Tuple<SampleSet, SampleSet>>().ForEach(new Action<Tuple<SampleSet, SampleSet>>(ac__DisplayClass3_2.ASliderPropertiesb__2));
					ac__DisplayClass3_2.edgeAdditions = ac__DisplayClass3_2.edgeAdditions.Trim(new char[]
					{
						'|'
					});
					result = string.Format("{0}{1},{2},{3},{4},{5}", new object[]
					{
						c,
						ac__DisplayClass3_.sliderPoints,
						repeats,
						text,
						ac__DisplayClass3_2.edgeHitsounds,
						ac__DisplayClass3_2.edgeAdditions
					});
				}
			}
			else
			{
				result = string.Format("{0}{1},{2},{3}", new object[]
				{
					c,
					ac__DisplayClass3_.sliderPoints,
					repeats,
					text
				});
			}
			return result;
		}

		// Token: 0x0600016B RID: 363 RVA: 0x0000B59C File Offset: 0x0000979C
		public static char CurveType(CurveType value)
		{
			char result;
			switch (value)
			{
			case OsuParsers.Enums.Beatmaps.CurveType.Catmull:
				result = 'C';
				break;
			case OsuParsers.Enums.Beatmaps.CurveType.Bezier:
				result = 'B';
				break;
			case OsuParsers.Enums.Beatmaps.CurveType.Linear:
				result = 'L';
				break;
			case OsuParsers.Enums.Beatmaps.CurveType.PerfectCurve:
				result = 'P';
				break;
			default:
				throw new InvalidCastException();
			}
			return result;
		}

		// Token: 0x0600016C RID: 364 RVA: 0x0000B5E4 File Offset: 0x000097E4
		public static int TypeByte(HitObject hitObject)
		{
			int num = 0;
			bool flag = hitObject is HitCircle && !(hitObject is ManiaHoldNote);
			if (flag)
			{
				num++;
			}
			bool flag2 = hitObject is Slider;
			if (flag2)
			{
				num += 2;
			}
			bool flag3 = hitObject is Spinner;
			if (flag3)
			{
				num += 8;
			}
			bool flag4 = hitObject is ManiaHoldNote;
			if (flag4)
			{
				num += 128;
			}
			num += (hitObject.IsNewCombo ? 4 : 0);
			return num + (hitObject.ComboOffset << 4);
		}

		// Token: 0x0600016D RID: 365 RVA: 0x0000B670 File Offset: 0x00009870
		public static string HitObjectExtras(Extras extras)
		{
			bool flag = extras == null;
			string result;
			if (flag)
			{
				result = "0:0:0:0:";
			}
			else
			{
				int sampleSet = (int)extras.SampleSet;
				int additionSet = (int)extras.AdditionSet;
				int customIndex = extras.CustomIndex;
				int volume = extras.Volume;
				string text = extras.SampleFileName ?? string.Empty;
				result = string.Format("{0}:{1}:{2}:{3}:{4}", new object[]
				{
					sampleSet,
					additionSet,
					customIndex,
					volume,
					text
				});
			}
			return result;
		}

		// Token: 0x0600016E RID: 366 RVA: 0x0000B700 File Offset: 0x00009900
		public static List<string> StoryboardObject(IStoryboardObject storyboardObject, StoryboardLayer layer)
		{
			List<string> list = new List<string>();
			StoryboardSprite storyboardSprite = storyboardObject as StoryboardSprite;
			bool flag = storyboardSprite != null;
			if (flag)
			{
				list.Add(string.Format("Sprite,{0},{1},\"{2}\",{3},{4}", new object[]
				{
					layer,
					storyboardSprite.Origin,
					storyboardSprite.FilePath,
					storyboardSprite.X.Format(),
					storyboardSprite.Y.Format()
				}));
			}
			else
			{
				StoryboardAnimation storyboardAnimation = storyboardObject as StoryboardAnimation;
				bool flag2 = storyboardAnimation != null;
				if (flag2)
				{
					list.Add(string.Format("Animation,{0},{1},\"{2}\",{3},{4},{5},{6},{7}", new object[]
					{
						layer,
						storyboardAnimation.Origin,
						storyboardAnimation.FilePath,
						storyboardAnimation.X.Format(),
						storyboardAnimation.Y.Format(),
						storyboardAnimation.FrameCount,
						storyboardAnimation.FrameDelay,
						storyboardAnimation.LoopType
					}));
				}
				else
				{
					StoryboardSample storyboardSample = storyboardObject as StoryboardSample;
					bool flag3 = storyboardSample != null;
					if (flag3)
					{
						list.Add(string.Format("Sample,{0},{1},\"{2}\",{3}", new object[]
						{
							storyboardSample.Time,
							layer,
							storyboardSample.FilePath,
							storyboardSample.Volume
						}));
					}
				}
			}
			IHasCommands hasCommands = storyboardObject as IHasCommands;
			bool flag4 = hasCommands != null;
			if (flag4)
			{
				foreach (LoopCommand loopCommand in hasCommands.Commands.Loops)
				{
					list.Add(string.Format(" L,{0},{1}", loopCommand.LoopStartTime, loopCommand.LoopCount));
					foreach (Command command in loopCommand.Commands.Commands)
					{
						bool flag5 = command.StartTime == command.EndTime;
						if (flag5)
						{
							list.Add(string.Format("  {0},{1},{2},,{3}", new object[]
							{
								command.GetAcronym(),
								(int)command.Easing,
								command.StartTime,
								WriteHelper.GetCommandArguments(command)
							}));
						}
						else
						{
							list.Add(string.Format("  {0},{1},{2},{3},{4}", new object[]
							{
								command.GetAcronym(),
								(int)command.Easing,
								command.StartTime,
								command.EndTime,
								WriteHelper.GetCommandArguments(command)
							}));
						}
					}
				}
				foreach (Command command2 in hasCommands.Commands.Commands)
				{
					bool flag6 = command2.StartTime == command2.EndTime;
					if (flag6)
					{
						list.Add(string.Format(" {0},{1},{2},,{3}", new object[]
						{
							command2.GetAcronym(),
							(int)command2.Easing,
							command2.StartTime,
							WriteHelper.GetCommandArguments(command2)
						}));
					}
					else
					{
						list.Add(string.Format(" {0},{1},{2},{3},{4}", new object[]
						{
							command2.GetAcronym(),
							(int)command2.Easing,
							command2.StartTime,
							command2.EndTime,
							WriteHelper.GetCommandArguments(command2)
						}));
					}
				}
				foreach (TriggerCommand triggerCommand in hasCommands.Commands.Triggers)
				{
					bool flag7 = triggerCommand.TriggerEndTime == 0;
					if (flag7)
					{
						list.Add(" T," + triggerCommand.TriggerName + ((triggerCommand.GroupNumber != 0) ? string.Format(",{0}", -triggerCommand.GroupNumber) : string.Empty));
					}
					else
					{
						list.Add(string.Format(" T,{0},{1},{2}{3}", new object[]
						{
							triggerCommand.TriggerName,
							triggerCommand.TriggerStartTime,
							triggerCommand.TriggerEndTime,
							(triggerCommand.GroupNumber != 0) ? string.Format(",{0}", -triggerCommand.GroupNumber) : string.Empty
						}));
					}
					foreach (Command command3 in triggerCommand.Commands.Commands)
					{
						bool flag8 = command3.StartTime == command3.EndTime;
						if (flag8)
						{
							list.Add(string.Format("  {0},{1},{2},,{3}", new object[]
							{
								command3.GetAcronym(),
								(int)command3.Easing,
								command3.StartTime,
								WriteHelper.GetCommandArguments(command3)
							}));
						}
						else
						{
							list.Add(string.Format("  {0},{1},{2},{3},{4}", new object[]
							{
								command3.GetAcronym(),
								(int)command3.Easing,
								command3.StartTime,
								command3.EndTime,
								WriteHelper.GetCommandArguments(command3)
							}));
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0600016F RID: 367 RVA: 0x0000BD5C File Offset: 0x00009F5C
		private static string GetCommandArguments(Command command)
		{
			string result;
			switch (command.Type)
			{
			case CommandType.Movement:
			case CommandType.VectorScale:
			{
				bool flag = command.StartVector.Equals(command.EndVector);
				if (flag)
				{
					result = command.StartVector.X.Format() + "," + command.StartVector.Y.Format();
				}
				else
				{
					result = string.Concat(new string[]
					{
						command.StartVector.X.Format(),
						",",
						command.StartVector.Y.Format(),
						",",
						command.EndVector.X.Format(),
						",",
						command.EndVector.Y.Format()
					});
				}
				break;
			}
			case CommandType.MovementX:
			case CommandType.MovementY:
			case CommandType.Fade:
			case CommandType.Scale:
			case CommandType.Rotation:
			{
				bool flag2 = command.StartFloat == command.EndFloat;
				if (flag2)
				{
					result = (command.StartFloat.Format() ?? "");
				}
				else
				{
					result = command.StartFloat.Format() + "," + command.EndFloat.Format();
				}
				break;
			}
			case CommandType.Colour:
			{
				bool flag3 = command.StartColour == command.EndColour;
				if (flag3)
				{
					result = string.Format("{0},{1},{2}", command.StartColour.R, command.StartColour.G, command.StartColour.B);
				}
				else
				{
					result = string.Format("{0},{1},{2},{3},{4},{5}", new object[]
					{
						command.StartColour.R,
						command.StartColour.G,
						command.StartColour.B,
						command.EndColour.R,
						command.EndColour.G,
						command.EndColour.B
					});
				}
				break;
			}
			case CommandType.FlipHorizontal:
				result = "H";
				break;
			case CommandType.FlipVertical:
				result = "V";
				break;
			case CommandType.BlendingMode:
				result = "A";
				break;
			default:
				result = string.Empty;
				break;
			}
			return result;
		}

		// Token: 0x06000170 RID: 368 RVA: 0x0000BFEC File Offset: 0x0000A1EC
		public static List<string> BaseListFormat(string SectionName)
		{
			return new List<string>
			{
				string.Empty,
				"[" + SectionName + "]"
			};
		}

		// Token: 0x0200003D RID: 61
		[CompilerGenerated]
		private sealed class Ac__DisplayClass3_0
		{
			// Token: 0x06000173 RID: 371 RVA: 0x00002A5C File Offset: 0x00000C5C
			internal void ASliderPropertiesb__0(Vector2 pt)
			{
				this.sliderPoints += string.Format("|{0}:{1}", pt.X, pt.Y);
			}

			// Token: 0x04000145 RID: 325
			public string sliderPoints;
		}

		// Token: 0x0200003E RID: 62
		[CompilerGenerated]
		private sealed class Ac__DisplayClass3_1
		{
			// Token: 0x06000175 RID: 373 RVA: 0x00002A8F File Offset: 0x00000C8F
			internal void ASliderPropertiesb__1(HitSoundType sound)
			{
				this.edgeHitsounds += string.Format("{0}|", (int)sound);
			}

			// Token: 0x06000176 RID: 374 RVA: 0x00002AB2 File Offset: 0x00000CB2
			internal void ASliderPropertiesb__2(Tuple<SampleSet, SampleSet> e)
			{
				this.edgeAdditions += string.Format("{0}:{1}|", (int)e.Item1, (int)e.Item2);
			}

			// Token: 0x04000146 RID: 326
			public string edgeHitsounds;

			// Token: 0x04000147 RID: 327
			public string edgeAdditions;
		}
	}
}
