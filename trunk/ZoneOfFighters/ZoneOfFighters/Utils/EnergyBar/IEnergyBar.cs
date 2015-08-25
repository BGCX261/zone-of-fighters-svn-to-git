using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ZoneOfFighters.Utils.EnergyBar
{
    public interface IEnergyBar
    {
        /// <summary>
        /// Energia
        /// </summary>
        float Energy { get; set; }

        /// <summary>
        /// Nível máximo de energia
        /// </summary>
        float MaxEnergy { get; set; }

        /// <summary>
        /// Recupera toda a energia
        /// </summary>
        void FullRecovery();

        /// <summary>
        /// Recupera o máximo possível de energia 
        /// </summary>
        void MaxRecovery();

        /// <summary>
        /// Move a barra de energia para outro lugar na tela
        /// Muito utilizado em jogos de estratégia, onde a 
        /// barra de energia acompanha o personagem
        /// </summary>
        /// <param name="newPosition">Nova posição da barra de energia</param>
        void MoveTo(Vector2 newPosition);

        /// <summary>
        /// Desenha a barra de energia
        /// </summary>
        /// <param name="gameTime">Game time do jogo</param>
        /// <param name="spriteBatch">Sprite batch do jogo</param>
        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
