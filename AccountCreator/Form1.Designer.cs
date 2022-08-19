namespace AccountCreator
{
    partial class Form1
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
            this.btnStart = new System.Windows.Forms.Button();
            this.lblPath = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.chBoxReddit = new System.Windows.Forms.CheckBox();
            this.chBoxMail = new System.Windows.Forms.CheckBox();
            this.chBoxGMail = new System.Windows.Forms.CheckBox();
            this.rTxtLog = new System.Windows.Forms.RichTextBox();
            this.lblInjectState = new System.Windows.Forms.Label();
            this.lblInjectStatus = new System.Windows.Forms.Label();
            this.lblNbOfAcc = new System.Windows.Forms.Label();
            this.txtNbAcc = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(385, 279);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(12, 9);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(32, 13);
            this.lblPath.TabIndex = 1;
            this.lblPath.Text = "Path:";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(15, 26);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(282, 20);
            this.txtPath.TabIndex = 2;
            // 
            // chBoxReddit
            // 
            this.chBoxReddit.AutoSize = true;
            this.chBoxReddit.Location = new System.Drawing.Point(15, 63);
            this.chBoxReddit.Name = "chBoxReddit";
            this.chBoxReddit.Size = new System.Drawing.Size(57, 17);
            this.chBoxReddit.TabIndex = 3;
            this.chBoxReddit.Text = "Reddit";
            this.chBoxReddit.UseVisualStyleBackColor = true;
            this.chBoxReddit.CheckedChanged += new System.EventHandler(this.chBoxReddit_CheckedChanged);
            // 
            // chBoxMail
            // 
            this.chBoxMail.AutoSize = true;
            this.chBoxMail.Location = new System.Drawing.Point(78, 63);
            this.chBoxMail.Name = "chBoxMail";
            this.chBoxMail.Size = new System.Drawing.Size(68, 17);
            this.chBoxMail.TabIndex = 4;
            this.chBoxMail.Text = "Mail.com";
            this.chBoxMail.UseVisualStyleBackColor = true;
            this.chBoxMail.CheckedChanged += new System.EventHandler(this.chBoxMail_CheckedChanged);
            // 
            // chBoxGMail
            // 
            this.chBoxGMail.AutoSize = true;
            this.chBoxGMail.Location = new System.Drawing.Point(152, 63);
            this.chBoxGMail.Name = "chBoxGMail";
            this.chBoxGMail.Size = new System.Drawing.Size(53, 17);
            this.chBoxGMail.TabIndex = 5;
            this.chBoxGMail.Text = "GMail";
            this.chBoxGMail.UseVisualStyleBackColor = true;
            this.chBoxGMail.CheckedChanged += new System.EventHandler(this.chBoxGMail_CheckedChanged);
            // 
            // rTxtLog
            // 
            this.rTxtLog.Location = new System.Drawing.Point(16, 86);
            this.rTxtLog.Name = "rTxtLog";
            this.rTxtLog.Size = new System.Drawing.Size(444, 187);
            this.rTxtLog.TabIndex = 6;
            this.rTxtLog.Text = "";
            // 
            // lblInjectState
            // 
            this.lblInjectState.AutoSize = true;
            this.lblInjectState.Location = new System.Drawing.Point(13, 284);
            this.lblInjectState.Name = "lblInjectState";
            this.lblInjectState.Size = new System.Drawing.Size(81, 13);
            this.lblInjectState.TabIndex = 7;
            this.lblInjectState.Text = "Injection status:";
            // 
            // lblInjectStatus
            // 
            this.lblInjectStatus.AutoSize = true;
            this.lblInjectStatus.Location = new System.Drawing.Point(100, 284);
            this.lblInjectStatus.Name = "lblInjectStatus";
            this.lblInjectStatus.Size = new System.Drawing.Size(41, 13);
            this.lblInjectStatus.TabIndex = 8;
            this.lblInjectStatus.Text = "succes";
            // 
            // lblNbOfAcc
            // 
            this.lblNbOfAcc.AutoSize = true;
            this.lblNbOfAcc.Location = new System.Drawing.Point(330, 29);
            this.lblNbOfAcc.Name = "lblNbOfAcc";
            this.lblNbOfAcc.Size = new System.Drawing.Size(72, 13);
            this.lblNbOfAcc.TabIndex = 9;
            this.lblNbOfAcc.Text = "req. accounts";
            // 
            // txtNbAcc
            // 
            this.txtNbAcc.Location = new System.Drawing.Point(408, 26);
            this.txtNbAcc.Name = "txtNbAcc";
            this.txtNbAcc.Size = new System.Drawing.Size(51, 20);
            this.txtNbAcc.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 309);
            this.Controls.Add(this.txtNbAcc);
            this.Controls.Add(this.lblNbOfAcc);
            this.Controls.Add(this.lblInjectStatus);
            this.Controls.Add(this.lblInjectState);
            this.Controls.Add(this.rTxtLog);
            this.Controls.Add(this.chBoxGMail);
            this.Controls.Add(this.chBoxMail);
            this.Controls.Add(this.chBoxReddit);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "AccountCreator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnStart;
        public System.Windows.Forms.Label lblPath;
        public System.Windows.Forms.CheckBox chBoxReddit;
        public System.Windows.Forms.CheckBox chBoxMail;
        public System.Windows.Forms.CheckBox chBoxGMail;
        public System.Windows.Forms.RichTextBox rTxtLog;
        public System.Windows.Forms.Label lblInjectState;
        public System.Windows.Forms.Label lblInjectStatus;
        private System.Windows.Forms.Label lblNbOfAcc;
        public System.Windows.Forms.TextBox txtPath;
        public System.Windows.Forms.TextBox txtNbAcc;
    }
}

