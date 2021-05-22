SELECT ProductId,Rate, [Description], CustomerId, Age, Gender
FROM Feedbacks as f
JOIN Customers as c ON c.Id =f.CustomerId
WHERE Rate < 5.0
ORDER BY ProductId DESC, Rate ASC