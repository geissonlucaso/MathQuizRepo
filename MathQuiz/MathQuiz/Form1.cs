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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Create a Rondom object called randomizer to generate random numbers.
        Random randomizer = new Random();

        //This integer variables store the numbers for addition problem.
        int addend1;
        int addend2;

        //This integer variables store the numbers fo subtraction problem.
        int minuend;
        int subtrahend;

        //This integer variable  keeps track of the ramaining time.
        int timeLeft;


        /// <summary>
        /// //Start quiz by filling in all of the problems and start the timer.
        /// </summary>
        public void StartTheQuiz()
        {
            //ADDITION
            //Fill in the addition problem.
            //Generate two random numbers to add.
            //Store the values in the variables "addend1" and "addend2".
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            //Convert the two randomly generated numbers into strings so that they can be displayed in the labels controls.
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            // 'sum' is the name of the NumericUpDown control.
            // This step makes sure its value is zero before
            // adding any values to it.
            sum.Value = 0;

            //SUBTRACTION
            //Fill in the subtraction problem.
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            //Start the timer.
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();

        }


        /// <summary>
        /// Check the answer to see if the user got everything right.
        /// </summary>
        /// <returns> True if the answer is correct, False otherwise </returns>
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value) && 
                (minuend - subtrahend == difference.Value))
                return true;
            else
                return false;
        }


        //Call the StartTheQuiz() method and unenable the Start Button 
        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }


        //Timer event elapsed
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                //If the CheckTheAnswer() returns true, then the use got the answer right. Stop the timer and show 
                //the MessageBox.
                timer1.Stop();
                MessageBox.Show("You got all the answers right!", "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                // If CheckTheAnswer() return false, keep counting
                // down. Decrease the time left by one second and 
                // display the new time left by updating the 
                // Time Left label.
                // Display the new time left by updating the TimeLeft label.
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                //If the user ran out time, stop timer , show a MessageBox, and fill in the answers.
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didin't finish in the time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                startButton.Enabled = true;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            //Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
    }
}
