using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using RPGEngine.UI;

namespace RPGEngine.Scenes
{
    /// <summary>
    /// 场景类\n
    /// 在一个场景中，有一个UI层表，根据UI层打开的顺序不同会有不同的显示顺序，而且上层UI层会影响下层UI层\n
    /// 注意：只有顶层UI层会接受事件和刷新！
    /// </summary>
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
            batch.Begin();

            for (var i = _uiLayerList.Count - 1; i >= 0; --i)
                _uiLayerList[i].Draw(batch);

            batch.End();
        }

        public virtual void Update(double deltaTime)
        {
            for (var i = _uiLayerList.Count - 1; i >= 0; --i)
                _uiLayerList[i].Update(deltaTime);
        }
    }
}