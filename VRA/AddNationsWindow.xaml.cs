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
    /// Логика взаимодействия для AddNationsWindow.xaml
    /// </summary>
    public partial class AddNationsWindow : Window
    {
        public AddNationsWindow()
        {
            InitializeComponent();
        }
        private int _id;
        public void Load(NationDto nation)
        {
            if (nation == null)
                return;
            _id = nation.NationID;
            tbNation.Text = nation.Nationality;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(tbNation.Text))
            {
                MessageBox.Show("Национальность не должна быть пустой", "Проверка");
                return;
            }
            NationDto nation = new NationDto();
            nation.Nationality = tbNation.Text;
            INationProcess nationProcess = ProcessFactory.GetNationProcess();
            if(_id==0)
            {
                nationProcess.Add(nation);
            }
            else
            {
                nation.NationID = _id;
                //nationProcess.Update
            }
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
