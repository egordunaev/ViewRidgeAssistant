using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VRA.BusinessLayer;
using VRA.Dto;

namespace VRA
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string status; //Устанавливает, с какой таблицей в текущий момент работает пользователь

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            switch(status)
            {
                case "Artist":this.btnAddA_Click(sender,e);
                    break;
                case "Work":this.btnAddW_Click(sender, e);
                    break;
                case "Customer":this.btnAddC_Click(sender, e);
                    break;
                case "Trans":this.btnAddT_Click(sender, e);
                    break;
                //case "Nations"
                //case "Interests":this
                default: MessageBox.Show("Необходимо выбрать таблицу, в которую добавляется элемент");
                    return;
            }
        }
        private void btnAddA_Click(object sender, RoutedEventArgs e)
        {
            AddArtistWindow window = new AddArtistWindow();
            window.ShowDialog();

            //Получаем список художников и передаем его на отображение таблице
            dgArtists.ItemsSource = ProcessFactory.GetArtistProcess().GetList();
        }
        private void btnAddC_Click(object sender, RoutedEventArgs e)
        {
            AddCustomerWindow window = new AddCustomerWindow();
            window.ShowDialog();

            //Получаем список клиентов и передаем его на отображение таблице
            dgCustomers.ItemsSource = ProcessFactory.GetCustomerProcess().GetList();
        }
        private void btnAddW_Click(object sender, RoutedEventArgs e)
        {
            AddWorkWindow window = new AddWorkWindow();
            window.ShowDialog();

            //Получаем список работ и передаем его на отображение таблице
            dgWork.ItemsSource = ProcessFactory.GetWorkProcess().GetList();
        }
        private void btnAddT_Click(object sender, RoutedEventArgs e)
        {
            AddTransWindow window = new AddTransWindow();
            window.ShowDialog();

            //Получаем список художников и передаем его на отображение таблице
            dgTrans.ItemsSource = ProcessFactory.GetTransProcess().GetList();
        }
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            //Получаем список  и передаем его на отображение таблице
            switch (status)
            {
                case "Artist":
                    this.btnRefreshA_Click(sender, e);
                    break;
                case "Work":
                    this.btnRefreshW_Click(sender, e);
                    break;
                case "Customer":
                    this.btnRefreshC_Click(sender, e);
                    break;
                case "Trans":
                    this.btnRefreshT_Click(sender, e);
                    break;
                //case "Nations"
                //case "Interests":this
                default:
                    MessageBox.Show("Необходимо выбрать таблицу, в которую добавляется элемент");
                    return;
            }

        }
        private void btnRefreshA_Click(object sender, RoutedEventArgs e)
        {
            //Получаем список  и передаем его на отображение таблице
            dgArtists.ItemsSource = ProcessFactory.GetArtistProcess().GetList();
        }
        private void btnRefreshC_Click(object sender, RoutedEventArgs e)
        {
            //Получаем список  и передаем его на отображение таблице
            dgCustomers.ItemsSource = ProcessFactory.GetCustomerProcess().GetList();
        }
        private void btnRefreshW_Click(object sender, RoutedEventArgs e)
        {
            //Получаем список  и передаем его на отображение таблице
            dgWork.ItemsSource = ProcessFactory.GetWorkProcess().GetList();
        }
        private void btnRefreshT_Click(object sender, RoutedEventArgs e)
        {
            //Получаем список  и передаем его на отображение таблице
            dgTrans.ItemsSource = ProcessFactory.GetTransProcess().GetList();
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Artist":
                    this.btnDeleteA_Click(sender, e);
                    break;
                case "Work":
                    this.btnDeleteW_Click(sender, e);
                    break;
                case "Customer":
                    this.btnDeleteC_Click(sender, e);
                    break;
                case "Trans":
                    this.btnDeleteT_Click(sender, e);
                    break;
                //case "Nations"
                //case "Interests":this
                default:
                    MessageBox.Show("Необходимо выбрать таблицу, в которую добавляется элемент1");
                    return;
            }

        }
        private void btnDeleteA_Click(object sender, RoutedEventArgs e)
        {
            //Получаем выделенную строку с объектом художника
            ArtistDto item = dgArtists.SelectedItem as ArtistDto;
            //если там не художник или пользователь ничего не выбрал сообщаем об этом
            if (item == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Удаление художника");
                return;
            }
            //Просим подтвердить удаление
            MessageBoxResult result = MessageBox.Show("Удалить художника " + item.Name + "?", "Удаление художника", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            //Если пользователь не подтвердил, выходим
            if (result != MessageBoxResult.Yes)
                return;
            //Если все проверки пройдены и подтверждение получено, удаляем художника
            ProcessFactory.GetArtistProcess().Delete(item.Id);
            //И перезагружаем список художников
            btnRefresh_Click(sender, e);

        }
        private void btnDeleteC_Click(object sender, RoutedEventArgs e)
        {
            //Получаем выделенную строку с объектом художника
            CustomerDto item = dgCustomers.SelectedItem as CustomerDto;
            //если там не художник или пользователь ничего не выбрал сообщаем об этом
            if (item == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Удаление художника");
                return;
            }
            //Просим подтвердить удаление
            MessageBoxResult result = MessageBox.Show("Удалить художника " + item.Name + "?", "Удаление художника", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            //Если пользователь не подтвердил, выходим
            if (result != MessageBoxResult.Yes)
                return;
            //Если все проверки пройдены и подтверждение получено, удаляем художника
            ProcessFactory.GetCustomerProcess().Delete(item.CustomerID);
            //И перезагружаем список художников
            btnRefresh_Click(sender, e);

        }
        private void btnDeleteW_Click(object sender, RoutedEventArgs e)
        {
            //Получаем выделенную строку с объектом художника
            WorkDto item = dgWork.SelectedItem as WorkDto;
            //если там не художник или пользователь ничего не выбрал сообщаем об этом
            if (item == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Удаление художника");
                return;
            }
            //Просим подтвердить удаление
            MessageBoxResult result = MessageBox.Show("Удалить художника " + item.Title + "?", "Удаление художника", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            //Если пользователь не подтвердил, выходим
            if (result != MessageBoxResult.Yes)
                return;
            //Если все проверки пройдены и подтверждение получено, удаляем художника
            ProcessFactory.GetWorkProcess().Delete(item.WorkID);
            //И перезагружаем список художников
            btnRefresh_Click(sender, e);

        }
        private void btnDeleteT_Click(object sender, RoutedEventArgs e)
        {
            //Получаем выделенную строку с объектом художника
            TransDto item = dgTrans.SelectedItem as TransDto;
            //если там не художник или пользователь ничего не выбрал сообщаем об этом
            if (item == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Удаление художника");
                return;
            }
            //Просим подтвердить удаление
            MessageBoxResult result = MessageBox.Show("Удалить художника " + item.TransactionID + "?", "Удаление художника", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            //Если пользователь не подтвердил, выходим
            if (result != MessageBoxResult.Yes)
                return;
            //Если все проверки пройдены и подтверждение получено, удаляем художника
            ProcessFactory.GetTransProcess().Delete(item.TransactionID);
            //И перезагружаем список художников
            btnRefresh_Click(sender, e);

        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Artist":
                    this.btnEditA_Click(sender, e);
                    break;
                case "Work":
                    this.btnEditW_Click(sender, e);
                    break;
                case "Customer":
                    this.btnEditC_Click(sender, e);
                    break;
                case "Trans": this.btnEditT_Click(sender, e);
                    break;
                //case "Nations"
                //case "Interests":this
                default:
                    MessageBox.Show("Необходимо выбрать таблицу, в которую добавляется элемент1");
                    return;
            }
        }
        private void btnEditA_Click(object sender, RoutedEventArgs e)
        {
            //Получаем выделенную строку с объектом художника
            ArtistDto item = dgArtists.SelectedItem as ArtistDto;
            //если там не художник или пользователь ничего не выбрал сообщаем об этом
            if (item == null)
            {
                MessageBox.Show("Выберите запись для редактирования", "Редактирование");
                return;
            }
            //Создаем окно
            AddArtistWindow window = new AddArtistWindow();
            //Передаем объект на редактирование
            window.Load(item);
            //Отображаем окно с данными
            window.ShowDialog();
            //Перезагружаем список объектов
            btnRefresh_Click(sender, e);
        }
        private void btnEditC_Click(object sender, RoutedEventArgs e)
        {
            //Получаем выделенную строку с объектом клиента
            CustomerDto item = dgCustomers.SelectedItem as CustomerDto;
            //если там не клиент или пользователь ничего не выбрал сообщаем об этом
            if (item == null)
            {
                MessageBox.Show("Выберите запись для редактирования", "Редактирование");
                return;
            }
            //Создаем окно
            AddCustomerWindow window = new AddCustomerWindow();
            //Передаем объект на редактирование
            window.Load(item);
            //Отображаем окно с данными
            window.ShowDialog();
            //Перезагружаем список объектов
            btnRefresh_Click(sender, e);
        }
        private void btnEditW_Click(object sender, RoutedEventArgs e)
        {
            //Получаем выделенную строку с объектом работы
            WorkDto item = dgWork.SelectedItem as WorkDto;
            //если там не работы или пользователь ничего не выбрал сообщаем об этом
            if (item == null)
            {
                MessageBox.Show("Выберите запись для редактирования", "Редактирование");
                return;
            }
            //Создаем окно
            AddWorkWindow window = new AddWorkWindow();
            //Передаем объект на редактирование
            window.Load(item);
            //Отображаем окно с данными
            window.ShowDialog();
            //Перезагружаем список объектов
            btnRefresh_Click(sender, e);
        }
        private void btnEditT_Click(object sender, RoutedEventArgs e)
        {
            //Получаем выделенную строку с объектом клиента
            TransDto item = dgTrans.SelectedItem as TransDto;
            //если там не клиент или пользователь ничего не выбрал сообщаем об этом
            if (item == null)
            {
                MessageBox.Show("Выберите запись для редактирования", "Редактирование");
                return;
            }
            //Создаем окно
            AddTransWindow window = new AddTransWindow();
            //Передаем объект на редактирование
            window.Load(item);
            //Отображаем окно с данными
            window.ShowDialog();
            //Перезагружаем список объектов
            btnRefresh_Click(sender, e);
        }
        private void btnDataBase_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow window = new SettingsWindow();
            window.ShowDialog();
        }

        private void btn_DataBase_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow window = new SettingsWindow();
            window.ShowDialog();
        }

        private void btnArtists_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Customer": this.dgCustomers.Visibility = Visibility.Hidden;
                    break;
                case "Work": this.dgWork.Visibility = Visibility.Hidden;
                    break;
                case "Trans": this.dgTrans.Visibility = Visibility.Hidden;
                    break;
                case "Interests": this.dgInterests.Visibility = Visibility.Hidden;
                    break;
                case "Nations": this.dgNations.Visibility = Visibility.Hidden;
                    break;
            }
            this.dgArtists.Visibility = Visibility.Visible;//отображаем DateGrid художников
            status = "Artist";//устанавливаем таблицу, с которой работаем в данный момент
            this.btnRefresh_Click(sender, e);//загружаем данные в DateGrid
            this.statusLabel.Content = "Работа с таблицей: Художники";
            //устанавливаем видимость кнопок управления записями таблицы
            this.btnAdd.Visibility = Visibility.Visible;
            this.btnPurchase.Visibility = Visibility.Collapsed;
            this.btnSale.Visibility = Visibility.Collapsed;
            this.btnEdit.Visibility = Visibility.Visible;
            this.btnDelete.Visibility = Visibility.Visible;
            this.btnRefresh.Visibility = Visibility.Visible;
            this.btnSearch.Visibility = Visibility.Visible;

        }

        private void btnCustomers_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Artist":
                    this.dgArtists.Visibility = Visibility.Hidden;
                    break;
                case "Work":
                    this.dgWork.Visibility = Visibility.Hidden;
                    break;
                case "Trans":
                    this.dgTrans.Visibility = Visibility.Hidden;
                    break;
                case "Interests":
                    this.dgInterests.Visibility = Visibility.Hidden;
                    break;
                case "Nations":
                    this.dgNations.Visibility = Visibility.Hidden;
                    break;
            }
            this.dgCustomers.Visibility = Visibility.Visible;//отображаем DateGrid клиентов
            status = "Customer";//устанавливаем таблицу, с которой работаем в данный момент
            this.btnRefresh_Click(sender, e);//загружаем данные в DateGrid
            this.statusLabel.Content = "Работа с таблицей: Клиенты";
            //устанавливаем видимость кнопок управления записями таблицы
            this.btnAdd.Visibility = Visibility.Visible;
            this.btnPurchase.Visibility = Visibility.Collapsed;
            this.btnSale.Visibility = Visibility.Collapsed;
            this.btnEdit.Visibility = Visibility.Visible;
            this.btnDelete.Visibility = Visibility.Visible;
            this.btnRefresh.Visibility = Visibility.Visible;
            this.btnSearch.Visibility = Visibility.Visible;
        }

        private void btnWork_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Artist":
                    this.dgArtists.Visibility = Visibility.Hidden;
                    break;
                case "Customer":
                    this.dgCustomers.Visibility = Visibility.Hidden;
                    break;
                case "Trans":
                    this.dgTrans.Visibility = Visibility.Hidden;
                    break;
                case "Interests":
                    this.dgInterests.Visibility = Visibility.Hidden;
                    break;
                case "Nations":
                    this.dgNations.Visibility = Visibility.Hidden;
                    break;
            }
            this.dgWork.Visibility = Visibility.Visible;//отображаем DateGrid работ
            status = "Work";//устанавливаем таблицу, с которой работаем в данный момент
            this.btnRefresh_Click(sender, e);//загружаем данные в DateGrid
            this.statusLabel.Content = "Работа с таблицей: Работы";
            //устанавливаем видимость кнопок управления записями таблицы
            this.btnAdd.Visibility = Visibility.Visible;
            this.btnPurchase.Visibility = Visibility.Collapsed;
            this.btnSale.Visibility = Visibility.Collapsed;
            this.btnEdit.Visibility = Visibility.Visible;
            this.btnDelete.Visibility = Visibility.Visible;
            this.btnRefresh.Visibility = Visibility.Visible;
            this.btnSearch.Visibility = Visibility.Visible;
        }

        private void btnTrans_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Artist":
                    this.dgArtists.Visibility = Visibility.Hidden;
                    break;
                case "Work":
                    this.dgWork.Visibility = Visibility.Hidden;
                    break;
                case "Customer":
                    this.dgCustomers.Visibility = Visibility.Hidden;
                    break;
                case "Interests":
                    this.dgInterests.Visibility = Visibility.Hidden;
                    break;
                case "Nations":
                    this.dgNations.Visibility = Visibility.Hidden;
                    break;
            }
            this.dgTrans.Visibility = Visibility.Visible;//отображаем DateGrid транзакций
            status = "Trans";//устанавливаем таблицу, с которой работаем в данный момент
            this.btnRefresh_Click(sender, e);//загружаем данные в DateGrid
            this.statusLabel.Content = "Работа с таблицей: Транзакции";
            //устанавливаем видимость кнопок управления записями таблицы
            this.btnAdd.Visibility = Visibility.Visible;
            this.btnPurchase.Visibility = Visibility.Collapsed;
            this.btnSale.Visibility = Visibility.Collapsed;
            this.btnEdit.Visibility = Visibility.Visible;
            this.btnDelete.Visibility = Visibility.Visible;
            this.btnRefresh.Visibility = Visibility.Visible;
            this.btnSearch.Visibility = Visibility.Visible;
        }
    }
}
