using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MVC.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetALL();
        T Get(Expression<Func<T, bool>> filter);


        void Add(T item);



        void Remove(T item);


        void RangeRemove(IEnumerable<T> items);











    }
}