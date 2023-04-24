using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LincolnTest
{
    public partial class PlainTextInput : Form
    {
        public string pname;
        public PlainTextInput()
        {
            InitializeComponent();
        }

        public void setText( string myTitle, string myPrompt)
        {
            projectLabel.Text = myPrompt;
            this.Text = myTitle;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pname = pnameTextBox.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
