# Introduction 
## Project Overview:
Wheel of Fortune is an American based game show where players solve word puzzles by spinning a giant wheel and win cash and prizes. Our project is to emulate this game as a stand -alone console based application. Our motivation in this project is to learn and demonstrate 
1) the use of Azure Boards for capturing user stories while implementing Agile methodologies.
2) object oriented design principles using UML diagrams
3) building a standalone console applcation using C# while following SOLID principles.
4) unit test development
5) azure pipeline integration for CI (Continuous Integration)


# Getting Started

## Technologies used
Visual Studio , GIT, C#, Azure DevOps, .NET Framework 
1.	Installation process
 - Repo can be found at https://v-sdixit@dev.azure.com/v-sdixit/Wheel%20of%20Fortune/_git/Wheel%20of%20Fortune
 - Clone the repo in Visual Studio
2.	Latest releases - 2.0


## Build and Test
Use CTRL+SHIFT+B to build . Run the code using CTRL + F5. For every feature, always add unit tests before creating a pull request
 

## Assumptions
Multiple players will play on the same console.

## Out of scope
1) Implementing user login and authentication.  
2) Implementing graphical user interface
 

## Concepts Implemented
SOLID principles, Dependency injection, static overloading

## Architecture
 
![OODesign logo](./assets/UML.jpg)

Game class is the entry point into the application. It instantiates the game with the required number of rounds and players. Each round has one puzzle to solve and players take several turns to solve the puzzle. At each turn, the player has two choices i.e. player can guess a letter or choose to solve the puzzle. If the player chooses to guess the puzzle, the wheel is spun. The puzzle class is responsible unlocking the guessed letters if present. The score gets calculated for the player. If the player chooses to  solve the puzzle, he/she needs to enter the answer and if correct, wins that round else the turn is passed to the next player. This continues until all the rounds are exhausted and the winner is announced

## CLI Interface
![CLI Interface logo](./assets/WheelOfFortune.gif)

## Azure pipeline details
Pipeline was set up to run tests automatically with every merge to main. 

## Contributors
Leo Kukharau, Joseph Yang, Michelle Tanzil, William Brennan, Supriya Dixit