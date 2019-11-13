/*
 * Created by SharpDevelop.
 * User: mark
 * Date: 11/4/2019
 * Time: 12:49 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text;

namespace SyslogServer
{
	/// <summary>
	/// Description of Form3.
	/// </summary>
	public partial class Form3 : Form
	{
		public Form3()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			textBox1.Text=Settings.ip;
			textBox2.Text=Settings.port.ToString();
			textBox3.Text=Settings.PfxFilename;
			textBox4.Text=Settings.PfxPassword;
			checkBox1.Checked=Settings.ssl;

			textBox5.Text=Settings.Sqlitedb;

			textBox6.Text=Settings.mailfrom;
			textBox7.Text=Settings.mailto;
			textBox8.Text=Settings.mailserver;
			textBox9.Text=Settings.mailport.ToString();
			textBox10.Text=Settings.mailusername;
			textBox11.Text=Settings.mailpassword;
			
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		private void okButton_Click(object sender, EventArgs e)
        {
			Properties.Settings.Default.port=Convert.ToInt32(textBox2.Text);
			Properties.Settings.Default.ip=textBox1.Text;
			Properties.Settings.Default.Pfxfilename=textBox3.Text;
			Properties.Settings.Default.Pfxpassword=textBox4.Text;
			Settings.PfxFilename= Properties.Settings.Default.Pfxfilename;
			Properties.Settings.Default.sqlitedb=textBox5.Text;
			Properties.Settings.Default.ssl=checkBox1.Checked;
			
			Properties.Settings.Default.mailfrom=textBox6.Text;
			Properties.Settings.Default.mailto=textBox7.Text;
			Properties.Settings.Default.mailserver=textBox8.Text;
			Properties.Settings.Default.mailport=Convert.ToInt32(textBox9.Text);
			Properties.Settings.Default.mailusername=textBox10.Text;
			Properties.Settings.Default.mailpassword=textBox11.Text;
			
			
			Properties.Settings.Default.Save();
			
if (MessageBox.Show("This will require a restart. Are you sure?", "Confirm Restart", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
				//
				//Settings._Server.Start();
            }
            this.DialogResult = DialogResult.OK;
        }
		void Button3Click(object sender, EventArgs e)
		{  
    OpenFileDialog openFileDialog1 = new OpenFileDialog  
    {  
        InitialDirectory = @".",  
        Title = "Browse PFX Files",  
  
        CheckFileExists = true,  
        CheckPathExists = true,  
  
        DefaultExt = "pfx",  
        Filter = "pfx files (*.pfx)|*.pfx",  
        FilterIndex = 2,  
        RestoreDirectory = true,  
  
        ReadOnlyChecked = true,  
        ShowReadOnly = true  
    };  
  
    if (openFileDialog1.ShowDialog() == DialogResult.OK)  
    {  
        textBox3.Text = openFileDialog1.FileName;  
    }  
}  
		void Button4Click(object sender, EventArgs e)
{  
    OpenFileDialog openFileDialog2 = new OpenFileDialog  
    {  
        InitialDirectory = @".",  
        Title = "Browse SQLite3 Files",  
  
        CheckFileExists = true,  
        CheckPathExists = true,  
  
        DefaultExt = "db3",  
        Filter = "db3 files (*.db3)|*.db3",  
        FilterIndex = 2,  
        RestoreDirectory = true,  
  
        ReadOnlyChecked = true,  
        ShowReadOnly = true  
    };  
  
    if (openFileDialog2.ShowDialog() == DialogResult.OK)  
    {  
        textBox5.Text = openFileDialog2.FileName;  
    }  
}  
		
	}
}
