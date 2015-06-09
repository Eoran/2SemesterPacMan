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
    public class Books : SpriteObject
    {
        public static Rectangle rectan;
        

        public Books(Vector2 pos)
            : base(pos)
        {
            CreateAnimation("IdleUp", 1, 0, 0, 24, 24, Vector2.Zero, 1);
            PlayAnimation("IdleUp");

            rectan = CollisionRect;
            
            
            
        }
        public override void LoadContent(ContentManager content)
        {
           
                texture = content.Load<Texture2D>(@"book");
            

            base.LoadContent(content);
        }
        public override void Update(GameTime gameTime)
        {
            if(CollisionRect.Intersects(Player.rectan))
            {
                GameWorld.bookRem.Add(this);

            }
            base.Update(gameTime);
        }
    }
}
