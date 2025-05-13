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

- MVVM �����
    - View <-> ViewModel �� ������ �ڵ� ����
    - ���� �и��� ������ ��Ȯ����. �ڱ����ϸ� �ϸ� ��
    - ������ ���� �� ���Һд��� Ȯ��. ��������Ʈ�� �˸���
    - �׽�Ʈ�� ���������� ����
    - ������ ����. ������� �����
    - �������� Ŀ��

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
    - INotifyPropertyChanged �������̽� ����
    - OnPropertyChanged �̺�Ʈ�ڵ鷯 �޼��� �ڵ�
8. MainView.xaml�� ViewModel ����
    ```xml
    ...
        xmlns:vm="clr-namespace:WpfBasicApp02.ViewModel"
        DataContext="{DynamicResource MainVM}"
        mc:Ignorable="d"
        Title="MahApps DB����(MVVM)" Height="350" Width="600">
    <mah:MetroWindow.IconTemplate>
        <DataTemplate>
            <iconPacks:PackIconMaterial Kind="DatabaseCog" Margin="10,7,0,0" Foreground="White" />
        </DataTemplate>
    </mah:MetroWindow.IconTemplate>
    <mah:MetroWindow.Resources>
        <!-- MainViewModel�� �����ͼ� ����ϰڴ�!! -->
        <vm:MainViewModel x:Key="MainVM" />
    </mah:MetroWindow.Resources>
    ```
9. MainView.xaml ��Ʈ�ѿ� ���ε� �۾�
    - �������� C# ��� - x:Name ���(�����ε� ����ʿ�), ���콺�̺�Ʈ �߰�
    ```xml
    <!-- UI ��Ʈ�� ���� -->
    <DataGrid x:Name="GrdBooks" 
            Grid.Row="0" Grid.Column="0" Margin="5" 
            AutoGenerateColumns="False" IsReadOnly="True" 
            MouseDoubleClick="GrdBooks_MouseDoubleClick">
        <DataGrid.Columns>
            <DataGridTextColumn Binding="{Binding Idx}" Header="����" />
    ```

    - WPF MVVM ���ε� ��� - ���� Binding ���
    ```xml
    <!-- UI ��Ʈ�� ���� -->
    <DataGrid Grid.Row="0" Grid.Column="0" Margin="5" 
            AutoGenerateColumns="False" IsReadOnly="True"
            ItemsSource="{Binding Books}"
            SelectedItem="{Binding SelectedBook, Mode=TwoWay}">
        <DataGrid.Columns>
            <DataGridTextColumn Binding="{Binding Idx}" Header="����" />
    ```
10. ������
    <img src='./image/wpf05.png'>

## 2����
### MVVM Framework
- MVVM ������ü�� �����. �ʱ� ���߽� MVVM ���ø��� ����µ� �ð��� ���� �ҿ�. ���̵� ����
- ���� ���� �����ϰ��� 3rd Party���� ������ MVVM �����ӿ�ũ ���
- ����
    - `Prism` : MS�迭���� ���� ����. ��Ը� �� ���߽� ���. ���ȭ�ߵǾ� ����. Ŀ�´�Ƽ Ȱ��
        - �����庮 ����
    - `Caliburn.Micro` : �淮ȭ�� �����ӿ�ũ. ���� ������ �� ����. Xaml ���ε� ��������. Ŀ�´�Ƽ �ִ��߼�
        - [���Ļ���Ʈ](https://caliburnmicro.com/)
        - [Github](https://github.com/Caliburn-Micro/Caliburn.Micro)
        - MahApps.Metro���� ��� ��
        - ������� �����
        - [����]MahApps.Metro�� �޽����ڽ� ���̾�αװ� ������ �ȵ�!!
    - `MVVM Light Toolkit` : ���� ������ MVVM �Թ���. ���� Command ����. ��������.
        - Ȯ�强�� ������
    - CommunityTooklit.Mvvm : MS ���� �淮MVVM. �ܼ�,����. Ŀ�´�Ƽ�� �ſ� Ȱ��
        - NotifyPropertyChanged�� ����� �ʿ����
        - ������� ����
    - ReactiveUI : �ֽű�� Rx��� MVVM. �񵿱�,��Ʈ��ó�� ����. Ŀ�´�Ƽ�� Ȱ��.
        - �����庮�� ����
### Caliburn.Micro �н�
1. WPF ������Ʈ ����
2. NuGet ��Ű�� Caliburn.Micro �˻� �� ��ġ
3. App.xaml StartupUri�� ���� - [�ҽ�](./day02/Day02Wpf/WpfBasicApp01/App.xaml)
4. Models, Views, ViewModels ����(�̸��� �Ȱ��ƾ� ��) ����
5. MainViewModel Ŭ���� ���� - [�ҽ�](./day02/Day02Wpf/WpfBasicApp01/ViewModels/MainViewModel.cs)
    - MainView�� ���ϴ� ViewModel�� �ݵ�� MainViewModel��� �̸��� �����
6. MainWindow.xaml�� View �̵�
7. MainWindow�� MainView�� �̸� ����
8. Bootstrapper Ŭ���� ����, �ۼ� - [�ҽ�](./day02/Day02Wpf/WpfBasicApp01/Bootstrapper.cs)
9. App.xaml���� Resource �߰�
10. MahApps.Metro UI ����
    <img src='./image/wpf06.png'>

### Caliburn.Micro MVVM ����
1. WPF ������Ʈ ����
2. �ʿ� ���̺귯�� ��ġ
    - Caliburn.Micro
    - MahApps.Metro
    - MahApps.Metro.IconPacks
    - MySQL.Data
3. Models, Views, ViewModels�� ���� ����
4. �����۾� �ҽ��ڵ� ����, ���ӽ����̽� ����
    <img src='./image/wpf07.png'>

## 3����
### CommunityToolkit.Mvmm �ٽ�
1. Wpf������Ʈ ����
2. �ʿ� ���̺귯�� ��ġ
    - CommunityToolkit.Mvvm
    - MahApps.Metro
    - MahApps.Metro.IconPacks
3. Models, Views, ViewModels ���� ����
4. MainWindow.xaml ����
5. App.xaml StartupUri �� ����
6. Views/MainView.xaml ����
7. ViewModels/MainViewModel.cs ����
8. App.xaml Startup �̺�Ʈ �߰�
    - App.xaml.cs ���� �߰�
9. App.xaml MahApps.Metro ���� ���ҽ� �߰�
10. MainView�� MetroWindow�� ����
    <img src='./image/wpf08.png'>

### Log ���̺귯��
- ������ ��, �ַ���� ������¸� ��� ����͸��ϴ� ���
- Log ����
    - ���� �ڵ� ���
    - �α� ���̺귯�� �����
- Log ���̺귯��
    - **NLog** : ������ ����. ����. ����ũ��
    - Serilog : ����� ��, ����. ����
    - Log4net : Java�� �α׸� .NET���� ����. ����. ����
    - `ZLogger` : ���� �ֽ�(2021), �ʰ��. ���Ӽ���

### NLog ���̺귯�� ���
1. NuGet��Ű�� > NLog, NLog.Schema ��ġ
2. ���׸� > XML���� > NLog.config ����
3. Info < `Debug` < Warn < Error < Fatal
4. `NLog.config`�� ��� ���丮�� ����
5. Debug, Trace�� ����� �ȵ�
6. Info, Warn, Error, Fatal �� ���
    <img src='./image/wpf09.png'>

### DB���� CRUD ����
1. WPF������Ʈ ����
2. NuGet ��Ű�� �ʿ���̺귯�� ��ġ
    - CommunityToolkit.Mvvm
    - MahApps.Metro / MahApps.Metro.IconPacks
    - MySql.Data
    - NLog
3. Models, Views, ViewModels ����
4. App.xaml �ʱ�ȭ �۾�
5. MainView.xaml, MainViewModel ����ȭ�� MVVM �۾�
    - �޴��۾�
    - ContentControl �߰�
6. ���� �������Ʈ�� �۾�
    - BookGenre(View, ViewModel)
    - Books(View, ViewModel)
7. Models > Genre(DivisionTbl) �� �۾�
8. BookGenreViewModel DBó�� ����

## 4����
### DB���� CRUD ����(���)
1. BookGenre���� INSERT, UPDATE ��� ����
2. NLog.config ����
3. Helpers.Common Ŭ���� ����
    - NLog �ν��Ͻ� ����
    - ���� DB���Ṯ�ڿ� ����
    - MahApps.Metro ���̾�α� �ڵ������ ����
4. �� ViewModel�� IDialogCoordinator ���� �ڵ� �߰�
    - ViewModel �����ڿ� �Ķ���� �߰�
    - View, ViewModel ������ IDialogCoordinator ����
5. View�� Dialog���� ���ӽ����̽�, �Ӽ� �߰�
6. await this.dialogCoordinator.ShowMessageAsync() ���
    <img src='./image/wpf11.png'>
7. BookView.xaml ȭ���۾�
8. MemberView.xaml, RentalView.xaml ȭ���۾�
9. ViewModel�� �۾�
    <img src='./image/wpf12.png'>

### DB���� CRUD ������ �߰� �ʿ����
- [x] ������ ������ ���� �޼���ȭ
- [x] NLog�� �� ��� ���۽� �α׳����. ����ȭ�۾�
- [x] ���Ṯ�ڿ� Common���� ����
- [x] ���� �޴� ���̾�α� MetroUI�� ����
- [x] MahApps.Metro �޽������·� ����
- [x] �������� �޽����ڽ� �߰�

### DB���� CRUD �ǽ�
- BooksView, BooksViewModel �۾� �ǽ�
- 1���� MVVM ����, ���� �н��Ѱ�
