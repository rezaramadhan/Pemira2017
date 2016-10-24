namespace PemiraServer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelNIM = new System.Windows.Forms.Label();
            this.textBoxNIM = new System.Windows.Forms.TextBox();
            this.buttonSubmitNIM = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonGrant1 = new System.Windows.Forms.Button();
            this.buttonGrant2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.labelTimerBilik1 = new System.Windows.Forms.Label();
            this.labelBilikNIM2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.labelTimerBilik2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.listViewWaiting = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelNIM
            // 
            this.labelNIM.AutoSize = true;
            this.labelNIM.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNIM.Location = new System.Drawing.Point(119, 42);
            this.labelNIM.Name = "labelNIM";
            this.labelNIM.Size = new System.Drawing.Size(72, 31);
            this.labelNIM.TabIndex = 0;
            this.labelNIM.Text = "NIM:";
            // 
            // textBoxNIM
            // 
            this.textBoxNIM.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNIM.Location = new System.Drawing.Point(197, 39);
            this.textBoxNIM.Name = "textBoxNIM";
            this.textBoxNIM.Size = new System.Drawing.Size(296, 38);
            this.textBoxNIM.TabIndex = 1;
            this.textBoxNIM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_pressed);
            // 
            // buttonSubmitNIM
            // 
            this.buttonSubmitNIM.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSubmitNIM.Location = new System.Drawing.Point(499, 39);
            this.buttonSubmitNIM.Name = "buttonSubmitNIM";
            this.buttonSubmitNIM.Size = new System.Drawing.Size(111, 38);
            this.buttonSubmitNIM.TabIndex = 2;
            this.buttonSubmitNIM.Text = "Submit";
            this.buttonSubmitNIM.UseVisualStyleBackColor = true;
            this.buttonSubmitNIM.Click += new System.EventHandler(this.buttonSubmitNIM_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::PemiraServer.Properties.Resources.Logo_Pemira_KM_ITB1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(665, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(68, 92);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // buttonGrant1
            // 
            this.buttonGrant1.Location = new System.Drawing.Point(130, -1);
            this.buttonGrant1.Name = "buttonGrant1";
            this.buttonGrant1.Size = new System.Drawing.Size(101, 30);
            this.buttonGrant1.TabIndex = 4;
            this.buttonGrant1.Text = "Grant Access";
            this.buttonGrant1.UseVisualStyleBackColor = true;
            this.buttonGrant1.Click += new System.EventHandler(this.buttonGrant1_Click);
            // 
            // buttonGrant2
            // 
            this.buttonGrant2.Location = new System.Drawing.Point(130, -1);
            this.buttonGrant2.Name = "buttonGrant2";
            this.buttonGrant2.Size = new System.Drawing.Size(101, 30);
            this.buttonGrant2.TabIndex = 5;
            this.buttonGrant2.Text = "Grant Access";
            this.buttonGrant2.UseVisualStyleBackColor = true;
            this.buttonGrant2.Click += new System.EventHandler(this.buttonGrant2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(90, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Bilik 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(88, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Bilik 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "Waiting List";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.labelTimerBilik1);
            this.panel1.Controls.Add(this.labelBilikNIM2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonGrant1);
            this.panel1.Location = new System.Drawing.Point(261, 168);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 253);
            this.panel1.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(152, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "time 2";
            // 
            // labelTimerBilik1
            // 
            this.labelTimerBilik1.AutoSize = true;
            this.labelTimerBilik1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimerBilik1.Location = new System.Drawing.Point(152, 91);
            this.labelTimerBilik1.Name = "labelTimerBilik1";
            this.labelTimerBilik1.Size = new System.Drawing.Size(52, 20);
            this.labelTimerBilik1.TabIndex = 9;
            this.labelTimerBilik1.Text = "time 1";
            // 
            // labelBilikNIM2
            // 
            this.labelBilikNIM2.AutoSize = true;
            this.labelBilikNIM2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBilikNIM2.Location = new System.Drawing.Point(25, 123);
            this.labelBilikNIM2.Name = "labelBilikNIM2";
            this.labelBilikNIM2.Size = new System.Drawing.Size(51, 20);
            this.labelBilikNIM2.TabIndex = 8;
            this.labelBilikNIM2.Text = "NIM 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "NIM 1";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.labelTimerBilik2);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.buttonGrant2);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Location = new System.Drawing.Point(499, 168);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(232, 253);
            this.panel2.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(149, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "time 2";
            // 
            // labelTimerBilik2
            // 
            this.labelTimerBilik2.AutoSize = true;
            this.labelTimerBilik2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimerBilik2.Location = new System.Drawing.Point(149, 91);
            this.labelTimerBilik2.Name = "labelTimerBilik2";
            this.labelTimerBilik2.Size = new System.Drawing.Size(52, 20);
            this.labelTimerBilik2.TabIndex = 13;
            this.labelTimerBilik2.Text = "time 1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(22, 123);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 20);
            this.label10.TabIndex = 12;
            this.label10.Text = "NIM 2";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(22, 91);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 20);
            this.label11.TabIndex = 11;
            this.label11.Text = "NIM 1";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.listViewWaiting);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(23, 168);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(232, 253);
            this.panel3.TabIndex = 10;
            // 
            // listViewWaiting
            // 
            this.listViewWaiting.BackColor = System.Drawing.SystemColors.Control;
            this.listViewWaiting.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewWaiting.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewWaiting.Location = new System.Drawing.Point(17, 46);
            this.listViewWaiting.Name = "listViewWaiting";
            this.listViewWaiting.Size = new System.Drawing.Size(195, 189);
            this.listViewWaiting.TabIndex = 11;
            this.listViewWaiting.UseCompatibleStateImageBehavior = false;
            this.listViewWaiting.View = System.Windows.Forms.View.Details;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 433);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonSubmitNIM);
            this.Controls.Add(this.textBoxNIM);
            this.Controls.Add(this.labelNIM);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNIM;
        private System.Windows.Forms.TextBox textBoxNIM;
        private System.Windows.Forms.Button buttonSubmitNIM;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonGrant1;
        private System.Windows.Forms.Button buttonGrant2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelTimerBilik1;
        private System.Windows.Forms.Label labelBilikNIM2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelTimerBilik2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListView listViewWaiting;
    }
}

