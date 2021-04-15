using System;
using osu.Memory.Processes.Enums;

namespace osu.Memory.Processes
{
	// Token: 0x0200008B RID: 139
	public class MemoryRegion
	{
		// Token: 0x17000104 RID: 260
		// (get) Token: 0x0600039F RID: 927 RVA: 0x00003D56 File Offset: 0x00003D56
		// (set) Token: 0x060003A0 RID: 928 RVA: 0x00003D5E File Offset: 0x00003D5E
		public UIntPtr BaseAddress { get; private set; }

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x060003A1 RID: 929 RVA: 0x00003D67 File Offset: 0x00003D67
		// (set) Token: 0x060003A2 RID: 930 RVA: 0x00003D6F File Offset: 0x00003D6F
		public UIntPtr RegionSize { get; private set; }

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x060003A3 RID: 931 RVA: 0x00003D78 File Offset: 0x00003D78
		// (set) Token: 0x060003A4 RID: 932 RVA: 0x00003D80 File Offset: 0x00003D80
		public UIntPtr Start { get; private set; }

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x060003A5 RID: 933 RVA: 0x00003D89 File Offset: 0x00003D89
		// (set) Token: 0x060003A6 RID: 934 RVA: 0x00003D91 File Offset: 0x00003D91
		public UIntPtr End { get; private set; }

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x060003A7 RID: 935 RVA: 0x00003D9A File Offset: 0x00003D9A
		// (set) Token: 0x060003A8 RID: 936 RVA: 0x00003DA2 File Offset: 0x00003DA2
		public MemoryState State { get; private set; }

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x060003A9 RID: 937 RVA: 0x00003DAB File Offset: 0x00003DAB
		// (set) Token: 0x060003AA RID: 938 RVA: 0x00003DB3 File Offset: 0x00003DB3
		public MemoryProtect Protect { get; private set; }

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x060003AB RID: 939 RVA: 0x00003DBC File Offset: 0x00003DBC
		// (set) Token: 0x060003AC RID: 940 RVA: 0x00003DC4 File Offset: 0x00003DC4
		public MemoryType Type { get; private set; }

		// Token: 0x060003AD RID: 941 RVA: 0x0001115C File Offset: 0x0001115C
		public MemoryRegion(MemoryBasicInformation.MEMORY_BASIC_INFORMATION_32 basicInformation)
		{
			this.BaseAddress = basicInformation.BaseAddress;
			this.RegionSize = basicInformation.RegionSize;
			this.State = basicInformation.State;
			this.Protect = basicInformation.Protect;
			this.Type = basicInformation.Type;
		}
	}
}
