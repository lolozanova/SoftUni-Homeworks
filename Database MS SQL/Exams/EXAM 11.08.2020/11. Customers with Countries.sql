---Create a view named v_UserWithCountries which selects all customers with their countries.
    ---CustomerName – first name plus last name, with space between them
    ---Age
    ---Gender
    ---CountryName
	CREATE VIEW v_UserWithCountries 
	AS
	SELECT CONCAT(c.FirstName,' ' , c.LastName) as CustomerName, c.Age, c.Gender, co.Name
	FROM Customers as c
	JOIN Countries as co ON co.Id = c.CountryId



  SELECT TOP 5 *
  FROM v_UserWithCountries
  ORDER BY Age
