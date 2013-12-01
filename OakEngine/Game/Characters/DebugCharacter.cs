using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oak.Engine.Entities;
using Oak.Engine.Graphics;

namespace Oak.Game.Characters
{
    class DebugCharacter : BaseCharacter
    {
        static string PATH_TO_SPRITES = "./Game/Sprites/Player/";

        public DebugCharacter()
            : base()
        {
            Sprite = new StillSprite(PATH_TO_SPRITES + "Rodel");
            CharacterType = CharacterType.Object;
        }

    }
}
