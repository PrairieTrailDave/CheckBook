using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckBook
{
    public partial class AddTransactionForm : Form
    {
        // variables filled from the main window
        public MyCheckbook ActiveBook { get; set; }
        public decimal PriorBalance { get; set; }
        public int LastCheckNumber { get; set; }

        // variable sent back to the main window
        public LedgerEntry tEntry { get; set; }
        public bool newEntry { get; set; }

        // Internal Variables

        decimal TransactionDebit = 0.00M;
        decimal TransactionCredit = 0.00M;

        public AddTransactionForm()
        {
            InitializeComponent();
            TransactionDateTimePicker.Format = DateTimePickerFormat.Custom;
        }



        private void AddTransactionForm_Activated(object sender, EventArgs e)
        {
            // clear out what we are to return
            tEntry = new LedgerEntry();
            newEntry = false;
            TransactionCredit = 0.00M;
            TransactionDebit = 0.00M;
        }


        private void AddTransactionForm_Shown(object sender, EventArgs e)
        {
            // load the forms 

            PriorBalance = ActiveBook.CurrentLedger[ActiveBook.CurrentLedger.Count - 1].Balance;
            string sLastCheckNumber = (from ch in ActiveBook.CurrentLedger
                                      where ch.CheckNumber.Length > 0
                                         && Char.IsDigit(ch.CheckNumber[0])
                                      orderby ch.CheckNumber descending
                                      select ch.CheckNumber).First();
            LastCheckNumber = Int32.Parse(sLastCheckNumber);

            TransactionDateTimePicker.Value = DateTime.Now;
            PriorBalanceTextBox.Text = PriorBalance.ToString("C");
            List<string> Categories = (from ct in ActiveBook.Accounts
                                       select ct.Name).ToList();
            CategoriesComboBox.DataSource = Categories;
            CategoryListBox.Items.Clear();
            foreach (string cat in Categories)
                CategoryListBox.Items.Add(cat);


        }

        private void CheckNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '+')
            {
                CheckNumberTextBox.Text = (LastCheckNumber + 1).ToString();
                e.Handled = true;
            }
        }

        private void ToWhomTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            List<string> PossibleNames = (from ch in ActiveBook.CurrentLedger
                                          where ch.ToWhom.ToUpper().StartsWith((ToWhomTextBox.Text + e.KeyChar).ToUpper())
                                             && ch.When.AddYears(1) > DateTime.Now
                                          orderby ch.ToWhom
                                          select ch.ToWhom).Distinct().ToList();
            if (PossibleNames.Count > 0)
            {
                MatchingListBox.DataSource = PossibleNames;
                MatchingListBox.Visible = true;
            }
            else
                MatchingListBox.Visible = false;
        }

        private void MatchingListBox_Click(object sender, EventArgs e)
        {
            int ListRow = MatchingListBox.SelectedIndex;
            string MatchedName = (string)MatchingListBox.SelectedItem;
            ToWhomTextBox.Text = MatchedName;
            MatchingListBox.Visible = false;

            // find the last transaction to this payee and autofill the form

            LedgerEntry LastTransaction = (from ch in ActiveBook.CurrentLedger
                                          where ch.ToWhom == MatchedName
                                             && ch.When.AddYears(1) > DateTime.Now
                                          orderby ch.When descending
                                          select ch).FirstOrDefault();

            CheckAmountTextBox.Text = LastTransaction.Debit.ToString();
            DepositTextBox.Text = LastTransaction.Credit.ToString();
            CategoriesComboBox.Text = LastTransaction.Account;
            if (LastTransaction.SubAccounts != null)
            {
                if (LastTransaction.SubAccounts.Count > 0)
                {
                    int subi = 0;
                    List<CategoryEntry> tSubAccounts = new List<CategoryEntry>();

                    while (subi < LastTransaction.SubAccounts.Count)
                    {
                        CategoryEntry tEntry = new CategoryEntry
                        {
                            AccountName = LastTransaction.SubAccounts[subi].AccountName,
                            Notes = LastTransaction.SubAccounts[subi].Notes,
                            Amount = 0.00M - LastTransaction.SubAccounts[subi].Amount
                        };
                        tSubAccounts.Add(tEntry);
                        subi++;
                    }
                    DetailDataGridView.DataSource = tSubAccounts;
                    DetailDataGridView.AutoResizeColumn(0);
                    DetailDataGridView.Columns[1].Width = 350;
                    DetailDataGridView.Visible = true;
                }
            }
            CheckAmountTextBox.Focus();
        }

        private void CheckAmountTextBox_Leave(object sender, EventArgs e)
        {
            if (CheckAmountTextBox.Text.Length > 0)
            {
                decimal Amount = Decimal.Parse(CheckAmountTextBox.Text);
                TransactionDebit = Amount;
                CheckAmountTextBox.Text = Amount.ToString("C");
                CurrentBalanceTextBox.Text = (PriorBalance - Amount).ToString("C");
            }
        }

        private void DepositTextBox_Leave(object sender, EventArgs e)
        {
            if (DepositTextBox.Text.Length > 0)
            {
                decimal Amount = Decimal.Parse(DepositTextBox.Text);
                TransactionCredit = Amount;
                DepositTextBox.Text = Amount.ToString("C");
                CurrentBalanceTextBox.Text = (PriorBalance + Amount).ToString("C");
            }
        }

        private void CheckAmountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsDigit(e.KeyChar)) ||
                (e.KeyChar == '.') ||
                (e.KeyChar == (char)Keys.Back))
            {
                if (DepositTextBox.Text.Length > 0)
                    DepositTextBox.Text = "";
                return; 
            }
            e.Handled = true;
        }

        private void DepositTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsDigit(e.KeyChar)) ||
                (e.KeyChar == '.') || 
                (e.KeyChar == (char)Keys.Back))
            {
                if (CheckAmountTextBox.Text.Length > 0)
                    CheckAmountTextBox.Text = "";
                return;
            }
            e.Handled = true;
        }

        private void SplitCategoryButton_Click(object sender, EventArgs e)
        {
            List<CategoryEntry> tSubAccounts = new List<CategoryEntry>();
            for (int i = 0; i < 30; i++)
                tSubAccounts.Add(new CategoryEntry());
            DetailDataGridView.DataSource = tSubAccounts;
            DetailDataGridView.AutoResizeColumn(0);
            DetailDataGridView.Columns[1].Width = 350;
            DetailDataGridView.EditMode = DataGridViewEditMode.EditOnEnter;
            DetailDataGridView.Visible = true;

        }

        private void DetailDataGridView_Enter(object sender, EventArgs e)
        {
            // check to make sure that this is the first empty row in the grid
            int RowNum = 0;
            while (RowNum < DetailDataGridView.RowCount)
            {
                if ((String.IsNullOrEmpty((string)DetailDataGridView.Rows[RowNum].Cells[0].Value)) &&
                    (String.IsNullOrEmpty((string)DetailDataGridView.Rows[RowNum].Cells[1].Value)) &&
                    ((decimal)DetailDataGridView.Rows[RowNum].Cells[2].Value == 0.00M))
                    break;
                RowNum++;
            }
            int trow = DetailDataGridView.SelectedCells[0].RowIndex;
            if (DetailDataGridView.CurrentCell.RowIndex > RowNum)
                DetailDataGridView.CurrentCell = DetailDataGridView.Rows[RowNum].Cells[0];

            // then show the input panel

            ClearItemPanel();
            DetailInputPanel.Location = new Point(DetailDataGridView.Location.X,
                DetailDataGridView.Top + (RowNum+2)*DetailDataGridView.Rows[RowNum].Height);
            DetailInputPanel.Visible = true;

        }

        private void ItemClearButton_Click(object sender, EventArgs e)
        {
            ClearItemPanel();
        }
        private void ItemCancelButton_Click(object sender, EventArgs e)
        {
            DetailInputPanel.Visible = false;
        }

        private void ClearItemPanel ()
        {
            CategoryListBox.SelectedItem = (from act in ActiveBook.Accounts
                                            where act.WhatType == AccountCategory.CategoryType.Expense
                                            select act.Name).FirstOrDefault();
            ItemNotesTextBox.Text = "";
            ItemAmountTextBox.Text = "";
        }

        private void ItemAmountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // only allow amounts to be entered
            if (!((e.KeyChar == '.') || 
                  (e.KeyChar == '-') || 
                  (Char.IsDigit(e.KeyChar)) || 
                  (e.KeyChar == ((char)Keys.Back))))
                e.Handled = true;
        }

        private void ItemAmountTextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                // move the values into the datagrid view
                // find the last empty row
                bool EmptyRowFound = false;
                int RowNum = 0;
                while (RowNum < DetailDataGridView.RowCount)
                {
                    if ((String.IsNullOrEmpty((string)DetailDataGridView.Rows[RowNum].Cells[0].Value)) &&
                        (String.IsNullOrEmpty((string)DetailDataGridView.Rows[RowNum].Cells[1].Value)) &&
                        ((decimal)DetailDataGridView.Rows[RowNum].Cells[2].Value == 0.00M))
                    {
                        EmptyRowFound = true;
                        break;
                    }
                    RowNum++;
                }
                if (EmptyRowFound)
                {
                    DataGridViewRow tRow = DetailDataGridView.Rows[RowNum];
                    tRow.Cells[0].Value = CategoryListBox.SelectedItem;
                    tRow.Cells[1].Value = ItemNotesTextBox.Text;
                    tRow.Cells[2].Value = ItemAmountTextBox.Text;
                }
                else
                {
                    DataGridViewRow nRow = new DataGridViewRow();
                    nRow.Cells[0].Value = CategoryListBox.SelectedItem;
                    nRow.Cells[1].Value = ItemNotesTextBox.Text;
                    nRow.Cells[2].Value = ItemAmountTextBox.Text;
                    DetailDataGridView.Rows.Add(nRow);
                }



                // and hide the input panel

                DetailInputPanel.Visible = false;
            }
        }




        private void DoneButton_Click(object sender, EventArgs e)
        {
            decimal CheckAmount;

            // someone can press the done key without entering a value 
            // because we used the value from the prior transaction

            if ((TransactionCredit == 0.00M) &&
                 TransactionDebit == 0.00M)
            {
                if (DepositTextBox.Text.Length > 0)
                    if (Char.IsDigit(DepositTextBox.Text[0]))
                        Decimal.TryParse(DepositTextBox.Text, out TransactionCredit);
                    else
                        Decimal.TryParse(DepositTextBox.Text.Substring(1), out TransactionCredit);
                if (CheckAmountTextBox.Text.Length > 0)
                    if (Char.IsDigit(CheckAmountTextBox.Text[0]))
                        Decimal.TryParse(CheckAmountTextBox.Text, out TransactionDebit);
                    else
                        Decimal.TryParse(CheckAmountTextBox.Text.Substring(1), out TransactionDebit);
            }

            if (TransactionDebit == 0.00M)
                CheckAmount = TransactionCredit;
            else
                CheckAmount = TransactionDebit;

            List<CategoryEntry> tSubAccounts = null;
            if (DetailDataGridView.Rows.Count > 0)
            {
                tSubAccounts = new List<CategoryEntry>();

                // build the sub accounts

                foreach (DataGridViewRow tRow in DetailDataGridView.Rows)
                {
                    CategoryEntry tEntry = new CategoryEntry();
                    tEntry.AccountName = tRow.Cells[0].Value.ToString();
                    tEntry.Notes = tRow.Cells[1].Value.ToString();
                    string amt = tRow.Cells[2].Value.ToString();
                    decimal EAmt;
                    if (Decimal.TryParse(amt, out EAmt))
                        tEntry.Amount = 0.00M - EAmt;
                    tSubAccounts.Add(tEntry);
                }
            }
            Decimal tBalance;
            if (!Decimal.TryParse(CurrentBalanceTextBox.Text.Substring(1), out tBalance))
            {
                MessageBox.Show("Invalid balance");
                return;
            }

            tEntry = new LedgerEntry
            {
                When = TransactionDateTimePicker.Value.Date,
                CheckNumber = CheckNumberTextBox.Text,
                ToWhom = ToWhomTextBox.Text,
                Cleared = false,
                Debit = TransactionDebit,
                Credit = TransactionCredit,
                Balance = tBalance,
                Amount = CheckAmount,
                Account = (string)CategoriesComboBox.SelectedItem,
                SubAccounts = tSubAccounts
            };

            // say that a new entry is available 

            newEntry = true;
            Close();
        }

    }
}
