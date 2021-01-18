﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

//
using src.ReadExcel;
using src.Tia;
using src.Xml;
using Siemens.Engineering;
using Siemens.Engineering.SW;
using Siemens.Engineering.SW.Blocks;
using Siemens.Engineering.Hmi;
using Siemens.Engineering.HW;

namespace TiaProMacker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 存放导入的配置文件的DataTabe
        public DataTable configDataTable;
        //        
        public Project tiaProject;
        public PlcSoftware plcSoftware;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_ReadExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectFile = new OpenFileDialog();
            selectFile.Title = "读取配置文件";
            selectFile.Filter = "xlsx files|*.xlsx|xls files|*.xls";
            selectFile.ShowDialog();
            //this.listBox_Main.Items.Add(selectFile.FileName);

            string excelFilePath = selectFile.FileName;
            selectFile.Dispose();
            if (excelFilePath != "")
            {
                string rowData = "";
                ExcelReader excelReader = new ExcelReader(excelFilePath);

                //// 如果存在多个工作部，需要用户选择一个
                //if (excelReader.dataTables.Count>1)
                //{
                //    Form formSelectWorksheet = new Form();
                //    formSelectWorksheet.Text = "配置文件有多个工作表，请选择其中一个";
                //    formSelectWorksheet.Width = 500;                    
                //    formSelectWorksheet.Show();
                //}

                configDataTable = excelReader.dataTables[0];
                foreach (DataRow row in configDataTable.Rows)
                {
                    rowData = "";
                    foreach (var col in row.ItemArray)
                    {
                        rowData += col.ToString() + "\t";
                    }
                    listBox_Main.Items.Add(rowData);
                }
            }

            
        }

        private void btn_ConnectToTiaProject_Click(object sender, EventArgs e)
        {

            tiaProject = MyTiaPortal.ConnectToTiaProject();
            if(tiaProject != null)
            {
                txt_Status.Text = tiaProject.Path.ToString();
            }
            
            
        }

        private void btn_DisposeTia_Click(object sender, EventArgs e)
        {
            MyTiaPortal.DisposeTiaPortal();
        }

        private void btn_ClearListbox_Click(object sender, EventArgs e)
        {
            listBox_Main.Items.Clear();
        }

        private void btn_GetSW_HW_Click(object sender, EventArgs e)
        {
            plcSoftware = MyTiaPortal.GetPlcSoftware();
            listBox_Main.Items.Add(plcSoftware.BlockGroup.Name);
        }


        #region EnumeratesAllPlcBlocks
        
        private void btn_EnumBlockGroupsAndBlocks_Click(object sender, EventArgs e)
        {
            // 程序块内所有不属于用户组的块
            foreach ( PlcBlock block in plcSoftware.BlockGroup.Blocks)
            {
                listBox_Main.Items.Add(block.Name);
            }

            // 枚举所有用户组及组内的所有块
            foreach (PlcBlockUserGroup blockUserGroup in plcSoftware.BlockGroup.Groups)
            {
                listBox_Main.Items.Add("-1-1-1-1-1-" + blockUserGroup.Name);
                EnumerateBlockUserGroups(blockUserGroup);
            }
        }
        //Enumerates all block user groups including sub groups
        private void EnumerateBlockUserGroups(PlcBlockUserGroup blockUserGroup)
        {
            //本子组内的所有块
            
            foreach (PlcBlock block in blockUserGroup.Blocks)
            {
                listBox_Main.Items.Add(block.Name);
            }
            //本子组内的所有下级子组
            foreach (PlcBlockUserGroup subBlockUserGroup in blockUserGroup.Groups)
            {
                listBox_Main.Items.Add("-2-2-2-2-2-" + blockUserGroup.Name);
                foreach (PlcBlock block in subBlockUserGroup.Blocks)
                {
                    listBox_Main.Items.Add(block.Name);
                }
                EnumerateBlockUserGroups(subBlockUserGroup);
                // recursion
                
            }
        }
        #endregion

        //导出选中的块到XML文件
        private void btn_ExportBlockXml_Click(object sender, EventArgs e)
        {
            if (listBox_Main.SelectedItems.Count > 0)
            {
                string strBlockName = listBox_Main.SelectedItem.ToString();
                //MessageBox.Show(strBlockName);
                PlcBlock block = plcSoftware.BlockGroup.Blocks.Find(strBlockName);

                FileInfo fileInfo = new FileInfo("D:\\WORKLOG\\00_FA\\TIA\\Xmls_Blocks\\" + block.Name + ".xml");
                if(File.Exists(fileInfo.ToString()))
                {
                    File.Delete(fileInfo.ToString());
                }
                block.Export(fileInfo, ExportOptions.WithDefaults);

                
            }

            PlcBlockUserGroupComposition userGroupComposition = plcSoftware.BlockGroup.Groups;
            PlcBlockUserGroup plcBlockUserGroup = userGroupComposition.Find("DBs");
                       
        }

        //导入FC块
        private void btn_ImportFC_Click(object sender, EventArgs e)
        {

        }

        //导入DB块
        private void btn_ImportDBs_Click(object sender, EventArgs e)
        {

        }

        

    }
}
