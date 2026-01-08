use ADOnet

SELECT name FROM sys.tables;


CREATE TABLE Students (
    StudentId INT IDENTITY(1,1) PRIMARY KEY,
    FullName VARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE,
    Department VARCHAR(50) NOT NULL,
    YearOfStudy INT NOT NULL
);

CREATE TABLE Courses (
    CourseId INT IDENTITY(1,1) PRIMARY KEY,
    CourseName VARCHAR(100) NOT NULL,
    Credits INT NOT NULL,
    Semester VARCHAR(20) NOT NULL
);

CREATE TABLE Enrollments (
    EnrollmentId INT IDENTITY(1,1) PRIMARY KEY,
    StudentId INT NOT NULL,
    CourseId INT NOT NULL,
    EnrollDate DATETIME NOT NULL,
    Grade VARCHAR(5),

    FOREIGN KEY (StudentId) REFERENCES Students(StudentId),
    FOREIGN KEY (CourseId) REFERENCES Courses(CourseId)
);


INSERT INTO Students (FullName, Email, Department, YearOfStudy)
VALUES
('Arun Kumar', 'arun@example.com', 'Computer Science', 2),
('Priya Sharma', 'priya@example.com', 'Mechanical', 3),
('Ravi Teja', 'ravi@example.com', 'Computer Science', 1),
('Meena Gupta', 'meena@example.com', 'Electrical', 4),
('Kiran Rao', 'kiran@example.com', 'Civil', 2);



INSERT INTO Courses (CourseName, Credits, Semester)
VALUES
('Data Structures', 4, 'Fall'),
('Operating Systems', 3, 'Fall'),
('Database Systems', 4, 'Spring'),
('Digital Electronics', 3, 'Spring'),
('Engineering Math', 5, 'Fall'),
('Computer Networks', 4, 'Spring');


INSERT INTO Enrollments (StudentId, CourseId, EnrollDate, Grade)
VALUES
(1, 1, GETDATE(), 'A'),
(1, 2, GETDATE(), 'B'),
(2, 4, GETDATE(), NULL),
(3, 1, GETDATE(), 'A'),
(3, 3, GETDATE(), 'C');

select * from Students

select * from Courses

select * from Enrollments




