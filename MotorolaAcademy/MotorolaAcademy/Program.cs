using System;

namespace MotorolaAcademy
{
    class Program
    {
        static void Main(string[] args)
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

            int lives = 5;
            Console.WriteLine("You've got " + lives + " lives");

            Console.WriteLine("Let's play!");
            Console.WriteLine("Do you want to guess a single letter or the whole word?");
            Console.WriteLine("Write LETTER or WORD to choose");

         
            string choose = Console.ReadLine().ToUpper();

            if (choose == "WORD")
            {
                Console.WriteLine("Guess the whole word:");
                while (lives > 0)
                {

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
            }
            else if (choose == "LETTER") 
            {
                Console.WriteLine("Guess a letter:");

                string guessLetter = Console.ReadLine().ToUpper();
                Console.WriteLine("You chose " + guessLetter);


                for (int i = 0; i < capital.Length; i++)

                {
                    Console.WriteLine(capital[i]);

                    if (guessLetter[0] == capital[i])
                    {
                        Console.WriteLine("That letter is in that word!");
                    }
                    else
                    {
                        Console.WriteLine("That letter isn't in that word!");

                    }
                }
            }
            else
            {
                Console.WriteLine("Incorrect value");
            }

        }
    }
}