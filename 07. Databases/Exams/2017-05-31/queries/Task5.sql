USE SuperheroesUniverse

CREATE PROC usp_GetSuperheroInfo @ID int
AS
BEGIN
  SELECT s.Id, s.Name, s.SecretIdentity AS 'Secret Identity', s.Bio, 
  a.Name AS 'Alignment', pl.Name AS 'Planet', p.Name AS 'Power'
  FROM Superheroes s
  INNER JOIN Alignments a ON s.Alignment_Id = a.Id
  INNER JOIN PlanetSuperheroes pls ON s.Id = pls.Superhero_Id
  INNER JOIN Planets pl ON pls.Planet_Id = pl.Id
  INNER JOIN PowerSuperheroes ps ON s.Id = ps.Superhero_Id
  INNER JOIN Powers p ON ps.Power_Id = p.Id
  WHERE s.Id = @ID
END