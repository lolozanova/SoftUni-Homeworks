SELECT FirstName
From Employees
WHERE DepartmentID IN (3,10) AND DATEPART(YEAR,[HireDate]) BETWEEN '1995' and '2005'




