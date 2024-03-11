/*
* Author: Joshua Isidro
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
            Console.WriteLine("In order to provide the best medical care we will need information about yourself, please answer truthfully.");
            Console.WriteLine("");
            
            
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

            
            Console.Write("Gender (M/F/O): ");
            Gender = Console.ReadLine().ToUpper();

            
            string GenderDescription;
            switch (Gender)
            {
                case "M":
                    GenderDescription = "Male";
                    break;
                case "F":
                    GenderDescription = "Female";
                    break;
                case "O":
                    GenderDescription = "Other";
                    break;
                default:
                    GenderDescription = "Other not listed";
                    break;
            }

            
            Age = GetAge();
            Console.WriteLine($"Hello {First} {Last}, you are a {GenderDescription} and {Age} years old");
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
