# CheckBook
A Checkbook application with user interface and Excel database

This is a quick and dirty checkbook program that I wrote to replace my old DOS Quicken program. 
The computer that the Quicken was running on finally started to have the power die and I needed a new program.

When I looked at the C# checkbook programs here, most lacked a user interface and weren't attractive to me.

This program uses an Excel .CSV file as the database. That offers several benefits:
1. The user can write their own reports in Excel or in Power BI
2. The database doesn't need a fancy database system to run.
3. It makes sharing data with other programs very easy.

This program also is able to import data from DOS Quicken (version 2000 in my case).

Right now, the functions include

1. Pull in the database and compute the current balance
2. Add a transaction to the database and continue the balance
3. Put the transaction in a category
4. Remember the last transaction to a payee and auto fill this transaction with that data
5. Reconcile the ledger with the bank statement
6. Allow transactions to be broken up into multiple sub-categories
7. Reporting split up by category (helps with taxes)

USE THIS PROGRAM AT YOUR OWN RISK!!!!

I wrote this for my own use. Your use of this program may open you up to financial mistakes. 

Example user interface:
Main screen showing the current ledger
![image](https://user-images.githubusercontent.com/16313413/148289799-2ee31a4e-3716-427e-a476-a48de4d989ae.png)


How to add a transaction to the ledger
![image](https://user-images.githubusercontent.com/16313413/148289915-dbdbdfb3-d32e-4a8d-8388-3ca0efe34b79.png)

Adding transaction with split categories
![image](https://user-images.githubusercontent.com/16313413/148290187-6b649b32-6cf8-40a4-9076-4132da489dc7.png)


Reconciliation Screen
![image](https://user-images.githubusercontent.com/16313413/148290242-5756d0a2-ea86-4186-a0d0-0bb1c4acd42e.png)

Report Screen
![image](https://user-images.githubusercontent.com/16313413/148290293-4edd553a-dde7-4e04-82fc-ebc371f8693a.png)



Known Issues:
For some reason, the DataGridView for reconciling deposits throws an exception when clicking on a deposit that was 
added during the reconciliation process. How I can get around that is to add all the missing transactions in the 
reconcile screen, back out of that screen, and re-enter the reconciliation process. Then, clicking on such a deposit works.
