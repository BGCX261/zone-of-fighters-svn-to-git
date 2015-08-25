using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpriteAnimation
{
    public class AnimatedSprite
    {
        #region [ Fields ]

        /// <summary>
        /// Sprite sheet da imagem animada
        /// </summary>
        protected Texture2D texture;

        /// <summary>
        /// Posição do objeto animado no mundo
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Dicionário contendo as animações do personagem
        /// </summary>
        public Dictionary<string, Animation> Animations
        {
            get { return this.animations; }
        }
        private Dictionary<string, Animation> animations = new Dictionary<string, Animation>();

        /// <summary>
        /// Indice do frame da animação em execução
        /// </summary>
        public int FrameIndex
        {
            get { return this.frameIndex; }
        }
        private int frameIndex = 0;

        /// <summary>
        /// Nome da animação
        /// </summary>
        private string animationKey;
        public string AnimationKey
        {
            get { return this.animationKey; }
        }

        /// <summary>
        /// Cor de desenho da imagem
        /// </summary>
        protected Color color = Color.White;

        /// <summary>
        /// Rotação da imagem
        /// </summary>
        protected float rotation = 0.0f;

        /// <summary>
        /// Origem do desenho
        /// </summary>
        protected Vector2 origin;

        /// <summary>
        /// Escala da imagem
        /// </summary>
        protected float scale = 1.0f;

        /// <summary>
        /// Efeitos de imagem
        /// </summary>
        public SpriteEffects Flip
        {
            get { return this.flip; }
            set { this.flip = value; }
        }
        protected SpriteEffects flip = SpriteEffects.None;

        /// <summary>
        /// Layer de desenho
        /// </summary>
        protected float layerDepth = 0.0f;

        /// <summary>
        /// Tempo decorrido do frame atual da animação
        /// </summary>
        private float timeElapsed = 0.0f;

        /// <summary>
        /// Lista com os quadros do sprite sheet
        /// </summary>
        public List<Rectangle> Frames
        {
            get { return this.frames; }
        }
        private List<Rectangle> frames = new List<Rectangle>();

        /// <summary>
        /// Largura do quadro
        /// </summary>
        private int frameWidth = 0;

        /// <summary>
        /// Altura do quadro
        /// </summary>
        private int frameHeight = 0;

        /// <summary>
        /// Tamanho do frame
        /// </summary>
        public Vector2 Size
        {
            get { return new Vector2(frameWidth, frameHeight); }
        }

        #endregion

        #region [ Constructor ]

        /// <summary>
        /// Construtor do objeto animado
        /// </summary>
        /// <param name="texture">Imagem (Sprite Sheet)</param>
        /// <param name="columns">Quantidade de colunas</param>
        /// <param name="rows">Quantidade de linhas</param>
        public AnimatedSprite(Texture2D texture, int columns, int rows)
        {
            this.texture = texture;
            this.Position = new Vector2();
            this.frameWidth = texture.Width / columns;
            this.frameHeight = texture.Height / rows;

            // Cria todos os quadros da imagem
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    frames.Add(new Rectangle(j * frameWidth,
                        i * frameHeight, frameWidth, frameHeight));

            this.origin = new Vector2(frameWidth / 2, frameHeight / 2);
        }

        #endregion

        #region [ Update ]

        /// <summary>
        /// Atualiza a animação do objeto
        /// </summary>
        /// <param name="gameTime">Tempo de jogo</param>
        public void Update(GameTime gameTime)
        {
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timeElapsed > animations[AnimationKey].Interval)
            {
                if (animations[AnimationKey].IsLooping)
                {
                    frameIndex = (frameIndex + 1) % animations[AnimationKey].FramesCount;
                }
                else
                {
                    frameIndex = (int)MathHelper.Min(frameIndex + 1, animations[AnimationKey].FramesCount - 1);
                }
                timeElapsed = 0.0f;
            }
        }

        #endregion

        #region [ Draw ]

        /// <summary>
        /// Desnha o objeto animado
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture,
                Position,
                Animations[AnimationKey].Frames[frameIndex],
                color,
                rotation,
                origin,
                scale,
                flip,
                layerDepth);
        }

        #endregion

        #region [ Add Animations ]

        /// <summary>
        /// Adiciona novas animações
        /// </summary>
        /// <param name="name">Nome chave da animação</param>
        /// <param name="newAnimation">Animação definida</param>
        public void AddAnimation(string name, Animation newAnimation)
        {
            animations.Add(name, newAnimation);
        }

        #endregion

        #region [ Play Animation ]

        /// <summary>
        /// Inicia ou continua uma animação.
        /// </summary>
        public void PlayAnimation(string name)
        {
            // Se a animação for a mesma em execução, não reinicia a animação
            if (name == AnimationKey)
                return;

            // Inicia uma nova animação
            this.animationKey = name;
            this.frameIndex = 0;
            this.timeElapsed = 0.0f;
        }

        #endregion
    }
}
