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
    public partial class ClockForm : Form
    {
        public ClockForm()
        {
            InitializeComponent();
        }

        private void ClockForm_Load(object sender, EventArgs e)
        {
            UpdateLabel(secondLabel, DateTime.Now.Second);
            UpdateLabel(minuteLabel, DateTime.Now.Minute);
            UpdateLabel(hourLabel, DateTime.Now.Hour);

            secondTimer.Interval = 1000;
            minuteTimer.Interval = 60000;
            hourTimer.Interval = 360000;

            secondTimer.Tick += new EventHandler(SecondTimer_Tick);
            minuteTimer.Tick += new EventHandler(MinuteTimer_Tick);
            hourTimer.Tick += new EventHandler(HourTimer_Tick);

            secondTimer.Start();
            minuteTimer.Start();
            hourTimer.Start();
        }

        private void UpdateLabel(Label label, int value)
        {
            string text;

            if (value < 10)
            {
                text = "0" + value.ToString();
            }
            else
            {
                text = value.ToString();
            }

            label.Text = text;
        }

        private void SecondTimer_Tick(object sender, EventArgs e)
        {
            UpdateLabel(secondLabel, DateTime.Now.Second);
        }

        private void MinuteTimer_Tick(object sender, EventArgs e)
        {
            UpdateLabel(minuteLabel, DateTime.Now.Minute);
        }

        private void HourTimer_Tick(object sender, EventArgs e)
        {
            UpdateLabel(hourLabel, DateTime.Now.Hour);
        }
    }
}
