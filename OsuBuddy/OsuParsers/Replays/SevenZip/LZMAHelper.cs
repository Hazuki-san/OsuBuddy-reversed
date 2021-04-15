using System;
using System.IO;
using SevenZip;
using SevenZip.Compression.LZMA;

namespace OsuParsers.Replays.SevenZip
{
	// Token: 0x02000032 RID: 50
	internal class LZMAHelper
	{
		// Token: 0x0600012F RID: 303 RVA: 0x0000AB24 File Offset: 0x0000AB24
		public static MemoryStream Compress(Stream inStream)
		{
			inStream.Position = 0L;
			CoderPropID[] propIDs = new CoderPropID[]
			{
				CoderPropID.DictionarySize,
				CoderPropID.PosStateBits,
				CoderPropID.LitContextBits,
				CoderPropID.LitPosBits,
				CoderPropID.Algorithm
			};
			object[] properties = new object[]
			{
				65536,
				2,
				3,
				0,
				2
			};
			MemoryStream memoryStream = new MemoryStream();
			Encoder encoder = new Encoder();
			encoder.SetCoderProperties(propIDs, properties);
			encoder.WriteCoderProperties(memoryStream);
			for (int i = 0; i < 8; i++)
			{
				memoryStream.WriteByte((byte)(inStream.Length >> 8 * i));
			}
			encoder.Code(inStream, memoryStream, -1L, -1L, null);
			memoryStream.Flush();
			memoryStream.Position = 0L;
			return memoryStream;
		}

		// Token: 0x06000130 RID: 304 RVA: 0x0000ABF4 File Offset: 0x0000ABF4
		public static MemoryStream Decompress(Stream inStream)
		{
			Decoder decoder = new Decoder();
			byte[] array = new byte[5];
			bool flag = inStream.Read(array, 0, 5) != 5;
			if (flag)
			{
				throw new Exception("input .lzma is too short");
			}
			decoder.SetDecoderProperties(array);
			long num = 0L;
			for (int i = 0; i < 8; i++)
			{
				int num2 = inStream.ReadByte();
				bool flag2 = num2 < 0;
				if (flag2)
				{
					break;
				}
				num |= (long)((long)((ulong)((byte)num2)) << 8 * i);
			}
			long inSize = inStream.Length - inStream.Position;
			MemoryStream memoryStream = new MemoryStream();
			decoder.Code(inStream, memoryStream, inSize, num, null);
			memoryStream.Flush();
			memoryStream.Position = 0L;
			return memoryStream;
		}

		// Token: 0x06000131 RID: 305 RVA: 0x0000ACB4 File Offset: 0x0000ACB4
		public static byte[] Compress(byte[] inBytes)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream(inBytes, false))
			{
				result = LZMAHelper.Compress(memoryStream).ToArray();
			}
			return result;
		}

		// Token: 0x06000132 RID: 306 RVA: 0x0000ACF4 File Offset: 0x0000ACF4
		public static byte[] Decompress(byte[] inBytes)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream(inBytes, false))
			{
				result = LZMAHelper.Decompress(memoryStream).ToArray();
			}
			return result;
		}
	}
}
