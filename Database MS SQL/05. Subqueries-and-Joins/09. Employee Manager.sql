SELECT e.EmployeeID, e.FirstName, e.ManagerID, m.FirstName
FROM Employees as e
JOIN Employees as m ON m.EmployeeID = e.ManagerID
WHERE e.ManagerID IN (3,7)
ORDER BY e.EmployeeID