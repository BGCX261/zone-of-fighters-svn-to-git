using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ZoneOfFighters.ScreenManager.Transitions;
using System;

namespace ZoneOfFighters.ScreenManager
{
    public class ScreenManager : DrawableGameComponent
    {
        /// <summary>
        /// Transition
        /// </summary>
        private TransitionScreen transition;


        /// <summary>
        /// The Scenes to Update
        /// </summary>
        private IDictionary<string, GameScreen> scenesToUpdate;

        /// <summary>
        /// The Current Scene
        /// </summary>
        public string CurrentScene { get; private set; }
        
        /// <summary>
        /// The Next Scene
        /// </summary>
        public string NextScene { get; private set; }

        /// <summary>
        /// The List of all screens loaded
        /// </summary>
        public IList<GameScreen> SceneList { get; private set; }
        
        /// <summary>
        /// Is the SceneManager transitioning?
        /// </summary>
        public bool InTransition { get; private set; }

        /// <summary>
        /// The SpriteBatch
        /// </summary>
        public SpriteBatch SpriteBatch { get; private set; }

        /// <summary>
        /// Manages scenes and transitions
        /// </summary>
        /// <param name="game">The game</param>
        /// <param name="blank">A blank texture from the content pipeline</param>
        public ScreenManager(Game game) : base(game)
        {
            SpriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            CurrentScene = "None";
            NextScene = "None";
            InTransition = false;
            scenesToUpdate = new Dictionary<string, GameScreen>();
            SceneList = new List<GameScreen>();
        }

        /// <summary>
        /// Do initialization work
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Load content
        /// </summary>
        protected override void LoadContent()
        {
            base.LoadContent();
        }

        /// <summary>
        /// Updates the Scene Manager
        /// </summary>
        /// <param name="gameTime">The Game Time</param>
        public override void Update(GameTime gameTime)
        {
            if (CurrentScene != "None")
                scenesToUpdate[CurrentScene].Update(gameTime);
            if (transition.InProgress)
            {
                transition.Update(gameTime);

                if (transition.CurrentStatus == TransitionScreen.Status.Out)
                {
                    RemoveScene(CurrentScene);
                    CurrentScene = "None";
                }
                else if (transition.CurrentStatus == TransitionScreen.Status.In)
                {
                    CurrentScene = NextScene;
                    InTransition = false;
                }

                scenesToUpdate[NextScene].Update(gameTime);
            }
            else
                InTransition = false;
        }

        /// <summary>
        /// Draws the scenes and transitions
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            if (CurrentScene != "None")
            {
                scenesToUpdate[CurrentScene].Draw(gameTime);
            }
            else
            {
                scenesToUpdate[NextScene].Draw(gameTime);
            }

            if (transition.InProgress)
            {
                transition.Draw(gameTime);
            }
            SpriteBatch.End();
        }

        /// <summary>
        /// Instructs the Scene Manager to change the actual scene
        /// </summary>
        /// <param name="scene">The new Scene</param>
        /// <param name="transition">The transition between the actual scene and the new scene</param>
        /// <returns></returns>
        public void ChangeScene(GameScreen scene, TransitionScreen transFX)
        {
            this.NextScene = scene.Name;
            this.transition = transFX;

            this.InTransition = true;

            AddScene(scene);
        }

        public void PopUp(GameScreen scene, TransitionScreen transFX)
        {
        }

        /// <summary>
        /// Remove a Scene from the Scene Manager
        /// </summary>
        /// <param name="currentScene">The name of the Scene to remove</param>
        private void RemoveScene(string currentScene)
        {
            scenesToUpdate.Remove(currentScene);
        }

        /// <summary>
        /// Adds a Scene to the Scene Manager
        /// </summary>
        /// <param name="scene">The Scene to add</param>
        private void AddScene(GameScreen scene)
        {
            scenesToUpdate.Add(scene.Name, scene);

            if (!SceneList.Contains(scene))
                SceneList.Add(scene);
        }
    }
}
