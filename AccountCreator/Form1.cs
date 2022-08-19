using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountCreator
{
    public partial class Form1 : Form
    {
        Reddit r;
        ProtonMail m;
        GMail g;
        public static string computerName;
        public static string driverPath;
        public static string filePath;
        public static string nbOfAccStr;
        public static int nbOfAcc;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void btnStart_Click(object sender, EventArgs e)
        {
            if(txtPath.Text == string.Empty || txtNbAcc.Text == string.Empty)
            {
                MessageBox.Show("Please fill path and desired number of accounts.");
            }
            else if(txtPath.Text != string.Empty && txtNbAcc.Text != string.Empty)
            {
                filePath = txtPath.Text;
                nbOfAccStr = txtNbAcc.Text;
                nbOfAcc = int.Parse(nbOfAccStr);
            }

            if (chBoxReddit.Checked)
            {
                r = new Reddit(this);
                r.CreateReddit();
            }
            if (chBoxMail.Checked)
            {
                m = new ProtonMail(this);
                m.CreateMail();
            }
            if (chBoxGMail.Checked)
            {
                g = new GMail(this);
                g.CreateGMail();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            computerName = Environment.UserName;

            driverPath = (String.Format("C:\\Users\\{0}\\AppData\\Local\\Google\\Chrome\\User Data", computerName));
            
            try
            {
                byte[] bytes1 = Properties.Resources.chromedriver;
                File.WriteAllBytes(driverPath + "\\chromedriver.exe", bytes1);

                byte[] bytes2 = Properties.Resources.SeleniumExtras_WaitHelpers;
                File.WriteAllBytes(driverPath + "\\SeleniumExtras.WaitHelpers.dll", bytes2);

                byte[] bytes3 = Properties.Resources.WebDriver;
                File.WriteAllBytes(driverPath + "\\WebDriver.dll", bytes3);

                lblInjectStatus.Text = "Succes";
                lblInjectStatus.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                lblInjectStatus.Text = "Failed";
                lblInjectStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.Delete(driverPath + "\\chromedriver.exe");
            File.Delete(driverPath + "\\SeleniumExtras.WaitHelpers.dll");
            File.Delete(driverPath + "\\WebDriver.dll");
        }

        private void chBoxReddit_CheckedChanged(object sender, EventArgs e)
        {
            chBoxMail.Enabled = (chBoxReddit.CheckState == CheckState.Unchecked);
            chBoxGMail.Enabled = (chBoxReddit.CheckState == CheckState.Unchecked);
        }

        private void chBoxMail_CheckedChanged(object sender, EventArgs e)
        {
            chBoxReddit.Enabled = (chBoxMail.CheckState == CheckState.Unchecked);
            chBoxGMail.Enabled = (chBoxMail.CheckState == CheckState.Unchecked);
        }

        private void chBoxGMail_CheckedChanged(object sender, EventArgs e)
        {
            chBoxReddit.Enabled = (chBoxGMail.CheckState == CheckState.Unchecked);
            chBoxMail.Enabled = (chBoxGMail.CheckState == CheckState.Unchecked);
        }

        public string GetFilePath()
        {
            return filePath;
        }
        public string GetDriverPath()
        {
            return driverPath;
        }
        public int GetNbOfAcc()
        {
            return nbOfAcc;
        }
    }
}
