using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckBook
{
    public class MyCheckbook
    {
        public List<LedgerEntry> CurrentLedger { get; set; }
        public List<AccountCategory> Accounts { get; set; }

        public int InsertTransaction (LedgerEntry newEntry)
        {
            // if there are no transaction in the ledger,
            // simply add this transaction

            if (CurrentLedger.Count == 0)
            {
                newEntry.Balance = newEntry.Credit - newEntry.Debit;
                CurrentLedger.Add(newEntry);
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
                    return CurrentLedger.Count-1;
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
                        return LedgerIndex;
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
                                    return CurrentLedger.Count-1;
                                }
                                else
                                {
                                    newEntry.Balance = CurrentLedger[secondIndex - 1].Balance + newEntry.Credit - newEntry.Debit;
                                    CurrentLedger.Insert(secondIndex, newEntry);
                                    UpdateFollowingTransactionBalances(secondIndex);
                                    return secondIndex;
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
                                return CurrentLedger.Count-1;
                            }
                            else
                            {
                                newEntry.Balance = CurrentLedger[secondIndex - 1].Balance + newEntry.Credit - newEntry.Debit;
                                CurrentLedger.Insert(secondIndex, newEntry);
                                UpdateFollowingTransactionBalances(secondIndex);
                                return secondIndex;
                            }
                        }
                    }
                    // don't think it should get here, but if it does, simply add to end
                    newEntry.Balance = newEntry.Credit - newEntry.Debit;
                    CurrentLedger.Add(newEntry);
                    return CurrentLedger.Count-1;
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
