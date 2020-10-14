using ADOLibrary;
using DemoDAL.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DemoDAL.DAL.Services
{
    public class BrandService : ServiceBase<int, Brand>
    {
        private Brand Convert(SqlDataReader reader)
        {
            return new Brand(
                    (int) reader["Id"],
                    reader["name"].ToString()
                );
        }

        public override Brand Get(int key)
        {
            //Command cmd = new Command("SELECT Id, Name FROM Brand WHERE Id = @id");
            Command cmd = new Command("GetBrandById", true);
            
            cmd.AddParameter("Id", key);

            return connection.ExecuteReader(cmd, Convert).SingleOrDefault();
        }

        public override IEnumerable<Brand> GetAll()
        {
            //Command cmd = new Command("SELECT Id, Name FROM Brand");
            Command cmd = new Command("GetAllBrand", true);

            return connection.ExecuteReader(cmd, Convert);
        }

        public override int Insert(Brand entity)
        {
            //Command cmd = new Command("INSERT INTO Brand (Name) OUTPUT inserted.id VALUES (@name)");
            int result;
            Command cmd = new Command("AddBrand", true);
            cmd.AddParameter("Name", entity.Name);
            try
            {
                result = (int)connection.ExecuteScalar(cmd);
            }
            catch(Exception e)
            {
                result = 0;
                throw e;
            }
            
            return result;
        }

        public override bool Update(Brand entity)
        {
            Command cmd = new Command("UpdateBrand", true);
            cmd.AddParameter("Id", entity.Id);
            cmd.AddParameter("Name", entity.Name);

            return connection.ExecuteNonQuery(cmd) == 1;
        }

        public override bool Delete(int key)
        {
            //Command cmd = new Command("DELETE FROM Brand WHERE Id = @id");
            Command cmd = new Command("DeleteBrand", true);
            cmd.AddParameter("Id", key);

            return connection.ExecuteNonQuery(cmd) == 1;
        }
    }
}
