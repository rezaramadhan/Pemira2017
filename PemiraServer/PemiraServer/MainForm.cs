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
        private ServerSocket[] sock;
        private TimerCountdown[] time;
        private string[] tag = { "1" , "2" };
        private bool[] isTwice;
        private const int MAXWAITING = 2;
        private string[] host = { "127.0.0.1", "127.0.0.1" };
        private int port = 13514;

        /*
            Constructors             
        */
        public MainForm()
        {
            InitializeComponent();
            InitializeListView();
            InitializeVariable();
        }

        /*
            Initialize all data member in this class            
        */
        private void InitializeVariable() {
            isTwice = new bool[MAXWAITING];
            time = new TimerCountdown[MAXWAITING];
            sock = new ServerSocket[MAXWAITING];

            for (int i = 0; i < MAXWAITING; i++) {
                tag[i] = (i + 1).ToString();
                time[i] = new TimerCountdown(tag[i]);
                time[i].Tick += new EventHandler(time_Tick);
                sock[i] = new ServerSocket(host[i], port);
            }
        }

       

        /*
            Function to add the content of textBoxNIM to waiting list            
        */
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

        /*
            Event handler when button submit clicked             
        */
        private void buttonSubmitNIM_Click(object sender, EventArgs e)
        {
            addToWaiting();
        }

        /*
            Event handler when enter pressed while typing textBoxNIM 
        */
        private void enter_pressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addToWaiting();
            }
        }

        /*
            Event handler when a buttonGrant is clicked             
        */
        private void buttonGrant_Click(object sender, EventArgs e)
        {
            Button source = sender as Button;
            TimerCountdown t;
            ListView listNIM;

            int idx;
            if (source.Name == "buttonGrant1") {
                listNIM = listViewBilik1;
                idx = 0;
            } else {
                listNIM = listViewBilik2;
                idx = 1;
            }

            if (listNIM.Items.Count > 0) { //sukses
                isTwice[idx] = listNIM.Items[0].Text[0] == '1';
                source.Enabled = false;
                time[idx].Start();

               sock[idx].connect();
            } else { //gagal
                MessageBox.Show("Tidak ada NIM pada antrian!");
            }
            
        }

        /*
           Event handler for when a timer ticks             
       */
        private void time_Tick(object sender, EventArgs e) {
            TimerCountdown t = sender as TimerCountdown;
            Label lTimer;
            Button bGrant;
            ListView listNIM;
            int idx;

            if (t.Tag.ToString() == tag[0]) {
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

            //sock[i].send();

            // Check if should choose K3M
            if (count <= 0 && isTwice[idx]) {
                t.counter = t.MAXCOUNT;
                count = t.counter;
                isTwice[idx] = false;
            }

            // Timer's empty, stop
            if (count < 0) {
                bGrant.Enabled = true;
                t.counter = t.MAXCOUNT;
                t.Stop();

                lTimer.Text = t.MAXCOUNT.ToString();

                listNIM.Items.RemoveAt(0);

                //sock[idx].disconnect();

                // Add from listWaiting to bilik
                if (listViewWaiting.Items.Count > 0) {
                    string s = listViewWaiting.Items[0].Text;
                    listNIM.Items.Add(s);
                    listViewWaiting.Items.RemoveAt(0);
                }
            }
        }


    }
}
