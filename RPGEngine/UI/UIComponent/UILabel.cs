using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RSL;

namespace RPGEngine.UI.UIComponent
{
    public class UILabel : UIComponent
    {
        /// <summary>
        /// 所有文字都应定义在外部文本文件当中\n
        /// 格式：[XML目录]:[值]
        /// </summary>
        public string TextResKey;

        /// <summary>
        /// 字体
        /// </summary>
        public string FontName;

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
            var xmlKey = TextResKey.Substring(0, TextResKey.IndexOf(':'));
            var txtKey = TextResKey.Substring(TextResKey.IndexOf(':') + 1);
            var textDictionary = RPGGame.Game.Content.Load<TextDictionary>(xmlKey);
            
            batch.DrawString(RPGGame.Game.Content.Load<SpriteFont>(FontName), textDictionary[txtKey], Position.ToVector2(), Color.Black, 0,
                Vector2.Zero, Vector2.One, SpriteEffects.None, 0);
        }

        public override void Update(double deltaTime)
        {
        }
    }
}
