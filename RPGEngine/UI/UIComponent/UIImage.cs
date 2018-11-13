using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPGEngine.UI.UIComponent
{
    public class UIImage : UIComponent
    {
        public override void Draw(SpriteBatch batch)
        {
            if (Image != null)
                batch.Draw(Image, null,
                    new Rectangle(Rect.X + (int) Position.X, Rect.Y + (int) Position.Y, Rect.Width, Rect.Height));
        }

        public override void Update(double deltaTime)
        {
        }

        public void Load(string name)
        {
            Image = RPGGame.GetContent<Texture2D>(name);
        }
    }
}