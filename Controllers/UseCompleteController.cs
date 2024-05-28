using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Data;
using MVC.Models;

namespace MVC.Controllers
{
    [ApiController]
    public class UseCompleteController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public UseCompleteController(ApplicationDbContext _db)
        {
            db = _db;

        }

        [HttpGet("/api/users/all")]

        public IEnumerable<Product> getAllProducts()
        {
            string sql = @"EXEC GETALLUSERS_ST";

            IEnumerable<Product> users = db.LoadData<Product>(sql);
            return users.ToList();




        }

        [HttpGet("/api/users/{id}")]

        public Product getProductByID(int id)
        {

            string sql = @"EXEC USP_GETPRODUCTBYID ";

            if (id > 0)
            {

                sql += " @id=" + id.ToString();



            }

            Product product = db.LoadData<Product>(sql);
            return product;



        }




    }
}