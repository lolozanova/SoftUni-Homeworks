SELECT m.MountainRange,p.PeakName, p.Elevation 
FROM PEAKS as p
JOIN Mountains as m ON m.ID =MountainID 
WHERE MountainRange = 'Rila'
ORDER BY Elevation DESC