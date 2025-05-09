using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MySql.Data.MySqlClient;
using System.Data;
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

namespace WpfBasicApp01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 메인윈도우 로드 후 이벤트처리 핸들러
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // DB 연결
            // 데이터 그리드에 데이터를 읽어오기
            LoadControlFromDb();
            LoadGridFromDb();
        }

        private async void LoadControlFromDb()
        {
            // 1. DB연결문자열(필수)
            string connectionString = "Server=localhost;Database=bookrentalshop;Uid=root;Pwd=12345;Charset=utf8;";
            
            // 2. 사용쿼리
            string query = "SELECT division, names FROM divtbl";

            List<KeyValuePair<string, string>> divisions = new List<KeyValuePair<string, string>>();

            // 3. DB연결, 명령, 리더
            using(MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader(); // 데이터 가져올때
                    while (reader.Read())
                    {
                        var division = reader.GetString("division");
                        var names = reader.GetString("names");

                        divisions.Add(new KeyValuePair<string, string>(division, names));
                    }


                } catch(MySqlException ex)
                {
                    await this.ShowMessageAsync($"에러! {ex.Message}", "에러");
                }
                CboDivisions.ItemsSource = divisions; // 데이터 연동
            }

        }

        private void LoadGridFromDb()
        {
            // 1. DB연결문자열(필수)
            string connectionString = "Server=localhost;Database=bookrentalshop;Uid=root;Pwd=12345;Charset=utf8;";
            
            // 2. 사용쿼리
            string query = @"SELECT Idx, Author, Division, Names, ReleaseDate, ISBN, Price
                            FROM bookstbl;";
            
            // 3. DB연결, 명령, 리더
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    GrdBooks.ItemsSource = dt.DefaultView;
                }
                catch (MySqlException ex)
                {

                }
            }
        }

        private async void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(GrdBooks.SelectedItems.Count == 1)
            {   // 그리드 데이터를 하나만 선택했을 때
                // 데이터그리드의 데이터는 IList 형식, 그 중 한건은 DataRowView 객체로 형변환 가능
                var item = GrdBooks.SelectedItems[0] as DataRowView;

                //MessageBox.Show(item.Row["names"].ToString());
                NudIdx.Value = Convert.ToDouble(item.Row["idx"]);
                CboDivisions.SelectedValue = Convert.ToString(item.Row["division"]);
                TxtNames.Text = Convert.ToString(item.Row["names"]);
                TxtAuthor.Text = Convert.ToString(item.Row["author"]);
                TxtIsbn.Text = Convert.ToString(item.Row["names"]);
                TxtPrice.Text = Convert.ToString(item.Row["price"]);

                DpcReleasDate.Text = Convert.ToString(item.Row["releasedate"]);
            }

            await this.ShowMessageAsync($"처리완료!", "메시지");
        }
    }
}