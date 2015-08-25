using Microsoft.Xna.Framework;

namespace ZoneOfFighters.ScreenManager.Transitions
{
    /// <summary>
    /// The possible directions to slide
    /// </summary>
    public enum Direction { Horizontal, Vertical };

    /// <summary>
    /// A Slide effect
    /// </summary>
    public class Doors : TransitionScreen
    {
        private float speed, moveDoorOne, moveDoorTwo;

        private int width, height, middle;

        private Direction direction;

        private Vector2 positionDoorOne, positionDoorTwo, startPositions;

        /// <summary>
        /// Closing doors transition
        /// </summary>
        /// <param name="sceneManager">The SceneManager</param>
        /// <paramparam name="direction">The Direction to slide the doors. Use the Direction enumeration</paramparam>
        public Doors(ScreenManager sceneManager, Direction direction)
            : base(sceneManager)
        {
            this.speed = 2f;
            this.direction = direction;
            this.waitTime = 300;

            this.positionDoorOne = Vector2.Zero;
            this.positionDoorTwo = Vector2.Zero;

            switch (direction)
            {
                case Direction.Horizontal:
                    width = viewport.Width >> 1;
                    height = viewport.Height;
                    moveDoorOne = startPositions.X = -width;
                    moveDoorTwo = startPositions.Y = viewport.Width;
                    middle = width;
                    break;
                case Direction.Vertical:
                    width = viewport.Width;
                    height = viewport.Height >> 1;
                    moveDoorOne = startPositions.X = -height;
                    moveDoorTwo = startPositions.Y = viewport.Height;
                    middle = height;
                    break;
                default:
                    break;
            }
        }

        public override void Update(GameTime gameTime)
        {
            float gt = gameTime.ElapsedGameTime.Milliseconds;

            if (sceneManager.CurrentScene != "None" && CurrentStatus != Status.Out)
            {
                moveDoorOne += (float)gt * speed;
                moveDoorTwo -= (float)gt * speed;

                if (moveDoorOne.CompareTo(0) == 1)
                    moveDoorOne = 0;

                if (moveDoorTwo.CompareTo(middle) == -1)
                    moveDoorTwo = middle;

                if (moveDoorOne == 0 && moveDoorTwo == middle)
                    CurrentStatus = Status.Out;
            }
            else
            {
                if (waitTime <= 0)
                {
                    if (moveDoorOne.CompareTo(startPositions.X) == 1)
                        moveDoorOne -= (float)gt * speed;

                    if (moveDoorTwo.CompareTo(startPositions.Y) == -1)
                        moveDoorTwo += (float)gt * speed;

                    if (moveDoorOne <= startPositions.X && moveDoorTwo >= startPositions.Y)
                        CurrentStatus = Status.In;
                }
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            switch (direction)
            {
                case Direction.Horizontal:
                    positionDoorOne.X = moveDoorOne;
                    positionDoorTwo.X = moveDoorTwo;
                    break;
                case Direction.Vertical:
                    positionDoorOne.Y = moveDoorOne;
                    positionDoorTwo.Y = moveDoorTwo;
                    break;
            }

            spriteBatch.Draw(texture, new Vector2(positionDoorOne.X, positionDoorOne.Y), new Rectangle(0, 0, width, height), Color.Black);
            spriteBatch.Draw(texture, new Vector2(positionDoorTwo.X, positionDoorTwo.Y), new Rectangle(0, 0, width, height), Color.Black);
        }
    }
}
