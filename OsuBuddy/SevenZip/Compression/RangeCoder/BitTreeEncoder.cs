using System;

namespace SevenZip.Compression.RangeCoder
{
	// Token: 0x0200000F RID: 15
	internal struct BitTreeEncoder
	{
		// Token: 0x0600002F RID: 47 RVA: 0x00002192 File Offset: 0x00000392
		public BitTreeEncoder(int numBitLevels)
		{
			this.NumBitLevels = numBitLevels;
			this.Models = new BitEncoder[1 << numBitLevels];
		}

		// Token: 0x06000030 RID: 48 RVA: 0x0000505C File Offset: 0x0000325C
		public void Init()
		{
			uint num = 1U;
			while ((ulong)num < (ulong)(1L << (this.NumBitLevels & 31)))
			{
				this.Models[(int)num].Init();
				num += 1U;
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00005098 File Offset: 0x00003298
		public void Encode(Encoder rangeEncoder, uint symbol)
		{
			uint num = 1U;
			int i = this.NumBitLevels;
			while (i > 0)
			{
				i--;
				uint num2 = symbol >> i & 1U;
				this.Models[(int)num].Encode(rangeEncoder, num2);
				num = (num << 1 | num2);
			}
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000050E4 File Offset: 0x000032E4
		public void ReverseEncode(Encoder rangeEncoder, uint symbol)
		{
			uint num = 1U;
			uint num2 = 0U;
			while ((ulong)num2 < (ulong)((long)this.NumBitLevels))
			{
				uint num3 = symbol & 1U;
				this.Models[(int)num].Encode(rangeEncoder, num3);
				num = (num << 1 | num3);
				symbol >>= 1;
				num2 += 1U;
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00005130 File Offset: 0x00003330
		public uint GetPrice(uint symbol)
		{
			uint num = 0U;
			uint num2 = 1U;
			int i = this.NumBitLevels;
			while (i > 0)
			{
				i--;
				uint num3 = symbol >> i & 1U;
				num += this.Models[(int)num2].GetPrice(num3);
				num2 = (num2 << 1) + num3;
			}
			return num;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00005188 File Offset: 0x00003388
		public uint ReverseGetPrice(uint symbol)
		{
			uint num = 0U;
			uint num2 = 1U;
			for (int i = this.NumBitLevels; i > 0; i--)
			{
				uint num3 = symbol & 1U;
				symbol >>= 1;
				num += this.Models[(int)num2].GetPrice(num3);
				num2 = (num2 << 1 | num3);
			}
			return num;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000051E0 File Offset: 0x000033E0
		public static uint ReverseGetPrice(BitEncoder[] Models, uint startIndex, int NumBitLevels, uint symbol)
		{
			uint num = 0U;
			uint num2 = 1U;
			for (int i = NumBitLevels; i > 0; i--)
			{
				uint num3 = symbol & 1U;
				symbol >>= 1;
				num += Models[(int)(startIndex + num2)].GetPrice(num3);
				num2 = (num2 << 1 | num3);
			}
			return num;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00005230 File Offset: 0x00003430
		public static void ReverseEncode(BitEncoder[] Models, uint startIndex, Encoder rangeEncoder, int NumBitLevels, uint symbol)
		{
			uint num = 1U;
			for (int i = 0; i < NumBitLevels; i++)
			{
				uint num2 = symbol & 1U;
				Models[(int)(startIndex + num)].Encode(rangeEncoder, num2);
				num = (num << 1 | num2);
				symbol >>= 1;
			}
		}

		// Token: 0x04000029 RID: 41
		private BitEncoder[] Models;

		// Token: 0x0400002A RID: 42
		private int NumBitLevels;
	}
}
