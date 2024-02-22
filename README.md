# Rock-Paper-Scissors-Lizard-Spock-Game

This C# console application implements the popular game "Rock, Paper, Scissors, Lizard, Spock" where players can compete against the computer. The game includes rules, scoring, and interactive gameplay.

## Game Description

In this game, players can choose from five options: Rock, Paper, Scissors, Lizard, or Spock. Each option has different interactions with the others, leading to various outcomes. The game is played over a series of rounds, with the first player to win the majority of rounds declared the winner.

## Getting Started

To run the game, ensure you have the .NET SDK installed on your machine.

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/rock-paper-scissors-lizard-spock.git
   ```

2. Navigate to the project directory:
   ```bash
   cd rock-paper-scissors-lizard-spock
   ```

3. Build the project:
   ```bash
   dotnet build
   ```

4. Run the game:
   ```bash
   dotnet run
   ```

## Gameplay

### Rules
- `Rock` crushes `Lizard`, `Rock` crushes `Scissors`, `Rock` gets vaporized by `Spock`, `Rock` gets covered by `Paper`.
- `Paper` covers `Rock`, `Paper` disproves `Spock`, `Paper` gets eaten by `Lizard`, `Paper` gets cut by `Scissors`.
- `Scissor` cut `Paper`, `Scissors` decapitate `Lizard`, `Scissors` get crushed by `Rock`, `Scissors` get smashed by `Spock`.
- `Lizard` poisons `Spock`, `Lizard` eats `Paper`, `Lizard` gets crushed by `Rock`, `Lizard` gets decapitated by `Scissors`.
- `Spock` smashes `Scissors`, `Spock` vaporizes `Rock`, `Spock` gets poisoned by `Lizard`, `Spock` gets disproven by `Paper`.
  
### Game Flow
1. The game starts with a greeting message and displays the rules.
2. Each round, the player is prompted to make a selection (1-5) for Rock, Paper, Scissors, Lizard, or Spock.
3. The computer randomly selects an option.
4. The game processes the results and displays who wins the round.
5. Scores are updated based on the round's outcome.
6. The game continues for a set number of rounds (default: 5).
7. At the end of the rounds, the final score is displayed, and the winner (or tie) is announced.
8. Players have the option to play again.

## Code Overview
- `Game.cs`: Contains the main game logic and flow.
- `resultTable`: Defines the outcomes of player and computer selections.
- `reasonTable`: Describes the reason for each round's result.
- `Greeting()`: Displays the game rules and greets the player.
- `DisplayCurrentScore()`: Shows the current score during gameplay.
- `PlayerSelection()`: Prompts the player to make a selection.
- `CompSelection()`: Generates a random selection for the computer.
- `processResult()`: Determines the result of each round.
- `displayResults()`: Displays the final game results.
