using System;
using System.Diagnostics;
using System.Runtime;
using System.IO;


namespace MotorolaAcademy
{
    class Program
    {
        static void Main(string[] args)
        {

            string again = "NO";

            do
            {

                string[] lines = System.IO.File.ReadAllLines(@"C:\Users\kaerz\Documents\motorola-academy\countries_and_capitals.txt.txt");

                var random = new Random();
                int randomIndex = random.Next(0, lines.Length - 1); 

                string randomLine = lines[randomIndex];

                string[] words = randomLine.Split(" | ");
                string country = words[0].ToUpper();
                string capital = words[1].ToUpper();

                char[] capitalAsChars = capital.ToCharArray();
                Console.WriteLine(capitalAsChars);
                for (int i = 0; i < capitalAsChars.Length; i++)
                {
                    capitalAsChars[i] = '_';
                }

                Stopwatch sw = new Stopwatch();

                sw.Start();

               
                int lives = 5;
                int attemps = 0;
                bool success = false;
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
                                success = true;

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



                sw.Stop();

                Console.WriteLine("Time of play" + sw.Elapsed);
                Console.WriteLine("It took you " + attemps + " attemps");
      
                if (success == true)
                {
                    Console.WriteLine("What is your name?");
                    string name = Console.ReadLine();
                    string now = DateTime.Now.ToString();
                    long seconds = sw.ElapsedMilliseconds / 1000;

                    string score = name + " | " + now + " | " + seconds + " | " + capital;

                    using (System.IO.StreamWriter file =
                        new System.IO.StreamWriter(@"C:\Users\kaerz\Documents\motorola-academy\highscores.txt", true))
                    {
                        file.WriteLine(score);

                    }

                    Console.WriteLine("Score saved in file.");
                }

                Console.WriteLine("Do you want to play again?");

                Console.WriteLine("Write YES to continue.");
                again = Console.ReadLine().ToUpper();

            } while (again == "YES");
        }
    }

}