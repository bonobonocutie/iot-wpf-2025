﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MahApps.Metro.Controls.Dialogs;
using MQTTnet;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;
using System.Windows.Threading;
using WpfMqttSubApp.Models;

namespace WpfMqttSubApp.ViewModels
{
    public partial class MainViewModel : ObservableObject, IDisposable
    {
        private readonly IDialogCoordinator dialogCoordinator;
        private readonly string TOPIC;
        private string _brokerHost;
        private string _databaseHost;
        private IMqttClient mqttClient;
        private string _logText;
        private int counter = 1;
        private DispatcherTimer timer;
        private int lineCounter = 1;
        private string connString = string.Empty;
        private MySqlConnection connection;

        // 속성 BrokerHost, DatabaseHost
        // 메서드 ConnectBrokerCommand, ConnectDatabaseCommand

        public MainViewModel(IDialogCoordinator coordinator)
        {
            this.dialogCoordinator = coordinator;

            BrokerHost = "210.119.12.52";
            DatabaseHost = "210.119.12.73";
            //TOPIC = "smarthome/73/topic";
            TOPIC = "pknu/sh01/data";

            connection = new MySqlConnection();  // 예외처리용

            //RichTextBox 테스트용
            //timer = new DispatcherTimer();
            //timer.Interval = TimeSpan.FromSeconds(1);
            //timer.Tick += (sender, e) =>
            //{
            //    // RichTextBox 추가 내용
            //    LogText += $"Log[{DateTime.Now:HH:mm:ss}] - {counter++}\n";
            //    Debug.WriteLine($"Log[{DateTime.Now:HH:mm:ss}] - {counter++}");
            //};
            //timer.Start();
        }

        public string LogText
        {
            get => _logText;
            set => SetProperty(ref _logText, value);

        }

        public string BrokerHost
        {
            get => _brokerHost;
            set => SetProperty(ref _brokerHost, value);
        }

        public string DatabaseHost
        {
            get => _databaseHost;
            set => SetProperty(ref _databaseHost, value);
        }


        private async Task ConnectMqttBroker()
        {
            // MQTT 클라이언트 생성
            var mqttFactory = new MqttClientFactory();
            mqttClient = mqttFactory.CreateMqttClient();


            // MQTT 클라이언트접속 설정
            var mqttClientOptions = new MqttClientOptionsBuilder()
                .WithTcpServer(BrokerHost)
                .WithCleanSession(true)
                .Build();

            // MQTT 접속 후 이벤트처리
            mqttClient.ConnectedAsync += async e =>
            {
                LogText += "MQTT 브로커 접속성공!\n";

                // 연결 이후 구독(Subscribe)
                await mqttClient.SubscribeAsync(TOPIC);
            };

            // MQTT 구독메시지 로그출력
            mqttClient.ApplicationMessageReceivedAsync += e =>
            {
                var topic = e.ApplicationMessage.Topic;
                var payload = e.ApplicationMessage.ConvertPayloadToString(); // byte 데이터를 UTF-8 문자열로

                // json으로 변경
                var data = JsonConvert.DeserializeObject<SensingInfo>(payload);
                Debug.WriteLine($"{data.L} / {data.R} / {data.T} / {data.H}");
                //LogText += $"L:{data.L}, R:{data.R}, T:{data.T}, H:{data.H}, F:{data.F}, V:{data.V}, RL:{data.RL}, CB:{data.CB}\n";

                SaveSensingData(data);

                LogText += $"LINENUMBER : {lineCounter++}\n";
                LogText += $"{payload}\n";

                return Task.CompletedTask;
            };

            await mqttClient.ConnectAsync(mqttClientOptions); // MQTT 서버에 접속
        }

        // DB저장 메서드
        private async Task SaveSensingData(SensingInfo data)
        {
            string query = @"INSERT INTO sensingdatas
                            (sensing_dt, light, rain, temp, humid, fan, vul, real_light, chaim_bell)
                            VALUES
                            (now(), @light, @rain, @temp, @humid, @fan, @vul, @real_light, @chaim_bell);";

            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    using var cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@light", data.L);
                    cmd.Parameters.AddWithValue("@rain", data.R);
                    cmd.Parameters.AddWithValue("@temp", data.T);
                    cmd.Parameters.AddWithValue("@humid", data.H);
                    cmd.Parameters.AddWithValue("@fan", data.F);
                    cmd.Parameters.AddWithValue("@vul", data.V);
                    cmd.Parameters.AddWithValue("@real_light", data.RL);
                    cmd.Parameters.AddWithValue("@chaim_bell", data.CB);

                    await cmd.ExecuteNonQueryAsync(); // 이전까지는 cmd.ExecuteNonQuery()
                }
            }
            catch(Exception ex)
            {
                // TODO
            }
        }

        private async Task ConnectDatabaseServer()
        {
            try
            {
                connection = new MySqlConnection(connString);
                connection.Open();
                LogText += $"{DatabaseHost} DB서버 접속성공! {connection.State}\n";
            }
            catch (Exception ex)
            {
                LogText += $"{DatabaseHost} DB서버 접속실패 : {ex.Message}\n";
            }
        }

        [RelayCommand]
        public async Task ConnectBroker()
        {
            if (string.IsNullOrEmpty(BrokerHost))
            {
                await this.dialogCoordinator.ShowMessageAsync(this, "브로커연결","브로커호스트를 입력하세요");
                return;
            }

            // MMQT브로커에 접속해서 데이터를 가져오기
            await ConnectMqttBroker();
        }

        [RelayCommand]
        public async Task ConnectDatabase()
        {
            if (string.IsNullOrEmpty(DatabaseHost))
            {
                await this.dialogCoordinator.ShowMessageAsync(this, "DB연결", "DB연결합니다");
                return;
            }

            connString = $"Server={DatabaseHost};Database=smarthome;Uid=root;Pwd=12345;Charset=utf8;";
            await ConnectDatabaseServer();
        }

        public void Dispose()
        {
            // 리소스 해제를 명시적으로 처리하는 기능 추가
            connection?.Close(); // DB 접속 해제
        }
    }

}
