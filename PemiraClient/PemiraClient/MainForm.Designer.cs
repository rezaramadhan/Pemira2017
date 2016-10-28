namespace PemiraClient
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
            this.labelSelamatDatang = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelNIM = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSelamatDatang
            // 
            this.labelSelamatDatang.BackColor = System.Drawing.Color.Transparent;
            this.labelSelamatDatang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSelamatDatang.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelamatDatang.ForeColor = System.Drawing.Color.Snow;
            this.labelSelamatDatang.Location = new System.Drawing.Point(0, 0);
            this.labelSelamatDatang.Name = "labelSelamatDatang";
            this.labelSelamatDatang.Size = new System.Drawing.Size(457, 63);
            this.labelSelamatDatang.TabIndex = 0;
            this.labelSelamatDatang.Text = "Selamat Datang !";
            this.labelSelamatDatang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelSelamatDatang.UseMnemonic = false;
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.labelSelamatDatang);
            this.panel1.Location = new System.Drawing.Point(176, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(461, 67);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.labelNIM);
            this.panel2.Location = new System.Drawing.Point(176, 120);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(459, 80);
            this.panel2.TabIndex = 2;
            // 
            // labelNIM
            // 
            this.labelNIM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelNIM.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNIM.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelNIM.Location = new System.Drawing.Point(0, 0);
            this.labelNIM.Name = "labelNIM";
            this.labelNIM.Size = new System.Drawing.Size(455, 76);
            this.labelNIM.TabIndex = 0;
            this.labelNIM.Text = "Hubungi operator untuk memilih";
            this.labelNIM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(402, 234);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(35, 13);
            this.labelStatus.TabIndex = 3;
            this.labelStatus.Text = "label1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 326);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSelamatDatang;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelNIM;
        private System.Windows.Forms.Label labelStatus;
    }
}

