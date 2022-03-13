using System;
using System.Collections.Generic;
using System.Text;

namespace MsPacMan.Graphics
{
    public class SpriteAnimationFrame
    {
        // private Sprite _sprite and public Sprite Sprite is not really needed.  Doing it
        // as an example of throwing argumentnullexception error in the constructor.
        // can really just be "public Sprite Sprite"
        private Sprite _sprite;
        public Sprite Sprite {
            get
            {
                return _sprite;
            }
            set
            {
                if(value == null)
                    throw new ArgumentNullException("value", "The sprite cannot be null.");
                _sprite = value;
            }
        }

        public float TimeStamp { get; }

        public SpriteAnimationFrame(Sprite sprite, float timeStamp)
        {
            Sprite = sprite;
            TimeStamp = timeStamp;
        }

    }
}
