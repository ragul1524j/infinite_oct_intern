use adonet;

select name from sys.tables;

create table students (
    studentid int identity(1,1) primary key,
    fullname varchar(100) not null,
    email varchar(100) unique,
    department varchar(50) not null,
    yearofstudy int not null
);

create table courses (
    courseid int identity(1,1) primary key,
    coursename varchar(100) not null,
    credits int not null,
    semester varchar(20) not null
);

create table enrollments (
    enrollmentid int identity(1,1) primary key,
    studentid int not null,
    courseid int not null,
    enrolldate datetime not null,
    grade varchar(5),

    foreign key (studentid) references students(studentid),
    foreign key (courseid) references courses(courseid)
);

insert into students (fullname, email, department, yearofstudy)
values
('arun kumar', 'arun@example.com', 'computer science', 2),
('priya sharma', 'priya@example.com', 'mechanical', 3),
('ravi teja', 'ravi@example.com', 'computer science', 1),
('meena gupta', 'meena@example.com', 'electrical', 4),
('kiran rao', 'kiran@example.com', 'civil', 2);

insert into courses (coursename, credits, semester)
values
('data structures', 4, 'fall'),
('operating systems', 3, 'fall'),
('database systems', 4, 'spring'),
('digital electronics', 3, 'spring'),
('engineering math', 5, 'fall'),
('computer networks', 4, 'spring');

insert into enrollments (studentid, courseid, enrolldate, grade)
values
(1, 1, getdate(), 'a'),
(1, 2, getdate(), 'b'),
(2, 4, getdate(), null),
(3, 1, getdate(), 'a'),
(3, 3, getdate(), 'c');

select * from students;
select * from courses;
select * from enrollments;

create procedure usp_getcoursesbysemester
@semester varchar(20)
as
begin
   select courseid,coursename,credits,semester
   from courses
   where semester = @semester
end;

exec usp_getcoursesbysemester 'spring';
