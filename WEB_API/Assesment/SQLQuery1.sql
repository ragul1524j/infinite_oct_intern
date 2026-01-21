Create database CompanyDb;

Use CompanyDb;
Create table Employees
(
 EmployeeId int primary key,
    FirstName nvarchar(50),
   LastName nvarchar(50)
);
Insert into Employees values (5, 'Buchanan', 'Steven');
Insert into Employees values (6, 'Nancy', 'Davolio');
Create table Orders
(
 OrderId int primary key identity,
    OrderDate datetime,
    EmployeeId int,
    foreign key (EmployeeId) references Employees(EmployeeId)
);
Insert into Orders values (getdate(), 5);
Insert into Orders values (getdate(), 5);
Insert into Orders values (getdate(), 6);
Create table Customers
(
    CustomerId int primary key identity,
    CustomerName nvarchar(100),
    Country nvarchar(50)
);
Insert into Customers values ('John Smith', 'USA');
Insert into Customers values ('Arun Kumar', 'India');
Insert into Customers values ('Maria Garcia', 'Spain');
Insert into Customers values ('David Miller', 'USA');
Create procedure GetCustomersByCountry
    @Country nvarchar(50)
As
Begin
    Select * From Customers Where Country = @Country;
End;
Select * from Employees;
Select * from Orders;
Select * from Customers;
Exec GetCustomersByCountry 'USA';
