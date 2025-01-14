using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using _17PR_Kolbazov_RPM.Pages;


namespace _17PR_Kolbazov_RPM.Pages
{
    public partial class AddExpensePage : Page
    {
        private ObservableCollection<MainPage.Transaction> _transactions;

        // Конструктор, принимающий коллекцию транзакций
        public AddExpensePage(ObservableCollection<MainPage.Transaction> transactions)
        {
            InitializeComponent();
            _transactions = transactions; // Сохраняем ссылку на коллекцию
        }

        private void ButSaveExpense_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(SumExpense.Text, out decimal amount) && ExpenseCategory.SelectedItem != null)
            {
                var selectedItem = ExpenseCategory.SelectedItem as ComboBoxItem; // Приводим к типу ComboBoxItem

                // Создаем новый объект Transaction
                var newTransaction = new MainPage.Transaction
                {
                    Type = "Расход", // Указываем тип транзакции
                    Amount = -amount, // Сохраняем расходы как отрицательные значения
                    Date = DateTime.Now.ToString("dd.MM.yyyy"), // Указываем текущую дату
                    Category = selectedItem != null ? selectedItem.Content.ToString() : string.Empty // Получаем текст выбранного элемента
                };

                // Добавляем новую транзакцию в коллекцию
                _transactions.Add(newTransaction);

                MessageBox.Show("Расход сохранен!");

                // Возвращаемся на главную страницу
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректную сумму и выберите категорию.");
            }
        }
    }
}