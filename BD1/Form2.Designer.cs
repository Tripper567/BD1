
namespace BD1
{
    partial class Form2
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
            this.textBoxServ = new System.Windows.Forms.TextBox();
            this.textBoxSec = new System.Windows.Forms.TextBox();
            this.textBoxDB = new System.Windows.Forms.TextBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxServ
            // 
            this.textBoxServ.Location = new System.Drawing.Point(12, 12);
            this.textBoxServ.Name = "textBoxServ";
            this.textBoxServ.Size = new System.Drawing.Size(100, 20);
            this.textBoxServ.TabIndex = 0;
            // 
            // textBoxSec
            // 
            this.textBoxSec.Location = new System.Drawing.Point(12, 38);
            this.textBoxSec.Name = "textBoxSec";
            this.textBoxSec.Size = new System.Drawing.Size(100, 20);
            this.textBoxSec.TabIndex = 1;
            // 
            // textBoxDB
            // 
            this.textBoxDB.Location = new System.Drawing.Point(12, 64);
            this.textBoxDB.Name = "textBoxDB";
            this.textBoxDB.Size = new System.Drawing.Size(100, 20);
            this.textBoxDB.TabIndex = 2;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(713, 415);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(75, 23);
            this.buttonLogin.TabIndex = 3;
            this.buttonLogin.Text = "button1";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.textBoxDB);
            this.Controls.Add(this.textBoxSec);
            this.Controls.Add(this.textBoxServ);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxServ;
        private System.Windows.Forms.TextBox textBoxSec;
        private System.Windows.Forms.TextBox textBoxDB;
        private System.Windows.Forms.Button buttonLogin;
    }
}