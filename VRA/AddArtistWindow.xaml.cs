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
using System.Windows.Shapes;
using VRA.Dto;
using VRA.BusinessLayer;

namespace VRA
{
    /// <summary>
    /// Логика взаимодействия для AddArtistWindow.xaml
    /// </summary>
    public partial class AddArtistWindow : Window
    {
        /// <summary>
        /// Поле хранит идентификатор художника
        /// </summary>
        private int _id;
        public void Load(ArtistDto artist)
        {
            //если объект не существует, или его национальность не в списке допустимых,выходим
            if (artist == null || !Nationalities.Contains(artist.Nationality))
                return;
            //сохраняем id художника
            _id = artist.Id;
            //заполняем визуальные компоненты для отображения данных
            tbName.Text = artist.Name;
            tbBirth.Text = artist.BirthYear.ToString();
            if (artist.DeceaseYear.HasValue)
                tbDeath.Text = artist.DeceaseYear.Value.ToString();
            cbNationality.SelectedItem = artist.Nationality;
        }
        /// <summary>
        /// Список допустимых национальностей
        /// </summary>
        private static readonly string[] Nationalities =
        {"Русский", "Немец", "Испанец", "Итальянец"};
        public AddArtistWindow()
        {
            InitializeComponent();
            //Передаем допустимые значения
            cbNationality.ItemsSource = Nationalities;
            //Задаем начальное значение
            cbNationality.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Имя художника не должно быть пустым", "Проверка");
                return;
            }            int birth;
            int? death = null;
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Имя художника не должно быть пустым", "Проверка");
                return;
            }
            if (!int.TryParse(tbBirth.Text, out birth))
            {
                MessageBox.Show("Год рождения должен быть целым числом", "Проверка");
                return;
            }
            if (!string.IsNullOrEmpty(tbDeath.Text))
            {
                int intDeath;
                if (!int.TryParse(tbDeath.Text, out intDeath))
                {
                    MessageBox.Show("Год смерти должен быть целым числом", "Проверка");
                    return;
                }
                if (intDeath < birth)
                {
                    MessageBox.Show("Год смерти должен быть больше года рождения","Проверка");
                    return;
                }
                death = intDeath;
            }
            //Создаем объект для передачи данных
            ArtistDto artist = new ArtistDto();
            //Заполняем объект данными
            artist.Name = tbName.Text;
            artist.BirthYear = birth;
            artist.DeceaseYear = death;
            artist.Nationality = cbNationality.SelectedItem.ToString();
            //Именно тут запрашиваем реализованную ранее задачу по работе с художниками
            IArtistProcess artistProcess = ProcessFactory.GetArtistProcess();
            //если это новый объект - сохраняем его
            if (_id == 0)
            {
                //Сохраняем художника
                artistProcess.Add(artist);
            }
            else //иначе обновляем
            {
                //копируем обратно идентификатор объекта
                artist.Id = _id;
                //обновляем
                artistProcess.Update(artist);
            }
            //и закрываем форму
            Close();
        }
    }
}
