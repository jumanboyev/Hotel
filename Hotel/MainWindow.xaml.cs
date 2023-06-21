using Hotel.Pages;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hotel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if(this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else this.WindowState = WindowState.Maximized;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
                this.WindowState = WindowState.Minimized;          
        }

        private void brDragbale_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void rbDashboard_Click(object sender, RoutedEventArgs e)
        {
            DashboardPage dashboardPage=new DashboardPage();
            PageNavigator.Content=dashboardPage;
        }

        private void rbRoom_Click(object sender, RoutedEventArgs e)
        {
            RoomPage roomPage=new RoomPage();
            PageNavigator.Content=roomPage;
        }

        private void rbClient_Click(object sender, RoutedEventArgs e)
        {
            ClientPage clientPage=new ClientPage();
            PageNavigator.Content=clientPage;
        }

        private void rbEmployee_Click(object sender, RoutedEventArgs e)
        {
            EmployeePage employeePage=new EmployeePage();
            PageNavigator.Content=employeePage;
        }

        private void rbPayment_Click(object sender, RoutedEventArgs e)
        {
            PaymentPage paymentPage=new PaymentPage();
                PageNavigator.Content=paymentPage;
        }

        private void rbInformation_Click(object sender, RoutedEventArgs e)
        {
            InformationPage informationPage=new InformationPage();  
            PageNavigator.Content=informationPage;
        }

        private void rbDetail_Click(object sender, RoutedEventArgs e)
        {
            DetailPage detailPage=new DetailPage();
                PageNavigator.Content=detailPage;
        }
    }
}
