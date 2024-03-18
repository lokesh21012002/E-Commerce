using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.Data;
using MVC.Models;

namespace MVC.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository

    {

        private readonly ApplicationDbContext _db;
        public OrderDetailRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;



        }

        public void Update(OrderDetail obj)
        {
            _db.OrderDetails.Update(obj);


        }
    }
}