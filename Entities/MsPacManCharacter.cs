using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MsPacMan.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MsPacMan.Entities
{
    public class MsPacManCharacter : IGameEntity
    {
        public int MSPACMAN_SPRITE_POS_X = 627;
        public int MSPACMAN_SPRITE_POS_Y = 32;
        public const int MSPACMAN_SPRITE_WIDTH = 16;
        public const int MSPACMAN_SPRITE_HEIGHT = 16;
        public Sprite Sprite { get; private set; }
        public MsPacManState State { get; private set; }
        public Vector2 Position { get; set; }
        public bool IsAlive { get; private set; }
        public float Speed { get; private set; }
        public MsPacManCharacter(Texture2D spriteSheet, Vector2 position)
        {
            Sprite = new Sprite(spriteSheet, MSPACMAN_SPRITE_POS_X, MSPACMAN_SPRITE_POS_Y, MSPACMAN_SPRITE_WIDTH, MSPACMAN_SPRITE_HEIGHT);
            Position = position;
        }

        public int DrawOrder { get; set; }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Sprite.Draw(spriteBatch, Position);
        }

        public void Update(GameTime gameTime)
        {
            
        }
    }
}
