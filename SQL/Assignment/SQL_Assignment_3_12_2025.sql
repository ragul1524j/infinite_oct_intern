--- task 1 ---
create function Gretter_num(@a int,@b int,@c int)
returns int
as
begin
declare @result int
if(@a > @b and @a > @c)
 set @result = @a
else if(@b > @a and @b > @c)
 set @result = @b
else
 set @result = @c
 return @result
 end

 select dbo.Gretter_num(10,24,12) as greater_num

 --- task 2 ---
 select * from Products
 alter table Products add price decimal(10,2)

 INSERT INTO Products (ProductId, ProductName, Stock, price) VALUES
(12, 'Headphones', 35, 1500.00),
(13, 'Power Bank', 45, 1200.00),
(14, 'USB Cable', 80, 150.00),
(15, 'Smart Watch', 25, 4500.00),
(16, 'Bluetooth Speaker', 30, 2200.00),
(17, 'Flash Drive 32GB', 60, 400.00),
(18, 'Printer', 12, 8500.00),
(19, 'Monitor 24 Inch', 18, 11000.00),
(20, 'Desk Lamp', 40, 350.00),
(21, 'Gaming Mouse', 28, 1800.00);


alter function discount(@price int)
returns decimal(10,2)
as
begin
declare @discount decimal(10,2)
set @discount = @price - @price * 0.10
return @discount
end

select ProductId,ProductName,Stock,price as old_price, dbo.discount(price) as new_price from Products

--- task 3 ---
/* . create a function to calculate the discount on price as following
if productname = 'books' then 10%
if productname = toys then 15%
else
no discount */

alter function Discountroduct(@product varchar(30),@price decimal(10,2))
returns decimal(10,2)
as
begin
declare @discount decimal(10,2)
 if(@product = 'Headphones')
    set @discount = @price - @price * 0.1
 else if(@product = 'Power Bank')
    set @discount = @price - @price * 0.15   
 else
    set @discount = @price
return @discount
end

select ProductId,ProductName,Stock,dbo.Discountroduct(ProductName,price) as discounted_price from Products
select * from Products

--- task 4 ---
/* create inline function which accepts number and prints last n
years of orders made from now.
(pass n as a parameter */
select * from Transactions

create function GetByYear(@n int)
returns table
as
return select * from Transactions where TransDate >= dateadd(year,-@n,getdate())

select * from dbo.GetByYear(2)

--- select dbo.GetByYear(2) --- cannot use in inline functio it returns table not single row like scalar function





--- triggers ----
/*1. Create a trigger for table customer, which does not allow 
the user to delete the record who stays in Bangalore, 
Chennai, delhi */

select * from students

alter trigger tr1 on students
for delete
as
begin
if exists(select * from deleted where student_address in ('bangalore','Chennai','Delhi'))
begin
 print 'You Cannot delete this record'
 rollback transaction
end
end

delete from students where student_address = 'Pune'

--- task 2 ---
/* Create a triggers for orders which allows the user to insert 
only books, cd, mobile */

select * from Orders

create trigger tr2 on Orders
for insert
as
begin
if exists(select * from inserted where ProductName not in ('books','cd','mobile'))
begin
  print 'You Cannot Insert the Values'
  rollback transaction
end
end
insert into Orders values('grocery',5,'3466.00')
select * from Orders

/*. Create a trigger for customer table whenever an item is 
delete from this table. The corresponding item should be 
added in customerhistory table. */

select * from ProductsCopy

create trigger tr3 on Products
for delete
as
begin
insert into  ProductsCopy select * from deleted
end

delete from Products where ProductName = 'Laptop'

/*. Create update trigger for stock. Display old values and new 
values */

select * from Products
create trigger tr4 on Products
for update
as
begin
 SELECT 
        ProductId,
        ProductName,
        Stock AS OldStock
    FROM deleted;

    SELECT 
        ProductId,
        ProductName,
        Stock AS NewStock
    FROM inserted;
end

UPDATE Products SET Stock = 90  WHERE ProductId = 2;

--- task 10 ---



