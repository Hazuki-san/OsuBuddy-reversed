using System;
using System.IO;
using SevenZip.Compression.LZ;
using SevenZip.Compression.RangeCoder;

namespace SevenZip.Compression.LZMA
{
	// Token: 0x02000018 RID: 24
	internal class Decoder : ICoder, ISetDecoderProperties
	{
		// Token: 0x06000072 RID: 114 RVA: 0x00006550 File Offset: 0x00006550
		public Decoder()
		{
			this.m_DictionarySize = uint.MaxValue;
			int num = 0;
			while ((long)num < 4L)
			{
				this.m_PosSlotDecoder[num] = new BitTreeDecoder(6);
				num++;
			}
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00006648 File Offset: 0x00006648
		private void SetDictionarySize(uint dictionarySize)
		{
			bool flag = this.m_DictionarySize != dictionarySize;
			if (flag)
			{
				this.m_DictionarySize = dictionarySize;
				this.m_DictionarySizeCheck = Math.Max(this.m_DictionarySize, 1U);
				uint windowSize = Math.Max(this.m_DictionarySizeCheck, 4096U);
				this.m_OutWindow.Create(windowSize);
			}
		}

		// Token: 0x06000074 RID: 116 RVA: 0x000066A0 File Offset: 0x000066A0
		private void SetLiteralProperties(int lp, int lc)
		{
			bool flag = lp > 8;
			if (flag)
			{
				throw new InvalidParamException();
			}
			bool flag2 = lc > 8;
			if (flag2)
			{
				throw new InvalidParamException();
			}
			this.m_LiteralDecoder.Create(lp, lc);
		}

		// Token: 0x06000075 RID: 117 RVA: 0x000066D8 File Offset: 0x000066D8
		private void SetPosBitsProperties(int pb)
		{
			bool flag = pb > 4;
			if (flag)
			{
				throw new InvalidParamException();
			}
			uint num = 1U << pb;
			this.m_LenDecoder.Create(num);
			this.m_RepLenDecoder.Create(num);
			this.m_PosStateMask = num - 1U;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00006720 File Offset: 0x00006720
		private void Init(Stream inStream, Stream outStream)
		{
			this.m_RangeDecoder.Init(inStream);
			this.m_OutWindow.Init(outStream, this._solid);
			for (uint num = 0U; num < 12U; num += 1U)
			{
				for (uint num2 = 0U; num2 <= this.m_PosStateMask; num2 += 1U)
				{
					uint num3 = (num << 4) + num2;
					this.m_IsMatchDecoders[(int)num3].Init();
					this.m_IsRep0LongDecoders[(int)num3].Init();
				}
				this.m_IsRepDecoders[(int)num].Init();
				this.m_IsRepG0Decoders[(int)num].Init();
				this.m_IsRepG1Decoders[(int)num].Init();
				this.m_IsRepG2Decoders[(int)num].Init();
			}
			this.m_LiteralDecoder.Init();
			for (uint num = 0U; num < 4U; num += 1U)
			{
				this.m_PosSlotDecoder[(int)num].Init();
			}
			for (uint num = 0U; num < 114U; num += 1U)
			{
				this.m_PosDecoders[(int)num].Init();
			}
			this.m_LenDecoder.Init();
			this.m_RepLenDecoder.Init();
			this.m_PosAlignDecoder.Init();
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00006870 File Offset: 0x00006870
		public void Code(Stream inStream, Stream outStream, long inSize, long outSize, ICodeProgress progress)
		{
			this.Init(inStream, outStream);
			Base.State state = default(Base.State);
			state.Init();
			uint num = 0U;
			uint num2 = 0U;
			uint num3 = 0U;
			uint num4 = 0U;
			ulong num5 = 0UL;
			bool flag = num5 < (ulong)outSize;
			if (flag)
			{
				bool flag2 = this.m_IsMatchDecoders[(int)((int)state.Index << 4)].Decode(this.m_RangeDecoder) > 0U;
				if (flag2)
				{
					throw new DataErrorException();
				}
				state.UpdateChar();
				byte b = this.m_LiteralDecoder.DecodeNormal(this.m_RangeDecoder, 0U, 0);
				this.m_OutWindow.PutByte(b);
				num5 += 1UL;
			}
			while (num5 < (ulong)outSize)
			{
				uint num6 = (uint)num5 & this.m_PosStateMask;
				bool flag3 = this.m_IsMatchDecoders[(int)((state.Index << 4) + num6)].Decode(this.m_RangeDecoder) == 0U;
				if (flag3)
				{
					byte @byte = this.m_OutWindow.GetByte(0U);
					bool flag4 = !state.IsCharState();
					byte b2;
					if (flag4)
					{
						b2 = this.m_LiteralDecoder.DecodeWithMatchByte(this.m_RangeDecoder, (uint)num5, @byte, this.m_OutWindow.GetByte(num));
					}
					else
					{
						b2 = this.m_LiteralDecoder.DecodeNormal(this.m_RangeDecoder, (uint)num5, @byte);
					}
					this.m_OutWindow.PutByte(b2);
					state.UpdateChar();
					num5 += 1UL;
				}
				else
				{
					bool flag5 = this.m_IsRepDecoders[(int)state.Index].Decode(this.m_RangeDecoder) == 1U;
					uint num8;
					if (flag5)
					{
						bool flag6 = this.m_IsRepG0Decoders[(int)state.Index].Decode(this.m_RangeDecoder) == 0U;
						if (flag6)
						{
							bool flag7 = this.m_IsRep0LongDecoders[(int)((state.Index << 4) + num6)].Decode(this.m_RangeDecoder) == 0U;
							if (flag7)
							{
								state.UpdateShortRep();
								this.m_OutWindow.PutByte(this.m_OutWindow.GetByte(num));
								num5 += 1UL;
								continue;
							}
						}
						else
						{
							bool flag8 = this.m_IsRepG1Decoders[(int)state.Index].Decode(this.m_RangeDecoder) == 0U;
							uint num7;
							if (flag8)
							{
								num7 = num2;
							}
							else
							{
								bool flag9 = this.m_IsRepG2Decoders[(int)state.Index].Decode(this.m_RangeDecoder) == 0U;
								if (flag9)
								{
									num7 = num3;
								}
								else
								{
									num7 = num4;
									num4 = num3;
								}
								num3 = num2;
							}
							num2 = num;
							num = num7;
						}
						num8 = this.m_RepLenDecoder.Decode(this.m_RangeDecoder, num6) + 2U;
						state.UpdateRep();
					}
					else
					{
						num4 = num3;
						num3 = num2;
						num2 = num;
						num8 = 2U + this.m_LenDecoder.Decode(this.m_RangeDecoder, num6);
						state.UpdateMatch();
						uint num9 = this.m_PosSlotDecoder[(int)Base.GetLenToPosState(num8)].Decode(this.m_RangeDecoder);
						bool flag10 = num9 >= 4U;
						if (flag10)
						{
							int num10 = (int)((num9 >> 1) - 1U);
							num = (2U | (num9 & 1U)) << num10;
							bool flag11 = num9 < 14U;
							if (flag11)
							{
								num += BitTreeDecoder.ReverseDecode(this.m_PosDecoders, num - num9 - 1U, this.m_RangeDecoder, num10);
							}
							else
							{
								num += this.m_RangeDecoder.DecodeDirectBits(num10 - 4) << 4;
								num += this.m_PosAlignDecoder.ReverseDecode(this.m_RangeDecoder);
							}
						}
						else
						{
							num = num9;
						}
					}
					bool flag12 = (ulong)num >= (ulong)this.m_OutWindow.TrainSize + num5 || num >= this.m_DictionarySizeCheck;
					if (flag12)
					{
						bool flag13 = num == uint.MaxValue;
						if (flag13)
						{
							break;
						}
						throw new DataErrorException();
					}
					else
					{
						this.m_OutWindow.CopyBlock(num, num8);
						num5 += (ulong)num8;
					}
				}
			}
			this.m_OutWindow.Flush();
			this.m_OutWindow.ReleaseStream();
			this.m_RangeDecoder.ReleaseStream();
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00006C5C File Offset: 0x00006C5C
		public void SetDecoderProperties(byte[] properties)
		{
			bool flag = properties.Length < 5;
			if (flag)
			{
				throw new InvalidParamException();
			}
			int lc = (int)(properties[0] % 9);
			int num = (int)(properties[0] / 9);
			int lp = num % 5;
			int num2 = num / 5;
			bool flag2 = num2 > 4;
			if (flag2)
			{
				throw new InvalidParamException();
			}
			uint num3 = 0U;
			for (int i = 0; i < 4; i++)
			{
				num3 += (uint)((uint)properties[1 + i] << i * 8);
			}
			this.SetDictionarySize(num3);
			this.SetLiteralProperties(lp, lc);
			this.SetPosBitsProperties(num2);
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00006CE8 File Offset: 0x00006CE8
		public bool Train(Stream stream)
		{
			this._solid = true;
			return this.m_OutWindow.Train(stream);
		}

		// Token: 0x0400006D RID: 109
		private OutWindow m_OutWindow = new OutWindow();

		// Token: 0x0400006E RID: 110
		private Decoder m_RangeDecoder = new Decoder();

		// Token: 0x0400006F RID: 111
		private BitDecoder[] m_IsMatchDecoders = new BitDecoder[192];

		// Token: 0x04000070 RID: 112
		private BitDecoder[] m_IsRepDecoders = new BitDecoder[12];

		// Token: 0x04000071 RID: 113
		private BitDecoder[] m_IsRepG0Decoders = new BitDecoder[12];

		// Token: 0x04000072 RID: 114
		private BitDecoder[] m_IsRepG1Decoders = new BitDecoder[12];

		// Token: 0x04000073 RID: 115
		private BitDecoder[] m_IsRepG2Decoders = new BitDecoder[12];

		// Token: 0x04000074 RID: 116
		private BitDecoder[] m_IsRep0LongDecoders = new BitDecoder[192];

		// Token: 0x04000075 RID: 117
		private BitTreeDecoder[] m_PosSlotDecoder = new BitTreeDecoder[4];

		// Token: 0x04000076 RID: 118
		private BitDecoder[] m_PosDecoders = new BitDecoder[114];

		// Token: 0x04000077 RID: 119
		private BitTreeDecoder m_PosAlignDecoder = new BitTreeDecoder(4);

		// Token: 0x04000078 RID: 120
		private Decoder.LenDecoder m_LenDecoder = new Decoder.LenDecoder();

		// Token: 0x04000079 RID: 121
		private Decoder.LenDecoder m_RepLenDecoder = new Decoder.LenDecoder();

		// Token: 0x0400007A RID: 122
		private Decoder.LiteralDecoder m_LiteralDecoder = new Decoder.LiteralDecoder();

		// Token: 0x0400007B RID: 123
		private uint m_DictionarySize;

		// Token: 0x0400007C RID: 124
		private uint m_DictionarySizeCheck;

		// Token: 0x0400007D RID: 125
		private uint m_PosStateMask;

		// Token: 0x0400007E RID: 126
		private bool _solid = false;

		// Token: 0x02000019 RID: 25
		internal class LenDecoder
		{
			// Token: 0x0600007A RID: 122 RVA: 0x00006D10 File Offset: 0x00006D10
			public void Create(uint numPosStates)
			{
				for (uint num = this.m_NumPosStates; num < numPosStates; num += 1U)
				{
					this.m_LowCoder[(int)num] = new BitTreeDecoder(3);
					this.m_MidCoder[(int)num] = new BitTreeDecoder(3);
				}
				this.m_NumPosStates = numPosStates;
			}

			// Token: 0x0600007B RID: 123 RVA: 0x00006D60 File Offset: 0x00006D60
			public void Init()
			{
				this.m_Choice.Init();
				for (uint num = 0U; num < this.m_NumPosStates; num += 1U)
				{
					this.m_LowCoder[(int)num].Init();
					this.m_MidCoder[(int)num].Init();
				}
				this.m_Choice2.Init();
				this.m_HighCoder.Init();
			}

			// Token: 0x0600007C RID: 124 RVA: 0x00006DD0 File Offset: 0x00006DD0
			public uint Decode(Decoder rangeDecoder, uint posState)
			{
				bool flag = this.m_Choice.Decode(rangeDecoder) == 0U;
				uint result;
				if (flag)
				{
					result = this.m_LowCoder[(int)posState].Decode(rangeDecoder);
				}
				else
				{
					uint num = 8U;
					bool flag2 = this.m_Choice2.Decode(rangeDecoder) == 0U;
					if (flag2)
					{
						num += this.m_MidCoder[(int)posState].Decode(rangeDecoder);
					}
					else
					{
						num += 8U;
						num += this.m_HighCoder.Decode(rangeDecoder);
					}
					result = num;
				}
				return result;
			}

			// Token: 0x0400007F RID: 127
			private BitDecoder m_Choice = default(BitDecoder);

			// Token: 0x04000080 RID: 128
			private BitDecoder m_Choice2 = default(BitDecoder);

			// Token: 0x04000081 RID: 129
			private BitTreeDecoder[] m_LowCoder = new BitTreeDecoder[16];

			// Token: 0x04000082 RID: 130
			private BitTreeDecoder[] m_MidCoder = new BitTreeDecoder[16];

			// Token: 0x04000083 RID: 131
			private BitTreeDecoder m_HighCoder = new BitTreeDecoder(8);

			// Token: 0x04000084 RID: 132
			private uint m_NumPosStates = 0U;
		}

		// Token: 0x0200001A RID: 26
		internal class LiteralDecoder
		{
			// Token: 0x0600007E RID: 126 RVA: 0x00006EAC File Offset: 0x00006EAC
			public void Create(int numPosBits, int numPrevBits)
			{
				bool flag = this.m_Coders != null && this.m_NumPrevBits == numPrevBits && this.m_NumPosBits == numPosBits;
				if (!flag)
				{
					this.m_NumPosBits = numPosBits;
					this.m_PosMask = (1U << numPosBits) - 1U;
					this.m_NumPrevBits = numPrevBits;
					uint num = 1U << this.m_NumPrevBits + this.m_NumPosBits;
					this.m_Coders = new Decoder.LiteralDecoder.Decoder2[num];
					for (uint num2 = 0U; num2 < num; num2 += 1U)
					{
						this.m_Coders[(int)num2].Create();
					}
				}
			}

			// Token: 0x0600007F RID: 127 RVA: 0x00006F3C File Offset: 0x00006F3C
			public void Init()
			{
				uint num = 1U << this.m_NumPrevBits + this.m_NumPosBits;
				for (uint num2 = 0U; num2 < num; num2 += 1U)
				{
					this.m_Coders[(int)num2].Init();
				}
			}

			// Token: 0x06000080 RID: 128 RVA: 0x000022F5 File Offset: 0x000022F5
			private uint GetState(uint pos, byte prevByte)
			{
				return ((pos & this.m_PosMask) << this.m_NumPrevBits) + (uint)(prevByte >> 8 - this.m_NumPrevBits);
			}

			// Token: 0x06000081 RID: 129 RVA: 0x00002317 File Offset: 0x00002317
			public byte DecodeNormal(Decoder rangeDecoder, uint pos, byte prevByte)
			{
				return this.m_Coders[(int)this.GetState(pos, prevByte)].DecodeNormal(rangeDecoder);
			}

			// Token: 0x06000082 RID: 130 RVA: 0x00002332 File Offset: 0x00002332
			public byte DecodeWithMatchByte(Decoder rangeDecoder, uint pos, byte prevByte, byte matchByte)
			{
				return this.m_Coders[(int)this.GetState(pos, prevByte)].DecodeWithMatchByte(rangeDecoder, matchByte);
			}

			// Token: 0x04000085 RID: 133
			private Decoder.LiteralDecoder.Decoder2[] m_Coders;

			// Token: 0x04000086 RID: 134
			private int m_NumPrevBits;

			// Token: 0x04000087 RID: 135
			private int m_NumPosBits;

			// Token: 0x04000088 RID: 136
			private uint m_PosMask;

			// Token: 0x0200001B RID: 27
			private struct Decoder2
			{
				// Token: 0x06000084 RID: 132 RVA: 0x0000234F File Offset: 0x0000234F
				public void Create()
				{
					this.m_Decoders = new BitDecoder[768];
				}

				// Token: 0x06000085 RID: 133 RVA: 0x00006F80 File Offset: 0x00006F80
				public void Init()
				{
					for (int i = 0; i < 768; i++)
					{
						this.m_Decoders[i].Init();
					}
				}

				// Token: 0x06000086 RID: 134 RVA: 0x00006FB4 File Offset: 0x00006FB4
				public byte DecodeNormal(Decoder rangeDecoder)
				{
					uint num = 1U;
					do
					{
						num = (num << 1 | this.m_Decoders[(int)num].Decode(rangeDecoder));
					}
					while (num < 256U);
					return (byte)num;
				}

				// Token: 0x06000087 RID: 135 RVA: 0x00006FF0 File Offset: 0x00006FF0
				public byte DecodeWithMatchByte(Decoder rangeDecoder, byte matchByte)
				{
					uint num = 1U;
					for (;;)
					{
						uint num2 = (uint)(matchByte >> 7 & 1);
						matchByte = (byte)(matchByte << 1);
						uint num3 = this.m_Decoders[(int)((1U + num2 << 8) + num)].Decode(rangeDecoder);
						num = (num << 1 | num3);
						bool flag = num2 != num3;
						if (flag)
						{
							break;
						}
						if (num >= 256U)
						{
							goto IL_73;
						}
					}
					while (num < 256U)
					{
						num = (num << 1 | this.m_Decoders[(int)num].Decode(rangeDecoder));
					}
					IL_73:
					return (byte)num;
				}

				// Token: 0x04000089 RID: 137
				private BitDecoder[] m_Decoders;
			}
		}
	}
}
