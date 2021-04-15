using System;
using OsuParsers.Enums.Storyboards;

namespace OsuParsers.Storyboards.Interfaces
{
	// Token: 0x02000027 RID: 39
	public interface ICommand
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x060000CC RID: 204
		// (set) Token: 0x060000CD RID: 205
		CommandType Type { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x060000CE RID: 206
		// (set) Token: 0x060000CF RID: 207
		Easing Easing { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x060000D0 RID: 208
		// (set) Token: 0x060000D1 RID: 209
		int StartTime { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x060000D2 RID: 210
		// (set) Token: 0x060000D3 RID: 211
		int EndTime { get; set; }
	}
}
