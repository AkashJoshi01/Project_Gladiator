using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Gladiator.ViewModel
{
    public class PurchaseHistory
    {
        [Key]
        public int CustId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int PaidAmt { get; set; }
        public int ProductPrice { get; set; }

    }
}
