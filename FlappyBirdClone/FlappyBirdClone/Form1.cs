using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBirdClone
{
    public partial class Form1 : Form
    {
        // define global vars
        int pipeSpeed = 8;
        int gravity = 15;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        // Main game function, based on timer
        private void gameTimeEvent(object sender, EventArgs e)
        {
            // push bird down inside timer
            // push back up on space press
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score.ToString();

            // repopulate pipes after they go offscreen
            if (pipeBottom.Left < -120)
            {
                pipeBottom.Left = 800;
                score++;
            }
            if (pipeTop.Left < -150)
            {
                pipeTop.Left = 950;
                score++;
            }

            // speed up game after 5 points
            if (score > 5)
            {
                pipeSpeed = 20;
            }

            // prevent user from flying above game screen
            if (flappyBird.Top < -25)
            {
                flappyBird.Top = -25;
            }


            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) || 
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds))
            {
                endGame();
            }
        }

        // Raise bird up on spacebar press
        private void gameKeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }
        }

        // Make bird fall when button is released
        private void gameKeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }
        }

        // Executes when pipes or ground are hit
        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += " Game Over!";
        }
    }
}
