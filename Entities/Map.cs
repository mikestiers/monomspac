using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MsPacMan.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MsPacMan.Entities
{
    public class Map : IGameEntity
    {
        public int MAP_SPRITE_POS_X = 2;
        public int MAP_SPRITE_POS_Y = 2;
        public int MAP_SPRITE_WIDTH = 170;
        public int MAP_SPRITE_HEIGHT = 225;
        public Sprite Sprite { get; private set; }
        public Vector2 Position { get; set; }

        public static char[,] Map_1 = new char[,]
        {
                { 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x'},
                { 'x', '.', '.', '.', '.', '.', 'x', '.', '.', '.', '.', '.', '.', '.', 'x', '.', '.', '.', '.', '.', 'x'},
                { 'x', 'o', 'x', 'x', 'x', '.', 'x', '.', 'x', 'x', 'x', 'x', 'x', '.', 'x', '.', 'x', 'x', 'x', 'o', 'x'},
                { 'x', '.', 'x', 'x', 'x', '.', 'x', '.', 'x', 'x', 'x', 'x', 'x', '.', 'x', '.', 'x', 'x', 'x', '.', 'x'},
                { 'x', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', 'x'},
                { 'x', 'x', 'x', '.', 'x', '.', 'x', 'x', 'x', '.', 'x', '.', 'x', 'x', 'x', '.', 'x', '.', 'x', 'x', 'x'},
                { 'x', 'x', 'x', '.', 'x', '.', 'x', 'x', 'x', '.', 'x', '.', 'x', 'x', 'x', '.', 'x', '.', 'x', 'x', 'x'},
                { 'x', 'x', 'x', '.', 'x', '.', 'x', 'x', 'x', '.', 'x', '.', 'x', 'x', 'x', '.', 'x', '.', 'x', 'x', 'x'},
                { 'x', 'x', 'x', '.', 'x', '.', '.', '.', '.', '.', 'x', '.', '.', '.', '.', '.', 'x', '.', 'x', 'x', 'x'},
                { 'x', 'x', 'x', '.', 'x', 'x', 'x', ' ', 'x', 'x', 'x', 'x', 'x', ' ', 'x', 'x', 'x', '.', 'x', 'x', 'x'},
                { 'x', 'x', 'x', '.', 'x', 'x', 'x', ' ', 'x', 'x', 'x', 'x', 'x', ' ', 'x', 'x', 'x', '.', 'x', 'x', 'x'},
                { 'x', 'x', 'x', '.', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '.', 'x', 'x', 'x'},
                { 'x', 'x', 'x', '.', 'x', 'x', 'x', ' ', 'x', 'x', 'x', 'x', 'x', ' ', 'x', 'x', 'x', '.', 'x', 'x', 'x'},
                { 'x', 'x', 'x', '.', 'x', ' ', ' ', ' ', 'x', 'x', 'x', 'x', 'x', ' ', ' ', ' ', 'x', '.', 'x', 'x', 'x'},
                { 'x', 'x', 'x', '.', 'x', ' ', 'x', ' ', 'x', 'x', 'x', 'x', 'x', ' ', 'x', ' ', 'x', '.', 'x', 'x', 'x'},
                { 'x', 'x', 'x', '.', 'x', ' ', 'x', ' ', 'x', 'x', 'x', 'x', 'x', ' ', 'x', ' ', 'x', '.', 'x', 'x', 'x'},
                { 'x', 'x', 'x', '.', ' ', ' ', 'x', ' ', 'x', 'x', 'x', 'x', 'x', ' ', 'x', ' ', ' ', '.', 'x', 'x', 'x'},
                { 'x', 'x', 'x', '.', 'x', 'x', 'x', 'x', 'x', ' ', 'x', ' ', 'x', 'x', 'x', 'x', 'x', '.', 'x', 'x', 'x'},
                { 'x', 'x', 'x', '.', '.', '.', '.', '.', ' ', ' ', 'x', ' ', ' ', '.', '.', '.', '.', '.', 'x', 'x', 'x'},
                { 'x', 'x', 'x', '.', 'x', 'x', 'x', '.', 'x', 'x', 'x', 'x', 'x', '.', 'x', 'x', 'x', '.', 'x', 'x', 'x'},
                { 'x', 'x', 'x', '.', 'x', 'x', 'x', '.', 'x', 'x', 'x', 'x', 'x', '.', 'x', 'x', 'x', '.', 'x', 'x', 'x'},
                { 'x', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', 'x'},
                { 'x', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', 'x'},
                { 'x', '.', 'x', 'x', 'x', '.', 'x', '.', 'x', 'x', 'x', 'x', 'x', '.', 'x', '.', 'x', 'x', 'x', '.', 'x'},
                { 'x', 'o', 'x', 'x', 'x', '.', 'x', '.', 'x', 'x', 'x', 'x', 'x', '.', 'x', '.', 'x', 'x', 'x', 'o', 'x'},
                { 'x', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', 'x'},
                { 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x'}
        };
        public Map(Texture2D spriteSheet, Vector2 position)
        {
            Sprite = new Sprite(spriteSheet, MAP_SPRITE_POS_X, MAP_SPRITE_POS_Y, MAP_SPRITE_WIDTH, MAP_SPRITE_HEIGHT);
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
