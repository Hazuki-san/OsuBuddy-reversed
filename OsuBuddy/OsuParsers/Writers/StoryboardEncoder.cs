using System;
using System.Collections.Generic;
using System.Linq;
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
		// Token: 0x06000177 RID: 375 RVA: 0x0000C028 File Offset: 0x0000C028
		public static List<string> Encode(Storyboard storyboard)
		{
			List<string> list = new List<string>();
			bool flag = storyboard.Variables != null && storyboard.Variables.Any<KeyValuePair<string, string>>();
			if (flag)
			{
				list.Add("[Variables]");
				foreach (KeyValuePair<string, string> keyValuePair in storyboard.Variables)
				{
					list.Add(keyValuePair.Key + "=" + keyValuePair.Value);
				}
				list.Add(string.Empty);
			}
			list.AddRange(new List<string>
			{
				"[Events]",
				"//Background and Video events"
			});
			list.Add("//Storyboard Layer 0 (Background)");
			storyboard.BackgroundLayer.ForEach(delegate(IStoryboardObject sbObject)
			{
				list.AddRange(WriteHelper.StoryboardObject(sbObject, StoryboardLayer.Background));
			});
			list.Add("//Storyboard Layer 1 (Fail)");
			storyboard.FailLayer.ForEach(delegate(IStoryboardObject sbObject)
			{
				list.AddRange(WriteHelper.StoryboardObject(sbObject, StoryboardLayer.Fail));
			});
			list.Add("//Storyboard Layer 2 (Pass)");
			storyboard.PassLayer.ForEach(delegate(IStoryboardObject sbObject)
			{
				list.AddRange(WriteHelper.StoryboardObject(sbObject, StoryboardLayer.Pass));
			});
			list.Add("//Storyboard Layer 3 (Foreground)");
			storyboard.ForegroundLayer.ForEach(delegate(IStoryboardObject sbObject)
			{
				list.AddRange(WriteHelper.StoryboardObject(sbObject, StoryboardLayer.Foreground));
			});
			list.Add("//Storyboard Layer 4 (Overlay)");
			storyboard.OverlayLayer.ForEach(delegate(IStoryboardObject sbObject)
			{
				list.AddRange(WriteHelper.StoryboardObject(sbObject, StoryboardLayer.Overlay));
			});
			list.Add("//Storyboard Sound Samples");
			storyboard.SamplesLayer.ForEach(delegate(IStoryboardObject sbObject)
			{
				list.AddRange(WriteHelper.StoryboardObject(sbObject, (sbObject as StoryboardSample).Layer));
			});
			for (int i = 0; i < list.Count; i++)
			{
				foreach (KeyValuePair<string, string> keyValuePair2 in storyboard.Variables)
				{
					list[i] = list[i].Replace("," + keyValuePair2.Value, "," + keyValuePair2.Key);
				}
			}
			return list;
		}
	}
}
