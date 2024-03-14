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
        public OrderDetailRepository(ApplicationDbContext db) : base(db)
        {



        }
    }
}