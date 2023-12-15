using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Call_logger
{

    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            ContentContainer.ContentTemplate = (DataTemplate)FindResource("On_Start");
            New_log.IsEnabled = true;
            Latest_log.IsEnabled = true;
            All_logs.IsEnabled = true;
            Users.IsEnabled = true;
            Delete_logs.IsEnabled = true;
            

        }
        private void New_log_Click(object sender, RoutedEventArgs e)
        {
            // Open page for new log
            ContentContainer.ContentTemplate = (DataTemplate)FindResource("New_log");

            // Disable other buttons
            Latest_log.IsEnabled = false;
            All_logs.IsEnabled = false;
            Users.IsEnabled = false;
            Delete_logs.IsEnabled = false;
            Home_Quit.Content = "Home";
        }

        private void Latest_log_Click(object sender, RoutedEventArgs e)
        {
            ContentContainer.ContentTemplate = (DataTemplate)FindResource("Latest_log");
            // Disable other buttons
            New_log.IsEnabled = false;
            All_logs.IsEnabled = false;
            Users.IsEnabled = false;
            Delete_logs.IsEnabled = false;
            Home_Quit.Content = "Home";
        }

        private void All_logs_Click(object sender, RoutedEventArgs e)
        {
            ContentContainer.ContentTemplate = (DataTemplate)FindResource("All_logs");
            // Disable other buttons
            Latest_log.IsEnabled = false;
            New_log.IsEnabled = false;
            Users.IsEnabled = false;
            Delete_logs.IsEnabled = false;
            Home_Quit.Content = "Home";
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            ContentContainer.ContentTemplate = (DataTemplate)FindResource("Users");
            // Disable other buttons
            Latest_log.IsEnabled = false;
            All_logs.IsEnabled = false;
            New_log.IsEnabled = false;
            Delete_logs.IsEnabled = false;
            Home_Quit.Content = "Home";
        }

        private void Delete_logs_Click(object sender, RoutedEventArgs e)
        {
            ContentContainer.ContentTemplate = (DataTemplate)FindResource("Delete_logs");
            // Disable other buttons
            Latest_log.IsEnabled = false;
            All_logs.IsEnabled = false;
            Users.IsEnabled = false;
            New_log.IsEnabled = false;
            Home_Quit.Content = "Home";
        }

        private void Home_Quit_Click(object sender, RoutedEventArgs e)
        {
            string cur = (string)Home_Quit.Content;
            if (cur == "Quit")
            {
                Application.Current.Shutdown();
            }
            else // Home
            {
                ContentContainer.ContentTemplate = (DataTemplate)FindResource("On_Start");
                New_log.IsEnabled = true;
                Latest_log.IsEnabled = true;
                All_logs.IsEnabled = true;
                Users.IsEnabled = true;
                Delete_logs.IsEnabled = true;
                Home_Quit.IsEnabled = true;
                Home_Quit.Content = "Quit";
            }
            
        }


      
    }
}