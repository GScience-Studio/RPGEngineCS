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
            foreach (var child in Children)
                child.Draw(batch);
        }

        public override void Update(double deltaTime)
        {
            foreach (var component in Children)
                component.Update(deltaTime);

            if (Input.IsClick)
                foreach (var component in Children)
                    component.OnPressDown(Input.Position);
        }
    }
}