Delete all of Account ID 47’s account’s trips from the mapping table.

SELECT *
FROM Accounts as a
JOIN AccountsTrips  as atr ON atr.AccountId = a.Id
WHERE a.Id = 47

DELETE FROM AccountsTrips
WHERE AccountId = 47
