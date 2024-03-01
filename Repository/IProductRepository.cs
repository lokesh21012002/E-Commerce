using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.Models;

namespace MVC.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);
        void Save();



    }
}