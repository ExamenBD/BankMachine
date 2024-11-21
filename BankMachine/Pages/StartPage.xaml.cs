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
using System.Xml;

namespace BankMachine
{
    /// <summary>
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        private string realText = "";

        public StartPage()
        {
            InitializeComponent();
            
        }

        private void DeleteText_Click(object sender, RoutedEventArgs e)
        {
            MaskedTextBox.Clear();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (Data.CheckCardNumber(realText))
            {
                if (Data.UserEnterCard.status_id !=2)
                {
                    Data.MainFrame.Navigate(new PinPage());
                }
                else
                {
                    MessageBox.Show("Карта заблокирована");
                }
            }
            else
            {
                MessageBox.Show("Карта не найдена");
            }
        }

        private void MaskedTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[0-9]$");
        }

        private void MaskedTextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string numbers = "0123456789";
            if (textBox.Text.Length > 3 & textBox.Text.Length < 5)
                textBox.Text = textBox.Text.Insert(4, "-");
            if (textBox.Text.Length > 8 & textBox.Text.Length < 10)
                textBox.Text = textBox.Text.Insert(9, "-");
            if (textBox.Text.Length > 13 & textBox.Text.Length < 15)
                textBox.Text = textBox.Text.Insert(14, "-");
            if (textBox.Text.Length > realText.Length)
            {
                realText += textBox.Text.Substring(realText.Length);
            }
            if (textBox.Text.Length == 4 & textBox.Text.Length == 9 & textBox.Text.Length == 14)
            {
                textBox.Text = textBox.Text.Remove(textBox.Text.Length - 2, 2);
            }
            else if (textBox.Text.Length < realText.Length)
            {
                realText = realText.Substring(0, textBox.Text.Length);
            }
            textBox.SelectionStart = textBox.Text.Length;
            foreach (char a in numbers)
            {
                textBox.Text = textBox.Text.Replace(a, '*');
            } 
        }
    }
}
