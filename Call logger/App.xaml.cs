using System.Configuration;
using System.Data;
using System.Windows;
using Call_logger.classes;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Call_logger
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            DatabaseFacade facade = new DatabaseFacade(new UserDataContext());
            facade.EnsureCreated();
        }
    }

}
