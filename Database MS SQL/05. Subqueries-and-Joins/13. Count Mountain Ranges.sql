SELECT  mc.CountryCode, COUNT(m.MountainRange)
FROM MountainsCountries as mc
JOIN Mountains as m ON m.Id = mc.MountainId
WHERE mc.CountryCode in ('BG', 'RU','US')
GROUP BY mc.CountryCode