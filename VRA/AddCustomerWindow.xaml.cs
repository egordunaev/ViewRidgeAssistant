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
    /// Логика взаимодействия для AddCustomerWindow.xaml
    /// </summary>
    public partial class AddCustomerWindow : Window
    {
        private int _customerid;
        public void Load(CustomerDto customer)
        {
            _customerid = customer.CustomerID;
            tbAreaCode.Text = customer.AreaCode;
            tbCity.Text = customer.City;
            tbCountry.Text = customer.Country;
            tbEmail.Text = customer.Email;
            tbHouseNumber.Text = customer.HouseNumber;
            tbName.Text = customer.Name;
            tbPhoneNumber.Text = customer.PhoneNumber;
            tbRegion.Text = customer.Region;
            tbStreet.Text = customer.Street;
            tbZipPostalCode.Text = customer.ZipPostalCode;
        }
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
            CustomerDto customer = new CustomerDto();
            customer.AreaCode = tbAreaCode.Text;
            customer.City = tbCity.Text;
            customer.Country = tbCountry.Text;
            customer.Email = tbEmail.Text;
            customer.HouseNumber = tbHouseNumber.Text;
            customer.Name = tbName.Text;
            customer.PhoneNumber = tbPhoneNumber.Text;
            customer.Region = tbRegion.Text;
            customer.Street = tbStreet.Text;
            customer.ZipPostalCode = tbZipPostalCode.Text;
            ICustomerProcess customerProcess = ProcessFactory.GetCustomerProcess();
            if (_customerid==0)
            {
                customerProcess.Add(customer);
            }
            else
            {
                customer.CustomerID = _customerid;
                customerProcess.Update(customer);
            }
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
