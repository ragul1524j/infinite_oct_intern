--- Functions ---
/* 1. Create a table-valued function: fn_GetCustomerOrderHistory(@CustID) 
Return: OrderID, OrderDate, TotalAmount. */

create function dbo.fn_GetCustomerOrderHistory(@CustId int)
returns table
as
return(select
o.OrderId,o.OrderDate,sum(od.Qty * p.Price) as TotalAmount
from Orders o
join OrderDetails od on o.OrderId = od.OrderId
join Products p on od.ProductId = p.ProductId
where o.CustId = @CustId
group by o.OrderId,o.OrderDate
);

select * from dbo.fn_GetCustomerOrderHistory(1);

/* . Create a function fn_GetCustomerLevel(@CustID) 
Logic: 
• Total purchase > 1,00,000 → "Platinum" 
• 50,000–1,00,000 → "Gold" 
• Else → "Silver"  */

create function dbo.fn_GetCustomerLevel (@CustId int)
returns varchar(20)
as
begin
 declare @TotalPurchase decimal(18,2)
 declare @Level varchar(50)

 select @TotalPurchase = sum(od.Qty * p.Price) from Orders o
 join OrderDetails od on o.OrderId = od.OrderId
 join Products p on od.ProductId = p.ProductId where o.CustId = @CustId

 set @TotalPurchase = isnull(@TotalPurchase,0)

 if(@TotalPurchase > 100000)
   set @Level = 'Platinum'
 else if(@TotalPurchase >= 50000 and @TotalPurchase <= 100000)
   set @Level = 'Gold'
 else
   set @Level = 'Silver';
 return @Level
end

select dbo.fn_GetCustomerLevel(1) as CustomerLevel