using osu.Enums.Beatmaps;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace osu.Memory.Objects.Player.Beatmaps.Objects
{
    public class OsuSlider : OsuHitObject
    {
        public List<(Vector2 p1, Vector2 p2)> SliderCurveSmoothLines { get; set; }
        public List<double> CumulativeLengths { get; set; }

        public int Repeats { get; set; }
        public double PixelLength { get; set; }
        public CurveType CurveType { get; set; }

        public OsuSlider(int startTime, int endTime, Vector2 position, int repeats, double pixelLength, CurveType curveType,
            List<(Vector2 p1, Vector2 p2)> sliderCurveSmoothLines, List<double> cumulativeLengths)
            : base(startTime, endTime, position)
        {
            Repeats = repeats;
            PixelLength = pixelLength;
            CurveType = curveType;

            SliderCurveSmoothLines = sliderCurveSmoothLines;
            CumulativeLengths = cumulativeLengths;
        }

        public Vector2 PositionAtTime(int time)
        {
            if (SliderCurveSmoothLines.Count == 0)
                return Position;

            if (time < StartTime || time > EndTime)
                return Position;

            float pos = (time - StartTime) / ((float)(EndTime - StartTime) / Repeats);

            if (pos % 2 > 1)
                pos = 1 - (pos % 1);
            else
                pos = (pos % 1);

            float lengthRequired = (float)(PixelLength * pos);
            return positionAtLength(lengthRequired);
        }

        private Vector2 positionAtLength(float length)
        {
            if (SliderCurveSmoothLines.Count == 0 || CumulativeLengths.Count == 0)
                return Position;

            if (length == 0)
                return SliderCurveSmoothLines[0].p1;

            double end = CumulativeLengths[CumulativeLengths.Count - 1];
            if (length >= end)
                return SliderCurveSmoothLines[SliderCurveSmoothLines.Count - 1].p2;

            int i = CumulativeLengths.BinarySearch(length);
            if (i < 0)
                i = Math.Min(~i, CumulativeLengths.Count - 1);

            double lengthNext = CumulativeLengths[i];
            double lengthPrevious = i == 0 ? 0 : CumulativeLengths[i - 1];

            Vector2 res = SliderCurveSmoothLines[i].p1;

            if (lengthNext != lengthPrevious)
                res += (SliderCurveSmoothLines[i].p2 - SliderCurveSmoothLines[i].p1) * (float)((length - lengthPrevious) / (lengthNext - lengthPrevious));

            return res;
        }
    }
}
