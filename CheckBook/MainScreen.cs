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
using System.Globalization;

using System.IO;
using CsvHelper;


namespace CheckBook
{
    public partial class MainScreen : Form
    {
        public MyCheckbook ActiveBook;


        public MainScreen()
        {
            InitializeComponent();
            ActiveBook = new MyCheckbook();
            ActiveBook.Accounts = new List<AccountCategory>();
            ActiveBook.CurrentLedger = new List<LedgerEntry>();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openBKFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.UseWaitCursor = true;
                Application.DoEvents();
                ReadDataFile(openBKFileDialog.FileName);
                ledgerDataGridView.DataSource = ActiveBook.CurrentLedger;
                ledgerDataGridView.AutoResizeColumns();
                ledgerDataGridView.FirstDisplayedScrollingRowIndex = ledgerDataGridView.RowCount - 1;
                this.Cursor = Cursors.Default;
                this.UseWaitCursor = false;
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveBook.CurrentLedger.Count == 0)
            {
                if (MessageBox.Show("There are no transactions. Are you sure you want to save?", "",
                          MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            }
            saveBKFileDialog.OverwritePrompt = false;
            saveBKFileDialog.DefaultExt = "csv";
            if (saveBKFileDialog.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                SaveDataFile(saveBKFileDialog.FileName);
                Cursor = Cursors.Default;
            }
        }


        private void ImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openQuickenFileDialog.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                LoadQuickenFile(openQuickenFileDialog.FileName);
                ledgerDataGridView.DataSource = ActiveBook.CurrentLedger;
                ledgerDataGridView.AutoResizeColumns();
                ledgerDataGridView.FirstDisplayedScrollingRowIndex = ledgerDataGridView.RowCount - 1;
                Cursor = Cursors.Default;
            }
        }


        private void addTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveBook.CurrentLedger.Count > 0)
            {
                AddTransactionForm ATF = new AddTransactionForm();
                ATF.PriorBalance = ActiveBook.CurrentLedger[ActiveBook.CurrentLedger.Count - 1].Balance;
                string LastCheckNumber = (from ch in ActiveBook.CurrentLedger
                                       where ch.CheckNumber.Length > 0
                                          && Char.IsDigit(ch.CheckNumber[0])
                                       orderby ch.CheckNumber descending
                                       select ch.CheckNumber).First();
                ATF.LastCheckNumber = Int32.Parse(LastCheckNumber);
                ATF.ActiveBook = ActiveBook;
                ATF.ShowDialog();
                if (ATF.newEntry)
                {
                    ActiveBook.CurrentLedger.Add(ATF.tEntry);
                    ledgerDataGridView.DataSource = null;
                    ledgerDataGridView.DataSource = ActiveBook.CurrentLedger;
                    ledgerDataGridView.AutoResizeColumns();
                    ledgerDataGridView.FirstDisplayedScrollingRowIndex = ledgerDataGridView.RowCount - 1;

                }
            }
            else
            {
                MessageBox.Show("Please load a checkbook first");
            }
        }

        private void reconcileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveBook.CurrentLedger.Count > 0)
            {
                ReconcileForm RTF = new ReconcileForm();
                RTF.ActiveBook = ActiveBook;
                RTF.ShowDialog();
                // what to do on success?
                // redisplay the ledger
                ledgerDataGridView.DataSource = null;
                ledgerDataGridView.DataSource = ActiveBook.CurrentLedger;
                ledgerDataGridView.AutoResizeColumns();
                ledgerDataGridView.FirstDisplayedScrollingRowIndex = ledgerDataGridView.RowCount - 1;
            }
            else
            {
                MessageBox.Show("Please load a checkbook first");
            }

        }





        private void ReadDataFile (string FileName)
        {
            ActiveBook = new MyCheckbook();
            ActiveBook.Accounts = new List<AccountCategory>();
            ActiveBook.CurrentLedger = new List<LedgerEntry>();

            using (StreamReader sr = new StreamReader(openBKFileDialog.FileName))
            {
                CsvHelper.Configuration.CsvConfiguration config = new CsvHelper.Configuration.CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture);

                config.Delimiter = ",";
                config.MissingFieldFound = null;
                config.TrimOptions = CsvHelper.Configuration.TrimOptions.Trim;
                config.HeaderValidated = null;

                using (var csvFile = new CsvReader(sr, config))
                {
                    if (csvFile.Read())
                    {
                        csvFile.ReadHeader();
                        while (csvFile.Read())
                        {                            
                            string test = csvFile.GetField(0).Trim();
                            if (test == "AccountsEnd") 
                                break;
                            ActiveBook.Accounts.Add(csvFile.GetRecord<AccountCategory>());
                        }
                    }

                    if (csvFile.Read())
                    {
                        csvFile.ReadHeader();
                        while (csvFile.Read())
                        {
                            int FieldCount = csvFile.Parser.Count;
                            int FieldID = 0;
                            LedgerEntry LE = new LedgerEntry();
                            LE.When = DateTime.Parse(csvFile.GetField(FieldID++));
                            LE.CheckNumber = csvFile.GetField(FieldID++);
                            LE.ToWhom = csvFile.GetField(FieldID++);
                            LE.Cleared = Boolean.Parse(csvFile.GetField(FieldID++));
                            LE.Debit = Decimal.Parse(csvFile.GetField(FieldID++));
                            LE.Credit = Decimal.Parse(csvFile.GetField(FieldID++));
                            LE.Balance = Decimal.Parse(csvFile.GetField(FieldID++));
                            LE.Amount = Decimal.Parse(csvFile.GetField(FieldID++));
                            LE.Account = csvFile.GetField(FieldID++);
                            string testle = csvFile.GetField(FieldID);
                            if (!string.IsNullOrEmpty(csvFile.GetField(FieldID)))
                            {
                                LE.SubAccounts = new List<CategoryEntry>();
                                //while (!string.IsNullOrEmpty(csvFile.GetField(FieldID)))
                                while (FieldID < FieldCount)
                                {
                                    CategoryEntry CE = new CategoryEntry();
                                    CE.AccountName = csvFile.GetField(FieldID++);
                                    CE.Notes = csvFile.GetField(FieldID++);
                                    CE.Amount = Decimal.Parse(csvFile.GetField(FieldID++));
                                    LE.SubAccounts.Add(CE);
                                }
                            }

                            ActiveBook.CurrentLedger.Add(LE);
                        }
                    }
                }
            }

        }


        private void SaveDataFile (string FileName)
        {
            using (StreamWriter csvWriter = new StreamWriter(saveBKFileDialog.FileName, false))
            {
                using (var csvFile = new CsvWriter(csvWriter, CultureInfo.InvariantCulture))
                {
                    csvFile.WriteRecords(ActiveBook.Accounts);
                }
            }
            using (StreamWriter csvWriter = new StreamWriter(saveBKFileDialog.FileName, true))
            {
                csvWriter.WriteLine("AccountsEnd");  // put in a indicator before the next section

                using (var csvFile = new CsvWriter(csvWriter, CultureInfo.InvariantCulture))
                {
                    csvFile.WriteHeader<LedgerEntry>();
                    csvFile.NextRecord();
                    foreach (LedgerEntry LE in ActiveBook.CurrentLedger)
                    {
                        if (LE.SubAccounts == null)
                            csvFile.WriteRecord(LE);
                        else
                        {
                            csvFile.WriteField(LE.When);
                            csvFile.WriteField(LE.CheckNumber);
                            csvFile.WriteField(LE.ToWhom);
                            csvFile.WriteField(LE.Cleared);
                            csvFile.WriteField(LE.Debit);
                            csvFile.WriteField(LE.Credit);
                            csvFile.WriteField(LE.Balance);
                            csvFile.WriteField(LE.Amount);
                            csvFile.WriteField(LE.Account);
                            foreach (CategoryEntry CE in LE.SubAccounts)
                            {
                                csvFile.WriteField(CE.AccountName);
                                csvFile.WriteField(CE.Notes);
                                csvFile.WriteField(CE.Amount);
                            }
                        }
                        csvFile.NextRecord();
                    }
                }
            }

        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            
        }


        private void LoadQuickenFile(string FileName)
        {
            ActiveBook = new MyCheckbook();
            ActiveBook.Accounts = new List<AccountCategory>();
            ActiveBook.CurrentLedger = new List<LedgerEntry>();

            StreamReader QK = new StreamReader(FileName);

            while (!QK.EndOfStream)
            {
                string QLine = QK.ReadLine();
                if (QLine.Length > 0)
                {
                    if (QLine[0] == '!')
                    {
                        if (QLine.Trim() == "!Type:Cat")
                        {
                            do
                            {
                                AccountCategory nCategory = ProcessCategory(QK);
                                ActiveBook.Accounts.Add(nCategory);

                            } while (QK.Peek() != '!');
                        }
                        if (QLine.Trim() == "!Type:Bank")
                        {
                            decimal CurrentBalance = 0.00M;
                            do
                            {
                                LedgerEntry nEntry = ProcessLedger(QK);
                                CurrentBalance = CurrentBalance + nEntry.Amount;
                                nEntry.Balance = CurrentBalance;
                                ActiveBook.CurrentLedger.Add(nEntry);

                            } while (!QK.EndOfStream);
                        }
                    }
                    else
                    {

                    }

                }
            }

        }

        private AccountCategory ProcessCategory(StreamReader reader)
        {
            AccountCategory nCategory = new AccountCategory();
            while (true)
            {
                string QLine = reader.ReadLine();
                if (QLine.Length > 0)
                {
                    if (QLine[0] == '^') break;

                    switch (QLine[0])
                    {
                        case 'N': nCategory.Name = QLine.Substring(1).Trim(); break;
                        case 'D': nCategory.Description = QLine.Substring(1).Trim(); break;
                        case 'I': nCategory.WhatType = AccountCategory.CategoryType.Income; break;
                        case 'E': nCategory.WhatType = AccountCategory.CategoryType.Expense; break;
                        case 'T': break; // taxable
                        case 'R': break; // don't know what this is
                    }
                }
            }
            return nCategory;
        }
        private LedgerEntry ProcessLedger(StreamReader reader)
        {
            LedgerEntry nEntry = new LedgerEntry();
            while (true)
            {
                string QLine = reader.ReadLine();
                if (QLine.Length > 0)
                {
                    if (QLine[0] == '^') break;

                    switch (QLine[0])
                    {
                        case 'D': nEntry.When = ParseDateTime(QLine); break;
                        case 'T':
                            {
                                nEntry.Amount = Convert.ToDecimal(QLine.Substring(1).Trim());
                                if (nEntry.Amount < 0)
                                    nEntry.Debit = 0.00M - nEntry.Amount;
                                else
                                    nEntry.Credit = nEntry.Amount;
                                break;
                            }
                        case 'C': if (QLine[1] == 'X') nEntry.Cleared = true; break;
                        case 'P': nEntry.ToWhom = QLine.Substring(1).Trim(); break;
                        case 'L': nEntry.Account = QLine.Substring(1).Trim(); break;
                        case 'N': nEntry.CheckNumber = QLine.Substring(1).Trim(); break;
                        case 'S':
                            {
                                nEntry.SubAccounts = new List<CategoryEntry>();
                                do
                                {
                                    CategoryEntry sub = new CategoryEntry();
                                    sub.AccountName = QLine.Substring(1).Trim();
                                    QLine = reader.ReadLine();
                                    if (QLine.Length > 0)
                                    {
                                        if (QLine[0] == 'E')
                                        {
                                            sub.Notes = QLine.Substring(1).Trim();
                                            QLine = reader.ReadLine();
                                            if (QLine.Length == 0) break;
                                        }

                                        if (QLine[0] == '$')
                                            sub.Amount = Convert.ToDecimal(QLine.Substring(1).Trim());
                                        else break;
                                    }
                                    nEntry.SubAccounts.Add(sub);
                                    if (reader.Peek() != 'S') break;
                                    QLine = reader.ReadLine();
                                } while (!reader.EndOfStream);
                            }
                            break;
                    }
                }
            }
            return nEntry;
        }
        private DateTime ParseDateTime (string Line)
        {
            DateTime When = new DateTime();
            int Month = 0;
            int Day = 0;
            int Year = 0;

            int ptr = 1;
            if (Char.IsDigit(Line[ptr])) { Month = Int32.Parse(Line[ptr++].ToString()); } else ptr++;
            if (ptr < Line.Length)
            {
                if (Char.IsDigit(Line[ptr])) { Month = Month * 10 + Int32.Parse(Line[ptr++].ToString()); }
            }
            if (ptr < Line.Length) { if (Line[ptr] == '/') ptr++; else ptr++; }

            if (Char.IsDigit(Line[ptr])) { Day = Int32.Parse(Line[ptr++].ToString()); } else ptr++;
            if (ptr < Line.Length)
            {
                if (Char.IsDigit(Line[ptr])) { Day = Day * 10 + Int32.Parse(Line[ptr++].ToString()); }
            }
            if (ptr < Line.Length) { if (Line[ptr] == '\'') ptr++; }

            if (Char.IsDigit(Line[ptr])) { Year = Int32.Parse(Line[ptr++].ToString()); } else ptr++;
            if (ptr < Line.Length)
            {
                if (Char.IsDigit(Line[ptr])) { Year = Year * 10 + Int32.Parse(Line[ptr++].ToString()); }
            }

            Year = Year + 2000;
            When = new DateTime(Year, Month, Day);
            return When;
        }

    }
}
