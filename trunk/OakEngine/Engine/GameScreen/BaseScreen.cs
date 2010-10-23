using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Oak.Engine.GameScreen
{
    public enum ScreenStates
    {
        On,
        Off,
    }

    public class BaseScreen
    {
        protected List<IMenuItem> menuItems = new List<IMenuItem>();
        ScreenStates state;

        public ScreenStates State
        {
            get { return state; }
            set { state = value; }
        }

        public BaseScreen()
        {
            
        }

        public virtual void RemoveMenuItem(IMenuItem item)
        {
            menuItems.Remove(item);
        }

        public virtual void AddMenuItem(IMenuItem item)
        {
            menuItems.Add(item);
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (IMenuItem item in menuItems)
            {
                item.Update(gameTime);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < menuItems.Count; i++)
            {
                menuItems[i].Draw(spriteBatch);
            }
        }
    }
}
