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
                Environment.SetEnvironmentVariable("ENVIRONMENT_ENV", "PROD", EnvironmentVariableTarget.User);
                MessageBox.Show("Done!");
            }
            else if(checkBox2.Checked)
            {
                Environment.SetEnvironmentVariable("ENVIRONMENT_ENV", "STAGING", EnvironmentVariableTarget.User);
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
