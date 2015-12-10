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
    }
}
