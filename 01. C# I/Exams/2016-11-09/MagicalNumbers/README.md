<img src="https://raw.githubusercontent.com/TelerikAcademy/Common/master/logos/telerik-header-logo.png"/>

#### _Telerik Academy Season 2016-2017 / C# Fundamentals Exam - 09 November 2016_
# Task 1: Magical numbers

## Description
Pesho the **magician** has been trying to solve this task for years but with no luck. Out of desperation, he has taken your **magical** cat as a hostage. In exchange for your **magical** pet, he wants you to solve this **magical** task for him that consists of a **magical** number and a **magical** result.

### The magical number
You are given a number that is **3 digits** long. Depending on the **2nd digit**, you need to perform some calculations.

- If the **2nd digit** is even, find the sum of the `first two digits` and multiply the result by the `3rd digit`.
- If the **2nd digit** is odd, find the product of the `first two digits` and divide the result by the `3rd digit`.

## Input
- On the only input line, you will receive a number that contains 3 digits.

## Output
- Your output should always be a single line. The content of the line should be the result of the calculations with a precision specifier of 2. (Fixed-point 2).

## Constraints
- The input will always contain a number that is 3 digits long.
- The input will always be a positive number.

## Sample tests
| Input       | Output                                |
|:------------|:--------------------------------------|
| 132         | 1.50                                  |
| 123         | 9.00                                  |
| 120         | 0.00                                  |