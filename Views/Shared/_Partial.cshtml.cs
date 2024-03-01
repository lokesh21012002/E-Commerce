using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MVC.Views.Shared
{
    public class _Partial : PageModel
    {
        private readonly ILogger<_Partial> _logger;

        public _Partial(ILogger<_Partial> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}