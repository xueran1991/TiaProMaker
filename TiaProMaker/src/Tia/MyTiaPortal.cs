using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Siemens.Engineering;
using Siemens.Engineering.SW;
using Siemens.Engineering.SW.Blocks;
using Siemens.Engineering.HW;
using Siemens.Engineering.HW.Features;


namespace src.Tia
{
    class MyTiaPortal
    {
        
        public static TiaPortal tiaPortal;
        public static TiaPortalProcess tiaPortalProcess;
        public static Project tiaProject;
        public static PlcSoftware plcSoftware;

        public static Dictionary<string, Tuple<PlcBlock, PlcBlockGroup>> blocksDict = new Dictionary<string, Tuple<PlcBlock, PlcBlockGroup>>();

        // 连接到已经打开的TiaPortal项目上
        public static Project ConnectToTiaProject()
        {
            //************************************************************
            //  连接当前Tia Portal进程中已打开的项目
            //  项目只能打开一个
            //************************************************************
            IList<TiaPortalProcess> processes = TiaPortal.GetProcesses();
            switch (processes.Count)
            {
                case 1:
                    tiaPortalProcess = processes[0];
                    tiaPortal = tiaPortalProcess.Attach();

                    if (tiaPortal.Projects.Count <= 0)
                    {
                        MessageBox.Show("No TIA Portal Project was found!");
                        return null ;
                    }
                    tiaProject = tiaPortal.Projects[0];
                    //Form1.txt_Status.Text = tiaPortalProcess.ProjectPath.ToString();
                    return tiaProject;                    
                    
                case 0:
                    MessageBox.Show("No running instance of TIA Portal was found!");
                    return null;
                default:
                    MessageBox.Show("More than one running instance of TIA Portal was found!");
                    return null;
            }
        }

        // 断开与TiaPortal的连接
        public static void DisposeTiaPortal()
        {
            tiaPortal.Dispose();           
        }

        // 获取Tia项目的软件
        public static PlcSoftware GetPlcSoftware()
        {
            foreach (Device device in tiaProject.Devices)
            {
               if(GetPlcSoftware(device) != null)
                {
                    plcSoftware = GetPlcSoftware(device);
                }
            }
            return plcSoftware;
        }

        // 从硬件获取TIA项目的软件
        private static PlcSoftware GetPlcSoftware(Device device)
        {
            //***********************************************************
            //  获取PLC程序
            //
            //***********************************************************

            DeviceItemComposition deviceItemComposition = device.DeviceItems;
            foreach (DeviceItem deviceItem in deviceItemComposition)
            {
                SoftwareContainer softwareContainer = deviceItem.GetService<SoftwareContainer>();
                if (softwareContainer != null)
                {
                    Software softwareBase = softwareContainer.Software;
                    PlcSoftware plcSoftware = softwareBase as PlcSoftware;
                    return plcSoftware;
                }
            }
            return null;
        }
        

        // 枚举所有块组和包含的块
        public static void EnumAllBlockGroupsAndBlocks()
        {
            blocksDict.Clear();
            // 程序块内所有不属于用户组的块
            foreach (PlcBlock block in plcSoftware.BlockGroup.Blocks)
            {
                blocksDict.Add(block.Name, new Tuple<PlcBlock, PlcBlockGroup>(block, plcSoftware.BlockGroup));
            }

            // 枚举所有用户组及组内的所有块
            foreach (PlcBlockUserGroup blockUserGroup in plcSoftware.BlockGroup.Groups)
            {                
                EnumerateBlockUserGroups(blockUserGroup);
            }


        }
        // 枚举块的递归
        private static void EnumerateBlockUserGroups(PlcBlockUserGroup blockUserGroup)
        {
            //本子组内的所有块
            foreach (PlcBlock block in blockUserGroup.Blocks)
            {
                blocksDict.Add(block.Name, new Tuple<PlcBlock, PlcBlockGroup>(block, blockUserGroup));
            }
            //本子组内的所有下级子组
            foreach (PlcBlockUserGroup subBlockUserGroup in blockUserGroup.Groups)
            {
                // recursion
                EnumerateBlockUserGroups(subBlockUserGroup);                

            }
        }

        // 从程序块导出xml到指定路径
        public static void ExportBlockToXml(PlcBlock block, FileInfo fileInfo)
        {
            string directoryName = Path.GetDirectoryName(fileInfo.ToString());
            // 如果文件夹不存在，则先创建文件夹
            if ( ! Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }

            // 如果文件已经存在，删除后重新导出
            if (fileInfo.Exists)
            {                
                fileInfo.Delete();                
            }
            // 导出块到xml
            block.Export(fileInfo, ExportOptions.WithDefaults);
        }
    }
}
