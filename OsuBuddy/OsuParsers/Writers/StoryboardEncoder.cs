using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using OsuParsers.Enums.Storyboards;
using OsuParsers.Helpers;
using OsuParsers.Storyboards;
using OsuParsers.Storyboards.Interfaces;
using OsuParsers.Storyboards.Objects;

namespace OsuParsers.Writers
{
	// Token: 0x02000057 RID: 87
	internal class StoryboardEncoder
	{
		// Token: 0x06000177 RID: 375 RVA: 0x0000C028 File Offset: 0x0000A228
		public static List<string> Encode(Storyboard storyboard)
		{
			StoryboardEncoder.Ac__DisplayClass0_0 ac__DisplayClass0_ = new StoryboardEncoder.Ac__DisplayClass0_0();
			ac__DisplayClass0_.list = new List<string>();
			bool flag = storyboard.Variables != null && storyboard.Variables.Any<KeyValuePair<string, string>>();
			if (flag)
			{
				ac__DisplayClass0_.list.Add("[Variables]");
				foreach (KeyValuePair<string, string> keyValuePair in storyboard.Variables)
				{
					ac__DisplayClass0_.list.Add(keyValuePair.Key + "=" + keyValuePair.Value);
				}
				ac__DisplayClass0_.list.Add(string.Empty);
			}
			ac__DisplayClass0_.list.AddRange(new List<string>
			{
				"[Events]",
				"//Background and Video events"
			});
			ac__DisplayClass0_.list.Add("//Storyboard Layer 0 (Background)");
			storyboard.BackgroundLayer.ForEach(new Action<IStoryboardObject>(ac__DisplayClass0_.AEncodeb__0));
			ac__DisplayClass0_.list.Add("//Storyboard Layer 1 (Fail)");
			storyboard.FailLayer.ForEach(new Action<IStoryboardObject>(ac__DisplayClass0_.AEncodeb__1));
			ac__DisplayClass0_.list.Add("//Storyboard Layer 2 (Pass)");
			storyboard.PassLayer.ForEach(new Action<IStoryboardObject>(ac__DisplayClass0_.AEncodeb__2));
			ac__DisplayClass0_.list.Add("//Storyboard Layer 3 (Foreground)");
			storyboard.ForegroundLayer.ForEach(new Action<IStoryboardObject>(ac__DisplayClass0_.AEncodeb__3));
			ac__DisplayClass0_.list.Add("//Storyboard Layer 4 (Overlay)");
			storyboard.OverlayLayer.ForEach(new Action<IStoryboardObject>(ac__DisplayClass0_.AEncodeb__4));
			ac__DisplayClass0_.list.Add("//Storyboard Sound Samples");
			storyboard.SamplesLayer.ForEach(new Action<IStoryboardObject>(ac__DisplayClass0_.AEncodeb__5));
			for (int i = 0; i < ac__DisplayClass0_.list.Count; i++)
			{
				foreach (KeyValuePair<string, string> keyValuePair2 in storyboard.Variables)
				{
					ac__DisplayClass0_.list[i] = ac__DisplayClass0_.list[i].Replace("," + keyValuePair2.Value, "," + keyValuePair2.Key);
				}
			}
			return ac__DisplayClass0_.list;
		}

		// Token: 0x02000058 RID: 88
		[CompilerGenerated]
		private sealed class Ac__DisplayClass0_0
		{
			// Token: 0x0600017A RID: 378 RVA: 0x00002AE5 File Offset: 0x00000CE5
			internal void AEncodeb__0(IStoryboardObject sbObject)
			{
				this.list.AddRange(WriteHelper.StoryboardObject(sbObject, StoryboardLayer.Background));
			}

			// Token: 0x0600017B RID: 379 RVA: 0x00002AFA File Offset: 0x00000CFA
			internal void AEncodeb__1(IStoryboardObject sbObject)
			{
				this.list.AddRange(WriteHelper.StoryboardObject(sbObject, StoryboardLayer.Fail));
			}

			// Token: 0x0600017C RID: 380 RVA: 0x00002B0F File Offset: 0x00000D0F
			internal void AEncodeb__2(IStoryboardObject sbObject)
			{
				this.list.AddRange(WriteHelper.StoryboardObject(sbObject, StoryboardLayer.Pass));
			}

			// Token: 0x0600017D RID: 381 RVA: 0x00002B24 File Offset: 0x00000D24
			internal void AEncodeb__3(IStoryboardObject sbObject)
			{
				this.list.AddRange(WriteHelper.StoryboardObject(sbObject, StoryboardLayer.Foreground));
			}

			// Token: 0x0600017E RID: 382 RVA: 0x00002B39 File Offset: 0x00000D39
			internal void AEncodeb__4(IStoryboardObject sbObject)
			{
				this.list.AddRange(WriteHelper.StoryboardObject(sbObject, StoryboardLayer.Overlay));
			}

			// Token: 0x0600017F RID: 383 RVA: 0x00002B4E File Offset: 0x00000D4E
			internal void AEncodeb__5(IStoryboardObject sbObject)
			{
				this.list.AddRange(WriteHelper.StoryboardObject(sbObject, (sbObject as StoryboardSample).Layer));
			}

			// Token: 0x04000227 RID: 551
			public List<string> list;
		}
	}
}
