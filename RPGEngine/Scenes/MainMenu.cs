using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPGEngine.Scenes
{
    public class MainMenu : IScene
    {
        public void Draw(SpriteBatch batch)
        {
            batch.Begin();

            batch.Draw(RPGGame.Game.Content.Load<Texture2D>("Icon"), new Vector2(0, 0));

            // Stop drawing
            batch.End();
        }

        public void Update(double deltaTime)
        {
            //throw new NotImplementedException();
        }
    }
}