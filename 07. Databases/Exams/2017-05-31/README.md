<img src="https://raw.githubusercontent.com/TelerikAcademy/Common/master/logos/telerik-header-logo.png" />

# Databases Course May 2017
## SQL Exam 

# Description

You are given a database that stores information about superheroes and supervillains. Your tasks are to write the given queries for this database.

![Superheroes Universe-Diagram](http://i.imgur.com/iPw9N2o.png)

The database is in SQL Server. You can create it with SQL script.

-  **DON'T forget to change the path to the DATA folder for you instance of SQL Server**
    -   i.e. check if you need to change the following at the start of the script:
        - \MSSQL13.MSSQLSERVER (version of your SQL Server)
    
```
( NAME = N'SuperheroesUniverse', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\SuperheroesUniverse.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SuperheroesUniverse_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\SuperheroesUniverse_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )

```

# Tasks

1. List all superheroes in `Earth`
    -   In the format

| Id | Name             |
| -- | ---------------- |
| 1  | Iron man         |
| 2  | The Hulk         |
| 3  | Thor             |


2. List all superheroes with their powers and powerTypes
    -   In the format

| Superhero | Power                      |
| --------- | -------------------------- |
| Irom Man  | Armored Suit (Tech)        |
| Irom Man  | Genius (Intelligence)      |
| Groot     | I am groot (Intelligence)  |

3. List the top 5 planets, sorted by count of superheroes with alignment 'Good', then by Planet Name
    -   In the format

| Planet     | Protectors |
| ---------- | ---------- |
| Earth      | 6          |
| Asgard     | 1          |
| Apocalypse | 0          |
| Titan      | 0          |

4. Create a stored procedure to edit superheroes Bio, by provided Superhero's Id and the new bio
    -   Name it `usp_UpdateSuperheroBio` 

5. Create a stored prodecure, that gives full information about a superhero, by provided Superhero's Id
    -   Name it `usp_GetSuperheroInfo`
    -   In the format

| Id | Name  | Secret Identity | Bio  | Alignment | Planet      | Power          |
| -- | ----- | --------------- | ---- | --------- | ----------- | -------------- |
| 1  | Groot | Groot           | NULL | Good      | Earth       | Super strength |
| 1  | Groot | Groot           | NULL | Good      | The Galaxy  | Super strength |
| 1  | Groot | Groot           | NULL | Good      | Earth       | Immortal       |
| 1  | Groot | Groot           | NULL | Good      | The Galaxy  | Immortal       |
| 1  | Groot | Groot           | NULL | Good      | Earth       | I am groot     |
| 1  | Groot | Groot           | NULL | Good      | The Galaxy  | I am groot     |

6. Create a stored procedure that prints the number of heroes with `Good`, `Evil` and `Neutral` alignment for each Planet
    -   Name it `usp_GetPlanetsWithHeroesCount`
    -   In the format

| Planet     | Good heroes | Neutral heroes | Evil heroes |
| ---------- | ----------- | -------------- | ----------- |
| Earth      | 6           | 0              | 4           |
| Asgard     | 1           | 0              | 1           |
| Apocalypse | 0           | 1              | 1           |
| Titan      | 0           | 1              | 1           |



7. Create a stored procedure for creating a Superhero, with provided name, secret identity, bio, alignment, a planet and 3 powers (with their types)
    -   Powers, power types, planet and alignement should be reused, if they are already in the database

8. Create a stored procedure that prints the number of powers by alignment of their superheroes
    -   Name it `usp_PowersUsageByAlignment`
    -   In the format

| Alignment | Powers Count |
| --------- | ------------ |
| Good      | 15           |
| Evil      | 10           |

# Additional notes
* One stored procedure could contain multiple other stored procedures but it is not required to do so