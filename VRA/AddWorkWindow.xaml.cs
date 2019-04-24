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
    /// Логика взаимодействия для AddWorkWindow.xaml
    /// </summary>
    public partial class AddWorkWindow : Window
    {
        private readonly IList<ArtistDto> Artists = ProcessFactory.GetArtistProcess().GetList();
        private int _workid;
        public void Load(WorkDto work)
        {
            _workid = work.WorkID;
            
            tbCopy.Text = work.Copy;
            tbDescription.Text = work.Description;
            tbTitle.Text = work.Title;
            if(work.Artist!=null)
            {
                foreach(ArtistDto Art in Artists)
                {
                    if(work.Artist.Id==Art.Id)
                    {
                        this.cbArtist.SelectedItem = Art;
                        break;
                    }
                }
            }
        }
        public AddWorkWindow()
        {
            InitializeComponent();
            cbArtist.ItemsSource = (from A in Artists orderby A.Name select A);
            cbArtist.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (cbArtist==null)
            {
                MessageBox.Show("Необходимо выбрать художника", "Проверка");
                return;
            }
            if (string.IsNullOrEmpty(tbCopy.Text))
            {
                MessageBox.Show("Информация о копии не должна быть пустой", "Проверка");
                return;
            }
            if (string.IsNullOrEmpty(tbDescription.Text))
            {
                MessageBox.Show("Описание не должно быть пустым", "Проверка");
                return;
            }
            if (string.IsNullOrEmpty(tbTitle.Text))
            {
                MessageBox.Show("Название картины не должно быть пустым", "Проверка");
                return;
            }
            WorkDto work = new WorkDto();
            work.Artist = cbArtist.SelectedItem as ArtistDto;
            work.Title = tbTitle.Text;
            work.Copy = tbCopy.Text;
            work.Description = tbDescription.Text;
            IWorkProcess workProcess = ProcessFactory.GetWorkProcess();
            if(_workid==0)
            {
                workProcess.Add(work);
            }
            else
            {
                work.WorkID = _workid;
                workProcess.Update(work);
            }
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
