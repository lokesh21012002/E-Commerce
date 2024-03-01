using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MVC.Views.Student
{
    public class StudentDetails : PageModel
    {
        private readonly ILogger<StudentDetails> _logger;

        public StudentDetails(ILogger<StudentDetails> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}