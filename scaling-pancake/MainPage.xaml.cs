using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace scaling_pancake
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        private readonly List<StackPanel> _bodyStackPanels;
        private readonly List<ToggleButton> _bodyToggleButtons;
        private readonly List<StackPanel> _homeStackPanels;
        private readonly List<ToggleButton> _homeMenuToggleButtons;
        private readonly List<StackPanel> _accountStackPanels;

        public MainPage()
        {
            InitializeComponent();

            _bodyStackPanels = new List<StackPanel> { spHome, spCreateUser, spUserAccount };
            _bodyToggleButtons = new List<ToggleButton> { tbCreateUser };
            _homeStackPanels = new List<StackPanel> { spHomes, spTrips, spSelectedHome };
            _homeMenuToggleButtons = new List<ToggleButton> { tbHomes, tbTrips };
            _accountStackPanels = new List<StackPanel> { spLogin, spAccount };

            // Add Homes here for now.
            HomeHandler.AddHome("qwe", 2, 42);
            HomeHandler.SaveHomes();

            CustomerHandler.AddCustomer("Dan", "Dan@", "1234");
            CustomerHandler.SaveCustomers();

            //CustomerHandler.LoadCustomers();
            //HomeHandler.LoadHomes();

            spCreateUser.Visibility = Visibility.Collapsed;
            spUserAccount.Visibility = Visibility.Collapsed;
            spTrips.Visibility = Visibility.Collapsed;
            spAccount.Visibility = Visibility.Collapsed;
            spSelectedHome.Visibility = Visibility.Collapsed;
            tbHomes.IsChecked = true;
        }

        private void ToggleMenu(ToggleButton toggleButton, StackPanel panel, List<StackPanel> stackPanels, List<ToggleButton> toggleButtons)
        {
            if (toggleButton != null)
            {
                toggleButton.IsChecked = true;
            }
            foreach (StackPanel stackPanel in stackPanels)
            {
                stackPanel.Visibility = Visibility.Collapsed;
            }
            if (toggleButtons != null)
                foreach (ToggleButton button in toggleButtons)
                {
                    if (button != toggleButton)
                    {
                        button.IsChecked = false;
                    }
                }
            panel.Visibility = Visibility.Visible;
        }

        private void bTitel_Click(object sender, RoutedEventArgs e)
        {
            ToggleMenu(null, spHome, _bodyStackPanels, _bodyToggleButtons);
        }

        private void tbCreateUser_OnClick(object sender, RoutedEventArgs e)
        {
            ToggleMenu(tbCreateUser, spCreateUser, _bodyStackPanels, _bodyToggleButtons);
        }

        private void tbHomes_Onclick(object sender, RoutedEventArgs e)
        {
            ToggleMenu(tbHomes, spHomes, _homeStackPanels, _homeMenuToggleButtons);
        }

        private void tbTrips_Onclick(object sender, RoutedEventArgs e)
        {
            ToggleMenu(tbTrips, spTrips, _homeStackPanels, _homeMenuToggleButtons);
        }

        private void bAccountName_Click(object sender, RoutedEventArgs e)
        {
            ToggleMenu(null, spUserAccount, _bodyStackPanels, _bodyToggleButtons);
        }

        private void bLogin_Click(object sender, RoutedEventArgs e)
        {
            // Need to check if (canLogin) { } something???
            ToggleMenu(null, spUserAccount, _bodyStackPanels, _bodyToggleButtons);
            ToggleMenu(null, spAccount, _accountStackPanels, null);
        }

        private void bLogout_Click(object sender, RoutedEventArgs e)
        {
            ToggleMenu(null, spLogin, _accountStackPanels, null);
            ToggleMenu(null, spHome, _bodyStackPanels, null);
        }

        private void LvHomes_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ToggleMenu(null, spSelectedHome, _homeStackPanels, _homeMenuToggleButtons);
        }

        private void tbBookHome_Click(object sender, RoutedEventArgs e)
        {
            // Not implemented yet.
        }

        private void bCheckoutBooking_OnClick(object sender, RoutedEventArgs e)
        {
            // Not implemented yet.
        }
    }
}
