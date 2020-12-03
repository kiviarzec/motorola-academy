using System;
using System.Diagnostics;


namespace MotorolaAcademy
{
    class Program
    {



        static string getRandomLine()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\kaerz\Documents\motorola-academy\countries_and_capitals.txt.txt");
            
            var random = new Random();
            int randomIndex = random.Next(0, lines.Length - 1);
            string randomLine = lines[randomIndex];

            return randomLine;
        }

        static char[] capitalToDashes(string capital)
        {
            char[] capitalAsChars = capital.ToCharArray();
            for (int i = 0; i < capitalAsChars.Length; i++)
            {
                capitalAsChars[i] = '_';
            }

            return capitalAsChars;
        }

        static void printUserData(char[] passwordAsChars, char[] notInWordLettersAsChars, int lives)
        {
            Console.WriteLine("You've got " + lives + " lives");

            Console.WriteLine("Capital to guess : ");
            Console.WriteLine(passwordAsChars);

            Console.WriteLine("Not in word list : ");
            Console.WriteLine(notInWordLettersAsChars);
            
        }

        static void saveScore(string capital, long seconds)
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            string now = DateTime.Now.ToString();

            string score = name + " | " + now + " | " + seconds + " | " + capital;

            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\kaerz\Documents\motorola-academy\highscores.txt", true))
            {
                file.WriteLine(score);

            }

            Console.WriteLine("Score saved in file.");
        }

        static void gameOver(string country)
        {
            Console.WriteLine("Game over!");
            Console.WriteLine("");
            Console.WriteLine("It was a capitol of " + country);
        }

        static void Main(string[] args)
        {

            string again = "NO";

            do
            {

                string randomLine = getRandomLine();

                string[] words = randomLine.Split(" | ");
                string country = words[0].ToUpper();
                string capital = words[1].ToUpper();

                char[] capitalAsChars = capitalToDashes(capital);
                Stopwatch sw = new Stopwatch();

                sw.Start();
                int lives = 5;
                int attemps = 0;
                bool success = false;
                char[] notInWordList = new char[] { '_', '_', '_', '_', '_' };

                Console.WriteLine("Let's play!");
                Console.WriteLine("");

                while (lives > 0)
                {


                    printUserData(capitalAsChars, notInWordList, lives);

                    Console.WriteLine("");
                    Console.WriteLine("Do you want to guess a single letter or the whole word?");
                    Console.WriteLine("Write LETTER or WORD to choose");


                    attemps++;

                    string choose = Console.ReadLine().ToUpper();

                    if (choose == "WORD")
                    {
                        Console.WriteLine("Guess the whole word:");
                        string guessWord = Console.ReadLine().ToUpper();

                        if (guessWord == capital)
                        {
                            Console.WriteLine("That's correct!");
                            success = true;

                            break;
                        }
                        else
                        {
                            Console.WriteLine("That's incorrect!");

                            if (lives >= 2)
                            {
                                lives = lives - 2;
                            }
                            else
                            {
                                lives--;                          
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
                                success = true;

                                break;

                            }
                        }
                        else
                        {

                            Console.WriteLine("That letter isn't in that word!");

                            notInWordList[5 - lives] = guessLetter[0];

                            lives--;


                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect value");
                    }

                    if (lives != 0)
                    {
                        Console.WriteLine("Try again");
                        Console.WriteLine("");
                    }
                    else
                    {
                        gameOver(country);
                    }
                }



                sw.Stop();
                long seconds = sw.ElapsedMilliseconds / 1000;
                Console.WriteLine("Time of play " + seconds + " seconds");
                Console.WriteLine("It took you " + attemps + " attemps");
      
                if (success == true)
                {
                    saveScore(capital, seconds);
                }

                Console.WriteLine("Do you want to play again?");

                Console.WriteLine("Write YES to continue.");
                again = Console.ReadLine().ToUpper();

            } while (again == "YES");
        }
    }

}