using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using osu.Memory.Processes.Enums;

namespace osu.Memory.Processes
{
	// Token: 0x0200008B RID: 139
	public class MemoryRegion
	{
		// Token: 0x17000104 RID: 260
		// (get) Token: 0x0600039F RID: 927 RVA: 0x00003D56 File Offset: 0x00001F56
		// (set) Token: 0x060003A0 RID: 928 RVA: 0x00003D5E File Offset: 0x00001F5E
		public UIntPtr BaseAddress { get; private set; }

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x060003A1 RID: 929 RVA: 0x00003D67 File Offset: 0x00001F67
		// (set) Token: 0x060003A2 RID: 930 RVA: 0x00003D6F File Offset: 0x00001F6F
		public UIntPtr RegionSize { get; private set; }

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x060003A3 RID: 931 RVA: 0x00003D78 File Offset: 0x00001F78
		// (set) Token: 0x060003A4 RID: 932 RVA: 0x00003D80 File Offset: 0x00001F80
		public UIntPtr Start { get; private set; }

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x060003A5 RID: 933 RVA: 0x00003D89 File Offset: 0x00001F89
		// (set) Token: 0x060003A6 RID: 934 RVA: 0x00003D91 File Offset: 0x00001F91
		public UIntPtr End { get; private set; }

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x060003A7 RID: 935 RVA: 0x00003D9A File Offset: 0x00001F9A
		// (set) Token: 0x060003A8 RID: 936 RVA: 0x00003DA2 File Offset: 0x00001FA2
		public MemoryState State { get; private set; }

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x060003A9 RID: 937 RVA: 0x00003DAB File Offset: 0x00001FAB
		// (set) Token: 0x060003AA RID: 938 RVA: 0x00003DB3 File Offset: 0x00001FB3
		public MemoryProtect Protect { get; private set; }

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x060003AB RID: 939 RVA: 0x00003DBC File Offset: 0x00001FBC
		// (set) Token: 0x060003AC RID: 940 RVA: 0x00003DC4 File Offset: 0x00001FC4
		public MemoryType Type { get; private set; }

		// Token: 0x060003AD RID: 941 RVA: 0x0001115C File Offset: 0x0000F35C
		public MemoryRegion(MemoryBasicInformation.MEMORY_BASIC_INFORMATION_32 basicInformation)
		{
			this.BaseAddress = basicInformation.BaseAddress;
			this.RegionSize = basicInformation.RegionSize;
			this.State = basicInformation.State;
			this.Protect = basicInformation.Protect;
			this.Type = basicInformation.Type;
		}

		// Token: 0x04000318 RID: 792
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private UIntPtr ABaseAddressk__BackingField;

		// Token: 0x04000319 RID: 793
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private UIntPtr ARegionSizek__BackingField;

		// Token: 0x0400031A RID: 794
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private UIntPtr AStartk__BackingField;

		// Token: 0x0400031B RID: 795
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private UIntPtr AEndk__BackingField;

		// Token: 0x0400031C RID: 796
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MemoryState AStatek__BackingField;

		// Token: 0x0400031D RID: 797
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MemoryProtect AProtectk__BackingField;

		// Token: 0x0400031E RID: 798
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MemoryType ATypek__BackingField;
	}
}
