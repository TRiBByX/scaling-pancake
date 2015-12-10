using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace scaling_pancake
{
    public class HomeHandler
    {
        private static string _fileName = "Homes.dat";
        public static ObservableCollection<Home> Homes { get; set; } = new ObservableCollection<Home>();
        public static Home SelectedHome = new Home();
        
        //sqm = square meters
        public static void AddHome(string address, int rooms, int sqm)
        {
            Homes.Add(new Home(address, rooms, sqm));
        }

        public static void RentHome(int homeID, Customer customer, DateTime startDate, DateTime endDate)
        {
            if (CustomerHandler.LoggedCustomer == null)
            {
                throw new NoLoggedCustomerException();
            }

            Rental tempRental = new Rental(customer.Id, startDate, endDate);

            foreach (Rental rental in Homes[homeID].Rentals)
            {
                if (tempRental.PeriodIsOverlapping(rental))
                {
                    throw new RentPeriodUnavailableException();
                }
            }
            Homes[homeID].Rentals.Add(tempRental);
        }

        public static void SaveHomes()
        {
            PersistenceFacade.SerializeObjectsFileAsync(JsonConvert.SerializeObject(Homes), _fileName);
        }

        public static async void LoadHomes()
        {
            ObservableCollection<Home> homes =
                       (ObservableCollection<Home>)
                           JsonConvert.DeserializeObject(await PersistenceFacade.DeSerializeObjectsFileAsync(_fileName),
                               typeof(ObservableCollection<Home>));
            Homes.Clear();
            foreach (Home home in homes)
            {
                Homes.Add(home);
                Home.Count++;
            }
        }
    }
}