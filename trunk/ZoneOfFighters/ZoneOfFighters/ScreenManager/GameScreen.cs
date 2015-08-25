using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ZoneOfFighters.ScreenManager.Transitions;

namespace ZoneOfFighters.ScreenManager
{
    /// <summary>
    /// A Scene
    /// </summary>
    public abstract class GameScreen
    {
        /// <summary>
        /// The SceneManager
        /// </summary>
        protected ScreenManager sceneManager;
        
        /// <summary>
        /// The SpriteBatch
        /// </summary>
        protected SpriteBatch spriteBatch;
        
        /// <summary>
        /// Font to write stuff on the screen
        /// </summary>
        protected SpriteFont font;

        // Gerenciamento de input
        protected KeyboardState keyState;
        protected KeyboardState oldKeyState;

        /// <summary>
        /// The center of the screen
        /// </summary>
        protected Vector2 centerScreen;

        /// <summary>
        /// The name of the Scene
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Abstract Scene. Inherit from this to create your scenes
        /// </summary>
        /// <param name="sceneManager">The SceneManager</param>
        /// <param name="name">The name of the Scene</param>
        public GameScreen(ScreenManager sceneManager, String name)
        {
            this.Name = name;

            this.sceneManager = sceneManager;
            this.spriteBatch = sceneManager.SpriteBatch;

            this.centerScreen = new Vector2(
                sceneManager.Game.GraphicsDevice.Viewport.Width / 2, 
                sceneManager.Game.GraphicsDevice.Viewport.Height / 2);
        }

        /// <summary>
        /// Abstract Scene. Inherit from this to create your scenes that uses font to draw strings on screen
        /// </summary>
        /// <param name="sceneManager">The SceneManager</param>
        /// <param name="name">The name of the Scene</param>
        /// <param name="font">The SpriteFont to use</param>
        public GameScreen(ScreenManager sceneManager, String name, SpriteFont font)
        {
            this.Name = name;

            this.sceneManager = sceneManager;
            this.spriteBatch = sceneManager.SpriteBatch;

            this.centerScreen = new Vector2(
                sceneManager.Game.GraphicsDevice.Viewport.Width / 2,
                sceneManager.Game.GraphicsDevice.Viewport.Height / 2);

            this.font = font;
        }

        /// <summary>
        /// Initialization tasks
        /// </summary>
        public virtual void Initialize()
        {
        }

        /// <summary>
        /// Content Loading
        /// </summary>
        public virtual void LoadContent()
        {
        }

        /// <summary>
        /// Updates the Scene
        /// </summary>
        /// <param name="gameTime">The GameTime</param>
        public virtual void Update(GameTime gameTime)
        {
        }

        /// <summary>
        /// Draws the Scene
        /// </summary>
        /// <param name="gameTime">The GameTime</param>
        public virtual void Draw(GameTime gameTime)
        {
        }


        /// <summary>
        /// Go back to the previous screen
        /// </summary>
        /// <param name="t">The transition effect</param>
        protected void Previous(TransitionScreen t)
        {
            if (sceneManager.SceneList.Count() > 0)
                sceneManager.ChangeScene(sceneManager.SceneList.ElementAt(sceneManager.SceneList.IndexOf(this) - 1), t);
        }

        /// <summary>
        /// Advance to the next screen
        /// </summary>
        /// <param name="s">New Scene if there is no other to advance</param>
        /// <param name="t">The transition effect</param>
        protected void Next(GameScreen s, TransitionScreen t)
        {
            GameScreen next = s;

            if (sceneManager.SceneList.Count() > sceneManager.SceneList.IndexOf(this) + 1)
                next = sceneManager.SceneList.ElementAt(sceneManager.SceneList.IndexOf(this) + 1);

            sceneManager.ChangeScene(next, t);
        }
    }
}
