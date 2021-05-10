CREATE TABLE Subjects
(
SubjectId INT PRIMARY KEY,
SubjectName VARCHAR (50) NOT NULL
)

CREATE TABLE Majors
(
MajorID INT PRIMARY KEY,
[Name] VARCHAR (50) NOT NULL
)
CREATE TABLE Students
(
StudentID INT PRIMARY KEY,
StudentNumber INT NOT NULL,
StudentName VARCHAR (50) NOT NULL,
MajorID INT REFERENCES Majors(MajorID)
)

CREATE TABLE Payments
(
PaymentID INT PRIMARY KEY,
PaymentDate DATETIME,
PaymentAmount DECIMAL (10,2),
StudentID INT REFERENCES Students(StudentID)
)

CREATE TABLE Agenda
(
StudentID INT,
SubjectID INT,

CONSTRAINT PK_Student_Subject PRIMARY KEY(StudentID,SubjectID),
CONSTRAINT FK_Student FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
CONSTRAINT FK_Subject FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
)