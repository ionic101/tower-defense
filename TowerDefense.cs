using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Text.Json;

namespace TowerDefense
{
    public class TowerDefense : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private GameSessionData sessionData;
        private GameViewer gameViewer;
        private PlayerController playerController;
        
        private void LoadConfig()
        {
            var config = ConfigLoader.LoadConfigJSON<Dictionary<string, JsonElement>>();

            ConfigLoader.SavePropertyToVariable(config["ScreenWidth"], out Settings.ScreenWidth);
            ConfigLoader.SavePropertyToVariable(config["ScreenHeight"], out Settings.ScreenHeight);
            ConfigLoader.SavePropertyToVariable(config["Fullscreen"], out Settings.IsFullscreen);
        }

        public TowerDefense()
        {
            LoadConfig();

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "sprites";
            IsMouseVisible = true;

            graphics.PreferredBackBufferWidth = Settings.ScreenWidth;
            graphics.PreferredBackBufferHeight = Settings.ScreenHeight;
            graphics.IsFullScreen = Settings.IsFullscreen;
        }

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            sessionData = new GameSessionData();
            sessionData.Init();

            gameViewer = new GameViewer();
            gameViewer.Init(spriteBatch, sessionData);

            playerController = new PlayerController(sessionData);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            var cellTextures = new Dictionary<CellType, Texture2D>();

            var grassTexture = Content.Load<Texture2D>("grass");
            cellTextures.Add(CellType.Empty, grassTexture);
            cellTextures.Add(CellType.Tower, grassTexture);

            var roadTexture = Content.Load<Texture2D>("road");
            cellTextures.Add(CellType.Road, roadTexture);
            cellTextures.Add(CellType.Start, roadTexture);

            gameViewer.MapViewer.LoadTextures(cellTextures);


            var towerTextures = new Dictionary<TowerType, Texture2D>()
            {
                { TowerType.Policeman, Content.Load<Texture2D>("policeman")},
                { TowerType.Soldier, Content.Load<Texture2D>("soldier")},
                { TowerType.Sniper, Content.Load<Texture2D>("sniper")},
                { TowerType.Rocketman, Content.Load<Texture2D>("rocketman")}
            };
            gameViewer.TowersViewer.LoadTextures(towerTextures);


            var healthBarTexture = new Texture2D(GraphicsDevice, 1, 1);
            healthBarTexture.SetData(new[] { Color.Red });

            var enemyTextures = new Dictionary<EnemyType, Texture2D>()
            {
                { EnemyType.Zombie, Content.Load<Texture2D>("zombie")},
                { EnemyType.StoneZombie, Content.Load<Texture2D>("stone")},
                { EnemyType.FastZombie, Content.Load<Texture2D>("faster")},
                { EnemyType.GiantZombie, Content.Load<Texture2D>("giant")}
            };
            gameViewer.EnemysViewer.LoadTextures(enemyTextures, healthBarTexture);


            var squareTexture = Content.Load<Texture2D>("select");

            gameViewer.SelecterViewer.LoadTexture(squareTexture);

            var slotTexture = Content.Load<Texture2D>("slot");
            var spriteFont = Content.Load<SpriteFont>("font");
            gameViewer.TowerStoreViewer.LoadTextures(towerTextures, slotTexture, spriteFont);

            gameViewer.InfoViewer.LoadTexture(spriteFont);
        }

        protected override void Update(GameTime gameTime)
        {
            //Controller
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            playerController.ListenEvents();

            //Data
            var dt = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            sessionData.Update(dt);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            spriteBatch.Begin();

            gameViewer.Display();

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
