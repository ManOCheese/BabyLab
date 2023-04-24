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
    public partial class NewBlockTextInput : Form
    {
        public NewBlockTextInput()
        {
            InitializeComponent();            
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Text = blockNameTextBox.Text;

            if (visualSelect.Checked)
            {
                 Text = Text + ".visual";
            }
            if (audioSelect.Checked)
            {
                Text = Text + ".audio";
            }

            DialogResult = DialogResult.OK;
        }
    }
}
