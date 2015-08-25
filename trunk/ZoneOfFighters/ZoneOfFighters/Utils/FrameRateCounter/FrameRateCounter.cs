#region [ Usings ]
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace ZoneOfFighters.Utils.FrameRateCounter
{
    /// <summary>
    /// Componente de contador de FPS (Frames por Segundo)
    /// </summary>
    public class FrameRateCounter : DrawableGameComponent
    {
        #region [ Fields ]
        /// <summary>
        /// SpriteBatch utilizado para escrever e/ou desenhar na tela
        /// </summary>
        private SpriteBatch spriteBatch = null;

        /// <summary>
        /// SpriteFont para escrever
        /// </summary>
        private SpriteFont font = null;

        /// <summary>
        /// Nome da SpriteFont à ser carregada
        /// </summary>
        private string fontName;

        /// <summary>
        /// Cor do texto a ser desenhado na tela
        /// </summary>
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }
        private Color color = Color.White;

        /// <summary>
        /// Armazena o total de tempo (segundos) passados desde o último update
        /// </summary>
        private TimeSpan elapsedTime = new TimeSpan();

        /// <summary>
        /// Armazena o número total de frames
        /// </summary>
        private byte totalFrames = 0;

        /// <summary>
        /// Armazena o total de FPS (Frames Por Segundo)
        /// </summary>
        private byte frameRate = 0;

        /// <summary>
        /// Vetor para armazenar a posição do texto na tela
        /// </summary>
        public Vector2 Position
        {
            set { position = value; }
            get { return position; }
        }
        private Vector2 position = new Vector2(10.0f, 10.0f);
        #endregion

        #region [ Constructor ]

        /// <summary>
        /// Construtor do componente contador de FPS (Frames por Segundo)
        /// </summary>
        /// <param name="game">Referência do jogo que o chamou</param>
        /// <param name="fontName">Nome da SpriteFont ou caminho a ser carregado</param>
        public FrameRateCounter(Game game, string fontName)
            : base(game)
        {
            this.fontName = fontName;
        }

        /// <summary>
        /// Construtor do componente contador de FPS (Frames por Segundo)
        /// </summary>
        /// <param name="game">Referência do jogo que o chamou</param>
        /// <param name="fontName">Nome da SpriteFont ou caminho a ser carregado</param>
        /// <param name="color">Cor do Texto que sera escrito na tela</param>
        public FrameRateCounter(Game game, string fontName, Color color)
            : base(game)
        {
            this.fontName = fontName;
            Color = color;
        }

        /// <summary>
        /// Construtor do componente contador de FPS (Frames por Segundo)
        /// </summary>
        /// <param name="game">Referência do jogo que o chamou</param>
        /// <param name="fontName">Nome da SpriteFont ou caminho a ser carregado</param>
        /// <param name="color">Cor do Texto que sera escrito na tela</param>
        /// <param name="position">Posição do Texto à ser desenhado</param>
        public FrameRateCounter(Game game, string fontName, Color color, Vector2 position)
            : base(game)
        {
            this.fontName = fontName;
            Color = color;
            Position = position;
        }
        #endregion

        #region [ Load Content ]
        /// <summary>
        /// Carrega o conteúdo necessário para que o componente funcione
        /// </summary>
        protected override void LoadContent()
        {
            // Cria uma nova SpriteBatch, que pode ser usada
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            // Carrega a font para escrever o texto
            if (!string.IsNullOrEmpty(fontName))
                font = Game.Content.Load<SpriteFont>(fontName);
        }
        #endregion

        #region [ Update ]
        /// <summary>
        /// Método que atualiza o componente
        /// </summary>
        /// <param name="gameTime">Referência para o tempo de jogo</param>
        public override void Update(GameTime gameTime)
        {
            // Recebe o tempo passado deste a última chamada
            elapsedTime += gameTime.ElapsedGameTime;
            // Incrementa o total de frames por segundos, uma vez
            // que este método está sendo chamado novamente
            totalFrames++;
            // Verifica se o tempo passado (elapsedTime) é maior que
            // 1 segundo
            if (elapsedTime >= TimeSpan.FromSeconds(1))
            {
                // Se o tempo passado for maior ou igual a 1 segundo,
                // definimos então a variavel frameRate com a quantidade
                // total de frames exibido na tela da variavel totalFrames
                frameRate = totalFrames;
                // Logo após zeramos a variável que guardava o total de frames,
                // para começar a recontagem e verificar se houve mudanças
                totalFrames = 0;
                // Retiramos 1 segundo da variável que armazena o tempo passado,
                // pois pode ser que este tempo tenha passado de 1 segundo.
                elapsedTime -= TimeSpan.FromSeconds(1);
            }
        }
        #endregion

        #region [ Draw ]
        /// <summary>
        /// Método para desenhar a quantidade de Frames por Segundos
        /// </summary>
        /// <param name="gameTime">Referência para o tempo de jogo</param>
        public override void Draw(GameTime gameTime)
        {
            // Armazena uma string indicando a quantidade de FPS
            string fps = string.Format("FPS: {0}", frameRate);
            // Inicializa o SpriteBatch para desenhar
            spriteBatch.Begin();
            // Escreve o FPS na tela
            spriteBatch.DrawString(font, fps, position, color);
            // Finaliza o SpriteBatch
            spriteBatch.End();
        }
        #endregion
    }
}
