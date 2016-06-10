using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stronghold_Timing_2
{
    public class ControllerArmyWaves
    {
        public ArmyWaves armyWaves = new ArmyWaves();
        //public Timer timer1 = new Timer();
        public int waveCount=0;


        public ControllerArmyWaves temp()
        {
            return this;
        }
        //public ReturnMe()

        public ControllerArmyWaves()
        {

        }
        /*
                public ControllerArmyWaves CopyTo(ControllerArmyWaves temp)
                {
                    temp.armyWaves = this.armyWaves;
                    return temp;
                }
        */

        public void Copy(ControllerArmyWaves temp)
        {
            //ControllerArmyWaves temp = new ControllerArmyWaves();
            //temp = (ControllerArmyWaves)this.MemberwiseClone();
            //this.armyWaves.waves.CopyTo(temp.armyWaves.waves, 0);
            this.armyWaves.CopyTo(temp.armyWaves.waves);
            //return temp;
        }

        public void SortWaves()
        {

        }

        public void SetWave(int i, string time, int card, string comment)
        {
            armyWaves.SetWave(i, time, card, comment);
        }

        public void SetWave(int i, Wave wave)
        {
            armyWaves.SetWave(i, wave);
        }

        public string GetWave(int i)
        {
            return armyWaves.waves[i].timeCard + " " + armyWaves.waves[i].card.ToString() + " " + armyWaves.waves[i].comment;
        }

        public Wave GetWaveObj(int i)
        {
            return armyWaves.waves[i];
        }

        public DateTime GetTimeWave(int i)
        {
            return DateTime.Parse(armyWaves.waves[i].timeCard);
            
        }
/*
        public void TimerStart()
        {
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Enabled = true;
        }

        private void timer1_Tick(object Sender, EventArgs e)
        {
            for (int i =0; i < waveCount-1; i++)
            {
               
               armyWaves.SetWaveTime(i, GetTimeWave(i)-Convert.ToDateTime("00:00:01"));
            }
        }
*/
    }
}
