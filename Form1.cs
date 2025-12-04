using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Store numbers
        double firstNumberDouble, secondNumberDouble;
        decimal firstNumberDecimal, secondNumberDecimal;
        bool control = true; // false = valid input

        // Allow digits, decimal, and negative sign
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
                e.Handled = true;

            // Only one decimal point
            if (e.KeyChar == '.' && tb.Text.Contains("."))
                e.Handled = true;

            // Only one negative sign at start
            if (e.KeyChar == '-' && tb.SelectionStart != 0)
                e.Handled = true;
        }

        // Set first and second number (decimal) for operations like Min/Max
        void set2ParametersDecimal()
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                firstNumberDecimal = Convert.ToDecimal(textBox1.Text);
                secondNumberDecimal = Convert.ToDecimal(textBox2.Text);
                control = false;
            }
            else
            {
                control = true;
            }
        }

        // Set only first number (decimal) for operations like Abs/Sign
        void set1ParametersDecimal()
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                firstNumberDecimal = Convert.ToDecimal(textBox1.Text);
                control = false;
            }
            else
            {
                control = true;
            }
        }

        // Set first and second number (double) for operations like Sin/Cos/Tan/Pow
        void set2ParametersDouble()
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                firstNumberDouble = Convert.ToDouble(textBox1.Text);
                secondNumberDouble = Convert.ToDouble(textBox2.Text);
                control = false;
            }
            else
            {
                control = true;
            }
        }

        // Set only first number (double) for Sin/Cos/Tan/Sqrt/Exp/Log/Log10
        void set1ParametersDouble()
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                firstNumberDouble = Convert.ToDouble(textBox1.Text);
                control = false;
            }
            else
            {
                control = true;
            }
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            set2ParametersDecimal();
            if (!control)
                textResult.Text = Math.Min(firstNumberDecimal, secondNumberDecimal).ToString();
            else
                MessageBox.Show("Please enter both numbers.");
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            set2ParametersDecimal();
            if (!control)
                textResult.Text = Math.Max(firstNumberDecimal, secondNumberDecimal).ToString();
            else
                MessageBox.Show("Please enter both numbers.");
        }

        private void btnAbs_Click(object sender, EventArgs e)
        {
            set1ParametersDecimal();
            if (!control)
                textResult.Text = Math.Abs(firstNumberDecimal).ToString();
            else
                MessageBox.Show("Please enter the first number.");
        }

        private void btnSin_Click(object sender, EventArgs e)
        {
            set1ParametersDouble();
            if (!control)
                textResult.Text = Math.Sin(firstNumberDouble).ToString();
            else
                MessageBox.Show("Please enter the first number.");
        }

        private void btnCos_Click(object sender, EventArgs e)
        {
            set1ParametersDouble();
            if (!control)
                textResult.Text = Math.Cos(firstNumberDouble).ToString();
            else
                MessageBox.Show("Please enter the first number.");
        }

        private void btnTan_Click(object sender, EventArgs e)
        {
            set1ParametersDouble();
            if (!control)
                textResult.Text = Math.Tan(firstNumberDouble).ToString();
            else
                MessageBox.Show("Please enter the first number.");
        }

        private void btnPow_Click(object sender, EventArgs e)
        {
            set2ParametersDouble();
            if (!control)
                textResult.Text = Math.Pow(firstNumberDouble, secondNumberDouble).ToString();
            else
                MessageBox.Show("Please enter both numbers.");
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            set1ParametersDouble();
            if (!control)
            {
                if (firstNumberDouble > 0)
                    textResult.Text = Math.Log(firstNumberDouble).ToString();
                else
                    MessageBox.Show("Number must be greater than 0 for logarithm.");
            }
            else
                MessageBox.Show("Please enter the first number.");
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            set1ParametersDouble();
            if (!control)
            {
                if (firstNumberDouble >= 0)
                    textResult.Text = Math.Sqrt(firstNumberDouble).ToString();
                else
                    MessageBox.Show("Cannot take square root of a negative number.");
            }
            else
                MessageBox.Show("Please enter the first number.");
        }

        private void btnLog10_Click(object sender, EventArgs e)
        {
            set1ParametersDouble();
            if (!control)
            {
                if (firstNumberDouble > 0)
                    textResult.Text = Math.Log10(firstNumberDouble).ToString();
                else
                    MessageBox.Show("Number must be greater than 0 for log10.");
            }
            else
                MessageBox.Show("Please enter the first number.");
        }

        private void btnExp_Click(object sender, EventArgs e)
        {
            set1ParametersDouble();
            if (!control)
                textResult.Text = Math.Exp(firstNumberDouble).ToString();
            else
                MessageBox.Show("Please enter the first number.");
        }

        private void btnCopyFirstNumber_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textResult.Text))
                textBox1.Text = textResult.Text;
            else
                MessageBox.Show("No result to copy.");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            textResult.Text = "0";
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            set1ParametersDecimal();
            if (!control)
                textResult.Text = Math.Sign(firstNumberDecimal).ToString();
            else
                MessageBox.Show("Please enter the first number.");
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textResult.Text = "";
        }
    }
}

       