using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pacman
{
    class Animation
    {
        #region fields
        private Vector2 offset;

        private float fps;

        private Rectangle[] rectangles;
        #endregion
        #region properties
        public Vector2 Offset
        {
            get { return offset; }
            set { offset = value; }
        }
        public float Fps
        {
            get { return fps; }
            set { fps = value; }
        }
        public Rectangle[] Rectangles
        {
            get { return rectangles; }
            set { rectangles = value; }
        }
        #endregion

        public Animation(int frames, int yPos, int xStartFrame, int width, int height, Vector2 offset, float fps)
        {
            rectangles = new Rectangle[frames];

            for (int i = 0; i < frames; i++)
            {
                rectangles[i] = new Rectangle((i + xStartFrame) * width, yPos, width, height);
            }

            this.fps = fps;
            this.offset = offset;
        }
    }
}
