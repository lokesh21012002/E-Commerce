using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Services
{
    public class Transist : ItransistService
    {
        public string GUId()
        {
            return Guid.NewGuid().ToString();
        }
    }


}