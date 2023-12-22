using System;

class GuessingGame
{
    static void Main()
    {
        int totalWords = 0;
        int totalCorrectGuesses = 0;

        // Play the game a maximum of 5 times
        for (int gameNumber = 1; gameNumber <= 5; gameNumber++)
        {
            Console.WriteLine($"----- Level {gameNumber} -----");

            int level = gameNumber % 2 == 0 ? 2 : 1; // Alternate between levels 1 and 2
            int wordsInLevel = level == 1 ? 3 : 4;

            // Set words and hints for the current level
            string[] words = SetWords(level);
            string[] hints = SetHints(level);

            int playerLives = 3;
            int correctGuesses = 0;

            // Play the current level
            for (int wordIndex = 0; wordIndex < wordsInLevel; wordIndex++)
            {
                Console.WriteLine($"Hint: {hints[wordIndex]}");
                Console.Write("Guess the word: ");
                string playerGuess = Console.ReadLine();

                if (string.Equals(playerGuess, words[wordIndex], StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Correct!");
                    correctGuesses++;
                }
                else
                {
                    Console.WriteLine("Incorrect!");
                    playerLives--;
                    Console.WriteLine($"Lives remaining: {playerLives}");

                    if (playerLives == 0)
                    {
                        Console.WriteLine("Out of lives. Game over!");
                        break;
                    }
                }
            }

            totalWords += wordsInLevel;
            totalCorrectGuesses += correctGuesses;

            Console.WriteLine($"Level {level} completed. Correct guesses: {correctGuesses} out of {wordsInLevel}");
            Console.WriteLine($"Total correct guesses so far: {totalCorrectGuesses} out of {totalWords}");
            Console.WriteLine();
        }

        // Calculate and display the percentage score
        double percentageScore = (double)totalCorrectGuesses / totalWords * 100;
        Console.WriteLine($"Game Over! Your final percentage score: {percentageScore:F2}%");
    }

    // Set words based on the level
    static string[] SetWords(int level)
    {
        if (level == 1)
            return new string[] { "apple", "banana", "cherry" };
        else
            return new string[] { "elephant", "giraffe", "kangaroo", "lion" };
    }

    // Set hints based on the level
    static string[] SetHints(int level)
    {
        if (level == 1)
            return new string[] { "Fruit - red", "Fruit - yellow", "Fruit - red" };
        else
            return new string[] { "Large mammal", "Tall animal", "Hops", "King of the jungle" };
    }
}
