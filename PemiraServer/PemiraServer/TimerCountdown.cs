using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PemiraServer
{
    class TimerCountdown : Timer
    {
        private int jarak = 1000;
        public int MAXCOUNT = 10;
        public Boolean isSarjana = true;
        public int counter;

        public TimerCountdown(string s)
        {
            this.Tag = s;
            this.Interval = jarak;
            counter = MAXCOUNT;
        }
    }
}
