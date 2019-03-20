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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddArtistWindow window = new AddArtistWindow();
            window.ShowDialog();
            
            //Получаем список художников и передаем его на отображение таблице
            dgArtists.ItemsSource = ProcessFactory.GetArtistProcess().GetList();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            //Получаем список художников и передаем его на отображение таблице
            dgArtists.ItemsSource = ProcessFactory.GetArtistProcess().GetList();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
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
            MessageBoxResult result = MessageBox.Show("Удалить художника " +item.Name + "?","Удаление художника", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            //Если пользователь не подтвердил, выходим
            if (result != MessageBoxResult.Yes)
                return;
            //Если все проверки пройдены и подтверждение получено, удаляем художника
            ProcessFactory.GetArtistProcess().Delete(item.Id);
            //И перезагружаем список художников
            btnRefresh_Click(sender, e);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
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
    }
}
