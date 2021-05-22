SELECT m.FirstName + ' '+ m.LastName
FROM Mechanics as m
LEFT JOIN Jobs as j ON j.MechanicId = m.MechanicId
WHERE j.JobId IS NULL OR (SELECT COUNT(JobId)
FROM Jobs
WHERE Status != 'Finished' AND MechanicId = m.MechanicID 
GROUP BY MechanicId,Status) IS NULL
GROUP BY m.MechanicId, (m.FirstName + ' '+ m.LastName)




