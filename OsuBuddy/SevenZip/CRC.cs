using System;

namespace SevenZip
{
	// Token: 0x02000002 RID: 2
	internal class CRC
	{
		// Token: 0x06000002 RID: 2 RVA: 0x000047FC File Offset: 0x000047FC
		static CRC()
		{
			for (uint num = 0U; num < 256U; num += 1U)
			{
				uint num2 = num;
				for (int i = 0; i < 8; i++)
				{
					bool flag = (num2 & 1U) > 0U;
					if (flag)
					{
						num2 = (num2 >> 1 ^ 3988292384U);
					}
					else
					{
						num2 >>= 1;
					}
				}
				CRC.Table[(int)num] = num2;
			}
		}

		// Token: 0x06000003 RID: 3 RVA: 0x0000206B File Offset: 0x0000206B
		public void Init()
		{
			this._value = uint.MaxValue;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002075 File Offset: 0x00002075
		public void UpdateByte(byte b)
		{
			this._value = (CRC.Table[(int)((byte)this._value ^ b)] ^ this._value >> 8);
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00004868 File Offset: 0x00004868
		public void Update(byte[] data, uint offset, uint size)
		{
			for (uint num = 0U; num < size; num += 1U)
			{
				this._value = (CRC.Table[(int)((byte)this._value ^ data[(int)(offset + num)])] ^ this._value >> 8);
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000048A8 File Offset: 0x000048A8
		public uint GetDigest()
		{
			return this._value ^ uint.MaxValue;
		}

		// Token: 0x04000001 RID: 1
		public static readonly uint[] Table = new uint[256];

		// Token: 0x04000002 RID: 2
		private uint _value = uint.MaxValue;
	}
}
