SELECT
ProductName, 
OrderDate,
DATEADD(DAY,3,OrderDate) AS [Pay Due],
DateADD (MONTH, 1, OrderDate) AS [Deliver Due]
FROM ORDERS