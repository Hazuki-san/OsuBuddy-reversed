using System;

namespace SevenZip.Compression.LZMA
{
	// Token: 0x02000016 RID: 22
	internal abstract class Base
	{
		// Token: 0x0600006A RID: 106 RVA: 0x000064C0 File Offset: 0x000064C0
		public static uint GetLenToPosState(uint len)
		{
			len -= 2U;
			bool flag = len < 4U;
			uint result;
			if (flag)
			{
				result = len;
			}
			else
			{
				result = 3U;
			}
			return result;
		}

		// Token: 0x04000051 RID: 81
		public const uint kNumRepDistances = 4U;

		// Token: 0x04000052 RID: 82
		public const uint kNumStates = 12U;

		// Token: 0x04000053 RID: 83
		public const int kNumPosSlotBits = 6;

		// Token: 0x04000054 RID: 84
		public const int kDicLogSizeMin = 0;

		// Token: 0x04000055 RID: 85
		public const int kNumLenToPosStatesBits = 2;

		// Token: 0x04000056 RID: 86
		public const uint kNumLenToPosStates = 4U;

		// Token: 0x04000057 RID: 87
		public const uint kMatchMinLen = 2U;

		// Token: 0x04000058 RID: 88
		public const int kNumAlignBits = 4;

		// Token: 0x04000059 RID: 89
		public const uint kAlignTableSize = 16U;

		// Token: 0x0400005A RID: 90
		public const uint kAlignMask = 15U;

		// Token: 0x0400005B RID: 91
		public const uint kStartPosModelIndex = 4U;

		// Token: 0x0400005C RID: 92
		public const uint kEndPosModelIndex = 14U;

		// Token: 0x0400005D RID: 93
		public const uint kNumPosModels = 10U;

		// Token: 0x0400005E RID: 94
		public const uint kNumFullDistances = 128U;

		// Token: 0x0400005F RID: 95
		public const uint kNumLitPosStatesBitsEncodingMax = 4U;

		// Token: 0x04000060 RID: 96
		public const uint kNumLitContextBitsMax = 8U;

		// Token: 0x04000061 RID: 97
		public const int kNumPosStatesBitsMax = 4;

		// Token: 0x04000062 RID: 98
		public const uint kNumPosStatesMax = 16U;

		// Token: 0x04000063 RID: 99
		public const int kNumPosStatesBitsEncodingMax = 4;

		// Token: 0x04000064 RID: 100
		public const uint kNumPosStatesEncodingMax = 16U;

		// Token: 0x04000065 RID: 101
		public const int kNumLowLenBits = 3;

		// Token: 0x04000066 RID: 102
		public const int kNumMidLenBits = 3;

		// Token: 0x04000067 RID: 103
		public const int kNumHighLenBits = 8;

		// Token: 0x04000068 RID: 104
		public const uint kNumLowLenSymbols = 8U;

		// Token: 0x04000069 RID: 105
		public const uint kNumMidLenSymbols = 8U;

		// Token: 0x0400006A RID: 106
		public const uint kNumLenSymbols = 272U;

		// Token: 0x0400006B RID: 107
		public const uint kMatchMaxLen = 273U;

		// Token: 0x02000017 RID: 23
		public struct State
		{
			// Token: 0x0600006C RID: 108 RVA: 0x000022A5 File Offset: 0x000022A5
			public void Init()
			{
				this.Index = 0U;
			}

			// Token: 0x0600006D RID: 109 RVA: 0x000064E4 File Offset: 0x000064E4
			public void UpdateChar()
			{
				bool flag = this.Index < 4U;
				if (flag)
				{
					this.Index = 0U;
				}
				else
				{
					bool flag2 = this.Index < 10U;
					if (flag2)
					{
						this.Index -= 3U;
					}
					else
					{
						this.Index -= 6U;
					}
				}
			}

			// Token: 0x0600006E RID: 110 RVA: 0x000022AF File Offset: 0x000022AF
			public void UpdateMatch()
			{
				this.Index = ((this.Index < 7U) ? 7U : 10U);
			}

			// Token: 0x0600006F RID: 111 RVA: 0x000022C6 File Offset: 0x000022C6
			public void UpdateRep()
			{
				this.Index = ((this.Index < 7U) ? 8U : 11U);
			}

			// Token: 0x06000070 RID: 112 RVA: 0x000022DD File Offset: 0x000022DD
			public void UpdateShortRep()
			{
				this.Index = ((this.Index < 7U) ? 9U : 11U);
			}

			// Token: 0x06000071 RID: 113 RVA: 0x00006534 File Offset: 0x00006534
			public bool IsCharState()
			{
				return this.Index < 7U;
			}

			// Token: 0x0400006C RID: 108
			public uint Index;
		}
	}
}
