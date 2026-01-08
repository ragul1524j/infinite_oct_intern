select * from Employees

/* 1.Basic Cursor – Print All Employee Names 
Create a cursor on an Employees table to print each employee’s name one by one. */

declare @name varchar(100)

declare emp_cursor cursor
for select EmpName from Employees

open emp_cursor
 fetch next from emp_cursor into @name
 while @@fetch_status = 0
  begin
    print @name
    fetch next from emp_cursor into @name
  end
close emp_cursor
deallocate emp_cursor

/* 2. Cursor to Update Salary 
Create a cursor that increases each employee’s salary by 10%. 
Update the table inside the cursor loop. */
declare @salary decimal(10,2)
declare @empid int

declare update_cursor cursor for select EMpId,Salary from Employees

open update_cursor

fetch next from update_cursor into @empid,@salary

while @@fetch_status = 0
begin
  update Employees set Salary = @salary * 1.10 where EmpId = @empid

  fetch next from update_cursor into @empid,@salary
end

close update_cursor
deallocate update_cursor

select * from Employees

/* 3.Cursor with Conditional Logic 
Fetch all orders. 
While looping: 
• If quantity > 10 → give 5% discount 
• If quantity <= 10 → give 2% discount 
Update each order accordingly. */

select * from Orders

declare
  
