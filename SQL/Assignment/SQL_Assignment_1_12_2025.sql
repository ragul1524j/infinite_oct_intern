create table Employees
(
EmpId INT PRIMARY kEY,
EmpName VARCHAR(100),
DeptId INT,
ManagerId INT NULL,
JoinDate DATE,
Salary DECIMAL(10,2)
);


INSERT INTO Employees VALUES 
(1, 'Amit', 10, NULL, '2020-01-10', 65000), 
(2, 'Neha', 10, 1,    '2022-02-15', 50000), 
(3, 'Ravi', 20, 1,    '2023-03-12', 45000), 
(4, 'Sana', 20, 3,    '2024-01-20', 42000), 
(5, 'Karan', 30, 1,   '2021-07-18', 55000); 



CREATE TABLE Departments 
( 
    DeptId INT PRIMARY KEY, 
    DeptName VARCHAR(100) 
); 

INSERT INTO Departments VALUES 
(10, 'IT'), 
(20, 'HR'), 
(30, 'Finance'); 

CREATE TABLE Sales 
( 
    SaleId INT PRIMARY KEY, 
    EmpId INT, 
    Region VARCHAR(50), 
    SaleAmount DECIMAL(10,2), 
    SaleDate DATE 
); 


INSERT INTO Sales VALUES 
(1, 1, 'North', 100000, '2024-01-01'), 
(2, 2, 'North',  90000, '2024-01-10'), 
(3, 3, 'South', 120000, '2024-02-05'), 
(4, 4, 'South', 120000, '2024-02-20'), 
(5, 5, 'North', 110000, '2024-03-15');

CREATE TABLE Transactions 
( 
    TransId INT PRIMARY KEY, 
    AccountId INT, 
    Amount DECIMAL(10,2), 
    TransDate DATE 
);


INSERT INTO Transactions VALUES 
(1, 101, 1000, '2024-01-01'), 
(2, 101, 2000, '2024-02-01'), 
(3, 101, -500, '2024-03-01'), 
(4, 102, 1500, '2024-01-15'), 
(5, 102, -200, '2024-03-10');

/* ----------
   Views
   CTE
   Programming
   Ranking
   ---------*/

select * from Employees;

--- task 1 ---

SELECT EmpId,EmpName,DeptId,Salary,
CASE
  WHEN Salary < 20000 THEN 'LOW'
  WHEN Salary BETWEEN 20000 AND 50000 THEN 'MEDIUM'
  ELSE 'HIGH'
END AS SalaryCatergory

FROM Employees;


--- task 2 ---
declare @age int
set @age = 21

if(@age < 18)
print 'Minor'
else if(@age >= 18 and @age <= 60)
print 'Adult'
else
print 'Senior'


--- task 3 ---
create view dbo.View_EmployeeDetails
with
encryption,schemabinding
as
select
e.EmpId,
e.EmpName,
e.DeptId,
e.JoinDate,
e.ManagerId,
e.Salary,
(e.Salary * 12) As AnnualSalary
From dbo.Employees e
INNER JOIN dbo.Departments d ON d.DeptId = e.DeptId
Where e.JoinDate >= DATEADD(YEAR,-3,GETDATE());

select * from dbo.View_EmployeeDetails;

SELECT
 e.EmpId,
 e.EmpName,
 e.DeptId,
 SUM(s.SaleAmount) AS TotalSales,
 RANK() OVER(ORDER BY SUm(s.SaleAmount) DESC) AS SalesRank
 FROM dbo.Employees e
 JOIN dbo.Sales s
 ON e.EmpId = s.EmpId
group by
e.EmpId,e.DeptId,e.EmpName
order by
TotalSales DESC;

--- tatsk 5 ---

declare @x int,@y int;
set @x = 10;

begin try
   set @y = @x/0
   print 'Value of y = ' + cast (@y AS VARCHAR(10)) 
end try
begin catch

  print 'Zero Division Error' + ErrorMessage()
end catch

--- task 6 ---
declare @salary int
set @salary = 18900

if(@salary < 1000)
BEGIN 
  ;THROW 50001, 'Salary is too low. Minimum salary must be 1000.', 1;
end
ELSE
begin
  print 'Salary is acceptable'
end


--- task 7 ---
SELECT 
    E.EmpId,
    E.EmpName,
    E.Salary,
    RANK() OVER (ORDER BY E.Salary DESC) AS RankSalary,
    DENSE_RANK() OVER (ORDER BY E.Salary DESC) AS DenseSalary,
    ROW_NUMBER() OVER (ORDER BY E.Salary DESC) AS RowSalary
FROM Employees E;

--- task 8 ---
select * from Employees;

select * from Departments;
select * from Sales;

select * from Sales where SaleDate >= DATEADD(year,-1,GETDATE());


with CTE1 as(
select Region,SaleAmount from Sales
where SaleDate >= DATEADD(YEAR,-1,'2024-03-15')
),

CTE2 AS(
select Region,sum(SaleAmount) as TotalSales
From CTE1 group by Region
),

CTE3 AS(
select Region,TotalSales,
RANK() OVER(ORDER BY TotalSales DESC) AS SalesRank
FROM CTE2
)

SELECT * FROM CTE3 WHERE SalesRank <= 3;


 
 --- task 9 ---
 WITH EmpCTE AS(
 select
 *,
 ROW_NUMBER() OVER (ORDER BY EmpId) AS Ranks
 FROM Employees
 )

 select * from EmpCTE where Ranks BETWEEN 51 and 100;
  











