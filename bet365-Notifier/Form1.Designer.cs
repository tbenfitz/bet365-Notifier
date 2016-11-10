namespace bet365_Notifier
{
    partial class frmBet365
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
            this.btnBeginReporting = new System.Windows.Forms.Button();
            this.btnStopReporting = new System.Windows.Forms.Button();
            this.numericUpDownMatchTimeNotificationMins = new System.Windows.Forms.NumericUpDown();
            this.lblMatchTimeNotification = new System.Windows.Forms.Label();
            this.numericUpDownNumberGoals = new System.Windows.Forms.NumericUpDown();
            this.lblNumberGoals = new System.Windows.Forms.Label();
            this.numericUpDownMatchTimeNotificationSecs = new System.Windows.Forms.NumericUpDown();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtBoxPhone = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetTelegramCode = new System.Windows.Forms.Button();
            this.lblTelegramCode = new System.Windows.Forms.Label();
            this.txtBoxTelegramCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMatchTimeNotificationMins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberGoals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMatchTimeNotificationSecs)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBeginReporting
            // 
            this.btnBeginReporting.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBeginReporting.Location = new System.Drawing.Point(12, 282);
            this.btnBeginReporting.Name = "btnBeginReporting";
            this.btnBeginReporting.Size = new System.Drawing.Size(288, 44);
            this.btnBeginReporting.TabIndex = 40;
            this.btnBeginReporting.Text = "Begin Reporting";
            this.btnBeginReporting.UseVisualStyleBackColor = true;
            this.btnBeginReporting.Click += new System.EventHandler(this.btnBeginReporting_Click);
            // 
            // btnStopReporting
            // 
            this.btnStopReporting.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopReporting.Location = new System.Drawing.Point(12, 332);
            this.btnStopReporting.Name = "btnStopReporting";
            this.btnStopReporting.Size = new System.Drawing.Size(288, 44);
            this.btnStopReporting.TabIndex = 45;
            this.btnStopReporting.Text = "Stop Reporting";
            this.btnStopReporting.UseVisualStyleBackColor = true;
            this.btnStopReporting.Click += new System.EventHandler(this.btnStopReporting_Click);
            // 
            // numericUpDownMatchTimeNotificationMins
            // 
            this.numericUpDownMatchTimeNotificationMins.Location = new System.Drawing.Point(204, 214);
            this.numericUpDownMatchTimeNotificationMins.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownMatchTimeNotificationMins.Name = "numericUpDownMatchTimeNotificationMins";
            this.numericUpDownMatchTimeNotificationMins.Size = new System.Drawing.Size(43, 22);
            this.numericUpDownMatchTimeNotificationMins.TabIndex = 5;
            this.numericUpDownMatchTimeNotificationMins.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // lblMatchTimeNotification
            // 
            this.lblMatchTimeNotification.AutoSize = true;
            this.lblMatchTimeNotification.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatchTimeNotification.Location = new System.Drawing.Point(8, 214);
            this.lblMatchTimeNotification.Name = "lblMatchTimeNotification";
            this.lblMatchTimeNotification.Size = new System.Drawing.Size(186, 20);
            this.lblMatchTimeNotification.TabIndex = 4;
            this.lblMatchTimeNotification.Text = "Match Time Notification";
            // 
            // numericUpDownNumberGoals
            // 
            this.numericUpDownNumberGoals.Location = new System.Drawing.Point(204, 181);
            this.numericUpDownNumberGoals.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownNumberGoals.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNumberGoals.Name = "numericUpDownNumberGoals";
            this.numericUpDownNumberGoals.Size = new System.Drawing.Size(92, 22);
            this.numericUpDownNumberGoals.TabIndex = 1;
            this.numericUpDownNumberGoals.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // lblNumberGoals
            // 
            this.lblNumberGoals.AutoSize = true;
            this.lblNumberGoals.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberGoals.Location = new System.Drawing.Point(8, 180);
            this.lblNumberGoals.Name = "lblNumberGoals";
            this.lblNumberGoals.Size = new System.Drawing.Size(136, 20);
            this.lblNumberGoals.TabIndex = 6;
            this.lblNumberGoals.Text = "Number of Goals";
            // 
            // numericUpDownMatchTimeNotificationSecs
            // 
            this.numericUpDownMatchTimeNotificationSecs.Location = new System.Drawing.Point(253, 214);
            this.numericUpDownMatchTimeNotificationSecs.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDownMatchTimeNotificationSecs.Name = "numericUpDownMatchTimeNotificationSecs";
            this.numericUpDownMatchTimeNotificationSecs.Size = new System.Drawing.Size(43, 22);
            this.numericUpDownMatchTimeNotificationSecs.TabIndex = 10;
            this.numericUpDownMatchTimeNotificationSecs.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(65, 249);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(231, 22);
            this.textBoxEmail.TabIndex = 35;
            this.textBoxEmail.TextChanged += new System.EventHandler(this.textBoxEmail_TextChanged);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(8, 249);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(51, 20);
            this.lblEmail.TabIndex = 15;
            this.lblEmail.Text = "Email";
            // 
            // txtBoxPhone
            // 
            this.txtBoxPhone.Location = new System.Drawing.Point(65, 12);
            this.txtBoxPhone.Name = "txtBoxPhone";
            this.txtBoxPhone.Size = new System.Drawing.Size(231, 22);
            this.txtBoxPhone.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 46;
            this.label1.Text = "Phone";
            // 
            // btnGetTelegramCode
            // 
            this.btnGetTelegramCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetTelegramCode.Location = new System.Drawing.Point(12, 68);
            this.btnGetTelegramCode.Name = "btnGetTelegramCode";
            this.btnGetTelegramCode.Size = new System.Drawing.Size(288, 44);
            this.btnGetTelegramCode.TabIndex = 48;
            this.btnGetTelegramCode.Text = "Get Telegram Code";
            this.btnGetTelegramCode.UseVisualStyleBackColor = true;
            this.btnGetTelegramCode.Click += new System.EventHandler(this.btnGetTelegramCode_Click);
            // 
            // lblTelegramCode
            // 
            this.lblTelegramCode.AutoSize = true;
            this.lblTelegramCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelegramCode.Location = new System.Drawing.Point(123, 259);
            this.lblTelegramCode.Name = "lblTelegramCode";
            this.lblTelegramCode.Size = new System.Drawing.Size(0, 20);
            this.lblTelegramCode.TabIndex = 49;
            // 
            // txtBoxTelegramCode
            // 
            this.txtBoxTelegramCode.Location = new System.Drawing.Point(108, 128);
            this.txtBoxTelegramCode.Name = "txtBoxTelegramCode";
            this.txtBoxTelegramCode.Size = new System.Drawing.Size(192, 22);
            this.txtBoxTelegramCode.TabIndex = 50;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 51;
            this.label2.Text = "Enter Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(62, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 17);
            this.label3.TabIndex = 52;
            this.label3.Text = "(country code and number)";
            // 
            // frmBet365
            // 
            this.AcceptButton = this.btnBeginReporting;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(312, 396);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxTelegramCode);
            this.Controls.Add(this.lblTelegramCode);
            this.Controls.Add(this.btnGetTelegramCode);
            this.Controls.Add(this.txtBoxPhone);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.numericUpDownMatchTimeNotificationSecs);
            this.Controls.Add(this.numericUpDownNumberGoals);
            this.Controls.Add(this.lblNumberGoals);
            this.Controls.Add(this.numericUpDownMatchTimeNotificationMins);
            this.Controls.Add(this.lblMatchTimeNotification);
            this.Controls.Add(this.btnStopReporting);
            this.Controls.Add(this.btnBeginReporting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmBet365";
            this.Text = "bet365";
            this.Load += new System.EventHandler(this.frmBet365_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMatchTimeNotificationMins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberGoals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMatchTimeNotificationSecs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBeginReporting;
        private System.Windows.Forms.Button btnStopReporting;
        private System.Windows.Forms.NumericUpDown numericUpDownMatchTimeNotificationMins;
        private System.Windows.Forms.Label lblMatchTimeNotification;
        private System.Windows.Forms.NumericUpDown numericUpDownNumberGoals;
        private System.Windows.Forms.Label lblNumberGoals;
        private System.Windows.Forms.NumericUpDown numericUpDownMatchTimeNotificationSecs;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtBoxPhone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetTelegramCode;
        private System.Windows.Forms.Label lblTelegramCode;
        private System.Windows.Forms.TextBox txtBoxTelegramCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

