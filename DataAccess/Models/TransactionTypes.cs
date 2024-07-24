using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class TransactionTypes
    {
        public int TransactionTypeID { get; set; }

        public string TypeName { get; set; }

        public int Change {  get; set; }
    }
}
