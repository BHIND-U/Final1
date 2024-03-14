/*
* Author: Joshua Isidro
* Purpose: Code for final
* Course: COMP003A
*/
using System.Text.RegularExpressions;

namespace Final
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("New Patient Form");
            Console.WriteLine("");
            Console.WriteLine("In order to provide the best medical care we will need information about yourself, please answer truthfully.");
            Console.WriteLine("");

            string firstName = GetValidName("First Name");
            string lastName = GetValidName("Last Name");

            string gender = GetValidGender();

            string genderDescription = GetGenderDescription(gender);

            int age = GetAge();
            Console.WriteLine("");

            Console.WriteLine($"Hello {firstName} {lastName}, you are a {genderDescription} and {age} years old");

            List<string> questions = new List<string>
            {
                "1.  How often do you exercise?",
                "2.  Are you allergic to any medications?",
                "3.  When was your last physical?",
                "4.  Do you eat fruits and vegtables regularly(5-7 times a week)?",
                "5.  Do you have any concerns about your health?",
                "6.  Do you smoke? If so how many days of the week?",
                "7.  Do you drink? If so how many days of the week?",
                "8.  Are you currently taking any type of medication?",
                "9.  Does your family have a history of hereditary diseases? If so please list them.",
                "10. On average what is your screen time?"
            };

            Console.WriteLine("");
            Ask(questions);
        }

        /// <summary>
        /// Gets names but runs it through "ValidName" to ensure it is an actual answer,
        /// it then returns the name inputed. 
        /// </summary>
        /// <param name="names"></param>
        /// <returns></returns>
        static string GetValidName(string names)
        {
            string name;
            do
            {
                Console.Write($"{names}: ");
                name = Console.ReadLine();
                Console.WriteLine("");
            } while (!ValidName(name));

            return name;
        }

        /// <summary>
        /// bool to make sure the name is not left unanswered and does not contain numbers nor symbols.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        static bool ValidName(string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Z]+$");
        }

        /// <summary>
        /// Requests an input of only "m/f/o", if lowercase it will automatically convert it to uppercase.
        /// If the input is not correct, it returns an error message. 
        /// </summary>
        /// <returns></returns>
        static string GetValidGender()
        {
            string gender;
            bool ValidGender;
            do
            {
                Console.Write("Gender (M/F/O): ");
                gender = Console.ReadLine().ToUpper();
                Console.WriteLine("");
                ValidGender = gender == "M" || gender == "F" || gender == "O";
                if (!ValidGender)
                {
                    Console.WriteLine("Invalid input. Please enter M, F, or O.");
                }
            } while (!ValidGender);

            return gender;
        }

        /// <summary>
        /// switch to convert the input value of "gender" to an actual word instead of showing a letter. 
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        static string GetGenderDescription(string gender)
        {
            switch (gender)
            {
                case "M":
                    return "Male";
                case "F":
                    return "Female";
                case "O":
                    return "Other";
                default:
                    return "";
            }
        }

        /// <summary>
        /// Requests for a birth year, cannot be less than 1900 or greater than current year or letters, 
        /// it then substracts current year from input. 
        /// </summary>
        /// <returns></returns>
        static int GetAge()
        {
            int birthYear;
            do
            {
                Console.Write("What year were you born? ");
            } while (!int.TryParse(Console.ReadLine(), out birthYear) || birthYear < 1900 || birthYear > DateTime.Now.Year);

            return DateTime.Now.Year - birthYear;
            
        }

        /// <summary>
        /// Asks questions from list one by one
        /// </summary>
        /// <param name="questions"></param>
        static void Ask(List<string> questions)
        {
            foreach (string question in questions)
            {
                Console.Write(question);
                string answer = Console.ReadLine();
                Console.WriteLine("");
            }
        }
    }
}

