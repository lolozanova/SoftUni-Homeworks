SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation
FROM MountainsCountries as mc
JOIN Mountains as m ON m.Id = mc.MountainId
JOIN Peaks as p ON p.MountainId = m.Id
WHERE p.Elevation > 2835 and mc.CountryCode = 'BG'
ORDER BY p.Elevation DESC