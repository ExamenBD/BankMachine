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
using BankMachine;

namespace BankMachine
{
    /// <summary>
    /// Логика взаимодействия для MainCardPage.xaml
    /// </summary>
    public partial class MainCardPage : Page
    {
        public MainCardPage()
        {
            InitializeComponent();
        }

        private void WithdrawMoneyButton_Click(object sender, RoutedEventArgs e)
        {
            Data.MainFrame.Navigate(new GiveOutMoney());
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Data.UserEnterCard = null;
            Data.MainFrame.Navigate(new StartPage());
        }

        private void BalanceCard_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("На вашем счёте:" + Data.UserEnterCard.balance);
        }
    }
}
