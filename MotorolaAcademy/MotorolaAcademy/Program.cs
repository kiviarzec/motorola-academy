using System;

namespace MotorolaAcademy
{
    class Program
    {
        static void Main(string[] args)
        {

            string again = "NO";

            do
            {

                Console.WriteLine("Hello World!");
                // Read each line of the file into a string array. Each element
                // of the array is one line of the file.
                string[] lines = System.IO.File.ReadAllLines(@"C:\Users\kaerz\Documents\motorola-academy\countries_and_capitals.txt.txt");

                //            for (int i = 0; i < lines.Length; i++)
                //            {
                //                Console.WriteLine(lines[i]);
                //            }

                // Instantiate random number generator using system-supplied value as seed.
                var random = new Random();
                int randomIndex = random.Next(0, lines.Length - 1);  // creates a number between 1 and 12

                Console.WriteLine(randomIndex);

                string randomLine = lines[randomIndex];
                Console.WriteLine(randomLine);

                string[] words = randomLine.Split(" | ");
                string country = words[0].ToUpper();
                string capital = words[1].ToUpper();
                Console.WriteLine(country);
                Console.WriteLine(capital);
                char[] capitalAsChars = capital.ToCharArray();
                Console.WriteLine(capitalAsChars);
                for (int i = 0; i < capitalAsChars.Length; i++)
                {
                    capitalAsChars[i] = '_';
                }


                int lives = 5;
                Console.WriteLine("You've got " + lives + " lives");

                char[] notInWordList = new char[] { '_', '_', '_', '_', '_' };


                Console.WriteLine("Let's play!");

                while (lives > 0)
                {

                    Console.WriteLine("Capital to guess : ");
                    Console.WriteLine(capitalAsChars);

                    Console.WriteLine("Not in word list : ");
                    Console.WriteLine(notInWordList);


                    Console.WriteLine("Do you want to guess a single letter or the whole word?");
                    Console.WriteLine("Write LETTER or WORD to choose");


                    string choose = Console.ReadLine().ToUpper();

                    if (choose == "WORD")
                    {
                        Console.WriteLine("Guess the whole word:");
                        string guessWord = Console.ReadLine().ToUpper();

                        if (guessWord == capital)
                        {
                            Console.WriteLine("That's correct!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("That's incorrect!");
                            lives--;
                            Console.WriteLine("You've got " + lives + " lives");

                            if (lives != 0)
                            {
                                Console.WriteLine("Try again");
                            }
                            else
                            {
                                Console.WriteLine("Game over!");
                            }
                        }

                    }
                    else if (choose == "LETTER")
                    {
                        Console.WriteLine("Guess a letter:");

                        string guessLetter = Console.ReadLine().ToUpper();
                        Console.WriteLine("You chose " + guessLetter);


                        if (capital.Contains(guessLetter[0]))
                        {

                            for (int i = 0; i < capital.Length; i++)

                            {
                                if (guessLetter[0] == capital[i])
                                {
                                    Console.WriteLine("That letter is in that word!");

                                    capitalAsChars[i] = guessLetter[0];

                                }

                            }

                            string capitalAsString = new string(capitalAsChars);
                            if (!capitalAsString.Contains('_'))
                            {
                                Console.WriteLine("Good job. You won!");
                                break;

                            }
                        }
                        else
                        {

                            Console.WriteLine("That letter isn't in that word!");

                            notInWordList[5 - lives] = guessLetter[0];




                            lives--;
                            Console.WriteLine("You've got " + lives + " lives");

                            if (lives != 0)
                            {
                                Console.WriteLine("Try again");
                            }
                            else
                            {
                                Console.WriteLine("Game over!");
                                Console.WriteLine("It was a capitol of " + country);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect value");
                    }
                }

                Console.WriteLine("Do you want to play again?");
                Console.WriteLine("Write YES to continue.");
                again = Console.ReadLine().ToUpper();

            } while (again == "YES");
        }
    }

}