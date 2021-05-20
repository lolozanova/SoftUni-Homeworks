CREATE PROC dbo.usp_GetHoldersWithBalanceHigherThan @TotalBalance DECIMAL(15,5)
AS
SELECT FirstName, LastName
FROM AccountHolders as ah
JOIN Accounts as a ON a.AccountHolderId = ah.Id
GROUP BY FirstName, LastName
HAVING SUM(BALANCE)> @TotalBalance
ORDER BY FirstName,LastName


EXEC usp_GetHoldersWithBalanceHigherThan 1000000