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
    /// Логика взаимодействия для AddCustomerArtistIntWindow.xaml
    /// </summary>
    public partial class AddCustomerArtistIntWindow : Window
    {
        private int customerid;
        private int artistid;
        private readonly IList<CustomerDto> Customers = ProcessFactory.GetCustomerProcess().GetList();
        private readonly IList<ArtistDto> Artists = ProcessFactory.GetArtistProcess().GetList();
        public AddCustomerArtistIntWindow()
        {
            InitializeComponent();
            cbArtist.ItemsSource = (from A in Artists orderby A.Name select A);
            cbClient.ItemsSource = (from C in Customers orderby C.Name select C);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CustomerArtistIntDto intDto = new CustomerArtistIntDto();
                intDto.Artist = cbArtist.SelectedItem as ArtistDto;
                intDto.Customer = cbClient.SelectedItem as CustomerDto;
                ICustomerArtistIntProcess intProcess = ProcessFactory.GetCustomerArtistIntProcess();
                if (customerid==0 && artistid==0)
                {
                    intProcess.Add(intDto);
                }
                else
                {
                    intDto.Artist.Id = artistid;
                    intDto.Customer.CustomerID = customerid;
                    intProcess.Update(intDto);
                }
                Close();
            }
            catch(Exception msg)
            {
                MessageBox.Show(msg.Message, "Ошибка");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
