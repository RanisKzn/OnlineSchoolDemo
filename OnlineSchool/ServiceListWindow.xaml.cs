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

namespace OnlineSchool
{
    /// <summary>
    /// Логика взаимодействия для ServiceListWindow.xaml
    /// </summary>
    public partial class ServiceListWindow : Window
    {
        List<Service> serviceList;
        OnlineSchoolEntities1 onlineSchool = new OnlineSchoolEntities1  ();
        public ServiceListWindow()
        {
            InitializeComponent();
            serviceList = onlineSchool.Service.ToList();
            ServiceList.ItemsSource = serviceList;
            CurrentTotalCountTB.Text = $"{serviceList.Count} | {serviceList.Count}";

            FiterCB.ItemsSource = new List<String>() 
            { 
                "Все","0 - 5%", "5% - 15%", "15% - 30%", "30% - 70%", "70% - 100%" 
            };
            SortderCB.ItemsSource = new List<String>() 
            { 
                "По возромтанию","По убыванию"
            };


        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            setServiceList();
        } 
        
        private void FikterCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            setServiceList();
        }

        private void SortderCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            setServiceList();
        }

        private void setServiceList()
        {
            var services = serviceList;
            var filteredService = getByFilter(services);
            var searchedService = getBySearch(filteredService);
            var sorteredService = getBySorter(searchedService);

            CurrentTotalCountTB.Text = $"{sorteredService.Count} | {serviceList.Count}";
            ServiceList.ItemsSource = sorteredService;

        }

        private List<Service> getByFilter(List<Service> services)
        {
            switch(FiterCB.SelectedIndex)
            {
                case 0:
                    return services;
                case 1:
                    return services.Where(x => x.Amount > 0 && x.Amount < 5).ToList();
                case 2:
                    return services.Where(x => x.Amount > 5 && x.Amount < 15).ToList();
                case 3:
                    return services.Where(x => x.Amount > 15 && x.Amount < 30).ToList();
                case 4:
                    return services.Where(x => x.Amount > 30 && x.Amount < 70).ToList();
                case 5:
                    return services.Where(x => x.Amount > 70 && x.Amount < 100).ToList();
            }
            return services;
        }
        private List<Service> getBySorter(List<Service> services)
        {
            switch(SortderCB.SelectedIndex)
            {
                case 0:
                    return services.OrderBy(x => x.Cost).ToList();
                case 1:
                    return services.OrderByDescending(x => x.Cost).ToList();
            }
            return services;
        }

        private List<Service> getBySearch(List<Service> services)
        {
            if(string.IsNullOrEmpty(SearchTB.Text))
            {
                return services;
            }
            else
            {
                services = services.Where(x => x.ServiceName.Contains(SearchTB.Text)).ToList();
                return services;
            }
            
        }

        private void ChangeBTN_Click(object sender, RoutedEventArgs e)
        {
            if((sender as Button).DataContext is Service service)
            {
                ChangeServicesWindow changeServicesWindow = new ChangeServicesWindow(service);
                this.Close();
                changeServicesWindow.Show();
            }
        }

        private void DeleteBTN_Click(object sender, RoutedEventArgs e)
        {
            if((sender as Button).DataContext is Service service)
            {
                var records = onlineSchool.Record.Where(x => x.ServiceId == service.SericeId).ToList();
                if (records.Count > 0)
                {
                    MessageBox.Show("Нельзя удалять!");
                    return;
                }
                string messageBoxText =  $"Вы правда хотите удалить этот {service.ServiceName} объект?";
                string caption = "Word Processor";
                MessageBoxButton button = MessageBoxButton.YesNoCancel;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
               
                if (result == MessageBoxResult.Yes)
                {
                    using (OnlineSchoolEntities1 context = new OnlineSchoolEntities1())
                    {
                        context.Service.Remove(service);
                        context.SaveChanges();
                    }
                }
            }
            
        }

        private void AddServiceBTN_Click(object sender, RoutedEventArgs e)
        {
            AddServiceWindow addServiceWindow = new AddServiceWindow();
            this.Close();
            addServiceWindow.Show();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if ((sender as Grid).DataContext is Service service)
            {
                RecordServiceWindow recordServiceWindow = new RecordServiceWindow(service);
                this.Close();
                recordServiceWindow.Show();
            }
        }

        private void ShowRecordsBTN_Click(object sender, RoutedEventArgs e)
        {
            UpcomingRecordWindow upcomingRecordWindow = new UpcomingRecordWindow();
            this.Close();
            upcomingRecordWindow.Show();
        }
    }
}
