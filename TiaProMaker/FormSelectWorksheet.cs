using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiaProMaker
{
    public partial class FormSelectWorksheet : Form
    {
        public FormSelectWorksheet()
        {
            InitializeComponent();
            foreach (string  tableName in FormMain.workSheetNames)
            {
                checkedListBox_SelectWorksheet.Items.Add(tableName);
            }
            btn_ConfimSelection.Enabled = false;
        }


        private void btn_ConfimSelect_Click(object sender, EventArgs e)
        {            
            FormMain.selectedWorhsheetName = checkedListBox_SelectWorksheet.CheckedItems[0].ToString();
            this.Close();
        }

        // 仅单选：当有新的选中时清空已有的选中项
        private void checkedListBox_SelectWorksheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            int currentSelectionIdx = checkedListBox_SelectWorksheet.SelectedIndex;
            for (int i = 0; i < checkedListBox_SelectWorksheet.Items.Count; i++)
            {
                checkedListBox_SelectWorksheet.SetItemChecked(i, false);
            }
            checkedListBox_SelectWorksheet.SetItemChecked(currentSelectionIdx, true);
            if (checkedListBox_SelectWorksheet.CheckedItems.Count>0)
            {
                btn_ConfimSelection.Enabled = true;
            }
            else
            {
                btn_ConfimSelection.Enabled = false;
            }
        }
    
    }
}
