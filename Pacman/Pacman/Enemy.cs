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
        Player player = new Player( new Vector2(10,10),10);
        private enum Direction : byte
        {
            right = 1,
            left = 2,
            up = 3,
            down = 4,
        }
        private Direction direction = (Direction)4;
        public Enemy(Vector2 pos, int player)
            : base(pos)
        {
            CreateAnimation("MoveRight", 5, 0, 0, 65, 65, new Vector2(0, 0), 5);
            CreateAnimation("MoveLeft", 5, 65, 0, 65, 65, new Vector2(0, 0), 5);
            CreateAnimation("DmgRight", 4, 185, 0, 65, 65, new Vector2(0, 0), 5);
            CreateAnimation("DmgLeft", 5, 185, 0, 65, 65, new Vector2(0, 0), 5);
            CreateAnimation("Explode", 5, 260, 0, 100, 100, new Vector2(-10, -10), 5);
            PlayAnimation("MoveRight");
        }
        public override void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>(@"sponge");

            base.LoadContent(content);
        }
        private void ChasePlayer()
        {
            
            //if (keyState.IsKeyDown(Keys.Space))
            //{
            //    if (direction == (Direction)4)
            //    {
            //        PlayAnimation("AttackDown");
            //    }
            //    if (direction == (Direction)1)
            //    {
            //        PlayAnimation("AttackRight");
            //    }
            //    if (direction == (Direction)2)
            //    {
            //        PlayAnimation("AttackLeft");
            //    }
            //    if (direction == (Direction)3)
            //    {
            //        PlayAnimation("AttackUp");
            //    }

            //    velocity += new Vector2(0, 0);
            //}
        }
        public override void Update(GameTime gameTime)
        {
            velocity = player.Position - this.Position;

            //HandleInput(Keyboard.GetState());
            

            velocity *= speed;

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            position += (velocity * deltaTime);

            base.Update(gameTime);
        }
    }
}
 
