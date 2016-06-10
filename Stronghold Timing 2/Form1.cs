using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stronghold_Timing_2
{
    public partial class Form1 : Form
    {
        //private CurrencyManager currencyManager = null;
        
        ControllerArmyWaves controller = new ControllerArmyWaves();
        TimerForm timerForm = new TimerForm();
        TimingPacket[] packets = new TimingPacket[10];
        int packetsCount = 0;
        bool startedTime;
        public Form1()
        {
            InitializeComponent();
            AddNewPacket();
            
            
        }

        private void timeArmy1_Leave(object sender, EventArgs e)
        {
            int i;
            
            switch (sender.GetType().ToString())
            {
                case "System.Windows.Forms.MaskedTextBox": i = Convert.ToInt32((sender as MaskedTextBox).Tag); break;
                case "System.Windows.Forms.ComboBox": i = Convert.ToInt32((sender as ComboBox).Tag); break;
                case "System.Windows.Forms.TextBox": i = Convert.ToInt32((sender as TextBox).Tag); break;
                default: i = 5; break;
            }
            //MessageBox.Show(sender.GetType().ToString());
            //int i = Convert.ToInt32((sender as MaskedTextBox).Tag);
            MaskedTextBox timeArmy = packets[i].timeArmy;
            ComboBox cardArmy = packets[i].cardArmy;
            TextBox commentArmy = packets[i].commentArmy;
            controller.SetWave(i, timeArmy.Text, cardArmy.SelectedIndex+1, commentArmy.Text);
            label1.Text = controller.GetWave(i);
            if (i == packetsCount-1 && timeArmy.Text != "  :  :") AddNewPacket();
            if (timeArmy.Text =="  :  :")
                for (int j = packetsCount - 1; j > i; j--)
                {
                    this.Controls.Remove(packets[j].timeArmy);
                    this.Controls.Remove(packets[j].cardArmy);
                    this.Controls.Remove(packets[j].commentArmy);
                    packets[j] = null;
                    packetsCount--;
                }
            
            //MessageBox.Show(controller.GetWave(i));
        }

        
        public void AddNewPacket()
        {
            bool tempLast = false;
            for (int i = 0; i < packets.Length; i++)
            {
                if ((packets.GetValue(i) == null) && !tempLast)
                {
                    //packets.SetValue(new TimingPacket(), i);
                    TimingPacket newPacket = new TimingPacket(i);
                    packetsCount++;
                    //newPacket.timeArmy.
                    packets[i] = newPacket;

                    //MessageBox.Show("" + i);
                    tempLast = true;
                    //this.Controls["panel1"].SuspendLayout();
                    //packets[i].timeArmy.Location = new Point(b.Location.X + b.Width + 10, b.Location.Y);
                    this.Controls.Add(packets[i].timeArmy);
                    packets[i].timeArmy.Leave += new EventHandler(timeArmy1_Leave);
                    packets[i].cardArmy.SelectedIndexChanged += new EventHandler(timeArmy1_Leave);
                    packets[i].commentArmy.Leave += new EventHandler(timeArmy1_Leave);
                    this.Controls.Add(packets[i].cardArmy);
                    this.Controls.Add(packets[i].commentArmy);
                    //this.Controls["panel1"].ResumeLayout();
                }
            }
        }

        private class TimingPacket
        {
            public MaskedTextBox timeArmy = new MaskedTextBox();
            public ComboBox cardArmy = new ComboBox();
            public TextBox commentArmy = new TextBox();
            //public ArmyWave army = new ArmyWave("0:0:0",1,"");
            //public Controller controller = new Controller();
            public TimingPacket(int j)
            {
                //this.army = new ArmyThread(timeArmy.Text);

                this.timeArmy.Width = 50;
                this.timeArmy.Left = 10;
                this.timeArmy.Top = 10 + j * 25;
                this.timeArmy.Mask = "00:00:00";
                //this.timeArmy.PromptChar = '0';
                this.timeArmy.Tag = Convert.ToString(j);
                //this.timeArmy.Leave += new EventHandler(maskedTextBox1_Leave);
                for (int i = 1; i < 7; i++)
                {
                    this.cardArmy.Items.Add("X" + i);
                }
                this.cardArmy.SelectedIndex = 0;
                this.cardArmy.Width = 40;
                this.cardArmy.Left = 70;
                this.cardArmy.Top = 10 + j * 25;
                this.cardArmy.Tag = Convert.ToString(j);

                this.commentArmy.Width = 100;
                this.commentArmy.Left = 120;
                this.commentArmy.Top = 10 + j * 25;
                this.commentArmy.Tag = Convert.ToString(j);

            }
        }



        private void startTimer_Click(object sender, EventArgs e)
        {
            
            //timerForm.Show();
            //Label[] timeLabels = new Label[packetsCount];

            if (!startedTime)
            {
                if (packets[0].timeArmy.Text == "  :  :") { MessageBox.Show("Set at least time."); return; }
                startTimer.Text = "Stop";
                timerForm.Show();
                startedTime = true;
                //float currentSize;
                //foreach (TimingPacket value in packets)
                Label[] timeLabels = new Label[packetsCount - 1];
                Label[] commentLabels = new Label[packetsCount - 1];
                ControllerArmyWaves controllerTimer = new ControllerArmyWaves();
                //controllerTimer = 
                controller.Copy(controllerTimer);
                timerForm.SetController(controllerTimer);
                controllerTimer.waveCount = packetsCount;
                //controllerTimer.TimerStart();
                //TimingPacket[] packetsTemp = new TimingPacket[10];
                //packets.CopyTo(packetsTemp, 0);
                for (int i = 0; i < packetsCount - 1; i++)
                {
                    for (int j = 0; j < packetsCount - i - 2; j++)
                    {
                        if (controllerTimer.GetTimeWave(j) < controllerTimer.GetTimeWave(j+1))
                        {
                            Wave temp = controllerTimer.GetWaveObj(j);
                            Wave temp2 = controllerTimer.GetWaveObj(j+1);
                            controllerTimer.SetWave(j, controllerTimer.GetWaveObj(j + 1));
                            controllerTimer.SetWave(j + 1, temp);
                            //TimingPacket temp = packetsTemp[j];
                            //packetsTemp[j] = packetsTemp[j + 1];
                            //packetsTemp[j + 1] = temp;
                            //                            ArmyWave temp = armyWaves[j];
                            //                            armyWaves[j] = armyWaves[j + 1];
                            //                            armyWaves[j + 1] = temp;
                        }
                    }
                }

                for (int i = 0; i < packetsCount - 1; i++)
                {
                    timeLabels[i] = new Label();
                    timeLabels[i].Name = "time";
                    timerForm.Controls.Add(timeLabels[i]);// = value.army.CardTime; 
                    timeLabels[i].Location = new Point(10, i * 25 + 10);
                    timeLabels[i].Size = new Size(50, 15);

                    commentLabels[i] = new Label();
                    commentLabels[i].Name = "comment";
                    timerForm.Controls.Add(commentLabels[i]);// = value.army.CardTime; 
                    commentLabels[i].Location = new Point(70, i * 25 + 10);
                    
                    //labels[i].Text = "count - "+i;
                    //labels[i].Text = packets[i].timeArmy.Text;
                    //listBox1.SelectedIndex = i;
                    //labels[i].Text = listBox1.SelectedItem.ToString();
                    //DateTime timeTo = Convert.ToDateTime("01:00:00");
                    DateTime timeTo = controllerTimer.GetTimeWave(0).AddSeconds(15);// + Convert.ToDateTime("00:00:15");
                    //labels[i].Text = controllerTimer.GetWave(i);
                    timeLabels[i].Text = Convert.ToString(timeTo - controllerTimer.GetTimeWave(i));
                    commentLabels[i].Text = Convert.ToString(controllerTimer.GetWave(i));
                    //currentSize = labels[i].Font.Size;
                    //currentSize = 15.0F;
                    //labels[i].Font = new Font(labels[i].Font.Name, currentSize,
                    //labels[i].Font.Style, labels[i].Font.Unit);
                }
            }
            else if (startedTime)
            {
                startTimer.Text = "Start";
                timerForm.StopTimer();
                timerForm.Hide();
                timerForm.Controls.Clear();
                //timerForm.Close();
                startedTime = false;
                
            }
        }
    }
}
