using System.Configuration;
using System.Data;
using System.Windows;
using CommunityToolkitApp01.Views;

namespace CommunityToolkitApp01
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainView main = new MainView();
            main.ShowDialog();
        }
    }

}
