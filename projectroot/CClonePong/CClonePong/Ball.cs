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
    class Ball
    {
        private PictureBox ball;
        private Point zero;     // posición inicial de la bola
        private double startingSpeed;
        public double RunningSpeed;
        public bool DirectionX, DirectionY, CtrlX;

        // Declaro el constructor
        public Ball(PictureBox sprite)
        {
            ball = sprite;
            startingSpeed = 6;
            RunningSpeed = startingSpeed;
            DirectionX = GetRandomBool();
            DirectionY = GetRandomBool();
            CtrlX = DirectionX;     // ésto me permite controlar en qué sentido se inició la bola la última vez (para evitar que salga varias veces seguidas por el mismo lado)
            zero = ball.Location;
        }

        // Declaro un getter para sacar la posición de la bola
        public Point GetBallLoc()
        {
            return ball.Location;
        }

        // Declaro la función para mover la bola (he decidido no limitar la velocidad porque me va el harco y a los clones también)
        public void MoveBall()
        {
            int NewX = 0;
            int NewY = 0;
            if (DirectionX)
            {
                NewX = ball.Location.X + (int)RunningSpeed;
            }
            else
            {
                NewX = ball.Location.X - (int)RunningSpeed;
            }
            if (DirectionY)
            {
                NewY = ball.Location.Y + (int)RunningSpeed;
            }
            else
            {
                NewY = ball.Location.Y - (int)RunningSpeed;
            }
            ball.Location = new Point(NewX, NewY);
            Application.DoEvents();
        }

        // Declaro la función para resetear la bola
        public void ResetBall()
        {
            ball.Location = zero;
            RunningSpeed = startingSpeed;
            DirectionY = GetRandomBool();
            if (CtrlX)
            {
                DirectionX = false;
            }
            else
            {
                DirectionX = true;
            }
            CtrlX = DirectionX;
            Application.DoEvents();
        }

        // Declaro una función para generar booleanos aleatorios (la necesito para randomizar los primeros lanzamientos de bola)
        public bool GetRandomBool()
        {
            Random rnd = new Random();
            bool rndBool = true;
            int n = rnd.Next(1, 10);
            if (n % 2 == 0)
            {
                rndBool = false;
            }
            return rndBool;
        }
    }
}
