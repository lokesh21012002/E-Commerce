using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using MVC.Data;
using MVC.Models;
using MySqlX.XDevAPI.Common;

namespace MVC.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;

        private readonly ISqlConnectionFactory _isqlConnectionFactory;
        public ProductRepository(ApplicationDbContext db, ISqlConnectionFactory sqlConnectionFactory) : base(db)
        {
            _db = db;
            _isqlConnectionFactory = sqlConnectionFactory;



        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Product product)
        {
            _db.Update(product);

        }


        public async Task<Product> getProductById(int id)
        {
            // var sqlConnection = new SqlConnection()
            await using var sqlConnection = _isqlConnectionFactory.GetSqlConnection();
            // Product? product = await sqlConnection.QueryFirstOrDefaultAsync<Product>($"select * from Products where Id={id}");
            Product? product = await sqlConnection.QueryFirstOrDefaultAsync<Product>(
                @"select * from Products where Id=@id", new { id }
            );
            return product;








        }
    }
}