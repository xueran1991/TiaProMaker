namespace TiaProMacker
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_ReadExcel = new System.Windows.Forms.Button();
            this.listBox_Main = new System.Windows.Forms.ListBox();
            this.btn_ConnectToTiaProject = new System.Windows.Forms.Button();
            this.txt_Status = new System.Windows.Forms.TextBox();
            this.btn_DisposeTia = new System.Windows.Forms.Button();
            this.btn_ClearListbox = new System.Windows.Forms.Button();
            this.btn_GetSW_HW = new System.Windows.Forms.Button();
            this.btn_EnumBlockGroupsAndBlocks = new System.Windows.Forms.Button();
            this.btn_ExportBlockXml = new System.Windows.Forms.Button();
            this.btn_ImportFC = new System.Windows.Forms.Button();
            this.btn_ImportDBs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_ReadExcel
            // 
            this.btn_ReadExcel.Location = new System.Drawing.Point(914, 524);
            this.btn_ReadExcel.Name = "btn_ReadExcel";
            this.btn_ReadExcel.Size = new System.Drawing.Size(178, 76);
            this.btn_ReadExcel.TabIndex = 0;
            this.btn_ReadExcel.Text = "Read Excel file";
            this.btn_ReadExcel.UseVisualStyleBackColor = true;
            this.btn_ReadExcel.Click += new System.EventHandler(this.btn_ReadExcel_Click);
            // 
            // listBox_Main
            // 
            this.listBox_Main.FormattingEnabled = true;
            this.listBox_Main.ItemHeight = 18;
            this.listBox_Main.Location = new System.Drawing.Point(51, 21);
            this.listBox_Main.Name = "listBox_Main";
            this.listBox_Main.Size = new System.Drawing.Size(1051, 400);
            this.listBox_Main.TabIndex = 1;
            // 
            // btn_ConnectToTiaProject
            // 
            this.btn_ConnectToTiaProject.Location = new System.Drawing.Point(51, 439);
            this.btn_ConnectToTiaProject.Name = "btn_ConnectToTiaProject";
            this.btn_ConnectToTiaProject.Size = new System.Drawing.Size(128, 66);
            this.btn_ConnectToTiaProject.TabIndex = 2;
            this.btn_ConnectToTiaProject.Text = "Connect To Tia Project";
            this.btn_ConnectToTiaProject.UseVisualStyleBackColor = true;
            this.btn_ConnectToTiaProject.Click += new System.EventHandler(this.btn_ConnectToTiaProject_Click);
            // 
            // txt_Status
            // 
            this.txt_Status.Location = new System.Drawing.Point(51, 618);
            this.txt_Status.Name = "txt_Status";
            this.txt_Status.Size = new System.Drawing.Size(1051, 28);
            this.txt_Status.TabIndex = 3;
            // 
            // btn_DisposeTia
            // 
            this.btn_DisposeTia.Location = new System.Drawing.Point(49, 533);
            this.btn_DisposeTia.Name = "btn_DisposeTia";
            this.btn_DisposeTia.Size = new System.Drawing.Size(130, 58);
            this.btn_DisposeTia.TabIndex = 4;
            this.btn_DisposeTia.Text = "Dispose";
            this.btn_DisposeTia.UseVisualStyleBackColor = true;
            this.btn_DisposeTia.Click += new System.EventHandler(this.btn_DisposeTia_Click);
            // 
            // btn_ClearListbox
            // 
            this.btn_ClearListbox.Location = new System.Drawing.Point(1108, 21);
            this.btn_ClearListbox.Name = "btn_ClearListbox";
            this.btn_ClearListbox.Size = new System.Drawing.Size(94, 39);
            this.btn_ClearListbox.TabIndex = 5;
            this.btn_ClearListbox.Text = "Clear";
            this.btn_ClearListbox.UseVisualStyleBackColor = true;
            this.btn_ClearListbox.Click += new System.EventHandler(this.btn_ClearListbox_Click);
            // 
            // btn_GetSW_HW
            // 
            this.btn_GetSW_HW.Location = new System.Drawing.Point(239, 439);
            this.btn_GetSW_HW.Name = "btn_GetSW_HW";
            this.btn_GetSW_HW.Size = new System.Drawing.Size(98, 66);
            this.btn_GetSW_HW.TabIndex = 6;
            this.btn_GetSW_HW.Text = "Get HW SW";
            this.btn_GetSW_HW.UseVisualStyleBackColor = true;
            this.btn_GetSW_HW.Click += new System.EventHandler(this.btn_GetSW_HW_Click);
            // 
            // btn_EnumBlockGroupsAndBlocks
            // 
            this.btn_EnumBlockGroupsAndBlocks.Location = new System.Drawing.Point(241, 533);
            this.btn_EnumBlockGroupsAndBlocks.Name = "btn_EnumBlockGroupsAndBlocks";
            this.btn_EnumBlockGroupsAndBlocks.Size = new System.Drawing.Size(96, 58);
            this.btn_EnumBlockGroupsAndBlocks.TabIndex = 7;
            this.btn_EnumBlockGroupsAndBlocks.Text = "Enum All Blocks";
            this.btn_EnumBlockGroupsAndBlocks.UseVisualStyleBackColor = true;
            this.btn_EnumBlockGroupsAndBlocks.Click += new System.EventHandler(this.btn_EnumBlockGroupsAndBlocks_Click);
            // 
            // btn_ExportBlockXml
            // 
            this.btn_ExportBlockXml.Location = new System.Drawing.Point(403, 439);
            this.btn_ExportBlockXml.Name = "btn_ExportBlockXml";
            this.btn_ExportBlockXml.Size = new System.Drawing.Size(118, 65);
            this.btn_ExportBlockXml.TabIndex = 8;
            this.btn_ExportBlockXml.Text = "Export Xml";
            this.btn_ExportBlockXml.UseVisualStyleBackColor = true;
            this.btn_ExportBlockXml.Click += new System.EventHandler(this.btn_ExportBlockXml_Click);
            // 
            // btn_ImportFC
            // 
            this.btn_ImportFC.Location = new System.Drawing.Point(577, 439);
            this.btn_ImportFC.Name = "btn_ImportFC";
            this.btn_ImportFC.Size = new System.Drawing.Size(134, 65);
            this.btn_ImportFC.TabIndex = 9;
            this.btn_ImportFC.Text = "Import FC";
            this.btn_ImportFC.UseVisualStyleBackColor = true;
            this.btn_ImportFC.Click += new System.EventHandler(this.btn_ImportFC_Click);
            // 
            // btn_ImportDBs
            // 
            this.btn_ImportDBs.Location = new System.Drawing.Point(577, 524);
            this.btn_ImportDBs.Name = "btn_ImportDBs";
            this.btn_ImportDBs.Size = new System.Drawing.Size(134, 65);
            this.btn_ImportDBs.TabIndex = 9;
            this.btn_ImportDBs.Text = "Import DBs";
            this.btn_ImportDBs.UseVisualStyleBackColor = true;
            this.btn_ImportDBs.Click += new System.EventHandler(this.btn_ImportDBs_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 680);
            this.Controls.Add(this.btn_ImportDBs);
            this.Controls.Add(this.btn_ImportFC);
            this.Controls.Add(this.btn_ExportBlockXml);
            this.Controls.Add(this.btn_EnumBlockGroupsAndBlocks);
            this.Controls.Add(this.btn_GetSW_HW);
            this.Controls.Add(this.btn_ClearListbox);
            this.Controls.Add(this.btn_DisposeTia);
            this.Controls.Add(this.txt_Status);
            this.Controls.Add(this.btn_ConnectToTiaProject);
            this.Controls.Add(this.listBox_Main);
            this.Controls.Add(this.btn_ReadExcel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ReadExcel;
        private System.Windows.Forms.Button btn_ConnectToTiaProject;
        private System.Windows.Forms.Button btn_DisposeTia;
        private System.Windows.Forms.Button btn_ClearListbox;
        private System.Windows.Forms.Button btn_GetSW_HW;
        private System.Windows.Forms.Button btn_EnumBlockGroupsAndBlocks;
        private System.Windows.Forms.ListBox listBox_Main;
        private System.Windows.Forms.TextBox txt_Status;
        private System.Windows.Forms.Button btn_ExportBlockXml;
        private System.Windows.Forms.Button btn_ImportFC;
        private System.Windows.Forms.Button btn_ImportDBs;
    }
}

