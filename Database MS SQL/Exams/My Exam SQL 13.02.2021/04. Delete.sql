---Delete repository "Softuni-Teamwork" in repository contributors and issues.

DELETE rc
FROM RepositoriesContributors  rc
JOIN Repositories as r ON r.Id = rc.RepositoryId
WHERE r.Name = 'Softuni-Teamwork'

DELETE i
FROM Issues  i
JOIN Repositories as r ON r.Id = i.RepositoryId
WHERE r.Name = 'Softuni-Teamwork'