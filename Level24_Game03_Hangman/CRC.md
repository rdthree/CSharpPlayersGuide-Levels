***CRC Card***

| Class            |              |
|------------------|--------------|
| Responsibilities | Collaborator |

# Hangman
Computer picks random word for player to guess.  Player guesses word by selecting letters from alphabet.
These letters progressively fill in and reveal the word.  Only a limited amount of letters can be wrong before losing the game.
When a correct letter is chosen, everywhere it appears on the word is displayed.

- Game randomly chooses word, it is hidden from player
- Game state is shown and updated: Letters Remaining, Incorrect Guesses, Current Guess
- If player accidentally chooses an already guessed letter, choose again
- Game Detects Wins
- Game Detects Losses

## Objectives & CRC

| Game Class |            |
|------------|------------|
| Game Loop  | Hangman    |
|            | Game State |
|            | Player     |
|            | UI + Stats |

| Hangman                           |     |
|-----------------------------------|-----|
| choose a random word              |     |
| compare input chars to word chars |     |


| Game State                |     |
|---------------------------|-----|
| letters remaining         |     |
| incorrect guesses         |     |
| current guessed character |     |

| Player     |     |
|------------|-----|
| input char |     |
| losses     |     |
| wins       |     |

---
