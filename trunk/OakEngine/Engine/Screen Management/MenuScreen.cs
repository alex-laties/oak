using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Oak.Engine.GameScreen
{
    class MenuScreen : BaseScreen
    {
        protected List<IMenuItem> menuItems;


        public MenuScreen()
            : base()
        {
            menuItems = new List<IMenuItem>();
        }


        public virtual void RemoveMenuItem(IMenuItem item)
        {
            menuItems.Remove(item);
        }

        public virtual void AddMenuItem(IMenuItem item)
        {
            menuItems.Add(item);
        }

        public override void UpdateOn(GameTime gameTime)
        {
            foreach (IMenuItem item in menuItems)
            {
                item.Update(gameTime);
            }
        }
    }
}
