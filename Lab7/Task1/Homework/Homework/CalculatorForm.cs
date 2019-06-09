using System;
using System.Windows.Forms;

namespace Homework
{
    public partial class CalculatorForm : Form
    {
        public CalculatorForm()
        {
            InitializeComponent();

            var binding = new Binding("text", lastResultLabel, "text", true, DataSourceUpdateMode.OnPropertyChanged);
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
        private void ButtonDigit_Click(object sender, EventArgs e)
        {
            if (Validators.InputValidator.CanDigitBeAdded(textBoxCurrentInput.Text))
            {
                textBoxCurrentInput.Text += (sender as Button).Text;
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

                textBoxCurrentInput.Text += ".";
            }
        }

        /// <summary>
        /// Обработчик нажатий на кнопки со скобками
        /// </summary>
        private void ButtonBracket_Click(object sender, EventArgs e)
        {
            var buttonText = (sender as Button).Text;
            var isLeft = buttonText == "(";

            if (Validators.InputValidator.CanBracketBeAdded(textBoxCurrentInput.Text, isLeft))
            {
                textBoxCurrentInput.Text += buttonText;
            }
        }

        /// <summary>
        /// Обработка нажатий на кнопки с операторами
        /// </summary>
        private void ButtonOperator_Click(object sender, EventArgs e)
        {
            var buttonText = (sender as Button).Text;
            var isMinus = buttonText == "-";

            if (Validators.InputValidator.CanOperatorBeAdded(textBoxCurrentInput.Text, isMinus))
            {
                textBoxCurrentInput.Text += buttonText;
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