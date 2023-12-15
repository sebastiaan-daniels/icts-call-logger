using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Call_logger;
using Call_logger.classes;

namespace Call_logger.View.pages
{
    // Items we know about the user:
    // Firstname, lastname, type, payment_status
    public partial class New_log : UserControl
    {
        private DateTime startTime;
        public New_log()
        {
            InitializeComponent();
        }

        private void idNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            startTime = DateTime.Now; // vanaf dat het laatste character is ingegeven van het id
            // Check for validity of user existance
            if (user_exists(idNumber.Text)) {
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

                // information itself
                var user = fetch_user(idNumber.Text);

                if (user != null) // make sure user exists
                {
                    // u/r/b number
                    char firstChar = user.Unumber[0];
                    if ( firstChar == 'b')
                    {
                        type.Text = "Own account";
                    } else if ( firstChar == 'r') {
                        type.Text = "Student";
                    } else if (firstChar == 'u')
                    {
                        type.Text = "colleague";
                    } else { type.Text = "Unknown type"; }

                    // firstname
                    firstname.Text = user.FirstName;
                    // lastname
                    lastname.Text = user.LastName;
                    // payment status
                    if (user.PaymentStatus == false)
                    {
                        status.Text = "Unpaid invoices";
                        status.Foreground = new SolidColorBrush(Colors.Red);
                    } else
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

        private void description_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Code to handle dissapearance of preview
            if (string.IsNullOrEmpty(description.Text))
            {
                descText.Visibility = Visibility.Visible;
            }
            else
            {
                descText.Visibility = Visibility.Hidden;
            }

        }

        private bool user_exists(string obj)
        {
            // Code to handle dissapearance of preview
            using (UserDataContext ctx = new UserDataContext())
            {
                bool exists = ctx.Users.Any(user => user.Unumber == obj);
                if (exists)
                {
                    return true;
                }
                return false;
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
        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(idNumber.Text) || string.IsNullOrEmpty(description.Text))
            {
                MessageBox.Show("u/r/b-number and describtion must be filled in");
                return;
            }
            DateTime endTime = DateTime.Now;
            TimeSpan duration = endTime - startTime;
            string formattedDuration = $"{(int)duration.TotalHours:D2}:{duration.Minutes:D2}:{duration.Seconds:D2}";

            using (UserDataContext ctx = new UserDataContext())
            {
                Log newLog = new Log
                {
                    Unumber = idNumber.Text,
                    Description = description.Text,
                    CallDuration = formattedDuration
                };
                ctx.Logs.Add(newLog);
                ctx.SaveChanges();
            }

            // Set everything to be emtpy again
            idNumber.Text = string.Empty;
            description.Text = string.Empty;

            // display success message
            MessageBox.Show("Call successfully logged");


        }
    }
}
