using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ZoneOfFighters.Utils.Camera
{
    public class Camera2D
    {
        #region [ Fields ]
       
        protected float _zoom;

        /// <summary>
        ///  Zoom da camera
        /// </summary>
        public float Zoom
        {
            get { return _zoom; }
            set { _zoom = value; if (_zoom < 0.1f) _zoom = 0.1f; } // Negative zoom will flip image
        }
     
        protected float _rotation;

        /// <summary>
        /// Rotação da Camera
        /// </summary>
        public float Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }

        /// <summary>
        /// Matriz de transformação
        /// </summary>
        public Matrix  _transform;
        
        
        private Vector2 _pos;

        /// <summary>
        /// Posição da camera
        /// </summary>
        public Vector2 Pos
        {
            get { return _pos; }
            set { _pos = value; }
        }

        #endregion
        

        /// <summary>
        /// Construtor da classe
        /// </summary>
        public Camera2D()
        {
            _zoom = 1.0f;
            _rotation = 0.0f;
            _pos = Vector2.Zero;
        }


       /// <summary>
       /// Movimentação da camera
       /// </summary>
       /// <param name="amount"></param>
        public void Move(Vector2 amount)
        {
            _pos += amount;
        }

        public Matrix get_transformation(GraphicsDevice graphicsDevice)
        {
            _transform =      
              Matrix.CreateTranslation(new Vector3(-_pos.X, -_pos.Y, 0)) *
                                         Matrix.CreateRotationZ(Rotation) *
                                         Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) *
                                         Matrix.CreateTranslation(new Vector3(graphicsDevice.Viewport.Width * 0.5f,graphicsDevice.Viewport.Height * 0.5f, 0));
            return _transform;
        }

    }
}
