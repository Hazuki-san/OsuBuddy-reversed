using osu.Enums;
using osu.Enums.Beatmaps;
using osu.Memory.Objects.Player.Beatmaps.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace osu.Memory.Objects.Player
{
    public class OsuHitObjectManager : OsuObject
    {
        public override bool IsLoaded => base.IsLoaded && HitObjectsCount > 0;

        public Mods CurrentMods
        {
            get
            {
                UIntPtr modsObjectPointer = (UIntPtr)OsuProcess.ReadUInt32(BaseAddress + 0x34);
                int encryptedValue = OsuProcess.ReadInt32(modsObjectPointer + 0x08);
                int decryptionKey = OsuProcess.ReadInt32(modsObjectPointer + 0x0C);

                return (Mods)(encryptedValue ^ decryptionKey);
            }
        }

        public int CurrentHitObjectIndex => OsuProcess.ReadInt32(BaseAddress + 0x8C);

        public int HitObjectsCount => OsuProcess.ReadInt32(BaseAddress + 0x90);

        public List<OsuHitObject> HitObjects
        {
            get
            {
                bool isAddressValid(UIntPtr address) => address != UIntPtr.Zero && OsuProcess.ReadInt32(address) != 0;

                var hitObjects = new List<OsuHitObject>();

                UIntPtr hitObjectListItemsPointer() => (UIntPtr)OsuProcess.ReadUInt32((UIntPtr)OsuProcess.ReadUInt32(BaseAddress + 0x48) + 0x4);

                for (int i = 0; i < HitObjectsCount; i++)
                {
                    start:
                    OsuHitObject hitObject = null;

                    UIntPtr hitObjectPointer = (UIntPtr)OsuProcess.ReadUInt32(hitObjectListItemsPointer() + 0x8 + 0x4 * i);
                    if (!isAddressValid(hitObjectPointer))
                        goto start;

                    HitObjectType type = (HitObjectType)OsuProcess.ReadInt32(hitObjectPointer + 0x18);
                    type &= ~HitObjectType.ComboOffset;
                    type &= ~HitObjectType.NewCombo;

                    int startTime = OsuProcess.ReadInt32(hitObjectPointer + 0x10);
                    int endTime = OsuProcess.ReadInt32(hitObjectPointer + 0x14);
                    Vector2 position = new Vector2(OsuProcess.ReadFloat(hitObjectPointer + 0x38), OsuProcess.ReadFloat(hitObjectPointer + 0x3C));

                    switch (type)
                    {
                        case HitObjectType.Circle:
                            hitObject = new OsuHitCircle(startTime, endTime, position);
                            break;
                        case HitObjectType.Slider:
                            var sliderCurveSmoothLines = new List<(Vector2 p1, Vector2 p2)>();
                            var cumulativeLengths = new List<double>();

                            UIntPtr sliderCurveSmoothLinesPointer = (UIntPtr)OsuProcess.ReadUInt32(hitObjectPointer + 0xC4);
                            UIntPtr cumulativeLengthsPointer = (UIntPtr)OsuProcess.ReadUInt32(hitObjectPointer + 0xC8);

                            if (!isAddressValid(sliderCurveSmoothLinesPointer) || !isAddressValid(cumulativeLengthsPointer))
                                goto start;

                            UIntPtr sliderCurveSmoothLinesItems = (UIntPtr)OsuProcess.ReadUInt32(sliderCurveSmoothLinesPointer + 0x4);
                            UIntPtr cumulativeLengthsItems = (UIntPtr)OsuProcess.ReadUInt32(cumulativeLengthsPointer + 0x4);

                            if (!isAddressValid(sliderCurveSmoothLinesItems) || !isAddressValid(cumulativeLengthsItems))
                                goto start;

                            int sliderCurveSmoothLinesCount = OsuProcess.ReadInt32(sliderCurveSmoothLinesPointer + 0xC);
                            int cumulativeLengthsCount = OsuProcess.ReadInt32(sliderCurveSmoothLinesPointer + 0xC);

                            for (int j = 0; j < sliderCurveSmoothLinesCount; j++)
                            {
                                UIntPtr item = (UIntPtr)OsuProcess.ReadUInt32(sliderCurveSmoothLinesItems + 0x8 + 0x4 * j);

                                Vector2 p1 = new Vector2(OsuProcess.ReadFloat(item + 0x8), OsuProcess.ReadFloat(item + 0xC));
                                Vector2 p2 = new Vector2(OsuProcess.ReadFloat(item + 0x10), OsuProcess.ReadFloat(item + 0x14));

                                sliderCurveSmoothLines.Add((p1, p2));
                            }

                            for (int j = 0; j < cumulativeLengthsCount; j++)
                            {
                                double item = OsuProcess.ReadDouble(cumulativeLengthsItems + 0x8 + 0x8 * j);

                                cumulativeLengths.Add(item);
                            }

                            int repeats = OsuProcess.ReadInt32(hitObjectPointer + 0x20);
                            double pixelLength = OsuProcess.ReadDouble(hitObjectPointer + 0x8);
                            CurveType curveType = (CurveType)OsuProcess.ReadInt32(hitObjectPointer + 0xE8);

                            hitObject = new OsuSlider(startTime, endTime, position, repeats, pixelLength, curveType, sliderCurveSmoothLines, cumulativeLengths);
                            break;
                        case HitObjectType.Spinner:
                            hitObject = new OsuSpinner(startTime, endTime, position);
                            break;
                    }

                    hitObjects.Add(hitObject);
                }

                return hitObjects;
            }
        }

        public HitState GetHitState(int index)
        {
            UIntPtr hitObjectListPointer = (UIntPtr)OsuProcess.ReadUInt32(BaseAddress + 0x48);
            UIntPtr hitObjectListItemsPointer = (UIntPtr)OsuProcess.ReadUInt32(hitObjectListPointer + 0x4);
            UIntPtr hitObjectPointer = (UIntPtr)OsuProcess.ReadUInt32(hitObjectListItemsPointer + 0x8 + 0x4 * index);

            HitObjectType type = (HitObjectType)OsuProcess.ReadInt32(hitObjectPointer + 0x18);
            type &= ~HitObjectType.ComboOffset;
            type &= ~HitObjectType.NewCombo;

            var hitState = OsuProcess.ReadBool(hitObjectPointer + 0x84) ? HitState.Hit : HitState.NotHit;

            switch (type)
            {
                case HitObjectType.Slider:
                    UIntPtr startHitCirclePointer = (UIntPtr)OsuProcess.ReadUInt32(hitObjectPointer + 0xCC);

                    return OsuProcess.ReadBool(startHitCirclePointer + 0x84) ? hitState | HitState.SliderStartHit : hitState;
                default:
                    return hitState;
            }
        }
    }
}