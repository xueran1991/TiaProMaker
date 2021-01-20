using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data;
using System.Windows.Forms;

namespace src.Xml
{
    class XmlParser
    {
        public  XmlDocument xmlDocument;
        public  XmlNode rootNode;
        public  XmlNamespaceManager _ns;
        private string xmlFileFullPath;

        //构造函数，读入路径中的xml文件
        public XmlParser(string xmlFilePath)
        {
            xmlFileFullPath = xmlFilePath;
            xmlDocument = new XmlDocument();            
            xmlDocument.Load(xmlFilePath);
            //添加xml命名空间
            _ns = new XmlNamespaceManager(xmlDocument.NameTable);
            _ns.AddNamespace("SN", "http://www.siemens.com/automation/Openness/SW/NetworkSource/FlgNet/v3");
            _ns.AddNamespace("SI", "http://www.siemens.com/automation/Openness/SW/Interface/v3");
            //根节点
            rootNode = xmlDocument.DocumentElement;
        }

        // FC
        public void ParserFC(DataTable importDataTable)
        {
            // 第一个程序段视为程序模板
            // 获取这个模板程序段节点中的Access节点列表
            XmlNode networkTemplateNode = rootNode.SelectSingleNode("//SW.Blocks.CompileUnit[@ID='3']");
            XmlNodeList templateAccessNodeList = networkTemplateNode.SelectNodes(".//SN:Parts/SN:Access", _ns);

            if (networkTemplateNode == null)
            {
                MessageBox.Show("未发现模板程序段");
                return;
            }
            List<string> blockLinkColumns = new List<string>() { "UId", "NameCon", "AccessScope" };
            DataTable blockLinkTable = new DataTable();
            foreach (string name in blockLinkColumns)
            {
                DataColumn col = new DataColumn(name);
                blockLinkTable.Columns.Add(col);
            }

            // 从模板程序段中获取块管脚的参数
            foreach (XmlNode accessNode in templateAccessNodeList)
            {            
                DataRow row = blockLinkTable.NewRow();
                // 获取Access节点的UId、AccessScope、NamcCon属性
                row["UId"] = accessNode.Attributes["UId"].Value;
                row["AccessScope"] = accessNode.Attributes["Scope"].Value;
                XmlNode wireNode = networkTemplateNode.SelectSingleNode(".//SN:Wire/SN:IdentCon[@UId=" + row["UId"] + "]", _ns).ParentNode;
                row["NameCon"] = wireNode.SelectSingleNode("SN:NameCon", _ns).Attributes["Name"].Value;

                blockLinkTable.Rows.Add(row);
            }

            //根据导入文件的数据修改XML文件
            foreach (DataRow addObject in importDataTable.Rows)
            {
                //
                // 导入数据的每一行作为一个节点，对每个节点完成编辑后插入到程序段节点的末尾
                //

                // 导入文件的每一行拷贝一个模板程序段的节点
                XmlNode addNode = networkTemplateNode.CloneNode(true);

                // 编辑需要添加的节点
                Console.WriteLine(addObject["引用DB"]);

                // 1.更改背景块DB编号
                addNode.SelectSingleNode(".//SN:CallInfo/SN:Instance/SN:Component", _ns).Attributes["Name"].Value = addObject["引用DB"].ToString();

                //2. 更改程序段标题和注释
                addNode.SelectSingleNode(".//MultilingualText[@CompositionName='Title']//Text").InnerText = addObject["位号"].ToString();              // 标题
                addNode.SelectSingleNode(".//MultilingualText[@CompositionName='Comment']//Text").InnerText = addObject["位号"].ToString();     // 注释

                //3. 修改程序段管脚连接
                foreach (DataRow row in blockLinkTable.Rows)
                {
                    // 遍历块管脚
                    // 注意这里只修改模板程序段中写入了变量或数值的管脚连接
                    // 如果管脚值是默认而未作修改，同样不会被处理

                    XmlNode accessNode = addNode.SelectSingleNode(".//SN:Access[@UId='" + row["UId"].ToString() + "']", _ns);
                    //块管脚上连接的不同的不同数值类型                    
                    switch (row["AccessScope"])
                    {
                        // 全局变量
                        case "GlobalVariable":
                            accessNode.SelectSingleNode(".//SN:Component", _ns).Attributes["Name"].Value = addObject[row["NameCon"].ToString()].ToString();
                            break;

                        // 常数
                        case "LiteralConstant":
                            accessNode.SelectSingleNode(".//SN:ConstantValue", _ns).InnerText = addObject[row["NameCon"].ToString()].ToString();
                            break;

                        // 其他类型
                        default:
                            break;
                    }
                }

                //4. 将addNode添加到块标题节点之前
                XmlNode parentNode = rootNode.SelectSingleNode("//SW.Blocks.FC");
                XmlNode blockTitleNode = rootNode.SelectSingleNode("./SW.Blocks.FC/ObjectList/MultilingualText[@CompositionName='Title']");
                blockTitleNode.ParentNode.InsertBefore(addNode, blockTitleNode);
                
            }
                        
            // 5. 修改节点ID
            // 如果不改动Parts内子节点的结构，则UId无需修改            
            XmlNodeList idNodeList = rootNode.SelectNodes("//*[@ID]");
            int ID = 0;
            foreach (XmlNode node in idNodeList)
            {
                node.Attributes["ID"].Value = Convert.ToString(ID, 16).ToUpper();
                ID++;
            }

            //6. 保存Xml文件
            xmlDocument.Save(xmlFileFullPath);
        }

        // DB
        public void ParserDB(string dbName)
        {
            XmlNode dbNameNode = rootNode.SelectSingleNode("//Name");
            XmlNode dbNumNode = rootNode.SelectSingleNode("//Number");

            //修改DB块的名称
            dbNameNode.InnerText = dbName;
            //保存Xml文件
            xmlDocument.Save(xmlFileFullPath);

        }

    }
}
