using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using scaling_pancake.Annotations;

namespace scaling_pancake
{
    public class MainPageViewModel: INotifyPropertyChanged
    {
        private string _loginPassword;
        private string _loginEmail;
        private string _userPassword;
        private string _userEmail;
        private string _userName;
        private DateTimeOffset _startDate = DateTimeOffset.Now;
        private DateTimeOffset _endDate = DateTimeOffset.Now;
        private Customer _loggedCustomer;
        private Home _selectedHome;
        private ObservableCollection<Home> _homes = HomeHandler.Homes;
        private ObservableCollection<Home> _bookingCart = BookingHandler.BookingCart;
        private int _selectedHomeID = -1;
        private ICommand _addCustomerCommand;
        private ICommand _loginCommand;
        private ICommand _logoutCommand;
        private ICommand _selectHomeCommand;
        private ICommand _addHomeToBookingCommand;
        private ICommand _saveBookingCommand;
        private ICommand _clearBookingCommand;

        public string UserName
        {
            get { return _userName; }
            set
            {
                if (value == _userName) return;
                _userName = value;
                OnPropertyChanged();
            }
        }
        public string UserEmail
        {
            get { return _userEmail; }
            set
            {
                if (value == _userEmail) return;
                _userEmail = value;
                OnPropertyChanged();
            }
        }
        public string UserPassword
        {
            get { return _userPassword; }
            set
            {
                if (value == _userPassword) return;
                _userPassword = value;
                OnPropertyChanged();
            }
        }
        public string LoginEmail
        {
            get { return _loginEmail; }
            set
            {
                if (value == _loginEmail) return;
                _loginEmail = value;
                OnPropertyChanged();
            }
        }
        public string LoginPassword
        {
            get { return _loginPassword; }
            set
            {
                if (value == _loginPassword) return;
                _loginPassword = value;
                OnPropertyChanged();
            }
        }
        public DateTimeOffset StartDate
        {
            get { return _startDate; }
            set
            {
                if (value.Equals(_startDate)) return;
                _startDate = value;
                OnPropertyChanged();
            }
        }
        public DateTimeOffset EndDate
        {
            get { return _endDate; }
            set
            {
                if (value.Equals(_endDate)) return;
                _endDate = value;
                OnPropertyChanged();
            }
        }
        public Customer LoggedCustomer
        {
            get { return _loggedCustomer; }
            set
            {
                if (Equals(value, _loggedCustomer)) return;
                _loggedCustomer = value;
                OnPropertyChanged();
            }
        }
        public Home SelectedHome
        {
            get { return _selectedHome; }
            set
            {
                if (Equals(value, _selectedHome)) return;
                _selectedHome = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Home> Homes
        {
            get { return _homes; }
            set
            {
                if (Equals(value, _homes)) return;
                _homes = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Home> BookingCart
        {
            get { return _bookingCart; }
            set
            {
                if (Equals(value, _bookingCart)) return;
                _bookingCart = value;
                OnPropertyChanged();
            }
        }
        public int SelectedHomeID
        {
            get { return _selectedHomeID; }
            set
            {
                if (value == _selectedHomeID) return;
                _selectedHomeID = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCustomerCommand
        {
            get
            {
                if (_addCustomerCommand == null)
                    _addCustomerCommand = new RelayCommand(AddCustomer);
                return _addCustomerCommand;
            }
            set { _addCustomerCommand = value; }
        }
        public ICommand LoginCommand
        {
            get
            {
                if (_loginCommand == null)
                    _loginCommand = new RelayCommand(Login);
                return _loginCommand;
            }
            set { _loginCommand = value; }
        }
        public ICommand LogoutCommand
        {
            get
            {
                if (_logoutCommand == null)
                    _logoutCommand = new RelayCommand(Logout);
                return _logoutCommand;
            }
            set { _logoutCommand = value; }
        }
        public ICommand SelectHomeCommand
        {
            get
            {
                if (_selectHomeCommand == null)
                    _selectHomeCommand = new RelayCommand(SelectHome);
                return _selectHomeCommand;
            }
            set { _selectHomeCommand = value; }
        }
        public ICommand AddHomeToBookingCommand
        {
            get
            {
                if (_addHomeToBookingCommand == null)
                    _addHomeToBookingCommand = new RelayCommand(AddHomeToBooking);
                return _addHomeToBookingCommand;
            }
            set { _addHomeToBookingCommand = value; }
        }
        public ICommand SaveBookingCommand
        {
            get
            {
                if (_saveBookingCommand == null)
                    _saveBookingCommand = new RelayCommand(SaveBooking);
                return _saveBookingCommand;
            }
            set { _saveBookingCommand = value; }
        }
        public ICommand ClearBookingCommand
        {
            get
            {
                if (_clearBookingCommand == null)
                    _clearBookingCommand = new RelayCommand(ClearBooking);
                return _clearBookingCommand;
            }
            set { _clearBookingCommand = value; }
        }

        public void AddCustomer()
        {
            CustomerHandler.AddCustomer(UserName, UserEmail, UserPassword);
            UserName = "";
            UserEmail = "";
            UserPassword = "";
            CustomerHandler.SaveCustomers();
        }

        public void Login()
        {
            CustomerHandler.Login(LoginEmail, LoginPassword);
            LoggedCustomer = CustomerHandler.LoggedCustomer;
        }

        public void Logout()
        {
            LoginEmail = "";
            LoginPassword = "";
            LoggedCustomer = null;
            CustomerHandler.Logout();
        }

        public void SelectHome()
        {
            HomeHandler.SelectedHome = HomeHandler.Homes[SelectedHomeID];
            SelectedHome = HomeHandler.SelectedHome;
        }

        public void AddHomeToBooking()
        {
            BookingHandler.AddHomeToSelectedBooking(SelectedHomeID, StartDate, EndDate);
        }

        public void SaveBooking()
        {
            BookingHandler.AddSelectedBooking();
            HomeHandler.SaveHomes();
            BookingHandler.SaveBookings();
        }

        public void ClearBooking()
        {
            BookingHandler.ClearBookingCart();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}