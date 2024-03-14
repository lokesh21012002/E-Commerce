using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.Models;

namespace MVC.Repository
{
    public interface IOrderDetailRepository
    {

        public interface IOrderDetailRepository : IRepository<OrderDetail>
        {
            void Update(OrderDetail obj);


        }

    }
}