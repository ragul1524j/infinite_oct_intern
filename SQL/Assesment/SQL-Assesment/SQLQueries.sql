/* List customers who placed an order in the last 30 days. */

select distinct c.CustId,c.CustName,c.City from Customers c
join Orders o on c.CustID = o.CustId
where o.OrderDate >= dateadd(day,-30,getdate())

/*Display top 3 products that generated the highest total sales amount */

select top 3 p.ProductId,p.ProductName,
sum(o.Qty * p.Price) as TotalSales
from OrderDetails o
join Products p on o.ProductId = p.ProductId
group by p.ProductId,p.ProductName
order by TotalSales desc

/* For each city, show number of customers and total order count. */

select c.City,count(distinct c.CustId) as TotalCustomers,count(o.OrderId) as TotalOrders
from Customers c left join Orders o on c.CustID = o.CustID
group by c.City;

/* Retrieve orders that contain more than 2 different products. */

select OrderId from OrderDetails group by OrderId having count(distinct ProductId) > 2

/* Show orders where total payable amount is greater than 10,000 */

select o.OrderId,sum(o.Qty * p.Price) as TotalAmount
from OrderDetails o
join Products p on o.ProductId = p.ProductId
group by o.OrderId having sum(o.Qty * p.Price) > 10000;

/* List customers who ordered the same product more than once */

select distinct c.CustId,c.CustName from Customers c
join Orders o on c.CustId = o.CustId join OrderDetails
od on o.OrderId = od.OrderId group by c.CustId,c.CustName,od.ProductId
having count(od.ProductId) > 1;

/* Display employee-wise order processing details */

select c.CustId,c.CustName,count(o.OrderId) as TotalOrdersPlaced,
sum(p.Amount) as TotalAmountPaid from Customers c
left join Orders o On c.CustId = o.CustId
left join Payments p on o.OrderId = p.OrderId
group by c.CustId,c.CustName;

select e.EmployeeID,e.FirstName + ' ' + e.LastName as EmployeeName,
count(o.OrderId) as TotalOrdersProcessed,
sum(p.Amount) as TotalamountHandled
from Employees e
left join Orders o on e.EmployeeID = o.EmployeeID
left join Payments p on o.OrderId = p.OrderId
group by e.EmployeeID,e.FirstName,e.LastName
order by e.EmployeeID




select * from Employees
EXEC sp_help Orders;


