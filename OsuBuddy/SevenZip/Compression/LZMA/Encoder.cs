using System;
using System.IO;
using SevenZip.Compression.LZ;
using SevenZip.Compression.RangeCoder;

namespace SevenZip.Compression.LZMA
{
	// Token: 0x0200001C RID: 28
	internal class Encoder : ICoder, ISetCoderProperties, IWriteCoderProperties
	{
		// Token: 0x06000088 RID: 136 RVA: 0x00007078 File Offset: 0x00007078
		static Encoder()
		{
			int num = 2;
			Encoder.g_FastPos[0] = 0;
			Encoder.g_FastPos[1] = 1;
			for (byte b = 2; b < 22; b += 1)
			{
				uint num2 = 1U << (b >> 1) - 1;
				uint num3 = 0U;
				while (num3 < num2)
				{
					Encoder.g_FastPos[num] = b;
					num3 += 1U;
					num++;
				}
			}
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00007104 File Offset: 0x00007104
		private static uint GetPosSlot(uint pos)
		{
			bool flag = pos < 2048U;
			uint result;
			if (flag)
			{
				result = (uint)Encoder.g_FastPos[(int)pos];
			}
			else
			{
				bool flag2 = pos < 2097152U;
				if (flag2)
				{
					result = (uint)(Encoder.g_FastPos[(int)(pos >> 10)] + 20);
				}
				else
				{
					result = (uint)(Encoder.g_FastPos[(int)(pos >> 20)] + 40);
				}
			}
			return result;
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00007158 File Offset: 0x00007158
		private static uint GetPosSlot2(uint pos)
		{
			bool flag = pos < 131072U;
			uint result;
			if (flag)
			{
				result = (uint)(Encoder.g_FastPos[(int)(pos >> 6)] + 12);
			}
			else
			{
				bool flag2 = pos < 134217728U;
				if (flag2)
				{
					result = (uint)(Encoder.g_FastPos[(int)(pos >> 16)] + 32);
				}
				else
				{
					result = (uint)(Encoder.g_FastPos[(int)(pos >> 26)] + 52);
				}
			}
			return result;
		}

		// Token: 0x0600008B RID: 139 RVA: 0x000071B0 File Offset: 0x000071B0
		private void BaseInit()
		{
			this._state.Init();
			this._previousByte = 0;
			for (uint num = 0U; num < 4U; num += 1U)
			{
				this._repDistances[(int)num] = 0U;
			}
		}

		// Token: 0x0600008C RID: 140 RVA: 0x000071EC File Offset: 0x000071EC
		private void Create()
		{
			bool flag = this._matchFinder == null;
			if (flag)
			{
				BinTree binTree = new BinTree();
				int type = 4;
				bool flag2 = this._matchFinderType == Encoder.EMatchFinderType.BT2;
				if (flag2)
				{
					type = 2;
				}
				binTree.SetType(type);
				this._matchFinder = binTree;
			}
			this._literalEncoder.Create(this._numLiteralPosStateBits, this._numLiteralContextBits);
			bool flag3 = this._dictionarySize == this._dictionarySizePrev && this._numFastBytesPrev == this._numFastBytes;
			if (!flag3)
			{
				this._matchFinder.Create(this._dictionarySize, 4096U, this._numFastBytes, 274U);
				this._dictionarySizePrev = this._dictionarySize;
				this._numFastBytesPrev = this._numFastBytes;
			}
		}

		// Token: 0x0600008D RID: 141 RVA: 0x000072A8 File Offset: 0x000072A8
		public Encoder()
		{
			int num = 0;
			while ((long)num < 4096L)
			{
				this._optimum[num] = new Encoder.Optimal();
				num++;
			}
			int num2 = 0;
			while ((long)num2 < 4L)
			{
				this._posSlotEncoder[num2] = new BitTreeEncoder(6);
				num2++;
			}
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00002362 File Offset: 0x00002362
		private void SetWriteEndMarkerMode(bool writeEndMarker)
		{
			this._writeEndMark = writeEndMarker;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x000074A4 File Offset: 0x000074A4
		private void Init()
		{
			this.BaseInit();
			this._rangeEncoder.Init();
			for (uint num = 0U; num < 12U; num += 1U)
			{
				for (uint num2 = 0U; num2 <= this._posStateMask; num2 += 1U)
				{
					uint num3 = (num << 4) + num2;
					this._isMatch[(int)num3].Init();
					this._isRep0Long[(int)num3].Init();
				}
				this._isRep[(int)num].Init();
				this._isRepG0[(int)num].Init();
				this._isRepG1[(int)num].Init();
				this._isRepG2[(int)num].Init();
			}
			this._literalEncoder.Init();
			for (uint num = 0U; num < 4U; num += 1U)
			{
				this._posSlotEncoder[(int)num].Init();
			}
			for (uint num = 0U; num < 114U; num += 1U)
			{
				this._posEncoders[(int)num].Init();
			}
			this._lenEncoder.Init(1U << this._posStateBits);
			this._repMatchLenEncoder.Init(1U << this._posStateBits);
			this._posAlignEncoder.Init();
			this._longestMatchWasFound = false;
			this._optimumEndIndex = 0U;
			this._optimumCurrentIndex = 0U;
			this._additionalOffset = 0U;
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00007618 File Offset: 0x00007618
		private void ReadMatchDistances(out uint lenRes, out uint numDistancePairs)
		{
			lenRes = 0U;
			numDistancePairs = this._matchFinder.GetMatches(this._matchDistances);
			bool flag = numDistancePairs > 0U;
			if (flag)
			{
				lenRes = this._matchDistances[(int)(numDistancePairs - 2U)];
				bool flag2 = lenRes == this._numFastBytes;
				if (flag2)
				{
					lenRes += this._matchFinder.GetMatchLen((int)(lenRes - 1U), this._matchDistances[(int)(numDistancePairs - 1U)], 273U - lenRes);
				}
			}
			this._additionalOffset += 1U;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00007698 File Offset: 0x00007698
		private void MovePos(uint num)
		{
			bool flag = num > 0U;
			if (flag)
			{
				this._matchFinder.Skip(num);
				this._additionalOffset += num;
			}
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000076CC File Offset: 0x000076CC
		private uint GetRepLen1Price(Base.State state, uint posState)
		{
			return this._isRepG0[(int)state.Index].GetPrice0() + this._isRep0Long[(int)((state.Index << 4) + posState)].GetPrice0();
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00007710 File Offset: 0x00007710
		private uint GetPureRepPrice(uint repIndex, Base.State state, uint posState)
		{
			bool flag = repIndex == 0U;
			uint num;
			if (flag)
			{
				num = this._isRepG0[(int)state.Index].GetPrice0();
				num += this._isRep0Long[(int)((state.Index << 4) + posState)].GetPrice1();
			}
			else
			{
				num = this._isRepG0[(int)state.Index].GetPrice1();
				bool flag2 = repIndex == 1U;
				if (flag2)
				{
					num += this._isRepG1[(int)state.Index].GetPrice0();
				}
				else
				{
					num += this._isRepG1[(int)state.Index].GetPrice1();
					num += this._isRepG2[(int)state.Index].GetPrice(repIndex - 2U);
				}
			}
			return num;
		}

		// Token: 0x06000094 RID: 148 RVA: 0x000077D8 File Offset: 0x000077D8
		private uint GetRepPrice(uint repIndex, uint len, Base.State state, uint posState)
		{
			uint price = this._repMatchLenEncoder.GetPrice(len - 2U, posState);
			return price + this.GetPureRepPrice(repIndex, state, posState);
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00007808 File Offset: 0x00007808
		private uint GetPosLenPrice(uint pos, uint len, uint posState)
		{
			uint lenToPosState = Base.GetLenToPosState(len);
			bool flag = pos < 128U;
			uint num;
			if (flag)
			{
				num = this._distancesPrices[(int)(lenToPosState * 128U + pos)];
			}
			else
			{
				num = this._posSlotPrices[(int)((lenToPosState << 6) + Encoder.GetPosSlot2(pos))] + this._alignPrices[(int)(pos & 15U)];
			}
			return num + this._lenEncoder.GetPrice(len - 2U, posState);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00007870 File Offset: 0x00007870
		private uint Backward(out uint backRes, uint cur)
		{
			this._optimumEndIndex = cur;
			uint posPrev = this._optimum[(int)cur].PosPrev;
			uint backPrev = this._optimum[(int)cur].BackPrev;
			do
			{
				bool prev1IsChar = this._optimum[(int)cur].Prev1IsChar;
				if (prev1IsChar)
				{
					this._optimum[(int)posPrev].MakeAsChar();
					this._optimum[(int)posPrev].PosPrev = posPrev - 1U;
					bool prev = this._optimum[(int)cur].Prev2;
					if (prev)
					{
						this._optimum[(int)(posPrev - 1U)].Prev1IsChar = false;
						this._optimum[(int)(posPrev - 1U)].PosPrev = this._optimum[(int)cur].PosPrev2;
						this._optimum[(int)(posPrev - 1U)].BackPrev = this._optimum[(int)cur].BackPrev2;
					}
				}
				uint num = posPrev;
				uint backPrev2 = backPrev;
				backPrev = this._optimum[(int)num].BackPrev;
				posPrev = this._optimum[(int)num].PosPrev;
				this._optimum[(int)num].BackPrev = backPrev2;
				this._optimum[(int)num].PosPrev = cur;
				cur = num;
			}
			while (cur > 0U);
			backRes = this._optimum[0].BackPrev;
			this._optimumCurrentIndex = this._optimum[0].PosPrev;
			return this._optimumCurrentIndex;
		}

		// Token: 0x06000097 RID: 151 RVA: 0x000079B0 File Offset: 0x000079B0
		private uint GetOptimum(uint position, out uint backRes)
		{
			bool flag = this._optimumEndIndex != this._optimumCurrentIndex;
			uint result;
			if (flag)
			{
				uint num = this._optimum[(int)this._optimumCurrentIndex].PosPrev - this._optimumCurrentIndex;
				backRes = this._optimum[(int)this._optimumCurrentIndex].BackPrev;
				this._optimumCurrentIndex = this._optimum[(int)this._optimumCurrentIndex].PosPrev;
				result = num;
			}
			else
			{
				this._optimumCurrentIndex = (this._optimumEndIndex = 0U);
				bool flag2 = !this._longestMatchWasFound;
				uint longestMatchLength;
				uint num2;
				if (flag2)
				{
					this.ReadMatchDistances(out longestMatchLength, out num2);
				}
				else
				{
					longestMatchLength = this._longestMatchLength;
					num2 = this._numDistancePairs;
					this._longestMatchWasFound = false;
				}
				uint num3 = this._matchFinder.GetNumAvailableBytes() + 1U;
				bool flag3 = num3 < 2U;
				if (flag3)
				{
					backRes = uint.MaxValue;
					result = 1U;
				}
				else
				{
					bool flag4 = num3 > 273U;
					if (flag4)
					{
					}
					uint num4 = 0U;
					for (uint num5 = 0U; num5 < 4U; num5 += 1U)
					{
						this.reps[(int)num5] = this._repDistances[(int)num5];
						this.repLens[(int)num5] = this._matchFinder.GetMatchLen(-1, this.reps[(int)num5], 273U);
						bool flag5 = this.repLens[(int)num5] > this.repLens[(int)num4];
						if (flag5)
						{
							num4 = num5;
						}
					}
					bool flag6 = this.repLens[(int)num4] >= this._numFastBytes;
					if (flag6)
					{
						backRes = num4;
						uint num6 = this.repLens[(int)num4];
						this.MovePos(num6 - 1U);
						result = num6;
					}
					else
					{
						bool flag7 = longestMatchLength >= this._numFastBytes;
						if (flag7)
						{
							backRes = this._matchDistances[(int)(num2 - 1U)] + 4U;
							this.MovePos(longestMatchLength - 1U);
							result = longestMatchLength;
						}
						else
						{
							byte indexByte = this._matchFinder.GetIndexByte(-1);
							byte indexByte2 = this._matchFinder.GetIndexByte((int)(0U - this._repDistances[0] - 1U - 1U));
							bool flag8 = longestMatchLength < 2U && indexByte != indexByte2 && this.repLens[(int)num4] < 2U;
							if (flag8)
							{
								backRes = uint.MaxValue;
								result = 1U;
							}
							else
							{
								this._optimum[0].State = this._state;
								uint num7 = position & this._posStateMask;
								this._optimum[1].Price = this._isMatch[(int)((this._state.Index << 4) + num7)].GetPrice0() + this._literalEncoder.GetSubCoder(position, this._previousByte).GetPrice(!this._state.IsCharState(), indexByte2, indexByte);
								this._optimum[1].MakeAsChar();
								uint num8 = this._isMatch[(int)((this._state.Index << 4) + num7)].GetPrice1();
								uint num9 = num8 + this._isRep[(int)this._state.Index].GetPrice1();
								bool flag9 = indexByte2 == indexByte;
								if (flag9)
								{
									uint num10 = num9 + this.GetRepLen1Price(this._state, num7);
									bool flag10 = num10 < this._optimum[1].Price;
									if (flag10)
									{
										this._optimum[1].Price = num10;
										this._optimum[1].MakeAsShortRep();
									}
								}
								uint num11 = (longestMatchLength >= this.repLens[(int)num4]) ? longestMatchLength : this.repLens[(int)num4];
								bool flag11 = num11 < 2U;
								if (flag11)
								{
									backRes = this._optimum[1].BackPrev;
									result = 1U;
								}
								else
								{
									this._optimum[1].PosPrev = 0U;
									this._optimum[0].Backs0 = this.reps[0];
									this._optimum[0].Backs1 = this.reps[1];
									this._optimum[0].Backs2 = this.reps[2];
									this._optimum[0].Backs3 = this.reps[3];
									uint num12 = num11;
									do
									{
										this._optimum[(int)num12--].Price = 268435455U;
									}
									while (num12 >= 2U);
									for (uint num5 = 0U; num5 < 4U; num5 += 1U)
									{
										uint num13 = this.repLens[(int)num5];
										bool flag12 = num13 < 2U;
										if (!flag12)
										{
											uint num14 = num9 + this.GetPureRepPrice(num5, this._state, num7);
											do
											{
												uint num15 = num14 + this._repMatchLenEncoder.GetPrice(num13 - 2U, num7);
												Encoder.Optimal optimal = this._optimum[(int)num13];
												bool flag13 = num15 < optimal.Price;
												if (flag13)
												{
													optimal.Price = num15;
													optimal.PosPrev = 0U;
													optimal.BackPrev = num5;
													optimal.Prev1IsChar = false;
												}
											}
											while ((num13 -= 1U) >= 2U);
										}
									}
									uint num16 = num8 + this._isRep[(int)this._state.Index].GetPrice0();
									num12 = ((this.repLens[0] >= 2U) ? (this.repLens[0] + 1U) : 2U);
									bool flag14 = num12 <= longestMatchLength;
									if (flag14)
									{
										uint num17 = 0U;
										while (num12 > this._matchDistances[(int)num17])
										{
											num17 += 2U;
										}
										for (;;)
										{
											uint num18 = this._matchDistances[(int)(num17 + 1U)];
											uint num19 = num16 + this.GetPosLenPrice(num18, num12, num7);
											Encoder.Optimal optimal2 = this._optimum[(int)num12];
											bool flag15 = num19 < optimal2.Price;
											if (flag15)
											{
												optimal2.Price = num19;
												optimal2.PosPrev = 0U;
												optimal2.BackPrev = num18 + 4U;
												optimal2.Prev1IsChar = false;
											}
											bool flag16 = num12 == this._matchDistances[(int)num17];
											if (flag16)
											{
												num17 += 2U;
												bool flag17 = num17 == num2;
												if (flag17)
												{
													break;
												}
											}
											num12 += 1U;
										}
									}
									uint num20 = 0U;
									uint num21;
									for (;;)
									{
										num20 += 1U;
										bool flag18 = num20 == num11;
										if (flag18)
										{
											break;
										}
										this.ReadMatchDistances(out num21, out num2);
										bool flag19 = num21 >= this._numFastBytes;
										if (flag19)
										{
											goto Block_26;
										}
										position += 1U;
										uint num22 = this._optimum[(int)num20].PosPrev;
										bool prev1IsChar = this._optimum[(int)num20].Prev1IsChar;
										Base.State state;
										if (prev1IsChar)
										{
											num22 -= 1U;
											bool prev = this._optimum[(int)num20].Prev2;
											if (prev)
											{
												state = this._optimum[(int)this._optimum[(int)num20].PosPrev2].State;
												bool flag20 = this._optimum[(int)num20].BackPrev2 < 4U;
												if (flag20)
												{
													state.UpdateRep();
												}
												else
												{
													state.UpdateMatch();
												}
											}
											else
											{
												state = this._optimum[(int)num22].State;
											}
											state.UpdateChar();
										}
										else
										{
											state = this._optimum[(int)num22].State;
										}
										bool flag21 = num22 == num20 - 1U;
										if (flag21)
										{
											bool flag22 = this._optimum[(int)num20].IsShortRep();
											if (flag22)
											{
												state.UpdateShortRep();
											}
											else
											{
												state.UpdateChar();
											}
										}
										else
										{
											bool flag23 = this._optimum[(int)num20].Prev1IsChar && this._optimum[(int)num20].Prev2;
											uint num23;
											if (flag23)
											{
												num22 = this._optimum[(int)num20].PosPrev2;
												num23 = this._optimum[(int)num20].BackPrev2;
												state.UpdateRep();
											}
											else
											{
												num23 = this._optimum[(int)num20].BackPrev;
												bool flag24 = num23 < 4U;
												if (flag24)
												{
													state.UpdateRep();
												}
												else
												{
													state.UpdateMatch();
												}
											}
											Encoder.Optimal optimal3 = this._optimum[(int)num22];
											bool flag25 = num23 < 4U;
											if (flag25)
											{
												bool flag26 = num23 == 0U;
												if (flag26)
												{
													this.reps[0] = optimal3.Backs0;
													this.reps[1] = optimal3.Backs1;
													this.reps[2] = optimal3.Backs2;
													this.reps[3] = optimal3.Backs3;
												}
												else
												{
													bool flag27 = num23 == 1U;
													if (flag27)
													{
														this.reps[0] = optimal3.Backs1;
														this.reps[1] = optimal3.Backs0;
														this.reps[2] = optimal3.Backs2;
														this.reps[3] = optimal3.Backs3;
													}
													else
													{
														bool flag28 = num23 == 2U;
														if (flag28)
														{
															this.reps[0] = optimal3.Backs2;
															this.reps[1] = optimal3.Backs0;
															this.reps[2] = optimal3.Backs1;
															this.reps[3] = optimal3.Backs3;
														}
														else
														{
															this.reps[0] = optimal3.Backs3;
															this.reps[1] = optimal3.Backs0;
															this.reps[2] = optimal3.Backs1;
															this.reps[3] = optimal3.Backs2;
														}
													}
												}
											}
											else
											{
												this.reps[0] = num23 - 4U;
												this.reps[1] = optimal3.Backs0;
												this.reps[2] = optimal3.Backs1;
												this.reps[3] = optimal3.Backs2;
											}
										}
										this._optimum[(int)num20].State = state;
										this._optimum[(int)num20].Backs0 = this.reps[0];
										this._optimum[(int)num20].Backs1 = this.reps[1];
										this._optimum[(int)num20].Backs2 = this.reps[2];
										this._optimum[(int)num20].Backs3 = this.reps[3];
										uint price = this._optimum[(int)num20].Price;
										indexByte = this._matchFinder.GetIndexByte(-1);
										indexByte2 = this._matchFinder.GetIndexByte((int)(0U - this.reps[0] - 1U - 1U));
										num7 = (position & this._posStateMask);
										uint num24 = price + this._isMatch[(int)((state.Index << 4) + num7)].GetPrice0() + this._literalEncoder.GetSubCoder(position, this._matchFinder.GetIndexByte(-2)).GetPrice(!state.IsCharState(), indexByte2, indexByte);
										Encoder.Optimal optimal4 = this._optimum[(int)(num20 + 1U)];
										bool flag29 = false;
										bool flag30 = num24 < optimal4.Price;
										if (flag30)
										{
											optimal4.Price = num24;
											optimal4.PosPrev = num20;
											optimal4.MakeAsChar();
											flag29 = true;
										}
										num8 = price + this._isMatch[(int)((state.Index << 4) + num7)].GetPrice1();
										num9 = num8 + this._isRep[(int)state.Index].GetPrice1();
										bool flag31 = indexByte2 == indexByte && (optimal4.PosPrev >= num20 || optimal4.BackPrev > 0U);
										if (flag31)
										{
											uint num25 = num9 + this.GetRepLen1Price(state, num7);
											bool flag32 = num25 <= optimal4.Price;
											if (flag32)
											{
												optimal4.Price = num25;
												optimal4.PosPrev = num20;
												optimal4.MakeAsShortRep();
												flag29 = true;
											}
										}
										uint num26 = this._matchFinder.GetNumAvailableBytes() + 1U;
										num26 = Math.Min(4095U - num20, num26);
										num3 = num26;
										bool flag33 = num3 < 2U;
										if (!flag33)
										{
											bool flag34 = num3 > this._numFastBytes;
											if (flag34)
											{
												num3 = this._numFastBytes;
											}
											bool flag35 = !flag29 && indexByte2 != indexByte;
											if (flag35)
											{
												uint limit = Math.Min(num26 - 1U, this._numFastBytes);
												uint matchLen = this._matchFinder.GetMatchLen(0, this.reps[0], limit);
												bool flag36 = matchLen >= 2U;
												if (flag36)
												{
													Base.State state2 = state;
													state2.UpdateChar();
													uint num27 = position + 1U & this._posStateMask;
													uint num28 = num24 + this._isMatch[(int)((state2.Index << 4) + num27)].GetPrice1() + this._isRep[(int)state2.Index].GetPrice1();
													uint num29 = num20 + 1U + matchLen;
													while (num11 < num29)
													{
														this._optimum[(int)(num11 += 1U)].Price = 268435455U;
													}
													uint num30 = num28 + this.GetRepPrice(0U, matchLen, state2, num27);
													Encoder.Optimal optimal5 = this._optimum[(int)num29];
													bool flag37 = num30 < optimal5.Price;
													if (flag37)
													{
														optimal5.Price = num30;
														optimal5.PosPrev = num20 + 1U;
														optimal5.BackPrev = 0U;
														optimal5.Prev1IsChar = true;
														optimal5.Prev2 = false;
													}
												}
											}
											uint num31 = 2U;
											for (uint num32 = 0U; num32 < 4U; num32 += 1U)
											{
												uint num33 = this._matchFinder.GetMatchLen(-1, this.reps[(int)num32], num3);
												bool flag38 = num33 < 2U;
												if (!flag38)
												{
													uint num34 = num33;
													do
													{
														while (num11 < num20 + num33)
														{
															this._optimum[(int)(num11 += 1U)].Price = 268435455U;
														}
														uint num35 = num9 + this.GetRepPrice(num32, num33, state, num7);
														Encoder.Optimal optimal6 = this._optimum[(int)(num20 + num33)];
														bool flag39 = num35 < optimal6.Price;
														if (flag39)
														{
															optimal6.Price = num35;
															optimal6.PosPrev = num20;
															optimal6.BackPrev = num32;
															optimal6.Prev1IsChar = false;
														}
													}
													while ((num33 -= 1U) >= 2U);
													num33 = num34;
													bool flag40 = num32 == 0U;
													if (flag40)
													{
														num31 = num33 + 1U;
													}
													bool flag41 = num33 < num26;
													if (flag41)
													{
														uint limit2 = Math.Min(num26 - 1U - num33, this._numFastBytes);
														uint matchLen2 = this._matchFinder.GetMatchLen((int)num33, this.reps[(int)num32], limit2);
														bool flag42 = matchLen2 >= 2U;
														if (flag42)
														{
															Base.State state3 = state;
															state3.UpdateRep();
															uint num36 = position + num33 & this._posStateMask;
															uint num37 = num9 + this.GetRepPrice(num32, num33, state, num7) + this._isMatch[(int)((state3.Index << 4) + num36)].GetPrice0() + this._literalEncoder.GetSubCoder(position + num33, this._matchFinder.GetIndexByte((int)(num33 - 1U - 1U))).GetPrice(true, this._matchFinder.GetIndexByte((int)(num33 - 1U - (this.reps[(int)num32] + 1U))), this._matchFinder.GetIndexByte((int)(num33 - 1U)));
															state3.UpdateChar();
															num36 = (position + num33 + 1U & this._posStateMask);
															uint num38 = num37 + this._isMatch[(int)((state3.Index << 4) + num36)].GetPrice1();
															uint num39 = num38 + this._isRep[(int)state3.Index].GetPrice1();
															uint num40 = num33 + 1U + matchLen2;
															while (num11 < num20 + num40)
															{
																this._optimum[(int)(num11 += 1U)].Price = 268435455U;
															}
															uint num41 = num39 + this.GetRepPrice(0U, matchLen2, state3, num36);
															Encoder.Optimal optimal7 = this._optimum[(int)(num20 + num40)];
															bool flag43 = num41 < optimal7.Price;
															if (flag43)
															{
																optimal7.Price = num41;
																optimal7.PosPrev = num20 + num33 + 1U;
																optimal7.BackPrev = 0U;
																optimal7.Prev1IsChar = true;
																optimal7.Prev2 = true;
																optimal7.PosPrev2 = num20;
																optimal7.BackPrev2 = num32;
															}
														}
													}
												}
											}
											bool flag44 = num21 > num3;
											if (flag44)
											{
												num21 = num3;
												num2 = 0U;
												while (num21 > this._matchDistances[(int)num2])
												{
													num2 += 2U;
												}
												this._matchDistances[(int)num2] = num21;
												num2 += 2U;
											}
											bool flag45 = num21 >= num31;
											if (flag45)
											{
												num16 = num8 + this._isRep[(int)state.Index].GetPrice0();
												while (num11 < num20 + num21)
												{
													this._optimum[(int)(num11 += 1U)].Price = 268435455U;
												}
												uint num42 = 0U;
												while (num31 > this._matchDistances[(int)num42])
												{
													num42 += 2U;
												}
												uint num43 = num31;
												for (;;)
												{
													uint num44 = this._matchDistances[(int)(num42 + 1U)];
													uint num45 = num16 + this.GetPosLenPrice(num44, num43, num7);
													Encoder.Optimal optimal8 = this._optimum[(int)(num20 + num43)];
													bool flag46 = num45 < optimal8.Price;
													if (flag46)
													{
														optimal8.Price = num45;
														optimal8.PosPrev = num20;
														optimal8.BackPrev = num44 + 4U;
														optimal8.Prev1IsChar = false;
													}
													bool flag47 = num43 == this._matchDistances[(int)num42];
													if (flag47)
													{
														bool flag48 = num43 < num26;
														if (flag48)
														{
															uint limit3 = Math.Min(num26 - 1U - num43, this._numFastBytes);
															uint matchLen3 = this._matchFinder.GetMatchLen((int)num43, num44, limit3);
															bool flag49 = matchLen3 >= 2U;
															if (flag49)
															{
																Base.State state4 = state;
																state4.UpdateMatch();
																uint num46 = position + num43 & this._posStateMask;
																uint num47 = num45 + this._isMatch[(int)((state4.Index << 4) + num46)].GetPrice0() + this._literalEncoder.GetSubCoder(position + num43, this._matchFinder.GetIndexByte((int)(num43 - 1U - 1U))).GetPrice(true, this._matchFinder.GetIndexByte((int)(num43 - (num44 + 1U) - 1U)), this._matchFinder.GetIndexByte((int)(num43 - 1U)));
																state4.UpdateChar();
																num46 = (position + num43 + 1U & this._posStateMask);
																uint num48 = num47 + this._isMatch[(int)((state4.Index << 4) + num46)].GetPrice1();
																uint num49 = num48 + this._isRep[(int)state4.Index].GetPrice1();
																uint num50 = num43 + 1U + matchLen3;
																while (num11 < num20 + num50)
																{
																	this._optimum[(int)(num11 += 1U)].Price = 268435455U;
																}
																num45 = num49 + this.GetRepPrice(0U, matchLen3, state4, num46);
																optimal8 = this._optimum[(int)(num20 + num50)];
																bool flag50 = num45 < optimal8.Price;
																if (flag50)
																{
																	optimal8.Price = num45;
																	optimal8.PosPrev = num20 + num43 + 1U;
																	optimal8.BackPrev = 0U;
																	optimal8.Prev1IsChar = true;
																	optimal8.Prev2 = true;
																	optimal8.PosPrev2 = num20;
																	optimal8.BackPrev2 = num44 + 4U;
																}
															}
														}
														num42 += 2U;
														bool flag51 = num42 == num2;
														if (flag51)
														{
															break;
														}
													}
													num43 += 1U;
												}
											}
										}
									}
									return this.Backward(out backRes, num20);
									Block_26:
									this._numDistancePairs = num2;
									this._longestMatchLength = num21;
									this._longestMatchWasFound = true;
									result = this.Backward(out backRes, num20);
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00008C54 File Offset: 0x00008C54
		private void WriteEndMarker(uint posState)
		{
			bool flag = !this._writeEndMark;
			if (!flag)
			{
				this._isMatch[(int)((this._state.Index << 4) + posState)].Encode(this._rangeEncoder, 1U);
				this._isRep[(int)this._state.Index].Encode(this._rangeEncoder, 0U);
				this._state.UpdateMatch();
				uint num = 2U;
				this._lenEncoder.Encode(this._rangeEncoder, num - 2U, posState);
				uint symbol = 63U;
				uint lenToPosState = Base.GetLenToPosState(num);
				this._posSlotEncoder[(int)lenToPosState].Encode(this._rangeEncoder, symbol);
				int num2 = 30;
				uint num3 = (1U << num2) - 1U;
				this._rangeEncoder.EncodeDirectBits(num3 >> 4, num2 - 4);
				this._posAlignEncoder.ReverseEncode(this._rangeEncoder, num3 & 15U);
			}
		}

		// Token: 0x06000099 RID: 153 RVA: 0x0000236C File Offset: 0x0000236C
		private void Flush(uint nowPos)
		{
			this.ReleaseMFStream();
			this.WriteEndMarker(nowPos & this._posStateMask);
			this._rangeEncoder.FlushData();
			this._rangeEncoder.FlushStream();
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00008D40 File Offset: 0x00008D40
		public void CodeOneBlock(out long inSize, out long outSize, out bool finished)
		{
			inSize = 0L;
			outSize = 0L;
			finished = true;
			bool flag = this._inStream != null;
			if (flag)
			{
				this._matchFinder.SetStream(this._inStream);
				this._matchFinder.Init();
				this._needReleaseMFStream = true;
				this._inStream = null;
				bool flag2 = this._trainSize > 0U;
				if (flag2)
				{
					this._matchFinder.Skip(this._trainSize);
				}
			}
			bool finished2 = this._finished;
			if (!finished2)
			{
				this._finished = true;
				long num = this.nowPos64;
				bool flag3 = this.nowPos64 == 0L;
				if (flag3)
				{
					bool flag4 = this._matchFinder.GetNumAvailableBytes() == 0U;
					if (flag4)
					{
						this.Flush((uint)this.nowPos64);
						return;
					}
					uint num2;
					uint num3;
					this.ReadMatchDistances(out num2, out num3);
					uint num4 = (uint)this.nowPos64 & this._posStateMask;
					this._isMatch[(int)((this._state.Index << 4) + num4)].Encode(this._rangeEncoder, 0U);
					this._state.UpdateChar();
					byte indexByte = this._matchFinder.GetIndexByte((int)(0U - this._additionalOffset));
					this._literalEncoder.GetSubCoder((uint)this.nowPos64, this._previousByte).Encode(this._rangeEncoder, indexByte);
					this._previousByte = indexByte;
					this._additionalOffset -= 1U;
					this.nowPos64 += 1L;
				}
				bool flag5 = this._matchFinder.GetNumAvailableBytes() == 0U;
				if (flag5)
				{
					this.Flush((uint)this.nowPos64);
				}
				else
				{
					for (;;)
					{
						uint num5;
						uint optimum = this.GetOptimum((uint)this.nowPos64, out num5);
						uint num6 = (uint)this.nowPos64 & this._posStateMask;
						uint num7 = (this._state.Index << 4) + num6;
						bool flag6 = optimum == 1U && num5 == uint.MaxValue;
						if (flag6)
						{
							this._isMatch[(int)num7].Encode(this._rangeEncoder, 0U);
							byte indexByte2 = this._matchFinder.GetIndexByte((int)(0U - this._additionalOffset));
							Encoder.LiteralEncoder.Encoder2 subCoder = this._literalEncoder.GetSubCoder((uint)this.nowPos64, this._previousByte);
							bool flag7 = !this._state.IsCharState();
							if (flag7)
							{
								byte indexByte3 = this._matchFinder.GetIndexByte((int)(0U - this._repDistances[0] - 1U - this._additionalOffset));
								subCoder.EncodeMatched(this._rangeEncoder, indexByte3, indexByte2);
							}
							else
							{
								subCoder.Encode(this._rangeEncoder, indexByte2);
							}
							this._previousByte = indexByte2;
							this._state.UpdateChar();
						}
						else
						{
							this._isMatch[(int)num7].Encode(this._rangeEncoder, 1U);
							bool flag8 = num5 < 4U;
							if (flag8)
							{
								this._isRep[(int)this._state.Index].Encode(this._rangeEncoder, 1U);
								bool flag9 = num5 == 0U;
								if (flag9)
								{
									this._isRepG0[(int)this._state.Index].Encode(this._rangeEncoder, 0U);
									bool flag10 = optimum == 1U;
									if (flag10)
									{
										this._isRep0Long[(int)num7].Encode(this._rangeEncoder, 0U);
									}
									else
									{
										this._isRep0Long[(int)num7].Encode(this._rangeEncoder, 1U);
									}
								}
								else
								{
									this._isRepG0[(int)this._state.Index].Encode(this._rangeEncoder, 1U);
									bool flag11 = num5 == 1U;
									if (flag11)
									{
										this._isRepG1[(int)this._state.Index].Encode(this._rangeEncoder, 0U);
									}
									else
									{
										this._isRepG1[(int)this._state.Index].Encode(this._rangeEncoder, 1U);
										this._isRepG2[(int)this._state.Index].Encode(this._rangeEncoder, num5 - 2U);
									}
								}
								bool flag12 = optimum == 1U;
								if (flag12)
								{
									this._state.UpdateShortRep();
								}
								else
								{
									this._repMatchLenEncoder.Encode(this._rangeEncoder, optimum - 2U, num6);
									this._state.UpdateRep();
								}
								uint num8 = this._repDistances[(int)num5];
								bool flag13 = num5 > 0U;
								if (flag13)
								{
									for (uint num9 = num5; num9 >= 1U; num9 -= 1U)
									{
										this._repDistances[(int)num9] = this._repDistances[(int)(num9 - 1U)];
									}
									this._repDistances[0] = num8;
								}
							}
							else
							{
								this._isRep[(int)this._state.Index].Encode(this._rangeEncoder, 0U);
								this._state.UpdateMatch();
								this._lenEncoder.Encode(this._rangeEncoder, optimum - 2U, num6);
								num5 -= 4U;
								uint posSlot = Encoder.GetPosSlot(num5);
								uint lenToPosState = Base.GetLenToPosState(optimum);
								this._posSlotEncoder[(int)lenToPosState].Encode(this._rangeEncoder, posSlot);
								bool flag14 = posSlot >= 4U;
								if (flag14)
								{
									int num10 = (int)((posSlot >> 1) - 1U);
									uint num11 = (2U | (posSlot & 1U)) << num10;
									uint num12 = num5 - num11;
									bool flag15 = posSlot < 14U;
									if (flag15)
									{
										BitTreeEncoder.ReverseEncode(this._posEncoders, num11 - posSlot - 1U, this._rangeEncoder, num10, num12);
									}
									else
									{
										this._rangeEncoder.EncodeDirectBits(num12 >> 4, num10 - 4);
										this._posAlignEncoder.ReverseEncode(this._rangeEncoder, num12 & 15U);
										this._alignPriceCount += 1U;
									}
								}
								uint num13 = num5;
								for (uint num14 = 3U; num14 >= 1U; num14 -= 1U)
								{
									this._repDistances[(int)num14] = this._repDistances[(int)(num14 - 1U)];
								}
								this._repDistances[0] = num13;
								this._matchPriceCount += 1U;
							}
							this._previousByte = this._matchFinder.GetIndexByte((int)(optimum - 1U - this._additionalOffset));
						}
						this._additionalOffset -= optimum;
						this.nowPos64 += (long)((ulong)optimum);
						bool flag16 = this._additionalOffset == 0U;
						if (flag16)
						{
							bool flag17 = this._matchPriceCount >= 128U;
							if (flag17)
							{
								this.FillDistancesPrices();
							}
							bool flag18 = this._alignPriceCount >= 16U;
							if (flag18)
							{
								this.FillAlignPrices();
							}
							inSize = this.nowPos64;
							outSize = this._rangeEncoder.GetProcessedSizeAdd();
							bool flag19 = this._matchFinder.GetNumAvailableBytes() == 0U;
							if (flag19)
							{
								break;
							}
							bool flag20 = this.nowPos64 - num >= 4096L;
							if (flag20)
							{
								goto Block_24;
							}
						}
					}
					this.Flush((uint)this.nowPos64);
					return;
					Block_24:
					this._finished = false;
					finished = false;
				}
			}
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00009438 File Offset: 0x00009438
		private void ReleaseMFStream()
		{
			bool flag = this._matchFinder != null && this._needReleaseMFStream;
			if (flag)
			{
				this._matchFinder.ReleaseStream();
				this._needReleaseMFStream = false;
			}
		}

		// Token: 0x0600009C RID: 156 RVA: 0x0000239D File Offset: 0x0000239D
		private void SetOutStream(Stream outStream)
		{
			this._rangeEncoder.SetStream(outStream);
		}

		// Token: 0x0600009D RID: 157 RVA: 0x000023AD File Offset: 0x000023AD
		private void ReleaseOutStream()
		{
			this._rangeEncoder.ReleaseStream();
		}

		// Token: 0x0600009E RID: 158 RVA: 0x000023BC File Offset: 0x000023BC
		private void ReleaseStreams()
		{
			this.ReleaseMFStream();
			this.ReleaseOutStream();
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00009470 File Offset: 0x00009470
		private void SetStreams(Stream inStream, Stream outStream, long inSize, long outSize)
		{
			this._inStream = inStream;
			this._finished = false;
			this.Create();
			this.SetOutStream(outStream);
			this.Init();
			this.FillDistancesPrices();
			this.FillAlignPrices();
			this._lenEncoder.SetTableSize(this._numFastBytes + 1U - 2U);
			this._lenEncoder.UpdateTables(1U << this._posStateBits);
			this._repMatchLenEncoder.SetTableSize(this._numFastBytes + 1U - 2U);
			this._repMatchLenEncoder.UpdateTables(1U << this._posStateBits);
			this.nowPos64 = 0L;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00009514 File Offset: 0x00009514
		public void Code(Stream inStream, Stream outStream, long inSize, long outSize, ICodeProgress progress)
		{
			this._needReleaseMFStream = false;
			try
			{
				this.SetStreams(inStream, outStream, inSize, outSize);
				for (;;)
				{
					long inSize2;
					long outSize2;
					bool flag;
					this.CodeOneBlock(out inSize2, out outSize2, out flag);
					bool flag2 = flag;
					if (flag2)
					{
						break;
					}
					bool flag3 = progress != null;
					if (flag3)
					{
						progress.SetProgress(inSize2, outSize2);
					}
				}
			}
			finally
			{
				this.ReleaseStreams();
			}
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00009584 File Offset: 0x00009584
		public void WriteCoderProperties(Stream outStream)
		{
			this.properties[0] = (byte)((this._posStateBits * 5 + this._numLiteralPosStateBits) * 9 + this._numLiteralContextBits);
			for (int i = 0; i < 4; i++)
			{
				this.properties[1 + i] = (byte)(this._dictionarySize >> 8 * i & 255U);
			}
			outStream.Write(this.properties, 0, 5);
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x000095F4 File Offset: 0x000095F4
		private void FillDistancesPrices()
		{
			for (uint num = 4U; num < 128U; num += 1U)
			{
				uint posSlot = Encoder.GetPosSlot(num);
				int num2 = (int)((posSlot >> 1) - 1U);
				uint num3 = (2U | (posSlot & 1U)) << num2;
				this.tempPrices[(int)num] = BitTreeEncoder.ReverseGetPrice(this._posEncoders, num3 - posSlot - 1U, num2, num - num3);
			}
			for (uint num4 = 0U; num4 < 4U; num4 += 1U)
			{
				BitTreeEncoder bitTreeEncoder = this._posSlotEncoder[(int)num4];
				uint num5 = num4 << 6;
				for (uint num6 = 0U; num6 < this._distTableSize; num6 += 1U)
				{
					this._posSlotPrices[(int)(num5 + num6)] = bitTreeEncoder.GetPrice(num6);
				}
				for (uint num6 = 14U; num6 < this._distTableSize; num6 += 1U)
				{
					this._posSlotPrices[(int)(num5 + num6)] += (num6 >> 1) - 1U - 4U << 6;
				}
				uint num7 = num4 * 128U;
				uint num8;
				for (num8 = 0U; num8 < 4U; num8 += 1U)
				{
					this._distancesPrices[(int)(num7 + num8)] = this._posSlotPrices[(int)(num5 + num8)];
				}
				while (num8 < 128U)
				{
					this._distancesPrices[(int)(num7 + num8)] = this._posSlotPrices[(int)(num5 + Encoder.GetPosSlot(num8))] + this.tempPrices[(int)num8];
					num8 += 1U;
				}
			}
			this._matchPriceCount = 0U;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00009768 File Offset: 0x00009768
		private void FillAlignPrices()
		{
			for (uint num = 0U; num < 16U; num += 1U)
			{
				this._alignPrices[(int)num] = this._posAlignEncoder.ReverseGetPrice(num);
			}
			this._alignPriceCount = 0U;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x000097A4 File Offset: 0x000097A4
		private static int FindMatchFinder(string s)
		{
			for (int i = 0; i < Encoder.kMatchFinderIDs.Length; i++)
			{
				bool flag = s == Encoder.kMatchFinderIDs[i];
				if (flag)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x000097E4 File Offset: 0x000097E4
		public void SetCoderProperties(CoderPropID[] propIDs, object[] properties)
		{
			uint num = 0U;
			while ((ulong)num < (ulong)((long)properties.Length))
			{
				object obj = properties[(int)num];
				switch (propIDs[(int)num])
				{
				case CoderPropID.DictionarySize:
				{
					bool flag = !(obj is int);
					if (flag)
					{
						throw new InvalidParamException();
					}
					int num2 = (int)obj;
					bool flag2 = (long)num2 < 1L || (long)num2 > 1073741824L;
					if (flag2)
					{
						throw new InvalidParamException();
					}
					this._dictionarySize = (uint)num2;
					int num3 = 0;
					while ((long)num3 < 30L)
					{
						bool flag3 = (long)num2 <= (long)(1UL << (num3 & 31));
						if (flag3)
						{
							break;
						}
						num3++;
					}
					this._distTableSize = (uint)(num3 * 2);
					break;
				}
				case CoderPropID.UsedMemorySize:
				case CoderPropID.Order:
				case CoderPropID.BlockSize:
				case CoderPropID.MatchFinderCycles:
				case CoderPropID.NumPasses:
				case CoderPropID.NumThreads:
					goto IL_2C4;
				case CoderPropID.PosStateBits:
				{
					bool flag4 = !(obj is int);
					if (flag4)
					{
						throw new InvalidParamException();
					}
					int num4 = (int)obj;
					bool flag5 = num4 < 0 || (long)num4 > 4L;
					if (flag5)
					{
						throw new InvalidParamException();
					}
					this._posStateBits = num4;
					this._posStateMask = (1U << this._posStateBits) - 1U;
					break;
				}
				case CoderPropID.LitContextBits:
				{
					bool flag6 = !(obj is int);
					if (flag6)
					{
						throw new InvalidParamException();
					}
					int num5 = (int)obj;
					bool flag7 = num5 < 0 || (long)num5 > 8L;
					if (flag7)
					{
						throw new InvalidParamException();
					}
					this._numLiteralContextBits = num5;
					break;
				}
				case CoderPropID.LitPosBits:
				{
					bool flag8 = !(obj is int);
					if (flag8)
					{
						throw new InvalidParamException();
					}
					int num6 = (int)obj;
					bool flag9 = num6 < 0 || (long)num6 > 4L;
					if (flag9)
					{
						throw new InvalidParamException();
					}
					this._numLiteralPosStateBits = num6;
					break;
				}
				case CoderPropID.NumFastBytes:
				{
					bool flag10 = !(obj is int);
					if (flag10)
					{
						throw new InvalidParamException();
					}
					int num7 = (int)obj;
					bool flag11 = num7 < 5 || (long)num7 > 273L;
					if (flag11)
					{
						throw new InvalidParamException();
					}
					this._numFastBytes = (uint)num7;
					break;
				}
				case CoderPropID.MatchFinder:
				{
					bool flag12 = !(obj is string);
					if (flag12)
					{
						throw new InvalidParamException();
					}
					Encoder.EMatchFinderType matchFinderType = this._matchFinderType;
					int num8 = Encoder.FindMatchFinder(((string)obj).ToUpper());
					bool flag13 = num8 < 0;
					if (flag13)
					{
						throw new InvalidParamException();
					}
					this._matchFinderType = (Encoder.EMatchFinderType)num8;
					bool flag14 = this._matchFinder != null && matchFinderType != this._matchFinderType;
					if (flag14)
					{
						this._dictionarySizePrev = uint.MaxValue;
						this._matchFinder = null;
					}
					break;
				}
				case CoderPropID.Algorithm:
					break;
				case CoderPropID.EndMarker:
				{
					bool flag15 = !(obj is bool);
					if (flag15)
					{
						throw new InvalidParamException();
					}
					this.SetWriteEndMarkerMode((bool)obj);
					break;
				}
				default:
					goto IL_2C4;
				}
				num += 1U;
				continue;
				IL_2C4:
				throw new InvalidParamException();
			}
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x000023CD File Offset: 0x000023CD
		public void SetTrainSize(uint trainSize)
		{
			this._trainSize = trainSize;
		}

		// Token: 0x0400008A RID: 138
		private const uint kIfinityPrice = 268435455U;

		// Token: 0x0400008B RID: 139
		private static byte[] g_FastPos = new byte[2048];

		// Token: 0x0400008C RID: 140
		private Base.State _state = default(Base.State);

		// Token: 0x0400008D RID: 141
		private byte _previousByte;

		// Token: 0x0400008E RID: 142
		private uint[] _repDistances = new uint[4];

		// Token: 0x0400008F RID: 143
		private const int kDefaultDictionaryLogSize = 22;

		// Token: 0x04000090 RID: 144
		private const uint kNumFastBytesDefault = 32U;

		// Token: 0x04000091 RID: 145
		private const uint kNumOpts = 4096U;

		// Token: 0x04000092 RID: 146
		private Encoder.Optimal[] _optimum = new Encoder.Optimal[4096];

		// Token: 0x04000093 RID: 147
		private IMatchFinder _matchFinder = null;

		// Token: 0x04000094 RID: 148
		private Encoder _rangeEncoder = new Encoder();

		// Token: 0x04000095 RID: 149
		private BitEncoder[] _isMatch = new BitEncoder[192];

		// Token: 0x04000096 RID: 150
		private BitEncoder[] _isRep = new BitEncoder[12];

		// Token: 0x04000097 RID: 151
		private BitEncoder[] _isRepG0 = new BitEncoder[12];

		// Token: 0x04000098 RID: 152
		private BitEncoder[] _isRepG1 = new BitEncoder[12];

		// Token: 0x04000099 RID: 153
		private BitEncoder[] _isRepG2 = new BitEncoder[12];

		// Token: 0x0400009A RID: 154
		private BitEncoder[] _isRep0Long = new BitEncoder[192];

		// Token: 0x0400009B RID: 155
		private BitTreeEncoder[] _posSlotEncoder = new BitTreeEncoder[4];

		// Token: 0x0400009C RID: 156
		private BitEncoder[] _posEncoders = new BitEncoder[114];

		// Token: 0x0400009D RID: 157
		private BitTreeEncoder _posAlignEncoder = new BitTreeEncoder(4);

		// Token: 0x0400009E RID: 158
		private Encoder.LenPriceTableEncoder _lenEncoder = new Encoder.LenPriceTableEncoder();

		// Token: 0x0400009F RID: 159
		private Encoder.LenPriceTableEncoder _repMatchLenEncoder = new Encoder.LenPriceTableEncoder();

		// Token: 0x040000A0 RID: 160
		private Encoder.LiteralEncoder _literalEncoder = new Encoder.LiteralEncoder();

		// Token: 0x040000A1 RID: 161
		private uint[] _matchDistances = new uint[548];

		// Token: 0x040000A2 RID: 162
		private uint _numFastBytes = 32U;

		// Token: 0x040000A3 RID: 163
		private uint _longestMatchLength;

		// Token: 0x040000A4 RID: 164
		private uint _numDistancePairs;

		// Token: 0x040000A5 RID: 165
		private uint _additionalOffset;

		// Token: 0x040000A6 RID: 166
		private uint _optimumEndIndex;

		// Token: 0x040000A7 RID: 167
		private uint _optimumCurrentIndex;

		// Token: 0x040000A8 RID: 168
		private bool _longestMatchWasFound;

		// Token: 0x040000A9 RID: 169
		private uint[] _posSlotPrices = new uint[256];

		// Token: 0x040000AA RID: 170
		private uint[] _distancesPrices = new uint[512];

		// Token: 0x040000AB RID: 171
		private uint[] _alignPrices = new uint[16];

		// Token: 0x040000AC RID: 172
		private uint _alignPriceCount;

		// Token: 0x040000AD RID: 173
		private uint _distTableSize = 44U;

		// Token: 0x040000AE RID: 174
		private int _posStateBits = 2;

		// Token: 0x040000AF RID: 175
		private uint _posStateMask = 3U;

		// Token: 0x040000B0 RID: 176
		private int _numLiteralPosStateBits = 0;

		// Token: 0x040000B1 RID: 177
		private int _numLiteralContextBits = 3;

		// Token: 0x040000B2 RID: 178
		private uint _dictionarySize = 4194304U;

		// Token: 0x040000B3 RID: 179
		private uint _dictionarySizePrev = uint.MaxValue;

		// Token: 0x040000B4 RID: 180
		private uint _numFastBytesPrev = uint.MaxValue;

		// Token: 0x040000B5 RID: 181
		private long nowPos64;

		// Token: 0x040000B6 RID: 182
		private bool _finished;

		// Token: 0x040000B7 RID: 183
		private Stream _inStream;

		// Token: 0x040000B8 RID: 184
		private Encoder.EMatchFinderType _matchFinderType = Encoder.EMatchFinderType.BT4;

		// Token: 0x040000B9 RID: 185
		private bool _writeEndMark = false;

		// Token: 0x040000BA RID: 186
		private bool _needReleaseMFStream;

		// Token: 0x040000BB RID: 187
		private uint[] reps = new uint[4];

		// Token: 0x040000BC RID: 188
		private uint[] repLens = new uint[4];

		// Token: 0x040000BD RID: 189
		private const int kPropSize = 5;

		// Token: 0x040000BE RID: 190
		private byte[] properties = new byte[5];

		// Token: 0x040000BF RID: 191
		private uint[] tempPrices = new uint[128];

		// Token: 0x040000C0 RID: 192
		private uint _matchPriceCount;

		// Token: 0x040000C1 RID: 193
		private static string[] kMatchFinderIDs = new string[]
		{
			"BT2",
			"BT4"
		};

		// Token: 0x040000C2 RID: 194
		private uint _trainSize = 0U;

		// Token: 0x0200001D RID: 29
		private enum EMatchFinderType
		{
			// Token: 0x040000C4 RID: 196
			BT2,
			// Token: 0x040000C5 RID: 197
			BT4
		}

		// Token: 0x0200001E RID: 30
		internal class LiteralEncoder
		{
			// Token: 0x060000A7 RID: 167 RVA: 0x00009AD4 File Offset: 0x00009AD4
			public void Create(int numPosBits, int numPrevBits)
			{
				bool flag = this.m_Coders != null && this.m_NumPrevBits == numPrevBits && this.m_NumPosBits == numPosBits;
				if (!flag)
				{
					this.m_NumPosBits = numPosBits;
					this.m_PosMask = (1U << numPosBits) - 1U;
					this.m_NumPrevBits = numPrevBits;
					uint num = 1U << this.m_NumPrevBits + this.m_NumPosBits;
					this.m_Coders = new Encoder.LiteralEncoder.Encoder2[num];
					for (uint num2 = 0U; num2 < num; num2 += 1U)
					{
						this.m_Coders[(int)num2].Create();
					}
				}
			}

			// Token: 0x060000A8 RID: 168 RVA: 0x00009B64 File Offset: 0x00009B64
			public void Init()
			{
				uint num = 1U << this.m_NumPrevBits + this.m_NumPosBits;
				for (uint num2 = 0U; num2 < num; num2 += 1U)
				{
					this.m_Coders[(int)num2].Init();
				}
			}

			// Token: 0x060000A9 RID: 169 RVA: 0x00009BA8 File Offset: 0x00009BA8
			public Encoder.LiteralEncoder.Encoder2 GetSubCoder(uint pos, byte prevByte)
			{
				return this.m_Coders[(int)(((pos & this.m_PosMask) << this.m_NumPrevBits) + (uint)(prevByte >> 8 - this.m_NumPrevBits))];
			}

			// Token: 0x040000C6 RID: 198
			private Encoder.LiteralEncoder.Encoder2[] m_Coders;

			// Token: 0x040000C7 RID: 199
			private int m_NumPrevBits;

			// Token: 0x040000C8 RID: 200
			private int m_NumPosBits;

			// Token: 0x040000C9 RID: 201
			private uint m_PosMask;

			// Token: 0x0200001F RID: 31
			public struct Encoder2
			{
				// Token: 0x060000AB RID: 171 RVA: 0x000023D7 File Offset: 0x000023D7
				public void Create()
				{
					this.m_Encoders = new BitEncoder[768];
				}

				// Token: 0x060000AC RID: 172 RVA: 0x00009BE8 File Offset: 0x00009BE8
				public void Init()
				{
					for (int i = 0; i < 768; i++)
					{
						this.m_Encoders[i].Init();
					}
				}

				// Token: 0x060000AD RID: 173 RVA: 0x00009C1C File Offset: 0x00009C1C
				public void Encode(Encoder rangeEncoder, byte symbol)
				{
					uint num = 1U;
					for (int i = 7; i >= 0; i--)
					{
						uint num2 = (uint)(symbol >> i & 1);
						this.m_Encoders[(int)num].Encode(rangeEncoder, num2);
						num = (num << 1 | num2);
					}
				}

				// Token: 0x060000AE RID: 174 RVA: 0x00009C64 File Offset: 0x00009C64
				public void EncodeMatched(Encoder rangeEncoder, byte matchByte, byte symbol)
				{
					uint num = 1U;
					bool flag = true;
					for (int i = 7; i >= 0; i--)
					{
						uint num2 = (uint)(symbol >> i & 1);
						uint num3 = num;
						bool flag2 = flag;
						if (flag2)
						{
							uint num4 = (uint)(matchByte >> i & 1);
							num3 += 1U + num4 << 8;
							flag = (num4 == num2);
						}
						this.m_Encoders[(int)num3].Encode(rangeEncoder, num2);
						num = (num << 1 | num2);
					}
				}

				// Token: 0x060000AF RID: 175 RVA: 0x00009CD8 File Offset: 0x00009CD8
				public uint GetPrice(bool matchMode, byte matchByte, byte symbol)
				{
					uint num = 0U;
					uint num2 = 1U;
					int i = 7;
					if (matchMode)
					{
						while (i >= 0)
						{
							uint num3 = (uint)(matchByte >> i & 1);
							uint num4 = (uint)(symbol >> i & 1);
							num += this.m_Encoders[(int)((1U + num3 << 8) + num2)].GetPrice(num4);
							num2 = (num2 << 1 | num4);
							bool flag = num3 != num4;
							if (flag)
							{
								i--;
								break;
							}
							i--;
						}
					}
					while (i >= 0)
					{
						uint num5 = (uint)(symbol >> i & 1);
						num += this.m_Encoders[(int)num2].GetPrice(num5);
						num2 = (num2 << 1 | num5);
						i--;
					}
					return num;
				}

				// Token: 0x040000CA RID: 202
				private BitEncoder[] m_Encoders;
			}
		}

		// Token: 0x02000020 RID: 32
		internal class LenEncoder
		{
			// Token: 0x060000B0 RID: 176 RVA: 0x00009D9C File Offset: 0x00009D9C
			public LenEncoder()
			{
				for (uint num = 0U; num < 16U; num += 1U)
				{
					this._lowCoder[(int)num] = new BitTreeEncoder(3);
					this._midCoder[(int)num] = new BitTreeEncoder(3);
				}
			}

			// Token: 0x060000B1 RID: 177 RVA: 0x00009E28 File Offset: 0x00009E28
			public void Init(uint numPosStates)
			{
				this._choice.Init();
				this._choice2.Init();
				for (uint num = 0U; num < numPosStates; num += 1U)
				{
					this._lowCoder[(int)num].Init();
					this._midCoder[(int)num].Init();
				}
				this._highCoder.Init();
			}

			// Token: 0x060000B2 RID: 178 RVA: 0x00009E90 File Offset: 0x00009E90
			public void Encode(Encoder rangeEncoder, uint symbol, uint posState)
			{
				bool flag = symbol < 8U;
				if (flag)
				{
					this._choice.Encode(rangeEncoder, 0U);
					this._lowCoder[(int)posState].Encode(rangeEncoder, symbol);
				}
				else
				{
					symbol -= 8U;
					this._choice.Encode(rangeEncoder, 1U);
					bool flag2 = symbol < 8U;
					if (flag2)
					{
						this._choice2.Encode(rangeEncoder, 0U);
						this._midCoder[(int)posState].Encode(rangeEncoder, symbol);
					}
					else
					{
						this._choice2.Encode(rangeEncoder, 1U);
						this._highCoder.Encode(rangeEncoder, symbol - 8U);
					}
				}
			}

			// Token: 0x060000B3 RID: 179 RVA: 0x00009F30 File Offset: 0x00009F30
			public void SetPrices(uint posState, uint numSymbols, uint[] prices, uint st)
			{
				uint price = this._choice.GetPrice0();
				uint price2 = this._choice.GetPrice1();
				uint num = price2 + this._choice2.GetPrice0();
				uint num2 = price2 + this._choice2.GetPrice1();
				uint num3;
				for (num3 = 0U; num3 < 8U; num3 += 1U)
				{
					bool flag = num3 >= numSymbols;
					if (flag)
					{
						return;
					}
					prices[(int)(st + num3)] = price + this._lowCoder[(int)posState].GetPrice(num3);
				}
				while (num3 < 16U)
				{
					bool flag2 = num3 >= numSymbols;
					if (flag2)
					{
						return;
					}
					prices[(int)(st + num3)] = num + this._midCoder[(int)posState].GetPrice(num3 - 8U);
					num3 += 1U;
				}
				while (num3 < numSymbols)
				{
					prices[(int)(st + num3)] = num2 + this._highCoder.GetPrice(num3 - 8U - 8U);
					num3 += 1U;
				}
			}

			// Token: 0x040000CB RID: 203
			private BitEncoder _choice = default(BitEncoder);

			// Token: 0x040000CC RID: 204
			private BitEncoder _choice2 = default(BitEncoder);

			// Token: 0x040000CD RID: 205
			private BitTreeEncoder[] _lowCoder = new BitTreeEncoder[16];

			// Token: 0x040000CE RID: 206
			private BitTreeEncoder[] _midCoder = new BitTreeEncoder[16];

			// Token: 0x040000CF RID: 207
			private BitTreeEncoder _highCoder = new BitTreeEncoder(8);
		}

		// Token: 0x02000021 RID: 33
		internal class LenPriceTableEncoder : Encoder.LenEncoder
		{
			// Token: 0x060000B4 RID: 180 RVA: 0x000023EA File Offset: 0x000023EA
			public void SetTableSize(uint tableSize)
			{
				this._tableSize = tableSize;
			}

			// Token: 0x060000B5 RID: 181 RVA: 0x0000A030 File Offset: 0x0000A030
			public uint GetPrice(uint symbol, uint posState)
			{
				return this._prices[(int)(posState * 272U + symbol)];
			}

			// Token: 0x060000B6 RID: 182 RVA: 0x000023F4 File Offset: 0x000023F4
			private void UpdateTable(uint posState)
			{
				base.SetPrices(posState, this._tableSize, this._prices, posState * 272U);
				this._counters[(int)posState] = this._tableSize;
			}

			// Token: 0x060000B7 RID: 183 RVA: 0x0000A054 File Offset: 0x0000A054
			public void UpdateTables(uint numPosStates)
			{
				for (uint num = 0U; num < numPosStates; num += 1U)
				{
					this.UpdateTable(num);
				}
			}

			// Token: 0x060000B8 RID: 184 RVA: 0x0000A07C File Offset: 0x0000A07C
			public new void Encode(Encoder rangeEncoder, uint symbol, uint posState)
			{
				base.Encode(rangeEncoder, symbol, posState);
				uint[] counters = this._counters;
				uint num = counters[(int)posState] - 1U;
				counters[(int)posState] = num;
				bool flag = num == 0U;
				if (flag)
				{
					this.UpdateTable(posState);
				}
			}

			// Token: 0x040000D0 RID: 208
			private uint[] _prices = new uint[4352];

			// Token: 0x040000D1 RID: 209
			private uint _tableSize;

			// Token: 0x040000D2 RID: 210
			private uint[] _counters = new uint[16];
		}

		// Token: 0x02000022 RID: 34
		internal class Optimal
		{
			// Token: 0x060000BA RID: 186 RVA: 0x00002446 File Offset: 0x00002446
			public void MakeAsChar()
			{
				this.BackPrev = uint.MaxValue;
				this.Prev1IsChar = false;
			}

			// Token: 0x060000BB RID: 187 RVA: 0x00002457 File Offset: 0x00002457
			public void MakeAsShortRep()
			{
				this.BackPrev = 0U;
				this.Prev1IsChar = false;
			}

			// Token: 0x060000BC RID: 188 RVA: 0x0000A0B8 File Offset: 0x0000A0B8
			public bool IsShortRep()
			{
				return this.BackPrev == 0U;
			}

			// Token: 0x040000D3 RID: 211
			public Base.State State;

			// Token: 0x040000D4 RID: 212
			public bool Prev1IsChar;

			// Token: 0x040000D5 RID: 213
			public bool Prev2;

			// Token: 0x040000D6 RID: 214
			public uint PosPrev2;

			// Token: 0x040000D7 RID: 215
			public uint BackPrev2;

			// Token: 0x040000D8 RID: 216
			public uint Price;

			// Token: 0x040000D9 RID: 217
			public uint PosPrev;

			// Token: 0x040000DA RID: 218
			public uint BackPrev;

			// Token: 0x040000DB RID: 219
			public uint Backs0;

			// Token: 0x040000DC RID: 220
			public uint Backs1;

			// Token: 0x040000DD RID: 221
			public uint Backs2;

			// Token: 0x040000DE RID: 222
			public uint Backs3;
		}
	}
}
