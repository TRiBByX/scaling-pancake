using System;

namespace scaling_pancake
{
    public class Rental
    {
        private DateTime _startDate;
        private DateTime _endDate;

        public int CustomerID { get; set; }
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = new DateTime(value.Year, value.Month, value.Day, 15, 0, 0); }
        }
        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = new DateTime(value.Year, value.Month, value.Day, 11, 0, 0); }
        }

        public Rental()
        {
            
        }

        public Rental(int customerID, DateTime startDate, DateTime endDate)
        {
            CustomerID = customerID;
            StartDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, 15, 0, 0);
            EndDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, 11, 0, 0);
        }

        public bool PeriodIsOverlapping(Rental rental)
        {
            return StartDate > rental.StartDate && StartDate < rental.EndDate ||
                   EndDate > rental.StartDate && EndDate < rental.EndDate ||
                   StartDate < rental.StartDate && EndDate > rental.EndDate;
        }
    }
}