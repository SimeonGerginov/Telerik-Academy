<img src="https://raw.githubusercontent.com/TelerikAcademy/Common/master/logos/telerik-header-logo.png"/>

#### _Telerik Academy Season 2016-2017 / C# Fundamentals Exam - 09 November 2016_
# Task 3: Secret Message

## Description
**Tzacky** has a great idea to hide messages in subtitles of movies. But his friend, just started to code and has difficulty decoding the messages. He knows that to do so, he needs to take the numbers that come before each subtitle and use them to decode the message. The first number **S** is the index of the symbol he should start decoding (starting from 0) and the second number **E** is the last index of the symbol of the segment he needs to decode (inclusive). Additionally if the currently read line is odd you should take every 3rd symbol, otherwise (if it's even) every 4th. Start counting the lines from **1** (one).

To make things easy, when the subtitles finish **Tzacky** always adds **end** instead of the starting index **S** (see sample tests). 
- example:

  | input               | result | explanation                 |
  |:--------------------|:-------|:----------------------------|
  | 18<br/>23<br/>А traveller might choose a route...<br/>11<br/>26<br/>on a given destiny not gettinging...<br/>end | coding<br/><br/><br/><br/><br/><br/><br/> |  А traveller might **c**ho**o**se a route<br/>from the segment **choose** (18-23) take the **c** and **o**<br/>on a given **d**est**i**ny **n**ot **g**ettinging...<br/>from the segment **destiny not gett** (11-26) take the **d**, **i**, **n** and **g** <br/><br/><br/><br/> |

Sometimes **Tzacky** wants to be extra sure his message will be secret, so he decided to add additional complexity.
- If **S** and/or **E** are negative your program should take the letter counting from the end of the line as starting index
  - example 1: for **S = -2** and **E = -1**
    - line of code: "some random text that makes no sen**ce**"
  - example 2: for **S = -6** and **E = -2**
    - line of code: "some random text that makes no**_senc**e" (from the white space)

## Input
- On the first line you can read the index of the first symbol **S**, if instead of a number you read **end** your program should print the secret message so far and stop.
- On the second line you will get **E** the end of the segment you need to process.
- On the third line you will get a line of text on witch you have to use the previously read numbers. 

## Output
- The output should consist of a single line containing the full secret message.

## Constraints
- The starting symbol index **S** will be a valid integer number between `-100` and `100` inclusive.
- The number of skipped letters **E** will be a valid integer number between `-100` and `100` inclusive.
- Position the segment starts will never be after the end position.
- The length of each line of text will be between `1` and `100` inclusive.
  - The text will contain only Latin letters and the symbols: **,** (comma), **.** (dot), **!** (exclamation mark) and **white space** (space)
  - **[',', '.', '!', ' ']**.
- The input will always be valid and in the described format. There is no need to check it explicitly.
- Memory limit: **32 MB**
- Time limit: **0.10 sec**

## Sample tests

| **input**                                                                  | **output**        |
|:---------------------------------------------------------------------------|:------------------|
| 18<br/>23<br/>А traveller might choose a route basedek mythology, chaos,<br/>11<br/>26<br/>on a given destiny not gettinging to Hesiod, was the first thing to exist.<br/>4<br/>-18<br/>into which one is the best.<br/>6<br/>16<br/>Choices as professions are made<br/>-4<br/>18<br/>much more difficult.<br/>20<br/>20<br/>With them you might need to do some research beforehand.<br/>end | coding is fun<br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/> |

Explanation:<br/>
А traveller might **c**ho**o**se a route basedek mythology, chaos,<br/>
on a given **d**est**i**ny **n**ot **g**ettinging to Hesiod, was the first thing to exist.<br/>
into**_**wh**i**ch one is the best.<br/>
Choice**s** as**_**pro**f**essions are made<br/>
much more diffic**u**lt.<br/>
With them you might **n**eed to do some research beforehand.<br/>


| **input**                              | **output** |
|:---------------------------------------|:-----------|
| 0<br/>4<br/>oh no!<br/>end<br/>1<br/>some other text that should be ignored | on<br/><br/><br/><br/><br/><br/> |