using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDAL.DAL.Models
{
    public class Product : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CodeEAN13 { get; set; }
        public int BrandId { get; set; }

        public Product()
        {

        }

        public Product(string name, decimal price, string codeEAN13, int brandId)
        {
            this.Name = name;
            this.Price = price;
            this.CodeEAN13 = codeEAN13;
            this.BrandId = brandId;
        }

        internal Product(int id, string name, decimal price, string codeEAN13, int brandId)
            : this(name, price, codeEAN13, brandId)
        {
            this.Id = id;
        }
    }
}
