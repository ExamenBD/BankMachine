using BankMachine.SqlLiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace BankMachine
{
    /// <summary>
    /// Логика взаимодействия для GiveOutMoney.xaml
    /// </summary>
    public partial class GiveOutMoney : Page
    {
        public GiveOutMoney()
        {
            InitializeComponent();
        }

        private void EnterSumButton_Click(object sender, RoutedEventArgs e)
        {
            if (Data.UserEnterCard.balance >= Convert.ToDouble(SumMoneyOut.Text) )
            {
                LabelMessage.Content = "";
                Data.UserEnterCard.balance = Data.UserEnterCard.balance - Convert.ToDouble(SumMoneyOut.Text);
                DBContext.UpdateData(Data.UserEnterCard);
                MessageBox.Show($"дата:{DateTime.Now.ToShortDateString()} \n время:{DateTime.Now.ToShortTimeString()} \n" +
                    $" номер банкомата:Банкомат№214 \n номер карты:**** **** **** {Data.LastFourNumberCard()}" +
                    $" \n сумма операции:{SumMoneyOut.Text} \n остаток по карте:{Data.UserEnterCard.balance}");
                SumMoneyOut.Clear();
            }
            else
            {
                LabelMessage.Content = "Недостаточно средств!";
            }
        }

        private void SumMoneyOut_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[0-9]$");
        }

        private void BackPage_Click(object sender, RoutedEventArgs e)
        {
            Data.MainFrame.GoBack();
        }
    }
}
