using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        int addend1;
        int addend2;
        int minusend1;
        int minusend2;
        int multiplicand;
        int multiplier;
        int divisor;
        int dividend;
        int timeLeft;

        private void StartQuiz()
        {
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            sum.Value = 0;

            minusend1 = randomizer.Next(51);
            minusend2 = randomizer.Next(1, minusend1);
            minusLeftLabel.Text = minusend1.ToString();
            minusRightLabel.Text = minusend2.ToString();
            difference.Value = 0;

            multiplicand = randomizer.Next(10);
            multiplier = randomizer.Next(10);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }

        private bool CheckTheAnswer()
        {
            if ((sum.Value == addend1 + addend2) && (difference.Value == minusend1 - minusend2) && (product.Value == multiplicand * multiplier) && (quotient.Value == dividend / divisor))
                return true;
            else
                return false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartQuiz();
            startButton.Enabled = false;
            timeLabel.BackColor = Color.White;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                        "Congratulations!");
                startButton.Enabled = true;
            } else
            {
                if (timeLeft == 0)
                {
                    timer1.Stop();
                    timeLabel.Text = "Time is up";
                    MessageBox.Show("You didn't finish in time.", "Sorry!");
                    sum.Value = addend1 + addend2;
                    difference.Value = minusend1 - minusend2;
                    product.Value = multiplicand * multiplier;
                    quotient.Value = dividend / divisor;
                    startButton.Enabled = true;
                } else
                {
                    timeLeft -= 1;
                    timeLabel.Text = timeLeft.ToString() + " seconds";
                    if (timeLeft <= 5)
                    {
                        timeLabel.BackColor = Color.Red;
                    }
                }
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int answerLen = answerBox.Value.ToString().Length;
                answerBox.Select(0, answerLen);
            }
        }
    }
}
