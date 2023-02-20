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
    public partial class ChangeTransactionValueForm : Form
    {
        class AvailableToChangeRow
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

        List<AvailableToChangeRow> Entries { get; set; }

        AvailableToChangeRow EntryToChange;

        public ChangeTransactionValueForm()
        {
            InitializeComponent();
        }

        private void ChangeTransactionValueForm_Shown(object sender, EventArgs e)
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
                       select new AvailableToChangeRow
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
            EntryToChange = Entries[Row];

            string Message = "Do you really want to change the entry " + EntryToChange.When.ToShortDateString() +
                              " " + EntryToChange.ToWhom + " $" + EntryToChange.Amount;

            if (MessageBox.Show(Message, "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                OldValueTextBox.Text = EntryToChange.Amount;
                NewValueTextBox.Text = "";
                UpdatePanel.Visible = true;
            }
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NewValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allow only values in this text box

            if ((Char.IsDigit(e.KeyChar)) ||
                (e.KeyChar == '.') ||
                (e.KeyChar == (char)Keys.Back))
            {
                return;
            }
            e.Handled = true;
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            int LedgerEntryID = EntryToChange.ListIndex;
            decimal NewValue;
            Decimal.TryParse(NewValueTextBox.Text, out NewValue);
            ActiveBook.UpdateThisTransaction(LedgerEntryID, NewValue);
            UpdatePanel.Visible = false;
            NewValueTextBox.Text = "";
            LoadGrid();
            ShowEntries();

        }
    }
}
