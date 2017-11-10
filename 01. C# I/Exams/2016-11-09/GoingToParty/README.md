<img src="https://raw.githubusercontent.com/TelerikAcademy/Common/master/logos/telerik-header-logo.png"/>

#### _Telerik Academy Season 2016-2017 / C# Fundamentals Exam - 09 November 2016_
# Task 2: Going to a party

## Description
Djor and Djano are going to a party but they're either very drunk or very stupid and don't remember the way to the party. 
Fortunately, they have directions, but unfortunately, they can't understand them. Your task is to write a program that reads the directions and helps Djor and Djano to reach the party and to party **'cyala nosht'**.

### The directions
The directions are a string on a single line. This string can contain letters from the latin alphabet(upper and lower) and the symbol **'^'**(party symbol).

### Following the directions
- You will start from the first symbol of the directions(which is at position `0`)
- Step on a **lower latin** letter:
    - take it's position **P** in the latin alphabet('a' is 1, 'b' is 2 and so on)
    - move forward by **P** positions
- Step on a **upper latin** letter:
    - take it's position **P** in the latin alphabet('A' is 1, 'B' is 2 and so on)
    - move backward by **P** positions
- Step on a **party symbol** **'^'**:
    - print `Djor and Djano are at the party at POSITION!`, where **POSITION** at which they stepped on the party symbol **'^'**

### Getting lost
- If a step sends you at an index that is outside of the directions(negative or too large index), print `Djor and Djano are lost at POSITION!`, where **POSITION** is the index that is outside the description.

## Input
- On the only input line, you will receive a single string - the directions.

## Output
- Your output should always be a single line. The content of the line is described in the section **Following the directions** above.

## Constraints
- The direction string will never contain more than 100 symbols.
- The direction string will always contain only latin letters and party symbols **'^'**.
- Djor and Djano will **never enter a loop** while following the directions. Two examples of loops:
    - `aA^` - **a** -> **A** -> **a**
    - `ab^C` - **a** -> **b** -> **C** -> **a**

## Sample tests
| Input       | Output                                |
|:------------|:--------------------------------------|
| abcAk^zzz^  | Djor and Djano are at the party at 5! |
| abcAkzzzz^  | Djor and Djano are lost at 31!        |
| baK^I^      | Djor and Djano are lost at -9!        |
| fVz^A^Bz^kA | Djor and Djano are at the party at 3! |
| ak^         | Djor and Djano are lost at 12!        |