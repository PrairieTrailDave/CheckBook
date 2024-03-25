//
//  Copyright 2021 David Randolph
//
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
    public partial class ReconcileForm : Form
    {
        class ReconcileRow
        {
            public bool Cleared { get; set; }
            public DateTime When { get; set; }
            public string CheckNumber { get; set; }
            public string ToWhom { get; set; }
            public string Amount { get; set; }
            public int ListID { get; set; }  // change this from the record number to the record ID
        }
        class DepositRow
        {
            public bool Cleared { get; set; }
            public string Date { get; set; }
            public string FromWhom { get; set; }
            public string Amount { get; set; }
            public int ListID { get; set; }  // change this from the record number to the record ID
        }


        // variables filled from the main window
        public MyCheckbook ActiveBook { get; set; }

        // variable sent back to the main window

        // internal variables

        List<ReconcileRow> Checks { get; set; }
        List<DepositRow> Deposits { get; set; }
        public decimal ReconciledBalance { get; set; }
        public decimal ClearedBalance { get; set; }
        public ReconcileForm()
        {
            InitializeComponent();
        }
        private void ReconcileForm_Shown(object sender, EventArgs e)
        {
            LoadGrids();
            // only allow people to click on the cleared column
            ShowChecksAndDeposits();

            // recalculate the current reconciled balance

            ReconciledBalance = (from ch in ActiveBook.CurrentLedger
                                 where ch.Cleared == true &&
                                       ch.Credit > 0.00M
                                 select ch.Credit).Sum()
                                 -(from ch in ActiveBook.CurrentLedger
                                 where ch.Cleared == true &&
                                       ch.Debit > 0.00M
                                 select ch.Debit).Sum();
            LastReconciledBalanceTextBox.Text = ReconciledBalance.ToString("C");
            ReconciliationDateTimePicker.Format = DateTimePickerFormat.Custom;
            ClearedBalance = ReconciledBalance;
            ClearedBalanceTextBox.Text = ClearedBalance.ToString("C");
        }

        private void AddFeesAndInterestButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This button will add transactions to the ledger and the screen.", "", MessageBoxButtons.OKCancel)
                == DialogResult.OK)
            {
                AddFeesAndInterestButton.Enabled = false;
                DateTime AddedChargesDate = ReconciliationDateTimePicker.Value.Date;

                if (BankFeesTextBox.Text.Length > 0)
                {
                    decimal BankFees;
                    if (Decimal.TryParse(BankFeesTextBox.Text, out BankFees))
                    {
                        // find the account that is the default for bank fees
                        AccountCategory BankFeesAccount = ActiveBook.Accounts.Where(ac => ac.BankFeesDefault == "Y").FirstOrDefault();
                        if (BankFeesAccount == null)
                        {
                            BankFeesAccount = new()
                            { Name = "Bank Chrg", Description = "Bank Fees" };
                        }

                        LedgerEntry FeesEntry = new()
                        {
                            When = AddedChargesDate,
                            CheckNumber = "",
                            ToWhom = BankFeesAccount.Description,
                            Cleared = true,
                            Debit = BankFees,
                            Amount = BankFees,
                            Account = BankFeesAccount.Name,
                            ID = ActiveBook.CurrentLedger.Count + 1
                        };
                        int newID = ActiveBook.InsertTransaction(FeesEntry);
                        Checks.Add(new ReconcileRow
                        {
                            Cleared = true,
                            When = AddedChargesDate,
                            CheckNumber = "",
                            ToWhom = BankFeesAccount.Description,
                            Amount = BankFees.ToString("0.00"),
                            ListID = newID
                        });
                    }
                }
                if (InterestEarnedTextBox.Text.Length > 0)
                {
                    decimal Interest;
                    if (Decimal.TryParse(InterestEarnedTextBox.Text, out Interest))
                    {
                        // find the account that is the default for interest earned
                        AccountCategory InterestAccount = ActiveBook.Accounts.Where(ac => ac.InterestIncomeDefault == "Y").FirstOrDefault();
                        if (InterestAccount == null) 
                        { 
                            InterestAccount = new AccountCategory();
                            InterestAccount.Name = "Int Inc";
                            InterestAccount.Description = "Interest Earned";
                        }
                        LedgerEntry InterestEntry = new()
                        {
                            When = AddedChargesDate,
                            CheckNumber = "",
                            ToWhom = InterestAccount.Description,
                            Cleared = true,
                            Credit = Interest,
                            Amount = Interest,
                            Account = InterestAccount.Name,
                            ID = ActiveBook.CurrentLedger.Count + 1
                        };
                        int newID = ActiveBook.InsertTransaction(InterestEntry);
                        Deposits.Add(new DepositRow
                        {
                            Cleared = true,
                            Date = AddedChargesDate.ToShortDateString(),
                            FromWhom = InterestAccount.Description,
                            Amount = Interest.ToString("0.00"),
                            ListID = newID
                        });
                    }

                }
                ShowChecksAndDeposits();
                ChecksDataGridView.Invalidate();

                //ChecksDataGridView.Update();
                ChecksDataGridView.Refresh();
                DepositsDataGridView.Invalidate();
                //DepositsDataGridView.Update();
                DepositsDataGridView.Refresh();
            }
        }
        private void AddMissingTransactionButton_Click(object sender, EventArgs e)
        {
            AddTransactionForm ATF = new();
            ATF.ActiveBook = ActiveBook;
            ATF.ShowDialog();
            if (ATF.newEntry)
            {
                int newID = ActiveBook.InsertTransaction(ATF.tEntry);

                if (ATF.tEntry.Debit > 0.00M)
                {
                    Checks.Add(new ReconcileRow
                    {
                        Cleared = false,
                        When = ATF.tEntry.When,
                        CheckNumber = ATF.tEntry.CheckNumber,
                        ToWhom = ATF.tEntry.ToWhom,
                        Amount = ATF.tEntry.Debit.ToString("0.00"),
                        ListID = newID
                    });
                }
                else
                {
                    Deposits.Add(new DepositRow
                    {
                        Cleared = false,
                        Date = ATF.tEntry.When.ToShortDateString(),
                        FromWhom = ATF.tEntry.ToWhom,
                        Amount = ATF.tEntry.Credit.ToString("0.00"),
                        ListID = newID
                    });
                }
                ShowChecksAndDeposits();
            }

        }

        private void ChangeTransactionValueButton_Click(object sender, EventArgs e)
        {
            ChangeTransactionValueForm CTF = new();
            CTF.ActiveBook = ActiveBook;
            CTF.ShowDialog();
            LoadGrids();
            ShowChecksAndDeposits();
        }


        private void LoadGrids()
        {
            // pull out the unreconciled checks and get which item it is in the ledger
            // the select (entry, index) => new { entry, index } gets the row number with the select
            Checks = (from ch in
                   (ActiveBook.CurrentLedger.Select((Ledger, LIndex) => new { Ledger, LIndex }))
                      where ch.Ledger.Cleared == false &&
                            ch.Ledger.Debit > 0.00M
                      select new ReconcileRow
                      {
                          Cleared = ch.Ledger.Cleared,
                          When = ch.Ledger.When,
                          CheckNumber = ch.Ledger.CheckNumber,
                          ToWhom = ch.Ledger.ToWhom,
                          Amount = ch.Ledger.Debit.ToString("0.00"),
                          ListID = ch.Ledger.ID
                      }).ToList();

            // get the unreconciled deposits and the index into the ledger
            Deposits = (from ch in
                    (ActiveBook.CurrentLedger.Select((Ledger, LIndex) => new { Ledger, LIndex }))
                        where ch.Ledger.Cleared == false
                             && ch.Ledger.Credit > 0.00M
                        select new DepositRow
                        {
                            Cleared = ch.Ledger.Cleared,
                            Date = ch.Ledger.When.ToShortDateString(),
                            FromWhom = ch.Ledger.ToWhom,
                            Amount = ch.Ledger.Credit.ToString("0.00"),
                            ListID = ch.Ledger.ID
                        }).ToList();

        }

        private void ShowChecksAndDeposits ()
        {
            ChecksDataGridView.DataSource = null;
            ChecksDataGridView.DataSource = Checks;
            ChecksDataGridView.Columns[1].ReadOnly = true;
            ChecksDataGridView.Columns[2].ReadOnly = true;
            ChecksDataGridView.Columns[3].ReadOnly = true;
            ChecksDataGridView.Columns[4].ReadOnly = true;
            ChecksDataGridView.Columns[5].Visible = false;
            ChecksDataGridView.AutoResizeColumns();
            DepositsDataGridView.DataSource = null;
            DepositsDataGridView.DataSource = Deposits;
            DepositsDataGridView.Columns[1].ReadOnly = true;
            DepositsDataGridView.Columns[2].ReadOnly = true;
            DepositsDataGridView.Columns[3].ReadOnly = true;
            DepositsDataGridView.Columns[4].Visible = false;
            //DepositsDataGridView.AutoResizeColumns();
            DepositsDataGridView.Invalidate();
            DepositsDataGridView.Refresh();
        }


        private void DoneButton_Click(object sender, EventArgs e)
        {
            decimal EndingBalance;

            // verify that the reconcile worked
            if (Decimal.TryParse(EndingBalanceTextBox.Text, out EndingBalance))
            {
                if (ClearedBalance != EndingBalance)
                {
                    var ToQuit = MessageBox.Show("The reconcile is not balanced. Do you want to quit without reconciling?", "", MessageBoxButtons.YesNo);
                    if (ToQuit == DialogResult.Yes)
                        Close();
                    return;
                }
            }

            // update the ActiveBook 

            foreach (ReconcileRow ch in Checks)
            {
                int iD = ch.ListID;
                for (int index = 0; index < ActiveBook.CurrentLedger.Count; index++)
                {
                    if (ActiveBook.CurrentLedger[index].ID == iD)
                    {
                        if (ch.Cleared != ActiveBook.CurrentLedger[index].Cleared)
                            ActiveBook.CurrentLedger[index].Cleared = ch.Cleared;
                        break;
                    }
                }
            }
            foreach (DepositRow dp in Deposits)
            {
                int iD = dp.ListID;
                for (int index = 0; index < ActiveBook.CurrentLedger.Count; index++)
                {
                    if (ActiveBook.CurrentLedger[index].ID == iD)
                    {
                        if (dp.Cleared != ActiveBook.CurrentLedger[index].Cleared)
                            ActiveBook.CurrentLedger[index].Cleared = dp.Cleared;
                        break;
                    }
                }
            }
            // close this window
            Close();
        }

        private void CancelFormButton_Click(object sender, EventArgs e)
        {
            // close without updating the ActiveBook
            Close();
        }


        private void ChecksDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int WhichCheckOnScreen = e.RowIndex;
            //int WhichCheckInLedger = (int)ChecksDataGridView.Rows[WhichCheckOnScreen].Cells[4].Value;
            //int WhichCheckInLedger = Checks[WhichCheckOnScreen].ListID;

            decimal Amount = Decimal.Parse(Checks[WhichCheckOnScreen].Amount);
            //Decimal Amount = ActiveBook.CurrentLedger[WhichCheckInLedger].Debit;

            // if this check is cleared, subtract it from the uncleared balances
            //if (!ActiveBook.CurrentLedger[WhichCheckInLedger].Cleared)
            if (!Checks[WhichCheckOnScreen].Cleared)
            {
                ClearedBalance = ClearedBalance - Amount;
                ClearedBalanceTextBox.Text = ClearedBalance.ToString("C");
                //ActiveBook.CurrentLedger[WhichCheckInLedger].Cleared = true;
                Checks[WhichCheckOnScreen].Cleared = true;
                if (e.ColumnIndex > 0)
                {
                    ChecksDataGridView.Rows[WhichCheckOnScreen].Cells[0].Value = true;
                    ChecksDataGridView.RefreshEdit();
                    ChecksDataGridView.Refresh();
                }
            }
            else
            {
                ClearedBalance = ClearedBalance + Amount;
                ClearedBalanceTextBox.Text = ClearedBalance.ToString("C");
                //ActiveBook.CurrentLedger[WhichCheckInLedger].Cleared = false;
                Checks[WhichCheckOnScreen].Cleared = false;
                if (e.ColumnIndex > 0)
                {
                    ChecksDataGridView.Rows[WhichCheckOnScreen].Cells[0].Value = false;
                    ChecksDataGridView.RefreshEdit();
                    ChecksDataGridView.Refresh();
                }
            }
        }

        private void DepositsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int WhichDeposit = e.RowIndex;

            decimal Amount = Decimal.Parse(Deposits[WhichDeposit].Amount);

            // if this deposit is cleared, add it to the uncleared balances
            if (!Deposits[WhichDeposit].Cleared)
            {
                ClearedBalance = ClearedBalance + Amount;
                ClearedBalanceTextBox.Text = ClearedBalance.ToString("C");
                Deposits[WhichDeposit].Cleared = true;
                if (e.ColumnIndex > 0)
                {
                    DepositsDataGridView.Rows[WhichDeposit].Cells[0].Value = true;
                    DepositsDataGridView.RefreshEdit();
                    DepositsDataGridView.Refresh();
                }
            }
            else
            {
                ClearedBalance = ClearedBalance - Amount;
                ClearedBalanceTextBox.Text = ClearedBalance.ToString("C");
                Deposits[WhichDeposit].Cleared = false;
                if (e.ColumnIndex > 0)
                {
                    DepositsDataGridView.Rows[WhichDeposit].Cells[0].Value = false;
                    DepositsDataGridView.RefreshEdit();
                    DepositsDataGridView.Refresh();
                }
            }

        }

        private void EndingBalanceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            DecimalEntryOnly(sender, e);
        }
        private void BankFeesTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            DecimalEntryOnly(sender, e);
        }
        private void InterestEarnedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            DecimalEntryOnly(sender, e);
        }

        private void DecimalEntryOnly (object sender, KeyPressEventArgs e)
        {
            if ((Char.IsDigit(e.KeyChar)) ||
                (e.KeyChar == '.') ||
                (e.KeyChar == '-') ||
                (e.KeyChar == (char)Keys.Back))
            {
                return;
            }
            e.Handled = true;
        }

        private void EndingBalanceTextBox_Leave(object sender, EventArgs e)
        {
        }




        private void BankFeesTextBox_Leave(object sender, EventArgs e)
        {
            decimal BankFees;
            if (Decimal.TryParse(BankFeesTextBox.Text, out BankFees))
            {
                ClearedBalance = ClearedBalance - BankFees;
                ClearedBalanceTextBox.Text = ClearedBalance.ToString("C");
            }
        }

        private void InterestEarnedTextBox_Leave(object sender, EventArgs e)
        {
            decimal InterestEarned;
            if (Decimal.TryParse(InterestEarnedTextBox.Text, out InterestEarned))
            {
                ClearedBalance = ClearedBalance + InterestEarned;
                ClearedBalanceTextBox.Text = ClearedBalance.ToString("C");
            }
        }


    }
}
