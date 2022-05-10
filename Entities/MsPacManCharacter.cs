using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MsPacMan.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MsPacMan.Entities
{
    public class MsPacManCharacter : IGameEntity
    {
        private const float MSPACMAN_VELOCITY_UP = -30f;
        private const float MSPACMAN_VELOCITY_DOWN = 30f;
        private const float MSPACMAN_VELOCITY_LEFT = -30f;
        private const float MSPACMAN_VELOCITY_RIGHT = 30f;
        private const int MSPACMAN_IDLE_SPRITE_POS_X = 628;
        private const int MSPACMAN_IDLE_SPRITE_POS_Y = 47;
        public int MSPACMAN_SPRITE_POS_X = 628;
        public int MSPACMAN_SPRITE_POS_Y = 33;
        public const int MSPACMAN_SPRITE_WIDTH = 16;
        public const int MSPACMAN_SPRITE_HEIGHT = 16;
        private const float BLINK_ANIMATION_RANDOM_MIN = 3f;
        private const float BLINK_ANIMATION_RANDOM_MAX = 10f;
        private const float BLINK_ANIMATION_MOUTH_CLOSED_TIME = 0.5f;
        private Sprite _idleBackgroundSprite;
        private Sprite _mspacmanMouthClosedSprite;
        private Sprite _mspacmanMouthHalfOpenedSprite;
        private Sprite _mspacmanMouthFullyOpenedSprite;
        private SpriteAnimation _mspacmanChewAnimation;
        private Random _random;
        private float _mspacmanVelocity;
        public MsPacManState State { get; private set; }
        public Vector2 Position { get; set; }
        public bool IsAlive { get; private set; }
        public float Speed { get; private set; }
        public MsPacManCharacter(Texture2D spriteSheet, Vector2 position)
        {
            Position = position;
            _idleBackgroundSprite = new Sprite(spriteSheet, MSPACMAN_IDLE_SPRITE_POS_X, MSPACMAN_IDLE_SPRITE_POS_Y, MSPACMAN_SPRITE_WIDTH, MSPACMAN_SPRITE_HEIGHT);
            State = MsPacManState.Idle;
            _random = new Random();

            _mspacmanMouthClosedSprite = new Sprite(spriteSheet, MSPACMAN_SPRITE_POS_X, MSPACMAN_SPRITE_POS_Y, MSPACMAN_SPRITE_WIDTH, MSPACMAN_SPRITE_HEIGHT);
            _mspacmanMouthHalfOpenedSprite = new Sprite(spriteSheet, 645, 33, MSPACMAN_SPRITE_WIDTH, MSPACMAN_SPRITE_HEIGHT);
            _mspacmanMouthFullyOpenedSprite = new Sprite(spriteSheet, 662, 33, MSPACMAN_SPRITE_WIDTH, MSPACMAN_SPRITE_HEIGHT);

            CreateChewAnimation();
            _mspacmanChewAnimation.Play();
        }

        public int DrawOrder { get; set; }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (State == MsPacManState.Idle)
            {
                _idleBackgroundSprite.Draw(spriteBatch, this.Position);
                _mspacmanChewAnimation.Draw(spriteBatch, Position);
            }
            else if (State != MsPacManState.Idle)
            {
                _idleBackgroundSprite.Draw(spriteBatch, this.Position);
                _mspacmanChewAnimation.Draw(spriteBatch, Position);
            }
        }

        public void Update(GameTime gameTime)
        {
            if (State == MsPacManState.Idle)
            {
                if (!_mspacmanChewAnimation.IsPlaying)
                {
                    CreateChewAnimation();
                    _mspacmanChewAnimation.Play();
                }

                _mspacmanChewAnimation.Update(gameTime);
            }
            else if (State == MsPacManState.MovingUp)
            {
                Position = new Vector2(Position.X, Position.Y + _mspacmanVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds);
                _mspacmanChewAnimation.Update(gameTime);
            }
            else if (State == MsPacManState.MovingDown)
            {
                Position = new Vector2(Position.X, Position.Y + _mspacmanVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds);
                _mspacmanChewAnimation.Update(gameTime);
            }
            else if (State == MsPacManState.MovingLeft)
            {
                Position = new Vector2(Position.X + _mspacmanVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds, Position.Y);
                _mspacmanChewAnimation.Update(gameTime);
            }
            else if (State == MsPacManState.MovingRight)
            {
                Position = new Vector2(Position.X + _mspacmanVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds, Position.Y);
                _mspacmanChewAnimation.Update(gameTime);
            }
            if (State != MsPacManState.MovingUp)
            {
                Debug.WriteLine("X: " + Position.X);
                Debug.WriteLine("Y: " + Position.Y);

                Dictionary<int, Cell> cells = new Dictionary<int, Cell>();
                Cell cell_00 = new Cell(0, 0, false, false);
                Cell cell_01 = new Cell(12, 0, false, false);
                Cell cell_02 = new Cell(24, 0, false, false);
                Cell cell_03 = new Cell(36, 0, false, false);
                Cell cell_04 = new Cell(48, 0, false, false);
                Cell cell_05 = new Cell(60, 0, false, false);
                Cell cell_06 = new Cell(72, 0, false, false);
                Cell cell_07 = new Cell(84, 0, false, false);
                Cell cell_08 = new Cell(96, 0, false, false);
                Cell cell_09 = new Cell(108, 0, false, false);
                Cell cell_010 = new Cell(120, 0, true, true);
                Cell cell_011 = new Cell(132, 0, false, false);
                Cell cell_012 = new Cell(144, 0, false, false);
                Cell cell_013 = new Cell(156, 0, false, false);
                Cell cell_014 = new Cell(168, 0, false, false);
                Cell cell_015 = new Cell(180, 0, false, false);
                Cell cell_016 = new Cell(192, 0, false, false);
                Cell cell_017 = new Cell(204, 0, false, false);
                Cell cell_018 = new Cell(216, 0, false, false);
                Cell cell_019 = new Cell(228, 0, false, false);
                Cell cell_020 = new Cell(240, 0, false, false);

                cells.Add(00, cell_00);
                cells.Add(01, cell_01);
                cells.Add(02, cell_02);
                cells.Add(03, cell_03);
                cells.Add(04, cell_04);
                cells.Add(05, cell_05);
                cells.Add(06, cell_06);
                cells.Add(07, cell_07);
                cells.Add(08, cell_08);
                cells.Add(09, cell_09);
                cells.Add(10, cell_010);
                cells.Add(11, cell_011);
                cells.Add(12, cell_012);
                cells.Add(13, cell_013);
                cells.Add(14, cell_014);
                cells.Add(15, cell_015);
                cells.Add(16, cell_016);
                cells.Add(17, cell_017);
                cells.Add(18, cell_018);
                cells.Add(19, cell_019);
                cells.Add(20, cell_020);

                var currentLocationX = cells.Select(Item => Item.Value.x == (int)Position.X);
                var currentLocationY = cells.Select(Item => Item.Value.y == (int)Position.Y);
                Debug.WriteLine("sup " + currentLocationY.First());

                if (currentLocationY.First())
                {
                    Debug.WriteLine("currentLocationY: " + currentLocationY.First());
                }

                Dictionary<int, int> block = new Dictionary<int, int>();
                block.Add(0, 0);
                block.Add(12, 0);
                block.Add(24, 0);
                block.Add(77, 160);

                if (block.ContainsKey((int)Position.X) && block.ContainsValue((int)Position.Y))
                {
                    Debug.WriteLine(block.ContainsKey((int)Position.X));
                }

                if (cells.ContainsKey((int)Position.Y))
                {
                    Debug.WriteLine(cells[(int)Position.Y]);
                }
                if ((int)Position.Y <= 12)
                {
                    Debug.WriteLine("hit 0");
                    State = MsPacManState.Idle;
                }
            }
        }

        private void CreateChewAnimation()
        {

            _mspacmanChewAnimation = new SpriteAnimation();
            _mspacmanChewAnimation.ShouldLoop = true;

            double blinkTimeStamp = BLINK_ANIMATION_RANDOM_MIN + _random.NextDouble() * (BLINK_ANIMATION_RANDOM_MAX - BLINK_ANIMATION_RANDOM_MIN);

            _mspacmanChewAnimation.AddFrame(_mspacmanMouthClosedSprite, 0);
            _mspacmanChewAnimation.AddFrame(_mspacmanMouthHalfOpenedSprite, 0.3f);
            _mspacmanChewAnimation.AddFrame(_mspacmanMouthFullyOpenedSprite, 0.6f);
        }

        public bool MoveUp()
        {
            State = MsPacManState.MovingUp;
            _mspacmanVelocity = MSPACMAN_VELOCITY_UP;
            return true;
        }
        public bool MoveDown()
        {
            State = MsPacManState.MovingDown;
            _mspacmanVelocity = MSPACMAN_VELOCITY_DOWN;
            return true;
        }
        public bool MoveLeft()
        {
            State = MsPacManState.MovingLeft;
            _mspacmanVelocity = MSPACMAN_VELOCITY_LEFT;
            return true;
        }
        public bool MoveRight()
        {
            State = MsPacManState.MovingRight;
            _mspacmanVelocity = MSPACMAN_VELOCITY_RIGHT;
            return true;
        }

        public bool StopMoving()
        {
            State = MsPacManState.Idle;
            _mspacmanVelocity = 0;
            return true;
        }
            
    }
}
