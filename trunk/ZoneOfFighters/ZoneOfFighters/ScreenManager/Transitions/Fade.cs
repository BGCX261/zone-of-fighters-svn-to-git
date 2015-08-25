using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ZoneOfFighters.ScreenManager.Transitions
{
    public class Fade : TransitionScreen
    {
        private float alpha;

        private float speed;

        /// <summary>
        /// A fade transition
        /// </summary>
        /// <param name="sceneManager">The <c>SceneManager</c></param>
        public Fade(ScreenManager sceneManager) : base(sceneManager)
        {
            speed = 0.01f;

            if (sceneManager.CurrentScene == "None")
                alpha = 1.0f;
            else
                alpha = 0.0f;
        }

        public override void Update(GameTime gameTime)
        {
            if (sceneManager.CurrentScene != "None")
            {
                alpha += (float)gameTime.ElapsedGameTime.TotalMilliseconds * speed;
                if (alpha >= 1.0f)
                {
                    MathHelper.Clamp(alpha, 0, 1);
                    CurrentStatus = Status.Out;
                }
            }
            else
            {
                if (alpha > 0.0f)
                    alpha -= (float)gameTime.ElapsedGameTime.TotalMilliseconds * (speed/10);
                else
                {
                    MathHelper.Clamp(alpha, 0, 1);
                    CurrentStatus = Status.In;
                }
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// Draws the Fade effect
        /// </summary>
        /// <param name="gameTime">The GameTime</param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(texture,
                new Rectangle(0, 0, viewport.Width, viewport.Height),
                new Color(0, 0, 0, alpha));
        }
    }
}
