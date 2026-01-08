/* Create a table BankAccount with sample records. 
Write a transaction that transfers money from one account to another. 
If the source account balance becomes negative, roll back the transaction; otherwise 
commit.  */


create table BankAccount(
account_num int,
holder_name varchar(20),
balance decimal(10,2)
)
insert into BankAccount values(101,'Akshay',56789.00),(102,'Keerthickragul',156789.00)
,(103,'SaiRam',66789.00),(104,'Manikanta',116789.00)

select * from BankAccount

declare @source int = 10
declare @target int = 12
declare @amount decimal(10,2) = 2346.00
begin transaction
update BankAccount set balance = balance - @amount where account_num = @source
if(select balance from BankAccount where account_num = @source) < 0
begin
   print 'Insufficient Balance'
   rollback transaction
end
else
begin
  update BankAccount set balance = balance + @amount where account_num = @target
  print 'Amount Succesfully Transferred'
  commit transaction
end


/* 2. Using SAVEPOINT 
Insert three new records into a table Orders. 
Create a SAVEPOINT after each insert. 
Rollback only the second insert using the SAVEPOINT, then commit the remaining inserts. */


begin transaction
insert into BankAccount VALUES(10,'Mani',56789.00)
save transaction sp1
insert into BankAccount VALUES(11,'Virat',56719.00)
save transaction sp2
insert into BankAccount VALUES(12,'Gokul',567199.00)
save transaction sp3
rollback transaction sp1   -- Removes ONLY Virat (11)                        -- Removes Gokul (12) also (because inserted after sp2)
insert into BankAccount VALUES(12,'Gokul',567199.00)  -- Re-insert 3rd row
commit transaction

truncate table BankAccount
select * from BankAccount

/* 3. Handling Errors with TRY…CATCH 
Write a transaction that updates prices in a Products table. 
Introduce a division-by-zero error inside the transaction. 
Use TRY…CATCH to rollback the transaction and log the error message in a separate 
ErrorLog table */

select * from dbo.storelogs

begin try
begin transaction
 update BankAccount set balance = balance + 1000 where account_num = 10
 declare @n int = 10/0
commit transaction
end try
begin catch
 rollback transaction
 insert into storelogs values(error_message(),getdate())
 print 'Error Occured : '+error_message()
end catch

/* 4. Nested Transactions 
Create nested transactions: 
• Outer transaction inserts a customer 
• Inner transaction inserts an order for the customer 
• Force an error in the inner transaction 
Practice observing whether the outer transaction is committed or rolled back. */

select * from Customer
select * from Orders

begin try

begin transaction
 insert into Customer values (11,'Kumar',111,3,'Chennai')

 begin try
   begin transaction
       declare @x int = 1/0
       insert into Orders values('PowerBank',1,1200)
   commit transaction
 end try

 begin catch
   print 'Error Occured in Inner Transaction : ' + error_message()
 end catch

commit transaction

end try
begin catch
print 'Error Occured in Outer Transaction : ' + error_message()
end catch

/* 5.Isolation Level – Dirty Read 
Use two sessions: 
• Session 1: Open a transaction, update a row, but don’t commit 
• Session 2: Use SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED and read 
the same row 
Check whether dirty reads are allowed. */

select * from Orders

set transaction isolation level read uncommitted
select * from Orders where OrderId = 2
waitfor delay '00:00:10'
select * from Orders where OrderId = 2


/* 6. Isolation Level – Non-repeatable Read 
Using two sessions: 
• Session 1 reads a row twice inside a transaction 
• Session 2 updates and commits the same row in between 
Observe changes and understand non-repeatable reads. */

set transaction isolation level repeatable read
begin transaction
select * from Orders where OrderId = 2
waitfor delay '00:00:10'
select * from Orders where OrderId = 2
commit transaction

/* 7. Isolation Level – Phantom Read
Create a table Sales.
Using two sessions:
• Session 1 selects rows between a range inside a transaction
• Session 2 inserts a new row within the range and commits
See if the first session sees new rows depending on isolation leve */

set transaction isolation level read committed
begin transaction
select * from Orders
waitfor delay '00:00:10'
select * from Orders
commit transaction

/* 8.Savepoint with Partial Rollback
Inside a transaction:
• Update 5 employee salaries
• Create a savepoint after each update
• Rollback to savepoint 3
• Commit the rest
Check which rows were updated finally. */

begin transaction

update Orders set Quantity = 4 where OrderId = 1
save transaction sp1
update Orders set Quantity = 4 where OrderId = 2
save transaction sp2
update Orders set Quantity = 3 where OrderId = 3
save transaction sp3
update Orders set Quantity = 1 where OrderId = 1
save transaction sp4
update Orders set Quantity = 2 where OrderId = 2
save transaction sp5

rollback transaction sp2;
commit transaction;

/* 9.Insert multiple product records using a single transaction.
Force an error in one insert (duplicate key or null value).
Ensure that no records are inserted into the table. */
select * from Products
begin try
  begin transaction
    insert into Products values('21','comb',2,45.00)
    INSERT INTO Products VALUES ('22', 'Soap', 5, 30.00);
INSERT INTO Products VALUES ('23', 'Shampoo', 3, 120.00);
INSERT INTO Products VALUES ('24', 'Toothpaste', 4, 55.00);
INSERT INTO Products VALUES ('25', 'Face Cream', 2, 150.00);
  commit transaction
end try

begin catch
  print 'Error Occurred : ' + error_message()
end catch

/* 10.Savepoint in TRY…CATCH
Inside a long transaction:
• Insert 3 orders
• Savepoint after each
• Force an error before the third insert
Use savepoint rollback to keep first 2 insert */

BEGIN TRY
    BEGIN TRANSACTION;

    -- Insert 1 (OrderId auto-generated)
    INSERT INTO Orders (ProductName, Quantity, Price)
    VALUES ('Laptop', 1, 56000);
    SAVE TRANSACTION sp1;

    -- Insert 2
    INSERT INTO Orders (ProductName, Quantity, Price)
    VALUES ('Keyboard', 2, 2500);
    SAVE TRANSACTION sp2;

    -- Force error before Insert 3
    DECLARE @x INT = 10/0;   -- ERROR

    -- Insert 3 (will not run)
    INSERT INTO Orders (ProductName, Quantity, Price)
    VALUES ('Mouse', 1, 1200);
    SAVE TRANSACTION sp3;

    COMMIT TRANSACTION;
END TRY

BEGIN CATCH
    PRINT 'Error Occurred : ' + ERROR_MESSAGE();

    -- Rollback AFTER Savepoint 2
    ROLLBACK TRANSACTION sp2;

    -- Commit remaining valid inserts (first two)
    COMMIT TRANSACTION;
END CATCH;















 




 