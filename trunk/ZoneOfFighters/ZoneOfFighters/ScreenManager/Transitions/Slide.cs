using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ZoneOfFighters.ScreenManager.Transitions
{
    /// <summary>
    /// The possible directions to slide
    /// </summary>
    public enum Way { Down, Right, Up, Left };

    /// <summary>
    /// A Slide effect
    /// </summary>
    public class Slide : TransitionScreen
    {
        private int direction = 1, startPosition;
        private float X = 0f, Y = 0f, move = 0f;

        private int texW, texH;

        /// <summary>
        /// The speed
        /// </summary>
        private float speed = 3.0f;

        private float rotation = 0f;

        private SpriteEffects flip = SpriteEffects.None;

        private Vector2 offset = Vector2.Zero;

        /// <summary>
        /// The direction
        /// </summary>
        private Way way;

        /// <summary>
        /// A Slide transition.
        /// </summary>
        /// <param name="sceneManager">The SceneManager</param>
        /// <paramparam name="direction">The Way to slide. Use the Way enumeration</paramparam>
        public Slide(ScreenManager sceneManager, Way way)
            : base(sceneManager)
        {
            this.way = way;
            this.waitTime = 300;

            if ((int)way > 1)
                direction = -1;

            SwitchWay(way);
        }

        public Slide(ScreenManager sceneManager, Way way, Color color)
            : base(sceneManager)
        {
            this.way = way;
            this.waitTime = 300;

            if ((int)way > 1)
                direction = -1;

            SwitchWay(way);

            this.color = color;
        }

        public Slide(ScreenManager sceneManager, Way way, Texture2D texture)
            : base(sceneManager, texture)
        {
            this.way = way;
            this.waitTime = 300;

            if ((int)way > 1)
                direction = -1;

            SwitchWay(way);

            this.texture = texture;
        }

        private void SwitchWay(Way way)
        {
            switch (way)
            {
                case Way.Down:
                    move = startPosition = -viewport.Height;
                    texW = viewport.Width;
                    texH = viewport.Height;
                    break;
                case Way.Right:
                    move = startPosition = -viewport.Width;
                    texW = viewport.Height;
                    texH = viewport.Width;
                    offset.Y = viewport.Height;
                    rotation = -1.57079633f;
                    break;
                case Way.Up:
                    move = startPosition = viewport.Height;
                    flip = SpriteEffects.FlipVertically;
                    texW = viewport.Width;
                    texH = viewport.Height;
                    break;
                case Way.Left:
                    move = startPosition = viewport.Width;
                    texW = viewport.Height;
                    texH = viewport.Width;
                    offset.X = viewport.Width;
                    rotation = 1.57079633f;
                    flip = SpriteEffects.FlipHorizontally;

                    break;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (sceneManager.CurrentScene != "None" && CurrentStatus != Status.Out)
            {
                move += (float)gameTime.ElapsedGameTime.Milliseconds * speed * direction;
                if (move.CompareTo(0) == direction)
                {
                    move = 0;
                    CurrentStatus = Status.Out;
                }
            }
            else
            {
                if (waitTime <= 0)
                {
                    if (move.CompareTo(startPosition) == direction)
                        move -= (float)gameTime.ElapsedGameTime.Milliseconds * speed * direction;
                    else
                        CurrentStatus = Status.In; 
                }
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {

            if ((int)way % 2 == 0)
                Y = move;
            else
                X = move;

            //spriteBatch.Draw(texture, new Vector2(X, Y), new Rectangle(0, 0, viewport.Width, viewport.Height), color);
            //spriteBatch.Draw(texture, new Rectangle((int)X, (int)Y, viewport.Width, viewport.Height), color);
            spriteBatch.Draw(
                texture,
                new Rectangle((int)(X + offset.X), (int)(Y + offset.Y), texW, texH),
                null,
                color,
                rotation,
                Vector2.Zero,
                flip,
                0f);
        }
    }
}
