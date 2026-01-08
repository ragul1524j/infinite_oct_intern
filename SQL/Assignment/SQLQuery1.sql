create database infinite_db;
use infinite_db;

create table student(
student_id int,
studentname varchar(50),
age int,
address varchar(100)
);


insert into student values(1,'Arun',20,'chennai'),
 (2,'Priya Sharma', 22, 'Coimbatore'),
(3, 'Rahul Singh', 21, 'Madurai'),
(4, 'Meena Reddy', 23, 'Salem'),
(5, 'Vikram Das', 20, 'Trichy');

select * from student;


create view v1 
as 
select student_id,studentname from student;

select * from v1;

create view v3
with encryption
as
select student_id,studentname,age from student;

select * from v3;

insert into v3 values(102,'Keerthick',21);



create view v2 with
encryption,schemabinding
as
select student_id,studentname,age from dbo.student where age >=21 with check option;

select * from v2;

insert into v2 values(101,'ragul',22);


create view v5
with schemabinding
as
select student_id,studentname,age from dbo.student;

insert into student values(103,'_sairam',24,'andhrapradesh'),
(104,'_manikanta',24,'andhrapradesh');

select * from student;
delete from student where studentname = '_manikanta';

