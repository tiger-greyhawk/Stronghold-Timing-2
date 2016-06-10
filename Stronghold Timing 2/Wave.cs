using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stronghold_Timing_2
{
    public class Wave
    {
        public string time;
        public int card;
        public string comment;
        public string timeCard;

        public Wave(string time, int card, string comment)
        {
            if (time == "  :  :") time = "00:00:00";
            this.time = time;
            this.card = card;
            this.comment = comment;
            setCardTime(time, card);

        }

        private string setCardTime(string time, int x)
        {
            int hours;
            int minutes;
            int seconds;
            string[] tempTime = time.Split(':');
            if (tempTime[0] == "  ") tempTime[0] = "00";
            if (tempTime[1] == "  ") tempTime[1] = "00";
            if (tempTime[2] == "") tempTime[2] = "00";
            hours = Convert.ToInt32(tempTime[0]);
            minutes = Convert.ToInt32(tempTime[1]);
            seconds = Convert.ToInt32(tempTime[2]);
            int temp = hours * 3600 + minutes * 60 + seconds;
            int tempX = temp / x;
            int hoursX = tempX / 3600;
            int minutesX = (tempX % 3600) / 60;
            int secondsX = (tempX % 3600) % 60;
            this.timeCard = hoursX + ":" + minutesX + ":" + secondsX;
            return timeCard;
        }
    }
}
