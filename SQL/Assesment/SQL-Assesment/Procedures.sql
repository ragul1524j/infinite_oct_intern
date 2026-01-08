--- Procedures ---

/* 1. Create a stored procedure to update product price Rules: • Old price must be logged in a PriceHistory table • New price must be > 0 • If invalid, throw custom error. */

create table PriceHistory(
HistoryId int identity(1,1) primary key,
ProductId int foreign key references Products(ProductId),
OldPrice decimal(10,2),
ChangedDate datetime default getdate()
)

create procedure dbo.usp_UpdateProductPrice
@ProductId int,
@NewPrice decimal(10,2)
as
begin
 set nocount on
 if(@NewPrice <= 0)
 begin
   print 'Error : Price Needs to be greater than 0.'
   return;
 end

 declare @OldPrice decimal(10,2)
 select @OldPrice = Price FROM products where ProductId = @ProductId

 if(@OldPrice is null)
 begin
   print 'Error : Invalid ProductId'
   return
 end

 begin try
   begin transaction
     insert into PriceHistory(ProductId,OldPrice)
     values(@ProductId,@OldPrice);

     update Products set Price = @NewPrice
     where ProductId = @ProductId
   
   commit transaction

   print 'Price Updated Successfully'
 end try
 begin catch
   rollback transaction
   print 'Error Occurred during price updaton : ' + error_message()
 end catch
end

exec dbo.usp_UpdateProductPrice @ProductId = 103, @NewPrice = 12000

/* 2. Create a procedure sp_SearchOrders Search orders by: • Customer Name • City • Product Name • Date range (Any parameter can be NULL → Dynamic WHERE) */

create procedure dbo.sp_SearchOrders
@CustomerName varchar(100) = null,
@city varchar(100) = null,
@ProductName varchar(100) = null,
@StartDate date = null,
@EndDate date = null

as
begin
  set nocount on

  select
  o.OrderId,o.OrderDate,c.CustName,c.City,p.ProductName,od.Qty,p.Price
  as TotalAmount
  from Orders o 
  join Customers c on o.CustId = c.CustId join OrderDetails od on o.OrderId = od.OrderId
  join Products p on od.ProductId = p.ProductId
  where(@CustomerName is null or c.CustName like '%' + @CustomerName + '%')
  and (@City is null or c.City like '%' + @city + '%')
  and (@ProductName is null or p.ProductName like '%' + @ProductName + '%' )
  and(@StartDate is null or o.OrderDate >= @StartDate)
  and (@EndDate is null or o.OrderDate <= @EndDate)
  order by o.OrderDate desc;
end

exec dbo.sp_SearchOrders @CustomerName = 'Amit'
exec dbo.sp_SearchOrders @City = 'Delhi'
exec dbo.sp_SearchOrders @ProductName = 'Laptop';

exec dbo.sp_SearchOrders @StartDate = '2025-01-01',@EndDate = '2025-02-02'