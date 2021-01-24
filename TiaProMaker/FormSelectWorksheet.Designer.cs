namespace TiaProMaker
{
    partial class FormSelectWorksheet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkedListBox_SelectWorksheet = new System.Windows.Forms.CheckedListBox();
            this.btn_ConfimSelection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedListBox_SelectWorksheet
            // 
            this.checkedListBox_SelectWorksheet.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkedListBox_SelectWorksheet.FormattingEnabled = true;
            this.checkedListBox_SelectWorksheet.Location = new System.Drawing.Point(12, 24);
            this.checkedListBox_SelectWorksheet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkedListBox_SelectWorksheet.Name = "checkedListBox_SelectWorksheet";
            this.checkedListBox_SelectWorksheet.Size = new System.Drawing.Size(370, 395);
            this.checkedListBox_SelectWorksheet.TabIndex = 0;
            this.checkedListBox_SelectWorksheet.SelectedIndexChanged += new System.EventHandler(this.checkedListBox_SelectWorksheet_SelectedIndexChanged);
            // 
            // btn_ConfimSelection
            // 
            this.btn_ConfimSelection.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ConfimSelection.Location = new System.Drawing.Point(12, 442);
            this.btn_ConfimSelection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_ConfimSelection.Name = "btn_ConfimSelection";
            this.btn_ConfimSelection.Size = new System.Drawing.Size(370, 60);
            this.btn_ConfimSelection.TabIndex = 1;
            this.btn_ConfimSelection.Text = "OK";
            this.btn_ConfimSelection.UseVisualStyleBackColor = true;
            this.btn_ConfimSelection.Click += new System.EventHandler(this.btn_ConfimSelect_Click);
            // 
            // FormSelectWorksheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 523);
            this.Controls.Add(this.btn_ConfimSelection);
            this.Controls.Add(this.checkedListBox_SelectWorksheet);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormSelectWorksheet";
            this.Text = "请选择一个工作表";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox_SelectWorksheet;
        private System.Windows.Forms.Button btn_ConfimSelection;
    }
}