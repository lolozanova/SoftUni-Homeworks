--01. Find All Information About Departments
SELECT * FROM  Departments

--02. Find all Department Names
SELECT [Name] FROM  Departments

--03. Find Salary of Each Employee
SELECT [FirstName],[LastName],[Salary]
FROM Employees

--04. Find Full Name of Each Employee
SELECT [FirstName],[MiddleName],[LastName]
FROM Employees

--05. Find Email Address of Each Employee
SELECT [FirstName] + '.' + [LastName] + '@softuni.bg' as [Full Email Address]
FROM Employees

--06. Find All Different Employee’s Salaries
SELECT DISTINCT [Salary] 
FROM Employees

--07. Find all Information About Employees
SELECT *
FROM Employees
WHERE [JobTitle] = 'Sales Representative'

--08. Find Names of All Employees by Salary in Range

SELECT [FirstName], [LastName],[JobTitle]
FROM Employees
WHERE [Salary] BETWEEN 20000 AND 30000

--09. Find Names of All Employees 
SELECT [FirstName] +' ' +[MiddleName] + ' ' +[LastName] as [Full Name]
FROM Employees
WHERE [Salary] = 25000 OR [Salary] = 14000 OR [Salary] = 12500 OR [Salary] = 23600

--10. Find All Employees Without Manager

SELECT [FirstName],[LastName]
FROM Employees
WHERE [ManagerID] is NULL

--11. Find All Employees with Salary More Than 50000
SELECT [FirstName],[LastName],[Salary]
FROM Employees
WHERE  [Salary] > 50000
Order By  [Salary] DESC
--12.  Find 5 Best Paid Employees.
SELECT TOP (5) [FirstName],[LastName]
FROM Employees
Order By  [Salary] DESC
--13.Find All Employees Except Marketing
SELECT [FirstName],[LastName]
FROM Employees
WHERE [DepartmentID] != 4
--14.Sort Employees Table
SELECT *
FROM Employees
Order By Salary DESC, [FirstName],[LastName] DESC, [MiddleName]

--15.Create View Employees with Salaries
CREATE VIEW V_EmployeesSalaries AS
SELECT [FirstName],[LastName],[Salary]
FROM Employees

GO
SELECT* FROM V_EmployeesSalaries

--16.Create View Employees with Job Titles
CREATE VIEW V_EmployeeNameJobTitle AS
SELECT [FirstName] + ' ' + ISNULL(MiddleName, '') + ' ' +[LastName] AS [Full Name], [JobTitle]
FROM Employees


SELECT * FROM [dbo].[V_EmployeeNameJobTitle]

--17. Distinct Job Titles
SELECT DISTINCT[JobTitle]
FROM Employees

--18.Find First 10 Started Projects
Select TOP (10) *
FROM Projects
ORDER BY [StartDate],[Name]

--19.Last 7 Hired Employees
SELECT TOP (7) [FirstName],[LastName],[HireDate]
FROM Employees
ORDER BY [HireDate] DESC

--20 Increase Salaries
UPDATE Employees
SET Salary *=1.12
WHERE [DepartmentID] IN (1, 2, 4, 11)
SELECT Salary FROM Employees

--21. All Mountain Peaks

SELECT [PeakName]
FROM Peaks
ORDER BY [PeakName]

--22.  Biggest Countries by Population

  Select TOP(30) CountryName , Population
  From Countries
  Where ContinentCode = 'EU'
  Order By [Population] Desc, CountryName ASC

 --23. Countries and Currency (Euro / Not Euro)

  Select CountryName, CountryCode, Currency =
    CASE CurrencyCode
	  WHEN 'EUR' THEN 'Euro'
	  ELSE 'Not Euro'
	END
  From Countries
  ORDER BY CountryName 

  --24. All Diablo Characters

  SELECT [Name]
  FROM Characters
  ORDER BY [Name]
