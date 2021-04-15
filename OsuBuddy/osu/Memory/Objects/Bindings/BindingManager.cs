using System;
using System.Collections.Generic;

namespace osu.Memory.Objects.Bindings
{
	// Token: 0x0200009F RID: 159
	public class BindingManager : OsuObject
	{
		// Token: 0x17000143 RID: 323
		// (get) Token: 0x0600043B RID: 1083 RVA: 0x00012374 File Offset: 0x00012374
		public Dictionary<Bindings, int> BindingDictionary
		{
			get
			{
				Dictionary<Bindings, int> dictionary = new Dictionary<Bindings, int>();
				UIntPtr pointer = (UIntPtr)this.OsuProcess.ReadUInt32(this.BaseAddress + 8);
				int num = this.OsuProcess.ReadInt32(this.BaseAddress + 28);
				for (int i = 0; i < num; i++)
				{
					UIntPtr uintPtr = pointer + 8 + 8 * i;
					Bindings key = (Bindings)this.OsuProcess.ReadInt32(uintPtr);
					int value = this.OsuProcess.ReadInt32(uintPtr + 4);
					dictionary[key] = value;
				}
				return dictionary;
			}
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x0001241C File Offset: 0x0001241C
		public int GetKeyCode(Bindings binding)
		{
			int num;
			bool flag = !this.BindingDictionary.TryGetValue(binding, out num);
			int result;
			if (flag)
			{
				result = int.MinValue;
			}
			else
			{
				result = num;
			}
			return result;
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x0000401C File Offset: 0x0000401C
		public BindingManager(UIntPtr pointerToBaseAddress) : base(new UIntPtr?(pointerToBaseAddress))
		{
		}
	}
}
