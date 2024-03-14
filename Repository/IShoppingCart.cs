using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.Models;

namespace MVC.Repository
{
    public interface IShoppingCart : IRepository<ShoppingCart>
    {
        void Update(ShoppingCart shoppingCart);

        void Save();



    }
}