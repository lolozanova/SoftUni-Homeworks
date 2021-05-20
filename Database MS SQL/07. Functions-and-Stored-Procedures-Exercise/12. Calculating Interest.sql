CREATE PROC usp_CalculateFutureValueForAccount @AccountId INT,@InterestedRate DECIMAL(15,4)
AS
SELECT a.Id as [Account Id], 
       ah.FirstName as [First Name],
	   ah.LastName as [Last Name], 
	   a.Balance as [Current Balance],
	   dbo.ufn_CalculateFutureValue(Balance, @InterestedRate,5) as [Balance in 5 years]
FROM AccountHolders as ah
JOIN Accounts as a ON a.AccountHolderId = ah.Id
WHERE a.ID = @AccountId

EXEC usp_CalculateFutureValueForAccount 1, 0.1