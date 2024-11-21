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

namespace BankMachine
{
    /// <summary>
    /// Логика взаимодействия для PinPage.xaml
    /// </summary>
    public partial class PinPage : Page
    {
        
        public PinPage()
        {
            InitializeComponent();
            
        }

        private void DeleteText_Click(object sender, RoutedEventArgs e)
        {
            PinCodeNumberBox.Clear();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (Data.CheckPinCode(PinCodeNumberBox.Password))
            {
                Data.MainFrame.Navigate(new MainCardPage());
            }
            else
            {
                ErrorLabel.Content = "Неправильный пин код";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Data.MainFrame.Navigate(new StartPage());
        }
    }
}
