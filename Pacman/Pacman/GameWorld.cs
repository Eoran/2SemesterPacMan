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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class GameWorld : Game
    {
        
        Player player;
        Enemy enemy;
        
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static List<tiles> tiles;
        public static List<Books> books;
        public static List<Cards> cards;
        public static List<Books> bookRem;
        public static List<Cards> cardRem;
        int HighScore;


        public GameWorld()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            books = new List<Books>();
            cards = new List<Cards>();
            bookRem = new List<Books>();
            cardRem = new List<Cards>();
            tiles = new List<tiles>();

            IsMouseVisible = true;
            player = new Player(new Vector2(300, 20), 10);
            enemy = new Enemy(new Vector2(100, 100), 10);
            //books.Add(new Books(new Vector2(200, 200), 1));
            //books.Add(new Books(new Vector2(250, 200), 1));
            //books.Add(new Books(new Vector2(200, 300), 1));
           

            tiles.Add(new tiles(new Vector2(0, 0), 1));
            tiles.Add(new tiles(new Vector2(0, 32), 1));
            tiles.Add(new tiles(new Vector2(0, 64), 1));
            tiles.Add(new tiles(new Vector2(0, 96), 1));
            tiles.Add(new tiles(new Vector2(0, 128), 1));
            tiles.Add(new tiles(new Vector2(0, 160), 1));
            tiles.Add(new tiles(new Vector2(0, 192), 1));
            tiles.Add(new tiles(new Vector2(0, 224), 1));
            tiles.Add(new tiles(new Vector2(0, 256), 1));
            tiles.Add(new tiles(new Vector2(0, 288), 1));
            
            tiles.Add(new tiles(new Vector2(0, 352), 1));
            tiles.Add(new tiles(new Vector2(0, 384), 1));
            tiles.Add(new tiles(new Vector2(0, 416), 1));
            tiles.Add(new tiles(new Vector2(0, 448), 1));
            tiles.Add(new tiles(new Vector2(0, 480), 1));
            tiles.Add(new tiles(new Vector2(0, 512), 1));
            tiles.Add(new tiles(new Vector2(0, 544), 1));
            tiles.Add(new tiles(new Vector2(0, 576), 1));
            tiles.Add(new tiles(new Vector2(0, 608), 1));
            tiles.Add(new tiles(new Vector2(0, 640), 1));
            // Tiles below the middle to the left ^

            tiles.Add(new tiles(new Vector2(32, 0), 1));
            tiles.Add(new tiles(new Vector2(64, 0), 1));
            tiles.Add(new tiles(new Vector2(96, 0), 1));
            tiles.Add(new tiles(new Vector2(128, 0), 1));
            tiles.Add(new tiles(new Vector2(160, 0), 1));
            tiles.Add(new tiles(new Vector2(192, 0), 1));
            tiles.Add(new tiles(new Vector2(224, 0), 1));
            tiles.Add(new tiles(new Vector2(256, 0), 1));
            tiles.Add(new tiles(new Vector2(288, 0), 1));
            tiles.Add(new tiles(new Vector2(320, 0), 1));
            tiles.Add(new tiles(new Vector2(352, 0), 1));
            tiles.Add(new tiles(new Vector2(384, 0), 1));
            tiles.Add(new tiles(new Vector2(416, 0), 1));
            tiles.Add(new tiles(new Vector2(448, 0), 1));
            tiles.Add(new tiles(new Vector2(480, 0), 1));
            tiles.Add(new tiles(new Vector2(512, 0), 1));
            tiles.Add(new tiles(new Vector2(544, 0), 1));
            tiles.Add(new tiles(new Vector2(576, 0), 1));
            tiles.Add(new tiles(new Vector2(608, 0), 1));
            tiles.Add(new tiles(new Vector2(640, 0), 1));
            tiles.Add(new tiles(new Vector2(672, 0), 1));

            // tiles at the top

            tiles.Add(new tiles(new Vector2(672, 32), 1));
            tiles.Add(new tiles(new Vector2(672, 64), 1));
            tiles.Add(new tiles(new Vector2(672, 96), 1));
            tiles.Add(new tiles(new Vector2(672, 128), 1));
            tiles.Add(new tiles(new Vector2(672, 160), 1));
            tiles.Add(new tiles(new Vector2(672, 192), 1));
            tiles.Add(new tiles(new Vector2(672, 224), 1));
            tiles.Add(new tiles(new Vector2(672, 256), 1));
            tiles.Add(new tiles(new Vector2(672, 288), 1));
            
            tiles.Add(new tiles(new Vector2(672, 352), 1));
            tiles.Add(new tiles(new Vector2(672, 384), 1));
            tiles.Add(new tiles(new Vector2(672, 416), 1));
            tiles.Add(new tiles(new Vector2(672, 448), 1));
            tiles.Add(new tiles(new Vector2(672, 480), 1));
            tiles.Add(new tiles(new Vector2(672, 512), 1));
            tiles.Add(new tiles(new Vector2(672, 544), 1));
            tiles.Add(new tiles(new Vector2(672, 576), 1));
            tiles.Add(new tiles(new Vector2(672, 608), 1));
            tiles.Add(new tiles(new Vector2(672, 638), 1));
            // tiles right side^
            tiles.Add(new tiles(new Vector2(640, 638), 1));
            tiles.Add(new tiles(new Vector2(608, 638), 1));
            tiles.Add(new tiles(new Vector2(576, 638), 1));
            tiles.Add(new tiles(new Vector2(544, 638), 1));
            tiles.Add(new tiles(new Vector2(512, 638), 1));
            tiles.Add(new tiles(new Vector2(480, 638), 1));
            tiles.Add(new tiles(new Vector2(448, 638), 1));
            tiles.Add(new tiles(new Vector2(416, 638), 1));
            tiles.Add(new tiles(new Vector2(384, 638), 1));
            tiles.Add(new tiles(new Vector2(352, 638), 1));
            tiles.Add(new tiles(new Vector2(320, 638), 1));
            tiles.Add(new tiles(new Vector2(288, 638), 1));
            tiles.Add(new tiles(new Vector2(256, 638), 1));
            tiles.Add(new tiles(new Vector2(224, 638), 1));
            tiles.Add(new tiles(new Vector2(192, 638), 1));
            tiles.Add(new tiles(new Vector2(160, 638), 1));
            tiles.Add(new tiles(new Vector2(128, 638), 1));
            tiles.Add(new tiles(new Vector2(96, 638), 1));
            tiles.Add(new tiles(new Vector2(64, 638), 1));
            tiles.Add(new tiles(new Vector2(32, 638), 1));
            tiles.Add(new tiles(new Vector2(0, 638), 1));

            //tiles at the bottom ^

            tiles.Add(new tiles(new Vector2(384, 320), 1));
            tiles.Add(new tiles(new Vector2(384, 352), 1));
            tiles.Add(new tiles(new Vector2(384, 288), 1));
            tiles.Add(new tiles(new Vector2(288, 288), 1));
            tiles.Add(new tiles(new Vector2(288, 320), 1));
            tiles.Add(new tiles(new Vector2(288, 352), 1));
            tiles.Add(new tiles(new Vector2(320, 352), 1));
            tiles.Add(new tiles(new Vector2(352, 352), 1));
            tiles.Add(new tiles(new Vector2(320, 224), 1));
            tiles.Add(new tiles(new Vector2(288, 224), 1));
            tiles.Add(new tiles(new Vector2(256, 224), 1));
            tiles.Add(new tiles(new Vector2(224, 224), 1));
            tiles.Add(new tiles(new Vector2(128, 224), 1));
            tiles.Add(new tiles(new Vector2(96, 224), 1));
            tiles.Add(new tiles(new Vector2(64, 224), 1));
            tiles.Add(new tiles(new Vector2(160, 224), 1));
            tiles.Add(new tiles(new Vector2(64, 192), 1));
            tiles.Add(new tiles(new Vector2(64, 160), 1));
            tiles.Add(new tiles(new Vector2(64, 128), 1));
            tiles.Add(new tiles(new Vector2(64, 64), 1));
            tiles.Add(new tiles(new Vector2(96, 64), 1));
            tiles.Add(new tiles(new Vector2(128, 64), 1));
            tiles.Add(new tiles(new Vector2(160, 64), 1));
            tiles.Add(new tiles(new Vector2(192, 64), 1));
            tiles.Add(new tiles(new Vector2(224, 64), 1));
            tiles.Add(new tiles(new Vector2(256, 64), 1));
            tiles.Add(new tiles(new Vector2(608, 352), 1));
            tiles.Add(new tiles(new Vector2(640, 352), 1));
            tiles.Add(new tiles(new Vector2(576, 352), 1));
            tiles.Add(new tiles(new Vector2(544, 352), 1));
            tiles.Add(new tiles(new Vector2(512, 352), 1));
            tiles.Add(new tiles(new Vector2(480, 352), 1));
            tiles.Add(new tiles(new Vector2(608, 416), 1));
            tiles.Add(new tiles(new Vector2(576, 416), 1));
            tiles.Add(new tiles(new Vector2(544, 416), 1));
            tiles.Add(new tiles(new Vector2(608, 448), 1));
            tiles.Add(new tiles(new Vector2(608, 480), 1));
            tiles.Add(new tiles(new Vector2(608, 512), 1));
            tiles.Add(new tiles(new Vector2(480, 288), 1));
            tiles.Add(new tiles(new Vector2(480, 256), 1));
            tiles.Add(new tiles(new Vector2(480, 224), 1));
            tiles.Add(new tiles(new Vector2(480, 192), 1));
            tiles.Add(new tiles(new Vector2(480, 160), 1));
            tiles.Add(new tiles(new Vector2(480, 128), 1));
            tiles.Add(new tiles(new Vector2(480, 416), 1));
            tiles.Add(new tiles(new Vector2(480, 448), 1));
            tiles.Add(new tiles(new Vector2(480, 480), 1));
            tiles.Add(new tiles(new Vector2(512, 480), 1));
            tiles.Add(new tiles(new Vector2(544, 480), 1));
            tiles.Add(new tiles(new Vector2(544, 512), 1));
            tiles.Add(new tiles(new Vector2(544, 544), 1));
            tiles.Add(new tiles(new Vector2(544, 576), 1));
            tiles.Add(new tiles(new Vector2(576, 576), 1));
            tiles.Add(new tiles(new Vector2(608, 576), 1));
            tiles.Add(new tiles(new Vector2(480, 576), 1));
            tiles.Add(new tiles(new Vector2(480, 544), 1));
            tiles.Add(new tiles(new Vector2(448, 544), 1));
            tiles.Add(new tiles(new Vector2(416, 544), 1));
            tiles.Add(new tiles(new Vector2(384, 544), 1));
            tiles.Add(new tiles(new Vector2(448, 480), 1));
            tiles.Add(new tiles(new Vector2(416, 480), 1));
            tiles.Add(new tiles(new Vector2(384, 480), 1));
            tiles.Add(new tiles(new Vector2(352, 544), 1));
            tiles.Add(new tiles(new Vector2(320, 544), 1));
            tiles.Add(new tiles(new Vector2(320, 512), 1));
            tiles.Add(new tiles(new Vector2(320, 480), 1));
            tiles.Add(new tiles(new Vector2(320, 448), 1));
            tiles.Add(new tiles(new Vector2(320, 416), 1));
            tiles.Add(new tiles(new Vector2(352, 416), 1));
            tiles.Add(new tiles(new Vector2(384, 416), 1));
            tiles.Add(new tiles(new Vector2(416, 416), 1));
            tiles.Add(new tiles(new Vector2(416, 608), 1));
            tiles.Add(new tiles(new Vector2(352, 576), 1));
            tiles.Add(new tiles(new Vector2(288, 608), 1));
            tiles.Add(new tiles(new Vector2(224, 576), 1));
            tiles.Add(new tiles(new Vector2(160, 608), 1));
            tiles.Add(new tiles(new Vector2(160, 576), 1));
            tiles.Add(new tiles(new Vector2(160, 544), 1));
            tiles.Add(new tiles(new Vector2(160, 512), 1));
            tiles.Add(new tiles(new Vector2(160, 480), 1));
            tiles.Add(new tiles(new Vector2(192, 480), 1));
            tiles.Add(new tiles(new Vector2(224, 480), 1));
            tiles.Add(new tiles(new Vector2(256, 480), 1));
            tiles.Add(new tiles(new Vector2(224, 544), 1));
            tiles.Add(new tiles(new Vector2(256, 544), 1));
            tiles.Add(new tiles(new Vector2(288, 544), 1));
            tiles.Add(new tiles(new Vector2(256, 416), 1));
            tiles.Add(new tiles(new Vector2(224, 416), 1));
            tiles.Add(new tiles(new Vector2(192, 416), 1));
            tiles.Add(new tiles(new Vector2(160, 416), 1));
            tiles.Add(new tiles(new Vector2(128, 416), 1));
            tiles.Add(new tiles(new Vector2(96, 416), 1));
            tiles.Add(new tiles(new Vector2(96, 448), 1));
            tiles.Add(new tiles(new Vector2(96, 480), 1));
            tiles.Add(new tiles(new Vector2(96, 512), 1));
            tiles.Add(new tiles(new Vector2(96, 544), 1));
            tiles.Add(new tiles(new Vector2(96, 576), 1));
            tiles.Add(new tiles(new Vector2(32, 576), 1));
            tiles.Add(new tiles(new Vector2(64, 512), 1));
            tiles.Add(new tiles(new Vector2(32, 448), 1));
            tiles.Add(new tiles(new Vector2(32, 352), 1));
            tiles.Add(new tiles(new Vector2(64, 352), 1));
            tiles.Add(new tiles(new Vector2(96, 352), 1));
            tiles.Add(new tiles(new Vector2(160, 352), 1));
            tiles.Add(new tiles(new Vector2(192, 352), 1));
            tiles.Add(new tiles(new Vector2(224, 352), 1));
            tiles.Add(new tiles(new Vector2(224, 288), 1));
            tiles.Add(new tiles(new Vector2(192, 288), 1));
            tiles.Add(new tiles(new Vector2(128, 288), 1));
            tiles.Add(new tiles(new Vector2(96, 288), 1));
            tiles.Add(new tiles(new Vector2(64, 288), 1));
            tiles.Add(new tiles(new Vector2(32, 288), 1));
            tiles.Add(new tiles(new Vector2(128, 128), 1));
            tiles.Add(new tiles(new Vector2(128, 160), 1));
            tiles.Add(new tiles(new Vector2(160, 160), 1));
            tiles.Add(new tiles(new Vector2(224, 160), 1));
            tiles.Add(new tiles(new Vector2(256, 160), 1));
            tiles.Add(new tiles(new Vector2(256, 128), 1));
            tiles.Add(new tiles(new Vector2(192, 96), 1));
            tiles.Add(new tiles(new Vector2(320, 32), 1));
            tiles.Add(new tiles(new Vector2(320, 64), 1));
            tiles.Add(new tiles(new Vector2(320, 92), 1));
            tiles.Add(new tiles(new Vector2(320, 124), 1));
            tiles.Add(new tiles(new Vector2(320, 156), 1));
           
           
           
           
           
            //Tiles making up the level
            //cards.Add(new Cards(new Vector2(300, 200), 1));
            //cards.Add(new Cards(new Vector2(340, 200), 1));

            base.Initialize();
            graphics.PreferredBackBufferWidth = 700;
            graphics.PreferredBackBufferHeight = 670;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);


            // TODO: use this.Content to load your game content here
            player.LoadContent(Content);
            foreach (Books consu in books)
            {
                consu.LoadContent(Content);
            }
            foreach (Cards card in cards)
            {
                card.LoadContent(Content);
            }
            foreach (tiles tile in tiles)
            {
                tile.LoadContent(Content);
            }
            enemy.LoadContent(Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if (cardRem.Count > 0)
            {
                foreach (Cards card in cardRem)
                {
                    if (cards.Contains(card))
                    {
                        cards.Remove(card);

                    }
                }
                cardRem = new List<Cards>();
            }
            if (bookRem.Count > 0)
            {
                foreach (Books book in bookRem)
                {
                    if (books.Contains(book))
                    {
                        HighScore++;
                        books.Remove(book);

                    }
                }
                bookRem = new List<Books>();
            }

            player.Update(gameTime);
            enemy.Update(gameTime);
            foreach (Books consu in books)
            {
                consu.Update(gameTime);
            }
            foreach (Cards card in cards)
            {
                card.Update(gameTime);
            }
            foreach (tiles tile in tiles)
            {
                tile.Update(gameTime);
            }

            base.Update(gameTime);
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);




            
            foreach (Books consu in books)
            {
                consu.Draw(spriteBatch);
            }
            foreach (Cards card in cards)
            {
                card.Draw(spriteBatch);
            }
            foreach (tiles tile in tiles)
            {
                tile.Draw(spriteBatch);
            }

            player.Draw(spriteBatch);
            enemy.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
