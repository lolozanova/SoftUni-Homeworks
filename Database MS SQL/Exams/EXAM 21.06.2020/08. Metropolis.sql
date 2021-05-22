---Find the top 10 cities, which have the most registered accounts in them. Order them by the count of accounts (descending).

SELECT TOP(10) c.Id, c.Name as City, c.CountryCode as Country, COUNT(*) as Accounts
FROM Cities as c
JOIN Accounts as a ON a.CityId = c.Id
GROUP BY c.Id, c.Name, c.CountryCode
ORDER BY Accounts DESC