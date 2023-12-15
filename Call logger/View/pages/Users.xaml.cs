using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Call_logger.classes;
using Microsoft.EntityFrameworkCore;

namespace Call_logger.View.pages
{

    public partial class Users : UserControl
    {
        public string[]? UnumsArray { get; private set; }

        public Users()
        {
            InitializeComponent();
            using (UserDataContext ctx = new UserDataContext())
            {
                var allRows = ctx.Users.ToList();
                UnumsArray = allRows.Select(user => user.Unumber).ToArray();

            }
            DataContext = this;
        }

        private void UserList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UserList.SelectedItem != null)
            {
                // enable views
                UserNotFound.Visibility = Visibility.Hidden;
                // display infoboxes
                t1.Visibility = Visibility.Visible;
                t2.Visibility = Visibility.Visible;
                t3.Visibility = Visibility.Visible;
                t4.Visibility = Visibility.Visible;

                type.Visibility = Visibility.Visible;
                firstname.Visibility = Visibility.Visible;
                lastname.Visibility = Visibility.Visible;
                status.Visibility = Visibility.Visible;
                // Access the selected item
                var selectedOption = UserList.SelectedItem.ToString();

                // Use the selectedOption as needed
                var user = fetch_user(selectedOption);

                if (user != null) // make sure user exists
                {
                    // u/r/b number
                    char firstChar = user.Unumber[0];
                    if (firstChar == 'b')
                    {
                        type.Text = "Own account";
                    }
                    else if (firstChar == 'r')
                    {
                        type.Text = "Student";
                    }
                    else if (firstChar == 'u')
                    {
                        type.Text = "colleague";
                    }
                    else { type.Text = "Unknown type"; }

                    // firstname
                    firstname.Text = user.FirstName;
                    // lastname
                    lastname.Text = user.LastName;
                    // payment status
                    if (user.PaymentStatus == false)
                    {
                        status.Text = "Unpaid invoices";
                        status.Foreground = new SolidColorBrush(Colors.Red);
                    }
                    else
                    {
                        status.Text = "All invoices paid";
                        status.Foreground = new SolidColorBrush(Colors.Green);
                    }

                }
            } else
            {
                UserNotFound.Visibility = Visibility.Visible;
                t1.Visibility = Visibility.Hidden;
                t2.Visibility = Visibility.Hidden;
                t3.Visibility = Visibility.Hidden;
                t4.Visibility = Visibility.Hidden;

                type.Visibility = Visibility.Hidden;
                firstname.Visibility = Visibility.Hidden;
                lastname.Visibility = Visibility.Hidden;
                status.Visibility = Visibility.Hidden;
            }
        }

        private User fetch_user(string unumber)
        {
            using (UserDataContext ctx = new UserDataContext())
            {
                var user = ctx.Users.FirstOrDefault(user => user.Unumber == unumber);
                if (user != null)
                {
                    return user;
                }
                return null; // Return null when no user is found
            }
        }
    }
}
