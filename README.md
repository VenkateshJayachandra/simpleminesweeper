# Simple Minesweeper

This project is a basic console application for the game Minesweeper. 
It's designed with a focus on extensibility, making it easy to adapt for different platforms or game levels.

**Please note:** 
This is intended for reference only. 
This is a test project and not intended for reuse without modification.

## Design Approach

The application design is based on three main patterns:

1. **Factory Pattern**: Facilitates the introduction of new game levels.
2. **Strategy Pattern**: Allows the game to be adapted for different platforms (console, WinForms, Unity, Xamarin, etc.).
3. **Command Pattern**: Handles user input and updates the game state accordingly.

## Game Logic

The game starts by generating a grid of cells, with some cells randomly designated as mines (represented by -1). 
The game then enters a loop, asking the user for input until they either win the game or hit a mine. 
If a user reveals a cell with a value of zero, all adjacent cells are also revealed.

## Setup

To run the game, set `Minesweeper.App` as your startup project and provide your coordinates when prompted.

## Project Structure

- **Minesweeper.App**: The main console application. It sets up dependencies and starts the game service.
- **ApplicationCore**: Contains the core logic of the application, organized into several folders:
  - **Services**: Contains the game service, which calls the appropriate strategy to run the game.
  - **Strategies**: Contains different strategies for running the game, allowing it to be adapted for different platforms, such as (console, WinForms, Unity, Xamarin, etc.).
  - **Factories**: Contains factories for creating different game levels. (Beginner, Complex or Intermediate)
  - **Commands**: Contains commands for handling user input and updating the game state.
  - **Exceptions**: Contains custom exceptions for handling errors based on the strategies used.
- **Test**: Contains unit, functional, and integration tests for the application.

Please note that while the design and structure of this application are carefully thought out, there may still be some logic issues. 
The focus of this project was on the design and how to test and enhance it.
