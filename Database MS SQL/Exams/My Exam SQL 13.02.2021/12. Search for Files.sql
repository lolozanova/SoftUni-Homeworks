CREATE PROC usp_SearchForFiles @fileExtension VARCHAR(10)
AS
SELECT Id, Name, CONVERT(VARCHAR,Size)+'KB' as Size
FROM Files
WHERE  RIGHT(Name, (LEN(Name) - CHARINDEX('.', Name))) = @fileExtension
ORDER BY Id, Name, Size