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
using System.Windows.Threading;

namespace OnlineSchool
{
    /// <summary>
    /// Логика взаимодействия для UpcomingRecordWindow.xaml
    /// </summary>
    public partial class UpcomingRecordWindow : Window
    {
        List<Record> recordList;
        OnlineSchoolEntities1 onlineSchool = new OnlineSchoolEntities1();

        private int _tickCounter = 0;
        private int _refreshTime = 30;
        public UpcomingRecordWindow()
        {
            InitializeComponent();
            GetClientServices();


            var timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _tickCounter++;
            if (_tickCounter % _refreshTime == 0)
            {
                GetClientServices();
            }
        }
        private void GetClientServices()
        {
            recordList = onlineSchool.Record.ToList();
            RecordsList.ItemsSource = recordList;

            recordList = recordList.OrderByDescending(c => c.StartDate).ToList();
        }
        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {

            ServiceListWindow serviceListWindow = new ServiceListWindow();
            this.Close();
            serviceListWindow.Show();
        }
    }
}
