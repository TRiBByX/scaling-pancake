using System;

namespace scaling_pancake
{
    public class Flight
    {
        public static int Count;
        public int ID;
        private string _location;
        private string _destination;
        private DateTime _departure;
        private DateTime _arrival;

        public Flight()
        {

        }

        public Flight(string location, string destination, DateTime departure, DateTime arrival)
        {
            ID = Count++;
            _location = location;
            _destination = destination;
            _departure = departure;
            _arrival = arrival;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Location: {_location}, Destination: {_destination}, Departude: {_departure}, Arrival: {_arrival}";
        }
    }
}