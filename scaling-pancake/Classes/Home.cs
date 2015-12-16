using System;
using System.Collections.Generic;

namespace scaling_pancake
{
    public class Home
    {
        public static int Count;
        public int Id { get; set; }
        public string Address { get; set; }
        public int Rooms { get; set; }
        public int Sqm { get; set; }
        public List<Rental> Rentals { get; set; }

        public Home()
        {

        }

        public Home(string address, int rooms, int sqm)
        {
            InputChecker.NullOrEmptyChecker(address);
            InputChecker.NegativeNumberChecker(rooms);
            InputChecker.NegativeNumberChecker(sqm);

            Id = Count++;
            Address = address;
            Rooms = rooms;
            Sqm = sqm;
            Rentals = new List<Rental>();
        }
        
        public void NullChecker(string text)
        {
            if ( text == null )
            {
                throw new ArgumentNullException();
            }
        }

        public void NegativeNumChecker(int number)
        {
            if ( number < 1 )
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public override string ToString()
        {
            return $"Address: {Address}, Rooms: {Rooms}, Sq m: {Sqm}";
        }
    }
}