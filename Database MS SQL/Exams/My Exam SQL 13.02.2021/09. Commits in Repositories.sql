SELECT TOP(5) r.Id, r.Name , COUNT(c.Id) as Commits
FROM RepositoriesContributors as rc
JOIN Repositories as r ON r.Id = rc.RepositoryId
JOIN Commits as c ON c.RepositoryId = r.Id
GROUP BY r.Id, r.Name
ORDER BY Commits DESC, r.Id, r.Name



