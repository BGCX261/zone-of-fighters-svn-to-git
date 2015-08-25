using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using ZoneOfFighters.Utils;
using System.Collections;
using System.Collections.Generic;
using ZoneOfFighters.Utils.RandomHelper;

namespace ZoneOfFighters.ScreenManager.Transitions
{
    public class Pixelize : TransitionScreen
    {
        int div, colunas, larguraColuna, linhas, alturaLinha, quant, offset;
        Vector2 newposition;
        Vector2 newsize;

        struct Quadrado
        {
            public Vector2 size;
            public Vector2 position;
            public Texture2D texture;
        }
        List<Quadrado> quadrados;
        List<Vector2> posicoes;

        /// <summary>
        /// A Bubbles transition
        /// </summary>
        /// <param name="sceneManager">The <c>SceneManager</c></param>
        public Pixelize(ScreenManager sceneManager)
            : base(sceneManager)
        {
            waitTime = 200;
            div = 5;

            larguraColuna = viewport.Height / div;
            alturaLinha = viewport.Height / div;

            colunas = (viewport.Width / larguraColuna) + 1;
            linhas = viewport.Height / alturaLinha;

            int larguratotal = larguraColuna * colunas;
            offset = (larguratotal - viewport.Width) / 2;

            quant = colunas * linhas;

            quadrados = new List<Quadrado>(quant);
            posicoes = new List<Vector2>(quant);

            for (int i = 0; i < colunas; i++)
                for (int j = 0; j < linhas; j++)
                    posicoes.Add(new Vector2((i*larguraColuna)-offset, (j*alturaLinha)));

            newsize = new Vector2(larguraColuna, alturaLinha);
        }

        public override void Update(GameTime gameTime)
        {
            if (sceneManager.CurrentScene != "None")
            {
                if (posicoes.Count > 0)
                {
                    int index = RandomHelper.RandomInt(0, posicoes.Count);

                    newposition = posicoes[index];

                    quadrados.Add(new Quadrado { size = newsize, position = newposition, texture = texture });
                    posicoes.RemoveAt(index);

                    if (posicoes.Count == 0)
                        CurrentStatus = Status.Out;
                }
            }
            else
            {
                if (waitTime <= 0 && quadrados.Count > 0)
                {
                    int index = RandomHelper.RandomInt(0, posicoes.Count);

                    quadrados.RemoveAt(index);

                    if (quadrados.Count == 0)
                        CurrentStatus = Status.In;
                }
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// Draws the effect
        /// </summary>
        /// <param name="gameTime">The GameTime</param>
        public override void Draw(GameTime gameTime)
        {
            foreach (Quadrado q in quadrados)
                spriteBatch.Draw(q.texture, new Rectangle((int)q.position.X, (int)q.position.Y, (int)q.size.X, (int)q.size.Y), Color.Black);
        }
    }
}
