using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RPGEngine.Content;

namespace RPGEngine.UI.UIComponent
{
    public class UIImage : UIComponent
    {
        /// <summary>
        /// 背景颜色
        /// </summary>
        public Color Background = Color.White;

        /// <summary>
        /// 背景图像
        /// </summary>
        public Texture2D BackgroundImage;

        /// <summary>
        /// 绘制
        /// </summary>
        /// <param name="batch"></param>
        public override void Draw(SpriteBatch batch)
        {
            if (BackgroundImage != null)
                batch.Draw(BackgroundImage, Rect, Background);
        }

        public UIImage()
        {
        }
        public override void Update(double deltaTime)
        {
        }

        /// <summary>
        /// 加载图像
        /// </summary>
        /// <param name="name">资源名称</param>
        public void Load(string name)
        {
            BackgroundImage = ContentManager.Get<Texture2D>(name);
        }
    }
}