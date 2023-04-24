using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LincolnTest
{
    public partial class PresentKBOp : Form
    {
        pressKeyDialog keyDialog = new pressKeyDialog();
        string keyList = "";

        public PresentKBOp()
        {
            InitializeComponent();

        }

        private void PresentKBOp_FormClosed(object sender, FormClosedEventArgs e)
        {
            settingsDataGridView.Update();

            saveSettings();

            Properties.PresentKB.Default.Save();
        }

        private void saveSettings()
        {
            foreach (SettingsProperty setting in Properties.PresentKB.Default.Properties)
            {
                foreach (DataGridViewRow row in settingsDataGridView.Rows)
                {
                    if (setting.Name == row.Cells[2].Value.ToString())
                    {
                        Properties.PresentKB.Default[setting.Name] = row.Cells[1].Value.ToString();
                        Properties.PresentKB.Default.Save();
                    }
                }
            }
        }

        private void PresentKBOp_Shown(object sender, EventArgs e)
        {
            int index = 0;
            settingsDataGridView.Rows.Clear();

            foreach (SettingsProperty setting in Properties.PresentKB.Default.Properties)
            {
                settingsDataGridView.Rows.Add();
                string oldString = setting.Name;
                string newString = Regex.Replace(oldString, "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", " $1", RegexOptions.Compiled).Trim();
                settingsDataGridView.Rows[index].Cells[0].Value = newString;
                settingsDataGridView.Rows[index].Cells[1].Value = Properties.PresentKB.Default[setting.Name];
                keyList += Properties.PresentKB.Default[setting.Name];
                settingsDataGridView.Rows[index].Cells[2].Value = oldString;
                index++;
            }
        }
        private void settingsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewCell row in settingsDataGridView.SelectedCells)
            {
                keyDialog.keyList = keyList;
                keyDialog.keyToChange = settingsDataGridView.Rows[row.RowIndex].Cells[1].Value.ToString();
                keyDialog.ShowDialog();
                settingsDataGridView.Rows[row.RowIndex].Cells[1].Value = keyDialog.pressedKey;
                saveSettings();
                refreshUsedKeys();
            }
        }

        private void refreshUsedKeys()
        {
            keyList = "";
            foreach (SettingsProperty setting in Properties.PresentKB.Default.Properties)
            {
                keyList += Properties.PresentKB.Default[setting.Name];
            }
        }
    }
}
