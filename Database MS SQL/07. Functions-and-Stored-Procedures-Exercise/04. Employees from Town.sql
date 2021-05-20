CREATE PROC usp_GetEmployeesFromTown (@Town VARCHAR(20))
AS
SELECT FirstName, LastName
FROM Employees as e
JOIN Addresses as a ON a.AddressID = e.AddressID
JOIN Towns as t ON t.TownID = a.TownID
WHERE t.Name = @Town
