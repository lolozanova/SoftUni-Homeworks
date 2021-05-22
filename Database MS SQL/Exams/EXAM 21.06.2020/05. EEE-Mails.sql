SELECT FirstName, LastName, FORMAT(BirthDate,'MM-dd-yyyy') as BirthDate, c.Name, Email
FROM Accounts as a
JOIN Cities as c ON c.Id = a.CityId
WHERE Email LIKE 'e%'
ORDER BY c.Name