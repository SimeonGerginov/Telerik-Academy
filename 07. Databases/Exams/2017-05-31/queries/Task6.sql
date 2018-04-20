USE SuperheroesUniverse

CREATE PROC usp_GetPlanetsWithHeroesCount
AS
BEGIN
  SELECT p.Name AS 'Planet', 
  SUM(CASE WHEN a.Name = 'Good' THEN 1 ELSE 0 END) AS 'Good heroes', 
  SUM(CASE WHEN a.Name = 'Neutral' THEN 1 ELSE 0 END) AS 'Neutral heroes', 
  SUM(CASE WHEN a.Name = 'Evil' THEN 1 ELSE 0 END) AS 'Evil heroes'
  FROM Planets p
  INNER JOIN PlanetSuperheroes pls ON p.Id = pls.Planet_Id
  INNER JOIN Superheroes s ON pls.Superhero_Id = s.Id
  INNER JOIN Alignments a ON s.Alignment_Id = a.Id
  GROUP BY p.Name
  ORDER BY 'Good heroes' DESC
END