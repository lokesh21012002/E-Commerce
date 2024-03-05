using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.Models;

namespace MVC.Repository
{
    public interface ICompanyRepository : IRepository<Company>
    {
        void Update(Company company);
        void Save();

    }
}