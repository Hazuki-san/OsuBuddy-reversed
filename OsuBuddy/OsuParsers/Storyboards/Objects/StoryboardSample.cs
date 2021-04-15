using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using OsuParsers.Enums.Storyboards;
using OsuParsers.Storyboards.Interfaces;

namespace OsuParsers.Storyboards.Objects
{
	// Token: 0x02000025 RID: 37
	public class StoryboardSample : IStoryboardObject
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x060000C5 RID: 197 RVA: 0x00002491 File Offset: 0x00000691
		// (set) Token: 0x060000C6 RID: 198 RVA: 0x00002499 File Offset: 0x00000699
		public string FilePath { get; set; }

		// Token: 0x060000C7 RID: 199 RVA: 0x000024A2 File Offset: 0x000006A2
		public StoryboardSample(StoryboardLayer layer, int time, string filePath, int volume)
		{
			this.Layer = layer;
			this.Time = time;
			this.FilePath = filePath;
			this.Volume = volume;
		}

		// Token: 0x040000EE RID: 238
		public StoryboardLayer Layer;

		// Token: 0x040000EF RID: 239
		public int Time;

		// Token: 0x040000F0 RID: 240
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string AFilePathk__BackingField;

		// Token: 0x040000F1 RID: 241
		public int Volume;
	}
}
