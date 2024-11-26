using System;

class RockPaperScissors
{
    // Enum to represent the choices
    public enum Choice
    {
        Rock,
        Paper,
        Scissors
    }

    // Method to convert string input to Choice enum
    public static Choice GetChoiceFromString(string choiceString)
    {
        switch (choiceString.ToLower())
        {
            case "rock":
                return Choice.Rock;
            case "paper":
                return Choice.Paper;
            case "scissors":
                return Choice.Scissors;
            default:
                throw new ArgumentException("Invalid choice.");
        }
    }

    // Method to determine the winner of a round
    public static string DetermineWinner(Choice player1Choice, Choice player2Choice)
    {
        if (player1Choice == player2Choice)
            return "It's a tie!";

        if ((player1Choice == Choice.Rock && player2Choice == Choice.Scissors) ||
            (player1Choice == Choice.Paper && player2Choice == Choice.Rock) ||
            (player1Choice == Choice.Scissors && player2Choice == Choice.Paper))
        {
            return "Player 1 wins!";
        }
        else
        {
            return "Player 2 wins!";
        }
    }

    // Method to display the current score
    public static void DisplayScore(int player1Score, int player2Score)
    {
        Console.WriteLine($"\nScore: Player 1 - {player1Score} | Player 2 - {player2Score}\n");
    }

    // Main method to run the game
    public static void Main(string[] args)
    {
        int player1Score = 0;
        int player2Score = 0;

        Console.WriteLine("Rock, Paper, Scissors Game!");
        Console.WriteLine("Type 'exit' at any time to quit the game.");

        while (true)
        {
            Console.WriteLine("\nRound Start!");
            Console.WriteLine("Player 1, enter your choice (rock, paper, or scissors):");
            string player1Input = Console.ReadLine();

            if (player1Input.ToLower() == "exit") break;

            Console.WriteLine("Player 2, enter your choice (rock, paper, or scissors):");
            string player2Input = Console.ReadLine();

            if (player2Input.ToLower() == "exit") break;

            try
            {
                Choice player1Choice = GetChoiceFromString(player1Input);
                Choice player2Choice = GetChoiceFromString(player2Input);

                string result = DetermineWinner(player1Choice, player2Choice);
                Console.WriteLine($"Player 1 chose: {player1Choice}");
                Console.WriteLine($"Player 2 chose: {player2Choice}");
                Console.WriteLine(result);

                if (result == "Player 1 wins!")
                    player1Score++;
                else if (result == "Player 2 wins!")
                    player2Score++;

                DisplayScore(player1Score, player2Score);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid input, please choose 'rock', 'paper', or 'scissors'.");
            }
        }

        Console.WriteLine("\nThanks for playing! Final score:");
        DisplayScore(player1Score, player2Score);
    }
}
