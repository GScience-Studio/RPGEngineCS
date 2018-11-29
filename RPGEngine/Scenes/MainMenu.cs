using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
    }

    public class MainMenuUILayer : UILayer
    {
        private UIBottom _btm;

        public MainMenuUILayer()
        {
            Position = new Point(25, 25);
            _btm = AddChild<UIBottom>();
            _btm.Background.Load("Icon");
        }
    }
}