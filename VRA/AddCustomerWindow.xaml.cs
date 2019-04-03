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

namespace VRA
{
    /// <summary>
    /// Логика взаимодействия для AddCustomerWindow.xaml
    /// </summary>
    public partial class AddCustomerWindow : Window
    {
        public AddCustomerWindow()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Имя клиента не должно быть пустым", "Проверка");
                return;
            }
            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                MessageBox.Show("Email не должен быть пустым", "Проверка");
                return;
            }
            if (string.IsNullOrEmpty(tbAreaCode.Text))
            {
                MessageBox.Show("Код области не должен быть пустым", "Проверка");
                return;
            }
            if (string.IsNullOrEmpty(tbHouseNumber.Text))
            {
                MessageBox.Show("Номер дома не должен быть пустым", "Проверка");
                return;
            }
            if (string.IsNullOrEmpty(tbStreet.Text))
            {
                MessageBox.Show("Улица не должна быть пустой", "Проверка");
                return;
            }
            if (string.IsNullOrEmpty(tbCity.Text))
            {
                MessageBox.Show("Город не должен быть пустым", "Проверка");
                return;
            }
            if (string.IsNullOrEmpty(tbRegion.Text))
            {
                MessageBox.Show("Регион не должен быть пустым", "Проверка");
                return;
            }
            if (string.IsNullOrEmpty(tbZipPostalCode.Text))
            {
                MessageBox.Show("Почтовый индекс не должен быть пустым", "Проверка");
                return;
            }
            if (string.IsNullOrEmpty(tbCountry.Text))
            {
                MessageBox.Show("Страна не должна быть пустой", "Проверка");
                return;
            }
            if (string.IsNullOrEmpty(tbPhoneNumber.Text))
            {
                MessageBox.Show("Номер телефона не должен быть пустым", "Проверка");
                return;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
