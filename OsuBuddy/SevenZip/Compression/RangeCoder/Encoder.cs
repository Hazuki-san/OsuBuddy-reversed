using System;
using System.IO;

namespace SevenZip.Compression.RangeCoder
{
	// Token: 0x0200000C RID: 12
	internal class Encoder
	{
		// Token: 0x06000019 RID: 25 RVA: 0x00002113 File Offset: 0x00002113
		public void SetStream(Stream stream)
		{
			this.Stream = stream;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000211D File Offset: 0x0000211D
		public void ReleaseStream()
		{
			this.Stream = null;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002127 File Offset: 0x00002127
		public void Init()
		{
			this.StartPosition = this.Stream.Position;
			this.Low = 0UL;
			this.Range = uint.MaxValue;
			this._cacheSize = 1U;
			this._cache = 0;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00004AC8 File Offset: 0x00004AC8
		public void FlushData()
		{
			for (int i = 0; i < 5; i++)
			{
				this.ShiftLow();
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002158 File Offset: 0x00002158
		public void FlushStream()
		{
			this.Stream.Flush();
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002167 File Offset: 0x00002167
		public void CloseStream()
		{
			this.Stream.Close();
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00004AF0 File Offset: 0x00004AF0
		public void Encode(uint start, uint size, uint total)
		{
			this.Low += (ulong)(start * (this.Range /= total));
			this.Range *= size;
			while (this.Range < 16777216U)
			{
				this.Range <<= 8;
				this.ShiftLow();
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00004B58 File Offset: 0x00004B58
		public void ShiftLow()
		{
			bool flag = (uint)this.Low < 4278190080U || (uint)(this.Low >> 32) == 1U;
			if (flag)
			{
				byte b = this._cache;
				uint num;
				do
				{
					this.Stream.WriteByte((byte)((ulong)b + (this.Low >> 32)));
					b = byte.MaxValue;
					num = this._cacheSize - 1U;
					this._cacheSize = num;
				}
				while (num > 0U);
				this._cache = (byte)((uint)this.Low >> 24);
			}
			this._cacheSize += 1U;
			this.Low = (ulong)((ulong)((uint)this.Low) << 8);
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00004BFC File Offset: 0x00004BFC
		public void EncodeDirectBits(uint v, int numTotalBits)
		{
			for (int i = numTotalBits - 1; i >= 0; i--)
			{
				this.Range >>= 1;
				bool flag = (v >> i & 1U) == 1U;
				if (flag)
				{
					this.Low += (ulong)this.Range;
				}
				bool flag2 = this.Range < 16777216U;
				if (flag2)
				{
					this.Range <<= 8;
					this.ShiftLow();
				}
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00004C7C File Offset: 0x00004C7C
		public void EncodeBit(uint size0, int numTotalBits, uint symbol)
		{
			uint num = (this.Range >> numTotalBits) * size0;
			bool flag = symbol == 0U;
			if (flag)
			{
				this.Range = num;
			}
			else
			{
				this.Low += (ulong)num;
				this.Range -= num;
			}
			while (this.Range < 16777216U)
			{
				this.Range <<= 8;
				this.ShiftLow();
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00004CF4 File Offset: 0x00004CF4
		public long GetProcessedSizeAdd()
		{
			return (long)((ulong)this._cacheSize + (ulong)this.Stream.Position - (ulong)this.StartPosition + 4UL);
		}

		// Token: 0x04000017 RID: 23
		public const uint kTopValue = 16777216U;

		// Token: 0x04000018 RID: 24
		private Stream Stream;

		// Token: 0x04000019 RID: 25
		public ulong Low;

		// Token: 0x0400001A RID: 26
		public uint Range;

		// Token: 0x0400001B RID: 27
		private uint _cacheSize;

		// Token: 0x0400001C RID: 28
		private byte _cache;

		// Token: 0x0400001D RID: 29
		private long StartPosition;
	}
}
