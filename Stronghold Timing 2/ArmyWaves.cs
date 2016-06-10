using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Stronghold_Timing_2
{
    public class ArmyWaves
    {
        public Wave[] waves = new Wave[10];
        

        public ArmyWaves()
        { }

        public void CopyTo(Wave[] wavesNew)
        {
            //Wave[] waves1 = new Wave[10];
            waves.CopyTo(wavesNew,0);
        }

        public void SetWave(int i, string time, int card, string comment)
        {
            waves[i] = new Wave(time, card, comment);
        }

        public void SetWaveTime(int i, TimeSpan time)
        {
            waves[i] = new Wave(Convert.ToString(time), waves[i].card, waves[i].comment);
        }

        public void SetWave(int i, Wave wave)
        {
            waves[i] = wave;
        }

        
    }
}
