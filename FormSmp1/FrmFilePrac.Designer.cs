namespace FormSmp1
{
   partial class FrmFilePrac
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
         this.button1 = new System.Windows.Forms.Button();
         this.button2 = new System.Windows.Forms.Button();
         this.btnRWText = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this.tbOutput1 = new System.Windows.Forms.TextBox();
         this.tbOutput2 = new System.Windows.Forms.TextBox();
         this.listBox1 = new System.Windows.Forms.ListBox();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(14, 98);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(75, 23);
         this.button1.TabIndex = 0;
         this.button1.Text = "button1";
         this.button1.UseVisualStyleBackColor = true;
         // 
         // button2
         // 
         this.button2.Location = new System.Drawing.Point(15, 66);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(75, 23);
         this.button2.TabIndex = 1;
         this.button2.Text = "button2";
         this.button2.UseVisualStyleBackColor = true;
         // 
         // btnRWText
         // 
         this.btnRWText.Location = new System.Drawing.Point(15, 31);
         this.btnRWText.Name = "btnRWText";
         this.btnRWText.Size = new System.Drawing.Size(75, 23);
         this.btnRWText.TabIndex = 2;
         this.btnRWText.Text = "RW Text";
         this.btnRWText.UseVisualStyleBackColor = true;
         this.btnRWText.Click += new System.EventHandler(this.btnRWText_Click);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(15, 12);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(77, 13);
         this.label1.TabIndex = 3;
         this.label1.Text = "File Operations";
         // 
         // tbOutput1
         // 
         this.tbOutput1.Location = new System.Drawing.Point(129, 28);
         this.tbOutput1.Name = "tbOutput1";
         this.tbOutput1.Size = new System.Drawing.Size(236, 20);
         this.tbOutput1.TabIndex = 4;
         // 
         // tbOutput2
         // 
         this.tbOutput2.Location = new System.Drawing.Point(128, 74);
         this.tbOutput2.Name = "tbOutput2";
         this.tbOutput2.Size = new System.Drawing.Size(236, 20);
         this.tbOutput2.TabIndex = 5;
         // 
         // listBox1
         // 
         this.listBox1.FormattingEnabled = true;
         this.listBox1.Location = new System.Drawing.Point(129, 122);
         this.listBox1.Name = "listBox1";
         this.listBox1.Size = new System.Drawing.Size(235, 134);
         this.listBox1.TabIndex = 6;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(128, 12);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(45, 13);
         this.label2.TabIndex = 7;
         this.label2.Text = "Output1";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(129, 58);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(45, 13);
         this.label3.TabIndex = 8;
         this.label3.Text = "Output2";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(128, 103);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(35, 13);
         this.label4.TabIndex = 9;
         this.label4.Text = "label4";
         // 
         // FrmFilePrac
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(386, 266);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.listBox1);
         this.Controls.Add(this.tbOutput2);
         this.Controls.Add(this.tbOutput1);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.btnRWText);
         this.Controls.Add(this.button2);
         this.Controls.Add(this.button1);
         this.Name = "FrmFilePrac";
         this.Text = "FrmFilePrac";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.Button btnRWText;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox tbOutput1;
      private System.Windows.Forms.TextBox tbOutput2;
      private System.Windows.Forms.ListBox listBox1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
   }
}