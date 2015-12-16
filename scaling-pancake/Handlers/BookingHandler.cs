using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace scaling_pancake
{
    public class BookingHandler
    {
        private static string _fileName = "Bookings.dat";
        public static ObservableCollection<Booking> Bookings { get; set; } = new ObservableCollection<Booking>();
        public static ObservableCollection<Home> BookingCart { get; set; } = new ObservableCollection<Home>();
        public static Booking SelectedBooking = new Booking();

        public static void AddSelectedBooking()
        {
            Bookings.Add(SelectedBooking);
        }

        public static void AddHomeToSelectedBooking(int homeID, DateTimeOffset startDate, DateTimeOffset endDate)
        {
            if (CustomerHandler.LoggedCustomer == null)
            {
                throw new NoLoggedCustomerException();
            }
            SelectedBooking = new Booking(CustomerHandler.LoggedCustomer.Id);
            HomeHandler.RentHome(homeID, CustomerHandler.LoggedCustomer,
                new DateTime(startDate.Year, startDate.Month, startDate.Day),
                new DateTime(endDate.Year, endDate.Month, endDate.Day));
            SelectedBooking.AddHome(HomeHandler.SelectedHome);
            BookingCart.Add(HomeHandler.SelectedHome);
        }
        
        public static void ClearBookingCart()
        {
            BookingCart.Clear();
            SelectedBooking = new Booking();
        }

        public static void SaveBookings()
        {
            PersistenceFacade.SerializeObjectsFileAsync(JsonConvert.SerializeObject(Bookings), _fileName);
        }

        public static async void LoadBookings()
        {
            ObservableCollection<Booking> bookings =
                       (ObservableCollection<Booking>)
                           JsonConvert.DeserializeObject(await PersistenceFacade.DeSerializeObjectsFileAsync(_fileName),
                               typeof(ObservableCollection<Booking>));
            Bookings.Clear();
            foreach (Booking booking in bookings)
            {
                Bookings.Add(booking);
                Booking.Count++;
            }
        }
    }
}