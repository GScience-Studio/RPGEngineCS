using Microsoft.Xna.Framework.Graphics;

namespace RPGEngine.Scenes
{
    public class SceneManager
    {
        public static Scene Scene { get; private set; }

        public static void SwitchTo<T>() where T : Scene, new()
        {
            Scene = new T();
        }

        public static void Draw(SpriteBatch batch)
        {
            Scene?.Draw(batch);
        }

        public static void Update(double deltaTime)
        {
            Scene?.Update(deltaTime);
        }
    }
}