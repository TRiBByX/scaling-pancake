using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scaling_pancake
{
    public static class InputChecker
    {
        public static void NullChecker(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException();
            } 
        }

        public static void NegativeNumberChecker(int input)
        {
            if (input > 1)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public static void DateChecker(DateTime time1, DateTime time2)
        {
            if (time2 < time1)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public static void EmailContainsATChecker(string input)
        {
            if (!input.Contains("@"))
            {
                throw new ArgumentOutOfRangeException("Your email has to contain @");
            }
        }

        public static void EmailContainsDotChecker(string input)
        {
            string[] words = input.Split('@');

            if (!words[1].Contains("."))
            {
                throw new ArgumentException("Your email has to contain a .'whatever' ending");
            }
        }

        public static void PasswordContainsChecker(string input)
        {
            if (input.Length < 6)
            {
                throw new ArgumentOutOfRangeException("Your password has to be at least 6 characters long");
            }
        }

        public static void IsUsernameTaken(List<Customer> customers, string email)
        {
            foreach (Customer customer in customers)
            {
                if (customer.Email == email)
                {
                    throw new ArgumentException("Email already used, please enter a valid email");
                }
            }
        }
    }
}
