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
    /// Логика взаимодействия для AddServiceWindow.xaml
    /// </summary>
    public partial class AddServiceWindow : Window
    {
        List<Service> services;
        OnlineSchoolEntities1 onlineSchool = new OnlineSchoolEntities1();
        public AddServiceWindow()
        {
            Service service = new Service();
            InitializeComponent();
            ServicesGrid.DataContext = service;
            services = onlineSchool.Service.ToList();
        }

        private void EnterBTN_Click(object sender, RoutedEventArgs e)
        {
            var containService = (Service)ServicesGrid.DataContext;
            if (services.Contains(containService))
            {
                MessageBox.Show("Такая услуга существует");
                return;
            }
            if (Convert.ToInt32(DurationTB.Text) > 240)
            {
                MessageBox.Show("Длительность не должна быть больше 4 часов");
                return;
            }
            using (OnlineSchoolEntities1 context = new OnlineSchoolEntities1())
            {
                var service = (Service)ServicesGrid.DataContext;
                service.DurationTypeId = 1;
                context.Service.AddOrUpdate(service);
                context.SaveChanges();

            }
            MessageBox.Show("Добавлено");
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
    }
}
