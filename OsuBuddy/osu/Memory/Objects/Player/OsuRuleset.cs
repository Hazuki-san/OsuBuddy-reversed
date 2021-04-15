using System;
using System.Numerics;

namespace osu.Memory.Objects.Player
{
	// Token: 0x02000099 RID: 153
	public class OsuRuleset : OsuObject
	{
		// Token: 0x1700012D RID: 301
		// (get) Token: 0x06000407 RID: 1031 RVA: 0x00011FAC File Offset: 0x000101AC
		// (set) Token: 0x06000408 RID: 1032 RVA: 0x0001205C File Offset: 0x0001025C
		public Vector2 MousePosition
		{
			get
			{
				UIntPtr pointer = (UIntPtr)this.OsuProcess.ReadUInt32(this.BaseAddress + 140);
				bool flag = this.OsuProcess.ReadFloat(this.BaseAddress + 80) == 340f;
				float x = this.OsuProcess.ReadFloat(flag ? (pointer + 76) : (this.BaseAddress + 128));
				float y = this.OsuProcess.ReadFloat(flag ? (pointer + 80) : (this.BaseAddress + 132));
				return new Vector2(x, y);
			}
			set
			{
				UIntPtr pointer = (UIntPtr)this.OsuProcess.ReadUInt32(this.BaseAddress + 140);
				bool flag = this.OsuProcess.ReadFloat(pointer + 80) == 340f;
				bool flag2 = !flag;
				if (!flag2)
				{
					UIntPtr pointer2 = (UIntPtr)this.OsuProcess.ReadUInt32(this.BaseAddress + 164);
					this.OsuProcess.WriteMemory(pointer2 + 8, BitConverter.GetBytes(value.X), 4U);
					this.OsuProcess.WriteMemory(pointer2 + 12, BitConverter.GetBytes(1), 4U);
					this.OsuProcess.WriteMemory(pointer + 76, BitConverter.GetBytes(value.X), 4U);
					this.OsuProcess.WriteMemory(pointer + 80, BitConverter.GetBytes(value.Y), 4U);
				}
			}
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x00011D98 File Offset: 0x0000FF98
		public OsuRuleset() : base(null)
		{
		}
	}
}
