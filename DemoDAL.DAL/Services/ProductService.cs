using ADOLibrary;
using DemoDAL.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DemoDAL.DAL.Services
{
    public class ProductService : ServiceBase<int, Product>
    {
        private Product Converter(SqlDataReader reader)
        {
            return new Product(
                (int)reader["Id"],
                reader["Name"].ToString(),
                (decimal)reader["Price"],
                reader["EAN13"].ToString(),
                (int)reader["BrandId"]);
        }

        public ProductService(Connection connection) : base(connection)
        {

        }

        public override bool Delete(int key)
        {
            Command cmd = new Command("DeleteProduct", true);
            cmd.AddParameter("Id", key);

            return Connection.ExecuteNonQuery(cmd) == 1;
        }

        public override Product Get(int key)
        {
            Command cmd = new Command("GetProductById", true);
            cmd.AddParameter("Id", key);

            return Connection.ExecuteReader<Product>(cmd, Converter).FirstOrDefault();
        }

        public override IEnumerable<Product> GetAll()
        {
            Command cmd = new Command("GetAllProduct", true);

            return Connection.ExecuteReader<Product>(cmd, Converter);
        }

        public override int Insert(Product entity)
        {
            Command cmd = new Command("AddProduct", true);
            cmd.AddParameter("Name", entity.Name);
            cmd.AddParameter("EAN13", entity.CodeEAN13);
            cmd.AddParameter("BrandId", entity.BrandId);
            cmd.AddParameter("Price", entity.Price);

            return Connection.ExecuteNonQuery(cmd);
        }

        public override bool Update(Product entity)
        {
            Command cmd = new Command("UpdateProduct", true);
            cmd.AddParameter("Name", entity.Name);
            cmd.AddParameter("EAN13", entity.CodeEAN13);
            cmd.AddParameter("BrandId", entity.BrandId);
            cmd.AddParameter("Price", entity.Price);
            cmd.AddParameter("Id", entity.Id);

            return Connection.ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<Product> GetByBrandId(int key)
        {
            Command cmd = new Command("GetProductByBrandId", true);
            cmd.AddParameter("Id", key);

            return Connection.ExecuteReader<Product>(cmd, Converter);
        }
    }
}
