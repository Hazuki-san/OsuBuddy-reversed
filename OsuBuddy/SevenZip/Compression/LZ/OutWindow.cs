using System;
using System.IO;

namespace SevenZip.Compression.LZ
{
	// Token: 0x02000015 RID: 21
	internal class OutWindow
	{
		// Token: 0x06000061 RID: 97 RVA: 0x000061C8 File Offset: 0x000061C8
		public void Create(uint windowSize)
		{
			bool flag = this._windowSize != windowSize;
			if (flag)
			{
				this._buffer = new byte[windowSize];
			}
			this._windowSize = windowSize;
			this._pos = 0U;
			this._streamPos = 0U;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x0000620C File Offset: 0x0000620C
		public void Init(Stream stream, bool solid)
		{
			this.ReleaseStream();
			this._stream = stream;
			bool flag = !solid;
			if (flag)
			{
				this._streamPos = 0U;
				this._pos = 0U;
				this.TrainSize = 0U;
			}
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00006248 File Offset: 0x00006248
		public bool Train(Stream stream)
		{
			long length = stream.Length;
			uint num = (length < (long)((ulong)this._windowSize)) ? ((uint)length) : this._windowSize;
			this.TrainSize = num;
			stream.Position = length - (long)((ulong)num);
			this._streamPos = (this._pos = 0U);
			while (num > 0U)
			{
				uint num2 = this._windowSize - this._pos;
				bool flag = num < num2;
				if (flag)
				{
					num2 = num;
				}
				int num3 = stream.Read(this._buffer, (int)this._pos, (int)num2);
				bool flag2 = num3 == 0;
				if (flag2)
				{
					return false;
				}
				num -= (uint)num3;
				this._pos += (uint)num3;
				this._streamPos += (uint)num3;
				bool flag3 = this._pos == this._windowSize;
				if (flag3)
				{
					this._streamPos = (this._pos = 0U);
				}
			}
			return true;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00002276 File Offset: 0x00002276
		public void ReleaseStream()
		{
			this.Flush();
			this._stream = null;
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00006338 File Offset: 0x00006338
		public void Flush()
		{
			uint num = this._pos - this._streamPos;
			bool flag = num == 0U;
			if (!flag)
			{
				this._stream.Write(this._buffer, (int)this._streamPos, (int)num);
				bool flag2 = this._pos >= this._windowSize;
				if (flag2)
				{
					this._pos = 0U;
				}
				this._streamPos = this._pos;
			}
		}

		// Token: 0x06000066 RID: 102 RVA: 0x000063A0 File Offset: 0x000063A0
		public void CopyBlock(uint distance, uint len)
		{
			uint num = this._pos - distance - 1U;
			bool flag = num >= this._windowSize;
			if (flag)
			{
				num += this._windowSize;
			}
			while (len > 0U)
			{
				bool flag2 = num >= this._windowSize;
				if (flag2)
				{
					num = 0U;
				}
				byte[] buffer = this._buffer;
				uint pos = this._pos;
				this._pos = pos + 1U;
				buffer[(int)pos] = this._buffer[(int)num++];
				bool flag3 = this._pos >= this._windowSize;
				if (flag3)
				{
					this.Flush();
				}
				len -= 1U;
			}
		}

		// Token: 0x06000067 RID: 103 RVA: 0x0000643C File Offset: 0x0000643C
		public void PutByte(byte b)
		{
			byte[] buffer = this._buffer;
			uint pos = this._pos;
			this._pos = pos + 1U;
			buffer[(int)pos] = b;
			bool flag = this._pos >= this._windowSize;
			if (flag)
			{
				this.Flush();
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00006480 File Offset: 0x00006480
		public byte GetByte(uint distance)
		{
			uint num = this._pos - distance - 1U;
			bool flag = num >= this._windowSize;
			if (flag)
			{
				num += this._windowSize;
			}
			return this._buffer[(int)num];
		}

		// Token: 0x0400004B RID: 75
		private byte[] _buffer = null;

		// Token: 0x0400004C RID: 76
		private uint _pos;

		// Token: 0x0400004D RID: 77
		private uint _windowSize = 0U;

		// Token: 0x0400004E RID: 78
		private uint _streamPos;

		// Token: 0x0400004F RID: 79
		private Stream _stream;

		// Token: 0x04000050 RID: 80
		public uint TrainSize = 0U;
	}
}
