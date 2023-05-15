using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

namespace OnlineSchool
{
    /// <summary>
    /// Логика взаимодействия для RecordServiceWindow.xaml
    /// </summary>
    public partial class RecordServiceWindow : Window
    {
        List<Service> services;
        OnlineSchoolEntities1 onlineSchool = new OnlineSchoolEntities1();
        public RecordServiceWindow( Service service)
        {
            InitializeComponent();

            Service.DataContext = service;
            ClientListCB.ItemsSource = onlineSchool.Client.ToList();

        }

        private void ClientListCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void EnterBTN_Click(object sender, RoutedEventArgs e)
        {
            using (OnlineSchoolEntities1 context = new OnlineSchoolEntities1())
            {
                var service = (Service)Service.DataContext;
                var time = Convert.ToDateTime(TimeTB.Text);
                var calendarDate = Datecalendar.SelectedDate;
                var startDate = new DateTime(calendarDate.Value.Year, calendarDate.Value.Month, calendarDate.Value.Day, time.Hour, time.Minute, time.Second);
                var record = new Record()
                {
                    ServiceId = service.SericeId,
                    ClientId = ((Client)ClientListCB.SelectedItem).ClientId,
                    StartDate = startDate

                };
                context.Record.AddOrUpdate(record);
                context.SaveChanges();

            }
            MessageBox.Show("Сохранено");
            ServiceListWindow serviceListWindow = new ServiceListWindow();
            this.Close();
            serviceListWindow.Show();
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            ServiceListWindow serviceListWindow = new ServiceListWindow();
            this.Close();
            serviceListWindow.Show();
        }

        private void Datecalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void TimeTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (
                !Char.IsDigit(e.Text, 0) &&
                e.Text[0] != ':'
                )
            {
                e.Handled = true;
            }
        }
    }
}
