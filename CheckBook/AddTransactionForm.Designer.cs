
namespace CheckBook
{
    partial class AddTransactionForm
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
            this.CheckNumberTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ToWhomTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CheckAmountTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DepositTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CurrentBalanceTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.PriorBalanceTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CategoriesComboBox = new System.Windows.Forms.ComboBox();
            this.SplitCategoryButton = new System.Windows.Forms.Button();
            this.MatchingListBox = new System.Windows.Forms.ListBox();
            this.DetailDataGridView = new System.Windows.Forms.DataGridView();
            this.DoneButton = new System.Windows.Forms.Button();
            this.DetailInputPanel = new System.Windows.Forms.Panel();
            this.ItemCancelButton = new System.Windows.Forms.Button();
            this.ItemClearButton = new System.Windows.Forms.Button();
            this.ItemAmountTextBox = new System.Windows.Forms.TextBox();
            this.ItemNotesTextBox = new System.Windows.Forms.TextBox();
            this.CategoryListBox = new System.Windows.Forms.ListBox();
            this.TransactionDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.DetailTotalLabel = new System.Windows.Forms.Label();
            this.DetailTotalTextBox = new System.Windows.Forms.TextBox();
            this.DeleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DetailDataGridView)).BeginInit();
            this.DetailInputPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date";
            // 
            // CheckNumberTextBox
            // 
            this.CheckNumberTextBox.Location = new System.Drawing.Point(162, 60);
            this.CheckNumberTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.CheckNumberTextBox.Name = "CheckNumberTextBox";
            this.CheckNumberTextBox.Size = new System.Drawing.Size(59, 23);
            this.CheckNumberTextBox.TabIndex = 2;
            this.CheckNumberTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckNumberTextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Check #";
            // 
            // ToWhomTextBox
            // 
            this.ToWhomTextBox.Location = new System.Drawing.Point(225, 60);
            this.ToWhomTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ToWhomTextBox.Name = "ToWhomTextBox";
            this.ToWhomTextBox.Size = new System.Drawing.Size(261, 23);
            this.ToWhomTextBox.TabIndex = 4;
            this.ToWhomTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ToWhomTextBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 43);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "To Whom";
            // 
            // CheckAmountTextBox
            // 
            this.CheckAmountTextBox.Location = new System.Drawing.Point(489, 60);
            this.CheckAmountTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.CheckAmountTextBox.Name = "CheckAmountTextBox";
            this.CheckAmountTextBox.Size = new System.Drawing.Size(106, 23);
            this.CheckAmountTextBox.TabIndex = 6;
            this.CheckAmountTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckAmountTextBox_KeyPress);
            this.CheckAmountTextBox.Leave += new System.EventHandler(this.CheckAmountTextBox_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(489, 43);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Check Amt";
            // 
            // DepositTextBox
            // 
            this.DepositTextBox.Location = new System.Drawing.Point(598, 60);
            this.DepositTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.DepositTextBox.Name = "DepositTextBox";
            this.DepositTextBox.Size = new System.Drawing.Size(97, 23);
            this.DepositTextBox.TabIndex = 8;
            this.DepositTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DepositTextBox_KeyPress);
            this.DepositTextBox.Leave += new System.EventHandler(this.DepositTextBox_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(598, 43);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Deposit Amt";
            // 
            // CurrentBalanceTextBox
            // 
            this.CurrentBalanceTextBox.Location = new System.Drawing.Point(699, 60);
            this.CurrentBalanceTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.CurrentBalanceTextBox.Name = "CurrentBalanceTextBox";
            this.CurrentBalanceTextBox.Size = new System.Drawing.Size(106, 23);
            this.CurrentBalanceTextBox.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(699, 19);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Checkbook Balance";
            // 
            // PriorBalanceTextBox
            // 
            this.PriorBalanceTextBox.Location = new System.Drawing.Point(699, 41);
            this.PriorBalanceTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.PriorBalanceTextBox.Name = "PriorBalanceTextBox";
            this.PriorBalanceTextBox.Size = new System.Drawing.Size(106, 23);
            this.PriorBalanceTextBox.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(162, 84);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Category:";
            // 
            // CategoriesComboBox
            // 
            this.CategoriesComboBox.FormattingEnabled = true;
            this.CategoriesComboBox.Location = new System.Drawing.Point(225, 82);
            this.CategoriesComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.CategoriesComboBox.Name = "CategoriesComboBox";
            this.CategoriesComboBox.Size = new System.Drawing.Size(261, 23);
            this.CategoriesComboBox.TabIndex = 15;
            // 
            // SplitCategoryButton
            // 
            this.SplitCategoryButton.Location = new System.Drawing.Point(53, 84);
            this.SplitCategoryButton.Margin = new System.Windows.Forms.Padding(2);
            this.SplitCategoryButton.Name = "SplitCategoryButton";
            this.SplitCategoryButton.Size = new System.Drawing.Size(105, 20);
            this.SplitCategoryButton.TabIndex = 16;
            this.SplitCategoryButton.Text = "Split Category";
            this.SplitCategoryButton.UseVisualStyleBackColor = true;
            this.SplitCategoryButton.Click += new System.EventHandler(this.SplitCategoryButton_Click);
            // 
            // MatchingListBox
            // 
            this.MatchingListBox.FormattingEnabled = true;
            this.MatchingListBox.ItemHeight = 15;
            this.MatchingListBox.Location = new System.Drawing.Point(232, 82);
            this.MatchingListBox.Margin = new System.Windows.Forms.Padding(2);
            this.MatchingListBox.Name = "MatchingListBox";
            this.MatchingListBox.Size = new System.Drawing.Size(261, 79);
            this.MatchingListBox.TabIndex = 17;
            this.MatchingListBox.Visible = false;
            this.MatchingListBox.Click += new System.EventHandler(this.MatchingListBox_Click);
            // 
            // DetailDataGridView
            // 
            this.DetailDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DetailDataGridView.Location = new System.Drawing.Point(53, 108);
            this.DetailDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.DetailDataGridView.Name = "DetailDataGridView";
            this.DetailDataGridView.RowHeadersWidth = 62;
            this.DetailDataGridView.RowTemplate.Height = 33;
            this.DetailDataGridView.Size = new System.Drawing.Size(681, 361);
            this.DetailDataGridView.TabIndex = 18;
            this.DetailDataGridView.Visible = false;
            this.DetailDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DetailDataGridView_CellClick);
            // 
            // DoneButton
            // 
            this.DoneButton.Location = new System.Drawing.Point(686, 81);
            this.DoneButton.Margin = new System.Windows.Forms.Padding(2);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(78, 20);
            this.DoneButton.TabIndex = 19;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // DetailInputPanel
            // 
            this.DetailInputPanel.Controls.Add(this.DeleteButton);
            this.DetailInputPanel.Controls.Add(this.ItemCancelButton);
            this.DetailInputPanel.Controls.Add(this.ItemClearButton);
            this.DetailInputPanel.Controls.Add(this.ItemAmountTextBox);
            this.DetailInputPanel.Controls.Add(this.ItemNotesTextBox);
            this.DetailInputPanel.Controls.Add(this.CategoryListBox);
            this.DetailInputPanel.Location = new System.Drawing.Point(53, 202);
            this.DetailInputPanel.Margin = new System.Windows.Forms.Padding(2);
            this.DetailInputPanel.Name = "DetailInputPanel";
            this.DetailInputPanel.Size = new System.Drawing.Size(556, 186);
            this.DetailInputPanel.TabIndex = 20;
            this.DetailInputPanel.Visible = false;
            // 
            // ItemCancelButton
            // 
            this.ItemCancelButton.Location = new System.Drawing.Point(339, 97);
            this.ItemCancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.ItemCancelButton.Name = "ItemCancelButton";
            this.ItemCancelButton.Size = new System.Drawing.Size(78, 20);
            this.ItemCancelButton.TabIndex = 4;
            this.ItemCancelButton.Text = "Cancel";
            this.ItemCancelButton.UseVisualStyleBackColor = true;
            this.ItemCancelButton.Click += new System.EventHandler(this.ItemCancelButton_Click);
            // 
            // ItemClearButton
            // 
            this.ItemClearButton.Location = new System.Drawing.Point(249, 97);
            this.ItemClearButton.Margin = new System.Windows.Forms.Padding(2);
            this.ItemClearButton.Name = "ItemClearButton";
            this.ItemClearButton.Size = new System.Drawing.Size(78, 20);
            this.ItemClearButton.TabIndex = 3;
            this.ItemClearButton.Text = "Clear";
            this.ItemClearButton.UseVisualStyleBackColor = true;
            this.ItemClearButton.Click += new System.EventHandler(this.ItemClearButton_Click);
            // 
            // ItemAmountTextBox
            // 
            this.ItemAmountTextBox.Location = new System.Drawing.Point(407, 10);
            this.ItemAmountTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ItemAmountTextBox.Name = "ItemAmountTextBox";
            this.ItemAmountTextBox.Size = new System.Drawing.Size(136, 23);
            this.ItemAmountTextBox.TabIndex = 2;
            this.ItemAmountTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ItemAmountTextBox_KeyPress);
            this.ItemAmountTextBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ItemAmountTextBox_PreviewKeyDown);
            // 
            // ItemNotesTextBox
            // 
            this.ItemNotesTextBox.Location = new System.Drawing.Point(180, 10);
            this.ItemNotesTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ItemNotesTextBox.Name = "ItemNotesTextBox";
            this.ItemNotesTextBox.Size = new System.Drawing.Size(223, 23);
            this.ItemNotesTextBox.TabIndex = 1;
            // 
            // CategoryListBox
            // 
            this.CategoryListBox.FormattingEnabled = true;
            this.CategoryListBox.ItemHeight = 15;
            this.CategoryListBox.Location = new System.Drawing.Point(2, 10);
            this.CategoryListBox.Margin = new System.Windows.Forms.Padding(2);
            this.CategoryListBox.Name = "CategoryListBox";
            this.CategoryListBox.Size = new System.Drawing.Size(174, 169);
            this.CategoryListBox.TabIndex = 0;
            // 
            // TransactionDateTimePicker
            // 
            this.TransactionDateTimePicker.CustomFormat = "MM/dd/yyyy";
            this.TransactionDateTimePicker.Location = new System.Drawing.Point(53, 59);
            this.TransactionDateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.TransactionDateTimePicker.Name = "TransactionDateTimePicker";
            this.TransactionDateTimePicker.Size = new System.Drawing.Size(106, 23);
            this.TransactionDateTimePicker.TabIndex = 21;
            // 
            // DetailTotalLabel
            // 
            this.DetailTotalLabel.AutoSize = true;
            this.DetailTotalLabel.Location = new System.Drawing.Point(603, 484);
            this.DetailTotalLabel.Name = "DetailTotalLabel";
            this.DetailTotalLabel.Size = new System.Drawing.Size(68, 15);
            this.DetailTotalLabel.TabIndex = 22;
            this.DetailTotalLabel.Text = "Detail Total:";
            this.DetailTotalLabel.Visible = false;
            // 
            // DetailTotalTextBox
            // 
            this.DetailTotalTextBox.Location = new System.Drawing.Point(634, 502);
            this.DetailTotalTextBox.Name = "DetailTotalTextBox";
            this.DetailTotalTextBox.Size = new System.Drawing.Size(100, 23);
            this.DetailTotalTextBox.TabIndex = 23;
            this.DetailTotalTextBox.Visible = false;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(457, 156);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 5;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // AddTransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 687);
            this.Controls.Add(this.DetailTotalTextBox);
            this.Controls.Add(this.DetailTotalLabel);
            this.Controls.Add(this.TransactionDateTimePicker);
            this.Controls.Add(this.DetailInputPanel);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.DetailDataGridView);
            this.Controls.Add(this.MatchingListBox);
            this.Controls.Add(this.SplitCategoryButton);
            this.Controls.Add(this.CategoriesComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.PriorBalanceTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CurrentBalanceTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DepositTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CheckAmountTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ToWhomTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CheckNumberTextBox);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AddTransactionForm";
            this.Text = "AddTransaction";
            this.Activated += new System.EventHandler(this.AddTransactionForm_Activated);
            this.Shown += new System.EventHandler(this.AddTransactionForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DetailDataGridView)).EndInit();
            this.DetailInputPanel.ResumeLayout(false);
            this.DetailInputPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CheckNumberTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ToWhomTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CheckAmountTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox DepositTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox CurrentBalanceTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox PriorBalanceTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CategoriesComboBox;
        private System.Windows.Forms.Button SplitCategoryButton;
        private System.Windows.Forms.ListBox MatchingListBox;
        private System.Windows.Forms.DataGridView DetailDataGridView;
        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.Panel DetailInputPanel;
        private System.Windows.Forms.TextBox ItemAmountTextBox;
        private System.Windows.Forms.TextBox ItemNotesTextBox;
        private System.Windows.Forms.ListBox CategoryListBox;
        private System.Windows.Forms.Button ItemClearButton;
        private System.Windows.Forms.Button ItemCancelButton;
        private System.Windows.Forms.DateTimePicker TransactionDateTimePicker;
        private System.Windows.Forms.Label DetailTotalLabel;
        private System.Windows.Forms.TextBox DetailTotalTextBox;
        private System.Windows.Forms.Button DeleteButton;
    }
}