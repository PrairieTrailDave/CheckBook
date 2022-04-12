
namespace CheckBook
{
    partial class VoidTransactionForm
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
            this.EntriesDataGridView = new System.Windows.Forms.DataGridView();
            this.DoneButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.EntriesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // EntriesDataGridView
            // 
            this.EntriesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EntriesDataGridView.Location = new System.Drawing.Point(32, 71);
            this.EntriesDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.EntriesDataGridView.Name = "EntriesDataGridView";
            this.EntriesDataGridView.RowHeadersWidth = 62;
            this.EntriesDataGridView.RowTemplate.Height = 33;
            this.EntriesDataGridView.Size = new System.Drawing.Size(557, 264);
            this.EntriesDataGridView.TabIndex = 11;
            this.EntriesDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EntriesDataGridView_CellClick);
            // 
            // DoneButton
            // 
            this.DoneButton.Location = new System.Drawing.Point(80, 381);
            this.DoneButton.Margin = new System.Windows.Forms.Padding(2);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(78, 20);
            this.DoneButton.TabIndex = 14;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(479, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "Select a transaction to void  - Only transactions that have not been cleared may " +
    "be voided";
            // 
            // VoidTransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.EntriesDataGridView);
            this.Name = "VoidTransactionForm";
            this.Text = "Void Transaction";
            this.Shown += new System.EventHandler(this.VoidTransactionForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.EntriesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView EntriesDataGridView;
        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.Label label1;
    }
}