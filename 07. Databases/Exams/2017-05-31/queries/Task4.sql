USE SuperheroesUniverse

CREATE PROC usp_UpdateSuperheroBio @ID int, @Bio ntext
AS
BEGIN
  UPDATE Superheroes
  SET Bio = @Bio
  WHERE Id = @ID
END