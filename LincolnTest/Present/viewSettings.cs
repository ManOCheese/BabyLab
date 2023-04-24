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
    public partial class viewSettings : Form
    {
        public viewSettings()
        {
            InitializeComponent();
        }

        private void viewSettings_Load(object sender, EventArgs e)
        {
            scaleUpDown.Value = (decimal)Properties.PresentView.Default.Scale;
        }

        private void scaleUpDown_ValueChanged(object sender, EventArgs e)
        {
            Properties.PresentView.Default.Scale = (float)scaleUpDown.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
