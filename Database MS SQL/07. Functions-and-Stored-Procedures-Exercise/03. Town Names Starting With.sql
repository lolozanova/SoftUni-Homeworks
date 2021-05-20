CREATE PROC usp_GetTownsStartingWith (@FirstChar VARCHAR(MAX))
AS
SELECT [Name] as 'Town'
FROM Towns
WHERE LEFT([Name], LEN(@FirstChar)) = @FirstChar
