using System;

namespace SevenZip.Compression.LZ
{
	// Token: 0x02000012 RID: 18
	internal interface IMatchFinder : IInWindowStream
	{
		// Token: 0x06000042 RID: 66
		void Create(uint historySize, uint keepAddBufferBefore, uint matchMaxLen, uint keepAddBufferAfter);

		// Token: 0x06000043 RID: 67
		uint GetMatches(uint[] distances);

		// Token: 0x06000044 RID: 68
		void Skip(uint num);
	}
}
