using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using osu.Memory.Processes;
using SimpleDependencyInjection;

namespace osu.Memory.Objects
{
	// Token: 0x02000093 RID: 147
	public class OsuObject
	{
		// Token: 0x17000110 RID: 272
		// (get) Token: 0x060003D5 RID: 981 RVA: 0x00003ED6 File Offset: 0x000020D6
		public bool SingleComponentLoaded
		{
			get
			{
				OsuObject parent = this.Parent;
				return (parent != null) ? parent.SingleComponentLoaded : (this.BaseAddress != UIntPtr.Zero);
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x060003D6 RID: 982 RVA: 0x00003EF9 File Offset: 0x000020F9
		public virtual bool IsLoaded
		{
			get
			{
				bool result;
				if (this.SingleComponentLoaded)
				{
					result = this.Children.All(new Func<OsuObject, bool>(OsuObject.Ac.A9.Aget_IsLoadedb__4_0));
				}
				else
				{
					result = false;
				}
				return result;
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x060003D7 RID: 983 RVA: 0x00011754 File Offset: 0x0000F954
		public virtual UIntPtr BaseAddress
		{
			get
			{
				bool flag = this.pointerToBaseAddress != null;
				UIntPtr result;
				if (flag)
				{
					result = (UIntPtr)this.OsuProcess.ReadUInt32(this.pointerToBaseAddress.Value);
				}
				else
				{
					bool singleComponentLoaded = this.Parent.SingleComponentLoaded;
					if (singleComponentLoaded)
					{
						result = (UIntPtr)this.OsuProcess.ReadUInt32(this.Parent.BaseAddress + this.Offset);
					}
					else
					{
						result = UIntPtr.Zero;
					}
				}
				return result;
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x060003D8 RID: 984 RVA: 0x00003F30 File Offset: 0x00002130
		// (set) Token: 0x060003D9 RID: 985 RVA: 0x00003F38 File Offset: 0x00002138
		public OsuObject Parent { get; set; } = null;

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x060003DA RID: 986 RVA: 0x00003F41 File Offset: 0x00002141
		// (set) Token: 0x060003DB RID: 987 RVA: 0x000117D0 File Offset: 0x0000F9D0
		public OsuObject[] Children
		{
			get
			{
				return this.children.ToArray();
			}
			set
			{
				this.children = value.ToList<OsuObject>();
				foreach (OsuObject osuObject in this.children)
				{
					osuObject.Parent = this;
				}
			}
		}

		// Token: 0x060003DC RID: 988 RVA: 0x00003F4E File Offset: 0x0000214E
		public OsuObject(UIntPtr? pointerToBaseAddress = null)
		{
			this.pointerToBaseAddress = pointerToBaseAddress;
			this.OsuProcess = DependencyContainer.Get<OsuProcess>();
		}

		// Token: 0x060003DD RID: 989 RVA: 0x00003F7C File Offset: 0x0000217C
		public void Add(OsuObject osuObject)
		{
			osuObject.Parent = this;
			this.children.Add(osuObject);
		}

		// Token: 0x060003DE RID: 990 RVA: 0x00003F94 File Offset: 0x00002194
		public void Clear()
		{
			this.children.Clear();
		}

		// Token: 0x0400033E RID: 830
		protected OsuProcess OsuProcess;

		// Token: 0x0400033F RID: 831
		private UIntPtr? pointerToBaseAddress;

		// Token: 0x04000340 RID: 832
		public int Offset;

		// Token: 0x04000341 RID: 833
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private OsuObject AParentk__BackingField;

		// Token: 0x04000342 RID: 834
		private List<OsuObject> children = new List<OsuObject>();

		// Token: 0x02000094 RID: 148
		[CompilerGenerated]
		[Serializable]
		private sealed class Ac
		{
			// Token: 0x060003E1 RID: 993 RVA: 0x00003FAE File Offset: 0x000021AE
			internal bool Aget_IsLoadedb__4_0(OsuObject child)
			{
				return child.IsLoaded;
			}

			// Token: 0x04000343 RID: 835
			public static readonly OsuObject.Ac A9 = new OsuObject.Ac();

			// Token: 0x04000344 RID: 836
			public static Func<OsuObject, bool> A9__4_0;
		}
	}
}
