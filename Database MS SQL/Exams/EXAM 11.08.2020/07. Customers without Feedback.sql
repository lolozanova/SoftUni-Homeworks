SELECT CONCAT(FirstName, ' ', LastName) as [CustomerName], PhoneNumber, Gender
FROM Customers as c
LEFT JOIN Feedbacks as f ON f.CustomerId = c.Id
WHERE f.Id IS NULL 
ORDER BY f.CustomerId

