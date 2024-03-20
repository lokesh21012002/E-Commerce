using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MVC.Views.Cart
{
    public class OrderConfirmation : PageModel
    {
        private readonly ILogger<OrderConfirmation> _logger;

        public OrderConfirmation(ILogger<OrderConfirmation> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}