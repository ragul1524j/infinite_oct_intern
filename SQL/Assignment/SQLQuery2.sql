create table employee(
emp_id int,
emp_name varchar(50),
emp_age int,
emp_salary decimal
);


INSERT INTO employee (emp_id, emp_name, emp_age, emp_salary)
VALUES
(1, 'John Smith', 30, 45000.00),
(2, 'Alice Johnson', 28, 52000.00),
(3, 'Robert Brown', 35, 60000.00),
(4, 'Emily Davis', 26, 48000.00),
(5, 'Michael Wilson', 40, 75000.00),
(6, 'Sophia Taylor', 32, 55000.00),
(7, 'Daniel Anderson', 29, 50000.00),
(8, 'Olivia Thomas', 31, 58000.00),
(9, 'James Martinez', 38, 70000.00);

WITH getmax(a,b) as (
select sum(emp_age),emp_name from employee