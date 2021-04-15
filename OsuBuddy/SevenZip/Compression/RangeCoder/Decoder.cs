using System;
using System.IO;

namespace SevenZip.Compression.RangeCoder
{
	// Token: 0x0200000B RID: 11
	internal class Decoder
	{
		// Token: 0x0600000F RID: 15 RVA: 0x000048C4 File Offset: 0x00002AC4
		public void Init(Stream stream)
		{
			this.Stream = stream;
			this.Code = 0U;
			this.Range = uint.MaxValue;
			for (int i = 0; i < 5; i++)
			{
				this.Code = (this.Code << 8 | (uint)((byte)this.Stream.ReadByte()));
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000020C4 File Offset: 0x000002C4
		public void ReleaseStream()
		{
			this.Stream = null;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000020CE File Offset: 0x000002CE
		public void CloseStream()
		{
			this.Stream.Close();
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00004914 File Offset: 0x00002B14
		public void Normalize()
		{
			while (this.Range < 16777216U)
			{
				this.Code = (this.Code << 8 | (uint)((byte)this.Stream.ReadByte()));
				this.Range <<= 8;
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00004960 File Offset: 0x00002B60
		public void Normalize2()
		{
			bool flag = this.Range < 16777216U;
			if (flag)
			{
				this.Code = (this.Code << 8 | (uint)((byte)this.Stream.ReadByte()));
				this.Range <<= 8;
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000049AC File Offset: 0x00002BAC
		public uint GetThreshold(uint total)
		{
			return this.Code / (this.Range /= total);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000020DD File Offset: 0x000002DD
		public void Decode(uint start, uint size, uint total)
		{
			this.Code -= start * this.Range;
			this.Range *= size;
			this.Normalize();
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000049D8 File Offset: 0x00002BD8
		public uint DecodeDirectBits(int numTotalBits)
		{
			uint num = this.Range;
			uint num2 = this.Code;
			uint num3 = 0U;
			for (int i = numTotalBits; i > 0; i--)
			{
				num >>= 1;
				uint num4 = num2 - num >> 31;
				num2 -= (num & num4 - 1U);
				num3 = (num3 << 1 | 1U - num4);
				bool flag = num < 16777216U;
				if (flag)
				{
					num2 = (num2 << 8 | (uint)((byte)this.Stream.ReadByte()));
					num <<= 8;
				}
			}
			this.Range = num;
			this.Code = num2;
			return num3;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00004A64 File Offset: 0x00002C64
		public uint DecodeBit(uint size0, int numTotalBits)
		{
			uint num = (this.Range >> numTotalBits) * size0;
			bool flag = this.Code < num;
			uint result;
			if (flag)
			{
				result = 0U;
				this.Range = num;
			}
			else
			{
				result = 1U;
				this.Code -= num;
				this.Range -= num;
			}
			this.Normalize();
			return result;
		}

		// Token: 0x04000013 RID: 19
		public const uint kTopValue = 16777216U;

		// Token: 0x04000014 RID: 20
		public uint Range;

		// Token: 0x04000015 RID: 21
		public uint Code;

		// Token: 0x04000016 RID: 22
		public Stream Stream;
	}
}
