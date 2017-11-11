<img src="https://raw.githubusercontent.com/TelerikAcademy/Common/master/logos/telerik-header-logo.png"/>

#### _Telerik Academy Season 2016-2017 / C# Fundamentals Exam - 09 November 2016_
# Task 4: Merging numbers

## Description

We have the following operations defined for two-digit numbers:
- Merging: merging `ab` and `cd` produces `bc`
  - `42` merged with `17` produces `21`
  - `17` merged with `42` produces `74`
- Summing: I believe you know how to add numbers :)
  - `42` + `17` = `59`
  - `39` + `57` = `96`

You have a sequence of `N` two-digit numbers. Your task is to merge and sum each pair of adjacent numbers.

## Input

All input data is read from the standard input (the console)

- On the first line you will receive an integer `N`
- On the next `N` lines you will receive `N` two-digit numbers
  - One on each line

## Output

The output data is printed on the standard output (the console)

- On the first output line print the merged numbers
  - There should be `N - 1` of them
  - Separate them by spaces
- On the second output line print the summed numbers
  - There should be `N - 1` of them
  - Separate them by spaces

- _Hint_: You can use `Console.WriteLine(String.Join(" ", array));`

## Constraints

- 2 <= `N` <= 1000
- Numbers will be consisted of **two non-zero digits**
- **The input data will always be correct and there is no need to check it explicitly**

## Sample Tests

### Sample Input 1

```
4
12
23
34
45
```

### Sample Output 1

```
22 33 44
35 57 79
```

### Sample Input 2

```
5
11
22
11
22
11
```

### Sample Output 2

```
12 21 12 21
33 33 33 33
```

### Sample Input 3

```
11
44
69
46
63
83
13
62
14
31
68
87
```

### Sample Output 3

```
46 94 66 38 31 36 21 43 16 88
113 115 109 146 96 75 76 45 99 155
```