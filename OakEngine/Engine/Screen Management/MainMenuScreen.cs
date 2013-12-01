using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Oak.Engine.Graphics;

namespace Oak.Engine.GameScreen
{
    class MainMenuScreen : MenuScreen
    {
        int SelectedIndex = 0;

        public MainMenuScreen()
            : base()
        {
            this.kbm.BindKey(Microsoft.Xna.Framework.Input.Keys.Up, MoveUp);
            this.kbm.BindKey(Microsoft.Xna.Framework.Input.Keys.Down, MoveDown);
            this.kbm.BindKey(Microsoft.Xna.Framework.Input.Keys.Enter, MenuAction);

            State = ScreenVisibleState.On;
            
            TextItem textItem = new TextItem("Start Game", ScreenManager.font);
            textItem.Position = new Microsoft.Xna.Framework.Vector2(200, 200);
            textItem.Selected = true;
            AddMenuItem(textItem);

            TextItem textItem2 = new TextItem("Options", ScreenManager.font);
            textItem2.Position = new Microsoft.Xna.Framework.Vector2(200, 225);
            textItem2.Selected = false;
            AddMenuItem(textItem2);

            TextItem textItem3 = new TextItem("Quit", ScreenManager.font);
            textItem3.Position = new Microsoft.Xna.Framework.Vector2(200, 250);
            textItem3.Selected = false;
            AddMenuItem(textItem3);
        }


        public override void UpdateOn(GameTime time)
        {
            //Create Background Renderable
            Texture2D bgimage = Oak.ContentAccess.Load<Texture2D>("./Engine/Test Graphics/Backgrounds/MainMenuBackground");

            Renderable bg = new Renderable();

            bg.isText = false;
            bg.frame = new Rectangle(0, 0, bgimage.Width, bgimage.Height);
            bg.texture = bgimage;
            bg.origin = new Vector2(0, 0);
            bg.selection = null;
            bg.rotation = 0;
            bg.layerDepth = 0.4f;
            bg.tint = Color.White;
            bg.effect = SpriteEffects.None;

            GraphicsManager.AddRenderable(bg);

            base.UpdateOn(time);
        }

        public void MoveUp(GameTime time)
        {

            menuItems[SelectedIndex].Deselect();

            if (SelectedIndex > 0)
            {
                SelectedIndex--;
            }
            else
            {
                SelectedIndex = (menuItems.Count - 1);
            }

            menuItems[SelectedIndex].Select();


        }

        public void MoveDown(GameTime time)
        {
            menuItems[SelectedIndex].Deselect();

            if (SelectedIndex < (menuItems.Count - 1))
            {
                SelectedIndex++;
            }
            else
            {
                SelectedIndex = 0;
            }

            menuItems[SelectedIndex].Select();
        }

        public void MenuAction(GameTime time)
        {
            //Do stuff here.....
            if (SelectedIndex == 0)
            {
                ScreenManager.ToggleScreen("MainMenu");
                ScreenManager.ToggleScreen("world", ScreenVisibleState.On);
                ScreenManager.FocusScreen("world");
            }

            if (SelectedIndex == 2)
            {
                State = ScreenVisibleState.Off;
            }

        }

    }
}
