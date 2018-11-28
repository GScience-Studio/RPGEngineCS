using Microsoft.Xna.Framework.Graphics;
using RPGEngine.Scenes;

namespace RPGEngine.UI
{
    public abstract class UILayer : UINode
    {
        private Scene _owner;

        public void BindTo(Scene owner)
        {
            _owner = owner;
        }

        public void Close()
        {
            _owner.CloseUILayer(this);
        }

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

            if (TouchInput.IsClick)
                foreach (var component in Children)
                    component.OnPressDown(TouchInput.Position);
        }
    }
}