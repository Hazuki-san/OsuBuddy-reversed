using System;
using System.IO;

namespace SevenZip.Compression.LZ
{
	// Token: 0x02000014 RID: 20
	internal class InWindow
	{
		// Token: 0x06000054 RID: 84 RVA: 0x00005EA8 File Offset: 0x000040A8
		public void MoveBlock()
		{
			uint num = this._bufferOffset + this._pos - this._keepSizeBefore;
			bool flag = num > 0U;
			if (flag)
			{
				num -= 1U;
			}
			uint num2 = this._bufferOffset + this._streamPos - num;
			for (uint num3 = 0U; num3 < num2; num3 += 1U)
			{
				this._bufferBase[(int)num3] = this._bufferBase[(int)(num + num3)];
			}
			this._bufferOffset -= num;
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00005F1C File Offset: 0x0000411C
		public virtual void ReadBlock()
		{
			bool streamEndWasReached = this._streamEndWasReached;
			if (!streamEndWasReached)
			{
				for (;;)
				{
					int num = (int)(0U - this._bufferOffset + this._blockSize - this._streamPos);
					bool flag = num == 0;
					if (flag)
					{
						break;
					}
					int num2 = this._stream.Read(this._bufferBase, (int)(this._bufferOffset + this._streamPos), num);
					bool flag2 = num2 == 0;
					if (flag2)
					{
						goto Block_3;
					}
					this._streamPos += (uint)num2;
					bool flag3 = this._streamPos >= this._pos + this._keepSizeAfter;
					if (flag3)
					{
						this._posLimit = this._streamPos - this._keepSizeAfter;
					}
				}
				return;
				Block_3:
				this._posLimit = this._streamPos;
				uint num3 = this._bufferOffset + this._posLimit;
				bool flag4 = num3 > this._pointerToLastSafePosition;
				if (flag4)
				{
					this._posLimit = this._pointerToLastSafePosition - this._bufferOffset;
				}
				this._streamEndWasReached = true;
			}
		}

		// Token: 0x06000056 RID: 86 RVA: 0x000021E7 File Offset: 0x000003E7
		private void Free()
		{
			this._bufferBase = null;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00006020 File Offset: 0x00004220
		public void Create(uint keepSizeBefore, uint keepSizeAfter, uint keepSizeReserv)
		{
			this._keepSizeBefore = keepSizeBefore;
			this._keepSizeAfter = keepSizeAfter;
			uint num = keepSizeBefore + keepSizeAfter + keepSizeReserv;
			bool flag = this._bufferBase == null || this._blockSize != num;
			if (flag)
			{
				this.Free();
				this._blockSize = num;
				this._bufferBase = new byte[this._blockSize];
			}
			this._pointerToLastSafePosition = this._blockSize - keepSizeAfter;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000021F1 File Offset: 0x000003F1
		public void SetStream(Stream stream)
		{
			this._stream = stream;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x000021FB File Offset: 0x000003FB
		public void ReleaseStream()
		{
			this._stream = null;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00002205 File Offset: 0x00000405
		public void Init()
		{
			this._bufferOffset = 0U;
			this._pos = 0U;
			this._streamPos = 0U;
			this._streamEndWasReached = false;
			this.ReadBlock();
		}

		// Token: 0x0600005B RID: 91 RVA: 0x0000608C File Offset: 0x0000428C
		public void MovePos()
		{
			this._pos += 1U;
			bool flag = this._pos > this._posLimit;
			if (flag)
			{
				uint num = this._bufferOffset + this._pos;
				bool flag2 = num > this._pointerToLastSafePosition;
				if (flag2)
				{
					this.MoveBlock();
				}
				this.ReadBlock();
			}
		}

		// Token: 0x0600005C RID: 92 RVA: 0x000060E8 File Offset: 0x000042E8
		public byte GetIndexByte(int index)
		{
			return this._bufferBase[(int)(checked((IntPtr)(unchecked((ulong)(this._bufferOffset + this._pos) + (ulong)((long)index)))))];
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00006114 File Offset: 0x00004314
		public uint GetMatchLen(int index, uint distance, uint limit)
		{
			bool streamEndWasReached = this._streamEndWasReached;
			if (streamEndWasReached)
			{
				bool flag = (ulong)this._pos + (ulong)((long)index) + (ulong)limit > (ulong)this._streamPos;
				if (flag)
				{
					limit = this._streamPos - (uint)((ulong)this._pos + (ulong)((long)index));
				}
			}
			distance += 1U;
			uint num = this._bufferOffset + this._pos + (uint)index;
			uint num2 = 0U;
			while (num2 < limit && this._bufferBase[(int)(num + num2)] == this._bufferBase[(int)(num + num2 - distance)])
			{
				num2 += 1U;
			}
			return num2;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x000061A8 File Offset: 0x000043A8
		public uint GetNumAvailableBytes()
		{
			return this._streamPos - this._pos;
		}

		// Token: 0x0600005F RID: 95 RVA: 0x0000222B File Offset: 0x0000042B
		public void ReduceOffsets(int subValue)
		{
			this._bufferOffset += (uint)subValue;
			this._posLimit -= (uint)subValue;
			this._pos -= (uint)subValue;
			this._streamPos -= (uint)subValue;
		}

		// Token: 0x04000040 RID: 64
		public byte[] _bufferBase = null;

		// Token: 0x04000041 RID: 65
		private Stream _stream;

		// Token: 0x04000042 RID: 66
		private uint _posLimit;

		// Token: 0x04000043 RID: 67
		private bool _streamEndWasReached;

		// Token: 0x04000044 RID: 68
		private uint _pointerToLastSafePosition;

		// Token: 0x04000045 RID: 69
		public uint _bufferOffset;

		// Token: 0x04000046 RID: 70
		public uint _blockSize;

		// Token: 0x04000047 RID: 71
		public uint _pos;

		// Token: 0x04000048 RID: 72
		private uint _keepSizeBefore;

		// Token: 0x04000049 RID: 73
		private uint _keepSizeAfter;

		// Token: 0x0400004A RID: 74
		public uint _streamPos;
	}
}
