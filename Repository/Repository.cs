using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Repository;





namespace MVC.Repository
{
    public class Repository<T> : IRepository<T> where T : class

    {

        private readonly ApplicationDbContext _db;
        internal DbSet<T> _dbSet;



        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this._dbSet = _db.Set<T>();
            _db.Products.Include(u => u.Category);








        }
        public void Add(T item)
        {
            _dbSet.Add(item);



            // throw new NotImplementedException();
        }

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> filter, string? inlcudeProperties = null)
        {
            // _dbSet.
            IQueryable<T> query = _dbSet;
            query.Where(filter);
            if (!string.IsNullOrEmpty(inlcudeProperties))
            {
                foreach (var includeprop in inlcudeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query.Include(includeprop);



                }
            }
            return query.FirstOrDefault();



            // throw new NotImplementedException();
        }

        public IEnumerable<T> GetALL(string? inlcudeProperties = null)
        {
            IQueryable<T> query = _dbSet;

            if (!string.IsNullOrEmpty(inlcudeProperties))
            {
                foreach (var includeprop in inlcudeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query.Include(includeprop);



                }
            }

            return query.ToList();

            // throw new NotImplementedException();
        }

        public void RangeRemove(IEnumerable<T> items)
        {

            _dbSet.RemoveRange(items);
            // throw new NotImplementedException();
        }

        public void Remove(T item)
        {
            _dbSet.Remove(item);

            // throw new NotImplementedException();
        }
    }


}