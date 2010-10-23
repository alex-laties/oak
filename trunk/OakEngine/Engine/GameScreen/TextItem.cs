using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Oak.Engine.Input;

namespace Oak.Engine.GameScreen
{
    class TextItem : IMenuItem
    {
        string text = "";
        bool selected;

        Vector2 measurements, position;
        Vector2 drawPos, scale = new Vector2(1,1);
        SpriteFont font;

        #region Properties
        public string Text
        {
            get { return text; }
            set 
            { 
                text = value;
                UpdateMeasurements();
            }
        }

        public SpriteFont Font
        {
            get { return font; }
            set 
            { 
                font = value;
                UpdateMeasurements();
            }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public float Width
        {
            get { return measurements.X; }
        }

        public float Height
        {
            get { return measurements.Y; }
        }

        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        #endregion

        #region Private Methods

        private void UpdateMeasurements()
        {
            measurements = font.MeasureString(Text);
        }

        #endregion

        public TextItem(string text, SpriteFont font)
        {
            Font = font;
            Text = text;
        }

        public Vector2 GetPosition()
        {
            return position;
        }

        public void Select()
        {
            selected = true;
        }

        public void Deselect()
        {
            selected = false;
        }

        public bool IsSelected(Vector2 point)
        {
            Rectangle rect = new Rectangle((int)position.X, (int)position.Y, (int)measurements.X, (int)measurements.Y);
            bool inside = rect.Contains((int)point.X, (int)point.Y);
            if(inside)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public void Update(GameTime gameTime)
        {
            if (selected)
            {
                drawPos = position - new Vector2(10, 10);
                scale = new Vector2(1.1f, 1.1f);
            }
            else
            {
                drawPos = position;
                scale = new Vector2(1, 1);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(
                font,
                new StringBuilder(Text),
                drawPos,
                Color.White,
                0f,
                Vector2.Zero,
                scale,
                SpriteEffects.None,
                1);
        }

    }
}
