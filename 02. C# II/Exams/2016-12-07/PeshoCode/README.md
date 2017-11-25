<img src="https://raw.githubusercontent.com/TelerikAcademy/Common/master/logos/telerik-header-logo.png"/>

#### _Telerik Academy Season 2016-2017 / C# Advanced Exam - 07 December 2016_

# Task 4: PeshoCode

## Description
Let's just skip the useless text and get straight to the point. You need to make a program that accepts a keyword and a text. What you need to do is to find that keyword in the text and based on the sentence it is in, to generate a numerical code using the ASCII code for each character. That code is called PeshoCode, named after our favourite character Pesho.  

### The numerical code

The code itself is generated from a substring, that depending on the type of the sentence the keyword is in, starts and ends at:
- **Statement (.)** - The substring starts from the beginning of the sentence (inclusive), till the beginning of the keyword (exclusive) we are looking for.
- **Question (?)** - The substring starts from the end of the keyword (exclusive) we are looking for, till the end of the sentence (without the question mark though).

From that substring, you need to take the sum of the **ASCII value** of the **uppercase variant** of each character. **IGNORE THE SPACES**, do not include them in the calculations.


## Input
- On the first line, you will receive the **word** you should be looking for in the text
- On the second line you will receive the number **(N)** of lines the texts consists of
- On the next **N** lines, you will receive a line from the text.

## Output
- Your output should always be a single line. The content of the line should be the sum of the ASCII code of the uppercased characters in the given substring.

## Constraints
- The lines of the text can be a whole sentence or a part of a sentence.
- Sentences will always start with a **capital letter** and will end with a **dot or a question mark**.
- Sentences will not contain uppercase letters, besides from the first char in each sentence.
- There will not be more than **100** sentences, situated along no more than **150** lines.
- There will not be more than **500** words in each sentence.
- The provided keyword will never be contained inside another word.
- The provided keyword will be **unique** to the text.


## Explanation

In case you got confused, let's break down things a bit. You have a text and the keyword "tell" which we need to find. (See zero tests for the full version)


| Example text |
| --- |
| How do you **tell** html from html5? Try |
| it out in internet explorer. Did it    |
| work? No? It's html5.                  |


We can see that it's in the first sentence, which is a question. Therefore, we take the text after the keyword:

```
html from html5
```

From this substring, we have to get the **ASCII value** of the **uppercase variant** of each character, without taking into account the white spaces, which have the value of 32 each. The sum of the ASCII values in this case is:

```
979
```

## Zero tests

You can also find them in the `Tests` folder.

#### 01. Input

```
tell
3
How do you tell html from html5? Try
it out in internet explorer. Did it
work? No? It's html5.
```

#### 01. Expected output

```
979
```

#### 02. Input

```
will
4
Software developers like to solve
problems. If they are no problems
handily available, they will create
their own problems.
```

#### 02. Expected output

```
2962
```