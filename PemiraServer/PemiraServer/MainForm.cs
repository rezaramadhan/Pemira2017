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
        public MainForm()
        {
            InitializeComponent();
            TreeNode newNode = new TreeNode("Text for new node");
        }

        private void addToWaiting(string s)
        {
            if (s!= "")
                listViewWaiting.Items.Add(s);
        }

        private void buttonSubmitNIM_Click(object sender, EventArgs e)
        {
            string s = textBoxNIM.Text;
            addToWaiting(s);
            textBoxNIM.Text = "";
        }

        private void enter_pressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string s = textBoxNIM.Text;
                addToWaiting(s);
                textBoxNIM.Text = "";

            }
        } 
    }
}
