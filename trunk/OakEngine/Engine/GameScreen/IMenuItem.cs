using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Oak.Engine.Input;

namespace Oak.Engine.GameScreen
{
    public interface IMenuItem
    {

        //<summary>
        //The position of the menu item
        //</summary>
        Vector2 GetPosition();

        //<summary>
        //Checks if the mouse is over the item
        //</summary>
        bool IsSelected(Vector2 point);

        //<summary>
        //Selects the item
        //</summary>
        void Select();
        void Deselect();

        //<summary>
        //Updates the menu item
        //</summary>
        void Update(GameTime gameTime);

        //<summary>
        //Draws the menu item to the screen
        //</summary>
        void Draw(SpriteBatch spriteBatch);
    }
}
