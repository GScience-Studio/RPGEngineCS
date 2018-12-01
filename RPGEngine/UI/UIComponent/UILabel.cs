using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPGEngine.UI.UIComponent
{
    public class UILabel : UIComponent
    {
        /// <summary>
        /// 显示的文本
        /// </summary>
        public string Text;

        /// <summary>
        /// 字体
        /// </summary>
        public string FontName;

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);

            batch.DrawString(RPGGame.Game.Content.Load<SpriteFont>(FontName), Text, Position.ToVector2(), Color.Black, 0,
                Vector2.Zero, Vector2.One, SpriteEffects.None, 0);
        }

        public override void Update(double deltaTime)
        {
        }
    }
}
