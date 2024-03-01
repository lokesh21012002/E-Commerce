using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.Models;

namespace MVC.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
        void Save();


    }
}