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
    public partial class pressKeyDialog : Form
    {

        public Keys pressedKey;
        public string keyList;
        public string keyToChange;
        public pressKeyDialog()
        {
            InitializeComponent();
        }

        private void pressKeyDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (keyList.Contains(e.KeyCode.ToString()) && pressedKey.ToString() != e.KeyCode.ToString())
            {
                keyText.Text = "Key " + e.KeyCode.ToString() + " is already assigned. \nPlease try again.";
            }
            else
            {
                pressedKey = e.KeyCode;
                this.Close();
            }
            
        }
    }
}
