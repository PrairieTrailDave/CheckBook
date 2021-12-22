
namespace CheckBook
{
    partial class DetailReportForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.TimePeriodListBox = new System.Windows.Forms.ListBox();
            this.ReportDataGridView = new System.Windows.Forms.DataGridView();
            this.SaveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select the time period for the report";
            // 
            // TimePeriodListBox
            // 
            this.TimePeriodListBox.FormattingEnabled = true;
            this.TimePeriodListBox.ItemHeight = 15;
            this.TimePeriodListBox.Items.AddRange(new object[] {
            "This Month",
            "Last Month",
            "This Year",
            "Last Year"});
            this.TimePeriodListBox.Location = new System.Drawing.Point(29, 58);
            this.TimePeriodListBox.Name = "TimePeriodListBox";
            this.TimePeriodListBox.Size = new System.Drawing.Size(93, 64);
            this.TimePeriodListBox.TabIndex = 1;
            this.TimePeriodListBox.SelectedIndexChanged += new System.EventHandler(this.TimePeriodListBox_SelectedIndexChanged);
            // 
            // ReportDataGridView
            // 
            this.ReportDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ReportDataGridView.Location = new System.Drawing.Point(128, 73);
            this.ReportDataGridView.Name = "ReportDataGridView";
            this.ReportDataGridView.RowTemplate.Height = 25;
            this.ReportDataGridView.Size = new System.Drawing.Size(708, 773);
            this.ReportDataGridView.TabIndex = 2;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(29, 184);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // DetailReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 970);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ReportDataGridView);
            this.Controls.Add(this.TimePeriodListBox);
            this.Controls.Add(this.label1);
            this.Name = "DetailReportForm";
            this.Text = "Detail Report";
            ((System.ComponentModel.ISupportInitialize)(this.ReportDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox TimePeriodListBox;
        private System.Windows.Forms.DataGridView ReportDataGridView;
        private System.Windows.Forms.Button SaveButton;
    }
}