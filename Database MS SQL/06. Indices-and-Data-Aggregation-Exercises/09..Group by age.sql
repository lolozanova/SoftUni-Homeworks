SELECT t.Range  as [AgeGroup], Count(*) as WizardCount
FROM (
SELECT CASE
WHEN Age between 0 and 10 then  '[0-10]'
WHEN Age between 11 and 20 then '[11-20]'
WHEN Age between 21 and 30 then '[21-30]'
WHEN Age between 31 and 40 then '[31-40]'
WHEN Age between 41 and 50 then '[41-50]'
WHEN Age between 51 and 60 then '[51-60]'
WHEN AGE >=61 THEN '61+' 
END as Range
FROM WizzardDeposits) t
GROUP BY t.RANGE 


