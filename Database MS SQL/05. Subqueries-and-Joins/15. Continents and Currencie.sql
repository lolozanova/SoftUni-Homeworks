SELECT ContinentCode, CurrencyCode, Total
FROM(
SELECT ContinentCode, CurrencyCode, COUNT(CurrencyCode) as Total,
DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY COUNT(CurrencyCode)DESC) as RANKED
FROM Countries
GROUP BY ContinentCode, CurrencyCode
) as k
WHERE Ranked = 1 AND Total>1
ORDER BY ContinentCode
