--- dirty read ---
begin transaction
update Orders set Quantity = 4 where OrderId = 2

--- non repetable read ---
begin transaction
update Orders set Quantity = 3 where OrderId = 2
commit transaction

--- phantom Read ---
begin transaction
insert into Orders values('Mobile',2,23456.00)
commit transaction

