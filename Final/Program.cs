/*
 *Author: Joshua Isidro
 * Purpose: Code for final
 * Course: COMP003A
 */

using System;
using System.Text.RegularExpressions;

namespace Final
{
    internal class Program
    {
        static string First, Last, Gender;
        static int Age;

        static void Main(string[] args)
        {
            Console.WriteLine("New Patient Form");
            Console.WriteLine("In order to provide the best medical care we will need information about yourself, please answer truthfully");
            Console.WriteLine("");
            Info();
            Console.WriteLine($"Hello {First} {Last}, you chose {Gender} as your gender and you are {Age} years old");
        }

        static void Info()
        {
            do
            {
                Console.Write("First Name: ");
                First = Console.ReadLine();
            } while (!Letters(First));

            do
            {
                Console.Write("Last Name: ");
                Last = Console.ReadLine();
            } while (!Letters(Last));

            do
            {
                Console.Write("Gender (M/F/O): ");
                Gender = Console.ReadLine().ToUpper();
            } while (Gender != "M" && Gender != "F" && Gender != "O");

            Age = GetAge();
        }

        static bool Letters(string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z]+$");
        }

        static int GetAge()
        {
            int age;
            do
            {
                Console.Write("What year were you born? ");
            } while (!int.TryParse(Console.ReadLine(), out age) || age < 1900 || age > DateTime.Now.Year);

            return DateTime.Now.Year - age;
        }
    }
}