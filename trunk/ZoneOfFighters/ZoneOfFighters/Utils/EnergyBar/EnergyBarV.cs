using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ZoneOfFighters.Utils.EnergyBar
{
    class EnergyBarV : EnergyBar
    {
        #region [ Constructor ]
        /// <summary>
        /// Contrutor da barra de energia
        /// </summary>
        /// <param name="boxTexture">Imagem da caixa que envolve a energia</param>
        /// <param name="energyTexture">Imagem da barra de energia</param>
        /// <param name="boxPosition">Posição da caixa que envolve a energia</param>
        /// <param name="energyPosition">Posição da barra de energia</param>
        public EnergyBarV(Texture2D boxTexture, Texture2D energyTexture, Vector2 boxPosition, Vector2 energyPosition)
            : base(boxTexture, energyTexture, boxPosition, energyPosition)
        {

        }

        /// <summary>
        /// Contrutor da barra de energia
        /// </summary>
        /// <param name="boxTexture">Imagem da caixa que envolve a energia</param>
        /// <param name="energyTexture">Imagem da barra de energia</param>
        /// <param name="boxPosition">Posição da caixa que envolve a energia</param>
        /// <param name="energyPosition">Posição da barra de energia</param>
        /// <param name="color">Cor da barra de energia</param>
        public EnergyBarV(Texture2D boxTexture, Texture2D energyTexture, Vector2 boxPosition, Vector2 energyPosition, Color color)
            : base(boxTexture, energyTexture, boxPosition, energyPosition, color)
        {

        }

        /// <summary>
        /// Contrutor da barra de energia
        /// </summary>
        /// <param name="boxTexture">Imagem da caixa que envolve a energia</param>
        /// <param name="energyTexture">Imagem da barra de energia</param>
        /// <param name="boxPosition">Posição da caixa que envolve a energia</param>
        /// <param name="energyPosition">Posição da barra de energia</param>
        /// <param name="emptyEnergyColor">Cor da barra de energia para  quando ela estiver vazia</param>
        /// <param name="fullEnergyColor">Cor da barra de energia para quando ela estiver cheia</param>
        public EnergyBarV(Texture2D boxTexture, Texture2D energyTexture, Vector2 boxPosition, Vector2 energyPosition, Color emptyEnergyColor, Color fullEnergyColor)
            : base(boxTexture, energyTexture, boxPosition, energyPosition, emptyEnergyColor, fullEnergyColor)
        {

        }

        /// <summary>
        /// Contrutor da barra de energia
        /// </summary>
        /// <param name="boxTexture">Imagem da caixa que envolve a energia</param>
        /// <param name="energyTexture">Imagem da barra de energia</param>
        /// <param name="boxPosition">Posição da caixa que envolve a energia</param>
        /// <param name="energyPosition">Posição da barra de energia</param>
        /// <param name="emptyEnergyColor">Cor da barra de energia para  quando ela estiver vazia</param>
        /// <param name="fullEnergyColor">Cor da barra de energia para quando ela estiver cheia</param>
        /// <param name="flipEnergyReduce">Reduz a barra de energia para o lado inverso</param>
        public EnergyBarV(Texture2D boxTexture, Texture2D energyTexture, Vector2 boxPosition, Vector2 energyPosition, Color emptyEnergyColor, Color fullEnergyColor, bool flipEnergyReduce)
            : base(boxTexture, energyTexture, boxPosition, energyPosition, emptyEnergyColor, fullEnergyColor, flipEnergyReduce)
        {

        }

        /// <summary>
        /// Contrutor da barra de energia
        /// </summary>
        /// <param name="boxTexture">Imagem da caixa que envolve a energia</param>
        /// <param name="energyTexture">Imagem da barra de energia</param>
        /// <param name="boxPosition">Posição da caixa que envolve a energia</param>
        /// <param name="energyPosition">Posição da barra de energia</param>
        /// <param name="recoveryBar">Ativa ou não a barra de recuperação de energia</param>
        /// <param name="recoveryFactor">Fator de recuperação de energia</param>
        public EnergyBarV(Texture2D boxTexture, Texture2D energyTexture, Vector2 boxPosition, Vector2 energyPosition, bool recoveryBar, float recoveryFactor)
            : base(boxTexture, energyTexture, boxPosition, energyPosition, recoveryBar, recoveryFactor)
        {

        }

        /// <summary>
        /// Contrutor da barra de energia
        /// </summary>
        /// <param name="boxTexture">Imagem da caixa que envolve a energia</param>
        /// <param name="energyTexture">Imagem da barra de energia</param>
        /// <param name="boxPosition">Posição da caixa que envolve a energia</param>
        /// <param name="energyPosition">Posição da barra de energia</param>
        /// <param name="emptyEnergyColor">Cor da barra de energia para  quando ela estiver vazia</param>
        /// <param name="fullEnergyColor">Cor da barra de energia para quando ela estiver cheia</param>
        /// <param name="recoveryBar">Ativa ou não a barra de recuperação de energia</param>
        /// <param name="recoveryFactor">Fator de recuperação de energia</param>
        public EnergyBarV(Texture2D boxTexture, Texture2D energyTexture, Vector2 boxPosition, Vector2 energyPosition, Color emptyEnergyColor, Color fullEnergyColor, bool recoveryBar, float recoveryFactor)
            : base(boxTexture, energyTexture, boxPosition, energyPosition, emptyEnergyColor, fullEnergyColor, recoveryBar, recoveryFactor)
        {

        }

        /// <summary>
        /// Contrutor da barra de energia
        /// </summary>
        /// <param name="boxTexture">Imagem da caixa que envolve a energia</param>
        /// <param name="energyTexture">Imagem da barra de energia</param>
        /// <param name="boxPosition">Posição da caixa que envolve a energia</param>
        /// <param name="energyPosition">Posição da barra de energia</param>
        /// <param name="emptyEnergyColor">Cor da barra de energia para  quando ela estiver vazia</param>
        /// <param name="fullEnergyColor">Cor da barra de energia para quando ela estiver cheia</param>
        /// <param name="recoveryBar">Ativa ou não a barra de recuperação de energia</param>
        /// <param name="recoveryFactor">Fator de recuperação de energia</param>
        /// <param name="flipEnergyReduce">Reduz a barra de energia para o lado inverso</param>
        public EnergyBarV(Texture2D boxTexture, Texture2D energyTexture, Vector2 boxPosition, Vector2 energyPosition, Color emptyEnergyColor, Color fullEnergyColor, bool recoveryBar, float recoveryFactor, bool flipEnergyReduce)
            : base(boxTexture, energyTexture, boxPosition, energyPosition, emptyEnergyColor, fullEnergyColor, recoveryBar, recoveryFactor, flipEnergyReduce)
        {

        }
        #endregion

        #region [ Draw Method ]
        /// <summary>
        /// Desenha a barra de energia
        /// </summary>
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Se existir recuperação de energia
            if (recoveryBar)
            {
                // Reduz a recuperação de energia conforme o tempo passado de jogo
                recovery -= recoveryFactor * (float)gameTime.ElapsedGameTime.TotalSeconds;
                recovery = MathHelper.Clamp(recovery, energy, maxEnergy);

                // Desenha a barra de recuperação de energia
                spriteBatch.Draw(energyTexture,
                energyPosition,
                new Rectangle(0, 0, (int)energyTexture.Width, (int)(recovery * energyTexture.Height / maxEnergy)),
                new Color(recoveryColor.R, recoveryColor.G, recoveryColor.B, 0.25f),
                flipEnergyReduce ? MathHelper.ToRadians(180) : 0.0f,
                flipEnergyReduce ? new Vector2(energyTexture.Width, energyTexture.Height) : Vector2.Zero,
                1.0f,
                SpriteEffects.None,
                0.0f);
            }

            // Desenha a caixa que envolve a energia
            spriteBatch.Draw(boxTexture,
                boxPosition,
                new Rectangle(0, 0, boxTexture.Width, boxTexture.Height),
                Color.White,
                0.0f,
                Vector2.Zero,
                1.0f,
                SpriteEffects.None,
                0.0f);

            // Desenha a barra de energia
            spriteBatch.Draw(energyTexture,
                energyPosition,
                new Rectangle(0, 0, (int)energyTexture.Width, (int)(energy * energyTexture.Height / maxEnergy)),
                Color.Lerp(emptyEnergyColor, fullEnergyColor, energy / maxEnergy),
                flipEnergyReduce ? MathHelper.ToRadians(180) : 0.0f,
                flipEnergyReduce ? new Vector2(energyTexture.Width, energyTexture.Height) : Vector2.Zero,
                1.0f,
                SpriteEffects.None,
                0.0f);

            base.Draw(gameTime, spriteBatch);
        }

        #endregion
    }
}