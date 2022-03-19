***CRC Card***

| Class            |              |
|------------------|--------------|
| Responsibilities | Collaborator |

# Tic Tac Toe
- two players take turns making a choice
- each player designates the square of their choosing
- occupied squares cannot be chosen, players retry if this happens
- win/draw/cat outcomes displayed
- show state of board during game

## Objectives & CRC
- design the game as best out of 5

| Game Class |            |
|------------|------------|
| Game Loop  | TicTacToe  |
|            | Game State |
|            | Player 1   |
|            | Player 2   |
|            | UI + Stats |

| TicTacToe                       |     |
|---------------------------------|-----|
| choose a location 1-9           |     |
| compare with currently selected |     |
| best out of 5                   |     |

| Game State               |     |
|--------------------------|-----|
| moves remaining          |     |
| locations chosen by whom |     |
| win / loss / cat         |     |

| Player       |     |
|--------------|-----|
| Player 1 / 2 |     |
| input char   |     |
| losses       |     |
| wins         |     |
| cats         |     |

---
