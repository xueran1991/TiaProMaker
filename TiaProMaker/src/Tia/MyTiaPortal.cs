using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Engineering;
using Siemens.Engineering.SW;
using Siemens.Engineering.SW.Blocks;
using Siemens.Engineering.HW;
using Siemens.Engineering.HW.Features;

using TiaProMacker;

namespace src.Tia
{
    class MyTiaPortal
    {
        // 
        public static TiaPortal tiaPortal;
        public static TiaPortalProcess tiaPortalProcess;
        public static Project tiaProject;
        public static PlcSoftware plcSoftware;

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
                        //Form1.txt_Status.Text = "No TIA Portal Project was found!";
                        return null ;
                    }
                    tiaProject = tiaPortal.Projects[0];
                    //Form1.txt_Status.Text = tiaPortalProcess.ProjectPath.ToString();
                    return tiaProject;                    
                    
                case 0:
                    //Form1.txt_Status.Text = "No running instance of TIA Portal was found!";
                    return null;
                default:
                    //Form1.txt_Status.Text = "More than one running instance of TIA Portal was found!";
                    return null;
            }
        }

        //断开与TiaPortal的连接
        public static void DisposeTiaPortal()
        {
            tiaPortal.Dispose();           
        }

        //获取Tia项目的软件
        public static PlcSoftware GetPlcSoftware()
        {
            foreach (Device device in tiaProject.Devices)
            {
               if(GetPlcSoftware(device) != null)
                {
                    plcSoftware = GetPlcSoftware(device);
                }
            }
            //Form1.txt_Status.Text = "获得PLC软件："+plcSoftware.Name;
            return plcSoftware;
        }

        //从硬件获取TIA项目的软件
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
        

        //枚举所有块组和包含的块
        public static void EnumAllBlockGroupsAndBlocks()
        {
            foreach (PlcBlock block in plcSoftware.BlockGroup.Blocks)
            {
                // Do something...
                //Form1.listBox_Main.Items.Add(block.Name);
            }
        }

    }
}
