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
            tiles.Add(new tiles(new Vector2(240, 300), 1));
            tiles.Add(new tiles(new Vector2(272, 300), 1));

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
