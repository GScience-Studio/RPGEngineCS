using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPGEngine.UI.UIComponent
{
    public abstract class UIComponent : UINode
    {
        public Texture2D Image;
        public Rectangle Rect;

        protected UIComponent()
        {
            Rect = new Rectangle(new Point(0, 0), RPGGame.GetClientBounds().Size);
        }

        public override void OnPressDown(Point pos)
        {
            foreach (var child in Children)
                if (!child.GetType().IsAssignableFrom(typeof(UIComponent)))
                {
                    child.OnPressDown(pos);
                }
                else
                {
                    var component = (UIComponent) child;
                    if (component.Rect.Contains(pos))
                        component.OnPressDown(pos);
                }
        }
    }
}