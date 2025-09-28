//
//  Copyright 2021 David Randolph
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace CheckBook
{
    public class MyCheckbook
    {
        // Storage of the checkbook ledger
        public List<LedgerEntry> CurrentLedger { get; set; }
        public List<AccountCategory> Accounts { get; set; }

        private bool Changed;




        // Methods

        public MyCheckbook() 
        { 
            Changed = false; // always start a new checkbook as unchanged
        }



        // Methods for managing if changed

        public bool IfChanged()
        {
            return Changed;
        }
        public void HasChanged() { Changed = true; }
        public void ClearChanged()
        {
            Changed = false;
        }



        // methods for managing entries in the ledger

        public int InsertTransaction (LedgerEntry newEntry)
        {
            // if there are no transaction in the ledger,
            // simply add this transaction

            if (CurrentLedger.Count == 0)
            {
                newEntry.Balance = newEntry.Credit - newEntry.Debit;
                CurrentLedger.Add(newEntry);
                HasChanged();
                return CurrentLedger.Count-1;
            }
            else
            {
                // find where to insert this transaction

                // date of this transaction

                DateTime DateOfThisTransaction = newEntry.When.Date;

                // get the first transaction after yesterday

                int LedgerIndex = 0;
                while (LedgerIndex < CurrentLedger.Count)
                {
                    if (CurrentLedger[LedgerIndex].When.Date < DateOfThisTransaction)
                        LedgerIndex++;
                    else
                        break;
                }

                // if no more entries today or later, then simply append

                if (LedgerIndex >= CurrentLedger.Count)
                {
                    newEntry.Balance = CurrentLedger[LedgerIndex-1].Balance + newEntry.Credit - newEntry.Debit;
                    CurrentLedger.Add(newEntry);
                    HasChanged();
                    return newEntry.ID;
                }
                else
                {
                    // if this is a deposit, 
                    // insert it at the start of the day's transactions

                    if (newEntry.Credit > 0.00M)
                    {
                        newEntry.Balance = CurrentLedger[LedgerIndex - 1].Balance + newEntry.Credit - newEntry.Debit;
                        CurrentLedger.Insert(LedgerIndex, newEntry);
                        UpdateFollowingTransactionBalances(LedgerIndex);
                        HasChanged();
                        return newEntry.ID;
                    }
                    else
                    {
                        // if a check, if it has a check number, 
                        // insert after the prior check number of today
                        if (newEntry.CheckNumber.Length > 0)
                        {
                            // it is possible to put characters in the check number
                            // if it doesn't parse, skip this 

                            int EcheckNum;
                            if (Int32.TryParse(newEntry.CheckNumber, out EcheckNum))
                            {
                                int secondIndex = LedgerIndex;
                                while (secondIndex < CurrentLedger.Count)
                                {
                                    // if past today, insert at this point
                                    if (CurrentLedger[secondIndex].When.Date > DateOfThisTransaction)
                                        break;
                                    // if has a check number, compare that
                                    if (CurrentLedger[secondIndex].CheckNumber.Length > 0)
                                    {
                                        int LcheckNum;
                                        if (Int32.TryParse(CurrentLedger[secondIndex].CheckNumber, out LcheckNum))
                                        {
                                            if (EcheckNum < LcheckNum)
                                                break;
                                        }
                                        else
                                            break;
                                    }
                                    // if no check number, insert at this point
                                    else
                                        break;
                                    secondIndex++;
                                }
                                // if today is the last day in the ledger, 
                                // simply add it
                                if (secondIndex >= CurrentLedger.Count)
                                {
                                    newEntry.Balance = CurrentLedger[secondIndex - 1].Balance + newEntry.Credit - newEntry.Debit;
                                    CurrentLedger.Add(newEntry);
                                    HasChanged();
                                    return newEntry.ID;
                                }
                                else
                                {
                                    newEntry.Balance = CurrentLedger[secondIndex - 1].Balance + newEntry.Credit - newEntry.Debit;
                                    CurrentLedger.Insert(secondIndex, newEntry);
                                    UpdateFollowingTransactionBalances(secondIndex);
                                    HasChanged();
                                    return newEntry.ID;
                                }

                            }
                        }
                        else
                        // doesn't have a check number, 
                        // place it after all the check number entries for today
                        {
                            int secondIndex = LedgerIndex;
                            while (secondIndex < CurrentLedger.Count)
                            {
                                // if past today, insert at this point
                                if (CurrentLedger[secondIndex].When.Date > DateOfThisTransaction)
                                    break;
                                // if has a check number, keep going
                                if (CurrentLedger[secondIndex].CheckNumber.Length > 0)
                                {
                                }
                                // if no check number, insert at this point
                                else
                                    break;
                                secondIndex++;
                            }
                            // if today is the last day in the ledger, 
                            // simply add it
                            if (secondIndex >= CurrentLedger.Count)
                            {
                                newEntry.Balance = CurrentLedger[secondIndex - 1].Balance + newEntry.Credit - newEntry.Debit;
                                CurrentLedger.Add(newEntry);
                                HasChanged();
                                return newEntry.ID;
                            }
                            else
                            {
                                newEntry.Balance = CurrentLedger[secondIndex - 1].Balance + newEntry.Credit - newEntry.Debit;
                                CurrentLedger.Insert(secondIndex, newEntry);
                                UpdateFollowingTransactionBalances(secondIndex);
                                HasChanged();
                                return newEntry.ID;
                            }
                        }
                    }
                    // don't think it should get here, but if it does, simply add to end
                    newEntry.Balance = newEntry.Credit - newEntry.Debit;
                    CurrentLedger.Add(newEntry);
                    HasChanged();
                    return newEntry.ID;
                }
            }
        }

        public void AddTransaction(LedgerEntry newEntry)
        {
            CurrentLedger.Add(newEntry);
            HasChanged();
        }

        public void ReconcileThisCheck(int iD, bool CheckClearedFlag)
        {
            for (int index = 0; index < CurrentLedger.Count; index++)
            {
                if (CurrentLedger[index].ID == iD)
                {
                    if (CheckClearedFlag != CurrentLedger[index].Cleared)
                    {
                        CurrentLedger[index].Cleared = CheckClearedFlag;
                        HasChanged();
                    }
                    break;
                }
            }
        }

        public void ReconcileThisDeposit(int iD, bool DepositClearedFlag)
        {
            for (int index = 0; index < CurrentLedger.Count; index++)
            {
                if (CurrentLedger[index].ID == iD)
                {
                    if (DepositClearedFlag != CurrentLedger[index].Cleared)
                    {
                        CurrentLedger[index].Cleared = DepositClearedFlag;
                        HasChanged();
                    }
                    break;
                }
            }

        }



        public void VoidThisTransaction (int LedgerEntryID)
        {
            // only act if there are any transactions in the ledger

            if (CurrentLedger.Count > 0)
            {
                // and only if this is a valid entry
                
                for(int EntryNumber = 0; EntryNumber < CurrentLedger.Count; EntryNumber++)
                { 
                    LedgerEntry LE = CurrentLedger[EntryNumber];
                    if (LE.ID == LedgerEntryID)
                    {
                        CurrentLedger[EntryNumber].Amount = 0.00M;
                        CurrentLedger[EntryNumber].Debit = 0.00M;
                        CurrentLedger[EntryNumber].Credit = 0.00M;
                        CurrentLedger[EntryNumber].Cleared = true;
                        if (EntryNumber > 1)
                            CurrentLedger[EntryNumber].Balance = CurrentLedger[EntryNumber - 1].Balance;
                        else
                            CurrentLedger[EntryNumber].Balance = 0.00M;
                        UpdateFollowingTransactionBalances(EntryNumber);
                        HasChanged();
                        break;
                    }
                }
            }
        }

        public void UpdateThisTransaction(int LedgerEntryID, decimal NewValue)
        {
            // only act if there are any transactions in the ledger

            if (CurrentLedger.Count > 0)
            {
                // and only if this is a valid entry

                for (int EntryNumber = 0; EntryNumber < CurrentLedger.Count; EntryNumber++)
                {
                    LedgerEntry LE = CurrentLedger[EntryNumber];
                    if (LE.ID == LedgerEntryID)
                    {
                        if (CurrentLedger[EntryNumber].Debit > 0)
                        {
                            CurrentLedger[EntryNumber].Amount = 0.00M - NewValue;
                            CurrentLedger[EntryNumber].Debit = NewValue;
                        }
                        else
                        {
                            CurrentLedger[EntryNumber].Amount = NewValue;
                            CurrentLedger[EntryNumber].Credit = NewValue;
                        }

                        if (EntryNumber > 1)
                            CurrentLedger[EntryNumber].Balance = CurrentLedger[EntryNumber - 1].Balance
                                                                       + CurrentLedger[EntryNumber].Credit
                                                                       - CurrentLedger[EntryNumber].Debit;
                        else
                            CurrentLedger[EntryNumber].Balance = 0.00M
                                                                       + CurrentLedger[EntryNumber].Credit
                                                                       - CurrentLedger[EntryNumber].Debit;
                        UpdateFollowingTransactionBalances(EntryNumber);
                        HasChanged();
                        break;
                    }
                }
            }
        }
        private void UpdateFollowingTransactionBalances(int startingPoint)
        {
            int LIndex = startingPoint + 1;
            decimal RunningBalance = CurrentLedger[startingPoint].Balance;
            while (LIndex < CurrentLedger.Count)
            {
                RunningBalance = RunningBalance + CurrentLedger[LIndex].Credit - CurrentLedger[LIndex].Debit;
                CurrentLedger[LIndex].Balance = RunningBalance;
                LIndex++;
            }
        }
    }
}
