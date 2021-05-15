SELECT TOP(5) k.CountryName, k.PeakName, k.HighestPeak, k.MountainRange
FROM(SELECT c.CountryName,
       ISNULL(p.PeakName, '(no highest peak)') as PeakName, 
	   ISNULL (m.MountainRange, '(no mountain)') as MountainRange,
	   ISNULL(MAX(p.Elevation), 0) as HighestPeak,
	   DENSE_RANK() OVER (PARTITION BY CountryName ORDER BY MAX(p.Elevation) DESC)
	   AS RANKED
FROM Countries c
LEFT JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
LEFT JOIN Mountains as m ON m.Id = mc.MountainId
LEFT JOIN Peaks p ON p.MountainId = mc.MountainId
GROUP BY c.CountryName, p.PeakName, m.MountainRange) as k
WHERE RANKED = 1
ORDER BY CountryName,PeakName


