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
    class Player : SpriteObject
    {
        private static Vector2 Position;
        public static Rectangle rectan;
        public static bool isPower = false;
        private int powerCount = 600;

        public static Vector2 Position1
        {
            get { return Position; }
            set { Position = value; }
        }
        
        public enum Direction : byte
        {
            right = 1,
            left = 2,
            up = 3,
            down = 4,
        }
        public Direction direction = (Direction)4;
        public Player(Vector2 pos, int frames)
            : base(pos)
        {
            CreateAnimation("IdleUp", 1, 50, 0, 50, 50, Vector2.Zero, 1);
            CreateAnimation("RunUp", 12, 50, 0, 50, 50, Vector2.Zero, 12);
            CreateAnimation("IdleRight", 1, 100, 8, 50, 50, Vector2.Zero, 1);
            CreateAnimation("RunRight", 8, 100, 8, 50, 50, Vector2.Zero, 8);
            CreateAnimation("IdleDown", 1, 0, 0, 50, 50, Vector2.Zero, 1);
            CreateAnimation("RunDown", 12, 0, 0, 50, 50, Vector2.Zero, 12);
            CreateAnimation("IdleLeft", 1, 100, 0, 50, 50, Vector2.Zero, 1);
            CreateAnimation("RunLeft", 8, 100, 0, 50, 50, Vector2.Zero, 8);
            CreateAnimation("AttackUp", 9, 230, 0, 70, 80, new Vector2(-13, -28), 27);
            CreateAnimation("AttackRight", 9, 380, 0, 70, 80, new Vector2(10, -5), 27);
            CreateAnimation("AttackDown", 9, 150, 0, 70, 80, new Vector2(-4, -2), 27);
            CreateAnimation("AttackLeft", 9, 310, 0, 70, 70, new Vector2(-30, -4), 27);
            PlayAnimation("IdleDown");

            Position1 = pos;
        }
        public override void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>(@"playerSheet");

            base.LoadContent(content);
        }
        private void HandleInput(KeyboardState keyState)
        {
            if (keyState.IsKeyDown(Keys.W) || keyState.IsKeyDown(Keys.Up))
            {
                direction = (Direction)3;
                PlayAnimation("RunUp");
                velocity += new Vector2(0, -2);
            }
            if (keyState.IsKeyDown(Keys.A) || keyState.IsKeyDown(Keys.Left))
            {
                direction = (Direction)2;
                PlayAnimation("RunLeft");
                velocity += new Vector2(-2, 0);
            }
            if (keyState.IsKeyDown(Keys.S) || keyState.IsKeyDown(Keys.Down))
            {
                direction = (Direction)4;
                PlayAnimation("RunDown");
                velocity += new Vector2(0, 2);
            }
            if (keyState.IsKeyDown(Keys.D) || keyState.IsKeyDown(Keys.Right))
            {
                direction = (Direction)1;
                PlayAnimation("RunRight");
                velocity += new Vector2(2, 0);
            }
            if (keyState.IsKeyUp(Keys.D) && keyState.IsKeyUp(Keys.Right) && direction == (Direction)1)
            {
                
                PlayAnimation("IdleRight");
                velocity += new Vector2(0, 0);
            }
            if (keyState.IsKeyUp(Keys.W) && keyState.IsKeyUp(Keys.Up) && direction == (Direction)3)
            {

                PlayAnimation("IdleUp");
                velocity += new Vector2(0, 0);
            }
            if (keyState.IsKeyUp(Keys.A) && keyState.IsKeyUp(Keys.Left) && direction == (Direction)2)
            {

                PlayAnimation("IdleLeft");
                velocity += new Vector2(0, 0);
            }
            if (keyState.IsKeyUp(Keys.S) && keyState.IsKeyUp(Keys.Down) && direction == (Direction)4)
            {

                PlayAnimation("IdleDown");
                velocity += new Vector2(0, 0);
            }
            if (keyState.IsKeyDown(Keys.Space))
            {
                if (direction == (Direction)4)
                {
                    PlayAnimation("AttackDown");
                }
                if (direction == (Direction)1)
                {
                    PlayAnimation("AttackRight");
                }
                if (direction == (Direction)2)
                {
                    PlayAnimation("AttackLeft");
                }
                if (direction == (Direction)3)
                {
                    PlayAnimation("AttackUp");
                }
                    
                velocity += new Vector2(0, 0);
            }
        }
        public override void Update(GameTime gameTime)
        {
            if(powerCount > 0)
            {
                isPower = true;
                powerCount--;
            }
            else
            {
                isPower = false;
            }
            rectan = CollisionRect;
            Position1 = position;
            
            velocity = Vector2.Zero;

            HandleInput(Keyboard.GetState());

            velocity *= speed;

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            position += (velocity * deltaTime);
            if(CollisionRect.Intersects((Enemy.rectan)))
            {
                if(Player.isPower == false)
                {
                    position = Vector2.Zero;
                }
            }

            base.Update(gameTime);
        }
    }
}
