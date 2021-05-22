SELECT m.FirstName+' '+ m.LastName as [Mechanic], j.Status, j.IssueDate
FROM Mechanics as m
JOIN Jobs as j on j.MechanicId = m.MechanicId
ORDER BY m.MechanicId, IssueDate, j.JobId