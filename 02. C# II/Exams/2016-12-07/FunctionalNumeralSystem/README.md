<img src="https://raw.githubusercontent.com/TelerikAcademy/Common/master/logos/telerik-header-logo.png" />

#### _Telerik Academy Season 2016-2017 / C# Advanced Exam - 07 Dec 2016_

# Task 1: Functional Numeral System

## Description
**Ocek** and **Ikuc** like functional programming. 
One day they decided to invent a secret numeral system, so they can send encoded messages to each other without anyone else understanding them. They're using names of functional programming languages to represent the digits.
However, the **FBI** caught wind of it and since they know that you know a little bit of programming, your task is to decode the numbers that **Ocek** and **Ikuc** send to each other. 
Thankfully, the **FBI** also provided you with some additional information about their numeral system - below are all the numbers of their numeral system and their values in the decimal numeral system:

| Digit      | Decimal value   |
| ---------- |:---------------:|
| ocaml      | 0               |
| haskell    | 1               |
| scala      | 2               |
| f#         | 3               |
| lisp       | 4               |
| rust       | 5               |
| ml         | 6               |
| clojure    | 7               |
| erlang     | 8               |
| standardml | 9               |
| racket     | 10              |
| elm        | 11              |
| mercury    | 12              |
| commonlisp | 13              |
| scheme     | 14              |
| curry      | 15              |

### Decoding the messages
- **Ocek** will send **3** numbers in the functional numeral system to **Ikuc**. The **FBI** have deduced that you must find **the product** of the **3** numbers and print it's value in decimal numeral system.

## Input
- On the only input line you will receive the three numbers in the functional numeral system separated by a comma and a space - **`", "`**

## Output
- Output a single line containing a single value - **the product** of the **3** input numbers in the decimal numeral system.

## Constraints
- The input numbers' value will always be between 0 and 2^60, inclusive.

## Sample tests
| Input                                | Output           |
|:------------------------------------ |:---------------- |
| lispscala, scalaerlang, scalahaskell | 87120            |
| rust, elm, haskellscala              | 990              |
| rust, standardml, haskellscala       | 810              |
| racket, haskellml, mllisp            | 22000            |
| haskellscheme, scalaerlang, scala    | 2400             |
| haskellmercury, scalaerlang, scala   | 2240             |

## Hints
- **Use only if you're stuck :)**
- The **FBI** figured that their task is a bit hard, so they left you a hint - an array of ASCII character codes in the **base 6** numeral system. If you turn the numbers from **base 6** to **base 10**, take the corresponding ASCII symbols and concatenate them, you get to see the hint :)

```csharp
var hint = new string[] 
{
    "200", "303", "315", "52", "301", "241", "302", "321", "52", "244", "253", "251",
    "253", "312", "311", "52", "244", "303", "245", "311", "52", "312", "252", "253",
    "311", "52", "302", "313", "301", "245", "310", "241", "300", "52", "311", "321",
    "311", "312", "245", "301", "52", "252", "241", "314", "245", "143", "52", "201",
    "311", "52", "312", "252", "245", "310", "245", "52", "241", "302", "52", "241",
    "304", "304", "310", "303", "304", "310", "253", "241", "312", "245", "52", "242",
    "313", "253", "300", "312", "113", "253", "302", "52", "250", "313", "302", "243",
    "312", "253", "303", "302", "241", "300", "253", "312", "321", "143", "21", "14",
    "215", "312", "310", "253", "302", "251", "114", "214", "245", "304", "300", "241",
    "243", "245", "52", "243", "241", "302", "52", "311", "253","301", "304", "300",
    "253", "250", "321", "52", "312", "252", "253", "302", "251", "311", "52", "241",
    "52", "300", "303", "312", "112", "52", "254", "313", "311", "312", "52", "242",
    "245", "52", "243", "241", "310", "245", "250", "313", "300", "52", "253", "302",
    "52", "315", "252", "241", "312", "52", "303", "310","244", "245", "310", "52",
    "321", "303", "313", "52", "310", "245", "304", "300", "241", "243", "245", "21",
    "14", "220", "252", "253", "302", "255", "52", "241", "242", "303", "313", "312",
    "52", "312", "252", "245", "52", "244", "241", "312", "241", "52", "312", "321",
    "304", "245", "311", "52", "303", "250", "52", "312", "252", "245", "52", "312",
    "252", "310", "245", "245", "52", "302", "313", "301", "242", "245", "310", "311",
    "52", "241", "302", "244", "52", "312", "252", "245", "52", "310", "245", "311",
    "313", "300", "312", "52", "113", "52", "252", "303", "315", "52", "301", "313",
    "243", "252", "52", "253", "311", "52", "122", "234", "130", "120", "52", "110",
    "52", "122", "234", "130", "120", "52", "110", "52", "122", "234", "130", "120", "143"
};
```