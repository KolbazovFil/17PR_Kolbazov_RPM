using _17PR_Kolbazov_RPM.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static _17PR_Kolbazov_RPM.Pages.MainPage;

namespace _17PR_Kolbazov_RPM
{
    public partial class AddIncomePage : Page
    {
        private ObservableCollection<MainPage.Transaction> _transactions;

        // Конструктор, принимающий коллекцию транзакций
        public AddIncomePage(ObservableCollection<MainPage.Transaction> transactions)
        {
            InitializeComponent();
            _transactions = transactions; // Сохраняем ссылку на коллекцию
        }
        private void ButSaveIncome_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(SumIncome.Text, out decimal amount) && (IncomeCategory.SelectedItem != null || !string.IsNullOrEmpty(NewCatIncome.Text)))
            {
                string category;

                if (IncomeCategory.SelectedItem != null)
                {
                    var selectedItem = IncomeCategory.SelectedItem as ComboBoxItem; // Приводим к типу ComboBoxItem
                    category = selectedItem != null ? selectedItem.Content.ToString() : string.Empty;
                }
                else
                {
                    category = NewCatIncome.Text.Trim(); // Используем текст из TextBox
                }

                // Создаем новый объект Transaction
                var newTransaction = new MainPage.Transaction
                {
                    Type = "Доход", // Указываем тип транзакции
                    Amount = amount, // Получаем сумму из текстового поля
                    Date = DateTime.Now.ToString("dd.MM.yyyy"), // Указываем текущую дату
                    Category = category // Получаем категорию
                };

                // Добавляем новую транзакцию в коллекцию
                _transactions.Add(newTransaction);

                MessageBox.Show("Доход сохранен!");

                // Возвращаемся на главную страницу
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректную сумму и выберите или добавьте категорию.");
            }
        }

        private void BtnAddCategory_Click(object sender, RoutedEventArgs e)
        {
            string newCategory = NewCatIncome.Text.Trim();

            if (!string.IsNullOrEmpty(newCategory))
            {
                // Добавляем новую категорию в ComboBox
                IncomeCategory.Items.Add(new ComboBoxItem { Content = newCategory });
                NewCatIncome.Clear(); // Очищаем TextBox после добавления
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите название категории.");
            }
        }
    }
}