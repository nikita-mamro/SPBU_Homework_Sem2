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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик нажатия на кнопку RunningButton
        /// </summary>
        private void RunningButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Обработчик события "Пользователь пытается навести курсор на кнопку RunningButton"
        /// </summary>
        private void RunningButton_MouseEnter(object sender, EventArgs e)
        {
            Random r = new Random();
            RunningButton.Location = new Point((RunningButton.Location.X + Width / 2) % Width, RunningButton.Location.Y);
            RunningButton.BackColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
            RunningButton.ForeColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
        }
    }
}
