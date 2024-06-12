using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata;
using MVC.Data;
using MVC.Models;
using Mysqlx.Crud;
using NUnit.Framework.Internal;

namespace MVC.Controllers
{
    [ApiController]
    public class UseCompleteController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        private readonly IMapper mapper;

        public UseCompleteController(ApplicationDbContext _db)
        {
            db = _db;
            mapper = new SqlMapper(new MapperConfiguration(cfg)=>{
                cfg.CreateMap<Order,OrderDetail>();




            });

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

        public Product authHelper()
        {

            string sqlAuth = @"EXEC SP_GETAUTH @Email=@email @Password=@password";

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            SqlParameter email = new SqlParameter("@email", SqlDbType.VarChar);
            email.Value = "admin@gmail.com";
            sqlParameters.Add(email);
            SqlParameter password = new SqlParameter("@password", SqlDbType.VarChar);
            password.Value = "admin@gmail.com";
            sqlParameters.Add(password);

            return db.ExcecuteSqlWithParameters(sqlAuth, sqlParameters);


        }

        public Product tokenHelper()
        {

            string sqlAuth = @"EXEC SP_GETAUTH @Email=@email @Password=@password";

            DynamicParameters sql = new DynamicParameters();
            sql.Add("@Email", "test@gmail.com", DbType.String);
            sql.Add("@Password", "test@gmail.com", DbType.String);
            return db.ExcecuteSqlWithParameters(sqlAuth, sql);


            // List<SqlParameter> sqlParameters = new List<SqlParameter>();
            // SqlParameter email = new SqlParameter("@email", SqlDbType.VarChar);
            // email.Value = "admin@gmail.com";
            // sqlParameters.Add(email);
            // SqlParameter password = new SqlParameter("@password", SqlDbType.VarChar);
            // password.Value = "admin@gmail.com";
            // sqlParameters.Add(password);

            // return db.ExcecuteSqlWithParameters(sqlAuth, sqlParameters);


        }

        public Order autoMapper(Order order)
        {
            // auomapper which maps the order to the OrderDetail
            Order order = mapper.Map<Order>(OrderDetail);

            return order;





        }




    }
}