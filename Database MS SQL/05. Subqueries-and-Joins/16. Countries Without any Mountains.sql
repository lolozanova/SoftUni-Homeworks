SELECT COUNT (*)
FROM Countries as c
LEFT JOIN MountainsCountries as mc ON  mc.CountryCode = c.CountryCode
WHERE mc.MountainId IS NULL
