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
    public partial class DetailReportForm : Form
    {
        public class ReportLine
        {
            public string Col1 { get; set; }
            public string Col2 { get; set; }
            public string Col3 { get; set; }
            public string Col4 { get; set; }
            public string Col5 { get; set; }
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

        }

        private void BuildReport ()
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



                List<ReportItem> CategoryTransactions = (from le in ActiveBook.CurrentLedger
                                                          where le.Account.ToUpper().Trim() == category.Name.ToUpper().Trim()
                                                             && le.When >= StartDate
                                                             && le.When < EndDate
                                                          select new ReportItem { 
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
                    CategoryLine.Col1 = category.Name;
                    DetailReport.Add(CategoryLine);


                    foreach (ReportItem Le in CategoryTransactions)
                    {
                        ReportLine CategoryDetailLine = new ReportLine();
                        CategoryDetailLine.Col1 = "";
                        CategoryDetailLine.Col2 = Le.When.ToShortDateString();
                        CategoryDetailLine.Col3 = Le.CheckNumber;
                        CategoryDetailLine.Col4 = Le.ToWhom;
                        CategoryDetailLine.Col5 = Le.Amount.ToString();
                        DetailReport.Add(CategoryDetailLine);

                        CategorySum = CategorySum + Le.Amount;
                    }

                    ReportLine CategoryBreakLine = new ReportLine();
                    CategoryBreakLine.Col1 = "";
                    CategoryBreakLine.Col2 = "";
                    CategoryBreakLine.Col3 = "";
                    CategoryBreakLine.Col4 = "";
                    CategoryBreakLine.Col5 = "----------";
                    DetailReport.Add(CategoryBreakLine);

                    ReportLine CategorySumLine = new ReportLine();
                    CategorySumLine.Col1 = "";
                    CategorySumLine.Col2 = "";
                    CategorySumLine.Col3 = "";
                    CategorySumLine.Col4 = "";
                    CategorySumLine.Col5 = CategorySum.ToString();
                    DetailReport.Add(CategorySumLine);

                }
            }
            ReportDataGridView.DataSource = DetailReport;
            ReportDataGridView.AutoResizeColumns();
        }
    }
}
