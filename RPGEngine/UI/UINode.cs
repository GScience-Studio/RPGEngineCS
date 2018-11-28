using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPGEngine.UI
{
    public abstract class UINode
    {
        private Vector2 _pos;

        protected UINode()
        {
            Children = new List<UINode>();
        }

        public Vector2 Position
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

        public virtual void OnPressDown(Vector2 pos)
        {
            foreach (var child in Children)
                child.OnPressDown(pos);
        }
    }
}