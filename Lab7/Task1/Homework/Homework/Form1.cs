using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework
{
    public partial class CalculatorForm : Form
    {
        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void ButtonEraseAll_Click(object sender, EventArgs e)
        {
            textBoxCurrentInput.Clear();
        }

        private void Button0_Click(object sender, EventArgs e)
        {
            textBoxCurrentInput.Text += "0";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            textBoxCurrentInput.Text += "1";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textBoxCurrentInput.Text += "2";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            textBoxCurrentInput.Text += "3";
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            textBoxCurrentInput.Text += "4";
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            textBoxCurrentInput.Text += "5";
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            textBoxCurrentInput.Text += "6";
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            textBoxCurrentInput.Text += "7";
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            textBoxCurrentInput.Text += "8";
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            textBoxCurrentInput.Text += "9";
        }

        private void ButtonEraseSymbol_Click(object sender, EventArgs e)
        {
            if (textBoxCurrentInput.Text.Length == 0)
            {
                return;
            }

            textBoxCurrentInput.Text = textBoxCurrentInput.Text.Remove(textBoxCurrentInput.Text.Length - 1);
        }

        private void ButtonComma_Click(object sender, EventArgs e)
        {
            textBoxCurrentInput.Text += ".";
        }

        private void ButtonLeftBracket_Click(object sender, EventArgs e)
        {
            textBoxCurrentInput.Text += "(";
        }

        private void ButtonRightBracket_Click(object sender, EventArgs e)
        {
            textBoxCurrentInput.Text += ")";
        }

        private void ButtonPlus_Click(object sender, EventArgs e)
        {
            textBoxCurrentInput.Text += "+";
        }

        private void ButtonMinus_Click(object sender, EventArgs e)
        {
            textBoxCurrentInput.Text += "-";
        }

        private void ButtonMultiply_Click(object sender, EventArgs e)
        {
            textBoxCurrentInput.Text += "×";
        }

        private void ButtonDivide_Click(object sender, EventArgs e)
        {
            textBoxCurrentInput.Text += "÷";
        }

        private void ButtonEquals_Click(object sender, EventArgs e)
        {

        }
    }
}
