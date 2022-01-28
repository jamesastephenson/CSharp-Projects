using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpCalculator
{
    public partial class Form1 : Form
    {
        // Define global vars
        string firstNum = "";
        string secondNum = "";
        char function;
        double result = 0.0;
        string userInput = "";

        public Form1()
        {
            InitializeComponent();
        }

        // Start of Num Buttons ----------------------------------------
        // - each num button resets display text, appends str val to userInput and outputs to display
        private void zeroBtn_Click(object sender, EventArgs e)
        {
            display.Text = "";
            userInput += "0";
            display.Text += userInput;
        }

        private void oneBtn_Click(object sender, EventArgs e)
        {
            display.Text = "";
            userInput += "1";
            display.Text += userInput;
        }

        private void twoBtn_Click(object sender, EventArgs e)
        {
            display.Text = "";
            userInput += "2";
            display.Text += userInput;
        }

        private void threeBtn_Click(object sender, EventArgs e)
        {
            display.Text = "";
            userInput += "3";
            display.Text += userInput;
        }

        private void fourBtn_Click(object sender, EventArgs e)
        {
            display.Text = "";
            userInput += "4";
            display.Text += userInput;
        }

        private void fiveBtn_Click(object sender, EventArgs e)
        {
            display.Text = "";
            userInput += "5";
            display.Text += userInput;
        }

        private void sixBtn_Click(object sender, EventArgs e)
        {
            display.Text = "";
            userInput += "6";
            display.Text += userInput;
        }

        private void sevenBtn_Click(object sender, EventArgs e)
        {
            display.Text = "";
            userInput += "7";
            display.Text += userInput;
        }

        private void eightBtn_Click(object sender, EventArgs e)
        {
            display.Text = "";
            userInput += "8";
            display.Text += userInput;
        }

        private void nineBtn_Click(object sender, EventArgs e)
        {
            display.Text = "";
            userInput += "9";
            display.Text += userInput;
        }
        // End of Num Buttons ----------------------------------------

        // Add decimal point similar to num buttons
        private void decimalBtn_Click(object sender, EventArgs e)
        {
            display.Text = "";
            // Prevent user adding multiple decimal points
            if (userInput.Contains(".")) { userInput += ""; }
            else { userInput += "."; }
            display.Text += userInput;
        }

        // Start of operation buttons ----------------------------------
        // - each button sets the function var to the appropriate operation
        // - if firstNum is filled (from prev use), then secondNum gets the user input
        private void plusBtn_Click(object sender, EventArgs e)
        {
            function = '+';
            if (firstNum == "") { firstNum = userInput; }
            else { secondNum = userInput; }
            userInput = "";
        }

        private void minusBtn_Click(object sender, EventArgs e)
        {
            function = '-';
            if (firstNum == "") { firstNum = userInput; }
            else { secondNum = userInput; }
            userInput = "";
        }

        private void multiplyBtn_Click(object sender, EventArgs e)
        {
            function = '*';
            if (firstNum == "") { firstNum = userInput; }
            else { secondNum = userInput; }
            userInput = "";
        }

        private void divideBtn_Click(object sender, EventArgs e)
        {
            function = '/';
            if (firstNum == "") { firstNum = userInput; }
            else { secondNum = userInput; }
            userInput = "";
        }
        // End of operation buttons ----------------------------------

        // Clear global vars
        private void clearBtn_Click(object sender, EventArgs e)
        {
            firstNum = "";
            secondNum = "";
            userInput = "";
            result = 0.0;
            display.Text = "0";
        }

        // Convert strs to doubles, perform math, assign result to firstNum so calc can be used again
        private void equalBtn_Click(object sender, EventArgs e)
        {
            secondNum = userInput;
            double firstDoub, secondDoub;

            // error handling for empty vars
            if (firstNum == "" || secondNum == "") { display.Text = "Please enter numbers"; }
            else
            {
                firstDoub = Convert.ToDouble(firstNum);
                secondDoub = Convert.ToDouble(secondNum);

                if (function == '+')
                {
                    result = firstDoub + secondDoub;
                    display.Text = result.ToString();
                    firstNum = result.ToString();
                }
                else if (function == '-')
                {
                    result = firstDoub - secondDoub;
                    display.Text = result.ToString();
                    firstNum = result.ToString();
                }
                else if (function == '*')
                {
                    result = firstDoub * secondDoub;
                    display.Text = result.ToString();
                    firstNum = result.ToString();
                }
                else if (function == '/')
                {
                    // error handling for divide-by-zero
                    if (secondDoub == 0)
                    {
                        display.Text = "Impossible";
                    }
                    else
                    {
                        result = firstDoub / secondDoub;
                        display.Text = result.ToString();
                        firstNum = result.ToString();
                    }
                }
            }
        }
    }
}
