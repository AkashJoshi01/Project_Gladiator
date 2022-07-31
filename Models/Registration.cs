using System;
using System.Collections.Generic;

#nullable disable

namespace Project_Gladiator.models
{
    public partial class Registration
    {
        public Registration()
        {
            CardDetails = new HashSet<CardDetail>();
            Transactions = new HashSet<Transaction>();
        }

        public int CustId { get; set; }
        public string CustName { get; set; }
        public DateTime CustDob { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmedPassword { get; set; }
        public string CardType { get; set; }
        public string BankAccNo { get; set; }
        public string Ifsc { get; set; }
        public Boolean Rstatus { get; set; }

        public virtual ICollection<CardDetail> CardDetails { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
