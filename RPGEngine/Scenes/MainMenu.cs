using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RPGEngine.UI;
using RPGEngine.UI.UIComponent;

namespace RPGEngine.Scenes
{
    public class MainMenu : IScene
    {
        private MainMenuUILayer _uiLayer = new MainMenuUILayer();
        public void Draw(SpriteBatch batch)
        {
            _uiLayer.Draw(batch);
        }

        public void Update(double deltaTime)
        {
            //throw new NotImplementedException();
        }
    }

    public class MainMenuUILayer : UILayerBase
    {
        public MainMenuUILayer()
        {
            Position = new Vector2(25, 25);
            var image = AddChild<UIImage>();
            image.Load("Icon");
        }
    }
}