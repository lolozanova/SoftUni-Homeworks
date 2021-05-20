CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4)) 
RETURNS VARCHAR(10)
AS
BEGIN
   DECLARE @result VARCHAR(20)
   IF (@salary < 30000) 
   SET @result = 'Low'
   ELSE IF (@salary >=30000 and @salary <= 50000) 
   SET @result = 'Average'
   ELSE IF (@salary > 50000) 
   SET @result = 'High'
   RETURN @result
END






