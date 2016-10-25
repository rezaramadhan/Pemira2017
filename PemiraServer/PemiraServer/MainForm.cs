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

        public MainForm()
        {
            InitializeComponent();
            time1 = new TimerCountdown(tag1);
            time1.Tick += new EventHandler(time_Tick);

            time2 = new TimerCountdown(tag2);
            time2.Tick += new EventHandler(time_Tick);


            ColumnHeader header = new ColumnHeader();
            header.Text = "";
            header.Name = "dummy";
            header.Width = listViewWaiting.Width - 25;
            listViewWaiting.Columns.Add(header);
            listViewWaiting.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;


        }

        private void time_Tick(object sender, EventArgs e)
        {
            TimerCountdown t = sender as TimerCountdown;
            t.counter--;

            if (t.counter <= 0 && t.isSarjana) {//kasus dia milih K3M
                t.counter = t.MAXCOUNT;
                MessageBox.Show("heh");
            }

            if (t.Tag.ToString() == tag1) {
                labelTimerBilik1.Text = t.counter.ToString();
            } else if (t.Tag.ToString() == tag2) {
                labelTimerBilik2.Text = t.counter.ToString();
            }

            if (t.counter > 0) {
                
            } else { 
                t.Stop();
                t.counter = t.MAXCOUNT;
                if (t.Tag.ToString() == tag1) {
                    buttonGrant1.Enabled = true;
                } else if (t.Tag.ToString() == tag2) {
                    buttonGrant1.Enabled = true;
                }
            }
        }

        private void addToWaiting()
        {
            string s = textBoxNIM.Text;

            if (s != "") {
                listViewWaiting.Items.Add(s);

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

        private void buttonGrant1_Click(object sender, EventArgs e)
        {
            time1.Start();
            time1.isSarjana = labelBilikNIM1.Text[0] == '1';
            
            if (time1.isSarjana) {
                MessageBox.Show("hello");
            }
            buttonGrant1.Enabled = false;
        }

        private void buttonGrant2_Click(object sender, EventArgs e)
        {
            time2.Start();
        }
    }
}
