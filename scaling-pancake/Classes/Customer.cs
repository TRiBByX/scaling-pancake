using System.Collections.Generic;

namespace scaling_pancake
{
    public class Customer
    {
        public static int Count;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<int> BookingIDs { get; set; } 

        public Customer()
        {

        }

        public Customer(string name, string email, string password)
        {
            InputChecker.NullChecker(name);
            InputChecker.NullChecker(email);
            InputChecker.NullChecker(password);

            Id = Count++;
            Name = name;
            Email = email;
            Password = password;
            BookingIDs = new List<int>();
        }

        public override string ToString()
        {
            return $"Name: {Name}, Email: {Email}, Password: {Password}";
        }
    }
}