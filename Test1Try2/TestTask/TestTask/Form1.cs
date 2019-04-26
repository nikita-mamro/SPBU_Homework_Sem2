using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTask
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Список фраз, которые будут появляться в поле названия формы и мотивировать пользователя нажать на кнопку.
        /// </summary>
        private List<string> motivationalPhrases;

        public MainForm()
        {
            InitializeComponent();
            motivationalPhrases = new List<string>() { "Haha", "You loose", "LOL", "You can do it!", "LMAO", "Catch it!" };
        }

        /// <summary>
        /// Обработчик нажатия на кнопку TrollingButton.
        /// </summary>
        private void RunningButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanks for trying to do that.");
            Application.Exit();
        }

        /// <summary>
        /// Обработчик попытки наведения курсора мыши на кнопку TrollingButton.
        /// </summary>
        private void RunningButton_MouseEnter(object sender, EventArgs e)
        {
            Random r = new Random();

            Text = motivationalPhrases[r.Next(motivationalPhrases.Count)];

            TrollingButton.Location = new Point((TrollingButton.Location.X + Width / 2) % Width, TrollingButton.Location.Y);
            TrollingButton.BackColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
            TrollingButton.ForeColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
        }
    }
}
