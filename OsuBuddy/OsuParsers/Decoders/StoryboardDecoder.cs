using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using OsuParsers.Enums.Storyboards;
using OsuParsers.Helpers;
using OsuParsers.Storyboards;
using OsuParsers.Storyboards.Commands;
using OsuParsers.Storyboards.Interfaces;
using OsuParsers.Storyboards.Objects;

namespace OsuParsers.Decoders
{
	// Token: 0x02000064 RID: 100
	public static class StoryboardDecoder
	{
		// Token: 0x060001C9 RID: 457 RVA: 0x0000FB7C File Offset: 0x0000FB7C
		public static Storyboard Decode(string path)
		{
			bool flag = File.Exists(path);
			if (flag)
			{
				return StoryboardDecoder.Decode(File.ReadAllLines(path));
			}
			throw new FileNotFoundException();
		}

		// Token: 0x060001CA RID: 458 RVA: 0x0000FBAC File Offset: 0x0000FBAC
		public static Storyboard Decode(IEnumerable<string> lines)
		{
			StoryboardDecoder.storyboard = new Storyboard();
			StoryboardDecoder.lastDrawable = null;
			StoryboardDecoder.commandGroup = null;
			foreach (string text in lines)
			{
				bool flag = !string.IsNullOrWhiteSpace(text) && !text.StartsWith("//") && !text.StartsWith("[");
				if (flag)
				{
					bool flag2 = text.StartsWith("$");
					if (flag2)
					{
						string[] array = text.Split(new char[]
						{
							'='
						});
						bool flag3 = array.Length != 2;
						if (!flag3)
						{
							StoryboardDecoder.storyboard.Variables.Add(array[0], array[1]);
						}
					}
					else
					{
						bool flag4 = !text.StartsWith(" ") && !text.StartsWith("_");
						if (flag4)
						{
							StoryboardDecoder.ParseSbObject(StoryboardDecoder.ParseVariables(text));
						}
						else
						{
							StoryboardDecoder.ParseSbCommand(StoryboardDecoder.ParseVariables(text));
						}
					}
				}
			}
			return StoryboardDecoder.storyboard;
		}

		// Token: 0x060001CB RID: 459 RVA: 0x00002CF5 File Offset: 0x00002CF5
		public static Storyboard Decode(Stream stream)
		{
			return StoryboardDecoder.Decode(stream.ReadAllLines());
		}

		// Token: 0x060001CC RID: 460 RVA: 0x0000FCD8 File Offset: 0x0000FCD8
		private static string ParseVariables(string line)
		{
			bool flag = StoryboardDecoder.storyboard.Variables == null || line.IndexOf('$') < 0;
			string result;
			if (flag)
			{
				result = line;
			}
			else
			{
				foreach (KeyValuePair<string, string> keyValuePair in StoryboardDecoder.storyboard.Variables)
				{
					line = line.Replace(keyValuePair.Key, keyValuePair.Value);
				}
				result = line;
			}
			return result;
		}

		// Token: 0x060001CD RID: 461 RVA: 0x0000FD68 File Offset: 0x0000FD68
		private static void ParseSbObject(string line)
		{
			string[] array = line.Split(new char[]
			{
				','
			});
			EventType eventType;
			bool flag = !Enum.TryParse<EventType>(array[0], out eventType);
			if (!flag)
			{
				StoryboardLayer layer = (StoryboardLayer)Enum.Parse(typeof(StoryboardLayer), array[(eventType == EventType.Sample) ? 2 : 1]);
				switch (eventType)
				{
				case EventType.Sprite:
				{
					Origins origin = (Origins)Enum.Parse(typeof(Origins), array[2]);
					string filePath = array[3].Trim(new char[]
					{
						'"'
					});
					float x = array[4].ToFloat();
					float y = array[5].ToFloat();
					StoryboardDecoder.storyboard.GetLayer(layer).Add(new StoryboardSprite(origin, filePath, x, y));
					StoryboardDecoder.lastDrawable = StoryboardDecoder.storyboard.GetLayer(layer).Last<IStoryboardObject>();
					break;
				}
				case EventType.Sample:
				{
					int time = Convert.ToInt32(array[1]);
					string filePath2 = array[3].Trim(new char[]
					{
						'"'
					});
					int volume = (array.Length > 4) ? Convert.ToInt32(array[4]) : 100;
					StoryboardDecoder.storyboard.SamplesLayer.Add(new StoryboardSample(layer, time, filePath2, volume));
					break;
				}
				case EventType.Animation:
				{
					Origins origin2 = (Origins)Enum.Parse(typeof(Origins), array[2]);
					string filePath3 = array[3].Trim(new char[]
					{
						'"'
					});
					float x2 = array[4].ToFloat();
					float y2 = array[5].ToFloat();
					int frameCount = Convert.ToInt32(array[6]);
					double frameDelay = array[7].ToDouble();
					LoopType loopType = (array.Length > 8) ? ((LoopType)Enum.Parse(typeof(LoopType), array[8])) : LoopType.LoopForever;
					StoryboardDecoder.storyboard.GetLayer(layer).Add(new StoryboardAnimation(origin2, filePath3, x2, y2, frameCount, frameDelay, loopType));
					StoryboardDecoder.lastDrawable = StoryboardDecoder.storyboard.GetLayer(layer).Last<IStoryboardObject>();
					break;
				}
				}
			}
		}

		// Token: 0x060001CE RID: 462 RVA: 0x0000FF64 File Offset: 0x0000FF64
		private static void ParseSbCommand(string line)
		{
			int num = 0;
			while (line.StartsWith(" ") || line.StartsWith("_"))
			{
				num++;
				line = line.Substring(1);
			}
			bool flag = num < 2;
			if (flag)
			{
				bool flag2 = StoryboardDecoder.lastDrawable == null;
				if (flag2)
				{
					return;
				}
				StoryboardDecoder.commandGroup = (StoryboardDecoder.lastDrawable as IHasCommands).Commands;
			}
			string[] array = line.Split(new char[]
			{
				','
			});
			string text = array[0];
			string text2 = text;
			string a = text2;
			if (!(a == "T"))
			{
				if (!(a == "L"))
				{
					bool flag3 = string.IsNullOrEmpty(array[3]);
					if (flag3)
					{
						array[3] = array[2];
					}
					Easing easing = (Easing)Convert.ToInt32(array[1]);
					int startTime = Convert.ToInt32(array[2]);
					int endTime = Convert.ToInt32(array[3]);
					string text3 = text;
					string text4 = text3;
					uint num2 = <PrivateImplementationDetails>.ComputeStringHash(text4);
					if (num2 <= 3322673650U)
					{
						if (num2 <= 736079187U)
						{
							if (num2 != 719301568U)
							{
								if (num2 == 736079187U)
								{
									if (text4 == "MY")
									{
										float num3 = array[4].ToFloat();
										float endValue = (array.Length > 5) ? array[5].ToFloat() : num3;
										StoryboardDecoder.commandGroup.Commands.Add(new Command(CommandType.MovementY, easing, startTime, endTime, num3, endValue));
									}
								}
							}
							else if (text4 == "MX")
							{
								float num4 = array[4].ToFloat();
								float endValue2 = (array.Length > 5) ? array[5].ToFloat() : num4;
								StoryboardDecoder.commandGroup.Commands.Add(new Command(CommandType.MovementX, easing, startTime, endTime, num4, endValue2));
							}
						}
						else if (num2 != 3272340793U)
						{
							if (num2 == 3322673650U)
							{
								if (text4 == "C")
								{
									float num5 = array[4].ToFloat();
									float num6 = array[5].ToFloat();
									float num7 = array[6].ToFloat();
									float num8 = (array.Length > 7) ? array[7].ToFloat() : num5;
									float num9 = (array.Length > 8) ? array[8].ToFloat() : num6;
									float num10 = (array.Length > 9) ? array[9].ToFloat() : num7;
									StoryboardDecoder.commandGroup.Commands.Add(new Command(easing, startTime, endTime, Color.FromArgb(255, (int)num5, (int)num6, (int)num7), Color.FromArgb(255, (int)num8, (int)num9, (int)num10)));
								}
							}
						}
						else if (text4 == "F")
						{
							float num11 = array[4].ToFloat();
							float endValue3 = (array.Length > 5) ? array[5].ToFloat() : num11;
							StoryboardDecoder.commandGroup.Commands.Add(new Command(CommandType.Fade, easing, startTime, endTime, num11, endValue3));
						}
					}
					else if (num2 <= 3540782697U)
					{
						if (num2 != 3356228888U)
						{
							if (num2 == 3540782697U)
							{
								if (text4 == "V")
								{
									float num12 = array[4].ToFloat();
									float num13 = array[5].ToFloat();
									float x = (array.Length > 6) ? array[6].ToFloat() : num12;
									float y = (array.Length > 7) ? array[7].ToFloat() : num13;
									StoryboardDecoder.commandGroup.Commands.Add(new Command(CommandType.VectorScale, easing, startTime, endTime, new Vector2(num12, num13), new Vector2(x, y)));
								}
							}
						}
						else if (text4 == "M")
						{
							float num14 = array[4].ToFloat();
							float num15 = array[5].ToFloat();
							float x2 = (array.Length > 6) ? array[6].ToFloat() : num14;
							float y2 = (array.Length > 7) ? array[7].ToFloat() : num15;
							StoryboardDecoder.commandGroup.Commands.Add(new Command(CommandType.Movement, easing, startTime, endTime, new Vector2(num14, num15), new Vector2(x2, y2)));
						}
					}
					else if (num2 != 3574337935U)
					{
						if (num2 != 3591115554U)
						{
							if (num2 == 3607893173U)
							{
								if (text4 == "R")
								{
									float num16 = array[4].ToFloat();
									float endValue4 = (array.Length > 5) ? array[5].ToFloat() : num16;
									StoryboardDecoder.commandGroup.Commands.Add(new Command(CommandType.Rotation, easing, startTime, endTime, num16, endValue4));
								}
							}
						}
						else if (text4 == "S")
						{
							float num17 = array[4].ToFloat();
							float endValue5 = (array.Length > 5) ? array[5].ToFloat() : num17;
							StoryboardDecoder.commandGroup.Commands.Add(new Command(CommandType.Scale, easing, startTime, endTime, num17, endValue5));
						}
					}
					else if (text4 == "P")
					{
						string text5 = array[4];
						string text6 = text5;
						string a2 = text6;
						if (!(a2 == "H"))
						{
							if (!(a2 == "V"))
							{
								if (a2 == "A")
								{
									StoryboardDecoder.commandGroup.Commands.Add(new Command(CommandType.BlendingMode, easing, startTime, endTime));
								}
							}
							else
							{
								StoryboardDecoder.commandGroup.Commands.Add(new Command(CommandType.FlipVertical, easing, startTime, endTime));
							}
						}
						else
						{
							StoryboardDecoder.commandGroup.Commands.Add(new Command(CommandType.FlipHorizontal, easing, startTime, endTime));
						}
					}
				}
				else
				{
					int startTime2 = Convert.ToInt32(array[1]);
					int loopCount = Convert.ToInt32(array[2]);
					StoryboardDecoder.commandGroup = StoryboardDecoder.commandGroup.AddLoop(startTime2, loopCount).Commands;
				}
			}
			else
			{
				string triggerName = array[1];
				int startTime3 = (array.Length > 2) ? Convert.ToInt32(array[2]) : 0;
				int endTime2 = (array.Length > 3) ? Convert.ToInt32(array[3]) : 0;
				int groupNumber = (array.Length > 4) ? Convert.ToInt32(array[4]) : 0;
				StoryboardDecoder.commandGroup = StoryboardDecoder.commandGroup.AddTrigger(triggerName, startTime3, endTime2, groupNumber).Commands;
			}
		}

		// Token: 0x04000241 RID: 577
		private static Storyboard storyboard;

		// Token: 0x04000242 RID: 578
		private static IStoryboardObject lastDrawable;

		// Token: 0x04000243 RID: 579
		private static CommandGroup commandGroup;
	}
}
