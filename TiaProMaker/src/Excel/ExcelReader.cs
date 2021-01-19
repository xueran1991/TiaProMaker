using System;
using System.IO;
using ExcelDataReader;
using System.Data;

namespace src.ReadExcel
{
    class ExcelReader
    {
        private string excelFilepath;
        public DataSet dataSet;
        public DataTableCollection dataTables;



        public ExcelReader(String filePath)
        {
            // 读取Excel文件
            excelFilepath = filePath;
            FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(fileStream);

            // excelReader的配置
            var conf = new ExcelDataSetConfiguration
            {
                ConfigureDataTable = _ => new ExcelDataTableConfiguration
                {
                    // 使用第一行作为列标题, 此后标题列不再作为第一行数据
                    UseHeaderRow = true
                }
            };

            // 获取DataSet
            dataSet = excelDataReader.AsDataSet(conf);

            // 获取DataTables
            dataTables = dataSet.Tables;

            // 关闭与Excel文件的连接
            excelDataReader.Close();

        }
    }
}
