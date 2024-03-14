using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.Data;
using MVC.Models;

namespace MVC.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCart
    {

        private readonly ApplicationDbContext _db;
        public ShoppingCartRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {

            _db.SaveChanges();


        }

        public void Update(ShoppingCart shoppingCart)
        {

            _db.ShoppingCarts.Update(shoppingCart);


        }
    }
}