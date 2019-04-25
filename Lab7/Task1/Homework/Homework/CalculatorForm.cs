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

            Binding binding = new Binding("text", lastResultLabel, "text", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxCurrentInput.DataBindings.Add(binding);
        }

        /// <summary>
        /// Обработчики нажатий на клавиши, отвечающие за отмену ввода
        /// </summary>
        private void ButtonEraseAll_Click(object sender, EventArgs e)
        {
            textBoxCurrentInput.Clear();
        }

        private void ButtonEraseSymbol_Click(object sender, EventArgs e)
        {
            if (textBoxCurrentInput.Text.Length == 0)
            {
                return;
            }

            textBoxCurrentInput.Text = textBoxCurrentInput.Text.Remove(textBoxCurrentInput.Text.Length - 1);
        }

        /// <summary>
        /// Обработчики нажатий на кнопки-цифры
        /// </summary>
        private void Button0_Click(object sender, EventArgs e)
        {
            if (Validators.InputValidator.CanDigitBeAdded(textBoxCurrentInput.Text))
            {
                textBoxCurrentInput.Text += "0";
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Validators.InputValidator.CanDigitBeAdded(textBoxCurrentInput.Text))
            {
                textBoxCurrentInput.Text += "1";
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (Validators.InputValidator.CanDigitBeAdded(textBoxCurrentInput.Text))
            {
                textBoxCurrentInput.Text += "2";
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (Validators.InputValidator.CanDigitBeAdded(textBoxCurrentInput.Text))
            {
                textBoxCurrentInput.Text += "3";
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (Validators.InputValidator.CanDigitBeAdded(textBoxCurrentInput.Text))
            {
                textBoxCurrentInput.Text += "4";
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (Validators.InputValidator.CanDigitBeAdded(textBoxCurrentInput.Text))
            {
                textBoxCurrentInput.Text += "5";
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if (Validators.InputValidator.CanDigitBeAdded(textBoxCurrentInput.Text))
            {
                textBoxCurrentInput.Text += "6";
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            if (Validators.InputValidator.CanDigitBeAdded(textBoxCurrentInput.Text))
            {
                textBoxCurrentInput.Text += "7";
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            if (Validators.InputValidator.CanDigitBeAdded(textBoxCurrentInput.Text))
            {
                textBoxCurrentInput.Text += "8";
            }
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            if (Validators.InputValidator.CanDigitBeAdded(textBoxCurrentInput.Text))
            {
                textBoxCurrentInput.Text += "9";
            }
        }

        /// <summary>
        /// Обработчик нажатия на кнопку с запятой
        /// </summary>
        private void ButtonComma_Click(object sender, EventArgs e)
        {
            if (Validators.InputValidator.CanCommaBeAdded(textBoxCurrentInput.Text))
            {
                if (Validators.InputValidator.ShouldZeroBeAddedBeforeComma(textBoxCurrentInput.Text))
                {
                    textBoxCurrentInput.Text += "0";
                }

                textBoxCurrentInput.Text += ",";
            }
        }

        /// <summary>
        /// Обработчики нажатий на кнопки со скобками
        /// </summary>
        private void ButtonLeftBracket_Click(object sender, EventArgs e)
        {
            if (Validators.InputValidator.CanLeftBracketBeAdded(textBoxCurrentInput.Text))
            {
                textBoxCurrentInput.Text += "(";
            }
        }

        private void ButtonRightBracket_Click(object sender, EventArgs e)
        {
            if (Validators.InputValidator.CanRightBracketBeAdded(textBoxCurrentInput.Text))
            {
                textBoxCurrentInput.Text += ")";
            }
        }

        /// <summary>
        /// Обработка нажатий на кнопки с операторами
        /// </summary>
        private void ButtonPlus_Click(object sender, EventArgs e)
        {
            if (Validators.InputValidator.CanOperatorBeAdded(textBoxCurrentInput.Text, false))
            {
                textBoxCurrentInput.Text += "+";
            }
        }

        private void ButtonMinus_Click(object sender, EventArgs e)
        {
            if (Validators.InputValidator.CanOperatorBeAdded(textBoxCurrentInput.Text, true))
            {
                textBoxCurrentInput.Text += "-";
            }
        }

        private void ButtonMultiply_Click(object sender, EventArgs e)
        {
            if (Validators.InputValidator.CanOperatorBeAdded(textBoxCurrentInput.Text, false))
            {
                textBoxCurrentInput.Text += "×";
            }
        }

        private void ButtonDivide_Click(object sender, EventArgs e)
        {
            if (Validators.InputValidator.CanOperatorBeAdded(textBoxCurrentInput.Text, false))
            {
                textBoxCurrentInput.Text += "÷";
            }
        }

        /// <summary>
        /// Обработчик нажатия на кнопку "="
        /// </summary>
        private void ButtonEquals_Click(object sender, EventArgs e)
        {
            if (textBoxCurrentInput.Text.Length == 0)
            {
                return;
            }

            if (Validators.InputValidator.CanExpressionBeCalculated(textBoxCurrentInput.Text))
            {
                try
                {
                    textBoxCurrentInput.Text = Calculator.Calculator.Calculate(textBoxCurrentInput.Text).ToString();
                }
                catch (DivideByZeroException)
                {
                    var message = "Не надо делить на 0.";
                    var title = "Ошибка вычисления";
                    MessageBox.Show(message, title);
                }
            }
            else
            {
                var message = "Проверьте корректность введённого выражения и снова попробуйте получить результат.";
                var title = "Ошибка вычисления";
                MessageBox.Show(message, title);
            }
        }

        /// <summary>
        /// Отвечает за ввод выражения с клавиатуры
        /// </summary>
        private void TextBoxCurrentInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;
        }
    }
}
