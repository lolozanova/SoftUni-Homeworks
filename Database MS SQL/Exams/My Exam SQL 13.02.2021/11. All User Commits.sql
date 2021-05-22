CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(50))
RETURNS INT
AS
BEGIN
DECLARE @CommitCountForUser INT 
SET @CommitCountForUser = (SELECT COUNT(c.Id)
FROM USERS as u
JOIN Commits as c ON c.ContributorId = u.Id
WHERE u.Username = @username)
RETURN @CommitCountForUser
END 
