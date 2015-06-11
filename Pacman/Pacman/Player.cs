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
        private static int powerCount = 0;
        private int lifes = 3;

        public static int PowerCount
        {
            get { return Player.powerCount; }
            set { Player.powerCount = value; }
        }

        public static Vector2 Position1
        {
            get { return Position; }
            set { Position = value; }
        }

        public int Lifes
        {
            get { return lifes; }
        }

        public enum Direction : byte
        {
            right = 1,
            left = 2,
            up = 3,
            down = 4,
        }
        public Direction direction = (Direction)4;
        public Player(Vector2 pos)
            : base(pos)
        {
            CreateAnimation("IdleUp", 1, 0, 12, 28, 32, Vector2.Zero, 1);
            CreateAnimation("RunUp", 4, 0, 12, 28, 32, Vector2.Zero, 12);
            CreateAnimation("IdleRight", 1, 0, 8, 28, 32, Vector2.Zero, 1);
            CreateAnimation("RunRight", 4, 0, 8, 28, 32, Vector2.Zero, 8);
            CreateAnimation("IdleDown", 1, 0, 0, 28, 32, Vector2.Zero, 1);
            CreateAnimation("RunDown", 4, 0, 0, 28, 32, Vector2.Zero, 50);
            CreateAnimation("IdleLeft", 1, 0, 4, 28, 32, Vector2.Zero, 1);
            CreateAnimation("RunLeft", 4, 0, 4, 28, 32, Vector2.Zero, 8);

            
            PlayAnimation("IdleUp");

            Position1 = pos;
            

        }
        public override void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>(@"DonePlayer");

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

            
        }
        public override void Update(GameTime gameTime)
        {
            if (position.X < -32) 
            {
                position = new Vector2(704,320);
            }
            else if(position.X > 704)
            {
                position = new Vector2(-32, 320);
            }
            if (powerCount > 0)
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
            
            position = Position1;

            velocity = Vector2.Zero;

            HandleInput(Keyboard.GetState());

            velocity *= speed;

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (Enemy ene in GameWorld.enemyList)
            {
                if (CollisionRect.Intersects((ene.CollisionRect)))
                {
                    
                    if (isPower == false)
                    {
                        
                        if (Lifes != 0)
                        {
                            lifes = Lifes - 1;
                            position = new Vector2(300, 32);
                            direction = (Direction)4;
                            foreach (Enemy enemy in GameWorld.enemyList)
                            {
                                enemy.Reset();
                            }
                        }
                        else
                        {
                            GameWorld.gameOver = true;
                        }
                    }
                }
            }
            
            foreach(tiles item in GameWorld.tiles)
            {
                Rectangle overlap = Rectangle.Intersect(CollisionRect, item.CollisionRect);
                if (overlap.Height < overlap.Width && item.CollisionRect.Y > CollisionRect.Y)
                {
                    position -= new Vector2(0, overlap.Height);

                }
                if (overlap.Height < overlap.Width && item.CollisionRect.Y < CollisionRect.Y)
                {
                    position += new Vector2(0, overlap.Height);


                }
                if (overlap.Height > overlap.Width && item.CollisionRect.X < CollisionRect.X)
                {
                    position += new Vector2(overlap.Width, 0);

                }
                if (overlap.Height > overlap.Width && item.CollisionRect.X > CollisionRect.X)
                {
                    position -= new Vector2(overlap.Width, 0);

                }
            }
                
            
            position += (velocity * deltaTime);
            base.Update(gameTime);
        }
    }
}
