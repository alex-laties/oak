using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Oak.Engine.Input;
using Oak.Engine.Graphics;

namespace Oak.Engine.GameScreen
{
    class TextItem : IMenuItem
    {
        string text = "";
        public bool selected;
        Renderable toRender;


        Texture2D rectangle; 

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
            toRender = new Renderable();
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
                drawPos = position - new Vector2(10, 5);
                scale = new Vector2(1.1f, 1.1f);


                if (rectangle == null)
                {
                    rectangle = Oak.ContentAccess.Load<Texture2D>("./Engine/Test Graphics/Menu/MenuItemBackground");
                }
                Renderable r = new Renderable();

                r.texture = rectangle;
                r.frame = new Rectangle((int)drawPos.X - 5, (int)drawPos.Y, rectangle.Width, rectangle.Height);
                r.selection = null;
                r.rotation = 0;
                r.origin = Vector2.Zero;
                r.tint = Color.White;
                r.layerDepth = 0.5f;
                r.effect = SpriteEffects.None;

                toRender.tint = Color.Black;

                GraphicsManager.AddRenderable(r);
            }
            else
            {
                drawPos = position;
                scale = new Vector2(1, 1);
                toRender.tint = Color.White;
            }

            //prepare renderable
            toRender.isText = true;
            toRender.font = font;
            toRender.text = text;
            toRender.textPosition = drawPos;
            
            toRender.rotation = 0f;
            toRender.origin = Vector2.Zero;
            toRender.textScale = scale;
            toRender.effect = SpriteEffects.None;
            toRender.layerDepth = 1.0f;

            GraphicsManager.AddRenderable(toRender);
        }
    }
}
