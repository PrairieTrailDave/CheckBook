# CheckBook
A Checkbook application with user interface

This is a quick and dirty checkbook program that I wrote to replace my old DOS Quicken program. 
The computer that the Quicken was running on finally started to have the power die and I needed a new program.

When I looked at the C# checkbook programs here, most lacked a user interface and weren't attractive to me.

This program uses an Excel .CSV file as the database. That offers several benefits:
1. The user can write their own reports in Excel or in Power BI
2. The database doesn't need a fancy database system to run.
3. It makes sharing data with other programs very easy.

This program also is able to import data from DOS Quicken (version 2000 in my case).

Right now, the functions include

a. Pull in the database and compute the current balance

b. Add a transaction to the database and continue the balance

c. Put the transaction in a category

d. Remember the last transaction to a payee and auto fill this transaction with that data

e. Reconcile the ledger with the bank statement

f. Allow transactions to be broken up into multiple sub-categories


USE THIS PROGRAM AT YOUR OWN RISK!!!!

I wrote this for my own use. Your use of this program may open you up to financial mistakes. 

Example user interface:
Main screen showing the current ledger
![image](https://user-images.githubusercontent.com/16313413/146239323-5940c335-1ecf-4a84-9836-9fa6c4773af9.png)

How to add a transaction to the ledger
![image](https://user-images.githubusercontent.com/16313413/146238391-ca0f7922-11b8-47d2-83a2-e1500f2618cb.png)

Reconciliation Screen
![image](https://user-images.githubusercontent.com/16313413/146239192-ae597906-a078-4f34-9d22-146265c3323e.png)




Known Issues:
For some reason, the DataGridView for reconciling deposits throws an exception when clicking on a deposit that was 
added during the reconciliation process. How I can get around that is to add all the missing transactions in the 
reconcile screen, back out of that screen, and re-enter the reconciliation process. Then, clicking on such a deposit works.
