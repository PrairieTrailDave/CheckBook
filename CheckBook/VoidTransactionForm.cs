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
    public partial class VoidTransactionForm : Form
    {
        class AvailableToVoidRow
        {
            public bool Cleared { get; set; }
            public DateTime When { get; set; }
            public string CheckNumber { get; set; }
            public string ToWhom { get; set; }
            public string Amount { get; set; }
            public int ListIndex { get; set; }
        }

        // variables filled from the main window
        public MyCheckbook ActiveBook { get; set; }

        // Internal Variables

        List<AvailableToVoidRow> Entries { get; set; }


        public VoidTransactionForm()
        {
            InitializeComponent();
        }

        private void VoidTransactionForm_Shown(object sender, EventArgs e)
        {
            LoadGrid();
            ShowEntries();
        }

        private void LoadGrid()
        {
            // pull out the unreconciled entries and get which item it is in the ledger
            Entries = (from ch in
                   (ActiveBook.CurrentLedger.Select((Ledger, LIndex) => new { Ledger, LIndex }))
                      where ch.Ledger.Cleared == false 
                      select new AvailableToVoidRow
                      {
                          Cleared = ch.Ledger.Cleared,
                          When = ch.Ledger.When,
                          CheckNumber = ch.Ledger.CheckNumber,
                          ToWhom = ch.Ledger.ToWhom,
                          Amount = ch.Ledger.Debit.ToString("0.00"),
                          ListIndex = ch.LIndex
                      }).ToList();


        }

        private void ShowEntries()
        {
            EntriesDataGridView.DataSource = null;
            EntriesDataGridView.DataSource = Entries;
            EntriesDataGridView.Columns[1].ReadOnly = true;
            EntriesDataGridView.Columns[2].ReadOnly = true;
            EntriesDataGridView.Columns[3].ReadOnly = true;
            EntriesDataGridView.Columns[4].ReadOnly = true;
            EntriesDataGridView.Columns[5].Visible = false;
            EntriesDataGridView.AutoResizeColumns();

        }

        private void EntriesDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Row = e.RowIndex;
            AvailableToVoidRow Entry = Entries[Row];

            string Message = "Do you really want to void the entry from " + Entry.When.ToShortDateString() +
                              " regarding " + Entry.ToWhom + " for $" + Entry.Amount;
                    
            if (MessageBox.Show(Message, "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int LedgerEntryID = Entry.ListIndex;
                ActiveBook.VoidThisTransaction(LedgerEntryID);
                Entries.Remove(Entry);
                ShowEntries();
            }
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
