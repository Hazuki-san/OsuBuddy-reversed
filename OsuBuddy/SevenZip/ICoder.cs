using System;
using System.IO;

namespace SevenZip
{
	// Token: 0x02000006 RID: 6
	internal interface ICoder
	{
		// Token: 0x0600000B RID: 11
		void Code(Stream inStream, Stream outStream, long inSize, long outSize, ICodeProgress progress);
	}
}
