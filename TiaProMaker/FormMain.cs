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
using TiaProMaker.data;

using Siemens.Engineering;
using Siemens.Engineering.SW;
using Siemens.Engineering.SW.Blocks;
using Siemens.Engineering.Hmi;
using Siemens.Engineering.HW;


namespace TiaProMaker
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            // 按钮使能开关
            btn_ExportBlockXml.Enabled = false;
            btn_ImportDBs.Enabled = false;
            btn_ImportFB.Enabled = false;
            btn_ImportFC.Enabled = false;
            btn_EnumBlockGroupsAndBlocks.Enabled = false;
            btn_ConnectToTiaProject.Enabled = true;

            xmlFileFolder = UI.Default.xmlFileFolder;
            txtBox_XmlFolderPath.Text = xmlFileFolder;
        }

        // 存放导入的配置文件的DataTabe
        public DataTable configDataTable;
        // Tia项目
        public Project tiaProject;
        // Tia项目中的软件（PLC、HMI）
        public PlcSoftware plcSoftware;
        // 存放块名称、块对象、块所在块组的字典
        public static Dictionary<string, Tuple<PlcBlock, PlcBlockGroup>> blocksDict = new Dictionary<string, Tuple<PlcBlock, PlcBlockGroup>>();
        // 默认存放xml文件的文件夹名
        public string xmlFileFolder;
        // 用户选择的工作表名称
        public static string selectedWorhsheetName;
        // 需要用户选择的Excel工作表
        public static List<string> workSheetNames = new List<string>();


        // 读取工作表，输出DataTable
        private DataTable GetDataTableViaDialog()
        {
            // 
            // 读取Excel(.xls\.xlsx)文件，如果只有一个工作表，直接输出该表的DataTable
            // 如果有多个工作表，弹出对话框由用户选择一个工作表进行输出
            //

            DataTable dataTable = new DataTable();
            selectedWorhsheetName = "";
            workSheetNames.Clear();

            OpenFileDialog selectFile = new OpenFileDialog();
            selectFile.Title = "读取需要导入的配置文件";
            selectFile.Filter = "xlsx files|*.xlsx|xls files|*.xls";
            selectFile.ShowDialog();

            string excelFilePath = selectFile.FileName;
            selectFile.Dispose();

            if (excelFilePath != "")
            {
                ExcelReader excelReader = new ExcelReader(excelFilePath);

                // 如果存在多个工作表，需要用户选择一个
                if (excelReader.dataTables.Count > 1)
                {
                    foreach (DataTable table in excelReader.dataTables)
                    {
                        workSheetNames.Add(table.TableName);
                    }
                    FormSelectWorksheet formSelectWorksheet = new FormSelectWorksheet();
                    formSelectWorksheet.ShowDialog();

                    // 等待用户选择工作表名称

                    if (selectedWorhsheetName != "")
                    {
                        dataTable = excelReader.dataTables[selectedWorhsheetName];
                        return dataTable;
                    }

                }
                else
                {
                    // 如果只有一个工作表，直接输出
                    dataTable = excelReader.dataTables[0];
                    return dataTable;
                }
            }

            return null;

        }

        // 读取工作表
        private void btn_ReadExcel_Click(object sender, EventArgs e)
        {
            configDataTable  = GetDataTableViaDialog();
            string rowData;
            if (configDataTable == null)
            {
                return;
            }
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

        // 连接到已打开的Tia Portal项目
        private void btn_ConnectToTiaProject_Click(object sender, EventArgs e)
        {

            tiaProject = MyTiaPortal.ConnectToTiaProject();
            if(tiaProject != null)
            {
                btn_EnumBlockGroupsAndBlocks.Enabled = true;
                txt_Status.Text = tiaProject.Path.ToString();
            }
                        
        }

        // 断开与Tia Portal项目的连接
        private void btn_DisposeTia_Click(object sender, EventArgs e)
        {
            MyTiaPortal.DisposeTiaPortal();
        }

        // 清空显示框
        private void btn_ClearListbox_Click(object sender, EventArgs e)
        {
            listBox_Main.Items.Clear();
            // 关闭按钮使能
            btn_ExportBlockXml.Enabled = false;
            btn_ImportDBs.Enabled = false;
            btn_ImportFB.Enabled = false;
            btn_ImportFC.Enabled = false;
        }

        // 获取项目的软硬件
        private void btn_GetSW_HW_Click(object sender, EventArgs e)
        {
            plcSoftware = MyTiaPortal.GetPlcSoftware();
            listBox_Main.Items.Add(plcSoftware.BlockGroup.Name);
        }

        // 枚举所有块
        private void btn_EnumBlockGroupsAndBlocks_Click(object sender, EventArgs e)
        {
            listBox_Main.Items.Clear();
            plcSoftware = MyTiaPortal.GetPlcSoftware();
            MyTiaPortal.EnumAllBlockGroupsAndBlocks();
            blocksDict = MyTiaPortal.blocksDict;
            
            foreach (var blockName in blocksDict.Keys)
            {
                listBox_Main.Items.Add(blockName);
            }
            
        }        
        
        // 导出选中的块到XML文件
        private void btn_ExportBlockXml_Click(object sender, EventArgs e)
        {
            if (listBox_Main.SelectedItems.Count > 0)
            {
                string strBlockName = listBox_Main.SelectedItem.ToString();
                PlcBlock block = blocksDict[strBlockName].Item1;
                FileInfo fileInfo = new FileInfo(xmlFileFolder + "\\" + block.Name + ".xml");

                MyTiaPortal.ExportBlockToXml(block, fileInfo);
                MessageBox.Show("已导出块：" + block.Name + "到.xml文件");                
            }            
                       
        }

        // 导入FC块
        private void btn_ImportFC_Click(object sender, EventArgs e)
        {
            string strBlockName = listBox_Main.SelectedItem.ToString();
            PlcBlock block = blocksDict[strBlockName].Item1;
            string xmlFilePath = xmlFileFolder + "\\" + strBlockName + ".xml";
            FileInfo fileInfo = new FileInfo(xmlFilePath);
            // 1. 导出选中的块到xml文件
            MyTiaPortal.ExportBlockToXml(block, fileInfo);

            // 2. 读取表格数据
            configDataTable = GetDataTableViaDialog();
            if (configDataTable == null)
            {
                MessageBox.Show("没有读取到导入配置数据");
                return;
            }

            // 3. 解析xml文件
            XmlParser xmlParser = new XmlParser(xmlFilePath);
            xmlParser.ParserFC(configDataTable);

            // 4. 导入xml文件
            IList<PlcBlock> blocks = blocksDict[strBlockName].Item2.Blocks.Import(fileInfo, ImportOptions.Override);

            // 5. 导入FC块的实例DB块
            if (checkBox_ImportDBsWhenIMportFC.Checked)
            {
                string strInstanceDBName = xmlParser.instanceDBofFC;
                if (strInstanceDBName != null)
                {
                    if (blocksDict.ContainsKey(strInstanceDBName))
                    {

                        PlcBlock instanceBlock = blocksDict[strInstanceDBName].Item1;
                        string instanceDBXmlFilePath = xmlFileFolder + "\\" + strInstanceDBName + ".xml";
                        FileInfo instanceDBFileInfo = new FileInfo(instanceDBXmlFilePath);

                        // 导出实例DB块到xml文件
                        MyTiaPortal.ExportBlockToXml(instanceBlock, instanceDBFileInfo);
                        
                        // DB块的解析实例
                        XmlParser xmlParserDB = new XmlParser(instanceDBXmlFilePath);

                        foreach (DataRow rol in configDataTable.Rows)
                        {
                            //已经导入的DB块不再重复导入
                            if (!blocksDict.ContainsKey(rol["引用DB"].ToString()))
                            {
                                // 只修改DB块的名称后导入xml文件
                                xmlParserDB.ParserDB(rol["引用DB"].ToString());
                                IList<PlcBlock> blocksDBs = blocksDict[strInstanceDBName].Item2.Blocks.Import(instanceDBFileInfo, ImportOptions.Override);
                            }
                        }
                    }
                }

            }
        }
           
        
        // 导入DB块
        private void btn_ImportDBs_Click(object sender, EventArgs e)
        {
            string strBlockName = listBox_Main.SelectedItem.ToString();
            PlcBlock block = blocksDict[strBlockName].Item1;
            string xmlFilePath = xmlFileFolder + "\\" + strBlockName + ".xml";
            FileInfo fileInfo = new FileInfo(xmlFilePath);

            // 导出选中的块到xml文件
            MyTiaPortal.ExportBlockToXml(block, fileInfo);

            // 读取表格数据
            configDataTable = GetDataTableViaDialog();

            if (configDataTable == null)
            {
                MessageBox.Show("没有读取到导入配置数据");
                return;
            }

            XmlParser xmlParser = new XmlParser(xmlFilePath);
            foreach (DataRow rol in configDataTable.Rows)
            {
                //已经导入的DB块不再重复导入
                if (!blocksDict.ContainsKey(rol["引用DB"].ToString()))
                {
                    xmlParser.ParserDB(rol["引用DB"].ToString());
                    IList<PlcBlock> blocks = blocksDict[strBlockName].Item2.Blocks.Import(fileInfo, ImportOptions.Override);
                }
            }
        }
                   
        
        // 根据配置文件生成新的XML文件
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

        // 用户设置XML文件存放目录
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

        // 导入FB块
        private void btn_ImportFB_Click(object sender, EventArgs e)
        {

        }

        // 根据选中的块类型调整按钮权限
        private void listBox_Main_SelectedValueChanged(object sender, EventArgs e)
        {
            

            // 关闭按钮使能
            btn_ExportBlockXml.Enabled = false;
            btn_ImportDBs.Enabled = false;
            btn_ImportFB.Enabled = false;
            btn_ImportFC.Enabled = false;

            // 按需开启导入按钮使能
            if (listBox_Main.SelectedItems.Count > 0)
            {
                string strBlockName = listBox_Main.SelectedItem.ToString();
                PlcBlock block = blocksDict[strBlockName].Item1;
                txt_Status.Text = block.GetType().Name;

                switch (block.GetType().Name)
                {
                    case "InstanceDB":
                        btn_ImportDBs.Enabled = true;
                        btn_ExportBlockXml.Enabled = true;
                        break;
                    case "FB":
                        btn_ImportFB.Enabled = true;
                        btn_ExportBlockXml.Enabled = true;
                        break;
                    case "FC":
                        btn_ImportFC.Enabled = true;
                        btn_ExportBlockXml.Enabled = true;
                        break;
                    case "OB":
                        btn_ExportBlockXml.Enabled = true;
                        break;
                    default:
                        break;
                }
            }
        }

        // 窗体关闭时保存界面上的用户输入信息
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            UI.Default.xmlFileFolder = xmlFileFolder;

            UI.Default.Save();
        }
    }
}
