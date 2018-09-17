using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace CClonePong
{
    public partial class PongWindow : Form
    {
        // Inicializo objetos y variables
        Ball ball;
        Player player1;
        Player player2;
        bool GameIsRunning = false;
        int RefreshTime = 20;           // tiempo de refresco en ms (determina la velocidad general del juego)

        int maxScore = 20;              // seteo las puntuaciones base y máximas (no magic numbers)
        int p1Score = 0;
        int p2Score = 0;

        bool p1Clone = false;           // inicializo booleanos para saber si la IA está activada (false por defecto)
        bool p2Clone = false;

        public PongWindow()
        {
            InitializeComponent();
            ball = new Ball(spriteBall);    // YA SÉ que técnicamente no son sprites, son PictureBox, pero se podrían poner sprites, ¿no?
            player1 = new Player(spriteRacket1, Keys.W, Keys.S);
            player2 = new Player(spriteRacket2, Keys.O, Keys.L);
        }

        // EVENTOS DE ENTRADA (TECLADO)
        private void PongWindow_KeyUp(object sender, KeyEventArgs e)        // al detectar levantamiento de tecla se pasa la función StopMoving a ambos jugadores con la tecla levantada como parámetro
        {
            player1.StopMoving(e.KeyCode);
            player2.StopMoving(e.KeyCode);
        }

        private void PongWindow_KeyDown(object sender, KeyEventArgs e)      // al detectar pulsación de tecla se pasa la función StopMoving a ambos jugadores con la tecla pulsada como parámetro
        {
            player1.StartMoving(e.KeyCode);
            player2.StartMoving(e.KeyCode);
        }

        private void PongWindow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape && !GameIsRunning)           // al pulsar ESC, si el juego está parado se resetea, si está reseteado se cierra (si no, se ignora para impedir cierres por error)
            {
                if (playButton.Text == "reset")
                {
                    this.Close();
                }
                else
                {
                    ResetGame();
                }
            }
        }

        // Botón IA player1
        private void cloneButton1_Click(object sender, EventArgs e)
        {
            if (cloneButton1.Visible)
            {
                if (p1Clone)
                {
                    p1Clone = false;
                    cloneButton1.Text = "human";
                }
                else
                {
                    p1Clone = true;
                    cloneButton1.Text = "clone";
                }
            }
        }

        // Botón IA player2
        private void cloneButton2_Click(object sender, EventArgs e)
        {
            if (cloneButton2.Visible)
            {
                if (p2Clone)
                {
                    p2Clone = false;
                    cloneButton2.Text = "human";
                }
                else
                {
                    p2Clone = true;
                    cloneButton2.Text = "clone";
                }
            }
        }

        // Función para detectar colisión con raqueta (devuelve un booleano)
        public bool CollisionWithPlayer()
        {
            bool collision = false;
            int[] ballSizeX = new int[2] { ball.GetBallLoc().X, ball.GetBallLoc().X + spriteBall.ClientSize.Width };    // me creo unas tablas para controlar la posición actual de la bola            
            if (ball.DirectionX)    // si la pelota va hacia la derecha
            {
                int[] racketSizeX = new int[2] { player2.GetRacketLoc().X, player2.GetRacketLoc().X + spriteRacket2.ClientSize.Width };
                if (ballSizeX[1] >= racketSizeX[0] && ballSizeX[0] <= racketSizeX[1])
                {
                    int[] ballSizeY = new int[2] { ball.GetBallLoc().Y, ball.GetBallLoc().Y + spriteBall.ClientSize.Height };
                    int[] racketSizeY = new int[2] { player2.GetRacketLoc().Y, player2.GetRacketLoc().Y + spriteRacket2.ClientSize.Height };
                    if (ballSizeY[1] >= racketSizeY[0] && ballSizeY[0] <= racketSizeY[1])
                    {
                        collision = true;       // si la bola está dentro del rango X, Y de la pala collision es true
                    }
                }
            }
            else                    // si la pelota va hacia la izquierda
            {
                int[] racketSizeX = new int[2] { player1.GetRacketLoc().X, player1.GetRacketLoc().X + spriteRacket1.ClientSize.Width };
                if (ballSizeX[0] <= racketSizeX[1] && ballSizeX[1] >= racketSizeX[0])
                {
                    int[] ballSizeY = new int[2] { ball.GetBallLoc().Y, ball.GetBallLoc().Y + spriteBall.ClientSize.Height };
                    int[] racketSizeY = new int[2] { player1.GetRacketLoc().Y, player1.GetRacketLoc().Y + spriteRacket1.ClientSize.Height };
                    if (ballSizeY[1] >= racketSizeY[0] && ballSizeY[0] <= racketSizeY[1])
                    {
                        collision = true;       // si la bola está dentro del rango X, Y de la pala collision es true
                    }
                }
            }
            return collision;
        }

        // Función para detectar colisión con paredes horizontales (devuelve un booleano)
        public bool CollisionWithWall()
        {
            bool collision = false;
            if (ball.DirectionY && (ball.GetBallLoc().Y + spriteBall.ClientSize.Height) >= 600)
            {
                collision = true;
            }
            else if (ball.GetBallLoc().Y <= 0)
            {
                collision = true;
            }
            return collision;
        }

        // Función para detectar colisión con paredes verticales (devuelve un booleano)
        public bool CollisionGoal()
        {
            bool collision = false;
            if (ball.DirectionX && (ball.GetBallLoc().X + spriteBall.ClientSize.Width) >= 800)
            {
                collision = true;
            }
            else if (ball.GetBallLoc().X <= 0)
            {
                collision = true;
            }
            return collision;
        }

        // Función para resetear la partida
        public void ResetGame()
        {
            playButton.Text = "reset";
            cloneButton1.Visible = true;
            cloneButton2.Visible = true;
            player1.ResetRacket();
            player2.ResetRacket();
            ball.ResetBall();
        }

        // Botón start/stop
        private void playButton_Click(object sender, EventArgs e)
        {
            cloneButton1.Visible = false;
            cloneButton2.Visible = false;

            if (playButton.Text == "reset")   // si la partida ya había terminado, reseteamos puntuaciones
            {
                p1Score = 0;
                p2Score = 0;
                scoreLabel.Text = p1Score.ToString("00") + " : " + p2Score.ToString("00");
            }

            if (GameIsRunning)
            {
                GameIsRunning = false;
                playButton.Text = "play";
            }
            else
            {
                GameIsRunning = true;
                playButton.Text = "stop";
            }

            while (GameIsRunning)       // BUCLE DE JUEGO
            {
                Thread.Sleep(RefreshTime);

                ball.MoveBall();        // mover la bola

                if (player1.Moving && !p1Clone)     // movimiento de las palas: si está moviendo el jugador 1, mover la pala 1 (lo mismo para el jugador 2)
                {
                    player1.MoveRacket();
                }
                if (player2.Moving && !p2Clone)
                {
                    player2.MoveRacket();
                }
                if (p1Clone)
                {
                    if (ball.DirectionX)
                    {
                        player1.ReturnIA();
                    }
                    else
                    {
                        player1.MoveIA(ball.GetBallLoc().Y, ball.GetBallLoc().Y + spriteBall.ClientSize.Height, spriteRacket1.ClientSize.Height);
                    }
                }
                if (p2Clone)
                {
                    if (ball.DirectionX)
                    {
                        player2.MoveIA(ball.GetBallLoc().Y, ball.GetBallLoc().Y + spriteBall.ClientSize.Height, spriteRacket2.ClientSize.Height);
                    }
                    else
                    {
                        player2.ReturnIA();
                    }
                }

                if (CollisionWithPlayer())  // si hay colisión con las raquetas, refleja el eje X
                {
                    System.Media.SystemSounds.Beep.Play();
                    ball.RunningSpeed += 0.5;   // la aceleración de la bola se hace por colisión con jugador (como en el pong original, que no dispone de contador de tiempo)
                    if (ball.DirectionX)
                    {
                        ball.DirectionX = false;
                    }
                    else
                    {
                        ball.DirectionX = true;
                    }
                }

                if (CollisionWithWall())    // si hay colisión con las paredes horizontales, rebota en eje Y
                {
                    System.Media.SystemSounds.Beep.Play();
                    if (ball.DirectionY)
                    {
                        ball.DirectionY = false;
                    }
                    else
                    {
                        ball.DirectionY = true;
                    }
                }

                if (CollisionGoal())        // si hay colisión con los extremos verticales, punto y reset
                {
                    if (ball.DirectionX)
                    {
                        p1Score += 1;
                    }
                    else
                    {
                        p2Score += 1;
                    }
                    System.Media.SystemSounds.Exclamation.Play();
                    scoreLabel.Text = p1Score.ToString("00") + " : " + p2Score.ToString("00");
                    ball.ResetBall();
                    GameIsRunning = false;
                    playButton.Text = "play";
                }

                if (p1Score == maxScore || p2Score == maxScore)     // si un jugador ha alcanzado la puntuación máxima la partida termina
                {
                    ResetGame();
                    break;
                }
            }
        }
    }
}
