SELECT d.Name as DistributorName, i.Name as IngredientName,p.Name as ProductName , AVG(f.Rate)
FROM  Distributors as d
JOIN Ingredients as i ON i.DistributorId = d.Id
JOIN ProductsIngredients as pin ON pin.IngredientId = i.Id
JOIN Products as p ON p.Id = pin.ProductId
JOIN Feedbacks as f ON f.ProductId = p.Id
GROUP BY p.Name, d.Name ,  i.Name
HAVING  AVG(f.Rate) BETWEEN 5 and 8
ORDER BY d.Name,i.Name , p.Name