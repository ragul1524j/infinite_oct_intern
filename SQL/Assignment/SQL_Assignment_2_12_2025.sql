--- task 1 ---


alter procedure AddColumns(@id int,@name varchar(20),@age int)
as
begin
insert into students(student_id,student_name,student_address,student_age)
values(@id,@name,NULL,@age)
end

exec AddColumns 104,'Keerthick ragul',21;

select * from students;

--- task 2 ---

select * from Sales;
INSERT INTO Sales (SaleId, EmpId, Region, SaleAmount, SaleDate) VALUES
(6, 1, 'North', 95000.00,  '2004-02-10'),
(7, 2, 'South', 105000.00, '2004-07-15'),
(8, 3, 'East', 98000.00,   '2004-11-20'),

(9, 1, 'North', 115000.00, '2005-03-05'),
(10, 4, 'West', 125000.00, '2005-08-19'),
(11, 5, 'South', 102000.00,'2005-12-22'),

(12, 2, 'East', 110000.00, '2006-01-14'),
(13, 3, 'North', 132000.00,'2006-06-25'),
(14, 4, 'South', 118000.00,'2006-10-09'),

(15, 5, 'West', 140000.00, '2007-03-12'),
(16, 1, 'North', 100000.00,'2007-07-30'),
(17, 2, 'South', 99000.00, '2007-11-18'),

(18, 3, 'East', 128000.00, '2008-02-21'),
(19, 4, 'South', 119000.00,'2008-05-10'),
(20, 5, 'North', 135000.00,'2008-09-29');


create procedure OrderDetails(@start date,@end date)
as
select * from Sales where SaleDate BETWEEN @start AND @end

exec OrderDetails '2005-12-01','2007-12-02'

--- task 3 ---
select * from dbo.Customer;
exec sp_help Customer;

alter procedure Customer_Id(@id int,@n1 int output,@m1 int output)
as
select @m1 = productId,@n1 =Qty from Customer where CustId = @id;

declare @quantity int,@productid int
exec Customer_Id 2,@quantity output,@productid output;
print @productid
print @quantity


--- task 4 ---
select * from Products

alter procedure CheckBookStock
as
if exists(select 1 from Products where Productname ='Books')
begin
  select sum(stock) as totalstock from Products where Productname = 'Books'
end
else
begin
  print 'Productname books not found'
end

exec CheckBookStock


--- task 5 ---

create table customerduplicates(
CustId int primary key,
CustName varchar(50),
ProductId int,
Qty int

)
alter procedure sp_getdata
as
select CustId, 
        CustName, 
        ProductId, 
        Qty from Customer;

insert into customerduplicates exec sp_getdata

select * from customerduplicates

--- task 6 ---

create procedure GetCustomerByRow(@startrow int,@endrow int)
as
begin
  with cte as(
   select CustId,CustName,ProductId,Qty,
   ROW_NUMBER() OVER(ORDER BY CustId) as RowNum
   from Customer
  )

  select CustId,CustName,ProductId,Qty from cte where RowNum between @startrow AND @endrow;
end

GetCustomerByRow 2,5

--- task 7 ---
create table employee2(
  empid int identity(1,1) primary key,
  empname varchar(20),
  department varchar(20),
  salary decimal(10,2)
);

select * from employee2

alter procedure spAddEmployee(
@name varchar(20),@dept varchar(20),@salary decimal(10,2),@m int output
)
as
begin
insert into employee2 (empname,department,salary)values(@name,@dept,@salary);

set @m = SCOPE_IDENTITY()
end

declare @scope_val int
exec spAddEmployee 'ragul','it',45000.00,@scope_val output
print @scope_val

--- task 8 ---
select * from Products;
insert into Products values(11,'Electronics',30)

create procedure spGetProductsByCategory
(@categoryname varchar(20) = 'Electronics')
as
begin
select * from Products where ProductName = @categoryname
end

exec spGetProductsByCategory 'Mobile'

--- task 9 ---
select * from Sales
select * from Products
create table storelogs(
logid int identity(1,1) primary key,
errormessage varchar(2000),
errordate datetime
)

CREATE TABLE Orders (
    OrderId INT IDENTITY(1,1) PRIMARY KEY,
    ProductName VARCHAR(50),
    Quantity INT,
    Price DECIMAL(10,2)
);

alter procedure spSafeOrderInsert
(@name varchar(20),@stock int,@price int)
as
begin
begin try
  insert into Orders(ProductName,Quantity,Price)
  values(@name,@stock,@price)
end try

begin catch
  insert into storelogs(errormessage,errordate)
  values(ERROR_MESSAGE(),GETDATE())
end catch
end

exec spSafeOrderInsert 'Laptop',45000.00;

select * from Orders

select * from storelogs

--- task 10 ---
select * from Employees;
 
create procedure spUpdateSalary(@Empid int,@percentage int)
as
update Employees set Salary=Salary+Salary*@percentage/100
where EmpId=@Empid
 
exec spUpdateSalary 1,10;











