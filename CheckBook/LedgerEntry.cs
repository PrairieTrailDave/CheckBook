//
//  Copyright 2021 David Randolph
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckBook
{
    public class LedgerEntry
    {
        public DateTime When { get; set; }
        public string CheckNumber { get; set; }
        public string ToWhom { get; set; }
        public bool Cleared { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Balance { get; set; }
        public decimal Amount { get; set; }
        public string Account { get; set; }
        public List<CategoryEntry> SubAccounts { get; set; }
    }
}
