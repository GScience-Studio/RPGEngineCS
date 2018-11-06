using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPGEngine.UI.UIComponent
{
    public class UIImage : UINode
    {
        public Texture2D Image;
        public Rectangle Rect;

        public UIImage()
        {
            Rect = new Rectangle(0, 0, 25, 25);
        }

        public override void Draw(SpriteBatch batch)
        {
            if (Image != null)
                batch.Draw(Image, null, new Rectangle(Rect.X + (int)Position.X, Rect.Y + (int)Position.Y, Rect.Height, Rect.Width));
        }

        public void Load(string name)
        {
            Image = RPGGame.Game.Content.Load<Texture2D>(name);
        }
    }
}
