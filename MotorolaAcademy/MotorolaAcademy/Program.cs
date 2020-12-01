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
            string country = words[0];
            string capital = words[1];
            Console.WriteLine(country);
            Console.WriteLine(capital);

            string guess = Console.ReadLine();

            if (guess == capital)
            {
                Console.WriteLine("That's correct!");
            }
            else
            {
                Console.WriteLine("That's incorrect!");
            }






        }
    }
}