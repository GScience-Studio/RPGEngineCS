using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RPGEngine.UI;
using RPGEngine.UI.UIComponent;

namespace RPGEngine.Scenes
{
    public class MainMenu : Scene
    {
        public MainMenu()
        {
            OpenUILayer<MainMenuUILayer>();
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            //throw new NotImplementedException();
        }
    }

    public class MainMenuUILayer : UILayer
    {
        private UIImage _img;

        public MainMenuUILayer()
        {
            Position = new Vector2(25, 25);
            _img = AddChild<UIImage>();
            _img.Load("Icon");
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            var result = TouchInput.IsDrag();
            if (result)
                _img.Position = result.Pos.ToVector2();
        }
    }
}