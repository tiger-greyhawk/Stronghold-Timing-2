using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Stronghold_Timing_2
{
    public partial class TimerForm : Form
    {
        ControllerArmyWaves controller;
        DateTime timeTo;
        public TimerForm()
        {
            InitializeComponent();
            this.Text = "time";
            this.TopMost = true;
            this.ControlBox = false;
            
        }

        public void SetController(ControllerArmyWaves controller)
        {
            this.controller = controller;
            if (timer1.Enabled) timer1.Enabled = false;
            timer1.Tick -= new EventHandler(timer1_Tick);
            StartTimer();
            
        }

        public void StartTimer()
        {
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Enabled = true;
            timeTo = controller.GetTimeWave(0).AddSeconds(15);
        }

        public void StopTimer()
        {
            timer1.Enabled = false;
            timer1.Stop();
        }

        private void timer1_Tick(object Sender, EventArgs e)
        {
            //Label[] labels = (Label[])Controls.Find("label", false);
            Label[] labels = new Label[10];

            int j = 0;
            foreach (var ctrl in this.Controls)
            {
                if (ctrl is Label)
                    if ((ctrl as Label).Name == "time")
                {
                    labels.SetValue(ctrl, j);
                    j++;
                }
            }
            SoundPlayer sp10 = new SoundPlayer(Properties.Resources._10);
            SoundPlayer sp3 = new SoundPlayer(Properties.Resources._3);
            SoundPlayer sp1 = new SoundPlayer(Properties.Resources._1);

            for (int i = 0; i < Controls.Count/2; i++)
            {

                //Convert.ToString(timeTo - controller.GetTimeWave(i));
                //labels[i].Text = ((timeTo - controller.GetTimeWave(i)).ToString("T"));
                if ((labels[i].Text != "00:00:00") && (labels[i].Text != "sent") && (labels[i].Name == "time"))
                {
                    //labels[i].Size = new Size(50, 15);
                    //labels[i].ForeColor = Color.Black;
                    labels[i].Text = (Convert.ToDateTime(labels[i].Text) - Convert.ToDateTime("00:00:01")).ToString("T");
                }

                if ((labels[i].Text == "00:00:09") && (labels[i].Name == "time"))
                {
                    labels[i].ForeColor = Color.Green;
                    sp10.Play();
                        //.Font = new Font(labels[i].Font.Name, labels[i].Font.Size, labels[i].Font.Style, labels[i].Font.Unit);
                }
                if ((labels[i].Text == "00:00:02") && (labels[i].Name == "time"))
                {
                    labels[i].ForeColor = Color.Red;
                    sp3.Play();
                    //.Font = new Font(labels[i].Font.Name, labels[i].Font.Size, labels[i].Font.Style, labels[i].Font.Unit);
                }
                if ((labels[i].Text == "00:00:00") && (labels[i].Name == "time"))
                {
                    //labels[i].ForeColor = Color.Red;
                    sp1.Play();
                    labels[i].Text = "sent";
                    //.Font = new Font(labels[i].Font.Name, labels[i].Font.Size, labels[i].Font.Style, labels[i].Font.Unit);
                }
            }
        }

    }
}
