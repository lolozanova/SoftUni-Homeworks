SELECT FirstName, Age,PhoneNumber
FROM Customers as c
JOIN Countries as co ON co.Id =c.CountryId
WHERE Age >=21 AND FirstName LIKE '%an%'
OR PhoneNumber LIKE '%38' AND co.Name != 'Greece' 
ORDER BY FirstName ASC, Age DESC