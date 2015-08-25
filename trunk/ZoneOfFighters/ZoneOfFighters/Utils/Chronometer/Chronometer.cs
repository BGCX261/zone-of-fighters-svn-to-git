using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ZoneOfFighters.Utils.Chronometer
{
    public class Chronometer : GameComponent
    {
        #region [ Fields ]

        /// <summary>
        /// Tempo total contado
        /// </summary>
        private TimeSpan totalTime;

        /// <summary>
        /// Tempo total parado
        /// </summary>
        private TimeSpan stopedTime;

        /// <summary>
        /// Tipo de contagem
        /// </summary>
        private ChronometerType type;

        /// <summary>
        /// Tempo limite
        /// </summary>
        public TimeSpan LimiteTime { get; set; }

        /// <summary>
        /// Indica se o tempo esta parado
        /// </summary>
        public bool IsStopped
        {
            get { return this.stopped; }
        }

        private bool stopped;

        /// <summary>
        /// Tempo
        /// </summary>
        public TimeSpan Time
        {
            get
            {
                if (type == ChronometerType.Countdown)
                    return totalTime - stopedTime;
                else
                    return LimiteTime - (totalTime - stopedTime);
            }
        }
        #endregion

        #region [ Constructor ]

        public Chronometer(Game game, ChronometerType type)
            : base(game)
        {
            totalTime = new TimeSpan();
            stopedTime = new TimeSpan();
            stopped = true;
            this.type = type;
        }

        public Chronometer(Game game, ChronometerType type, TimeSpan limiteTime)
            : base(game)
        {
            totalTime = new TimeSpan();
            stopedTime = new TimeSpan();
            stopped = true;
            this.type = type;
            LimiteTime = limiteTime;
        }

        #endregion

        #region [ Update ]

        public override void Update(GameTime gameTime)
        {
            TimeSpan elapsedTime = gameTime.ElapsedGameTime;
            totalTime += elapsedTime;
            if (stopped)
                stopedTime += elapsedTime;
            base.Update(gameTime);
        }
        #endregion

        #region [ Methods ]

        /// <summary>
        /// Inicia o cronometro, ou se estiver parado continua a contagem
        /// </summary>
        public void Start()
        {
            stopped = false;
            if (totalTime == TimeSpan.Zero)
                Reset();
        }

        /// <summary>
        /// Pausa o cronometro
        /// </summary>
        public void Stop()
        {
            stopped = true;
        }

        /// <summary>
        /// Zera a contagem do cronometro
        /// </summary>
        public void Reset()
        {
            totalTime = new TimeSpan();
            stopedTime = new TimeSpan();
        }

        #endregion
    }
}
