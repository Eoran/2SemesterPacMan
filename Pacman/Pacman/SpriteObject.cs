using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Pacman
{
    public class SpriteObject
    {

        protected Texture2D texture;
        private Rectangle[] rectangles;
        public Vector2 position = Vector2.Zero;
        protected float speed;
        private int currentIndex;
        private float timeElapsed;
        protected float fps;
        private Dictionary<string, Animation> animations = new Dictionary<string, Animation>();
        public Color color = Color.White;
        private SpriteEffects effect = new SpriteEffects();
        protected Vector2 velocity;
        private float layer;
        protected float scale;
        protected Vector2 origin = Vector2.Zero;
        protected Vector2 offset;
        private Texture2D boxTexture;

        public Rectangle CollisionRect
        {
            get
            {
                return new Rectangle
                (
                    (int)(position.X + offset.X),
                    (int)(position.Y + offset.Y),
                    rectangles[0].Width, rectangles[0].Width
                );
            }
        }

        public SpriteObject(Vector2 position)
        {
            this.position = position;
            this.speed = 100;
            this.fps = 15;
            this.layer = 0;
            this.scale = 1;
            
        }
        public virtual void LoadContent(ContentManager content)
        {
            boxTexture = content.Load<Texture2D>(@"CollisionTexture");
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture, position, rectangles[currentIndex], color, 0, origin, scale, effect, layer);
            Rectangle topLine = new Rectangle(CollisionRect.X, CollisionRect.Y, CollisionRect.Width, 1);
            Rectangle bottomLine = new Rectangle(CollisionRect.X, CollisionRect.Y + CollisionRect.Height, CollisionRect.Width, 1);
            Rectangle rightLine = new Rectangle(CollisionRect.X + CollisionRect.Width, CollisionRect.Y, 1, CollisionRect.Height);
            Rectangle leftLine = new Rectangle(CollisionRect.X, CollisionRect.Y, 1, CollisionRect.Height);
#if DEBUG
            spriteBatch.Draw(boxTexture, topLine, Color.White);
            spriteBatch.Draw(boxTexture, bottomLine, Color.White);
            spriteBatch.Draw(boxTexture, rightLine, Color.White);
            spriteBatch.Draw(boxTexture, leftLine, Color.White);
#endif

        }
        public void PlayAnimation(string frameName)
        {
            rectangles = animations[frameName].Rectangles;
            //OffFuckingSet = .Offset;
        }
        public virtual void Update(GameTime gameTime)
        {
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            currentIndex = (int)(timeElapsed * fps);
            if (currentIndex > rectangles.Length - 1)
            {
                timeElapsed = 0;
                currentIndex = 0;
            }
            
        }

        protected void CreateAnimation(string name, int frames, int yPos, int xStartFrame, int width, int height, Vector2 offset, float fps)
        {
            animations.Add(name, new Animation(frames, yPos, xStartFrame, width, height, offset, fps));

        }


    }
}
