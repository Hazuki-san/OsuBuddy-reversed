using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OsuParsers.Serialization
{
	// Token: 0x0200002F RID: 47
	internal class SerializationReader : BinaryReader
	{
		// Token: 0x060000F6 RID: 246 RVA: 0x00002730 File Offset: 0x00002730
		public SerializationReader(Stream s) : base(s, Encoding.UTF8)
		{
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x0000A2D0 File Offset: 0x0000A2D0
		public override string ReadString()
		{
			bool flag = this.ReadByte() == 0;
			string result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = base.ReadString();
			}
			return result;
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x0000A2FC File Offset: 0x0000A2FC
		public byte[] ReadByteArray()
		{
			int num = this.ReadInt32();
			bool flag = num > 0;
			byte[] result;
			if (flag)
			{
				result = this.ReadBytes(num);
			}
			else
			{
				bool flag2 = num < 0;
				if (flag2)
				{
					result = null;
				}
				else
				{
					result = new byte[0];
				}
			}
			return result;
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x0000A33C File Offset: 0x0000A33C
		public char[] ReadCharArray()
		{
			int num = this.ReadInt32();
			bool flag = num > 0;
			char[] result;
			if (flag)
			{
				result = this.ReadChars(num);
			}
			else
			{
				bool flag2 = num < 0;
				if (flag2)
				{
					result = null;
				}
				else
				{
					result = new char[0];
				}
			}
			return result;
		}

		// Token: 0x060000FA RID: 250 RVA: 0x0000A37C File Offset: 0x0000A37C
		public DateTime ReadDateTime()
		{
			return new DateTime(this.ReadInt64(), DateTimeKind.Utc);
		}

		// Token: 0x060000FB RID: 251 RVA: 0x0000A39C File Offset: 0x0000A39C
		public List<T> ReadList<T>()
		{
			int num = this.ReadInt32();
			bool flag = num < 0;
			List<T> result;
			if (flag)
			{
				result = null;
			}
			else
			{
				List<T> list = new List<T>(num);
				for (int i = 0; i < num; i++)
				{
					list.Add((T)((object)this.ReadObject()));
				}
				result = list;
			}
			return result;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x0000A3F4 File Offset: 0x0000A3F4
		public Dictionary<T, U> ReadDictionary<T, U>()
		{
			int num = this.ReadInt32();
			bool flag = num < 0;
			Dictionary<T, U> result;
			if (flag)
			{
				result = null;
			}
			else
			{
				Dictionary<T, U> dictionary = new Dictionary<T, U>();
				for (int i = 0; i < num; i++)
				{
					dictionary[(T)((object)this.ReadObject())] = (U)((object)this.ReadObject());
				}
				result = dictionary;
			}
			return result;
		}

		// Token: 0x060000FD RID: 253 RVA: 0x0000A454 File Offset: 0x0000A454
		public object ReadObject()
		{
			object result;
			switch (this.ReadByte())
			{
			case 1:
				result = this.ReadBoolean();
				break;
			case 2:
				result = this.ReadByte();
				break;
			case 3:
				result = this.ReadUInt16();
				break;
			case 4:
				result = this.ReadUInt32();
				break;
			case 5:
				result = this.ReadUInt64();
				break;
			case 6:
				result = this.ReadSByte();
				break;
			case 7:
				result = this.ReadInt16();
				break;
			case 8:
				result = this.ReadInt32();
				break;
			case 9:
				result = this.ReadInt64();
				break;
			case 10:
				result = this.ReadChar();
				break;
			case 11:
				result = base.ReadString();
				break;
			case 12:
				result = this.ReadSingle();
				break;
			case 13:
				result = this.ReadDouble();
				break;
			case 14:
				result = this.ReadDecimal();
				break;
			case 15:
				result = this.ReadDateTime();
				break;
			case 16:
				result = this.ReadByteArray();
				break;
			case 17:
				result = this.ReadCharArray();
				break;
			default:
				result = null;
				break;
			}
			return result;
		}
	}
}
