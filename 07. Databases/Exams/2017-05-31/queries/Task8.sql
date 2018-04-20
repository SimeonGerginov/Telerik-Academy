USE SuperheroesUniverse

CREATE PROC usp_PowersUsageByAlignment 
AS
BEGIN
  SELECT a.Name AS 'Alignment', COUNT(s.Id) AS 'Powers Count'
  FROM Alignments a
  INNER JOIN Superheroes s ON a.Id = s.Alignment_Id
  GROUP BY a.Name
END