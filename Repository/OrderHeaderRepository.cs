using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MVC.Data;
using MVC.Models;

namespace MVC.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {

        private readonly ApplicationDbContext _db;
        public OrderHeaderRepository(ApplicationDbContext db) : base(db)
        {

            _db = db;

        }

        public void Update(OrderHeader obj)
        {
            throw new NotImplementedException();
        }

        public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
        {
            throw new NotImplementedException();
        }

        public void UpdateStripePaymentID(int id, string sessionId, string paymentIntentId)
        {
            throw new NotImplementedException();
        }
    }
}