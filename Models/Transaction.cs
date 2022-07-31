using System;
using System.Collections.Generic;

#nullable disable

namespace Project_Gladiator.models
{
    public partial class Transaction
    {
        public int TransactionId { get; set; }
        public int CustId { get; set; }
        public int ProductId { get; set; }
        public int PaidAmt { get; set; }
        public int BalanceAmt { get; set; }
        public int? Emi { get; set; }
        public int Tenure { get; set; }

        public virtual Registration Cust { get; set; }
    }
}
