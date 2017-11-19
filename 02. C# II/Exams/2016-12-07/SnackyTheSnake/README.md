<img src="https://raw.githubusercontent.com/TelerikAcademy/Common/master/logos/telerik-header-logo.png"/>

#### _Telerik Academy Season 2016-2017 / C# Advanced Exam - 07 December 2016_
# Task 3: Snacky the Snake

## Description
Snacky the Snake loves to have snacks. He found a den that is full of eggs that he loves to eat so much, but there's a problem. The den is so dark that he has to be prepared in advance and know where to go once he is in. Use you Advanced C# skills to help Snacky out.

The den is represented by a two dimensional array of symbols. Possible symbols are:
- `.` - represents free **space**.
- `#` - represents a **rock**.
- `*` - represents **food**.
- `s` - represents the entrance of the den (starting point).
The first line will be filled with the symbol **#** (rocks) and **only one** symbol will be **s** (entrance)

_Example input:_
```
5x8
####s###
....*...
..*.....
.....*..
..###...
d,l,l,d,d,r,r,u,u,u
```

Then Snacky will give you a rout to test separated with commas `,`. The directions are: **d** - down, **u** - up, **l** - left, **r** - right

There are a few other **IMPORTANT** things you should have in mind:
- Snacky needs to **enter and exit from the same spot** (entrance) otherwise he will **remain in the den**.
- Snacky enters the den with length `3` and for every `5` moves he makes he loses `1` of his length, but if he eats some food `*` he gains `1` length. If his length drops to `0` or below he will **starve in the den**.
  - _NOTE_: This is always calculated before the result of the move!
  - _NOTE_: Food can be consumed only once (it is gone after the first time Snacky moves to it)
- If he goes below the provided depth **R** he will lose sight of the entrance and will be **lost into the depths**.
- If Snacky moves to the left or right and exceeds the width of the den **C**, he will go to the other side of the den.
  - If he is at the rightmost column and goes right (**r**) he will go to the leftmost column
  - If he is at the leftmost column and goes left (**l**) he will go to the rightmost column

The possible results of a path are:
- `Snacky will get out with length L` - when Snacky successfully exits the den.
- `Snacky will hit a rock at [R,C]` - when Snacky hits a rock (**#**) anywhere in the den.
- `Snacky will be lost into the depths with length L` - when Snacky moves below the provided depth **R**.
- `Snacky will starve at [R,C]` - when Snacky's length drops to `0` or lower.
- `Snacky will be stuck in the den at [R,C]` - when Snacky is stuck inside the den when the moves end.
  - _NOTE_: Substitute **R** and **C** with the row and column where Snacky is.
  - _NOTE_: Substitute **L** with the length of Snacky.

## Input
- On the **first line** you will receive the dimensions of the den in format **RxC**, where **R** is the depth of the den (number of rows) and **C** is the width (number of columns).
- On the next **R** lines you will receive the representation of the den (see example).
- On the last line you will receive the step directions you have to execute separated by a single comma `,`.

## Output
- Your output should always be a single line with content depending on the result of the path taken.

## Constraints
- **R** and **C** will be between **5** and **30**
- The number of moves will not be more than **120**
- Memory limit: **16 MB**
- Time limit: **0.10 sec**

## Sample tests 1
#### input
```
5x8
####s###
....*...
..*.....
.....*..
........
d,l,l,d,d,r,r,u,u,u
```

#### output
```
Snacky will get out with length 3
```

#### explanation
- Snacky enters from [0, 4] with length = 3
- Moves **d**own to [1,4] and consumes the food, so he gains +1 to length (length = 4)
- Moves **l**eft to [1,3]
- Moves **l**eft to [1,2]
- Moves **d**own to [2,2] and consumes the food, so he gains +1 to length (length = 5)
- Moves **d**own to [3,2] and loses 1 from length because this is the 5th move (length = 4)
- Moves **r**ight to [3,3]
- Moves **r**ight to [3,4]
- Moves **u**p to [2,4]
- Moves **u**p to [1,4]
- Moves **u**p to [0,4], loses 1 from length because this is the 10th move and gets out with length 3

## Sample tests 2
#### input
```
5x8
####s###
....*...
..*.....
.....*..
..###...
d,l,l,d,d,r,r,r,u,u,u
```

#### output
```
Snacky will hit a rock at [0,5]
```

#### explanation
- Similar to the first example, but taking one more step to the right, so Snacky end up hitting the rocks at position [0,5]

## Sample tests 3
#### input
```
5x8
####s###
....*...
..*.....
.....*..
..###...
d,l,l,d,d,r,r,u,u
```

#### output
```
Snacky will be stuck in the den at [1,4]
```

#### explanation
- Similar to the first example, but this time Snacky does one less move up, so he ends up in the den at position [1,4]


## Sample tests 4
#### input
```
5x8
####s###
....*...
..*..##.
.....*..
..###...
d,l,l,d,d,r,r,r,u,u,u
```

#### output
```
Snacky will hit a rock at [2,5]
```

#### explanation
- Similar to the second example, but this time Snacky hits the rock at position [2,5] when he does the first `u` (up) move


## Sample tests 5
#### input
```
5x8
####s###
....*...
..*..##.
.....*..
..###...
d,l,l,d,l,l,l,d,l,l,l,u,u,u
```

#### output
```
Snacky will get out with length 4
```

#### explanation
- Snacky enters from [0, 4] with length = 3
- Moves **d**own to [1,4] and consumes the food, so he gains +1 to length (length = 4)
- Moves **l**eft to [1,3]
- Moves **l**eft to [1,2]
- Moves **d**own to [2,2] and consumes the food, so he gains +1 to length
- Moves **l**eft to [2,1] and loses 1 from length because this is the 5th move (length = 4)
- Moves **l**eft to [2,0]
- Moves **l**eft to [2,7]
- Moves **d**own to [3,7]
- Moves **l**eft to [3,6]
- Moves **l**eft to [3,5] and consumes the food, so he gains +1 to length (length = 5), but also loses 1 from length because this is the 10th move (length = 4)
- Moves **l**eft to [3,4]
- Moves **u**p to [2,4]
- Moves **u**p to [1,4]
- Moves **u**p to [0,4] and gets out with length 4