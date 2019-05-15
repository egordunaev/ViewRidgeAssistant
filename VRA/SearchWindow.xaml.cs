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
    /// Логика взаимодействия для SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        private readonly IList<ArtistDto> AllowArtists = ProcessFactory.GetArtistProcess().GetList();
        private readonly IList<NationDto> AllowNations = ProcessFactory.GetNationProcess().GetList();
        private readonly IList<CustomerDto> customers = ProcessFactory.GetCustomerProcess().GetList();
        public IList<ArtistDto> FindedArtists;
        public bool exec;
        private readonly IList<CustomerDto> AllowCustomers = ProcessFactory.GetCustomerProcess().GetList();
        public IList<CustomerDto> FindedCustomers;
        public IList<TransDto> FoundTransactions;
        public SearchWindow(string status)
        {
            InitializeComponent();
            this.cbArtistCountry.ItemsSource = AllowNations;
            this.cbTransArtist.ItemsSource = AllowArtists;
            this.cbTransClient.ItemsSource = customers;
            switch (status)
            {
                case "Artist":
                    {
                        
                        //this.cbArtistCountry.SelectedIndex = 1;
                        this.sCustomer.Visibility = Visibility.Collapsed;
                        // this.sWork.Visibility = Visibility.Collapsed;
                        //  this.tiInterests.Visibility = Visibility.Collapsed;
                        this.sTrans.Visibility = Visibility.Collapsed;
                        break;
                    }
                case "Customer":
                    {
                        this.sArtist.Visibility = Visibility.Collapsed;
                        this.sTrans.Visibility = Visibility.Collapsed;
                        break;
                    }
                case "Trans":
                    {
                        this.sArtist.Visibility = Visibility.Collapsed;
                        this.sCustomer.Visibility = Visibility.Collapsed;
                        break;
                    }
            }
        }

        private void SearchArtist(object sender, RoutedEventArgs e)
        {
            this.FindedArtists = ProcessFactory.GetArtistProcess().SearchArtist(this.ArtistName.Text, this.cbArtistCountry.Text);
            this.exec = true;
            this.Close();
        }

        private void CloseForm(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SearchCustomer(object sender, RoutedEventArgs e)
        {
            this.FindedCustomers = ProcessFactory.GetCustomerProcess().SearchCustomer(this.CustomerName.Text, this.Email.Text);
            this.exec = true;
            this.Close();
        }

        private void btnSearchTrans_Click(object sender, RoutedEventArgs e)
        {
            this.FoundTransactions = ProcessFactory.GetTransProcess().SearchTransaction(this.cbTransClient.Text, this.cbTransArtist.Text, decimal.Parse(this.TransSales.Text), this.dpTransPurchasesStart.Text, this.dpTransPurchaseStop.Text, this.dpTransSalesStart.Text, this.dpTransSalesStop.Text);
        }

        private void btnCancelTrans_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
