using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPGEngine.UI.UIComponent
{
    public abstract class UIComponent : UINode
    {
        public delegate void InputHandler(Point pos);

        /// <summary>
        /// 点击
        /// </summary>
        public event InputHandler OnPressDownEvent;

        /// <summary>
        /// 释放
        /// </summary>
        public event InputHandler OnReleaseUpEvent;

        /// <summary>
        /// 点击
        /// </summary>
        public event InputHandler OnClickEvent;

        /// <summary>
        /// 位置
        /// </summary>
        public Rectangle Rect
        {
            get => new Rectangle(Position, Size);
            set
            {
                Size = value.Size;
                Position = value.Location;
            }
        }

        /// <summary>
        /// 大小
        /// </summary>
        public Point Size;

        protected UIComponent()
        {
            Size = RPGGame.GetClientBounds().Size;
        }

        /// <summary>
        /// 渲染
        /// </summary>
        /// <param name="batch"></param>
        public override void Draw(SpriteBatch batch)
        {
            foreach (var child in Children)
                child.Draw(batch);
        }

        /// <summary>
        /// 当鼠标按下
        /// </summary>
        /// <param name="pos">点击的位置</param>
        public sealed override void OnPressDown(Point pos)
        {
            OnPressDownEvent?.Invoke(pos);

            foreach (var child in Children)
            {
                var component = child as UIComponent;
                if (component?.Rect.Contains(pos) != false)
                    child.OnPressDown(pos);
            }
        }

        /// <summary>
        /// 当鼠标释放
        /// </summary>
        /// <param name="pos">点击的位置</param>
        public sealed override void OnReleaseUp(Point pos)
        {
            OnReleaseUpEvent?.Invoke(pos);

            foreach (var child in Children)
            {
                var component = child as UIComponent;
                if (component?.Rect.Contains(pos) != false)
                    child.OnReleaseUp(pos);
            }
        }

        /// <summary>
        /// 当点击
        /// </summary>
        /// <param name="pos">点击的位置</param>
        public sealed override void OnClick(Point pos)
        {
            OnClickEvent?.Invoke(pos);

            foreach (var child in Children)
            {
                var component = child as UIComponent;
                if (component?.Rect.Contains(pos) != false)
                    child.OnClick(pos);
            }
        }
    }
}