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
                if (_mspacman.State != MsPacManState.Moving)
                {
                    _mspacman.BeginMove();
                }
            }
            if (keyboardState.IsKeyUp(Keys.Up))
            {
                _mspacman.StopMoving();
            }
            _previousKeyboardState = keyboardState;
        }
    }
}
