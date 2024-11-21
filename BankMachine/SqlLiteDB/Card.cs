using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMachine.SqlLiteDB
{
    public class Card
    {
        public  string numbercard { get; set; }
        public  int pincod { get; set; }
        public  int status_id { get; set; }
        public  double balance { get; set; }
    }
}
