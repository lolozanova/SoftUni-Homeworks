SELECT TripId, 
       CONCAT(FirstName,' ',MiddleName,' ', LastName) as [Full Name],
	   c.Name as [From],
	   hc.Name  as [To],
	   CASE 
	   WHEN [CancelDate] IS NULL THEN CONVERT(VARCHAR(10), DATEDIFF(DAY,[ArrivalDate],[ReturnDate])) + ' days'
	   ELSE  'Canceled' 
	   END  as Duration
FROM AccountsTrips as atr
JOIN Accounts as a ON a.Id = atr.AccountId
JOIN Cities as c ON c.Id = a.CityId
JOIN Trips as t ON t.Id = atr.TripId
JOIN  Rooms as r ON r.Id = t.RoomId
JOIN Hotels as h ON h.Id = r.HotelId
JOIN Cities as hc ON h.CityId = hc.Id
ORDER BY [Full Name], TripId