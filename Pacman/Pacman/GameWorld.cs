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

        private SpriteFont sf;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static List<tiles> tiles;
        public static List<Books> books;
        public static List<Cards> cards;
        public static List<Books> bookRem;
        public static List<Cards> cardRem;
        public static List<Enemy> enemyList;

        bool gameStarted = false;
        private bool howtoplay = false;
        public static bool gameOver = false;
        private bool youwin = false;
        private bool youLoose = false;
       
        Rectangle mainRec = new Rectangle();
        Rectangle startGameRec = new Rectangle();
        Rectangle howToPlayRec = new Rectangle();

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
            //pickups
            #region pick ups
            //pick ups
            books.Add(new Books(new Vector2(292, 260)));
            books.Add(new Books(new Vector2(324, 260)));
            books.Add(new Books(new Vector2(356, 260)));
            books.Add(new Books(new Vector2(388, 260)));
            books.Add(new Books(new Vector2(420, 260)));
            books.Add(new Books(new Vector2(452, 260)));
            books.Add(new Books(new Vector2(452, 228)));
            books.Add(new Books(new Vector2(452, 196)));
            books.Add(new Books(new Vector2(452, 164)));
            books.Add(new Books(new Vector2(452, 132)));
            books.Add(new Books(new Vector2(420, 132)));
            books.Add(new Books(new Vector2(420, 100)));
            books.Add(new Books(new Vector2(420, 68)));
            books.Add(new Books(new Vector2(420, 36)));
            books.Add(new Books(new Vector2(452, 36)));
            books.Add(new Books(new Vector2(484, 36)));
            books.Add(new Books(new Vector2(484, 68)));
            books.Add(new Books(new Vector2(516, 68)));
            books.Add(new Books(new Vector2(548, 68)));
            books.Add(new Books(new Vector2(580, 68)));
            books.Add(new Books(new Vector2(580, 36)));
            books.Add(new Books(new Vector2(612, 36)));
            books.Add(new Books(new Vector2(644, 68)));
            books.Add(new Books(new Vector2(644, 100)));
            books.Add(new Books(new Vector2(644, 132)));
            books.Add(new Books(new Vector2(612, 132)));
            books.Add(new Books(new Vector2(580, 132)));
            books.Add(new Books(new Vector2(580, 164)));
            books.Add(new Books(new Vector2(580, 196)));
            books.Add(new Books(new Vector2(612, 196)));
            books.Add(new Books(new Vector2(644, 196)));
            books.Add(new Books(new Vector2(644, 228)));
            books.Add(new Books(new Vector2(644, 260)));
            books.Add(new Books(new Vector2(612, 260)));
            books.Add(new Books(new Vector2(580, 260)));
            books.Add(new Books(new Vector2(580, 292)));
            books.Add(new Books(new Vector2(580, 324)));
            books.Add(new Books(new Vector2(612, 324)));
            books.Add(new Books(new Vector2(644, 324)));
            books.Add(new Books(new Vector2(672, 324)));
            books.Add(new Books(new Vector2(548, 292)));
            books.Add(new Books(new Vector2(516, 292)));

            books.Add(new Books(new Vector2(516, 260)));
            books.Add(new Books(new Vector2(516, 228)));
            books.Add(new Books(new Vector2(516, 196)));
            books.Add(new Books(new Vector2(516, 164)));
            books.Add(new Books(new Vector2(516, 132)));
            books.Add(new Books(new Vector2(516, 100)));
            books.Add(new Books(new Vector2(516, 324)));
            books.Add(new Books(new Vector2(484, 324)));
            books.Add(new Books(new Vector2(452, 324)));
            books.Add(new Books(new Vector2(420, 324)));
            books.Add(new Books(new Vector2(420, 356)));
            books.Add(new Books(new Vector2(420, 292)));
            books.Add(new Books(new Vector2(420, 388)));
            books.Add(new Books(new Vector2(452, 388)));
            books.Add(new Books(new Vector2(484, 388)));
            books.Add(new Books(new Vector2(516, 388)));

            //branch 1
            books.Add(new Books(new Vector2(516, 420)));
            books.Add(new Books(new Vector2(516, 452)));
            books.Add(new Books(new Vector2(580, 452)));
            books.Add(new Books(new Vector2(548, 452)));
            books.Add(new Books(new Vector2(580, 484)));
            books.Add(new Books(new Vector2(580, 516)));
            books.Add(new Books(new Vector2(580, 548)));
            books.Add(new Books(new Vector2(612, 548)));

            //branch 2
            books.Add(new Books(new Vector2(548, 388)));
            books.Add(new Books(new Vector2(580, 388)));
            books.Add(new Books(new Vector2(612, 388)));
            books.Add(new Books(new Vector2(644, 388)));
            books.Add(new Books(new Vector2(644, 420)));
            books.Add(new Books(new Vector2(644, 452)));
            books.Add(new Books(new Vector2(644, 484)));
            books.Add(new Books(new Vector2(644, 516)));
            books.Add(new Books(new Vector2(644, 548)));
            books.Add(new Books(new Vector2(644, 580)));

            books.Add(new Books(new Vector2(612, 612)));
            books.Add(new Books(new Vector2(580, 612)));
            books.Add(new Books(new Vector2(548, 612)));
            books.Add(new Books(new Vector2(516, 612)));

            //branch 1
            books.Add(new Books(new Vector2(516, 580)));
            books.Add(new Books(new Vector2(516, 548)));
            books.Add(new Books(new Vector2(516, 516)));
            books.Add(new Books(new Vector2(484, 516)));
            books.Add(new Books(new Vector2(452, 516)));
            books.Add(new Books(new Vector2(420, 516)));
            books.Add(new Books(new Vector2(388, 516)));
            books.Add(new Books(new Vector2(356, 516)));
            books.Add(new Books(new Vector2(356, 484)));
            books.Add(new Books(new Vector2(356, 452)));
            books.Add(new Books(new Vector2(388, 452)));
            books.Add(new Books(new Vector2(420, 452)));
            books.Add(new Books(new Vector2(452, 452)));
            books.Add(new Books(new Vector2(452, 420)));

            //branch 2
            books.Add(new Books(new Vector2(484, 612)));
            books.Add(new Books(new Vector2(452, 612)));
            books.Add(new Books(new Vector2(452, 580)));
            books.Add(new Books(new Vector2(420, 580)));
            books.Add(new Books(new Vector2(388, 580)));
            books.Add(new Books(new Vector2(388, 612)));
            books.Add(new Books(new Vector2(356, 612)));
            books.Add(new Books(new Vector2(324, 612)));
            books.Add(new Books(new Vector2(324, 580)));
            books.Add(new Books(new Vector2(292, 580)));
            books.Add(new Books(new Vector2(260, 580)));
            books.Add(new Books(new Vector2(260, 612)));
            books.Add(new Books(new Vector2(228, 612)));
            books.Add(new Books(new Vector2(196, 612)));
            books.Add(new Books(new Vector2(196, 580)));
            books.Add(new Books(new Vector2(196, 548)));
            books.Add(new Books(new Vector2(196, 516)));
            books.Add(new Books(new Vector2(228, 516)));
            books.Add(new Books(new Vector2(260, 516)));
            books.Add(new Books(new Vector2(292, 516)));
            books.Add(new Books(new Vector2(292, 484)));
            books.Add(new Books(new Vector2(292, 452)));
            //branch 1
            books.Add(new Books(new Vector2(292, 420)));
            books.Add(new Books(new Vector2(292, 388)));
            books.Add(new Books(new Vector2(324, 388)));
            books.Add(new Books(new Vector2(356, 388)));
            books.Add(new Books(new Vector2(388, 388)));
            books.Add(new Books(new Vector2(260, 388)));
            books.Add(new Books(new Vector2(228, 388)));
            books.Add(new Books(new Vector2(196, 388)));
            books.Add(new Books(new Vector2(164, 388)));
            books.Add(new Books(new Vector2(132, 388)));
            books.Add(new Books(new Vector2(132, 356)));
            //branch 2
            books.Add(new Books(new Vector2(260, 452)));
            books.Add(new Books(new Vector2(228, 452)));
            books.Add(new Books(new Vector2(196, 452)));
            books.Add(new Books(new Vector2(164, 452)));
            books.Add(new Books(new Vector2(132, 452)));
            books.Add(new Books(new Vector2(132, 484)));
            books.Add(new Books(new Vector2(132, 516)));
            books.Add(new Books(new Vector2(132, 548)));
            books.Add(new Books(new Vector2(132, 580)));
            books.Add(new Books(new Vector2(132, 612)));
            books.Add(new Books(new Vector2(100, 612)));
            books.Add(new Books(new Vector2(68, 612)));

            books.Add(new Books(new Vector2(68, 580)));
            books.Add(new Books(new Vector2(68, 548)));
            books.Add(new Books(new Vector2(36, 548)));
            books.Add(new Books(new Vector2(36, 516)));
            books.Add(new Books(new Vector2(36, 484)));
            books.Add(new Books(new Vector2(68, 484)));
            books.Add(new Books(new Vector2(68, 452)));
            books.Add(new Books(new Vector2(68, 420)));
            books.Add(new Books(new Vector2(36, 420)));
            books.Add(new Books(new Vector2(36, 388)));
            books.Add(new Books(new Vector2(36, 356)));
            books.Add(new Books(new Vector2(36, 324)));
            books.Add(new Books(new Vector2(4, 324)));
            books.Add(new Books(new Vector2(68, 324)));
            books.Add(new Books(new Vector2(100, 324)));
            books.Add(new Books(new Vector2(132, 324)));
            books.Add(new Books(new Vector2(164, 324)));
            books.Add(new Books(new Vector2(196, 324)));
            books.Add(new Books(new Vector2(228, 324)));
            books.Add(new Books(new Vector2(260, 324)));
            books.Add(new Books(new Vector2(260, 356)));
            books.Add(new Books(new Vector2(260, 292)));
            books.Add(new Books(new Vector2(260, 260)));
            books.Add(new Books(new Vector2(228, 260)));
            books.Add(new Books(new Vector2(196, 260)));
            books.Add(new Books(new Vector2(196, 228)));
            books.Add(new Books(new Vector2(164, 260)));
            books.Add(new Books(new Vector2(164, 292)));
            books.Add(new Books(new Vector2(132, 260)));
            books.Add(new Books(new Vector2(100, 260)));
            books.Add(new Books(new Vector2(68, 260)));
            books.Add(new Books(new Vector2(36, 260)));
            books.Add(new Books(new Vector2(36, 228)));
            books.Add(new Books(new Vector2(36, 196)));
            books.Add(new Books(new Vector2(36, 164)));
            books.Add(new Books(new Vector2(36, 132)));
            books.Add(new Books(new Vector2(36, 100)));
            // branch 1
            books.Add(new Books(new Vector2(36, 68)));
            books.Add(new Books(new Vector2(68, 36)));
            books.Add(new Books(new Vector2(100, 36)));
            books.Add(new Books(new Vector2(132, 36)));
            books.Add(new Books(new Vector2(164, 36)));
            books.Add(new Books(new Vector2(196, 36)));
            books.Add(new Books(new Vector2(228, 36)));
            books.Add(new Books(new Vector2(260, 36)));
            books.Add(new Books(new Vector2(292, 36)));
            books.Add(new Books(new Vector2(292, 68)));
            books.Add(new Books(new Vector2(292, 100)));
            books.Add(new Books(new Vector2(292, 132)));
            books.Add(new Books(new Vector2(292, 164)));
            books.Add(new Books(new Vector2(292, 196)));
            books.Add(new Books(new Vector2(324, 196)));
            books.Add(new Books(new Vector2(356, 196)));
            books.Add(new Books(new Vector2(388, 196)));
            books.Add(new Books(new Vector2(420, 196)));
            books.Add(new Books(new Vector2(356, 228)));
            books.Add(new Books(new Vector2(356, 164)));
            books.Add(new Books(new Vector2(356, 132)));
            books.Add(new Books(new Vector2(356, 100)));
            books.Add(new Books(new Vector2(356, 68)));
            books.Add(new Books(new Vector2(356, 36)));
            books.Add(new Books(new Vector2(388, 36)));
            // branch 2
            books.Add(new Books(new Vector2(68, 100)));
            books.Add(new Books(new Vector2(100, 100)));
            //branch 3
            books.Add(new Books(new Vector2(132, 100)));
            books.Add(new Books(new Vector2(164, 100)));
            books.Add(new Books(new Vector2(164, 132)));
            books.Add(new Books(new Vector2(196, 132)));
            books.Add(new Books(new Vector2(228, 132)));
            books.Add(new Books(new Vector2(228, 100)));
            books.Add(new Books(new Vector2(260, 100)));
            //branch 4
            books.Add(new Books(new Vector2(100, 132)));
            books.Add(new Books(new Vector2(100, 164)));
            books.Add(new Books(new Vector2(100, 196)));
            books.Add(new Books(new Vector2(132, 196)));
            books.Add(new Books(new Vector2(164, 196)));
            books.Add(new Books(new Vector2(196, 196)));
            books.Add(new Books(new Vector2(196, 164)));
            books.Add(new Books(new Vector2(228, 196)));
            books.Add(new Books(new Vector2(260, 196)));



            //power ups
            cards.Add(new Cards(new Vector2(36, 36)));
            cards.Add(new Cards(new Vector2(644, 612)));
            cards.Add(new Cards(new Vector2(36, 612)));
            cards.Add(new Cards(new Vector2(644, 36)));
            #endregion
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
            tiles.Add(new tiles(new Vector2(320, 288), false));
            tiles.Add(new tiles(new Vector2(352, 288), false));
            //bug fix blok
            tiles.Add(new tiles(new Vector2(-32, 288), true));
            tiles.Add(new tiles(new Vector2(-64, 288), true));
            tiles.Add(new tiles(new Vector2(-64, 352), true));
            tiles.Add(new tiles(new Vector2(-32, 352), true));

            tiles.Add(new tiles(new Vector2(704, 288), true));
            tiles.Add(new tiles(new Vector2(736, 288), true));
            tiles.Add(new tiles(new Vector2(704, 352), true));
            tiles.Add(new tiles(new Vector2(736, 352), true));


            #endregion



            base.Initialize();
            graphics.PreferredBackBufferWidth = 700;
            graphics.PreferredBackBufferHeight = 720;
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
            spriteBatch = new SpriteBatch(graphics.GraphicsDevice);

            sf = Content.Load<SpriteFont>("sprite");
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
            if (gameStarted)
            {


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
            }
            else
            {
                if (startGameRec.Contains(Mouse.GetState().X, Mouse.GetState().Y) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    gameStarted = true;
                }
                else if (howToPlayRec.Contains(Mouse.GetState().X, Mouse.GetState().Y) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    if (howtoplay)
                    {
                        howtoplay = false;
                    }
                    else
                    {
                        howtoplay = true;
                    }
                    
                }
            }
            if (gameOver)
            {
                gameStarted = false;
                books = null;
                cards = null;
                tiles = null;
                enemyList = null;
                player = null;
                Initialize();
                LoadContent();
                HighScore = 0;
                Player.PowerCount = 0;
                gameOver = false;
                youwin = false;
                youLoose = true;
            }
            if(books.Count == 0 && cards.Count == 0)
            {
                
                gameStarted = false;
                books = null;
                cards = null;
                tiles = null;
                enemyList = null;
                player = null;
                Initialize();
                LoadContent();
                HighScore = 0;
                Player.PowerCount = 0;
                youwin = true;
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
            if (gameStarted)
            {


                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);


                //HUD setup

                #region HUD

                Rectangle rectangle = new Rectangle();
                rectangle.Width = 700;
                rectangle.Height = 50;
                rectangle.Y = 670;

                Texture2D texture = new Texture2D(graphics.GraphicsDevice, 1, 1);
                texture.SetData(new Color[] { Color.Gray });
                Color color = Color.White;

                spriteBatch.Draw(texture, rectangle, color);
                spriteBatch.DrawString(sf, "Score: " + HighScore.ToString(), new Vector2(10, 680), Color.White);
                spriteBatch.DrawString(sf, "liv: " + Player.Lifes, new Vector2(200, 680), Color.White);

                #endregion

                player.Draw(spriteBatch);


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
                foreach (Enemy enemy in enemyList)
                {
                    enemy.Draw(spriteBatch);
                }


                //sprite text

                spriteBatch.End();
            }
            else
            {
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
                if (howtoplay == false)
                {
                    if (youwin)
                    {
                        spriteBatch.DrawString(sf, "YOU WIN!", new Vector2(270, 100), Color.White);
                    }
                    else if(youLoose)
                    {
                        spriteBatch.DrawString(sf, "YOU LOOSE!", new Vector2(270, 100), Color.White);
                    }
                    #region mainMenuBar
                    mainRec.Width = 170;
                    mainRec.Height = 300;
                    mainRec.Y = 200;
                    mainRec.X = 260;

                    Texture2D mainBarTex = new Texture2D(graphics.GraphicsDevice, 1, 1);
                    mainBarTex.SetData(new Color[] { Color.DarkGray });
                    Color MainColor = Color.White;

                    spriteBatch.Draw(mainBarTex, mainRec, MainColor);
                    #endregion
                    #region StartGameButton

                    startGameRec.Width = 150;
                    startGameRec.Height = 50;
                    startGameRec.Y = 210;
                    startGameRec.X = 270;

                    Texture2D startGameTex = new Texture2D(graphics.GraphicsDevice, 1, 1);
                    startGameTex.SetData(new Color[] { Color.Gray });
                    Color startGameCol = Color.White;

                    spriteBatch.Draw(startGameTex, startGameRec, startGameCol);

                    spriteBatch.DrawString(sf, "Start spil", new Vector2(startGameRec.X + 5, startGameRec.Y + 10), Color.White);
                    #endregion
                    #region howToPlayButton

                    howToPlayRec.Width = 150;
                    howToPlayRec.Height = 50;
                    howToPlayRec.Y = 270;
                    howToPlayRec.X = 270;

                    Texture2D howToPlayTex = new Texture2D(graphics.GraphicsDevice, 1, 1);
                    howToPlayTex.SetData(new Color[] { Color.Gray });
                    Color howToPlayCol = Color.White;

                    spriteBatch.Draw(howToPlayTex, howToPlayRec, howToPlayCol);

                    spriteBatch.DrawString(sf, "Instruktioner", new Vector2(howToPlayRec.X + 5, howToPlayRec.Y + 10), Color.White);
                    #endregion
                }
                else
                {
                    #region mainMenuBar
                    mainRec.Width = 300;
                    mainRec.Height = 450;
                    mainRec.Y = 200;
                    mainRec.X = 200;

                    Texture2D mainBarTex = new Texture2D(graphics.GraphicsDevice, 1, 1);
                    mainBarTex.SetData(new Color[] { Color.DarkGray });
                    Color MainColor = Color.White;

                    spriteBatch.Draw(mainBarTex, mainRec, MainColor);
                    #endregion
                    #region howToPlayButton

                    howToPlayRec.Width = 130;
                    howToPlayRec.Height = 50;
                    howToPlayRec.Y = 570;
                    howToPlayRec.X = 270;

                    Texture2D howToPlayTex = new Texture2D(graphics.GraphicsDevice, 1, 1);
                    howToPlayTex.SetData(new Color[] { Color.Gray });
                    Color howToPlayCol = Color.White;

                    spriteBatch.Draw(howToPlayTex, howToPlayRec, howToPlayCol);

                    spriteBatch.DrawString(sf, "I dette spil er maalet at", new Vector2(mainRec.X + 5, mainRec.Y + 5), Color.White);
                    spriteBatch.DrawString(sf, "samle alle boegerne", new Vector2(mainRec.X + 5, mainRec.Y + 35), Color.White);
                    spriteBatch.DrawString(sf, "og laane dem med hjem", new Vector2(mainRec.X + 5, mainRec.Y + 65), Color.White);
                    spriteBatch.DrawString(sf, "Men da biblioteket er lukket", new Vector2(mainRec.X + 5, mainRec.Y + 95), Color.White);
                    spriteBatch.DrawString(sf, "vil bibliotekarene proeve at", new Vector2(mainRec.X + 5, mainRec.Y + 125), Color.White);
                    spriteBatch.DrawString(sf, "fange dig. Du bevaeger dig", new Vector2(mainRec.X + 5, mainRec.Y + 155), Color.White);
                    spriteBatch.DrawString(sf, "med WAS og D tasterne. ", new Vector2(mainRec.X + 5, mainRec.Y + 185), Color.White);
                    spriteBatch.DrawString(sf, "Hvis du finder et laaner-. ", new Vector2(mainRec.X + 5, mainRec.Y + 215), Color.White);
                    spriteBatch.DrawString(sf, "kort vil bibliotekarene", new Vector2(mainRec.X + 5, mainRec.Y + 245), Color.White);
                    spriteBatch.DrawString(sf, "flygte fra dig i et kort", new Vector2(mainRec.X + 5, mainRec.Y + 275), Color.White);
                    spriteBatch.DrawString(sf, "stykke tid. Held og lykke!", new Vector2(mainRec.X + 5, mainRec.Y + 305), Color.White);
                    spriteBatch.DrawString(sf, "Tilbage", new Vector2(howToPlayRec.X + 5, howToPlayRec.Y + 10), Color.White);
                    #endregion
                }


                spriteBatch.End();

            }

            base.Draw(gameTime);
        }
    }
}
