using System;
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
        // Tia项目
        public Project tiaProject;
        // Tia项目中的软件（PLC、HMI）
        public PlcSoftware plcSoftware;
        // 
        public static Dictionary<string, Tuple<PlcBlock, PlcBlockGroup>> blocksDict = new Dictionary<string, Tuple<PlcBlock, PlcBlockGroup>>();
        // 存放xml文件的文件夹名
        public string xmlFileFolder = "D:\\Users\\MY\\Desktop\\TIA";

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

        
        private void btn_EnumBlockGroupsAndBlocks_Click(object sender, EventArgs e)
        {
            MyTiaPortal.EnumAllBlockGroupsAndBlocks();
            blocksDict = MyTiaPortal.blocksDict;
            
            foreach (var blockName in blocksDict.Keys)
            {
                listBox_Main.Items.Add(blockName);
            }
            
        }        
        

        //导出选中的块到XML文件
        private void btn_ExportBlockXml_Click(object sender, EventArgs e)
        {
            if (listBox_Main.SelectedItems.Count > 0)
            {
                string strBlockName = listBox_Main.SelectedItem.ToString();
                //MessageBox.Show(strBlockName);
                PlcBlock block = plcSoftware.BlockGroup.Blocks.Find(strBlockName);

                FileInfo fileInfo = new FileInfo(xmlFileFolder + "\\" + block.Name + ".xml");
                if(File.Exists(fileInfo.ToString()))
                {
                    File.Delete(fileInfo.ToString());
                }
                block.Export(fileInfo, ExportOptions.WithDefaults);
                MessageBox.Show("已导出块：" + block.Name + "到.xml文件");
                
            }

            PlcBlockUserGroupComposition userGroupComposition = plcSoftware.BlockGroup.Groups;
            PlcBlockUserGroup plcBlockUserGroup = userGroupComposition.Find("DBs");
                       
        }

        //导入FC块
        private void btn_ImportFC_Click(object sender, EventArgs e)
        {
            string strBlockName = listBox_Main.SelectedItem.ToString();
            //PlcBlock block = plcSoftware.BlockGroup.Blocks.Find(strBlockName);
            PlcBlock block = blocksDict[strBlockName].Item1;
            string xmlFilePath = xmlFileFolder + "\\" + strBlockName + ".xml";
            FileInfo fileInfo = new FileInfo(xmlFilePath);
            // 1. 导出选中的块到xml文件
            if (File.Exists(xmlFilePath))
            {
                //如果文件已经存在，删除后重新导出
                File.Delete(xmlFilePath);
            }
            block.Export(fileInfo, ExportOptions.WithDefaults);

            // 2. 根据用户选择的配置文件重新编辑获得新的xml文件
            OpenFileDialog selectFile = new OpenFileDialog();
            selectFile.Title = "读取需要导入的配置文件";
            selectFile.Filter = "xlsx files|*.xlsx|xls files|*.xls";
            selectFile.ShowDialog();

            string excelFilePath = selectFile.FileName;
            selectFile.Dispose();
            if (excelFilePath != "")
            {
                ExcelReader excelReader = new ExcelReader(excelFilePath);

                //// 如果存在多个工作表，需要用户选择一个
                //if (excelReader.dataTables.Count>1)
                //{
                //    Form formSelectWorksheet = new Form();
                //    formSelectWorksheet.Text = "配置文件有多个工作表，请选择其中一个";
                //    formSelectWorksheet.Width = 500;                    
                //    formSelectWorksheet.Show();
                //}

                configDataTable = excelReader.dataTables[0];
               
                XmlParser xmlParser = new XmlParser(xmlFilePath);
                xmlParser.ParserFC(configDataTable);
            }

            // 3. 导入xml文件
            IList<PlcBlock> blocks = blocksDict[strBlockName].Item2.Blocks.Import(fileInfo, ImportOptions.Override); 

        }

        //导入DB块
        private void btn_ImportDBs_Click(object sender, EventArgs e)
        {
            string strBlockName = listBox_Main.SelectedItem.ToString();
            PlcBlock block = blocksDict[strBlockName].Item1;
            string xmlFilePath = xmlFileFolder + "\\" + strBlockName + ".xml";
            FileInfo fileInfo = new FileInfo(xmlFilePath);
            // 1. 导出选中的块到xml文件
            if (File.Exists(xmlFilePath))
            {
                //如果文件已经存在，删除后重新导出
                File.Delete(xmlFilePath);
            }
            block.Export(fileInfo, ExportOptions.WithDefaults);

            // 2. 根据用户选择的配置文件重新编辑获得新的xml文件
            OpenFileDialog selectFile = new OpenFileDialog();
            selectFile.Title = "读取需要导入的配置文件";
            selectFile.Filter = "xlsx files|*.xlsx|xls files|*.xls";
            selectFile.ShowDialog();

            string excelFilePath = selectFile.FileName;
            selectFile.Dispose();
            if (excelFilePath != "")
            {
                ExcelReader excelReader = new ExcelReader(excelFilePath);

                //// 如果存在多个工作表，需要用户选择一个
                //if (excelReader.dataTables.Count>1)
                //{
                //    Form formSelectWorksheet = new Form();
                //    formSelectWorksheet.Text = "配置文件有多个工作表，请选择其中一个";
                //    formSelectWorksheet.Width = 500;                    
                //    formSelectWorksheet.Show();
                //}

                configDataTable = excelReader.dataTables[0];

                XmlParser xmlParser = new XmlParser(xmlFilePath);
                foreach (DataRow rol in configDataTable.Rows)
                {
                    xmlParser.ParserDB(rol["引用DB"].ToString());                    
                    IList<PlcBlock> blocks = blocksDict[strBlockName].Item2.Blocks.Import(fileInfo, ImportOptions.Override);
                }
            }

            
        }

        //根据配置文件生成新的XML文件
        private void btn_GenerateNewXml_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectFile = new OpenFileDialog();
            selectFile.Title = "读取需要导入的配置文件";
            selectFile.Filter = "xlsx files|*.xlsx|xls files|*.xls";
            selectFile.ShowDialog();

            string excelFilePath = selectFile.FileName;
            selectFile.Dispose();
            if (excelFilePath != "")
            {
                ExcelReader excelReader = new ExcelReader(excelFilePath);

                //// 如果存在多个工作表，需要用户选择一个
                //if (excelReader.dataTables.Count>1)
                //{
                //    Form formSelectWorksheet = new Form();
                //    formSelectWorksheet.Text = "配置文件有多个工作表，请选择其中一个";
                //    formSelectWorksheet.Width = 500;                    
                //    formSelectWorksheet.Show();
                //}

                configDataTable = excelReader.dataTables[0];

                FileInfo fileInfo = new FileInfo("D:\\WORKLOG\\00_FA\\TIA\\Xmls_Blocks\\" + "P_Motors_FC" + ".xml");

                XmlParser xmlParser = new XmlParser(fileInfo.ToString());
                xmlParser.ParserFC(configDataTable);


            }


        }

        //用户设置XML文件存放目录
        private void btn_ChoseXmlFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "选择XML文件存放目录";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                xmlFileFolder = folderBrowserDialog.SelectedPath;
                txtBox_XmlFolderPath.Text = xmlFileFolder;
            }
            
        }
    }
}
