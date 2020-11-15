using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 5;
        int gravity = 15;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }



        private void gameTimerEvent(object sender, EventArgs e)
        {
            FlappyBird.Top += gravity;
            pipeDown.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            ScoreText.Text = "Score:" + score;

            if(pipeDown.Left < -140)
            {
                pipeDown.Left = 700;
                score++;
            }
            if (pipeTop.Left < -180)
            {
                pipeTop.Left = 750;
                score++;
            }
            if(FlappyBird.Bounds.IntersectsWith(pipeDown.Bounds) ||
                FlappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                FlappyBird.Bounds.IntersectsWith(ground.Bounds))
            {
                endGame();
            }

            if(score > 5)
            {
                pipeSpeed = 12;
            }
            else if(score > 10)
            {
                pipeSpeed = 20;
            }
            else if (score > 15)
            {
                pipeSpeed = 30;
            }

            if (FlappyBird.Top < -25)
            {
                endGame();
            }
        }

        private void gamekeydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }
        }



        private void gamekeyup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 8;
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            ScoreText.Text += " Game Over";
           
        }
    }
}
