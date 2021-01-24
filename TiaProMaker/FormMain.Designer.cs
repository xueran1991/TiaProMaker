namespace TiaProMaker
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btn_ReadExcel = new System.Windows.Forms.Button();
            this.listBox_Main = new System.Windows.Forms.ListBox();
            this.btn_ConnectToTiaProject = new System.Windows.Forms.Button();
            this.txt_Status = new System.Windows.Forms.TextBox();
            this.btn_ClearListbox = new System.Windows.Forms.Button();
            this.btn_EnumBlockGroupsAndBlocks = new System.Windows.Forms.Button();
            this.btn_ExportBlockXml = new System.Windows.Forms.Button();
            this.btn_ImportFC = new System.Windows.Forms.Button();
            this.btn_ImportDBs = new System.Windows.Forms.Button();
            this.txtBox_XmlFolderPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ChoseXmlFolder = new System.Windows.Forms.Button();
            this.btn_ImportFB = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_ImportDBsWhenIMportFC = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_ReadExcel
            // 
            this.btn_ReadExcel.Location = new System.Drawing.Point(826, 691);
            this.btn_ReadExcel.Name = "btn_ReadExcel";
            this.btn_ReadExcel.Size = new System.Drawing.Size(160, 35);
            this.btn_ReadExcel.TabIndex = 0;
            this.btn_ReadExcel.Text = "Read Excel file";
            this.btn_ReadExcel.UseVisualStyleBackColor = true;
            this.btn_ReadExcel.Click += new System.EventHandler(this.btn_ReadExcel_Click);
            // 
            // listBox_Main
            // 
            this.listBox_Main.FormattingEnabled = true;
            this.listBox_Main.ItemHeight = 18;
            this.listBox_Main.Location = new System.Drawing.Point(27, 24);
            this.listBox_Main.Name = "listBox_Main";
            this.listBox_Main.Size = new System.Drawing.Size(959, 400);
            this.listBox_Main.TabIndex = 1;
            this.listBox_Main.ValueMemberChanged += new System.EventHandler(this.listBox_Main_SelectedValueChanged);
            this.listBox_Main.SelectedValueChanged += new System.EventHandler(this.listBox_Main_SelectedValueChanged);
            // 
            // btn_ConnectToTiaProject
            // 
            this.btn_ConnectToTiaProject.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ConnectToTiaProject.Location = new System.Drawing.Point(27, 443);
            this.btn_ConnectToTiaProject.Name = "btn_ConnectToTiaProject";
            this.btn_ConnectToTiaProject.Size = new System.Drawing.Size(130, 58);
            this.btn_ConnectToTiaProject.TabIndex = 2;
            this.btn_ConnectToTiaProject.Text = "Connect To Tia Project";
            this.btn_ConnectToTiaProject.UseVisualStyleBackColor = true;
            this.btn_ConnectToTiaProject.Click += new System.EventHandler(this.btn_ConnectToTiaProject_Click);
            // 
            // txt_Status
            // 
            this.txt_Status.Location = new System.Drawing.Point(27, 566);
            this.txt_Status.Name = "txt_Status";
            this.txt_Status.Size = new System.Drawing.Size(959, 28);
            this.txt_Status.TabIndex = 3;
            // 
            // btn_ClearListbox
            // 
            this.btn_ClearListbox.Location = new System.Drawing.Point(992, 24);
            this.btn_ClearListbox.Name = "btn_ClearListbox";
            this.btn_ClearListbox.Size = new System.Drawing.Size(94, 39);
            this.btn_ClearListbox.TabIndex = 5;
            this.btn_ClearListbox.Text = "Clear";
            this.btn_ClearListbox.UseVisualStyleBackColor = true;
            this.btn_ClearListbox.Click += new System.EventHandler(this.btn_ClearListbox_Click);
            // 
            // btn_EnumBlockGroupsAndBlocks
            // 
            this.btn_EnumBlockGroupsAndBlocks.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_EnumBlockGroupsAndBlocks.Location = new System.Drawing.Point(192, 443);
            this.btn_EnumBlockGroupsAndBlocks.Name = "btn_EnumBlockGroupsAndBlocks";
            this.btn_EnumBlockGroupsAndBlocks.Size = new System.Drawing.Size(134, 65);
            this.btn_EnumBlockGroupsAndBlocks.TabIndex = 7;
            this.btn_EnumBlockGroupsAndBlocks.Text = "Read Program Blocks";
            this.btn_EnumBlockGroupsAndBlocks.UseVisualStyleBackColor = true;
            this.btn_EnumBlockGroupsAndBlocks.Click += new System.EventHandler(this.btn_EnumBlockGroupsAndBlocks_Click);
            // 
            // btn_ExportBlockXml
            // 
            this.btn_ExportBlockXml.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ExportBlockXml.Location = new System.Drawing.Point(357, 443);
            this.btn_ExportBlockXml.Name = "btn_ExportBlockXml";
            this.btn_ExportBlockXml.Size = new System.Drawing.Size(134, 65);
            this.btn_ExportBlockXml.TabIndex = 8;
            this.btn_ExportBlockXml.Text = "Export Xml";
            this.btn_ExportBlockXml.UseVisualStyleBackColor = true;
            this.btn_ExportBlockXml.Click += new System.EventHandler(this.btn_ExportBlockXml_Click);
            // 
            // btn_ImportFC
            // 
            this.btn_ImportFC.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ImportFC.Location = new System.Drawing.Point(522, 443);
            this.btn_ImportFC.Name = "btn_ImportFC";
            this.btn_ImportFC.Size = new System.Drawing.Size(134, 65);
            this.btn_ImportFC.TabIndex = 9;
            this.btn_ImportFC.Text = "Import FC";
            this.btn_ImportFC.UseVisualStyleBackColor = true;
            this.btn_ImportFC.Click += new System.EventHandler(this.btn_ImportFC_Click);
            // 
            // btn_ImportDBs
            // 
            this.btn_ImportDBs.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ImportDBs.Location = new System.Drawing.Point(852, 443);
            this.btn_ImportDBs.Name = "btn_ImportDBs";
            this.btn_ImportDBs.Size = new System.Drawing.Size(134, 65);
            this.btn_ImportDBs.TabIndex = 9;
            this.btn_ImportDBs.Text = "Import DBs";
            this.btn_ImportDBs.UseVisualStyleBackColor = true;
            this.btn_ImportDBs.Click += new System.EventHandler(this.btn_ImportDBs_Click);
            // 
            // txtBox_XmlFolderPath
            // 
            this.txtBox_XmlFolderPath.Location = new System.Drawing.Point(27, 696);
            this.txtBox_XmlFolderPath.Name = "txtBox_XmlFolderPath";
            this.txtBox_XmlFolderPath.ReadOnly = true;
            this.txtBox_XmlFolderPath.Size = new System.Drawing.Size(459, 28);
            this.txtBox_XmlFolderPath.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 674);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = "Xmls folder path:";
            // 
            // btn_ChoseXmlFolder
            // 
            this.btn_ChoseXmlFolder.Location = new System.Drawing.Point(492, 695);
            this.btn_ChoseXmlFolder.Name = "btn_ChoseXmlFolder";
            this.btn_ChoseXmlFolder.Size = new System.Drawing.Size(56, 28);
            this.btn_ChoseXmlFolder.TabIndex = 13;
            this.btn_ChoseXmlFolder.Text = "...";
            this.btn_ChoseXmlFolder.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_ChoseXmlFolder.UseVisualStyleBackColor = true;
            this.btn_ChoseXmlFolder.Click += new System.EventHandler(this.btn_ChoseXmlFolder_Click);
            // 
            // btn_ImportFB
            // 
            this.btn_ImportFB.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ImportFB.Location = new System.Drawing.Point(687, 443);
            this.btn_ImportFB.Name = "btn_ImportFB";
            this.btn_ImportFB.Size = new System.Drawing.Size(134, 65);
            this.btn_ImportFB.TabIndex = 14;
            this.btn_ImportFB.Text = "Import FB";
            this.btn_ImportFB.UseVisualStyleBackColor = true;
            this.btn_ImportFB.Click += new System.EventHandler(this.btn_ImportFB_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 545);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 18);
            this.label2.TabIndex = 12;
            this.label2.Text = "Status:";
            // 
            // checkBox_ImportDBsWhenIMportFC
            // 
            this.checkBox_ImportDBsWhenIMportFC.AutoSize = true;
            this.checkBox_ImportDBsWhenIMportFC.Location = new System.Drawing.Point(27, 745);
            this.checkBox_ImportDBsWhenIMportFC.Name = "checkBox_ImportDBsWhenIMportFC";
            this.checkBox_ImportDBsWhenIMportFC.Size = new System.Drawing.Size(367, 22);
            this.checkBox_ImportDBsWhenIMportFC.TabIndex = 15;
            this.checkBox_ImportDBsWhenIMportFC.Text = "Import instance DBs when importing FC";
            this.checkBox_ImportDBsWhenIMportFC.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 811);
            this.Controls.Add(this.checkBox_ImportDBsWhenIMportFC);
            this.Controls.Add(this.btn_ImportFB);
            this.Controls.Add(this.btn_ChoseXmlFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBox_XmlFolderPath);
            this.Controls.Add(this.btn_ImportDBs);
            this.Controls.Add(this.btn_ImportFC);
            this.Controls.Add(this.btn_ExportBlockXml);
            this.Controls.Add(this.btn_EnumBlockGroupsAndBlocks);
            this.Controls.Add(this.btn_ClearListbox);
            this.Controls.Add(this.txt_Status);
            this.Controls.Add(this.btn_ConnectToTiaProject);
            this.Controls.Add(this.listBox_Main);
            this.Controls.Add(this.btn_ReadExcel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tia Project Maker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ReadExcel;
        private System.Windows.Forms.Button btn_ConnectToTiaProject;
        private System.Windows.Forms.Button btn_ClearListbox;
        private System.Windows.Forms.Button btn_EnumBlockGroupsAndBlocks;
        private System.Windows.Forms.ListBox listBox_Main;
        private System.Windows.Forms.TextBox txt_Status;
        private System.Windows.Forms.Button btn_ExportBlockXml;
        private System.Windows.Forms.Button btn_ImportFC;
        private System.Windows.Forms.Button btn_ImportDBs;
        private System.Windows.Forms.TextBox txtBox_XmlFolderPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ChoseXmlFolder;
        private System.Windows.Forms.Button btn_ImportFB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_ImportDBsWhenIMportFC;
    }
}

