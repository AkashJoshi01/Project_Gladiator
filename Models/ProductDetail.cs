using System;
using System.Collections.Generic;

#nullable disable

namespace Project_Gladiator.models
{
    public partial class ProductDetail
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public string Availability { get; set; }
    }
}
