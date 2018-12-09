using System;
using System.Windows.Forms;

namespace ChooseEnvironment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                Environment.SetEnvironmentVariable("ENVIRONMENT_ENV", "STAGING_Mainnet", EnvironmentVariableTarget.User);
                MessageBox.Show("Done!");
            }
            else if(checkBox2.Checked)
            {
                Environment.SetEnvironmentVariable("ENVIRONMENT_ENV", "STAGING_Kovan", EnvironmentVariableTarget.User);
                MessageBox.Show("Done!");
            }
            else if (checkBox4.Checked)
            {
                Environment.SetEnvironmentVariable("ENVIRONMENT_ENV", "PROD_Mainnet", EnvironmentVariableTarget.User);
                MessageBox.Show("Done!");
            }
            else if (checkBox3.Checked)
            {
                Environment.SetEnvironmentVariable("ENVIRONMENT_ENV", textBox1.Text, EnvironmentVariableTarget.User);
                MessageBox.Show("Done!");
            }
        }
    }
}
