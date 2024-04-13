# Simple mine sweeper

I havent concentrated on UI, just a design approach, so it is an console app :-D :-D

This is a very simple minesweeper, Please do not copy or re-use it, come up with your own. This is just a test approach to solve a problem.

This was my thinking. 

1. Factory pattern for to have multiple game level, so introducing another game level would be simple.
2. Strategy pattern to play the game, now this is an console app later we can introduce unity, or winforms or even xamarin that was the intentions.
3. Command pattern to reload the window as the user input is involved. 


The logic is create a mine field with some random mines, in my grid -1 refers the mine. 

And it will ask for user input from a never ending while loop.

Then if the user matches the mine co-ordinates boom.

Else continue plus if the value is zero of a opened mine open the adjusant cells as well.


This might have some logic issues but my approach was on the design and how to test it and how to easily enhance it. 


