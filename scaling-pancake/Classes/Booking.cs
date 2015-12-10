using System;
using System.Collections.Generic;
using System.Threading;

namespace scaling_pancake
{
    public class Booking
    {
        public static int Count;
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public List<int> HomeIDs { get; set; }

        public Booking()
        {

        }

        public Booking(int customerID)
        {
            ID = Count++;
            CustomerID = customerID;
            HomeIDs = new List<int>();
        }

        public void AddHome(Home home)
        {
            HomeIDs.Add(home.Id);
        }

        public override string ToString()
        {
            return $"ID: {ID} CustomerID: {CustomerID}";
        }
    }
}