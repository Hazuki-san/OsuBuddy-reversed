using System;
using System.IO;
using System.Text;
using OsuParsers.Enums;
using OsuParsers.Helpers;
using OsuParsers.Replays;
using OsuParsers.Replays.Objects;
using OsuParsers.Replays.SevenZip;
using OsuParsers.Serialization;

namespace OsuParsers.Encoders
{
	// Token: 0x0200005F RID: 95
	internal class ReplayEncoder
	{
		// Token: 0x060001A8 RID: 424 RVA: 0x0000D678 File Offset: 0x0000D678
		public static void Encode(Replay replay, string path)
		{
			using (SerializationWriter serializationWriter = new SerializationWriter(new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read)))
			{
				serializationWriter.Write((byte)replay.Ruleset);
				serializationWriter.Write(replay.OsuVersion);
				serializationWriter.Write(replay.BeatmapMD5Hash);
				serializationWriter.Write(replay.PlayerName);
				serializationWriter.Write(replay.ReplayMD5Hash);
				serializationWriter.Write(replay.Count300);
				serializationWriter.Write(replay.Count100);
				serializationWriter.Write(replay.Count50);
				serializationWriter.Write(replay.CountGeki);
				serializationWriter.Write(replay.CountKatu);
				serializationWriter.Write(replay.CountMiss);
				serializationWriter.Write(replay.ReplayScore);
				serializationWriter.Write(replay.Combo);
				serializationWriter.Write(replay.PerfectCombo);
				serializationWriter.Write((int)replay.Mods);
				string text = null;
				foreach (LifeFrame lifeFrame in replay.LifeFrames)
				{
					text = string.Concat(new string[]
					{
						text,
						lifeFrame.Time.Format(),
						"|",
						lifeFrame.Percentage.Format(),
						","
					});
				}
				serializationWriter.Write(text);
				serializationWriter.Write(replay.ReplayTimestamp.ToUniversalTime().Ticks);
				bool flag = replay.ReplayFrames.Count == 0;
				if (flag)
				{
					serializationWriter.Write(0);
				}
				else
				{
					string text2 = string.Empty;
					foreach (ReplayFrame replayFrame in replay.ReplayFrames)
					{
						int num = 0;
						switch (replay.Ruleset)
						{
						case Ruleset.Standard:
							num = (int)replayFrame.StandardKeys;
							break;
						case Ruleset.Taiko:
							num = (int)replayFrame.TaikoKeys;
							break;
						case Ruleset.Fruits:
							num = (int)replayFrame.CatchKeys;
							break;
						case Ruleset.Mania:
							num = (int)replayFrame.ManiaKeys;
							break;
						}
						text2 += string.Format("{0}|{1}|{2}|{3},", new object[]
						{
							replayFrame.TimeDiff,
							replayFrame.X.Format(),
							replayFrame.Y.Format(),
							num
						});
					}
					byte[] bytes = Encoding.ASCII.GetBytes(text2);
					using (MemoryStream memoryStream = new MemoryStream())
					{
						memoryStream.Write(bytes, 0, bytes.Length);
						MemoryStream memoryStream2 = LZMAHelper.Compress(memoryStream);
						byte[] array = new byte[memoryStream2.Length];
						memoryStream2.Read(array, 0, array.Length);
						serializationWriter.Write(array.Length);
						serializationWriter.Write(array);
					}
				}
				serializationWriter.Write(replay.OnlineId);
			}
		}
	}
}
