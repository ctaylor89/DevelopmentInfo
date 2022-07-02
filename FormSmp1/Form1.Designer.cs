namespace FormSmp1
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
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.textBox2 = new System.Windows.Forms.TextBox();
         this.textBox3 = new System.Windows.Forms.TextBox();
         this.listBoxRes = new System.Windows.Forms.ListBox();
         this.btnInstallSvc = new System.Windows.Forms.Button();
         this.btnStartSvc = new System.Windows.Forms.Button();
         this.btnStopSvc = new System.Windows.Forms.Button();
         this.btnRemoveSvc = new System.Windows.Forms.Button();
         this.textBox4 = new System.Windows.Forms.TextBox();
         this.textBox5 = new System.Windows.Forms.TextBox();
         this.textBox6 = new System.Windows.Forms.TextBox();
         this.btnLaunchFileFrm = new System.Windows.Forms.Button();
         this.btnIsRunning = new System.Windows.Forms.Button();
         this.btnToExcel = new System.Windows.Forms.Button();
         this.groupBoxRS2100sqld = new System.Windows.Forms.GroupBox();
         this.groupBoxSQLServer = new System.Windows.Forms.GroupBox();
         this.label1 = new System.Windows.Forms.Label();
         this.tbConnectString = new System.Windows.Forms.TextBox();
         this.btnExecute = new System.Windows.Forms.Button();
         this.tbSqlResults = new System.Windows.Forms.TextBox();
         this.lblSqlServerResults = new System.Windows.Forms.Label();
         this.btnSendEmail = new System.Windows.Forms.Button();
         this.button1 = new System.Windows.Forms.Button();
         this.groupBoxRS2100sqld.SuspendLayout();
         this.groupBoxSQLServer.SuspendLayout();
         this.SuspendLayout();
         // 
         // textBox1
         // 
         this.textBox1.Location = new System.Drawing.Point(16, 15);
         this.textBox1.Name = "textBox1";
         this.textBox1.ReadOnly = true;
         this.textBox1.Size = new System.Drawing.Size(473, 20);
         this.textBox1.TabIndex = 0;
         this.textBox1.TabStop = false;
         // 
         // textBox2
         // 
         this.textBox2.Location = new System.Drawing.Point(468, 50);
         this.textBox2.Name = "textBox2";
         this.textBox2.Size = new System.Drawing.Size(100, 20);
         this.textBox2.TabIndex = 1;
         // 
         // textBox3
         // 
         this.textBox3.Location = new System.Drawing.Point(468, 91);
         this.textBox3.Name = "textBox3";
         this.textBox3.Size = new System.Drawing.Size(100, 20);
         this.textBox3.TabIndex = 2;
         // 
         // listBoxRes
         // 
         this.listBoxRes.FormattingEnabled = true;
         this.listBoxRes.Location = new System.Drawing.Point(139, 41);
         this.listBoxRes.Name = "listBoxRes";
         this.listBoxRes.Size = new System.Drawing.Size(313, 212);
         this.listBoxRes.TabIndex = 4;
         // 
         // btnInstallSvc
         // 
         this.btnInstallSvc.Location = new System.Drawing.Point(10, 23);
         this.btnInstallSvc.Name = "btnInstallSvc";
         this.btnInstallSvc.Size = new System.Drawing.Size(75, 23);
         this.btnInstallSvc.TabIndex = 5;
         this.btnInstallSvc.Text = "Install svc";
         this.btnInstallSvc.UseVisualStyleBackColor = true;
         this.btnInstallSvc.Click += new System.EventHandler(this.btnInstallSvc_Click);
         // 
         // btnStartSvc
         // 
         this.btnStartSvc.Location = new System.Drawing.Point(10, 49);
         this.btnStartSvc.Name = "btnStartSvc";
         this.btnStartSvc.Size = new System.Drawing.Size(75, 23);
         this.btnStartSvc.TabIndex = 6;
         this.btnStartSvc.Text = "Start svc";
         this.btnStartSvc.UseVisualStyleBackColor = true;
         this.btnStartSvc.Click += new System.EventHandler(this.btnStartSvc_Click);
         // 
         // btnStopSvc
         // 
         this.btnStopSvc.Location = new System.Drawing.Point(10, 79);
         this.btnStopSvc.Name = "btnStopSvc";
         this.btnStopSvc.Size = new System.Drawing.Size(75, 23);
         this.btnStopSvc.TabIndex = 7;
         this.btnStopSvc.Text = "Stop svc";
         this.btnStopSvc.UseVisualStyleBackColor = true;
         this.btnStopSvc.Click += new System.EventHandler(this.btnStopSvc_Click);
         // 
         // btnRemoveSvc
         // 
         this.btnRemoveSvc.Location = new System.Drawing.Point(106, 56);
         this.btnRemoveSvc.Name = "btnRemoveSvc";
         this.btnRemoveSvc.Size = new System.Drawing.Size(75, 23);
         this.btnRemoveSvc.TabIndex = 8;
         this.btnRemoveSvc.Text = "Remove svc";
         this.btnRemoveSvc.UseVisualStyleBackColor = true;
         this.btnRemoveSvc.Click += new System.EventHandler(this.btnRemoveSvc_Click);
         // 
         // textBox4
         // 
         this.textBox4.Location = new System.Drawing.Point(22, 247);
         this.textBox4.Name = "textBox4";
         this.textBox4.Size = new System.Drawing.Size(93, 20);
         this.textBox4.TabIndex = 9;
         // 
         // textBox5
         // 
         this.textBox5.Location = new System.Drawing.Point(22, 270);
         this.textBox5.Name = "textBox5";
         this.textBox5.Size = new System.Drawing.Size(179, 20);
         this.textBox5.TabIndex = 10;
         // 
         // textBox6
         // 
         this.textBox6.Location = new System.Drawing.Point(23, 296);
         this.textBox6.Name = "textBox6";
         this.textBox6.Size = new System.Drawing.Size(178, 20);
         this.textBox6.TabIndex = 11;
         // 
         // btnLaunchFileFrm
         // 
         this.btnLaunchFileFrm.Location = new System.Drawing.Point(13, 46);
         this.btnLaunchFileFrm.Name = "btnLaunchFileFrm";
         this.btnLaunchFileFrm.Size = new System.Drawing.Size(102, 23);
         this.btnLaunchFileFrm.TabIndex = 12;
         this.btnLaunchFileFrm.Text = "Launch &File Form";
         this.btnLaunchFileFrm.UseVisualStyleBackColor = true;
         this.btnLaunchFileFrm.Click += new System.EventHandler(this.btnLaunchFileFrm_Click);
         // 
         // btnIsRunning
         // 
         this.btnIsRunning.Location = new System.Drawing.Point(106, 23);
         this.btnIsRunning.Name = "btnIsRunning";
         this.btnIsRunning.Size = new System.Drawing.Size(75, 23);
         this.btnIsRunning.TabIndex = 13;
         this.btnIsRunning.Text = "IsRunning";
         this.btnIsRunning.UseVisualStyleBackColor = true;
         this.btnIsRunning.Click += new System.EventHandler(this.btnIsRunning_Click);
         // 
         // btnToExcel
         // 
         this.btnToExcel.Location = new System.Drawing.Point(12, 91);
         this.btnToExcel.Name = "btnToExcel";
         this.btnToExcel.Size = new System.Drawing.Size(78, 23);
         this.btnToExcel.TabIndex = 14;
         this.btnToExcel.Text = "To &Excel";
         this.btnToExcel.UseVisualStyleBackColor = true;
         this.btnToExcel.Click += new System.EventHandler(this.btnToExcel_Click);
         // 
         // groupBoxRS2100sqld
         // 
         this.groupBoxRS2100sqld.Controls.Add(this.btnIsRunning);
         this.groupBoxRS2100sqld.Controls.Add(this.btnRemoveSvc);
         this.groupBoxRS2100sqld.Controls.Add(this.btnStopSvc);
         this.groupBoxRS2100sqld.Controls.Add(this.btnStartSvc);
         this.groupBoxRS2100sqld.Controls.Add(this.btnInstallSvc);
         this.groupBoxRS2100sqld.Location = new System.Drawing.Point(458, 188);
         this.groupBoxRS2100sqld.Name = "groupBoxRS2100sqld";
         this.groupBoxRS2100sqld.Size = new System.Drawing.Size(203, 127);
         this.groupBoxRS2100sqld.TabIndex = 15;
         this.groupBoxRS2100sqld.TabStop = false;
         this.groupBoxRS2100sqld.Text = "RS2100sqld Service";
         // 
         // groupBoxSQLServer
         // 
         this.groupBoxSQLServer.Controls.Add(this.label1);
         this.groupBoxSQLServer.Controls.Add(this.tbConnectString);
         this.groupBoxSQLServer.Controls.Add(this.btnExecute);
         this.groupBoxSQLServer.Controls.Add(this.tbSqlResults);
         this.groupBoxSQLServer.Controls.Add(this.lblSqlServerResults);
         this.groupBoxSQLServer.Location = new System.Drawing.Point(16, 343);
         this.groupBoxSQLServer.Name = "groupBoxSQLServer";
         this.groupBoxSQLServer.Size = new System.Drawing.Size(542, 149);
         this.groupBoxSQLServer.TabIndex = 16;
         this.groupBoxSQLServer.TabStop = false;
         this.groupBoxSQLServer.Text = "SQL Server";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
         this.label1.Location = new System.Drawing.Point(6, 21);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(91, 13);
         this.label1.TabIndex = 4;
         this.label1.Text = "Connection String";
         // 
         // tbConnectString
         // 
         this.tbConnectString.Location = new System.Drawing.Point(7, 37);
         this.tbConnectString.Name = "tbConnectString";
         this.tbConnectString.Size = new System.Drawing.Size(529, 20);
         this.tbConnectString.TabIndex = 3;
         this.tbConnectString.Text = "Data Source=CT2\\SQLEXPRESS;Initial Catalog=PRACDB;User Id=Driver90;Password=Drive" +
             "r90;";
         // 
         // btnExecute
         // 
         this.btnExecute.Location = new System.Drawing.Point(27, 112);
         this.btnExecute.Name = "btnExecute";
         this.btnExecute.Size = new System.Drawing.Size(75, 23);
         this.btnExecute.TabIndex = 2;
         this.btnExecute.Text = "E&xecute";
         this.btnExecute.UseVisualStyleBackColor = true;
         this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
         // 
         // tbSqlResults
         // 
         this.tbSqlResults.Location = new System.Drawing.Point(27, 87);
         this.tbSqlResults.Name = "tbSqlResults";
         this.tbSqlResults.Size = new System.Drawing.Size(397, 20);
         this.tbSqlResults.TabIndex = 1;
         // 
         // lblSqlServerResults
         // 
         this.lblSqlServerResults.AutoSize = true;
         this.lblSqlServerResults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
         this.lblSqlServerResults.Location = new System.Drawing.Point(24, 71);
         this.lblSqlServerResults.Name = "lblSqlServerResults";
         this.lblSqlServerResults.Size = new System.Drawing.Size(42, 13);
         this.lblSqlServerResults.TabIndex = 0;
         this.lblSqlServerResults.Text = "Results";
         // 
         // btnSendEmail
         // 
         this.btnSendEmail.Location = new System.Drawing.Point(468, 131);
         this.btnSendEmail.Name = "btnSendEmail";
         this.btnSendEmail.Size = new System.Drawing.Size(102, 23);
         this.btnSendEmail.TabIndex = 17;
         this.btnSendEmail.Text = "Send an email";
         this.btnSendEmail.UseVisualStyleBackColor = true;
         this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(620, 88);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(75, 23);
         this.button1.TabIndex = 18;
         this.button1.Text = "press";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(753, 504);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.btnSendEmail);
         this.Controls.Add(this.groupBoxSQLServer);
         this.Controls.Add(this.groupBoxRS2100sqld);
         this.Controls.Add(this.btnToExcel);
         this.Controls.Add(this.btnLaunchFileFrm);
         this.Controls.Add(this.textBox6);
         this.Controls.Add(this.textBox5);
         this.Controls.Add(this.textBox4);
         this.Controls.Add(this.listBoxRes);
         this.Controls.Add(this.textBox3);
         this.Controls.Add(this.textBox2);
         this.Controls.Add(this.textBox1);
         this.Name = "Form1";
         this.Text = "FormSmp1";
         this.Load += new System.EventHandler(this.Form1_Load);
         this.groupBoxRS2100sqld.ResumeLayout(false);
         this.groupBoxSQLServer.ResumeLayout(false);
         this.groupBoxSQLServer.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox textBox1;
      private System.Windows.Forms.TextBox textBox2;
      private System.Windows.Forms.TextBox textBox3;
      private System.Windows.Forms.ListBox listBoxRes;
      private System.Windows.Forms.Button btnInstallSvc;
      private System.Windows.Forms.Button btnStartSvc;
      private System.Windows.Forms.Button btnStopSvc;
      private System.Windows.Forms.Button btnRemoveSvc;
      private System.Windows.Forms.TextBox textBox4;
      private System.Windows.Forms.TextBox textBox5;
      private System.Windows.Forms.TextBox textBox6;
      private System.Windows.Forms.Button btnLaunchFileFrm;
      private System.Windows.Forms.Button btnIsRunning;
      private System.Windows.Forms.Button btnToExcel;
      private System.Windows.Forms.GroupBox groupBoxRS2100sqld;
      private System.Windows.Forms.GroupBox groupBoxSQLServer;
      private System.Windows.Forms.Label lblSqlServerResults;
      private System.Windows.Forms.Button btnExecute;
      private System.Windows.Forms.TextBox tbSqlResults;
      private System.Windows.Forms.TextBox tbConnectString;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Button btnSendEmail;
      private System.Windows.Forms.Button button1;
   }
}

