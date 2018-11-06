using Microsoft.Xna.Framework.Graphics;

namespace RPGEngine.Scenes
{
    public class SceneManager
    {
        private static IScene _scene;

        public static void SwitchTo<T>() where T : IScene, new()
        {
            _scene = new T();
        }

        public static void Draw(SpriteBatch batch)
        {
            _scene?.Draw(batch);
        }

        public static void Update(double deltaTime)
        {
            _scene?.Update(deltaTime);
        }
    }
}