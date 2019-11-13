namespace SyslogServer
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
        	this.textBox1 = new System.Windows.Forms.TextBox();
        	this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
        	this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
        	this.okButton = new System.Windows.Forms.Button();
        	this.button1 = new System.Windows.Forms.Button();
        	this.textBox2 = new System.Windows.Forms.TextBox();
        	this.label1 = new System.Windows.Forms.Label();
        	this.label2 = new System.Windows.Forms.Label();
        	this.label3 = new System.Windows.Forms.Label();
        	this.label4 = new System.Windows.Forms.Label();
        	this.SuspendLayout();
        	// 
        	// textBox1
        	// 
        	this.textBox1.Location = new System.Drawing.Point(199, 153);
        	this.textBox1.Margin = new System.Windows.Forms.Padding(4);
        	this.textBox1.Multiline = true;
        	this.textBox1.Name = "textBox1";
        	this.textBox1.Size = new System.Drawing.Size(132, 78);
        	this.textBox1.TabIndex = 18;
        	// 
        	// checkedListBox1
        	// 
        	this.checkedListBox1.CheckOnClick = true;
        	this.checkedListBox1.FormattingEnabled = true;
        	this.checkedListBox1.Location = new System.Drawing.Point(41, 41);
        	this.checkedListBox1.Margin = new System.Windows.Forms.Padding(4);
        	this.checkedListBox1.Name = "checkedListBox1";
        	this.checkedListBox1.Size = new System.Drawing.Size(132, 72);
        	this.checkedListBox1.TabIndex = 17;
        	// 
        	// checkedListBox2
        	// 
        	this.checkedListBox2.CheckOnClick = true;
        	this.checkedListBox2.FormattingEnabled = true;
        	this.checkedListBox2.Location = new System.Drawing.Point(199, 41);
        	this.checkedListBox2.Margin = new System.Windows.Forms.Padding(4);
        	this.checkedListBox2.Name = "checkedListBox2";
        	this.checkedListBox2.Size = new System.Drawing.Size(132, 72);
        	this.checkedListBox2.TabIndex = 19;
        	// 
        	// okButton
        	// 
        	this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        	this.okButton.Location = new System.Drawing.Point(124, 262);
        	this.okButton.Margin = new System.Windows.Forms.Padding(4);
        	this.okButton.Name = "okButton";
        	this.okButton.Size = new System.Drawing.Size(100, 28);
        	this.okButton.TabIndex = 25;
        	this.okButton.Text = "&OK";
        	this.okButton.Click += new System.EventHandler(this.okButton_Click);
        	// 
        	// button1
        	// 
        	this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        	this.button1.Location = new System.Drawing.Point(232, 262);
        	this.button1.Margin = new System.Windows.Forms.Padding(4);
        	this.button1.Name = "button1";
        	this.button1.Size = new System.Drawing.Size(100, 28);
        	this.button1.TabIndex = 26;
        	this.button1.Text = "Cancel";
        	this.button1.UseVisualStyleBackColor = true;
        	// 
        	// textBox2
        	// 
        	this.textBox2.Location = new System.Drawing.Point(41, 153);
        	this.textBox2.Margin = new System.Windows.Forms.Padding(4);
        	this.textBox2.Multiline = true;
        	this.textBox2.Name = "textBox2";
        	this.textBox2.Size = new System.Drawing.Size(132, 78);
        	this.textBox2.TabIndex = 27;
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(37, 21);
        	this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(66, 17);
        	this.label1.TabIndex = 28;
        	this.label1.Text = "Facilities:";
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(195, 21);
        	this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(74, 17);
        	this.label2.TabIndex = 29;
        	this.label2.Text = "Severities:";
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Location = new System.Drawing.Point(195, 133);
        	this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(48, 17);
        	this.label3.TabIndex = 30;
        	this.label3.Text = "Hosts:";
        	// 
        	// label4
        	// 
        	this.label4.AutoSize = true;
        	this.label4.Location = new System.Drawing.Point(37, 133);
        	this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(68, 17);
        	this.label4.TabIndex = 31;
        	this.label4.Text = "Contents:";
        	// 
        	// Form2
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.CancelButton = this.button1;
        	this.ClientSize = new System.Drawing.Size(379, 321);
        	this.Controls.Add(this.label4);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.textBox2);
        	this.Controls.Add(this.button1);
        	this.Controls.Add(this.okButton);
        	this.Controls.Add(this.checkedListBox2);
        	this.Controls.Add(this.textBox1);
        	this.Controls.Add(this.checkedListBox1);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        	this.Margin = new System.Windows.Forms.Padding(4);
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "Form2";
        	this.ShowIcon = false;
        	this.ShowInTaskbar = false;
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        	this.Text = "Filters";
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}