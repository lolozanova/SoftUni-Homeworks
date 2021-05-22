---Select all cities with the count of hotels in them. Order them by the hotel count (descending), then by city name. Do not include cities, which have no hotels in them.

SELECT c.Name, COUNT(*) as Hotels
FROM Cities as c
JOIN Hotels as h ON h.CityId = c.Id
GROUP BY c.Name
ORDER BY Hotels DESC, c.Name