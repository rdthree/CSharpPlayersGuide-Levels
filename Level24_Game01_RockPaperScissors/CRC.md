***CRC Card***

| Class            |              |
|------------------|--------------|
| Responsibilities | Collaborator |

# Rock Paper Scissors

## Objectives & CRC

- two players
- each chooses rock, paper OR scissors
- winner is determined:
    - rock beats scissors
    - paper beats rock
    - scissors beat paper
    - same pick is a draw
- EACH ROUND:
    - display winner
    - show running count of wins, draws per player

| Player Class                  |        |
|-------------------------------|--------|
| Choose: Rock, Paper, Scissors | Player |
| Wins                          |        |
| Points                        |        |
| Rounds Played                 |        |

| Game Class |         |
|------------|---------|
| Game Loop  | Game    |
|            | Players |
|            | Round   |
|            | Record  |

| Game Round Class |     |
|------------------|-----|
| Win              |     |
| Loss             |     |
| Draw             |     |

| Game Record Class |        |
|-------------------|--------|
| Stats per Player  | Record |
| Rounds            |        |
| Wins              |        |
| Losses            |        |
| Draws             |        |


| Enum RockPaperScissors |                   |
|------------------------|-------------------|
| Rock                   | RockPaperScissors |
| Paper                  |                   |
| Scissors               |                   |

| Enum WinLoseDraw |             |
|------------------|-------------|
| Win              | WinLoseDraw |
| Lose             |             |
| Draw             |             |

---
