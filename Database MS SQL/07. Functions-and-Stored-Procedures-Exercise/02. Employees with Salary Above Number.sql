CREATE PROC usp_GetEmployeesSalaryAboveNumber( @Salary decimal(18,4))
AS
SELECT FirstName, LastName
FROM Employees
WHERE Salary >= @Salary
