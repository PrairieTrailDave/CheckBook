﻿//
//  Copyright 2021 David Randolph
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckBook
{
    public class AccountCategory
    {
        public enum CategoryType { Income, Expense }

        public CategoryType WhatType { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string InterestIncomeDefault { get; set; } = "N";
        public string BankFeesDefault { get; set; } = "N";

    }
}
