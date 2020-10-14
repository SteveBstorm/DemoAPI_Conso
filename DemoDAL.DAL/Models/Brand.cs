using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDAL.DAL.Models
{
    public class Brand : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Brand()
        {

        }

        public Brand(string name)
        {
            this.Id = 0;
            this.Name = name;
        }

        internal Brand(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
