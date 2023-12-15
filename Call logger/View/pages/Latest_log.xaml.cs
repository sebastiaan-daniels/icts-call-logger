using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using Call_logger.classes;

namespace Call_logger.View.pages
{
    /// <summary>
    /// Interaction logic for Latest_log.xaml
    /// </summary>
    public partial class Latest_log : UserControl
    {
        public Latest_log()
        {
            InitializeComponent();
            using (UserDataContext ctx = new UserDataContext())
            {
                var lastRow = ctx.Logs.OrderByDescending(log => log.Id).FirstOrDefault();
                if (lastRow != null)
                {
                    idNumber.Text = lastRow.Unumber;
                    description.Text = lastRow.Description;
                    Calltime.Text = lastRow.CallDuration;
                } else
                {
                    idNumber.Text = "Error";
                    description.Text = "There are no logs in the database at the moment";
                    Calltime.Text = "0";
                }
            }
        }
    }
}
