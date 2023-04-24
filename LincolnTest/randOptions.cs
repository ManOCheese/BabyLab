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
    public partial class randOptions : Form
    {

        Random rnd = new Random();
        public string randSeed;
        public string randOption;

        public randOptions()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            randSeedBox.Value = rnd.Next();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            randSeed = randSeedBox.Value.ToString();
            Close();
        }

        private void randOptions_Shown(object sender, EventArgs e)
        {
            randSeedBox.Value = int.Parse(randSeed);

        }
    }
}
