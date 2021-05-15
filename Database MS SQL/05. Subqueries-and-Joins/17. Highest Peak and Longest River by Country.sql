SELECT TOP (5) co.CountryName, MAX(p.Elevation) as HighestPeakElevation, MAX(r.Length) as LongestRiverLength
FROM Countries co
FULL JOIN MountainsCountries mc ON mc.CountryCode = co.CountryCode
FULL JOIN Peaks as p ON p.MountainId = mc.MountainId
FULL JOIN CountriesRivers as cr ON cr.CountryCode = co.CountryCode
FULL JOIN Rivers as r ON r.Id = cr.RiverId
GROUP BY co.CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, co.CountryName
