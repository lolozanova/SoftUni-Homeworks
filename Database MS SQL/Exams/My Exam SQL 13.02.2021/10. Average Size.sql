SELECT Username,AVG(f.Size) as Size
FROM Users as u
JOIN Commits as c ON c.ContributorId=u.Id
JOIN Files as f ON f.CommitId = c.Id
GROUP BY Username
ORDER BY AVG(f.Size) DESC, Username ASC