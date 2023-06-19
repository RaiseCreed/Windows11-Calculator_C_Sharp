using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Kalkulator
{
    public partial class Form1 : Form
    {
        private string _operation;
        private double _numberA;
        private double _numberB;
        private int replace = 0;

        public string Operation
        {
            get { return _operation; }
            set { _operation = value; }
        }

        public double NumberA
        {
            get { return _numberA; }
            set { _numberA = value; }
        }

        public double NumberB
        {
            get { return _numberB; }
            set { _numberB = value; }
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void addDigit(object sender, EventArgs e)
        {
            input.Font = new Font("Microsoft Sans Serif", 50);
            Button clickedButton = (Button)sender;
            if (input.Text.Length < 13 || input.Text == "You cant divide by 0!" || replace == 1)
            {
                if (input.Text == "0")
                {
                    input.Text = clickedButton.Text;
                }
                else
                {
                    if(replace == 1)
                    {
                        input.Text = clickedButton.Text;
                        replace = 0;
                    } 
                    else
                        input.Text = input.Text + clickedButton.Text;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            input.Text = "0";
            hint.Text = "";
            NumberA = 0;
            NumberB = 0;
            replace = 0;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (input.Text.Length==1)
            {
                input.Text = "0";
            }
            else
            {
                input.Text = input.Text.Remove(input.Text.Length - 1);
            }
        }

        private void btnComma_Click(object sender, EventArgs e)
        {
            if (!input.Text.Contains(",")){
                input.Text = input.Text + ",";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NumberA = double.Parse(input.Text);
            Operation = "+";
            hint.Text = input.Text + " " + Operation + " ";
            replace = 1;
        }

        private void btnSubstract_Click(object sender, EventArgs e)
        {
            NumberA = double.Parse(input.Text);
            Operation = "-";
            hint.Text = input.Text + " "+Operation+" ";
            replace = 1;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            NumberA = double.Parse(input.Text);
            Operation = "*";
            hint.Text = input.Text + " " + Operation + " ";
            replace = 1;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            NumberA = double.Parse(input.Text);
            Operation = "/";
            hint.Text = input.Text + " " + Operation + " ";
            replace = 1;
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {   
            if(hint.Text.Contains("="))
            {
                NumberA = double.Parse(input.Text);
                hint.Text = input.Text +" " + Operation + " " + NumberB.ToString() + " =";
            }
            else
            {
                NumberB = double.Parse(input.Text);
                hint.Text = hint.Text + NumberB.ToString() + " =";
            }

            switch (Operation)
            {
                case "+":
                    input.Text = (NumberA+NumberB).ToString("G8");
                    break;
                case "-":
                    input.Text = (NumberA - NumberB).ToString("G8");
                    break;
                case "*":
                    input.Text = (NumberA * NumberB).ToString("G8");
                    break;
                case "/":
                    if (NumberB == 0)
                    {
                        input.Font = new Font("Microsoft Sans Serif", 25);
                        input.Text = "You cant divide by 0!";
                    }
                    else
                        input.Text = (NumberA / NumberB).ToString("G8");
                    break;
            }
            replace = 1;
        }
    }
}
