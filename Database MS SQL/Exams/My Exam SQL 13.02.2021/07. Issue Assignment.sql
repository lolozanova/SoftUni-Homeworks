SELECT f.Id, f.Name, CONVERT(VARCHAR,f.Size)+'KB' as Size
FROM Files as f
LEFT JOIN Files as pf ON f.Id = pf.ParentId
WHERE  pf.Id IS NULL
ORDER BY f.Id ASC, f.Name ASC , f.Size DESC