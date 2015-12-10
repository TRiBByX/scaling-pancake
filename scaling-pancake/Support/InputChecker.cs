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
                throw new ArgumentOutOfRangeException("Your email has to contain a .'whatever' ending");
            }
        }

        public static void PasswordContainsChecker(string input)
        {
            if (!input.Any(c => char.IsUpper(c)) && !input.Any(c => char.IsDigit(c)))
            {
                throw new ArgumentException("Your passphrase has to have at least one uppercase letter and one number");
            }
        }
    }
}
