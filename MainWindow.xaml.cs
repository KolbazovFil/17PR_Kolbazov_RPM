using _17PR_Kolbazov_RPM.Pages;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace _17PR_Kolbazov_RPM
{
    public partial class MainWindow : Window
    {
        // Создаем коллекцию транзакций
        public ObservableCollection<MainPage.Transaction> Transactions { get; set; } = new ObservableCollection<MainPage.Transaction>();

        public MainWindow()
        {
            InitializeComponent();
            mainFrame.Navigate(new MainPage(Transactions)); // Передаем коллекцию в MainPage
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
            // Передаем коллекцию транзакций в AddIncomePage
            mainFrame.Navigate(new AddIncomePage(Transactions));
        }

        private void BtnAddExpensePage_Click(object sender, RoutedEventArgs e)
        {
            // Передаем коллекцию транзакций в AddExpensePage
            mainFrame.Navigate(new AddExpensePage(Transactions));
        }
    }
}