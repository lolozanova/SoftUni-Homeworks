SELECT a.Id,a.Email,c.Name,  COUNT(*) as Trips
FROM Accounts as a
JOIN Cities as c ON c.Id = a.CityId
JOIN Hotels as h on h.CityId = c.Id
JOIN Rooms as r on r.HotelId = h.Id
JOIN Trips as t on t.RoomId = r.Id
JOIN AccountsTrips as atr ON atr.TripId = t.Id
WHERE atr.AccountId = a.Id AND a.CityId =c.Id
GROUP BY a.Id, a.Email, c.Name
ORDER BY Trips DESC, a.Id
