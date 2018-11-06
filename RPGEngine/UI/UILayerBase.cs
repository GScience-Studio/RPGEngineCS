using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using RPGEngine.UI.UIComponent;

namespace RPGEngine.UI
{
    public class UILayerBase : UINode
    {
        public override void Draw(SpriteBatch batch)
        {
            batch.Begin();

            foreach (var component in Children)
                component.Draw(batch);

            batch.End();
        }

        public override void Update(double deltaTime)
        {
            foreach (var component in Children)
                component.Update(deltaTime);
        }
    }
}
