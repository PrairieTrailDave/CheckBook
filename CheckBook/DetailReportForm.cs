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
    public partial class DetailReportForm : Form
    {
        public class ReportLine
        {
            public string Category { get; set; }
            public string Date { get; set; }
            public string ChkNum { get; set; }
            public string Payee { get; set; }
            public string Amount { get; set; }
        }

        public class ReportItem
        {
            public DateTime When { get; set; }
            public string CheckNumber { get; set; }
            public string ToWhom { get; set; }
            public decimal Amount { get; set; }
        }


        // variables filled from the main window
        public MyCheckbook ActiveBook { get; set; }


        // local variables

        public List<ReportLine> DetailReport;
        DateTime StartDate;
        DateTime EndDate;

        public DetailReportForm()
        {
            InitializeComponent();
        }

        private void TimePeriodListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (TimePeriodListBox.SelectedItem)
            {
                case "Last Month":
                    DateTime lastMonth = DateTime.Now.AddMonths(-1);
                    StartDate = new DateTime(lastMonth.Year, lastMonth.Month, 1);
                    EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    BuildReport();
                    break;
                case "This Month":
                    DateTime NextMonth = DateTime.Now.AddMonths(1);
                    StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    EndDate = new DateTime(NextMonth.Year, NextMonth.Month, 1);
                    BuildReport();
                    break;
                case "Last Year":
                    DateTime lastYear = DateTime.Now.AddYears(-1);
                    StartDate = new DateTime(lastYear.Year, 1, 1);
                    EndDate = new DateTime(DateTime.Now.Year, 1, 1);
                    BuildReport();
                    break;
                case "This Year":
                    StartDate = new DateTime(DateTime.Now.Year, 1, 1);
                    EndDate = new DateTime(DateTime.Now.AddYears(1).Year, 1, 1);
                    BuildReport();
                    break;

            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (DetailReport.Count == 0)
            {
                if (MessageBox.Show("The report is empty. Are you sure you want to save?", "",
                          MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            }
            SaveReportFileDialog.AddExtension = true;
            SaveReportFileDialog.DefaultExt = "csv";
            SaveReportFileDialog.Filter = "CheckBook files (*.csv)|*.csv|All files (*.*)|*.*";
            if (SaveReportFileDialog.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                SaveReportFile(SaveReportFileDialog.FileName);
                Cursor = Cursors.Default;
            }
        }

        private void BuildReport()
        {
            DetailReport = new List<ReportLine>();


            foreach (AccountCategory category in ActiveBook.Accounts)
            {

                // get any transactions for this category

                var SubItems = (from le in ActiveBook.CurrentLedger
                                where le.SubAccounts != null
                                   && le.When >= StartDate
                                   && le.When < EndDate
                                   && le.SubAccounts.Count > 0
                                select (
                                from les in le.SubAccounts
                                where les.AccountName.ToUpper().Trim() == category.Name.ToUpper().Trim()
                                select new ReportItem
                                {
                                    When = le.When,
                                    CheckNumber = le.CheckNumber,
                                    ToWhom = le.ToWhom,
                                    Amount = les.Amount
                                }
                                )).SelectMany(li => li);


                // when there are sub accounts, the amount here would get allocated to the first sub account instead of letting the subs work
                List<ReportItem> CategoryTransactions = (from le in ActiveBook.CurrentLedger
                                                         where le.Account.ToUpper().Trim() == category.Name.ToUpper().Trim()
                                                            && le.When >= StartDate
                                                            && le.When < EndDate
                                                            &&(le.SubAccounts == null || 
                                                             le.SubAccounts?.Count == 0 )
                                                         select new ReportItem
                                                         {
                                                             When = le.When,
                                                             CheckNumber = le.CheckNumber,
                                                             ToWhom = le.ToWhom,
                                                             Amount = le.Amount
                                                         })
                                                          .Union(
                                                                SubItems
                                                           )
                                                          .OrderBy(ls => ls.When)
                                                          .ToList();


                if (CategoryTransactions.Count > 0)
                {
                    decimal CategorySum = 0.00M;

                    // put in the category line

                    ReportLine CategoryLine = new ReportLine();
                    CategoryLine.Category = category.Name;
                    DetailReport.Add(CategoryLine);


                    foreach (ReportItem Le in CategoryTransactions)
                    {
                        ReportLine CategoryDetailLine = new ReportLine();
                        CategoryDetailLine.Category = "";
                        CategoryDetailLine.Date = Le.When.ToShortDateString();
                        CategoryDetailLine.ChkNum = Le.CheckNumber;
                        CategoryDetailLine.Payee = Le.ToWhom;
                        CategoryDetailLine.Amount = Le.Amount.ToString("0.00");
                        DetailReport.Add(CategoryDetailLine);

                        CategorySum = CategorySum + Le.Amount;
                    }

                    ReportLine CategoryBreakLine = new ReportLine();
                    CategoryBreakLine.Category = "";
                    CategoryBreakLine.Date = "";
                    CategoryBreakLine.ChkNum = "";
                    CategoryBreakLine.Payee = "";
                    CategoryBreakLine.Amount = "----------";
                    DetailReport.Add(CategoryBreakLine);

                    ReportLine CategorySumLine = new ReportLine();
                    CategorySumLine.Category = "";
                    CategorySumLine.Date = "";
                    CategorySumLine.ChkNum = "";
                    CategorySumLine.Payee = "";
                    CategorySumLine.Amount = CategorySum.ToString();
                    DetailReport.Add(CategorySumLine);

                }
            }
            ReportDataGridView.DataSource = DetailReport;
            ReportDataGridView.AutoResizeColumns();
        }

        private void SaveReportFile(string FileName)
        {
            using (StreamWriter csvWriter = new StreamWriter(FileName, false))
            {
                using (var csvFile = new CsvWriter(csvWriter, CultureInfo.InvariantCulture))
                {
                    csvFile.WriteRecords(DetailReport);
                }
            }
        }
    }
}
