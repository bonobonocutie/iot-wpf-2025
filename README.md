# iot-wpf-2025
IoT ������ WPF �������丮

## 1����
### WPF�� ����
- Windows Presentation Foundation
    - WinForms�� �������� �̾��� �κ�, �ӵ�����, ���߰� �������� �и� �����ϰ��� MS �����ӿ�ũ
    - ȭ��������� XML����� xaml

### WPF DB ���ε� ����
1. ������Ʈ ���� - [������](./day01/Day01Wpf/WpfBasicApp01/MainWindow.xaml), [�ҽ�](./day01/Day01Wpf/WpfBasicApp01/MainWindow.xaml.cs)
2. NuGet��Ű������ `MahApps.Metro`(������) ���̺귯�� ��ġ
3. ������ ����
    - App.xaml
    - MainWindow.xmal
    - MainWindow.xaml.cs�� ��� Ŭ������ �����ϴ� �� - ������
4. UI ����
5. DB���� �����غ�
    - NuGet��Ű������ `MSQL.Data` ���̺귯�� ��ġ
6. DB����
    1. DB���Ṯ�ڿ�(Connection String) : DB�������� ���Ṯ�ڿ� ������ �ٸ��� ������ �־����
    2. ���� : ������ ����(���� SELECT, INSERT, UPDATE, DELETE)
    3. �����͸� ���� ��ü : ����Ʈ ����
    4. DB���ᰴü(`SqlConnection`) : ���� ���ڿ��� ó���ϴ� ��ü. DB����, ����, ����Ȯ�� ...
        - DB �������� MySqlConnection, SqlConnection ,OracleConnection ...
    5. DB��ɰ�ü(`SqlCommand`) : ������ ��Ʈ���ϴ� ��ü, ���� �� ������ ���ᰴü
        - ExecuteReader() : SELECT�� ����, ��� �����͸� ��� �޼���
        - ExecuteScalar() : SELECT�� �� count() �� �Լ��� 1row/1column �����͸� �������� �޼���
        - ExecuteNonQuery() : INSERT, UPDATE, DELETE���� ���� transaction�� �߻��ϴ� �������� ��� �޼���
    6. DB�����;����(`SqlDataAdapter`) : �������� ������ó���� ���� �����ִ� ��ü
        - DB��ɰ�üó�� ������ ���������� �ʿ����
        - DataTable, DataSet ��ü�� fill() �޼���� �ڵ����� ä����
        - ���� SELECT������ ���
    7. DB�����͸���(`SqlDataReader`)
        - DataReader : ExecuteReader()�� ������ �����͸� �����ϴ� ��ü
        - DataAdapter : �� �� �����ϰ� �����͸� ó�����ִ� ��ü
7. ������
    <img src="./image/wpf01.png">
8. MahApps.Metro ��� ���̾�α� ó��
    <img src="./image/wpf04.png">
9. �������� C# ���۰��߰� ���̰� ����

### WPF MVVM
- [����������](https://ko.wikipedia.org/wiki/%EC%86%8C%ED%94%84%ED%8A%B8%EC%9B%A8%EC%96%B4_%EB%94%94%EC%9E%90%EC%9D%B8_%ED%8C%A8%ED%84%B4)
    - ����Ʈ���� ���п��� ���������� �߻��ϴ� ������ ���� �����ϰ� �ذ��� ��ĵ�
    - �ݺ������� ��Ǯ�̵Ǵ� ���ߵ������� ������ �ذ��ϵ��� ����ȭ��Ų ���(���ø�)
    - ���� ���������� �� ��Ű��������, �� �� �����ΰ� ������ �и��� ������ �� �ִ� ������ �غ�
    - MV* : MVC, MVP, MVVM...

- MVC : Model-View-Controller ����
    - ����� �������̽�(View)�� ����Ͻ� ����(Controller, Model)�и��ؼ� ���� ����
    - �����̳ʿ��� �ּ����� ���߿� ������ ��Ŵ
    - �����ڴ� �������� ������� �ʰ� ���߸� �� �� ����
    - ����ڴ� Controller���� ��û
    - Controller�� Model���� Data�� ��û
    - Model�� DB�� �����͸� ������ Controller�� ����
    - Controller�� �����͸� ����Ͻ������� ���� ó���ϰ� View�� ����
    - View�� �����͸� ȭ�鿡 �ѷ��ְ�, ȭ��� ó���� ���� ��ģ �� ����ڿ��� ����
    - ������ ����, �� �κк� �����ڵ�� ����
    - Spring Boot, `ASP.NET`, Django �� ������ ��Ű��ó�������� ǥ������ ���
    <img src='./image/wpf02.png'>

- MVP : Model-View-Presenter ����
    - MVC ���Ͽ��� �Ļ���
    - Presenter : Supervising Controller��� �θ�

- **MVVM** : Model-View-ViewModel ����
    - MVC ���Ͽ��� �Ļ�
    - ��ũ������ GUI�ڵ带 �����ϴ� ��Ű��ó
    - ����ڴ� View�� ����(MVC�� ������)
    - ViewModel�� Controller ����(����Ͻ����� ó��)
    - Model�� �翬�� DB��û, ����
    - �������� MVC�� �ٸ�
    - �������� C#����� ����ڰ� �̺�Ʈ�߻���Ű�� ������ �߻��ñ⸦ �ٷ� �� �� ����
    - MVVM ����� C#�� ��ȭ�� �ֽ��ϰ� �־�� ��. ���°� �ٲ�� ��ȭ�� �����
    <img src='./image/wpf03.png'>

### WPF MVVM ����
1. ������Ʈ ���� - [������](./day01/Day01Wpf/WpfBasicApp02/View/MainView.xaml), [�ҽ�](./day01/Day01Wpf/WpfBasicApp02/ViewModel/MainViewModel.cs)
2. WPF DB���ε� ������ ����� UI �״�� ����
3. Model, View, ViewModel ���� ����
4. MainWindow.xaml�� View�� �̵�
5. App.xaml StartupUri ����
6. Model���� �� BookŬ���� ����
    - INotifyPropertyChanged �������̽� : ��ü���� ��� �Ӽ����� ����Ǹ� ���¸� C#���� �˷��ִ� ���
    - PropertyChangedEventHandler �̺�Ʈ ����
7. ViewModel���� �� MainViewModelŬ���� ����
