using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfBasicApp01.ViewModels;

namespace WpfBasicApp01
{
    public class Bootstrapper :BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override async void OnStartup(object sender, StartupEventArgs e)
        {
            // base.OnStartup(sender, e);
            // App.xaml의 StartupUri와 동일한 일을 수행
            // MainViewModel과 동일한 이름의 View를 찾아서 바인딩 후 실행
            await DisplayRootViewForAsync<MainViewModel>();
        }
    }
}
