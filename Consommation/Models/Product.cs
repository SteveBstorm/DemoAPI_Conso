using System;
using System.Collections.Generic;
using System.Text;

namespace Consommation.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CodeEAN13 { get; set; }
        public int BrandId { get; set; }
    }
}
