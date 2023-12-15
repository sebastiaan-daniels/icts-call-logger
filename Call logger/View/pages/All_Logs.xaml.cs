using Call_logger.classes;
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

namespace Call_logger.View.pages
{
    public partial class All_Logs : UserControl
    {
        public int[]? IdArray { get; private set; }
        public All_Logs()
        {
            InitializeComponent();
            using (UserDataContext ctx = new UserDataContext())
            {
                var allRows = ctx.Logs.ToList();
                IdArray = allRows.Select(user => user.Id).ToArray();

            }
            DataContext = this;
        }

        private void UserList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UserList.SelectedItem != null)
            {
                // Access the selected item
                var selectedOption = UserList.SelectedItem.ToString();

                // Use the selectedOption as needed
                var log = fetch_log(int.Parse(selectedOption));

                // enable views
                UserNotFound.Visibility = Visibility.Hidden;
                unumtext.Visibility = Visibility.Visible;
                idNumber.Visibility = Visibility.Visible;
                desctext.Visibility = Visibility.Visible;
                description.Visibility = Visibility.Visible;
                Calltimetext.Visibility = Visibility.Visible;
                Calltime.Visibility = Visibility.Visible;

                // populate views
                idNumber.Text = log.Unumber;
                description.Text = log.Description;
                Calltime.Text = log.CallDuration;

            } else
            {
                // disable views
                UserNotFound.Visibility = Visibility.Visible;
                unumtext.Visibility = Visibility.Hidden;
                idNumber.Visibility = Visibility.Hidden;
                desctext.Visibility = Visibility.Hidden;
                description.Visibility = Visibility.Hidden;
                Calltimetext.Visibility = Visibility.Hidden;
                Calltime.Visibility = Visibility.Hidden;
            }
        }

        private Log fetch_log(int Id)
        {
            using (UserDataContext ctx = new UserDataContext())
            {
                var log = ctx.Logs.FirstOrDefault(log => log.Id == Id);
                if (log != null)
                {
                    return log;
                }
                return null; // Return null when no user is found
            }
        }
    }
}
