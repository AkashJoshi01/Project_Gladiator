using System;
using System.Collections.Generic;

#nullable disable

namespace Project_Gladiator.models
{
    public partial class CardDetail
    {
        public long CardNo { get; set; }
        public int CustId { get; set; }
        public DateTime ValidTill { get; set; }
        public string CardStatus { get; set; }
        public int TotalCredit { get; set; }
        public int RemainingCredit { get; set; }

        public virtual Registration Cust { get; set; }
    }
}
