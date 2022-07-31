using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Project_Gladiator.ViewModel
{
    public class balamt
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int TransactionId { get; set; }
        public int CustId { get; set; }
        public int PaidAmt { get; set; }
    }
}
