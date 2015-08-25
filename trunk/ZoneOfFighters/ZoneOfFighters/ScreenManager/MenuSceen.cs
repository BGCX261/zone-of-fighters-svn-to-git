using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ZoneOfFighters.Utils;
using ZoneOfFighters.Utils.RandomHelper;

namespace ZoneOfFighters.ScreenManager
{
    public abstract class MenuSceen : GameScreen
    {
        /// <summary>
        /// The moving clouds
        /// </summary>
        private Cloud[] nuvens;

        /// <summary>
        /// A Menu Scene
        /// </summary>
        /// <param name="game">The game</param>
        public MenuSceen(ScreenManager sceneManager, string name) : base(sceneManager, name)
        {
            // Fonte a ser usada para escrever na tela;
            font = sceneManager.Game.Content.Load<SpriteFont>("font");
            // Gera nuvens aleatórias
            nuvens = new Cloud[RandomHelper.RandomInt(10,50)];
            for (int i = 0; i < nuvens.Length; i++)
            {
                nuvens[i] = new Cloud(sceneManager);
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // Update the clouds
            for (int i = 0; i < nuvens.Length; i++)
            {
                nuvens[i].Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            // Draw the clouds
            for (int i = 0; i < nuvens.Length; i++)
            {
                nuvens[i].Draw(spriteBatch);
            }
        }
    }

    public class Cloud
    {
        // Common fields
        private Viewport viewport;
        private Texture2D textura;
        private int startx = 300;
        private int starty = 100;

        // Specific fields
        private Vector2 posicao;
        private float escala, velocidade;
        private SpriteEffects flip;
        private enum Direcao { Direita = -1, Esquerda = 1};
        private Direcao direcao;

        public Cloud(ScreenManager sceneManager)
        {
            
            viewport = sceneManager.Game.GraphicsDevice.Viewport;
            textura = sceneManager.Game.Content.Load<Texture2D>(@"cloud");
            posicao.X = RandomHelper.RandomInt(-startx, viewport.Width);
            posicao.Y = RandomHelper.RandomInt(-starty, viewport.Height / 3);
            escala = RandomHelper.RandomFloat(0.2f, 0.7f);
            velocidade = RandomHelper.RandomFloat(0.01f, 0.07f);
            flip = (SpriteEffects)RandomHelper.RandomInt(0, 2);
            direcao = (Direcao)RandomHelper.RandomInt(-1, 1);
            if (direcao == 0)
                direcao = (Direcao)1;
        }

        public void Update(GameTime gameTime)
        {
            posicao.X += (float)(velocidade * gameTime.ElapsedGameTime.TotalMilliseconds) * (int)direcao;

            switch (direcao)
            {
                case Direcao.Direita:
                    if (posicao.X + textura.Width < 0)
                    {
                        posicao.X = viewport.Width + startx;
                    }
                    break;
                case Direcao.Esquerda:
                    if (posicao.X > viewport.Width)
                    {
                        posicao.X = -startx;
                    }
                    break;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(textura, posicao, null, Color.White, 0f, new Vector2(0, 0), escala, flip, 1f);
        }
    }
}
