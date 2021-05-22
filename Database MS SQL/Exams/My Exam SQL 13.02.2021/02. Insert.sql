SELECT *
FROM Issues

UPDATE Issues
SET [Status] = 'closed'
WHERE AssigneeId = 6
