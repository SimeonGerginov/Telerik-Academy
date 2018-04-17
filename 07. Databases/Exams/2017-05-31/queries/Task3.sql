USE SuperheroesUniverse

SELECT TOP 5 p.Name AS 'Planet', SUM(CASE WHEN a.Name = 'GOOD'
THEN 1 ELSE 0 END) AS 'Protectors'
FROM Superheroes s
INNER JOIN PlanetSuperheroes ps ON s.Id = ps.Superhero_Id
INNER JOIN Planets p ON ps.Planet_Id = p.Id
INNER JOIN Alignments a ON s.Alignment_Id = a.Id
GROUP BY p.Name
ORDER BY Protectors DESC, p.Name