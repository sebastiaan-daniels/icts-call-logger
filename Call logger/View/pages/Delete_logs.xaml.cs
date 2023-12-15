using System;
using System.Windows;
using System.Windows.Controls;
using Call_logger.classes;
using Microsoft.EntityFrameworkCore;

namespace Call_logger.View.pages
{
    /// <summary>
    /// Interaction logic for Delete_logs.xaml
    /// </summary>
    public partial class Delete_logs : UserControl
    {
        public Delete_logs()
        {
            InitializeComponent();
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            using (UserDataContext ctx = new UserDataContext())
            {
                try
                {
                    // Get all rows from your table
                    var allRows = ctx.Logs.ToList();

                    // Delete each row
                    foreach (var row in allRows)
                    {
                        ctx.Logs.Remove(row);
                    }

                    // Save changes to the database
                    ctx.SaveChanges();

                    MessageBox.Show("All rows deleted successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
        
    }
}
