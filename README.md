# Simple mine sweeper

I havent concentrated on the UI, just looked at the design approach, so it is an simple console app :-D :-D

This is a very simple minesweeper, Please do not copy or re-use it, come up with your own. This is just a test approach to solve a problem.

This was my thinking. 

1. Factory pattern to have multiple game level, so in future introducing another game level would be simple.
2. Strategy pattern to play the game, now this is an console app but later we can introduce unity, or winforms or even xamarin, so by using strategy it is easy to implement another type of the same game.
3. Command pattern to reload the objects(Console) as the user input is involved. 


The logic is to create a mine field with some random mines, in my grid -1 refers the mine. 

And this program will ask for user input from a never ending while loop until the user wins or hit a mine.

As the user progress and if the value is zero of a opened cell then the adjusant cells are opened as well.

This might have some logic issues but my approach was on the design and how to test it and how to easily enhance it. 


# Set up 

Make the Minesweeper.App as your start up project and try passing your co-ordinates to run the game.

# Files - Description

## Minesweeper.App

1. Console app, at startup DI is used build dependencies.
2. Calls the game service 

## ApplicationCore

1. Service Folder - has the game service which inturn calls the mine strategy class, in this case it is a console app but this place can hold for other strategies like Winform, unity
2. Strategies Folder - place to have your strategies like Winform, unity
3. Factories Folder - place to have multiple game level like Beginner, Complex and intermediate
4. Commands Folder - place to have the commands based on user input like reload the data in the console / window or where ever.
5  Exceptions Folder - place to have our custom exception based on the strategies which is been used. 

## Test

1. Place to have your unit/functional/integration tests