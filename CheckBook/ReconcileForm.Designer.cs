
namespace CheckBook
{
    partial class ReconcileForm
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
            this.LastReconciledBalanceTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.EndingBalanceTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BankFeesTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.InterestEarnedTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ClearedBalanceTextBox = new System.Windows.Forms.TextBox();
            this.ChecksDataGridView = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.DoneButton = new System.Windows.Forms.Button();
            this.CancelFormButton = new System.Windows.Forms.Button();
            this.DepositsDataGridView = new System.Windows.Forms.DataGridView();
            this.AddMissingTransactionButton = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.ReconciliationDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.AddFeesAndInterestButton = new System.Windows.Forms.Button();
            this.ChangeTransactionValueButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ChecksDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Last Reconciled Balance";
            // 
            // LastReconciledBalanceTextBox
            // 
            this.LastReconciledBalanceTextBox.Location = new System.Drawing.Point(177, 44);
            this.LastReconciledBalanceTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LastReconciledBalanceTextBox.Name = "LastReconciledBalanceTextBox";
            this.LastReconciledBalanceTextBox.ReadOnly = true;
            this.LastReconciledBalanceTextBox.Size = new System.Drawing.Size(106, 23);
            this.LastReconciledBalanceTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ending Balance";
            // 
            // EndingBalanceTextBox
            // 
            this.EndingBalanceTextBox.Location = new System.Drawing.Point(177, 66);
            this.EndingBalanceTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.EndingBalanceTextBox.Name = "EndingBalanceTextBox";
            this.EndingBalanceTextBox.Size = new System.Drawing.Size(106, 23);
            this.EndingBalanceTextBox.TabIndex = 3;
            this.EndingBalanceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EndingBalanceTextBox_KeyPress);
            this.EndingBalanceTextBox.Leave += new System.EventHandler(this.EndingBalanceTextBox_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 90);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bank Fees";
            // 
            // BankFeesTextBox
            // 
            this.BankFeesTextBox.Location = new System.Drawing.Point(177, 88);
            this.BankFeesTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BankFeesTextBox.Name = "BankFeesTextBox";
            this.BankFeesTextBox.Size = new System.Drawing.Size(106, 23);
            this.BankFeesTextBox.TabIndex = 5;
            this.BankFeesTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BankFeesTextBox_KeyPress);
            this.BankFeesTextBox.Leave += new System.EventHandler(this.BankFeesTextBox_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 113);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Interest Earned";
            // 
            // InterestEarnedTextBox
            // 
            this.InterestEarnedTextBox.Location = new System.Drawing.Point(177, 111);
            this.InterestEarnedTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.InterestEarnedTextBox.Name = "InterestEarnedTextBox";
            this.InterestEarnedTextBox.Size = new System.Drawing.Size(106, 23);
            this.InterestEarnedTextBox.TabIndex = 7;
            this.InterestEarnedTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InterestEarnedTextBox_KeyPress);
            this.InterestEarnedTextBox.Leave += new System.EventHandler(this.InterestEarnedTextBox_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 138);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Cleared Balance";
            // 
            // ClearedBalanceTextBox
            // 
            this.ClearedBalanceTextBox.Location = new System.Drawing.Point(177, 138);
            this.ClearedBalanceTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ClearedBalanceTextBox.Name = "ClearedBalanceTextBox";
            this.ClearedBalanceTextBox.ReadOnly = true;
            this.ClearedBalanceTextBox.Size = new System.Drawing.Size(106, 23);
            this.ClearedBalanceTextBox.TabIndex = 9;
            // 
            // ChecksDataGridView
            // 
            this.ChecksDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ChecksDataGridView.Location = new System.Drawing.Point(318, 44);
            this.ChecksDataGridView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ChecksDataGridView.Name = "ChecksDataGridView";
            this.ChecksDataGridView.RowHeadersWidth = 62;
            this.ChecksDataGridView.RowTemplate.Height = 33;
            this.ChecksDataGridView.Size = new System.Drawing.Size(557, 264);
            this.ChecksDataGridView.TabIndex = 10;
            this.ChecksDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ChecksDataGridView_CellClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(438, 25);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Outstanding Transactions";
            // 
            // DoneButton
            // 
            this.DoneButton.Location = new System.Drawing.Point(334, 447);
            this.DoneButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(78, 20);
            this.DoneButton.TabIndex = 12;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // CancelFormButton
            // 
            this.CancelFormButton.Location = new System.Drawing.Point(488, 448);
            this.CancelFormButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CancelFormButton.Name = "CancelFormButton";
            this.CancelFormButton.Size = new System.Drawing.Size(78, 20);
            this.CancelFormButton.TabIndex = 13;
            this.CancelFormButton.Text = "Cancel";
            this.CancelFormButton.UseVisualStyleBackColor = true;
            this.CancelFormButton.Click += new System.EventHandler(this.CancelFormButton_Click);
            // 
            // DepositsDataGridView
            // 
            this.DepositsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DepositsDataGridView.Location = new System.Drawing.Point(892, 44);
            this.DepositsDataGridView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DepositsDataGridView.Name = "DepositsDataGridView";
            this.DepositsDataGridView.RowHeadersWidth = 62;
            this.DepositsDataGridView.RowTemplate.Height = 33;
            this.DepositsDataGridView.Size = new System.Drawing.Size(446, 264);
            this.DepositsDataGridView.TabIndex = 14;
            this.DepositsDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DepositsDataGridView_CellClick);
            // 
            // AddMissingTransactionButton
            // 
            this.AddMissingTransactionButton.Location = new System.Drawing.Point(43, 203);
            this.AddMissingTransactionButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddMissingTransactionButton.Name = "AddMissingTransactionButton";
            this.AddMissingTransactionButton.Size = new System.Drawing.Size(240, 27);
            this.AddMissingTransactionButton.TabIndex = 15;
            this.AddMissingTransactionButton.Text = "Add A Missing Transaction";
            this.AddMissingTransactionButton.UseVisualStyleBackColor = true;
            this.AddMissingTransactionButton.Click += new System.EventHandler(this.AddMissingTransactionButton_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(42, 25);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(109, 15);
            this.label13.TabIndex = 17;
            this.label13.Text = "Reconciliation Date";
            // 
            // ReconciliationDateTimePicker
            // 
            this.ReconciliationDateTimePicker.CustomFormat = "MM/dd/yyyy";
            this.ReconciliationDateTimePicker.Location = new System.Drawing.Point(177, 25);
            this.ReconciliationDateTimePicker.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ReconciliationDateTimePicker.Name = "ReconciliationDateTimePicker";
            this.ReconciliationDateTimePicker.Size = new System.Drawing.Size(106, 23);
            this.ReconciliationDateTimePicker.TabIndex = 18;
            // 
            // AddFeesAndInterestButton
            // 
            this.AddFeesAndInterestButton.Location = new System.Drawing.Point(42, 169);
            this.AddFeesAndInterestButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddFeesAndInterestButton.Name = "AddFeesAndInterestButton";
            this.AddFeesAndInterestButton.Size = new System.Drawing.Size(240, 30);
            this.AddFeesAndInterestButton.TabIndex = 19;
            this.AddFeesAndInterestButton.Text = "Add fees and interest to Ledger";
            this.AddFeesAndInterestButton.UseVisualStyleBackColor = true;
            this.AddFeesAndInterestButton.Click += new System.EventHandler(this.AddFeesAndInterestButton_Click);
            // 
            // ChangeTransactionValueButton
            // 
            this.ChangeTransactionValueButton.Location = new System.Drawing.Point(43, 234);
            this.ChangeTransactionValueButton.Margin = new System.Windows.Forms.Padding(2);
            this.ChangeTransactionValueButton.Name = "ChangeTransactionValueButton";
            this.ChangeTransactionValueButton.Size = new System.Drawing.Size(240, 27);
            this.ChangeTransactionValueButton.TabIndex = 20;
            this.ChangeTransactionValueButton.Text = "Change the value of a transaction";
            this.ChangeTransactionValueButton.UseVisualStyleBackColor = true;
            this.ChangeTransactionValueButton.Click += new System.EventHandler(this.ChangeTransactionValueButton_Click);
            // 
            // ReconcileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1347, 487);
            this.Controls.Add(this.ChangeTransactionValueButton);
            this.Controls.Add(this.AddFeesAndInterestButton);
            this.Controls.Add(this.ReconciliationDateTimePicker);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.AddMissingTransactionButton);
            this.Controls.Add(this.DepositsDataGridView);
            this.Controls.Add(this.CancelFormButton);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ChecksDataGridView);
            this.Controls.Add(this.ClearedBalanceTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.InterestEarnedTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BankFeesTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.EndingBalanceTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LastReconciledBalanceTextBox);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ReconcileForm";
            this.Text = "ReconcileForm";
            this.Shown += new System.EventHandler(this.ReconcileForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ChecksDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox LastReconciledBalanceTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox EndingBalanceTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox BankFeesTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox InterestEarnedTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ClearedBalanceTextBox;
        private System.Windows.Forms.DataGridView ChecksDataGridView;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.Button CancelFormButton;
        private System.Windows.Forms.DataGridView DepositsDataGridView;
        private System.Windows.Forms.Button AddMissingTransactionButton;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker ReconciliationDateTimePicker;
        private System.Windows.Forms.Button AddFeesAndInterestButton;
        private System.Windows.Forms.Button ChangeTransactionValueButton;
    }
}