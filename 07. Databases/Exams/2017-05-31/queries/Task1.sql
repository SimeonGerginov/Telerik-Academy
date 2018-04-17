USE SuperheroesUniverse

SELECT s.Id, s.Name
FROM Superheroes s
INNER JOIN PlanetSuperheroes ps ON s.Id = ps.Superhero_Id 
INNER JOIN Planets p ON ps.Planet_Id = p.Id
WHERE p.Name = 'Earth'