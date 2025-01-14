using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace _17PR_Kolbazov_RPM.Pages
{
    public partial class MainPage : Page
    {
        public ObservableCollection<Transaction> Transactions { get; set; }

        // Конструктор, принимающий коллекцию транзакций
        public MainPage(ObservableCollection<Transaction> transactions)
        {
            InitializeComponent();
            Transactions = transactions; // Сохраняем ссылку на коллекцию
            TransactionList.ItemsSource = Transactions; // Привязка коллекции к элементу управления
        }

        private void BtnAddIncomePage_Click(object sender, RoutedEventArgs e)
        {
            // Передаем коллекцию транзакций в AddIncomePage
            AddIncomePage addIncomePage = new AddIncomePage(Transactions);
            NavigationService.Navigate(addIncomePage);
        }

        public class Transaction
        {
            public string Type { get; set; }
            public decimal Amount { get; set; }
            public string Date { get; set; }
            public string Category { get; set; }
        }
    }
}
