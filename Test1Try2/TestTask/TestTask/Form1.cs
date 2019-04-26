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
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик нажатия на кнопку RunningButton
        /// </summary>
        private void RunningButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Haha, u must have cheated with TAB, uh?");
            Application.Exit();
        }

        /// <summary>
        /// Обработчик события "Пользователь пытается навести курсор на кнопку RunningButton"
        /// </summary>
        private void RunningButton_MouseEnter(object sender, EventArgs e)
        {
            var phrases = new List<string>() { "Haha", "You loose", "LOL", "You can do it!", "LMAO", "Catch it!" };

            Random r = new Random();

            this.Text = phrases[r.Next(phrases.Count)];

            TrollingButton.Location = new Point((TrollingButton.Location.X + Width / 2) % Width, TrollingButton.Location.Y);
            TrollingButton.BackColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
            TrollingButton.ForeColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
        }
    }
}
