USE SuperheroesUniverse

CREATE PROC usp_CreateSuperhero @Name nvarchar(40), @SecretIdentity nvarchar(40),
            @Bio ntext, @Alignment nvarchar(40), @Planet nvarchar(40),
			@PowerOne nvarchar(40), @PowerTypeOne nvarchar(40),
			@PowerTwo nvarchar(40), @PowerTypeTwo nvarchar(40),
			@PowerThree nvarchar(40), @PowerTypeThree nvarchar(40)
AS
BEGIN
  IF(@Alignment NOT IN (SELECT Name FROM Alignments))
     BEGIN
	    INSERT INTO Alignments VALUES(@Alignment)
	 END

  DECLARE @AlignmentId INT = (SELECT Id FROM Alignments WHERE Name = @Alignment)

  IF(@Planet NOT IN (SELECT Name FROM Planets))
     BEGIN
	    INSERT INTO Planets VALUES(@Planet)
	 END

  DECLARE @PlanetId INT = (SELECT Id FROM Planets WHERE Name = @Planet)

  IF(@PowerTypeOne NOT IN (SELECT Name FROM PowerTypes))
     BEGIN
	    INSERT INTO PowerTypes VALUES(@PowerTypeOne)
	 END

  DECLARE @PowerTypeOneId INT = (SELECT Id FROM PowerTypes WHERE Name = @PowerTypeOne)

  IF(@PowerTypeTwo NOT IN (SELECT Name FROM PowerTypes))
     BEGIN
	    INSERT INTO PowerTypes VALUES(@PowerTypeTwo)
	 END

  DECLARE @PowerTypeTwoId INT = (SELECT Id FROM PowerTypes WHERE Name = @PowerTypeTwo)

  IF(@PowerTypeThree NOT IN (SELECT Name FROM PowerTypes))
     BEGIN
	    INSERT INTO PowerTypes VALUES(@PowerTypeThree)
	 END

  DECLARE @PowerTypeThreeId INT = (SELECT Id FROM PowerTypes WHERE Name = @PowerTypeThree)

  IF(@PowerOne NOT IN (SELECT Name FROM Powers))
     BEGIN
	    INSERT INTO Powers VALUES(@PowerOne, @PowerTypeOneId)
	 END

  DECLARE @PowerOneId INT = (SELECT Id FROM Powers WHERE Name = @PowerOne)

  IF(@PowerTwo NOT IN (SELECT Name FROM Powers))
     BEGIN
	    INSERT INTO Powers VALUES(@PowerTwo, @PowerTypeTwoId)
	 END

  DECLARE @PowerTwoId INT = (SELECT Id FROM Powers WHERE Name = @PowerTwo)

  IF(@PowerThree NOT IN (SELECT Name FROM Powers))
     BEGIN
	    INSERT INTO Powers VALUES(@PowerThree, @PowerTypeThreeId)
	 END

  DECLARE @PowerThreeId INT = (SELECT Id FROM Powers WHERE Name = @PowerThree)

  INSERT INTO Superheroes VALUES(@Name, @SecretIdentity, @AlignmentId, @Bio)

  DECLARE @SuperheroId INT = (SELECT Id FROM Superheroes WHERE Name = @Name)

  INSERT INTO PlanetSuperheroes VALUES(@PlanetId, @SuperheroId)
  INSERT INTO PowerSuperheroes VALUES(@PowerOneId, @SuperheroId), 
              (@PowerTwoId, @SuperheroId), (@PowerThreeId, @SuperheroId)
END