using _17PR_Kolbazov_RPM.Pages;
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

namespace _17PR_Kolbazov_RPM
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainFrame.Navigate(new MainPage()); // Инициализация с MainPage
        }
        private void ButtonBack_OnClick(object sender, RoutedEventArgs e)
        {
            if (mainFrame.CanGoBack) mainFrame.GoBack();
        }
        private void MainFrame_OnNavigated(object sender, NavigationEventArgs e)
        {
            if (!(e.Content is Page page)) return;
            this.Title = $"17ПР_Колбазов - {page.Title}";

            if (page is Pages.MainPage)
                ButtonBack.Visibility = Visibility.Hidden;

            else
                ButtonBack.Visibility = Visibility.Visible;
        }
        private void BtnAddIncomePage_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new AddIncomePage());
        }
        private void BtnAddExpensePage_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new AddExpensePage());
        }
    }
}