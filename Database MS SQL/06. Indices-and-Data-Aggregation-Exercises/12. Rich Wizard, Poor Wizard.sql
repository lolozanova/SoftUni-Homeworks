SELECT SUM(HOST.DepositAmount- GUEST.DepositAmount) as [Difference]
FROM WizzardDeposits as HOST
JOIN WizzardDeposits as GUEST ON GUEST.Id =  HOST.Id+1