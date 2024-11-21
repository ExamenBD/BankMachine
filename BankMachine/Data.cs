using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using BankMachine.SqlLiteDB;
using Microsoft.Data.Sqlite;


namespace BankMachine
{
    public class Data
    {
        
        private static int CountEnterUserPinCode = 0; 
        public static Frame MainFrame { get; set; }
        public static List<Card> ListCard= new List<Card>();
        public static List<Statuscard> ListStatusCard = new List<Statuscard>();
        public static Card UserEnterCard { get; set; }
        public static bool CheckActivateCard = false;
        

        public static void DataBase()
        {
            DBContext.GetCards();
            DBContext.GetStatus();
        }
        

        public static bool CheckPinCode(string pincode)
        {
            if (Data.UserEnterCard.status_id == 2)
            {
                MessageBox.Show("Карта заблокирована!");
                return false;
            }
            else if (Data.UserEnterCard.pincod.Equals(Convert.ToInt32(pincode)))
            {
                return true;
            }
            else
            {
                CountEnterUserPinCode += 1;
                if(CountEnterUserPinCode == 3) 
                {
                    Data.UserEnterCard.status_id = 2;
                    CountEnterUserPinCode = 0;
                    DBContext.UpdateData(Data.UserEnterCard);
                    MessageBox.Show("Карта заблокировна по причине: превышен лимит ввода пин кода");
                }
                return false;
            }
        }

        public static bool CheckCardNumber(string cardnumber)
        {
            Data.UserEnterCard=Data.ListCard.Where(x=>x.numbercard.Equals(cardnumber.Replace("-",""))).FirstOrDefault();
            return Data.UserEnterCard != null;
        }

        public static string LastFourNumberCard()
        {
            return Data.UserEnterCard.numbercard.Substring(Data.UserEnterCard.numbercard.Length-4);
        }
    }
}
