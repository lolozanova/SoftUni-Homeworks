---Find the longest and shortest trip for each account, in days. Filter the results to accounts with no middle name and trips, which are not cancelled (CancelDate is null).
---Order the results by Longest Trip days (descending), then by Shortest Trip (ascending).

SELECT a.Id, CONCAT(FirstName,' ', LastName) as FullName , MAX(DATEDIFF(DAY,t.ArrivalDate, t.ReturnDate)) as LongestTrip,MIN(DATEDIFF(DAY,t.ArrivalDate, t.ReturnDate)) as ShortestTrip
FROM Accounts as a
JOIN AccountsTrips as atr ON atr.AccountId = a.Id
JOIN Trips as t ON t.Id = atr.TripId
WHERE a.MiddleName IS NULL AND CancelDate IS NULL
GROUP BY a.Id,  CONCAT(FirstName,' ', LastName)
ORDER BY LongestTrip DESC, ShortestTrip ASC