using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTree.Controllers
{
    public class appController : Controller 
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
