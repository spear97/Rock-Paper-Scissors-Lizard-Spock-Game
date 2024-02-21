using System;

class Game
{
    //Scoring for the Player Character and Computer
    public int playerScore = 0, CompScore = 0;

    //Rounds for the Game
    public int currRound = 0, maxRounds = 5;

    //Has the Game Started?
    public bool Init;

    //Contains display data for what the Player Selected
    public string[] playerSelectionPrompt = { 
                                              "Player Selected Rock!",
                                              "Player Selected Scissors!",
                                              "Player Selected Paper!",
                                              "Player Selected Lizard!",
                                              "Player Selected Spock!"
                                            };

    //Contains display data for what the Computer Selected
    public string[] compSelectionPrompt = {
                                            "Computer Selected Rock!",
                                            "Computer Selected Scissors!",
                                            "Computer Selected Paper!",
                                            "Computer Selected Lizard!",
                                            "Computer Selected Spock!"
                                          };

    //Contains display data for what the results of the round could be
    public string[] resultsPrompt = { 
                                      "Result: Player Wins!\nA point is awarded to the Player!",
                                      "Result: Computer Wins!\nA point is awarded to the Computer!",
                                      "Result: TIE!"
                                    };

    //Result of the Table
    public string[,] resultTable = {
                                        {"TIE", "COMPUTER", "PLAYER", "PLAYER", "COMPUTER"},
                                        {"PLAYER", "TIE", "COMPUTER", "COMPUTER", "PLAYER"},
                                        {"COMPUTER", "PLAYER", "TIE", "PLAYER", "COMPUTER"},
                                        {"COMPUTER", "PLAYER", "COMPUTER", "TIE", "PLAYER"},
                                        {"PLAYER", "COMPUTER", "PLAYER", "COMPUTER", "TIE"}
                                    };

    //Reason for the Result of the Round
    public string[,] reasonTable = {
                                        {"Rock is Rock!", "Paper Covers Rock!", "Rock Crushes Scissors!", "Scissors Decapitates Lizard!", "Spock Vaporizes Rock!"},
                                        {"Paper Covers Rock!", "Paper is Paper!", "Scissors Cutes Paper!", "Lizard Eats Paper!", "Paper Disproves Spock!"},
                                        {"Rock Crushes Scissors!", "Scissors Cuts Paper!", "Scissors is Scissors!", "Scissors Decapitates Lizard!", "Spock Smashes Scissors!"},
                                        {"Rock Crushes Lizard!", "Lizard Eats Paper!", "Scissors Decapitates Lizard!", "Lizard is Lizard!", "Lizard Poisons Spock!"},
                                        {"Spock Vaporizes Rock!", "Paper Disproves Spock!", "Spock Smahes Scissors!", "Lizard Poisons Spock!", "Spock is Spock!"}
                                   };


    //Greet the player and tell the player the rules of the game
    public bool Greeting()
    {
        //Contents of the Greeting Message
        string[] prompt = {
                            "----------------------------------------------------------------------------------",
                            "Welcome to Rock, Paper, Scissors, Lizard, Spock!",
                            "----------------------------------------------------------------------------------",
                            "Rules:",
                            "----------------------------------------------------------------------------------",
                            "\t1.) Rock",
                            "----------------------------------------------------------------------------------",
                            "\t\ta.) Crushes Lizard",
                            "\t\tb.) Crushes Scissors",
                            "\t\tc.) Gets Vaporized by Spock",
                            "\t\td.) Gets Covered by Paper",
                            "----------------------------------------------------------------------------------",
                            "\t2.) Paper",
                            "----------------------------------------------------------------------------------",
                            "\t\ta.) Covers Rock",
                            "\t\tb.) Disproves Spock",
                            "\t\tc.) Gets Eaten by Lizard",
                            "\t\td.) Gets cut by Scissors",
                            "----------------------------------------------------------------------------------",
                            "\t3.) Scissors",
                            "----------------------------------------------------------------------------------",
                            "\t\ta.) Cuts Paper",
                            "\t\tb.) Decapitates Lizard",
                            "\t\tc.) Gets Crushed by Rock",
                            "\t\td.) Gets Smashed by Spock",
                            "----------------------------------------------------------------------------------",
                            "\t4.) Lizard",
                            "----------------------------------------------------------------------------------",
                            "\t\ta.) Poisons Spock",
                            "\t\tb.) Eats Paper",
                            "\t\tc.) Gets Crushed by Rock",
                            "\t\td.) Get decapitated by Scissors",
                            "----------------------------------------------------------------------------------",
                            "\t5.) Spock",
                            "----------------------------------------------------------------------------------",
                            "\t\ta.) Smashes Scissors",
                            "\t\tb.) Vaporizes Rock",
                            "\t\tc.) Gets Poisioned by Lizard",
                            "\t\td.) Gets Disproven by Paper",
                            "----------------------------------------------------------------------------------",
                            "\t6.) The side to win the majority of 5 rounds, will be deemed the winner",
                            "----------------------------------------------------------------------------------",
        };

        //Output each line of the Prompt
        for (int i = 0; i < prompt.Length; i++)
        {
            Console.WriteLine(prompt[i]);
        }

        //Return true to indicate that the Game has begun
        return true;
    }

    //Display the Current Score of the Player Character
    public void DisplayCurrentScore(Game game)
    {
        Console.WriteLine($"\t\t\t\tRound: {game.currRound+1}\n\t\t\tPlayer: {game.playerScore} | Computer: {game.CompScore}");
    }

    //Prompt Player to make a Selection
    public int MakePlayerSelection()
    {
        //User enter selection here
        string selection = Console.ReadLine();

        //Parse Selection to an Integer Value
        int selectionNum = int.Parse(selection);

        return selectionNum;
    }

    //Prompt Player if they would like to play again
    public void playAgain(Game game)
    {
        Console.WriteLine("----------------------------------------------------------------------------------");
        Console.Write("Do you want to play again? (Y/N) ");
        string decision = Console.ReadLine();

        if(decision.Equals("Yes", StringComparison.OrdinalIgnoreCase))
        {
            //Start Game from Fresh
            game.GameLoop(new Game());
        }
        else if (decision.Equals("No", StringComparison.OrdinalIgnoreCase))
        {
            return;
        }
        else
        {
            Console.WriteLine("INVALID INPUT! PLEASE ENTER A VALID INPUT!");
            game.playAgain(game);
        }
    }

    //Player Choice Selection
    public int PlayerSelection()
    {
        //Selection Menu to aid player in making selection
        string[] prompt = 
        {
            "----------------------------------------------------------------------------------",
            "Selection Menu",
            "----------------------------------------------------------------------------------",
            "\t1.) Rock",
            "\t2.) Paper",
            "\t3.) Scissors",
            "\t4.) Lizard",
            "\t5.) Spock",
            "----------------------------------------------------------------------------------",
            "Make your Selection: ",
        };

        //Output Selection Menu
        for (int i = 0; i < prompt.Length-1; i++)
        {
            Console.WriteLine(prompt[i]);
        }

        //Output Prompt for player to input their selection
        Console.Write(prompt[prompt.Length-1]);

        try
        {
            //Parse Selection to an Integer Value
            int selectionNum = MakePlayerSelection();

            //Format the output of the program
            Console.WriteLine(prompt[prompt.Length - 2]);

            return selectionNum;
        }
        catch(FormatException)
        {
            //Display Error Message
            Console.WriteLine("INVALID INPUT! PLEASE ENTER A INTEGER VALUE (1-5)!");

            //Perform recursion
            int selectionNum = PlayerSelection();

            return selectionNum;
        }
    }

    //Generate Computer Selection
    public int CompSelection()
    {
        // Create a new instance of the Random class
        Random random = new Random();

        // Generate a random integer between 1 and 5 (inclusive)
        int randomNumber = random.Next(1, 6);

        return randomNumber;
    }

    //Process the results of the match
    public Game processResult(Game game, int playerSelection, int compSelection)
    {
        //The Index pointing at the Player's Selection and the Computer's Selection
        int i = playerSelection - 1, j = compSelection - 1;

        //The display the selection of the Player and Computer
        string selectionDisplay = $"{game.playerSelectionPrompt[i]} {game.compSelectionPrompt[j]}";

        //The reason for the round's result
        string reasonDisplay = game.reasonTable[i, j];

        //Get the result display of the round
        string resultItem = game.resultTable[i, j];
        int index = (resultItem == "PLAYER") ? 0 : (resultItem == "COMPUTER") ? 1 : 2;
        string resultDisplay = game.resultsPrompt[index];

        //Update Score
        switch(index)
        {
            //If Index points to a winning player result
            case 0:
                game.playerScore++;
                break;

            
            case 1:
                game.CompScore++;
                break;
        }

        //Increment the current Round
        game.currRound++;

        //Display the result of the round
        Console.WriteLine($"{selectionDisplay}\n{reasonDisplay}\n{resultDisplay}");

        Console.WriteLine("----------------------------------------------------------------------------------");

        return game;
    }

    //Display the results of the Game
    public void displayResults(Game game)
    {
        Console.WriteLine($"Game Over!\nFinal Score: {game.playerScore} - {game.CompScore}");
        if (game.playerScore > game.CompScore) Console.WriteLine("Result: Player Wins!");
        else if (game.playerScore > game.CompScore) Console.WriteLine("Result: Computer Wins!");
        else Console.WriteLine("Result: Tie!");
    }

    //Run the Game for it to run
    public void GameLoop(Game game)
    {
        //Greet the Player
        game.Init = game.Greeting();

        //Game Loop
        while (game.Init)
        {
            //Display the Current Score for the game
            game.DisplayCurrentScore(game);

            //Get Player and Computer Selections
            int playerSelection = game.PlayerSelection();
            int compSelection = game.CompSelection();

            //Process the result of the player and computer decision
            game = game.processResult(game, playerSelection, compSelection);

            // Check if game has hit 5 rounds
            if (game.currRound >= 5) game.Init = false;
        }

        //Display Results of the Game
        game.displayResults(game);

        //Ask Player if they would like to play again
        game.playAgain(game);
    }


    //Driver Function
    private static void Main()
    {
        //Initialize the Game Object
        Game game = new Game();

        //Run the Game
        game.GameLoop(game);
    }
}
