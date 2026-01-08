--- Triggers  ---
/* 1. Create a trigger on Products 
Prevent deletion of a product if it is part of any OrderDetails.  */

alter Trigger trg_PreventProductDelete
on Products
instead of delete
as
begin
  set nocount on

  if exists(select 1 from OrderDetails od 
  join deleted d on od.ProductId = d.ProductId)
  begin
    print 'Error : Cannot delete Product because it exists in OrderDetails'
    return
  end
delete from Products where ProductId in(select ProductId from deleted)
end

delete from Products where ProductId = 103
delete from Products where ProductId = 999

/* 2. Create an AFTER UPDATE trigger on Payments 
Log old and new payment values into a PaymentAudit table. */

create table PaymentAudit (
    AuditID int identity (1,1) PRIMARY KEY,
    PaymentID int,
    OldAmount decimal(10,2),
    NewAmount decimal(10,2),
    OldPaymentDate date,
    NewPaymentDate date,
    ChangedOn datetime default GETDATE()
);

create trigger trg_PaymentUpdateAudit
on Payments
after update
as
begin
  set nocount on
  insert into PaymentAudit(
  PaymentID,
        OldAmount,
        NewAmount,
        OldPaymentDate,
        NewPaymentDate
   )
   select
   d.PaymentId,d.Amount as OldAmount,i.Amount as NewAmount,
   d.PaymentDate as OldPaymentDate,
   i.PaymentDate as NewPaymentDate
   from deleted d
   join inserted i on d.PaymentId = i.PaymentId;
end

update Payments set Amount = 9999 where PaymentId = 7002

select * from PaymentAudit


/* 3. Create an INSTEAD OF DELETE trigger on Customers 
Logic: 
• If customer has orders → mark status as “Inactive” instead of deleting 
• If no orders → allow deletion */




create trigger trg_CustomerDeleteControl
on Customers
instead of delete
as
begin
  set nocount on

  update Customers set Status = 'Inactive'
  where CustId in(
  select d.CustId from deleted d join Orders o on d.CustId = o.CustId
  )

  delete from Customers where CustId in(
  select d.CustId from deleted d
  where not exists(select 1 from Orders o where o.CustId = d.CustId)
  )
  end

  delete from Customers where CustId = 1
  delete from Customers where CustId = 6
  select * from Customers

