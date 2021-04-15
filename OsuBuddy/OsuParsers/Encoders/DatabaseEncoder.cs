using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using OsuParsers.Database;
using OsuParsers.Database.Objects;
using OsuParsers.Enums;
using OsuParsers.Serialization;

namespace OsuParsers.Encoders
{
	// Token: 0x0200005D RID: 93
	internal class DatabaseEncoder
	{
		// Token: 0x06000199 RID: 409 RVA: 0x0000CCB0 File Offset: 0x0000AEB0
		public static void EncodeOsuDatabase(string path, OsuDatabase db)
		{
			using (SerializationWriter serializationWriter = new SerializationWriter(new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read)))
			{
				serializationWriter.Write(db.OsuVersion);
				serializationWriter.Write(db.FolderCount);
				serializationWriter.Write(db.AccountUnlocked);
				serializationWriter.Write(db.UnlockDate);
				serializationWriter.Write(db.PlayerName);
				serializationWriter.Write(db.BeatmapCount);
				foreach (DbBeatmap dbBeatmap in db.Beatmaps)
				{
					bool flag = db.OsuVersion < 20191106;
					if (flag)
					{
						serializationWriter.Write(dbBeatmap.BytesOfBeatmapEntry);
					}
					serializationWriter.Write(dbBeatmap.Artist);
					serializationWriter.Write(dbBeatmap.ArtistUnicode);
					serializationWriter.Write(dbBeatmap.Title);
					serializationWriter.Write(dbBeatmap.TitleUnicode);
					serializationWriter.Write(dbBeatmap.Creator);
					serializationWriter.Write(dbBeatmap.Difficulty);
					serializationWriter.Write(dbBeatmap.AudioFileName);
					serializationWriter.Write(dbBeatmap.MD5Hash);
					serializationWriter.Write(dbBeatmap.FileName);
					serializationWriter.Write((byte)dbBeatmap.RankedStatus);
					serializationWriter.Write(dbBeatmap.CirclesCount);
					serializationWriter.Write(dbBeatmap.SlidersCount);
					serializationWriter.Write(dbBeatmap.SpinnersCount);
					serializationWriter.Write(dbBeatmap.LastModifiedTime);
					serializationWriter.Write(dbBeatmap.ApproachRate);
					serializationWriter.Write(dbBeatmap.CircleSize);
					serializationWriter.Write(dbBeatmap.HPDrain);
					serializationWriter.Write(dbBeatmap.OverallDifficulty);
					serializationWriter.Write(dbBeatmap.SliderVelocity);
					bool flag2 = db.OsuVersion >= 20140609;
					if (flag2)
					{
						serializationWriter.Write<int, double>(dbBeatmap.StandardStarRating.ToDictionary(new Func<KeyValuePair<Mods, double>, int>(DatabaseEncoder.Ac.A9.AEncodeOsuDatabaseb__0_0), new Func<KeyValuePair<Mods, double>, double>(DatabaseEncoder.Ac.A9.AEncodeOsuDatabaseb__0_1)));
						serializationWriter.Write<int, double>(dbBeatmap.TaikoStarRating.ToDictionary(new Func<KeyValuePair<Mods, double>, int>(DatabaseEncoder.Ac.A9.AEncodeOsuDatabaseb__0_2), new Func<KeyValuePair<Mods, double>, double>(DatabaseEncoder.Ac.A9.AEncodeOsuDatabaseb__0_3)));
						serializationWriter.Write<int, double>(dbBeatmap.CatchStarRating.ToDictionary(new Func<KeyValuePair<Mods, double>, int>(DatabaseEncoder.Ac.A9.AEncodeOsuDatabaseb__0_4), new Func<KeyValuePair<Mods, double>, double>(DatabaseEncoder.Ac.A9.AEncodeOsuDatabaseb__0_5)));
						serializationWriter.Write<int, double>(dbBeatmap.ManiaStarRating.ToDictionary(new Func<KeyValuePair<Mods, double>, int>(DatabaseEncoder.Ac.A9.AEncodeOsuDatabaseb__0_6), new Func<KeyValuePair<Mods, double>, double>(DatabaseEncoder.Ac.A9.AEncodeOsuDatabaseb__0_7)));
					}
					serializationWriter.Write(dbBeatmap.DrainTime);
					serializationWriter.Write(dbBeatmap.TotalTime);
					serializationWriter.Write(dbBeatmap.AudioPreviewTime);
					serializationWriter.Write(dbBeatmap.TimingPoints.Count);
					for (int i = 0; i < dbBeatmap.TimingPoints.Count; i++)
					{
						serializationWriter.Write(dbBeatmap.TimingPoints[i].BPM);
						serializationWriter.Write(dbBeatmap.TimingPoints[i].Offset);
						serializationWriter.Write(dbBeatmap.TimingPoints[i].Inherited);
					}
					serializationWriter.Write(dbBeatmap.BeatmapId);
					serializationWriter.Write(dbBeatmap.BeatmapSetId);
					serializationWriter.Write(dbBeatmap.ThreadId);
					serializationWriter.Write((byte)dbBeatmap.StandardGrade);
					serializationWriter.Write((byte)dbBeatmap.TaikoGrade);
					serializationWriter.Write((byte)dbBeatmap.CatchGrade);
					serializationWriter.Write((byte)dbBeatmap.ManiaGrade);
					serializationWriter.Write(dbBeatmap.LocalOffset);
					serializationWriter.Write(dbBeatmap.StackLeniency);
					serializationWriter.Write((byte)dbBeatmap.Ruleset);
					serializationWriter.Write(dbBeatmap.Source);
					serializationWriter.Write(dbBeatmap.Tags);
					serializationWriter.Write(dbBeatmap.OnlineOffset);
					serializationWriter.Write(dbBeatmap.TitleFont);
					serializationWriter.Write(dbBeatmap.IsUnplayed);
					serializationWriter.Write(dbBeatmap.LastPlayed);
					serializationWriter.Write(dbBeatmap.IsOsz2);
					serializationWriter.Write(dbBeatmap.FolderName);
					serializationWriter.Write(dbBeatmap.LastCheckedAgainstOsuRepo);
					serializationWriter.Write(dbBeatmap.IgnoreBeatmapSound);
					serializationWriter.Write(dbBeatmap.IgnoreBeatmapSkin);
					serializationWriter.Write(dbBeatmap.DisableStoryboard);
					serializationWriter.Write(dbBeatmap.DisableVideo);
					serializationWriter.Write(dbBeatmap.VisualOverride);
					bool flag3 = db.OsuVersion < 20140609;
					if (flag3)
					{
						serializationWriter.Write(0);
					}
					serializationWriter.Write(0);
					serializationWriter.Write(dbBeatmap.ManiaScrollSpeed);
				}
				serializationWriter.Write((int)db.Permissions);
			}
		}

		// Token: 0x0600019A RID: 410 RVA: 0x0000D228 File Offset: 0x0000B428
		public static void EncodeCollectionDatabase(string path, CollectionDatabase db)
		{
			using (SerializationWriter serializationWriter = new SerializationWriter(new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read)))
			{
				serializationWriter.Write(db.OsuVersion);
				serializationWriter.Write(db.CollectionCount);
				foreach (Collection collection in db.Collections)
				{
					serializationWriter.Write(collection.Name);
					serializationWriter.Write(collection.Count);
					foreach (string value in collection.MD5Hashes)
					{
						serializationWriter.Write(value);
					}
				}
			}
		}

		// Token: 0x0600019B RID: 411 RVA: 0x0000D320 File Offset: 0x0000B520
		public static void EncodeScoresDatabase(string path, ScoresDatabase db)
		{
			using (SerializationWriter serializationWriter = new SerializationWriter(new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read)))
			{
				serializationWriter.Write(db.OsuVersion);
				serializationWriter.Write(db.Scores.Count);
				foreach (Tuple<string, List<Score>> tuple in db.Scores)
				{
					serializationWriter.Write(tuple.Item1);
					serializationWriter.Write(tuple.Item2.Count);
					foreach (Score score in tuple.Item2)
					{
						serializationWriter.Write((byte)score.Ruleset);
						serializationWriter.Write(score.OsuVersion);
						serializationWriter.Write(score.BeatmapMD5Hash);
						serializationWriter.Write(score.PlayerName);
						serializationWriter.Write(score.ReplayMD5Hash);
						serializationWriter.Write(score.Count300);
						serializationWriter.Write(score.Count100);
						serializationWriter.Write(score.Count50);
						serializationWriter.Write(score.CountGeki);
						serializationWriter.Write(score.CountKatu);
						serializationWriter.Write(score.CountMiss);
						serializationWriter.Write(score.ReplayScore);
						serializationWriter.Write(score.Combo);
						serializationWriter.Write(score.PerfectCombo);
						serializationWriter.Write((int)score.Mods);
						serializationWriter.Write(string.Empty);
						serializationWriter.Write(score.ScoreTimestamp);
						serializationWriter.Write(-1);
						serializationWriter.Write(score.ScoreId);
					}
				}
			}
		}

		// Token: 0x0600019C RID: 412 RVA: 0x0000D54C File Offset: 0x0000B74C
		public static void EncodePresenceDatabase(string path, PresenceDatabase db)
		{
			using (SerializationWriter serializationWriter = new SerializationWriter(new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read)))
			{
				serializationWriter.Write(db.OsuVersion);
				serializationWriter.Write(db.Players.Count);
				foreach (Player player in db.Players)
				{
					serializationWriter.Write(player.UserId);
					serializationWriter.Write(player.Username);
					serializationWriter.Write((byte)(player.Timezone + 24));
					serializationWriter.Write(player.CountryCode);
					serializationWriter.Write((byte)((int)((byte)player.Permissions & 31) | (int)((byte)player.Ruleset & 7) << 5));
					serializationWriter.Write(player.Longitude);
					serializationWriter.Write(player.Latitude);
					serializationWriter.Write(player.Rank);
					serializationWriter.Write(player.LastUpdateTime);
				}
			}
		}

		// Token: 0x0200005E RID: 94
		[CompilerGenerated]
		[Serializable]
		private sealed class Ac
		{
			// Token: 0x060001A0 RID: 416 RVA: 0x00002C4E File Offset: 0x00000E4E
			internal int AEncodeOsuDatabaseb__0_0(KeyValuePair<Mods, double> d)
			{
				return (int)d.Key;
			}

			// Token: 0x060001A1 RID: 417 RVA: 0x00002C57 File Offset: 0x00000E57
			internal double AEncodeOsuDatabaseb__0_1(KeyValuePair<Mods, double> d)
			{
				return d.Value;
			}

			// Token: 0x060001A2 RID: 418 RVA: 0x00002C4E File Offset: 0x00000E4E
			internal int AEncodeOsuDatabaseb__0_2(KeyValuePair<Mods, double> d)
			{
				return (int)d.Key;
			}

			// Token: 0x060001A3 RID: 419 RVA: 0x00002C57 File Offset: 0x00000E57
			internal double AEncodeOsuDatabaseb__0_3(KeyValuePair<Mods, double> d)
			{
				return d.Value;
			}

			// Token: 0x060001A4 RID: 420 RVA: 0x00002C4E File Offset: 0x00000E4E
			internal int AEncodeOsuDatabaseb__0_4(KeyValuePair<Mods, double> d)
			{
				return (int)d.Key;
			}

			// Token: 0x060001A5 RID: 421 RVA: 0x00002C57 File Offset: 0x00000E57
			internal double AEncodeOsuDatabaseb__0_5(KeyValuePair<Mods, double> d)
			{
				return d.Value;
			}

			// Token: 0x060001A6 RID: 422 RVA: 0x00002C4E File Offset: 0x00000E4E
			internal int AEncodeOsuDatabaseb__0_6(KeyValuePair<Mods, double> d)
			{
				return (int)d.Key;
			}

			// Token: 0x060001A7 RID: 423 RVA: 0x00002C57 File Offset: 0x00000E57
			internal double AEncodeOsuDatabaseb__0_7(KeyValuePair<Mods, double> d)
			{
				return d.Value;
			}

			// Token: 0x0400022F RID: 559
			public static readonly DatabaseEncoder.Ac A9 = new DatabaseEncoder.Ac();

			// Token: 0x04000230 RID: 560
			public static Func<KeyValuePair<Mods, double>, int> A9__0_0;

			// Token: 0x04000231 RID: 561
			public static Func<KeyValuePair<Mods, double>, double> A9__0_1;

			// Token: 0x04000232 RID: 562
			public static Func<KeyValuePair<Mods, double>, int> A9__0_2;

			// Token: 0x04000233 RID: 563
			public static Func<KeyValuePair<Mods, double>, double> A9__0_3;

			// Token: 0x04000234 RID: 564
			public static Func<KeyValuePair<Mods, double>, int> A9__0_4;

			// Token: 0x04000235 RID: 565
			public static Func<KeyValuePair<Mods, double>, double> A9__0_5;

			// Token: 0x04000236 RID: 566
			public static Func<KeyValuePair<Mods, double>, int> A9__0_6;

			// Token: 0x04000237 RID: 567
			public static Func<KeyValuePair<Mods, double>, double> A9__0_7;
		}
	}
}
