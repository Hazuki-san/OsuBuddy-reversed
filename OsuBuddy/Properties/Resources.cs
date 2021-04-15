using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace OsuBuddy.Properties
{
	// Token: 0x020000BA RID: 186
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x060004C2 RID: 1218 RVA: 0x0000390A File Offset: 0x0000390A
		internal Resources()
		{
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x060004C3 RID: 1219 RVA: 0x00017F1C File Offset: 0x00017F1C
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				bool flag = Resources.resourceMan == null;
				if (flag)
				{
					ResourceManager resourceManager = new ResourceManager("OsuBuddy.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x060004C4 RID: 1220 RVA: 0x00017F64 File Offset: 0x00017F64
		// (set) Token: 0x060004C5 RID: 1221 RVA: 0x000047E1 File Offset: 0x000047E1
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x04000499 RID: 1177
		private static ResourceManager resourceMan;

		// Token: 0x0400049A RID: 1178
		private static CultureInfo resourceCulture;
	}
}
