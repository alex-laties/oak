using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Oak.Engine.Graphics
{
    class AnimatedSprite : BaseSprite
    {
        protected Dictionary<object, string> stateToSpriteKey;
        
        int maxFrames;
        int frameCounter;
        int currentDelay;
        object currentState;
        /// <summary>
        /// The current state we are rendering.
        /// When setting, pass the variable you are using for state management (like an enum, int, bool, etc.).
        /// When getting, this must be casted to the type you are using for state management.
        /// </summary>
        public object CurrentState
        {
            get 
            { 
                return currentState; 
            }
            set
            {
                frameCounter = 0;
                maxFrames = InternalSprites[stateToSpriteKey[value]].Count;
                currentState = value;
            }
        }

        public bool StopAtEndOfAnimation
        {
            get;
            set;
        }

        /// <summary>
        /// The delay between each frame of an animation
        /// </summary>
        public int FrameDelay
        {
            get;
            set;
        }

        public AnimatedSprite()
            : base()
        {
            stateToSpriteKey = new Dictionary<object, string>();
            frameCounter = 0;
            maxFrames = 0;
        }

        public virtual void AddSprites(object key, string name, string path)
        {
            stateToSpriteKey[key] = name;
            AddSprites(name, path);
        }

        public virtual void RemoveSprites(object key)
        {
            InternalSprites.Remove(stateToSpriteKey[key]);
            stateToSpriteKey.Remove(key);
        }

        public override void Update(GameTime time)
        {
            if (currentDelay > 0)
            {
                --currentDelay;
                return;
            }
            else
            {
                currentDelay = FrameDelay;
            }
            //TODO implement this, should be pretty easy
            if (frameCounter < maxFrames)
            {
                currentTexture = InternalSprites[stateToSpriteKey[currentState]][frameCounter];
                frameCounter++;
            }
            else
            {
                if (StopAtEndOfAnimation)
                {
                    frameCounter = maxFrames;
                }
                else
                {
                    frameCounter = 0;
                    currentTexture = InternalSprites[stateToSpriteKey[currentState]][frameCounter];
                }
            }

            
        }
    }
}
