using System;
using System.IO;
using System.Linq;
using System.Text;
using OsuParsers.Enums;
using OsuParsers.Enums.Replays;
using OsuParsers.Helpers;
using OsuParsers.Replays;
using OsuParsers.Replays.Objects;
using OsuParsers.Replays.SevenZip;
using OsuParsers.Serialization;

namespace OsuParsers.Decoders
{
	// Token: 0x02000063 RID: 99
	public static class ReplayDecoder
	{
		// Token: 0x060001C7 RID: 455 RVA: 0x0000F770 File Offset: 0x0000D970
		public static Replay Decode(string path)
		{
			bool flag = File.Exists(path);
			if (flag)
			{
				return ReplayDecoder.Decode(new FileStream(path, FileMode.Open));
			}
			throw new FileNotFoundException();
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x0000F7A0 File Offset: 0x0000D9A0
		public static Replay Decode(Stream stream)
		{
			Replay replay = new Replay();
			using (SerializationReader serializationReader = new SerializationReader(stream))
			{
				replay.Ruleset = (Ruleset)serializationReader.ReadByte();
				replay.OsuVersion = serializationReader.ReadInt32();
				replay.BeatmapMD5Hash = serializationReader.ReadString();
				replay.PlayerName = serializationReader.ReadString();
				replay.ReplayMD5Hash = serializationReader.ReadString();
				replay.Count300 = serializationReader.ReadUInt16();
				replay.Count100 = serializationReader.ReadUInt16();
				replay.Count50 = serializationReader.ReadUInt16();
				replay.CountGeki = serializationReader.ReadUInt16();
				replay.CountKatu = serializationReader.ReadUInt16();
				replay.CountMiss = serializationReader.ReadUInt16();
				replay.ReplayScore = serializationReader.ReadInt32();
				replay.Combo = serializationReader.ReadUInt16();
				replay.PerfectCombo = serializationReader.ReadBoolean();
				replay.Mods = (Mods)serializationReader.ReadInt32();
				string text = serializationReader.ReadString();
				bool flag = !string.IsNullOrEmpty(text);
				if (flag)
				{
					foreach (string text2 in text.Split(new char[]
					{
						','
					}))
					{
						string[] array2 = text2.Split(new char[]
						{
							'|'
						});
						bool flag2 = array2.Length < 2;
						if (!flag2)
						{
							replay.LifeFrames.Add(new LifeFrame
							{
								Time = Convert.ToInt32(array2[0]),
								Percentage = array2[1].ToFloat()
							});
						}
					}
				}
				replay.ReplayTimestamp = serializationReader.ReadDateTime();
				replay.ReplayLength = serializationReader.ReadInt32();
				bool flag3 = replay.ReplayLength > 0;
				if (flag3)
				{
					byte[] inBytes = serializationReader.ReadBytes(replay.ReplayLength);
					byte[] bytes = LZMAHelper.Decompress(inBytes);
					string @string = Encoding.ASCII.GetString(bytes);
					int num = 0;
					foreach (string text3 in @string.Split(new char[]
					{
						','
					}))
					{
						bool flag4 = string.IsNullOrEmpty(text3);
						if (!flag4)
						{
							string[] array4 = text3.Split(new char[]
							{
								'|'
							});
							bool flag5 = array4.Length < 4;
							if (!flag5)
							{
								bool flag6 = array4[0] == "-12345";
								if (flag6)
								{
									replay.Seed = Convert.ToInt32(array4[3]);
								}
								else
								{
									ReplayFrame replayFrame = new ReplayFrame();
									replayFrame.TimeDiff = Convert.ToInt32(array4[0]);
									replayFrame.Time = Convert.ToInt32(array4[0]) + num;
									replayFrame.X = array4[1].ToFloat();
									replayFrame.Y = array4[2].ToFloat();
									switch (replay.Ruleset)
									{
									case Ruleset.Standard:
										replayFrame.StandardKeys = (StandardKeys)Convert.ToInt32(array4[3]);
										break;
									case Ruleset.Taiko:
										replayFrame.TaikoKeys = (TaikoKeys)Convert.ToInt32(array4[3]);
										break;
									case Ruleset.Fruits:
										replayFrame.CatchKeys = (CatchKeys)Convert.ToInt32(array4[3]);
										break;
									case Ruleset.Mania:
										replayFrame.ManiaKeys = (ManiaKeys)replayFrame.X;
										break;
									}
									replay.ReplayFrames.Add(replayFrame);
									num = replay.ReplayFrames.Last<ReplayFrame>().Time;
								}
							}
						}
					}
				}
				bool flag7 = serializationReader.BaseStream.Length - serializationReader.BaseStream.Position > 0L;
				if (flag7)
				{
					bool flag8 = serializationReader.BaseStream.Length - serializationReader.BaseStream.Position == 4L;
					if (flag8)
					{
						replay.OnlineId = (long)serializationReader.ReadInt32();
					}
					else
					{
						replay.OnlineId = serializationReader.ReadInt64();
					}
				}
			}
			return replay;
		}
	}
}
