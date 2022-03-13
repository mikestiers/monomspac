using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MsPacMan.Entities;
using MsPacMan.Graphics;

namespace MsPacMan
{
    public class MsPacManGame : Game
    {
        private const string ASSET_NAME_SPRITESHEET = "mspacman_spritesheet";
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public const int WINDOW_WIDTH = 172;
        public const int WINDOW_HEIGHT = 225;

        public const int MSPACMAN_START_POSITION_X = 78;
        public const int MSPACMAN_START_POSITION_Y = 166;

        private Texture2D _spriteSheetTexture;
        private MsPacManCharacter _mspacman;
        private Map _map;

        public MsPacManGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            _graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
            _graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            _graphics.ApplyChanges();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _spriteSheetTexture = Content.Load<Texture2D>(ASSET_NAME_SPRITESHEET);
            _mspacman = new MsPacManCharacter(_spriteSheetTexture, new Vector2(MSPACMAN_START_POSITION_X, MSPACMAN_START_POSITION_Y));
            _map = new Map(_spriteSheetTexture, new Vector2(0, 0));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
            _mspacman.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            //Sprite mspacmanSprite = new Sprite(_spriteSheetTexture, 0, 0, 16, 16);
            _map.Draw(_spriteBatch, gameTime);
            _mspacman.Draw(_spriteBatch, gameTime);

            //Sprite mspacmanSprite = new Sprite(_spriteSheetTexture, 0, 0, 16, 16);
            //mspacmanSprite.Draw(_spriteBatch, new Vector2(20, 20));
   
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
