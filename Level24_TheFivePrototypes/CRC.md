***CRC Card***

| Class            |              |
|------------------|--------------|
| Responsibilities | Collaborator |

# The Point

Define a point class with properties for X and Y. Each point has an x coordinate, a side to side distance from an
origin, a y coordinate

## Objectives & CRC

- Define a new Point class with properties for X and Y
- Add a constructor to create a point from specific x and y coordinates
- Add a parameterless constructor to create a point at origin (0,0)
- Display a point at (2,3) and (-4,0) as a test
- Are X and Y immutable? Why? Why not?

| Point Class   |       |
|---------------|-------|
| X position    | Point |
| Y Position    |       |
| Origin (0,0)  |       |
| Display (x,y) |       |

---

# The Color

Color class representing a color. Colors consists of three channels R, G, B. Each channel can be from 0 to 255. 0 is
completely off, 255 is completely on. Examples of commonly used colors:

- White (255, 255, 255)
- Black (0, 0, 0)
- Red (255, 0, 0)
- Orange (255, 165, 0)
- Yellow (255, 255, 0)
- Green (0, 128, 0)
- Blue (0, 0, 255)
- Purple (128, 0, 128)

## Objectives & CRC

- define a new Color class with properties for R, G, B channels
- constructors for new color objects
- static properties for 8 commonly used colors
- two test variables, display the RGB channels of a custom color and a static color

| Color Class       |       |
|-------------------|-------|
| R channel         | Color |
| G channel         |       |
| B channel         |       |
| 8 common colors   |       |
| Display (R, G, B) |       |

---

# The Card

Playing cards with a color (red, green, blue, yellow) and a rank (1 through 10, followed by symbols $,%,^,&) Symbol
cards are equivalent to face cards.

## Objectives & CRC

- enums for card colors and ranks
- Card class
- tell if a card is a number or symbol card
- method to create a card instance for the whole deck (every number, every rank) and display each with a string name
- example: 14 red cards {1 thru 10 + (4) ranks)

| Card Class                            |      |
|---------------------------------------|------|
| Red, Green, Blue, Yellow cards        | Card |
| 1 thru 10 cards (in a color)          |      |
| $, %, ^, & cards (in a color)         |      |
| identify card: number or symbol       |      |
| deck: all colors (numbers or symbols) |      |

---

# The Locked Door

A door that can only lock with the correct passcode. Operation:

- Open door can always close
- Closed Unlocked can always open
- Closed Unlocked can always lock
- Closed Locked needs a password to unlock
- Door gets passcode upon creation
- Passcode can be changed by using the current code

## Objectives & CRC
Logic should stay within the door class so that the password can stay secure and control the door states.  Making the door condition immutable causes weird issues with the password.

- Door class tracks locked, open, closed
- Performs transitions with methods
- User provided initial passcode ad door creation
- Method to change passcode

| Door Class                              |      |
|-----------------------------------------|------|
| Open -> Close -> Lock -> Unlock -> Open | Door |
| Password at Door Creation               |      |
| Password to Unlock                      |      |
| Change Password using old Password      |      |
| User can operate door continuously      |      |

---

# The Password Validator

Determine if a password is valid.
- password between 6 and 13 characters long
- one uppercase letter
- one lower case letter
- one number
- cannot contain 'T'
- cannot contain '&'
 
## Objectives & CRC
- New PasswordValidator class that takes the password and validates it based on the rules at hand
- Loops until the password is correct

| PasswordValidator Class       |                   |
|-------------------------------|-------------------|
| take input                    | PasswordValidator |
|  check each character         |                   |
| repeat until password correct |                   |

---



