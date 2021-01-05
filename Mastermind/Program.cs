using System;

namespace Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mastermind there is a secret code that is 4 digits long that contains only numbers 1-6);
            Console.WriteLine("You will have 10 attempts to guess the code and each attempt must be 4 consequtive digits (####) each 1-6);
            var rand = new Random();
            int[] ans = new int[4] {rand.Next(1,7), rand.Next(1, 7), rand.Next(1, 7) , rand.Next(1, 7)};
            bool isCorrect = false;
            int numCor;
            int placesCor;
            for (int i = 1; i <= 10; i++)
            {
                try
                {
                    Console.WriteLine("Attempt "+ i + "/10. Enter your guess:");
                    int guess = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Guess: " + guess);
                    if (guess > 6666 || guess < 1000)
                    {
                        throw new ArithmeticException();
                    }
                    numCor = 0;
                    placesCor = 0;
                    int[] guessArray = new int[4] { guess / 1000, guess / 100 % 10, guess / 10 % 10, guess % 10 };
                    foreach (int j in guessArray)
                    {
                        if (j > 6 || j == 0)
                        {
                            throw new ArithmeticException();
                        }
                    }
                    for (int j = 0; j < 4; j++)
                    {
                        for (int k = 0; k < 4; k++)
                        {
                            if (j == k)
                            {
                                if (guessArray[j]*10 == ans[k])
                                {
                                    placesCor++;
                                    numCor--;
                                    
                                }
                                else if (guessArray[j] == ans[k])
                                {
                                    placesCor++;
                                    ans[k] *= 10;
                                    break;
                                }
                            }
                            else if (guessArray[j] == ans[k])
                            {
                                numCor++;
                                ans[k] *= 10;
                                break;
                            }
                        }
                    }
                    for (int j = 0; j < 4; j++)
                    {
                        if (ans[j] > 10)
                        {
                            ans[j] /= 10;
                        }
                    }
                    if (placesCor == 4)
                    {
                        isCorrect = true;
                        break;
                    }
                    while (numCor > 0)
                    {
                        Console.Write("-");
                        numCor--;
                    }
                    while (placesCor > 0)
                    {
                        Console.Write("+");
                        placesCor--;
                    }
                    Console.WriteLine();
                }
                catch
                {
                    Console.WriteLine("Guess must be 4 consecutive digits 1-6, try again");
                    i--;
                }
            }
            string result = isCorrect ? "You broke the code and are the mastermind":
                "You couldn't break the code the correct answer was " + ans[0] + ans[1] + ans[2] + ans[3];
            Console.WriteLine(result);
        }
    }
}
