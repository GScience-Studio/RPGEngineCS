using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPGEngine.UI.UIComponent
{
    public enum BottomState
    {
        Pressed, Released
    }

    public class UIBottom : UIComponent
    {
        public UIImage Background;

        public BottomState BottomState => 
            Rect.Contains(Input.Position) && Input.IsPressed 
                ? BottomState.Pressed : BottomState.Released;

        public UIBottom()
        {
            Background = AddChild<UIImage>();
        }

        public override void Update(double deltaTime)
        {
            Background.LocalPos = BottomState == BottomState.Pressed ? 
                new Point(RPGGame.GetClientBounds().Height / 50, RPGGame.GetClientBounds().Height / 50) : new Point(0, 0);
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
        }
    }
}
