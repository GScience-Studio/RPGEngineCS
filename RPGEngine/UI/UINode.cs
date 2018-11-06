using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPGEngine.UI
{
    public class UINode
    {
        private Vector2 _pos;

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

        protected UINode()
        {
            Children = new List<UINode>();
        }

        protected T AddChild<T>() where T: UINode, new()
        {
            var child = new T();
            child.SetParent(this);
            child.Position = Position;
            return child;
        }

        public virtual void Draw(SpriteBatch batch)
        {
        }

        public virtual void Update(double deltaTime)
        {
        }
    }
}
