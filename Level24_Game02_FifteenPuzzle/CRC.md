***CRC Card***

| Class            |              |
|------------------|--------------|
| Responsibilities | Collaborator |

# 15-Puzzle
Set of numbered tiles on a board with a single open slot.  Goal is to rearrange tiles to put numbers in order from left to right one row at a time, leaving an empty space on the bottom right corner

- player needs to manipulate the board and rearrange it
- game state to be displayed
- game detects when its solved and convey player win
- game generates random puzzle to solve
- game tracks and displays total player moves

## Objectives & CRC

| Game Class |            |
|------------|------------|
| Game Loop  | Board      |
|            | Game State |
|            | Player     |
|            | UI + Stats |

| Board                    |     |
|--------------------------|-----|
| 15 numbered tiles        |     |
| 1 empty tile             |     |      
| 4 x 4 matrix             |     |
| initialize random layout |     |
| movement logic           |     |

| Board State |     |
|-------------|-----|
| solved      |     |

| Player      |     |
|-------------|-----|
| move        |     |
| total moves |     |
| wins        |     |

---
