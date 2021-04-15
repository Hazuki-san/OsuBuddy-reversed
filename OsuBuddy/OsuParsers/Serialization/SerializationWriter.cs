using System;
using System.Collections.Generic;
using System.IO;

namespace OsuParsers.Serialization
{
	// Token: 0x02000030 RID: 48
	internal class SerializationWriter : BinaryWriter
	{
		// Token: 0x060000FE RID: 254 RVA: 0x00002740 File Offset: 0x00002740
		public SerializationWriter(Stream s) : base(s)
		{
		}

		// Token: 0x060000FF RID: 255 RVA: 0x0000A5B8 File Offset: 0x0000A5B8
		public override void Write(string str)
		{
			bool flag = str == null;
			if (flag)
			{
				this.Write(0);
			}
			else
			{
				this.Write(11);
				base.Write(str);
			}
		}

		// Token: 0x06000100 RID: 256 RVA: 0x0000A5F0 File Offset: 0x0000A5F0
		public void Write(DateTime dateTime)
		{
			this.Write(dateTime.ToUniversalTime().Ticks);
		}

		// Token: 0x06000101 RID: 257 RVA: 0x0000A614 File Offset: 0x0000A614
		public void Write<T, U>(IDictionary<T, U> d)
		{
			bool flag = d == null;
			if (flag)
			{
				this.Write(-1);
			}
			else
			{
				this.Write(d.Count);
				foreach (KeyValuePair<T, U> keyValuePair in d)
				{
					this.WriteObject(keyValuePair.Key);
					this.WriteObject(keyValuePair.Value);
				}
			}
		}

		// Token: 0x06000102 RID: 258 RVA: 0x0000A6A4 File Offset: 0x0000A6A4
		public void WriteObject(object obj)
		{
			bool flag = obj == null;
			if (flag)
			{
				this.Write(0);
			}
			else
			{
				string name = obj.GetType().Name;
				string text = name;
				uint num = <PrivateImplementationDetails>.ComputeStringHash(text);
				if (num <= 2386971688U)
				{
					if (num <= 765439473U)
					{
						if (num <= 679076413U)
						{
							if (num != 423635464U)
							{
								if (num == 679076413U)
								{
									if (text == "Char")
									{
										this.Write(10);
										base.Write((char)obj);
										goto IL_471;
									}
								}
							}
							else if (text == "SByte")
							{
								this.Write(6);
								this.Write((sbyte)obj);
								goto IL_471;
							}
						}
						else if (num != 697196164U)
						{
							if (num == 765439473U)
							{
								if (text == "Int16")
								{
									this.Write(7);
									this.Write((short)obj);
									goto IL_471;
								}
							}
						}
						else if (text == "Int64")
						{
							this.Write(9);
							this.Write((long)obj);
							goto IL_471;
						}
					}
					else if (num <= 1324880019U)
					{
						if (num != 1323747186U)
						{
							if (num == 1324880019U)
							{
								if (text == "UInt64")
								{
									this.Write(5);
									this.Write((ulong)obj);
									goto IL_471;
								}
							}
						}
						else if (text == "UInt16")
						{
							this.Write(3);
							this.Write((ushort)obj);
							goto IL_471;
						}
					}
					else if (num != 1615808600U)
					{
						if (num == 2386971688U)
						{
							if (text == "Double")
							{
								this.Write(13);
								this.Write((double)obj);
								goto IL_471;
							}
						}
					}
					else if (text == "String")
					{
						this.Write(11);
						base.Write((string)obj);
						goto IL_471;
					}
				}
				else if (num <= 2779444460U)
				{
					if (num <= 2642490659U)
					{
						if (num != 2615964816U)
						{
							if (num == 2642490659U)
							{
								if (text == "Byte[]")
								{
									this.Write(16);
									base.Write((byte[])obj);
									goto IL_471;
								}
							}
						}
						else if (text == "DateTime")
						{
							this.Write(15);
							this.Write((DateTime)obj);
							goto IL_471;
						}
					}
					else if (num != 2711245919U)
					{
						if (num == 2779444460U)
						{
							if (text == "Decimal")
							{
								this.Write(14);
								this.Write((decimal)obj);
								goto IL_471;
							}
						}
					}
					else if (text == "Int32")
					{
						this.Write(8);
						this.Write((int)obj);
						goto IL_471;
					}
				}
				else if (num <= 3538687084U)
				{
					if (num != 3409549631U)
					{
						if (num == 3538687084U)
						{
							if (text == "UInt32")
							{
								this.Write(4);
								this.Write((uint)obj);
								goto IL_471;
							}
						}
					}
					else if (text == "Byte")
					{
						this.Write(2);
						this.Write((byte)obj);
						goto IL_471;
					}
				}
				else if (num != 3585005533U)
				{
					if (num != 3969205087U)
					{
						if (num == 4051133705U)
						{
							if (text == "Single")
							{
								this.Write(12);
								this.Write((float)obj);
								goto IL_471;
							}
						}
					}
					else if (text == "Boolean")
					{
						this.Write(1);
						this.Write((bool)obj);
						goto IL_471;
					}
				}
				else if (text == "Char[]")
				{
					this.Write(17);
					base.Write((char[])obj);
					goto IL_471;
				}
				throw new NotImplementedException();
				IL_471:;
			}
		}
	}
}
