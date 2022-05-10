using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MsPacMan.Entities;

namespace MsPacMan.System
{
    public class InputController
    {
        private MsPacManCharacter _mspacman;

        private KeyboardState _previousKeyboardState;
        public InputController(MsPacManCharacter mspacman)
        {
            _mspacman = mspacman;
        }

        public void ProcessControls(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (!_previousKeyboardState.IsKeyDown(Keys.Up) && keyboardState.IsKeyDown(Keys.Up))
            {
                if (_mspacman.State != MsPacManState.MovingUp)
                {
                    _mspacman.MoveUp();
                }
            }
            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                if (_mspacman.State != MsPacManState.MovingDown)
                {
                    _mspacman.MoveDown();
                }
            }
            else if (keyboardState.IsKeyDown(Keys.Left))
            {
                if (_mspacman.State != MsPacManState.MovingLeft)
                {
                    _mspacman.MoveLeft();
                }
            }
            else if (keyboardState.IsKeyDown(Keys.Right))
            {
                if (_mspacman.State != MsPacManState.MovingRight)
                {
                    _mspacman.MoveRight();
                }
            }
            else if (keyboardState.IsKeyUp(Keys.Up))
            {
                _mspacman.StopMoving();
            }
            _previousKeyboardState = keyboardState;
        }
    }
}
