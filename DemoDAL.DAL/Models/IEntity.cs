using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDAL.DAL.Models
{
    public interface IEntity<TKey>
    {
        TKey Id { get; }
    }
}
