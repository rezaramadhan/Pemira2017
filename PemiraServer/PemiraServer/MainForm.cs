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
        private Timer time;
        private Timer time1;
        private int interval = 2000;
        
        public MainForm()
        {
            InitializeComponent();
            time = new Timer();
            time.Tick += new EventHandler(time_Tick);
            time.Interval = interval;
            time.Tag = "halo";

            time1 = new Timer();
            time1.Tick += new EventHandler(time_Tick);
            time1.Interval = interval;
            time1.Tag = "hello";

            ColumnHeader header = new ColumnHeader();
            header.Text = "";
            header.Name = "col1";
            header.Width = listViewWaiting.Width - 25;
            listViewWaiting.Columns.Add(header);
            listViewWaiting.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;

        }

        private void time_Tick(object sender, EventArgs e)
        {
            Timer t = sender as Timer;
            string s = t.Tag.ToString();
            MessageBox.Show(s);
        }

        private void addToWaiting()
        {
            string s = textBoxNIM.Text;

            if (s!= "")
                listViewWaiting.Items.Add(s);

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
            time.Start();
        }

        private void buttonGrant2_Click(object sender, EventArgs e)
        {
            time1.Start();
        }
    }
}
