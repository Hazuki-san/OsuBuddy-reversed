using System;
using System.Collections.Generic;
using System.IO;
using OsuParsers.Enums.Storyboards;
using OsuParsers.Storyboards.Interfaces;
using OsuParsers.Writers;

namespace OsuParsers.Storyboards
{
	// Token: 0x02000023 RID: 35
	public class Storyboard
	{
		// Token: 0x060000BE RID: 190 RVA: 0x0000A0D4 File Offset: 0x000082D4
		public List<IStoryboardObject> GetLayer(StoryboardLayer layer)
		{
			List<IStoryboardObject> result;
			switch (layer)
			{
			case StoryboardLayer.Background:
				result = this.BackgroundLayer;
				break;
			case StoryboardLayer.Fail:
				result = this.FailLayer;
				break;
			case StoryboardLayer.Pass:
				result = this.PassLayer;
				break;
			case StoryboardLayer.Foreground:
				result = this.ForegroundLayer;
				break;
			case StoryboardLayer.Overlay:
				result = this.OverlayLayer;
				break;
			case StoryboardLayer.Samples:
				result = this.SamplesLayer;
				break;
			default:
				result = this.BackgroundLayer;
				break;
			}
			return result;
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00002468 File Offset: 0x00000668
		public void Save(string path)
		{
			File.WriteAllLines(path, StoryboardEncoder.Encode(this));
		}

		// Token: 0x040000DF RID: 223
		public List<IStoryboardObject> BackgroundLayer = new List<IStoryboardObject>();

		// Token: 0x040000E0 RID: 224
		public List<IStoryboardObject> FailLayer = new List<IStoryboardObject>();

		// Token: 0x040000E1 RID: 225
		public List<IStoryboardObject> PassLayer = new List<IStoryboardObject>();

		// Token: 0x040000E2 RID: 226
		public List<IStoryboardObject> ForegroundLayer = new List<IStoryboardObject>();

		// Token: 0x040000E3 RID: 227
		public List<IStoryboardObject> OverlayLayer = new List<IStoryboardObject>();

		// Token: 0x040000E4 RID: 228
		public List<IStoryboardObject> SamplesLayer = new List<IStoryboardObject>();

		// Token: 0x040000E5 RID: 229
		public Dictionary<string, string> Variables = new Dictionary<string, string>();
	}
}
