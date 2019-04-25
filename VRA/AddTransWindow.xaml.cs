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
using System.Globalization;
using System.Threading;

namespace VRA
{
    /// <summary>
    /// Логика взаимодействия для AddTransWindow.xaml
    /// </summary>
    public partial class AddTransWindow : Window
    {
        private readonly IList<WorkDto> Works = ProcessFactory.GetWorkProcess().GetList();
        private readonly IList<WorkDto> FreeForSale = ProcessFactory.GetWorkProcess().GetListInGallery();
        private IList<WorkDto> FreeForPurchase = new List<WorkDto>();        public string status;
        private int _transactionid;
        public void Load(TransDto trans)
        {
            _transactionid = trans.TransactionID;
            this.Title = "Транзакция: Редактирование";
            if(trans.Customer !=null)
            {
                this.cbCustomer.Text = trans.Customer.Name;
            }
            if(trans.Work.Copy!=null)
            {
                this.cbCopy.Text = trans.Work.Copy;
                this.cbWork.Text = trans.Work.Title;
            }
            this.tbAcquisitionPrice.Text = trans.AcquisitionPrice.ToString();
            this.tbAskingPrice.Text = trans.AskingPrice.ToString();
            this.tbSalesPrice.Text = trans.SalesPrice.ToString();
            this.dpAcuired.Text = trans.DateAcquired.ToString();
            this.dpPurchase.Text = trans.PurchaseDate.ToString();
            this.LoadWork(trans.Work.Title);
        }
        private void LoadWork(string Title)
        {
            this.cbCopy.Items.Clear();
            foreach(WorkDto work in Works)
            {
                if (work.Title == Title)
                    this.cbCopy.Items.Add(work);
            }
            this.cbCopy.SelectedIndex = 0;
        }
        public AddTransWindow()
        {
            CultureInfo ci = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
            ci.DateTimeFormat.ShortDatePattern = "dd - MM - yyyy";
            Thread.CurrentThread.CurrentCulture = ci;

            InitializeComponent();

            IList<CustomerDto> customers = ProcessFactory.GetCustomerProcess().GetList();
            Works = ProcessFactory.GetWorkProcess().GetList();
            this.cbCustomer.ItemsSource = (from C in customers orderby C.Name select C);
            this.cbWork.ItemsSource = (from W in Works orderby W.Title select W);
            this.dpAcuired.IsTodayHighlighted = true;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(status=="sale")
            {
                if (this.cbCustomer.SelectedIndex < 0)
                {
                    MessageBox.Show("Укажите клиента, которому продается картина!");
                    return;
                }
            }
            TransDto transaction = new TransDto();
            WorkDto SelectedWork = selectWork();
            if (SelectedWork == null)
            {
                MessageBox.Show("Картина должна быть выбрана!");
                return;
            }
            if(status=="purchase")
            {
                if(workAtGalery(SelectedWork))
                {
                    MessageBox.Show("Запрашиваемая работа уже находится в галерее!");
                    return;
                }
            }
            if (status == "sale")
            {
                if (!workAtGalery(SelectedWork))
                {
                    MessageBox.Show("Запрашиваемая работа уже продана!");
                    return;
                }
            }
            transaction.Work = SelectedWork;
            if(!string.IsNullOrEmpty(tbAcquisitionPrice.Text))
            {
                try
                {
                    transaction.AcquisitionPrice = Convert.ToDecimal(tbAcquisitionPrice.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Введите корректную цену приобретения");
                    return;
                }
            }
            if(!string.IsNullOrEmpty(tbAskingPrice.Text))
            {
                try
                {
                    transaction.AcquisitionPrice = Convert.ToDecimal(tbAcquisitionPrice.Text);
                }
                catch(Exception)
                {
                    MessageBox.Show("Введите корректную запрашиваемую цену");
                    return;
                }
            }
            if (!string.IsNullOrEmpty(this.dpAcuired.Text))
            {
                transaction.DateAcquired = Convert.ToDateTime(this.dpAcuired.Text);
            }
            else
            {
                MessageBox.Show("Дата приобретения должна быть указана!"); return;
            }
            if (!string.IsNullOrEmpty(this.dpPurchase.Text))
            {
                if (Convert.ToDateTime(dpPurchase.Text) > Convert.ToDateTime(dpAcuired.Text))
                    transaction.PurchaseDate = Convert.ToDateTime(this.dpPurchase.Text);
                else
                {
                    MessageBox.Show("Нельзя продать работу раньше, чем её купила галерея! Проверьте правильность ввода данных.");
                    return;
                }
            }
            if (!string.IsNullOrEmpty(cbCustomer.Text))
            {
                CustomerDto SelectedCustomer = (CustomerDto)this.cbCustomer.SelectedItem;
                transaction.Customer = SelectedCustomer;
            }
            if (!string.IsNullOrEmpty(tbSalesPrice.Text))
            {
                try
                {
                    if (Convert.ToDecimal(tbSalesPrice.Text) >= 30000 &&
                   Convert.ToDecimal(tbSalesPrice.Text) <= 1500000)
                        transaction.SalesPrice = Convert.ToDecimal(tbSalesPrice.Text);
                    else
                    {
                        MessageBox.Show("Продажа может проходить только в пределах от 30 тыс. у.е.до 1, 5 млн.у.е.");
                        return;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Неверный формат данных при операции с ценой продажи"); return;
                }
            }
            ITransProcess transProcess = ProcessFactory.GetTransProcess();
            if (_transactionid == 0)
                transProcess.Add(transaction);
            else
            {
                transaction.TransactionID = _transactionid;
                transProcess.Update(transaction);
            }            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void cbWork_LostFocus(object sender, RoutedEventArgs e)
        {
            this.LoadWork(this.cbWork.Text);
        }

        private void cbWork_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(this.status=="sale")
            {
                WorkDto work = cbWork.SelectedItem as WorkDto;
                if (work != null) this._transactionid = FindTransaction(work.WorkID);
                loadTransaction(this._transactionid);

            }
        }
        private int FindTransaction(int workid)
        {
            IList<TransDto> transes = ProcessFactory.GetTransProcess().GetList();
            foreach (TransDto t in transes)
            {
                if (t.Work.WorkID == workid & t.Customer == null)
                {
                    return t.TransactionID;
                }
            }
            return -1;
        }
        private void loadTransaction(int transId)
        {
            TransDto trans = ProcessFactory.GetTransProcess().Get(transId);
            this.dpAcuired.Text = trans.DateAcquired.ToString();
            this.dpAcuired.IsEnabled = false;
            this.tbAcquisitionPrice.Text = trans.AcquisitionPrice.ToString();
            this.tbAcquisitionPrice.IsEnabled = false;
            this.tbAskingPrice.Text = trans.AskingPrice.ToString();
            this.tbAskingPrice.IsEnabled = false;
        }        private WorkDto selectWork()
        {
            WorkDto work = null;
            foreach (WorkDto w in Works)
            {
                if (w.Copy == this.cbCopy.Text && w.Title == this.cbWork.Text)
                { work = w; break; }
            }
            return work;
        }        private bool workAtGalery(WorkDto work)
        {
            return FreeForSale.Contains(work);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (status == "purchase")
            {
                GetWorksWithCustomers();
                this.cbWork.ItemsSource = this.FreeForPurchase;
                this.cbCustomer.IsEnabled = false;
                this.tbSalesPrice.IsEnabled = false;
                this.dpPurchase.IsEnabled = false;
            }
            if (status == "sale")
            {
                this.cbWork.ItemsSource = FreeForSale;
            }
        }
        private void GetWorksWithCustomers()
        {
            IEnumerable<WorkDto> forPurchase = Works.Except(FreeForSale);
            FreeForPurchase = forPurchase.ToList();
        }
    }
}
