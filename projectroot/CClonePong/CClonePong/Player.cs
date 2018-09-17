using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace CClonePong
{
    class Player
    {
        public int Score;
        private PictureBox racket;
        public bool Moving;
        public bool Direction;
        private int speed;
        private Keys Up, Down;

        // Declaro el constructor
        public Player(PictureBox sprite, Keys Up, Keys Down)
        {
            Score = 0;
            racket = sprite;
            Moving = false;
            speed = 16;
            this.Up = Up;
            this.Down = Down;
        }

        // Declaro un getter para sacar la posición de la raqueta
        public Point GetRacketLoc()
        {
            return racket.Location;
        }

        // Declaro la función para empezar a mover una raqueta (se llama al pulsar cualquier tecla)
        public void StartMoving(Keys PressedKey)
        {
            if (PressedKey == Up)
            {
                Direction = false;
                Moving = true;
            }
            else if (PressedKey == Down)
            {
                Direction = true;
                Moving = true;
            }
        }

        // Declaro la función para dejar de mover la raqueta (se llama al levantar una tecla)
        public void StopMoving(Keys DroppedKey)
        {
            if (Moving && Direction && DroppedKey == Down)                  // si se mueve y es hacia abajo y se ha soltado la tecla Down, se para
            {
                Moving = false;
            }
            else if (Moving && Direction == false && DroppedKey == Up)      // si se mueve y es hacia arriba y se ha soltado la tecla Up, se para
            {
                Moving = false;
            }
        }

        // Declaro la función desplazar raqueta
        public void MoveRacket()
        {
            if (Direction)              // si la dirección es true (hacia abajo) se le suma a Y la velocidad, si se saldría de la ventana se fija en su extremo
            {
                if (racket.Location.Y + speed < 536)    // (536 es la altura de la ventana menos la raqueta)
                {
                    racket.Location = new Point(racket.Location.X, racket.Location.Y + speed);
                }
                else
                {
                    racket.Location = new Point(racket.Location.X, 536);
                }
            }
            else                        // si la dirección es false (hacia arriba) se le resta a Y la velocidad, si se saldría de la ventana se fija en su extremo
            {
                if (racket.Location.Y - speed > 0)
                {
                    racket.Location = new Point(racket.Location.X, racket.Location.Y - speed);
                }
                else
                {
                    racket.Location = new Point(racket.Location.X, 0);
                }
            }
            Application.DoEvents();
        }

        // Declaro la función IA (mover)
        public void MoveIA(int upper, int lower, int height)
        {
            if (lower > racket.Location.Y + height)             // si la bola se encuentra por debajo de la raqueta
            {
                if (racket.Location.Y + speed < 600 - height)   // mueve hacia abajo o fija en el fondo
                {
                    racket.Location = new Point(racket.Location.X, racket.Location.Y + speed);
                }
                else
                {
                    racket.Location = new Point(racket.Location.X, 600 - height);
                }
            }
            else if (upper < racket.Location.Y)                 // si la bola se encuentra por encima de la raqueta
            {
                if (racket.Location.Y - speed > 0)              // mueve hacia arriba o fija encima
                {
                    racket.Location = new Point(racket.Location.X, racket.Location.Y - speed);
                }
                else
                {
                    racket.Location = new Point(racket.Location.X, 0);
                }
            }
            Application.DoEvents();
        }

        // Declaro la función IA (volver) - este pequeño script hace que la IA sea un poco menos dura, al permitirle volver al centro en vez de estar siempre persiguiendo la bola; por mi experiencia de otro modo es casi imbatible (aún así sigue siendo bastante difíci, aunque humanamente posible)
        public void ReturnIA()
        {
            if (racket.Location.Y < 268)
            {
                racket.Location = new Point(racket.Location.X, racket.Location.Y + speed/2);
            }
            else if (racket.Location.Y > 268 + speed)
            {
                racket.Location = new Point(racket.Location.X, racket.Location.Y - speed/2);
            }
            Application.DoEvents();
        }

        // Declaro la función para resetear las palas (cuando el juego termina)
        public void ResetRacket()
        {
            racket.Location = new Point(racket.Location.X, 268);
            Application.DoEvents();
        }
    }
}
