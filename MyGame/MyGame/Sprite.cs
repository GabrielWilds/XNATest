using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MyGame
{
    public class Sprite
    {
        private Vector2 _position = Vector2.Zero;
        private Vector2 _speed = new Vector2(50.0f, 50.0f);

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public Texture2D Texture
        {
            get;
            private set;
        }

        public Vector2 Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public Sprite(Texture2D _tex)
        {
            Texture = _tex;
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(Texture, Position, Color.White);
        }

        public void MoveDown(int distance)
        {
            _position.Y += distance;
        }

        public void MoveUp(int distance)
        {
            _position.Y -= distance;
        }

        public void MoveRight(int distance)
        {
            _position.X += distance;
        }

        public void MoveLeft(int distance)
        {
            _position.X -= distance;
        }

        public void SpeedUpY(int change)
        {
            _speed.Y += change;
        }

        public void SlowY(int change)
        {
            _speed.Y -= change;
        }

        public void ReverseYSpeed()
        {
            _speed.Y *= -1;
        }

        public void SpeedUpX(int change)
        {
            _speed.X += change;
        }

        public void SlowX(int change)
        {
            _speed.X -= change;
        }

        public void ReverseXSpeed()
        {
            _speed.X *= -1;
        }
    }
}
