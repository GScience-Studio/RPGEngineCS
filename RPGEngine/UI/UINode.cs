using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPGEngine.UI
{
    public abstract class UINode
    {
        private Point _pos;

        protected UINode()
        {
            Children = new List<UINode>();
        }

        public Point Position
        {
            get => _pos;
            set
            {
                var delta = value - _pos;

                foreach (var child in Children)
                    child.Position += delta;

                _pos = value;
            }
        }

        public Point LocalPos
        {
            get => _pos - Parent.Position;
            set => Position = value + Parent.Position;
        }

        public List<UINode> Children { get; }
        public UINode Parent { get; private set; }

        private void SetParent(UINode parent)
        {
            Parent = parent;
            Parent?.Children.Add(this);
        }

        protected T AddChild<T>() where T : UINode, new()
        {
            var child = new T();
            child.SetParent(this);
            child.Position = Position;
            return child;
        }

        public abstract void Draw(SpriteBatch batch);
        public abstract void Update(double deltaTime);

        public virtual void OnPressDown(Point pos)
        {
            foreach (var child in Children)
                child.OnPressDown(pos);
        }

        public virtual void OnReleaseUp(Point pos)
        {
            foreach (var child in Children)
                child.OnPressDown(pos);
        }
        public virtual void OnClick(Point pos)
        {
            foreach (var child in Children)
                child.OnPressDown(pos);
        }
    }
}