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
    /// Логика взаимодействия для AddTransWindow.xaml
    /// </summary>
    public partial class AddTransWindow : Window
    {
        private int _transactionid;
        public void Load(TransDto trans)
        {
            _transactionid = trans.TransactionID;
            tbAcquisitionPrice.Text = trans.AcquisitionPrice.ToString();
            tbAskingPrice.Text = trans.AskingPrice.ToString();
            tbCustomerID.Text = trans.CustomerID.ToString();
            tbSalesPrice.Text = trans.SalesPrice.ToString();
            //Даты сделать позже.
        }
        public AddTransWindow()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(tbAcquisitionPrice.Text))
            {
                MessageBox.Show("Цена приобретения не указана", "Проверка");
                return;
            }
            if (string.IsNullOrEmpty(tbAskingPrice.Text))
            {
                MessageBox.Show("Цена продажи не указана", "Проверка");
                return;
            }
            if (string.IsNullOrEmpty(tbCustomerID.Text))
            {
                MessageBox.Show("Номер клиента не указан", "Проверка");
                return;
            }
            if (string.IsNullOrEmpty(tbSalesPrice.Text))
            {
                MessageBox.Show("Цена покупки не указана", "Проверка");
                return;
            }
            //добавить проверку даты
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
