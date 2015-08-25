using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ZoneOfFighters.Utils.EnergyBar
{
    /// <summary>
    /// Classe para barras de energia, saúde, vida etc... porém somente horizontal
    /// </summary>
    public abstract class EnergyBar : IEnergyBar
    {
        #region [ Fields ]

        /// <summary>
        /// Imagem da caixa por trás da barra de energia
        /// </summary>
        protected Texture2D boxTexture = null;

        /// <summary>
        /// Imagem da barra de energia
        /// </summary>
        protected Texture2D energyTexture = null;

        /// <summary>
        /// Posição da caixa
        /// </summary>
        protected Vector2 boxPosition;

        /// <summary>
        /// Posição da barra de energia
        /// </summary>
        protected Vector2 energyPosition;

        /// <summary>
        /// Nível máximo de energia
        /// </summary>
        public float MaxEnergy
        {
            get { return this.maxEnergy; }
            set { this.maxEnergy = value; }
        }
        protected float maxEnergy = 100.0f;

        /// <summary>
        /// Energia
        /// </summary>
        public float Energy
        {
            get { return this.energy; }
            set
            {
                this.energy = MathHelper.Clamp(value, 0, maxEnergy);
            }
        }
        protected float energy = 100.0f;

        /// <summary>
        /// Cor da barra de energia quando esta vazia
        /// </summary>
        protected Color emptyEnergyColor = Color.White;

        /// <summary>
        /// Cor da barra de energia quando esta cheia
        /// </summary>
        protected Color fullEnergyColor = Color.White;

        /// <summary>
        /// Indica se deseja reduzir a energia para o outro lado
        /// </summary>
        protected bool flipEnergyReduce = false;

        /// <summary>
        /// Indica se existira barra de recuperação de energia
        /// </summary>
        protected bool recoveryBar = false;

        /// <summary>
        /// Quantidade de recuperação atual
        /// </summary>
        protected float recovery;

        /// <summary>
        /// Fator de descida da recuperação
        /// </summary>
        protected float recoveryFactor;

        /// <summary>
        /// Cor da barra de recuperação
        /// </summary>
        protected Color recoveryColor = Color.White;

        #endregion

        #region [ Constructor ]
        /// <summary>
        /// Contrutor da barra de energia
        /// </summary>
        /// <param name="boxTexture">Imagem da caixa que envolve a energia</param>
        /// <param name="energyTexture">Imagem da barra de energia</param>
        /// <param name="boxPosition">Posição da caixa que envolve a energia</param>
        /// <param name="energyPosition">Posição da barra de energia</param>
        public EnergyBar(Texture2D boxTexture, Texture2D energyTexture, Vector2 boxPosition, Vector2 energyPosition)
        {
            this.boxTexture = boxTexture;
            this.energyTexture = energyTexture;
            this.boxPosition = boxPosition;
            this.energyPosition = energyPosition;
        }

        /// <summary>
        /// Contrutor da barra de energia
        /// </summary>
        /// <param name="boxTexture">Imagem da caixa que envolve a energia</param>
        /// <param name="energyTexture">Imagem da barra de energia</param>
        /// <param name="boxPosition">Posição da caixa que envolve a energia</param>
        /// <param name="energyPosition">Posição da barra de energia</param>
        /// <param name="color">Cor da barra de energia</param>
        public EnergyBar(Texture2D boxTexture, Texture2D energyTexture, Vector2 boxPosition, Vector2 energyPosition, Color color)
        {
            this.boxTexture = boxTexture;
            this.energyTexture = energyTexture;
            this.boxPosition = boxPosition;
            this.energyPosition = energyPosition;
            this.emptyEnergyColor = color;
            this.fullEnergyColor = color;
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
        public EnergyBar(Texture2D boxTexture, Texture2D energyTexture, Vector2 boxPosition, Vector2 energyPosition, Color emptyEnergyColor, Color fullEnergyColor)
        {
            this.boxTexture = boxTexture;
            this.energyTexture = energyTexture;
            this.boxPosition = boxPosition;
            this.energyPosition = energyPosition;
            this.emptyEnergyColor = emptyEnergyColor;
            this.fullEnergyColor = fullEnergyColor;
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
        public EnergyBar(Texture2D boxTexture, Texture2D energyTexture, Vector2 boxPosition, Vector2 energyPosition, Color emptyEnergyColor, Color fullEnergyColor, bool flipEnergyReduce)
        {
            this.boxTexture = boxTexture;
            this.energyTexture = energyTexture;
            this.boxPosition = boxPosition;
            this.energyPosition = energyPosition;
            this.emptyEnergyColor = emptyEnergyColor;
            this.fullEnergyColor = fullEnergyColor;
            this.flipEnergyReduce = flipEnergyReduce;
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
        public EnergyBar(Texture2D boxTexture, Texture2D energyTexture, Vector2 boxPosition, Vector2 energyPosition, bool recoveryBar, float recoveryFactor)
        {
            this.boxTexture = boxTexture;
            this.energyTexture = energyTexture;
            this.boxPosition = boxPosition;
            this.energyPosition = energyPosition;
            this.recoveryBar = recoveryBar;
            this.recoveryFactor = recoveryFactor;
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
        public EnergyBar(Texture2D boxTexture, Texture2D energyTexture, Vector2 boxPosition, Vector2 energyPosition, Color emptyEnergyColor, Color fullEnergyColor, bool recoveryBar, float recoveryFactor)
        {
            this.boxTexture = boxTexture;
            this.energyTexture = energyTexture;
            this.boxPosition = boxPosition;
            this.energyPosition = energyPosition;
            this.emptyEnergyColor = emptyEnergyColor;
            this.fullEnergyColor = fullEnergyColor;
            this.recoveryBar = recoveryBar;
            this.recoveryFactor = recoveryFactor;
            this.recoveryColor = emptyEnergyColor;
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
        public EnergyBar(Texture2D boxTexture, Texture2D energyTexture, Vector2 boxPosition, Vector2 energyPosition, Color emptyEnergyColor, Color fullEnergyColor, bool recoveryBar, float recoveryFactor, bool flipEnergyReduce)
        {
            this.boxTexture = boxTexture;
            this.energyTexture = energyTexture;
            this.boxPosition = boxPosition;
            this.energyPosition = energyPosition;
            this.emptyEnergyColor = emptyEnergyColor;
            this.fullEnergyColor = fullEnergyColor;
            this.recoveryBar = recoveryBar;
            this.recoveryFactor = recoveryFactor;
            this.recoveryColor = emptyEnergyColor;
            this.flipEnergyReduce = flipEnergyReduce;
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Recupera toda a energia
        /// </summary>
        public void FullRecovery()
        {
            energy = maxEnergy;
            recovery = energy;
        }

        /// <summary>
        /// Recupera o máximo possível de energia 
        /// </summary>
        public void MaxRecovery()
        {
            recovery = energy;
        }

        /// <summary>
        /// Move a barra de energia para outro lugar na tela
        /// Muito utilizado em jogos de estratégia, onde a 
        /// barra de energia acompanha o personagem
        /// </summary>
        /// <param name="newPosition">Nova posição da barra de energia</param>
        public void MoveTo(Vector2 newPosition)
        {
            Vector2 diff = energyPosition - boxPosition;
            boxPosition = newPosition;
            energyPosition = boxPosition + diff;
        }
        #endregion


        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch) { }
    }
}
