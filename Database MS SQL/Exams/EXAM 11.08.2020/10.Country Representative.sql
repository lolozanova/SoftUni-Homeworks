SELECT ranked.Name, ranked.DistributorName 
FROM (select c.Name, d.Name as DistributorName,
       dense_rank() over (partition by c.Name order by count(i.Id) desc) as rank -- grupira po ime na darjava spored broq na ingridientite
from Countries as c
      join  Distributors D on c.Id = D.CountryId
     left join Ingredients I on D.Id = I.DistributorId
group by  c.Name, d.Name) as ranked
WHERE rank = 1
ORDER BY ranked.Name, ranked.DistributorName 

--Select all countries with their most active distributor (the one with the greatest number of ingredients). If there are several distributor