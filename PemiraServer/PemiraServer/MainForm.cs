using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
namespace PemiraServer
{
    public partial class MainForm : Form
    {
        private ServerSocket[] sock;
        private TimerCountdown[] time;
        private string[] tag = { "1" , "2" };
        private bool[] isTwice;
        private const int MAXWAITING = 2;
        private string[] host = { "169.254.1.1", "127.0.0.1" };
        private int port = 13514;
        private dbDPTController dbDpt = new dbDPTController();
        private dbQBilik1Controller dbQBilik1 = new dbQBilik1Controller();
        private dbQBilik2Controller dbQBilik2 = new dbQBilik2Controller();
        private dbWaitingListController dbWaitingList = new dbWaitingListController();
      
        /*
            Constructors             
        */
        public MainForm()
        {
            InitializeComponent();
            InitializeListView();
            InitializeVariable();
            //dbDpt.printDB();
            //dbQBilik1.printDB();
            //dbQBilik2.printDB();
            //dbWaitingList.printDB();
        }

        /*
            Initialize all data members in this class            
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
                    //DITAMBAHIN ALSON, semua addNimnya
                    if (countBilik1 == 0) {
                        dbQBilik1.addNim(s);
                        listViewBilik1.Items.Add(s);
                    } else {
                        dbQBilik2.addNim(s);
                        listViewBilik2.Items.Add(s);
                    }
                } else if (countBilik1 < MAXWAITING) {
                    if (countBilik2 == 0) {
                        dbQBilik2.addNim(s);
                        listViewBilik2.Items.Add(s);
                    } else {
                        dbQBilik1.addNim(s);
                        listViewBilik1.Items.Add(s);
                    }
                } else {
                    dbWaitingList.addNim(s);
                    listViewWaiting.Items.Add(s);
                }
            }
            textBoxNIM.Text = "";
        }

        private void STOP_VOTE(ListView listNIM, Button bGrant, TimerCountdown t, Label lTimer) {

            
            listNIM.Items.RemoveAt(0);
            // Add from listWaiting to bilik
            if (listViewWaiting.Items.Count > 0) {
                string s = listViewWaiting.Items[0].Text;
                listNIM.Items.Add(s);
                //DITAMBAHIN ALSON
                dbWaitingList.delNim(listViewWaiting.Items[0].Text);
                listViewWaiting.Items.RemoveAt(0);
            }

            bGrant.Enabled = true;
            t.Stop();
            t.reset();

            lTimer.Text = TimerCountdown.MAXCOUNT.ToString();
        }

        private void ACCEPT_VOTE(string[] args, int i) {
            //masukin pilihan ke database, masukin juga bahwa NIM x udah milih

            //ubah label waktu
            ListView listNIM;
            Button bGrant;
            Label lTimer;
            if (i == 0) {
                bGrant = buttonGrant1;
                lTimer = labelTimerBilik1;
                listNIM = listViewBilik1;
                labelTimerBilik1.Text = TimerCountdown.MAXCOUNT.ToString();
            } else {
                bGrant = buttonGrant2;
                lTimer = labelTimerBilik2;
                listNIM = listViewBilik2;
                labelTimerBilik2.Text = TimerCountdown.MAXCOUNT.ToString();    
            }

            
            if(!isTwice[i]) { //stop proses buat NIM x
                sock[i].disconnect();
                STOP_VOTE(listNIM, bGrant, time[i], lTimer);
            } else {
                //stop timer
                time[i].Stop();
                time[i].reset();
            }
        }

        private void START_VOTE(int i) {
            //start timer
            time[i].Start();
            isTwice[i] = false;
        }

        private void TCPrecv(Object i) {
            int idx = (int) i ;
            Action<string[], int> Delegate_AcceptVote = ACCEPT_VOTE;
            Action<int> Delegate_StartVote = START_VOTE;

            string s = "aa";
            while (s != "") {
                try {
                    s = sock[idx].recv();
                    //Debug.WriteLine("recieved" + s);
                    string[] listArg = s.Split(',');
                    if (listArg[0] == "K3M" || listArg[0] == "MWA") {
                        Invoke(Delegate_AcceptVote, listArg, idx);
                    } else if (listArg[0] == "ready") {
                        //Debug.WriteLine("READY");
                        Invoke(Delegate_StartVote, idx);
                    }
                } catch (IOException e) {
                    s = "";
                }
            }
        }

        /*
            Event handler when button submit clicked             
        */
        private void buttonSubmitNIM_Click(object sender, EventArgs e)
        {
            validasiNIM();
        }

        private void validasiNIM() {
            //DITAMBAHIN ALSON, tapi entah kenapa ga ngecek
            if (dbDpt.isExistInDB(textBoxNIM.Text)) {
                if (dbDpt.isAlreadyPickedMWAWM(textBoxNIM.Text)) {
                    if (dbQBilik1.isExistInDB(textBoxNIM.Text)) {
                        if (dbQBilik2.isExistInDB(textBoxNIM.Text)) {
                            if (dbWaitingList.isExistInDB(textBoxNIM.Text)) {
                                addToWaiting();
                            } else {
                                MessageBox.Show("Nim " + textBoxNIM.Text + " Sudah Ada di Waiting List!");
                            }
                        } else {
                            MessageBox.Show("Nim " + textBoxNIM.Text + " Sudah Ada di Bilik 2!");
                        }
                    } else {
                        MessageBox.Show("Nim " + textBoxNIM.Text + " Sudah Ada di Bilik 1!");
                    }
                } else {
                    MessageBox.Show("Nim " + textBoxNIM.Text + " Sudah Pernah Memilih!");
                }
            } else {
                MessageBox.Show("Nim " + textBoxNIM.Text + " Tidak Terdaftar di DPT!");
            }
        }

        /*
            Event handler when enter pressed while typing textBoxNIM 
        */
        private void enter_pressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                validasiNIM();
            }
        }
        
        /*
            Event handler when a buttonGrant is clicked             
        */
        private void buttonGrant_Click(object sender, EventArgs e)
        {
            Button source = sender as Button;
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
                Thread trd = new Thread(TCPrecv);
                trd.Start(idx);

                string NIM = listNIM.Items[0].Text;
                string data;
                if (isTwice[idx]) {
                    data = NIM + ",y";
                } else {
                    data = NIM + ",n";
                }
                sock[idx].send(data);
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
            string data;

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

            // Check if should choose K3M
            

            // Timer's empty, stop
            if (count <= 0) {
                if (isTwice[idx]) {
                    t.counter = TimerCountdown.MAXCOUNT;
                    sock[idx].send("({timeout})");
                    count = t.counter;
                    isTwice[idx] = false;
                    t.Stop();
                    t.reset();
                    //dbDpt.setChoiceKM(listNIM.Items.ToString(), "999");
                } else {
                    sock[idx].send("({timeout})");
                    sock[idx].disconnect();
                    //tandain NIM x udah vote di database

                    STOP_VOTE(listNIM, bGrant, t, lTimer);
                }
            } else {
                data = "({" + count.ToString() + "})";
                sock[idx].send(data);
            }
        }


    }
}
