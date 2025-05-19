using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfSmartHomeApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {

        private double _homeTemp;
        public double HomeTemp
        {
            get => _homeTemp;
            set => SetProperty(ref _homeTemp, value);
        }

        private double _homeHumid;
        public double HomeHumid
        {
            get => _homeHumid;
            set => SetProperty(ref _homeHumid, value);
        }

        // 사람인지
        private string _detectResult;
        public string DetectResult
        {
            get => _detectResult;
            set => SetProperty(ref _detectResult, value);
        }

        // 사람인지 여부
        private Boolean _isDetectOn;
        public Boolean IsDetectOn
        {
            get => _isDetectOn;
            set => SetProperty(ref _isDetectOn, value);
        }

        private string _rainResult;
        public string RainResult
        {
            get => _rainResult;
            set => SetProperty(ref _rainResult, value);
        }

        private Boolean _isRainOn;
        public Boolean IsRainOn
        {
            get => _isRainOn;
            set => SetProperty(ref _isRainOn, value);
        }

        private string _airConResult;
        public string AirConResult
        {
            get => _airConResult;
            set => SetProperty(ref _airConResult, value);
        }

        private Boolean _isAirConOn;
        public Boolean IsAirConOn
        {
            get => _isAirConOn;
            set => SetProperty(ref _isAirConOn, value);
        }

        private string _lightResult;
        public string LightResult
        {
            get => _lightResult;
            set => SetProperty(ref _lightResult, value);
        }

        // 사람인지 여부
        private Boolean _isLightOn;
        public Boolean IsLightOn
        {
            get => _isLightOn;
            set => SetProperty(ref _isLightOn, value);
        }

        // LoadedCommand에서 앞에 On이 붙고 Command는 삭제
        [RelayCommand]
        public void OnLoaded()
        {
            HomeTemp = 30;
            HomeHumid = 43.2;

            DetectResult = "Detected Human!";
            IsDetectOn = true;
            RainResult = "Raining";
            IsRainOn = true;
            AirConResult = "Aircon On!";
            IsAirConOn = true;
            LightResult = "Light On~";
            IsLightOn = true;
        }
    }
}
