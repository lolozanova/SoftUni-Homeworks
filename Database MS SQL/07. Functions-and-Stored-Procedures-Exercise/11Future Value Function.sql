CREATE FUNCTION ufn_CalculateFutureValue (@InitialSum DECIMAL (15,2), @YearlyInterestedRate FLOAT,@NumberOfYears INT)
RETURNS DECIMAL (16,4)
AS
BEGIN
return @InitialSum * POWER(@YearlyInterestedRate + 1), @NumberOfYears)
END

SELECT dbo.ufn_CalculateFutureValue  (1000 ,0.1 , 5)

