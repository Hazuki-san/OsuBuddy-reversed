using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using OsuParsers.Enums.Storyboards;
using OsuParsers.Storyboards.Commands;
using OsuParsers.Storyboards.Interfaces;

namespace OsuParsers.Storyboards.Objects
{
	// Token: 0x02000026 RID: 38
	public class StoryboardSprite : IHasCommands, IStoryboardObject
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x060000C8 RID: 200 RVA: 0x000024CA File Offset: 0x000006CA
		public CommandGroup Commands { get; } = new CommandGroup();

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x000024D2 File Offset: 0x000006D2
		// (set) Token: 0x060000CA RID: 202 RVA: 0x000024DA File Offset: 0x000006DA
		public string FilePath { get; set; }

		// Token: 0x060000CB RID: 203 RVA: 0x000024E3 File Offset: 0x000006E3
		public StoryboardSprite(Origins origin, string filePath, float x, float y)
		{
			this.Origin = origin;
			this.FilePath = filePath;
			this.X = x;
			this.Y = y;
		}

		// Token: 0x040000F2 RID: 242
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly CommandGroup ACommandsk__BackingField;

		// Token: 0x040000F3 RID: 243
		public Origins Origin;

		// Token: 0x040000F4 RID: 244
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string AFilePathk__BackingField;

		// Token: 0x040000F5 RID: 245
		public float X;

		// Token: 0x040000F6 RID: 246
		public float Y;
	}
}
