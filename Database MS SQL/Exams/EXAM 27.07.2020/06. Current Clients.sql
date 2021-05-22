SELECT c.FirstName+' '+c.LastName as [Client], DATEDIFF(DAY, j.IssueDate, '2017-04-24') as [Days going], j.Status
FROM Clients as c
JOIN Jobs as j ON j.ClientId = c.ClientId
WHERE j.Status != 'Finished'
ORDER BY [Days going] DESC, c.ClientId ASC