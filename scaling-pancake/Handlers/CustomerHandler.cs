using System.Collections.Generic;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;
using Newtonsoft.Json;

namespace scaling_pancake
{
    public class CustomerHandler
    {
        private static string _fileName = "Customers.dat";
        public static List<Customer> Customers = new List<Customer>();
        public static Customer LoggedCustomer;

        public static void AddCustomer(string name, string email, string password)
        {
            InputChecker.IsUsernameTaken(Customers, email);
            InputChecker.EmailContainsATChecker(email);
            InputChecker.EmailContainsDotChecker(email);
            InputChecker.PasswordContainsChecker(password);

            Customers.Add(new Customer(name, email, ComputeMd5(password)));
        }

        public static void Login(string email, string password)
        {
            foreach (Customer customer in Customers)
            {
                if (email == customer.Email && ComputeMd5(password) == customer.Password)
                {
                    LoggedCustomer = customer;
                }
            }
        }

        public static void Logout()
        {
            LoggedCustomer = null;
        }

        private static string ComputeMd5(string password)
        {
            HashAlgorithmProvider alg = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Md5);
            IBuffer buff = CryptographicBuffer.ConvertStringToBinary(password, BinaryStringEncoding.Utf8);
            return CryptographicBuffer.EncodeToHexString(alg.HashData(buff));
        }

        public static void SaveCustomers()
        {
            PersistenceFacade.SerializeObjectsFileAsync(JsonConvert.SerializeObject(Customers), _fileName);
        }

        public static async void LoadCustomers()
        {
            List<Customer> customers =
                (List<Customer>)
                    JsonConvert.DeserializeObject(await PersistenceFacade.DeSerializeObjectsFileAsync(_fileName),
                        typeof(List<Customer>));
            Customers.Clear();
            foreach (Customer customer in customers)
            {
                Customers.Add(customer);
                Customer.Count++;
            }
        }
    }
}