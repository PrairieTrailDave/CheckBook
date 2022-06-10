
namespace CheckBook
{
    partial class ChangeTransactionValueForm
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
            this.DoneButton = new System.Windows.Forms.Button();
            this.EntriesDataGridView = new System.Windows.Forms.DataGridView();
            this.UpdatePanel = new System.Windows.Forms.Panel();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.NewValueTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OldValueTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.EntriesDataGridView)).BeginInit();
            this.UpdatePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(505, 15);
            this.label1.TabIndex = 19;
            this.label1.Text = "Select a transaction to change  - Only transactions that have not been cleared ma" +
    "y be changed";
            // 
            // DoneButton
            // 
            this.DoneButton.Location = new System.Drawing.Point(93, 385);
            this.DoneButton.Margin = new System.Windows.Forms.Padding(2);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(78, 20);
            this.DoneButton.TabIndex = 18;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // EntriesDataGridView
            // 
            this.EntriesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EntriesDataGridView.Location = new System.Drawing.Point(45, 75);
            this.EntriesDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.EntriesDataGridView.Name = "EntriesDataGridView";
            this.EntriesDataGridView.RowHeadersWidth = 62;
            this.EntriesDataGridView.RowTemplate.Height = 33;
            this.EntriesDataGridView.Size = new System.Drawing.Size(557, 264);
            this.EntriesDataGridView.TabIndex = 17;
            this.EntriesDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EntriesDataGridView_CellClick);
            // 
            // UpdatePanel
            // 
            this.UpdatePanel.Controls.Add(this.UpdateButton);
            this.UpdatePanel.Controls.Add(this.NewValueTextBox);
            this.UpdatePanel.Controls.Add(this.label3);
            this.UpdatePanel.Controls.Add(this.OldValueTextBox);
            this.UpdatePanel.Controls.Add(this.label2);
            this.UpdatePanel.Location = new System.Drawing.Point(646, 119);
            this.UpdatePanel.Name = "UpdatePanel";
            this.UpdatePanel.Size = new System.Drawing.Size(287, 220);
            this.UpdatePanel.TabIndex = 20;
            this.UpdatePanel.Visible = false;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(116, 158);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateButton.TabIndex = 4;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // NewValueTextBox
            // 
            this.NewValueTextBox.Location = new System.Drawing.Point(112, 90);
            this.NewValueTextBox.Name = "NewValueTextBox";
            this.NewValueTextBox.Size = new System.Drawing.Size(100, 23);
            this.NewValueTextBox.TabIndex = 3;
            this.NewValueTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NewValueTextBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "New Value:";
            // 
            // OldValueTextBox
            // 
            this.OldValueTextBox.Location = new System.Drawing.Point(112, 42);
            this.OldValueTextBox.Name = "OldValueTextBox";
            this.OldValueTextBox.ReadOnly = true;
            this.OldValueTextBox.Size = new System.Drawing.Size(100, 23);
            this.OldValueTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Old Value:";
            // 
            // ChangeTransactionValueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 456);
            this.Controls.Add(this.UpdatePanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.EntriesDataGridView);
            this.Name = "ChangeTransactionValueForm";
            this.Text = "Change Transaction Value";
            this.Shown += new System.EventHandler(this.ChangeTransactionValueForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.EntriesDataGridView)).EndInit();
            this.UpdatePanel.ResumeLayout(false);
            this.UpdatePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.DataGridView EntriesDataGridView;
        private System.Windows.Forms.Panel UpdatePanel;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.TextBox NewValueTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox OldValueTextBox;
        private System.Windows.Forms.Label label2;
    }
}