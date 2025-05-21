using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MQTTnet;
using Newtonsoft.Json;
using System.Windows.Threading;
using WpfSmartHomeApp.Helpers;
using WpfSmartHomeApp.Models;

namespace WpfSmartHomeApp.ViewModels
{
    public partial class MainViewModel : ObservableObject, IDisposable
    {

        // readonly는 생성자에서만 값을 할당. 그외는 불가
        private readonly DispatcherTimer _timer;
        public MainViewModel()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += (sender, e) =>
            {
                CurrDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            };
            _timer.Start();
        }

        // 온도 속성
        private double _homeTemp;
        public double HomeTemp
        {
            get => _homeTemp;
            set => SetProperty(ref _homeTemp, value);
        }

        // 습도 속성
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
        private bool _isDetectOn;
        public bool IsDetectOn
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

        private bool _isRainOn;
        public bool IsRainOn
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

        private bool _isAirConOn;
        public bool IsAirConOn
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
        private bool _isLightOn;
        public bool IsLightOn
        {
            get => _isLightOn;
            set => SetProperty(ref _isLightOn, value);
        }

        private string TOPIC;
        private string BROKERHOST;
        private string _currDateTime;
        private IMqttClient mqttClient;

        public string CurrDateTime
        {
            get => _currDateTime;
            set => SetProperty(ref _currDateTime, value);
        }
        public IMqttClient MqttClient { get; private set; }


        // LoadedCommand에서 앞에 On이 붙고 Command는 삭제
        [RelayCommand]
        public async Task OnLoaded()
        {
            //HomeTemp = 30;
            //HomeHumid = 43.2;

            //DetectResult = "Detected Human!";
            //IsDetectOn = true;
            //RainResult = "Raining";
            //IsRainOn = true;
            //AirConResult = "Aircon On!";
            //IsAirConOn = true;
            //LightResult = "Light On~";
            //IsLightOn = true;

            // MQTT 접속부터 실행까지
            TOPIC = "pknu/sh01/data";
            BROKERHOST = "210.119.12.52"; // SmartHome MQTT Broker IP

            var mqttFactory = new MqttClientFactory();
            mqttClient = mqttFactory.CreateMqttClient();

            // MQTT 클라이언트 접속 설정변수
            var mqttClientOptions = new MqttClientOptionsBuilder()
                .WithTcpServer(BROKERHOST)
                .WithCleanSession(true)
                .Build();

            // MQTT 접속 후 이벤트처리 메서드 선언
            mqttClient.ConnectedAsync += MqttClient_ConnectedAsync;

            // MQTT 구독메세지 확인 메서드 선언
            mqttClient.ApplicationMessageReceivedAsync += MqttClient_ApplicationMessageReceivedAsync;

            await mqttClient.ConnectAsync(mqttClientOptions); // MQTT 브로커에 접속
        }

        // MQTT 구독메세지 확인 메서드
        private Task MqttClient_ApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs arg)
        {
            var topic = arg.ApplicationMessage.Topic; // pknu//sh01/data
            var payload = arg.ApplicationMessage.ConvertPayloadToString(); // byte -> UTF-8 문자열로 변환

            var data = JsonConvert.DeserializeObject<SensingInfo>(payload);

            HomeTemp = data.T;
            HomeHumid = data.H;

            IsDetectOn = data.V == "ON" ? true : false;
            DetectResult = data.V == "ON" ? "Detection State" : "Normal State";

            IsLightOn = data.RL == "ON" ? true : false;
            LightResult = data.RL == "ON" ? "Light On" : "Light Off";

            IsAirConOn = data.F == "ON" ? true : false;
            AirConResult = data.F == "On" ? "Aircon On" : "Aircon Off";

            IsRainOn = data.R <= 300 ? true : false;
            RainResult = data.R <= 300 ? "Raining" : "No Rain";

            return Task.CompletedTask;  // 구독이 종료됨을 알려주는 리턴문
        }

        // MQTT 접속 후 이벤트처리 메서드
        private async Task MqttClient_ConnectedAsync(MqttClientConnectedEventArgs arg)
        {
            Common.LOGGER.Info($"{arg}");
            Common.LOGGER.Info("MQTT Broker ");
            //연결이후 SubscribeAsync 구독 시작
            await mqttClient.SubscribeAsync(TOPIC);
        }

        public void Dispose()
        {
            // TODO : 나중에 리소스 해제처리 필요
        }
    }
}
