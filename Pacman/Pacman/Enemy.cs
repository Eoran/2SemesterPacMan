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
    class Enemy : SpriteObject
    {
        private Vector2 Position;
        public static Rectangle rectan;
        
       
        
        public Enemy(Vector2 pos, int player)
            : base(pos)
        {
            CreateAnimation("MoveRight", 5, 0, 0, 65, 65, new Vector2(0, 0), 5);
            CreateAnimation("MoveLeft", 5, 65, 0, 65, 65, new Vector2(0, 0), 5);
            CreateAnimation("DmgRight", 4, 185, 0, 65, 65, new Vector2(0, 0), 5);
            CreateAnimation("DmgLeft", 5, 185, 0, 65, 65, new Vector2(0, 0), 5);
            CreateAnimation("Explode", 5, 260, 0, 100, 100, new Vector2(-10, -10), 5);
            PlayAnimation("MoveRight");

            Position = pos;
        }
        public override void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>(@"sponge");

            base.LoadContent(content);
        }
        private void ChasePlayer()
        {
            
   
        }
        public override void Update(GameTime gameTime)
        {
            rectan = CollisionRect;
            //if (Player.isPower == false)
            //{
            //    velocity = Player.Position1 - this.position;
            //}
            //else
            //{
            //    velocity = Player.Position1 + this.position;
            //}

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (CollisionRect.Intersects((Player.rectan)))
            {
                if(Player.isPower == true)
                {
                    position = new Vector2(100, 100);
                }
                
            }

            position += (velocity * deltaTime);

            base.Update(gameTime);
        }
    }
}
 
