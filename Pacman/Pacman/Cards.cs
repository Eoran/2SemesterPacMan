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
    public class Cards : SpriteObject
    {
  
        public static Rectangle rectan;
        

        public Cards(Vector2 pos, int frames)
            : base(pos)
        {
            CreateAnimation("IdleUp", 1, 1, 0, 32, 32, Vector2.Zero, 1);
            PlayAnimation("IdleUp");

            rectan = CollisionRect;
          
        }
        public override void LoadContent(ContentManager content)
        {

                texture = content.Load<Texture2D>(@"card");

            base.LoadContent(content);
        }
        public override void Update(GameTime gameTime)
        {
            if(CollisionRect.Intersects(Player.rectan))
            {
              
                    Player.PowerCount = 600;
                    GameWorld.cardRem.Add(this);
                
            }
            base.Update(gameTime);
        }
    }
}
