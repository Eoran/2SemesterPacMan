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

        static Player player;


        internal static Player Player
        {
            get { return GameWorld.player; }
        }

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static List<tiles> tiles;
        public static List<Books> books;
        public static List<Cards> cards;
        public static List<Books> bookRem;
        public static List<Cards> cardRem;
        public static List<Enemy> enemyList;

        public static int HighScore;


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
            Enemy.init();
            // TODO: Add your initialization logic here
            books = new List<Books>();
            cards = new List<Cards>();
            bookRem = new List<Books>();
            cardRem = new List<Cards>();
            tiles = new List<tiles>();
            enemyList = new List<Enemy>();


            IsMouseVisible = true;


            player = new Player(new Vector2(300, 20));
            enemyList.Add(new Enemy(new Vector2(320, 320), 0));
            enemyList.Add(new Enemy(new Vector2(352, 320), 1));
            enemyList.Add(new Enemy(new Vector2(320, 298), 2));
            enemyList.Add(new Enemy(new Vector2(352, 298), 3));

            //pick ups
            books.Add(new Books(new Vector2(292, 260)));

            //power ups
            cards.Add(new Cards(new Vector2(36, 36)));

            //Tiles making up the level
            #region tiles
            tiles.Add(new tiles(new Vector2(0, 0), true));
            tiles.Add(new tiles(new Vector2(0, 32), true));
            tiles.Add(new tiles(new Vector2(0, 64), true));
            tiles.Add(new tiles(new Vector2(0, 96), true));
            tiles.Add(new tiles(new Vector2(0, 128), true));
            tiles.Add(new tiles(new Vector2(0, 160), true));
            tiles.Add(new tiles(new Vector2(0, 192), true));
            tiles.Add(new tiles(new Vector2(0, 224), true));
            tiles.Add(new tiles(new Vector2(0, 256), true));
            tiles.Add(new tiles(new Vector2(0, 288), true));

            tiles.Add(new tiles(new Vector2(0, 352), true));
            tiles.Add(new tiles(new Vector2(0, 384), true));
            tiles.Add(new tiles(new Vector2(0, 416), true));
            tiles.Add(new tiles(new Vector2(0, 448), true));
            tiles.Add(new tiles(new Vector2(0, 480), true));
            tiles.Add(new tiles(new Vector2(0, 512), true));
            tiles.Add(new tiles(new Vector2(0, 544), true));
            tiles.Add(new tiles(new Vector2(0, 576), true));
            tiles.Add(new tiles(new Vector2(0, 608), true));
            tiles.Add(new tiles(new Vector2(0, 640), true));
            // Tiles below the middle to the left ^

            tiles.Add(new tiles(new Vector2(32, 0), true));
            tiles.Add(new tiles(new Vector2(64, 0), true));
            tiles.Add(new tiles(new Vector2(96, 0), true));
            tiles.Add(new tiles(new Vector2(128, 0), true));
            tiles.Add(new tiles(new Vector2(160, 0), true));
            tiles.Add(new tiles(new Vector2(192, 0), true));
            tiles.Add(new tiles(new Vector2(224, 0), true));
            tiles.Add(new tiles(new Vector2(256, 0), true));
            tiles.Add(new tiles(new Vector2(288, 0), true));
            tiles.Add(new tiles(new Vector2(320, 0), true));
            tiles.Add(new tiles(new Vector2(352, 0), true));
            tiles.Add(new tiles(new Vector2(384, 0), true));
            tiles.Add(new tiles(new Vector2(416, 0), true));
            tiles.Add(new tiles(new Vector2(448, 0), true));
            tiles.Add(new tiles(new Vector2(480, 0), true));
            tiles.Add(new tiles(new Vector2(512, 0), true));
            tiles.Add(new tiles(new Vector2(544, 0), true));
            tiles.Add(new tiles(new Vector2(576, 0), true));
            tiles.Add(new tiles(new Vector2(608, 0), true));
            tiles.Add(new tiles(new Vector2(640, 0), true));
            tiles.Add(new tiles(new Vector2(672, 0), true));

            // tiles at the top

            tiles.Add(new tiles(new Vector2(672, 32), true));
            tiles.Add(new tiles(new Vector2(672, 64), true));
            tiles.Add(new tiles(new Vector2(672, 96), true));
            tiles.Add(new tiles(new Vector2(672, 128), true));
            tiles.Add(new tiles(new Vector2(672, 160), true));
            tiles.Add(new tiles(new Vector2(672, 192), true));
            tiles.Add(new tiles(new Vector2(672, 224), true));
            tiles.Add(new tiles(new Vector2(672, 256), true));
            tiles.Add(new tiles(new Vector2(672, 288), true));

            tiles.Add(new tiles(new Vector2(672, 352), true));
            tiles.Add(new tiles(new Vector2(672, 384), true));
            tiles.Add(new tiles(new Vector2(672, 416), true));
            tiles.Add(new tiles(new Vector2(672, 448), true));
            tiles.Add(new tiles(new Vector2(672, 480), true));
            tiles.Add(new tiles(new Vector2(672, 512), true));
            tiles.Add(new tiles(new Vector2(672, 544), true));
            tiles.Add(new tiles(new Vector2(672, 576), true));
            tiles.Add(new tiles(new Vector2(672, 608), true));
            tiles.Add(new tiles(new Vector2(672, 638), true));
            // tiles right side^
            tiles.Add(new tiles(new Vector2(640, 638), true));
            tiles.Add(new tiles(new Vector2(608, 638), true));
            tiles.Add(new tiles(new Vector2(576, 638), true));
            tiles.Add(new tiles(new Vector2(544, 638), true));
            tiles.Add(new tiles(new Vector2(512, 638), true));
            tiles.Add(new tiles(new Vector2(480, 638), true));
            tiles.Add(new tiles(new Vector2(448, 638), true));
            tiles.Add(new tiles(new Vector2(416, 638), true));
            tiles.Add(new tiles(new Vector2(384, 638), true));
            tiles.Add(new tiles(new Vector2(352, 638), true));
            tiles.Add(new tiles(new Vector2(320, 638), true));
            tiles.Add(new tiles(new Vector2(288, 638), true));
            tiles.Add(new tiles(new Vector2(256, 638), true));
            tiles.Add(new tiles(new Vector2(224, 638), true));
            tiles.Add(new tiles(new Vector2(192, 638), true));
            tiles.Add(new tiles(new Vector2(160, 638), true));
            tiles.Add(new tiles(new Vector2(128, 638), true));
            tiles.Add(new tiles(new Vector2(96, 638), true));
            tiles.Add(new tiles(new Vector2(64, 638), true));
            tiles.Add(new tiles(new Vector2(32, 638), true));
            tiles.Add(new tiles(new Vector2(0, 638), true));

            //tiles at the bottom ^

            tiles.Add(new tiles(new Vector2(384, 320), true));
            tiles.Add(new tiles(new Vector2(384, 352), true));
            tiles.Add(new tiles(new Vector2(384, 288), true));
            tiles.Add(new tiles(new Vector2(288, 288), true));
            tiles.Add(new tiles(new Vector2(288, 320), true));
            tiles.Add(new tiles(new Vector2(288, 352), true));
            tiles.Add(new tiles(new Vector2(320, 352), true));
            tiles.Add(new tiles(new Vector2(352, 352), true));
            tiles.Add(new tiles(new Vector2(320, 224), true));
            tiles.Add(new tiles(new Vector2(288, 224), true));
            tiles.Add(new tiles(new Vector2(256, 224), true));
            tiles.Add(new tiles(new Vector2(224, 224), true));
            tiles.Add(new tiles(new Vector2(128, 224), true));
            tiles.Add(new tiles(new Vector2(96, 224), true));
            tiles.Add(new tiles(new Vector2(64, 224), true));
            tiles.Add(new tiles(new Vector2(160, 224), true));
            tiles.Add(new tiles(new Vector2(64, 192), true));
            tiles.Add(new tiles(new Vector2(64, 160), true));
            tiles.Add(new tiles(new Vector2(64, 128), true));
            tiles.Add(new tiles(new Vector2(64, 64), true));
            tiles.Add(new tiles(new Vector2(96, 64), true));
            tiles.Add(new tiles(new Vector2(128, 64), true));
            tiles.Add(new tiles(new Vector2(160, 64), true));
            tiles.Add(new tiles(new Vector2(192, 64), true));
            tiles.Add(new tiles(new Vector2(224, 64), true));
            tiles.Add(new tiles(new Vector2(256, 64), true));
            tiles.Add(new tiles(new Vector2(608, 352), true));
            tiles.Add(new tiles(new Vector2(640, 352), true));
            tiles.Add(new tiles(new Vector2(576, 352), true));
            tiles.Add(new tiles(new Vector2(544, 352), true));
            tiles.Add(new tiles(new Vector2(512, 352), true));
            tiles.Add(new tiles(new Vector2(480, 352), true));
            tiles.Add(new tiles(new Vector2(608, 416), true));
            tiles.Add(new tiles(new Vector2(576, 416), true));
            tiles.Add(new tiles(new Vector2(544, 416), true));
            tiles.Add(new tiles(new Vector2(608, 448), true));
            tiles.Add(new tiles(new Vector2(608, 480), true));
            tiles.Add(new tiles(new Vector2(608, 512), true));
            tiles.Add(new tiles(new Vector2(480, 288), true));
            tiles.Add(new tiles(new Vector2(480, 256), true));
            tiles.Add(new tiles(new Vector2(480, 224), true));
            tiles.Add(new tiles(new Vector2(480, 192), true));
            tiles.Add(new tiles(new Vector2(480, 160), true));
            tiles.Add(new tiles(new Vector2(480, 128), true));
            tiles.Add(new tiles(new Vector2(480, 416), true));
            tiles.Add(new tiles(new Vector2(480, 448), true));
            tiles.Add(new tiles(new Vector2(480, 480), true));
            tiles.Add(new tiles(new Vector2(512, 480), true));
            tiles.Add(new tiles(new Vector2(544, 480), true));
            tiles.Add(new tiles(new Vector2(544, 512), true));
            tiles.Add(new tiles(new Vector2(544, 544), true));
            tiles.Add(new tiles(new Vector2(544, 576), true));
            tiles.Add(new tiles(new Vector2(576, 576), true));
            tiles.Add(new tiles(new Vector2(608, 576), true));
            tiles.Add(new tiles(new Vector2(480, 576), true));
            tiles.Add(new tiles(new Vector2(480, 544), true));
            tiles.Add(new tiles(new Vector2(448, 544), true));
            tiles.Add(new tiles(new Vector2(416, 544), true));
            tiles.Add(new tiles(new Vector2(384, 544), true));
            tiles.Add(new tiles(new Vector2(448, 480), true));
            tiles.Add(new tiles(new Vector2(416, 480), true));
            tiles.Add(new tiles(new Vector2(384, 480), true));
            tiles.Add(new tiles(new Vector2(352, 544), true));
            tiles.Add(new tiles(new Vector2(320, 544), true));
            tiles.Add(new tiles(new Vector2(320, 512), true));
            tiles.Add(new tiles(new Vector2(320, 480), true));
            tiles.Add(new tiles(new Vector2(320, 448), true));
            tiles.Add(new tiles(new Vector2(320, 416), true));
            tiles.Add(new tiles(new Vector2(352, 416), true));
            tiles.Add(new tiles(new Vector2(384, 416), true));
            tiles.Add(new tiles(new Vector2(416, 416), true));
            tiles.Add(new tiles(new Vector2(416, 608), true));
            tiles.Add(new tiles(new Vector2(352, 576), true));
            tiles.Add(new tiles(new Vector2(288, 608), true));
            tiles.Add(new tiles(new Vector2(224, 576), true));
            tiles.Add(new tiles(new Vector2(160, 608), true));
            tiles.Add(new tiles(new Vector2(160, 576), true));
            tiles.Add(new tiles(new Vector2(160, 544), true));
            tiles.Add(new tiles(new Vector2(160, 512), true));
            tiles.Add(new tiles(new Vector2(160, 480), true));
            tiles.Add(new tiles(new Vector2(192, 480), true));
            tiles.Add(new tiles(new Vector2(224, 480), true));
            tiles.Add(new tiles(new Vector2(256, 480), true));
            tiles.Add(new tiles(new Vector2(224, 544), true));
            tiles.Add(new tiles(new Vector2(256, 544), true));
            tiles.Add(new tiles(new Vector2(288, 544), true));
            tiles.Add(new tiles(new Vector2(256, 416), true));
            tiles.Add(new tiles(new Vector2(224, 416), true));
            tiles.Add(new tiles(new Vector2(192, 416), true));
            tiles.Add(new tiles(new Vector2(160, 416), true));
            tiles.Add(new tiles(new Vector2(128, 416), true));
            tiles.Add(new tiles(new Vector2(96, 416), true));
            tiles.Add(new tiles(new Vector2(96, 448), true));
            tiles.Add(new tiles(new Vector2(96, 480), true));
            tiles.Add(new tiles(new Vector2(96, 512), true));
            tiles.Add(new tiles(new Vector2(96, 544), true));
            tiles.Add(new tiles(new Vector2(96, 576), true));
            tiles.Add(new tiles(new Vector2(32, 576), true));
            tiles.Add(new tiles(new Vector2(64, 512), true));
            tiles.Add(new tiles(new Vector2(32, 448), true));
            tiles.Add(new tiles(new Vector2(64, 384), true));
            tiles.Add(new tiles(new Vector2(96, 384), true));
            tiles.Add(new tiles(new Vector2(64, 352), true));
            tiles.Add(new tiles(new Vector2(96, 352), true));
            tiles.Add(new tiles(new Vector2(160, 352), true));
            tiles.Add(new tiles(new Vector2(192, 352), true));
            tiles.Add(new tiles(new Vector2(224, 352), true));
            tiles.Add(new tiles(new Vector2(224, 288), true));
            tiles.Add(new tiles(new Vector2(192, 288), true));
            tiles.Add(new tiles(new Vector2(128, 288), true));
            tiles.Add(new tiles(new Vector2(96, 288), true));
            tiles.Add(new tiles(new Vector2(64, 288), true));
            tiles.Add(new tiles(new Vector2(32, 288), true));
            tiles.Add(new tiles(new Vector2(128, 128), true));
            tiles.Add(new tiles(new Vector2(128, 160), true));
            tiles.Add(new tiles(new Vector2(160, 160), true));
            tiles.Add(new tiles(new Vector2(224, 160), true));
            tiles.Add(new tiles(new Vector2(256, 160), true));
            tiles.Add(new tiles(new Vector2(256, 128), true));
            tiles.Add(new tiles(new Vector2(192, 96), true));
            tiles.Add(new tiles(new Vector2(320, 32), true));
            tiles.Add(new tiles(new Vector2(320, 64), true));
            tiles.Add(new tiles(new Vector2(320, 96), true));
            tiles.Add(new tiles(new Vector2(320, 128), true));
            tiles.Add(new tiles(new Vector2(320, 160), true));
            tiles.Add(new tiles(new Vector2(384, 224), true));
            tiles.Add(new tiles(new Vector2(416, 224), true));
            tiles.Add(new tiles(new Vector2(448, 288), true));
            tiles.Add(new tiles(new Vector2(448, 352), true));
            tiles.Add(new tiles(new Vector2(416, 160), true));
            tiles.Add(new tiles(new Vector2(384, 160), true));
            tiles.Add(new tiles(new Vector2(384, 128), true));
            tiles.Add(new tiles(new Vector2(384, 96), true));
            tiles.Add(new tiles(new Vector2(384, 64), true));
            tiles.Add(new tiles(new Vector2(448, 64), true));

            tiles.Add(new tiles(new Vector2(448, 96), true));
            tiles.Add(new tiles(new Vector2(480, 96), true));
            tiles.Add(new tiles(new Vector2(512, 32), true));
            tiles.Add(new tiles(new Vector2(544, 96), true));
            tiles.Add(new tiles(new Vector2(544, 128), true));
            tiles.Add(new tiles(new Vector2(544, 160), true));
            tiles.Add(new tiles(new Vector2(544, 192), true));
            tiles.Add(new tiles(new Vector2(544, 224), true));
            tiles.Add(new tiles(new Vector2(544, 256), true));
            tiles.Add(new tiles(new Vector2(544, 320), true));

            tiles.Add(new tiles(new Vector2(608, 288), true));
            tiles.Add(new tiles(new Vector2(640, 288), true));
            tiles.Add(new tiles(new Vector2(576, 224), true));
            tiles.Add(new tiles(new Vector2(608, 224), true));
            tiles.Add(new tiles(new Vector2(640, 160), true));
            tiles.Add(new tiles(new Vector2(608, 160), true));
            tiles.Add(new tiles(new Vector2(576, 96), true));
            tiles.Add(new tiles(new Vector2(608, 96), true));
            tiles.Add(new tiles(new Vector2(608, 64), true));
            tiles.Add(new tiles(new Vector2(544, 32), true));

            //spawn chucks
            tiles.Add(new tiles(new Vector2(320, 288),false));
            tiles.Add(new tiles(new Vector2(352, 288), false));
            
            #endregion


            
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
            foreach (Enemy enemy in enemyList)
            {
                enemy.LoadContent(Content);
            }

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
                        HighScore += 500;
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
                        books.Remove(book);
                        HighScore += 100;
                    }
                }
                bookRem = new List<Books>();
            }

            player.Update(gameTime);


            foreach (Enemy enemy in enemyList)
            {
                enemy.Update(gameTime);
            }
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
            GraphicsDevice.Clear(Color.Gray);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            this.Window.Title = "You're score is: " + HighScore.ToString();

            //HUD setup
            #region HUD
            //SpriteFont spriteFont = Content.Load<SpriteFont>("arial");
            //Rectangle rectangle = new Rectangle();
            //rectangle.Width = 700;
            //rectangle.Height = 50;
            //rectangle.Y = 670;

            //Texture2D texture = new Texture2D(graphics.GraphicsDevice, 1, 1);
            //texture.SetData(new Color[] { Color.Gray });
            //Color color = Color.White;

            //spriteBatch.Draw(texture, rectangle, color);
            #endregion
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

            foreach (Enemy enemy in enemyList)
            {
                enemy.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
