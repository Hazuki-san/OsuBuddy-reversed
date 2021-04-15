using osu.Memory.Processes;
using SimpleDependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace osu.Memory.Objects
{
    public class OsuObject
    {
        protected OsuProcess OsuProcess;

        public bool SingleComponentLoaded => Parent?.SingleComponentLoaded ?? true && BaseAddress != UIntPtr.Zero;

        public virtual bool IsLoaded => SingleComponentLoaded && Children.All(child => child.IsLoaded);

        private UIntPtr? pointerToBaseAddress;
        public virtual UIntPtr BaseAddress
        {
            get
            {
                if (pointerToBaseAddress.HasValue)
                    return (UIntPtr)OsuProcess.ReadUInt32(pointerToBaseAddress.Value);

                if (Parent.SingleComponentLoaded)
                    return (UIntPtr)OsuProcess.ReadUInt32(Parent.BaseAddress + Offset);

                return UIntPtr.Zero;
            }
        }

        public int Offset;

        public OsuObject Parent { get; set; } = null;

        private List<OsuObject> children = new List<OsuObject>();
        public OsuObject[] Children
        {
            get => children.ToArray();
            set
            {
                children = value.ToList();

                foreach (var child in children)
                    child.Parent = this;
            }
        }

        public OsuObject(UIntPtr? pointerToBaseAddress = null)
        {
            this.pointerToBaseAddress = pointerToBaseAddress;
            OsuProcess = DependencyContainer.Get<OsuProcess>();
        }

        public void Add(OsuObject osuObject)
        {
            osuObject.Parent = this;
            children.Add(osuObject);
        }

        public void Clear() => children.Clear();
    }
}
