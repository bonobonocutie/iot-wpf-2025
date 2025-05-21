using System.Windows;
using System.Windows.Input;
using WpfSmartHomeApp.Helpers;
using WpfSmartHomeApp.ViewModels;

namespace WpfSmartHomeApp.views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Common.LOGGER.Info("스마트홈 모니터링 앱 종료");
            Application.Current.Shutdown();
        }

        private void window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // 제목표시줄 X버튼 누를때, Alt+F4 누를 때 발생하는 이벤트
            e.Cancel = true; // 앱종료 막는 기능
        }

        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            if(DataContext is MainViewModel vm)
            {
                vm.LoadedCommand.Execute(null);
            }
        }
    }
}