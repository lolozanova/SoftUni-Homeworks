
---    • he room must not be already occupied. A room is occupied if the date the customers want to book is between the arrival and return dates of a trip to that room and the trip is not canceled.
 ---   • The room must be in the provided hotel.
  ---  • The room must have enough beds for all the people.

  ---find the highest priced room (by total price) of all of them and provide them with that room.

CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR(MAX)
AS
BEGIN                                ----“Room {Room Id}: {Room Type} ({Beds} beds) - ${Total Price}”
DECLARE @result VARCHAR(MAX) = (SELECT TOP(1) 'Room' + ' ' + CONVERT(VARCHAR,r.Id) + ': ' + r.Type+' '+'(' + CONVERT(VARCHAR,r.Beds) + ' beds)' +' - $' + CONVERT(VARCHAR,(r.Price+h.BaseRate)*@People)
FROM Rooms as r
JOIN Hotels as h ON r.HotelId = h.Id
JOIN Trips as t ON t.RoomId =r.Id
WHERE HotelId = @HotelId 
AND Beds >= @People AND
NOT('2011-12-17' BETWEEN  t.ArrivalDate and t.ReturnDate)
OR '2011-12-17' BETWEEN t.ArrivalDate and t.ReturnDate and t.CancelDate is not null
---NOT EXISTS(SELECT * FROM Trips as t
---                        WHERE t.RoomId = r.Id
---						AND t.CancelDate IS  NULL 
---						AND @Date BETWEEN ArrivalDate and ReturnDate)
ORDER BY (r.Price+h.BaseRate)*@People DESC)

 IF @result IS NULL
 RETURN 'No room available'
RETURN @result
END

GO
SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)

SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)


---SELECT *
---FROM Rooms as r
---JOIN Hotels as h ON r.HotelId = h.Id
---JOIN Trips as t ON t.RoomId =r.Id
---WHERE HotelId = 94 
---AND Beds >= 3 AND
---NOT('2015-07-26' BETWEEN  t.ArrivalDate and t.ReturnDate)
---OR '2015-07-26' BETWEEN t.ArrivalDate and t.ReturnDate and t.CancelDate is not null

     




