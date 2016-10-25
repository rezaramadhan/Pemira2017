using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PemiraServer
{
    public partial class MainForm : Form
    {
        private TimerCountdown time1;
        private TimerCountdown time2;
        private string tag1 = "1";
        private string tag2 = "2";
        private bool[] isTwice;
        private const int MAXWAITING = 2;

        public MainForm()
        {
            isTwice = new bool[2];
            InitializeComponent();
            InitializeListView();
            time1 = new TimerCountdown(tag1);
            time1.Tick += new EventHandler(time_Tick);

            time2 = new TimerCountdown(tag2);
            time2.Tick += new EventHandler(time_Tick);


            
        }



        private void time_Tick(object sender, EventArgs e)
        {
            TimerCountdown t = sender as TimerCountdown;
            Label lTimer;
            Button bGrant;
            ListView listNIM;
            int idx;
            if (t.Tag.ToString() == tag1) {
                lTimer = labelTimerBilik1;
                idx = 0;
                bGrant = buttonGrant1;
                listNIM = listViewBilik1;
            } else {
                idx = 1;
                bGrant = buttonGrant1;
                lTimer = labelTimerBilik2;
                listNIM = listViewBilik2;
            }


            t.counter--;
            int count = t.counter;
            lTimer.Text = count.ToString();

            if (count < 0 && isTwice[idx]) {
                t.counter = t.MAXCOUNT;
                count = t.counter;
                isTwice[idx] = false;
            }

            if (count < 0) { //stop
                bGrant.Enabled = true;
                t.counter = t.MAXCOUNT;
                t.Stop();

                lTimer.Text = t.MAXCOUNT.ToString();

                listNIM.Items.RemoveAt(0);
                if (listViewWaiting.Items.Count > 0) {
                    string s = listViewWaiting.Items[0].Text;
                    listNIM.Items.Add(s);
                    listViewWaiting.Items.RemoveAt(0);
                }
            }
        }

        private void addToWaiting()
        {
            string s = textBoxNIM.Text;

            if (s != "") {
                int countBilik1 = listViewBilik1.Items.Count;
                int countBilik2 = listViewBilik2.Items.Count;
                if (countBilik2 < MAXWAITING) {
                    if (countBilik1 == 0) {
                        listViewBilik1.Items.Add(s);
                    } else {
                        listViewBilik2.Items.Add(s);
                    }
                } else if (countBilik1 < MAXWAITING) {
                    if (countBilik2 == 0) {
                        listViewBilik2.Items.Add(s);
                    } else {
                        listViewBilik1.Items.Add(s);
                    }
                } else {
                    listViewWaiting.Items.Add(s);
                }
            }
            textBoxNIM.Text = "";
        }

        private void buttonSubmitNIM_Click(object sender, EventArgs e)
        {
            addToWaiting();
        }

        private void enter_pressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addToWaiting();
            }
        }

        private void buttonGrant_Click(object sender, EventArgs e)
        {
            Button source = sender as Button;
            TimerCountdown t;
            ListView listNIM;
            int idx;
            if (source.Name == "buttonGrant1") {
                t = time1;
                listNIM = listViewBilik1;
                idx = 0;
            } else {
                t = time2;
                listNIM = listViewBilik2;
                idx = 1;
            }

            if (listNIM.Items.Count > 0) { //sukses
                isTwice[idx] = listNIM.Items[0].Text[0] == '1';
                source.Enabled = false;
                t.Start();
            } else { //gagal
                MessageBox.Show("Tidak ada NIM pada antrian!");
            }
            
        }

        private void button1_Click(object sender, EventArgs e) {
            SocketClient client = new SocketClient("127.0.0.1", 4949);
            client.connect();
            
            client.send("Hello");

            client.disconnect();
        }
    }
}
