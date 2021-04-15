using System;
using System.Numerics;

namespace osu.Memory.Objects.Window
{
    public class OsuWindowManager
    {
        public OsuViewport Viewport { get; private set; }

        public Vector2 WindowSize => new Vector2(Viewport.Width, Viewport.Height);

        //TODO: this is letterboxing position, not the actual window position
        public Vector2 WindowPosition => new Vector2(Viewport.X, Viewport.Y);

        public float WindowRatio => WindowSize.Y / 480;

        public Vector2 PlayfieldSize
        {
            get
            {
                float width = 512 * WindowRatio;
                float height = 384 * WindowRatio;

                return new Vector2(width, height);
            }
        }

        public Vector2 PlayfieldPosition //topleft origin
        {
            get
            {
                float x = (WindowSize.X - PlayfieldSize.X) / 2;
                float y = (WindowSize.Y - PlayfieldSize.Y) / 4 * 3 + (-16 * WindowRatio);

                return new Vector2(x, y);
            }
        }

        public float PlayfieldRatio => PlayfieldSize.Y / 384;

        public OsuWindowManager(UIntPtr viewportPointer)
        {
            Viewport = new OsuViewport(viewportPointer);
        }

        public Vector2 ScreenToPlayfield(Vector2 screenCoords) => (screenCoords - PlayfieldPosition) / PlayfieldRatio;

        public Vector2 PlayfieldToScreen(Vector2 playfieldCoords) => (playfieldCoords * PlayfieldRatio) + PlayfieldPosition;
    }
}
