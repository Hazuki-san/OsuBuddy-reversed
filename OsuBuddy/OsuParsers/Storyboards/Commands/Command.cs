using System;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;
using OsuParsers.Enums.Storyboards;
using OsuParsers.Storyboards.Interfaces;

namespace OsuParsers.Storyboards.Commands
{
	// Token: 0x0200002A RID: 42
	public class Command : ICommand
	{
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x060000D6 RID: 214 RVA: 0x00002516 File Offset: 0x00000716
		// (set) Token: 0x060000D7 RID: 215 RVA: 0x0000251E File Offset: 0x0000071E
		public CommandType Type { get; set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x060000D8 RID: 216 RVA: 0x00002527 File Offset: 0x00000727
		// (set) Token: 0x060000D9 RID: 217 RVA: 0x0000252F File Offset: 0x0000072F
		public Easing Easing { get; set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x060000DA RID: 218 RVA: 0x00002538 File Offset: 0x00000738
		// (set) Token: 0x060000DB RID: 219 RVA: 0x00002540 File Offset: 0x00000740
		public int StartTime { get; set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x060000DC RID: 220 RVA: 0x00002549 File Offset: 0x00000749
		// (set) Token: 0x060000DD RID: 221 RVA: 0x00002551 File Offset: 0x00000751
		public int EndTime { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x060000DE RID: 222 RVA: 0x0000255A File Offset: 0x0000075A
		// (set) Token: 0x060000DF RID: 223 RVA: 0x00002562 File Offset: 0x00000762
		public Color StartColour { get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x0000256B File Offset: 0x0000076B
		// (set) Token: 0x060000E1 RID: 225 RVA: 0x00002573 File Offset: 0x00000773
		public Color EndColour { get; set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060000E2 RID: 226 RVA: 0x0000257C File Offset: 0x0000077C
		// (set) Token: 0x060000E3 RID: 227 RVA: 0x00002584 File Offset: 0x00000784
		public Vector2 StartVector { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060000E4 RID: 228 RVA: 0x0000258D File Offset: 0x0000078D
		// (set) Token: 0x060000E5 RID: 229 RVA: 0x00002595 File Offset: 0x00000795
		public Vector2 EndVector { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060000E6 RID: 230 RVA: 0x0000259E File Offset: 0x0000079E
		// (set) Token: 0x060000E7 RID: 231 RVA: 0x000025A6 File Offset: 0x000007A6
		public float StartFloat { get; set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060000E8 RID: 232 RVA: 0x000025AF File Offset: 0x000007AF
		// (set) Token: 0x060000E9 RID: 233 RVA: 0x000025B7 File Offset: 0x000007B7
		public float EndFloat { get; set; }

		// Token: 0x060000EA RID: 234 RVA: 0x000025C0 File Offset: 0x000007C0
		public Command(CommandType type, Easing easing, int startTime, int endTime, float startValue, float endValue)
		{
			this.Type = type;
			this.Easing = easing;
			this.StartTime = startTime;
			this.EndTime = endTime;
			this.StartFloat = startValue;
			this.EndFloat = endValue;
		}

		// Token: 0x060000EB RID: 235 RVA: 0x000025FD File Offset: 0x000007FD
		public Command(CommandType type, Easing easing, int startTime, int endTime, Vector2 startValue, Vector2 endValue)
		{
			this.Type = type;
			this.Easing = easing;
			this.StartTime = startTime;
			this.EndTime = endTime;
			this.StartVector = startValue;
			this.EndVector = endValue;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x0000263A File Offset: 0x0000083A
		public Command(Easing easing, int startTime, int endTime, Color startValue, Color endValue)
		{
			this.Type = CommandType.Colour;
			this.Easing = easing;
			this.StartTime = startTime;
			this.EndTime = endTime;
			this.StartColour = startValue;
			this.EndColour = endValue;
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00002676 File Offset: 0x00000876
		public Command(CommandType type, Easing easing, int startTime, int endTime)
		{
			this.Type = type;
			this.Easing = easing;
			this.StartTime = startTime;
			this.EndTime = endTime;
		}

		// Token: 0x060000EE RID: 238 RVA: 0x0000A204 File Offset: 0x00008404
		public string GetAcronym()
		{
			CommandType type = this.Type;
			CommandType commandType = type;
			switch (commandType)
			{
			case CommandType.None:
				return "None";
			case CommandType.Movement:
				break;
			case CommandType.MovementX:
				return "MX";
			case CommandType.MovementY:
				return "MY";
			default:
				if (commandType - CommandType.FlipHorizontal <= 2)
				{
					return "P";
				}
				break;
			}
			return this.Type.ToString().Substring(0, 1);
		}

		// Token: 0x040000F7 RID: 247
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private CommandType ATypek__BackingField;

		// Token: 0x040000F8 RID: 248
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Easing AEasingk__BackingField;

		// Token: 0x040000F9 RID: 249
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int AStartTimek__BackingField;

		// Token: 0x040000FA RID: 250
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int AEndTimek__BackingField;

		// Token: 0x040000FB RID: 251
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Color AStartColourk__BackingField;

		// Token: 0x040000FC RID: 252
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Color AEndColourk__BackingField;

		// Token: 0x040000FD RID: 253
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Vector2 AStartVectork__BackingField;

		// Token: 0x040000FE RID: 254
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Vector2 AEndVectork__BackingField;

		// Token: 0x040000FF RID: 255
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float AStartFloatk__BackingField;

		// Token: 0x04000100 RID: 256
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float AEndFloatk__BackingField;
	}
}
