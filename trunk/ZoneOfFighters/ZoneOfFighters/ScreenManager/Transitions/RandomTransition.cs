using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using ZoneOfFighters.Utils;
using ZoneOfFighters.Utils.RandomHelper;

namespace ZoneOfFighters.ScreenManager.Transitions
{
    public class RandomTransition : TransitionScreen
    {
        List<TransitionScreen> list;
        TransitionScreen t;

        public RandomTransition(ScreenManager sceneManager) : base(sceneManager)
        {
            list = new List<TransitionScreen>();
            list.Add(new Fade(sceneManager));
            list.Add(new Slide(sceneManager, Way.Down));
            list.Add(new Slide(sceneManager, Way.Up));
            list.Add(new Slide(sceneManager, Way.Right));
            list.Add(new Slide(sceneManager, Way.Left));
            list.Add(new Flash(sceneManager));
            list.Add(new Pixelize(sceneManager));
            list.Add(new Doors(sceneManager, Direction.Vertical));
            list.Add(new Doors(sceneManager, Direction.Horizontal));

            t = list[RandomHelper.RandomInt(0, list.Count)];
        }

        public RandomTransition(ScreenManager sceneManager, List<TransitionScreen> list) : base(sceneManager)
        {
            t = list[RandomHelper.RandomInt(0, list.Count)];
        }

        public override void Update(GameTime gameTime)
        {
            t.Update(gameTime);
            CurrentStatus = t.CurrentStatus;
            InProgress = t.InProgress;
        }

        public override void Draw(GameTime gameTime)
        {
            t.Draw(gameTime);
        }
    }
}
