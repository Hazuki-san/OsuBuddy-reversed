using System;
using System.Collections.Generic;

namespace osu.Memory.Objects.Bindings
{
    public class BindingManager : OsuObject
    {
        public Dictionary<Bindings, int> BindingDictionary
        {
            get
            {
                var bindingDictionary = new Dictionary<Bindings, int>();

                UIntPtr items = (UIntPtr)OsuProcess.ReadUInt32(BaseAddress + 0x8);
                int dictionaryLength = OsuProcess.ReadInt32(BaseAddress + 0x1C);
                for (int i = 0; i < dictionaryLength; i++)
                {
                    UIntPtr currentItem = items + 0x8 + 0x8 * i;
                    var key = (Bindings)OsuProcess.ReadInt32(currentItem);
                    var value = (int)OsuProcess.ReadInt32(currentItem + 0x4);

                    bindingDictionary[key] = value;
                }

                return bindingDictionary;
            }
        }

        public int GetKeyCode(Bindings binding)
        {
            int key;
            if (!BindingDictionary.TryGetValue(binding, out key))
                return int.MinValue;

            return key;
        }

        public BindingManager(UIntPtr pointerToBaseAddress) : base(pointerToBaseAddress) { }
    }
}
