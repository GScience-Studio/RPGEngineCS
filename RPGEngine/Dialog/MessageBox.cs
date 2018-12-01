using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using RPGEngine.Scenes;
using RPGEngine.UI;
using RPGEngine.UI.UIComponent;

namespace RPGEngine.Dialog
{
    public class MessageBox : Dialog
    {
        public class MessageBoxUILayer : UILayer
        {
            public MessageBoxUILayer()
            {
                AddChild<UIImage>().BackgroundImage = RPGGame.Game.Content.Load<Texture2D>("DialogElement/Background");
                var label = AddChild<UILabel>();
                label.Text = RPGTextRes.MessageBox.Test;
                label.FontName = "Font/MessageBox";
            }
        }

        public MessageBox(string message)
        {

        }
        public override void Show(Scene owner)
        {
            owner.OpenUILayer<MessageBoxUILayer>();
        }
    }
}
