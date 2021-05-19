SELECT  SUM (Diff)
FROM (SELECT w.DepositAmount -LEAD(w.DepositAmount, 1) OVER (ORDER BY w.Id) as Diff
FROM WizzardDeposits as w) as t