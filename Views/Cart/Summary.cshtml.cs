using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MVC.Views.Cart
{
    public class Summary : PageModel
    {
        private readonly ILogger<Summary> _logger;

        public Summary(ILogger<Summary> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}