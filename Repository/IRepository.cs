using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MVC.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetALL(string? inlcudeProperties);
        T Get(Expression<Func<T, bool>> filter, string? inlcudeProperties);


        void Add(T item);



        void Remove(T item);


        void RangeRemove(IEnumerable<T> items);











    }
}