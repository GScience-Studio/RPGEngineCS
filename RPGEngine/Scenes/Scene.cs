using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using RPGEngine.UI;

namespace RPGEngine.Scenes
{
    public abstract class Scene
    {
        private readonly List<UILayer> _uiLayerList = new List<UILayer>();

        public T OpenUILayer<T>() where T : UILayer, new()
        {
            var layer = new T();
            _uiLayerList.Add(layer);
            layer.BindTo(this);
            return layer;
        }

        public void CloseUILayer(UILayer layer)
        {
            _uiLayerList.Remove(layer);
        }

        public virtual void Draw(SpriteBatch batch)
        {
            if (_uiLayerList.Count != 0)
                _uiLayerList[_uiLayerList.Count - 1].Draw(batch);
        }

        public virtual void Update(double deltaTime)
        {
            if (_uiLayerList.Count != 0)
                _uiLayerList[_uiLayerList.Count - 1].Update(deltaTime);
        }
    }
}