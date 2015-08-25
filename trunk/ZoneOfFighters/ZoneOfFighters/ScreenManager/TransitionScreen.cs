using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ZoneOfFighters.ScreenManager
{
    public abstract class TransitionScreen
    {
        /// <summary>
        /// The SceneManager
        /// </summary>
        protected ScreenManager sceneManager;

        /// <summary>
        /// The ViewPort
        /// </summary>
        protected Viewport viewport;

        /// <summary>
        /// The SpriteBatch
        /// </summary>
        protected SpriteBatch spriteBatch;

        /// <summary>
        /// Image to render the effect
        /// </summary>
        protected Texture2D texture;

        /// <summary>
        /// Color to paint the Texture
        /// </summary>
        protected Color color;

        /// <summary>
        /// Amount of time in milliseconds to wait between Transition Out and Transition In
        /// </summary>
        protected int waitTime = 0;

        /// <summary>
        /// Transition Status
        /// </summary>
        public enum Status { None, In, Out }

        /// <summary>
        /// The transition is actually in progress
        /// </summary>
        public bool InProgress { get; protected set; }

        /// <summary>
        /// The current status of the transition. (In or Out)
        /// 
        /// Use the Transition.Status on this property
        /// </summary>
        public Status CurrentStatus { get; protected set; }

        /// <summary>
        /// A transition between two scenes
        /// </summary>
        /// <param name="game">The game</param>
        public TransitionScreen(ScreenManager sceneManager)
        {
            SetBasicParams(sceneManager);

            texture = CreateBlankTexture(sceneManager);
            color = Color.Black;
        }

        public TransitionScreen(ScreenManager sceneManager, Texture2D texture)
        {
            SetBasicParams(sceneManager);

            this.texture = texture;
            color = Color.White;
        }


        private void SetBasicParams(ScreenManager sceneManager)
        {
            this.sceneManager = sceneManager;
            spriteBatch = sceneManager.SpriteBatch;

            viewport = sceneManager.Game.GraphicsDevice.Viewport;
            InProgress = true;
        }

        private Texture2D CreateBlankTexture(ScreenManager sceneManager)
        {
            Texture2D t = new Texture2D(sceneManager.Game.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);

            Color[] data = new Color[t.Width * t.Height];
            for (int i = 0; i < data.Length; i++)
                data[i] = Color.White;
            t.SetData(data);
            return t;
        }

        /// <summary>
        /// Update the actual transition
        /// </summary>
        /// <param name="gameTime">The GameTime</param>
        public virtual void Update(GameTime gameTime)
        {
            if (CurrentStatus == Status.In)
                InProgress = false;

            if (waitTime > 0 && CurrentStatus == Status.Out)
                waitTime -= (int)gameTime.ElapsedGameTime.TotalMilliseconds;
        }

        /// <summary>
        /// Draw the elements of the actual transition
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Draw(GameTime gameTime)
        {
            //
        }
    }
}
