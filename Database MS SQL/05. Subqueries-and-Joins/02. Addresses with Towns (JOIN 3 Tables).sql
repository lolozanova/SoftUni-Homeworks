SELECT TOP (50) [FirstName],[LastName],t.[Name] as [Town], a.AddressText as [AddressText]
FROM Employees as e
JOIN Addresses as a ON a.AddressID = e.AddressID
JOIN Towns as t ON t.TownID = a.TownID
ORDER BY e.FirstName, e.LastName
