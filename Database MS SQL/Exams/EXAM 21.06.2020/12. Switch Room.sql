CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS

---If the target room ID is in a different hotel, than the trip is in, raise an exception with the message “Target room is in another hotel!”.
DECLARE @TripHotelId INT = (SELECT HotelId
                          FROM Rooms as r
                          JOIN Trips as t ON r.Id =t.RoomId
                          JOIN Hotels as h ON h.Id = r.HotelId
                          Where t.Id = @TripId
						  )

DECLARE @TargetRoomsHotelID INT = (SELECT HotelId
						  FROM Rooms as r
                          JOIN Hotels as h ON h.Id = r.HotelId
                          Where r.Id = @TargetRoomId)


IF (@TripHotelId != @TargetRoomsHotelID)
THROW 50001,'Target room is in another hotel!',1

---If the target room doesn’t have enough beds for all the trip’s accounts, raise an exception with the message “Not enough beds in target room!”.

DECLARE @COUNTPeople INT =(SELECT COUNT(*)
FROM AccountsTrips as atr
WHERE atr.TripId = @TripId)

DECLARE @BedsInTargetRoom INT=(SELECT TOP(1)Beds
FROM Rooms as r
WHERE r.Id =@TargetRoomId)

IF(@COUNTPeople>@BedsInTargetRoom)
THROW 50002, 'Not enough beds in target room!',1

-----Change the RoomId for this TripId
ELSE
UPDATE Trips
SET RoomId =@TargetRoomId
WHERE Id = @TripId
RETURN @TargetRoomId

GO

EXEC usp_SwitchRoom 10, 11
SELECT RoomId FROM Trips WHERE Id = 10















