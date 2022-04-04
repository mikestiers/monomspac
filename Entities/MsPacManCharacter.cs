﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MsPacMan.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MsPacMan.Entities
{
    public class MsPacManCharacter : IGameEntity
    {
        private const float MSPACMAN_VELOCITY = -30f;
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
            else if (State == MsPacManState.Moving)
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
            else if (State == MsPacManState.Moving)
            {
                Position = new Vector2(Position.X, Position.Y + _mspacmanVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds);
                //State = MsPacManState.Idle;
            }
        }

        private void CreateChewAnimation()
        {

            _mspacmanChewAnimation = new SpriteAnimation();
            _mspacmanChewAnimation.ShouldLoop = true;

            double blinkTimeStamp = BLINK_ANIMATION_RANDOM_MIN + _random.NextDouble() * (BLINK_ANIMATION_RANDOM_MAX - BLINK_ANIMATION_RANDOM_MIN);

            _mspacmanChewAnimation.AddFrame(_mspacmanMouthClosedSprite, 0);
            //_mspacmanChewAnimation.AddFrame(_mspacmanMouthHalfOpenedSprite, (float)blinkTimeStamp);
            _mspacmanChewAnimation.AddFrame(_mspacmanMouthHalfOpenedSprite, 0.3f);
            _mspacmanChewAnimation.AddFrame(_mspacmanMouthFullyOpenedSprite, 0.6f);
            //_mspacmanChewAnimation.AddFrame(_mspacmanMouthClosedSprite, (float)blinkTimeStamp + BLINK_ANIMATION_MOUTH_CLOSED_TIME); // dummy key frame to reset animation
        }

        public bool BeginMove()
        {
            //if (State == MsPacManState.Moving || State == MsPacManState.Idle)
            //    return false;

            State = MsPacManState.Moving;
            _mspacmanVelocity = MSPACMAN_VELOCITY;
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
