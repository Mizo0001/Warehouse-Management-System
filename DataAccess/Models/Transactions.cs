using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Transactions
    {
        public int TransactionID { get; set; }
        public int ProductId { get; set; }
        public int TransactionTypeID { get; set; }
        public int Quantity { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
