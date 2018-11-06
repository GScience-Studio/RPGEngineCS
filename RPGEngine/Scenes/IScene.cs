using Microsoft.Xna.Framework.Graphics;

namespace RPGEngine.Scenes
{
    public interface IScene
    {
        void Draw(SpriteBatch batch);
        void Update(double deltaTime);
    }
}