using System;
using System.Collections.Generic;
using System.Linq;
using osu.Memory.Processes;
using SimpleDependencyInjection;

namespace osu.Memory.Objects
{
	// Token: 0x02000093 RID: 147
	public class OsuObject
	{
		// Token: 0x17000110 RID: 272
		// (get) Token: 0x060003D5 RID: 981 RVA: 0x00003ED6 File Offset: 0x00003ED6
		public bool SingleComponentLoaded
		{
			get
			{
				OsuObject parent = this.Parent;
				return (parent != null) ? parent.SingleComponentLoaded : (this.BaseAddress != UIntPtr.Zero);
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x060003D6 RID: 982 RVA: 0x00003EF9 File Offset: 0x00003EF9
		public virtual bool IsLoaded
		{
			get
			{
				bool result;
				if (this.SingleComponentLoaded)
				{
					result = this.Children.All((OsuObject child) => child.IsLoaded);
				}
				else
				{
					result = false;
				}
				return result;
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x060003D7 RID: 983 RVA: 0x00011754 File Offset: 0x00011754
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
		// (get) Token: 0x060003D8 RID: 984 RVA: 0x00003F30 File Offset: 0x00003F30
		// (set) Token: 0x060003D9 RID: 985 RVA: 0x00003F38 File Offset: 0x00003F38
		public OsuObject Parent { get; set; } = null;

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x060003DA RID: 986 RVA: 0x00003F41 File Offset: 0x00003F41
		// (set) Token: 0x060003DB RID: 987 RVA: 0x000117D0 File Offset: 0x000117D0
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

		// Token: 0x060003DC RID: 988 RVA: 0x00003F4E File Offset: 0x00003F4E
		public OsuObject(UIntPtr? pointerToBaseAddress = null)
		{
			this.pointerToBaseAddress = pointerToBaseAddress;
			this.OsuProcess = DependencyContainer.Get<OsuProcess>();
		}

		// Token: 0x060003DD RID: 989 RVA: 0x00003F7C File Offset: 0x00003F7C
		public void Add(OsuObject osuObject)
		{
			osuObject.Parent = this;
			this.children.Add(osuObject);
		}

		// Token: 0x060003DE RID: 990 RVA: 0x00003F94 File Offset: 0x00003F94
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

		// Token: 0x04000342 RID: 834
		private List<OsuObject> children = new List<OsuObject>();
	}
}
