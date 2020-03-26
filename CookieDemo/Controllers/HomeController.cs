using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CookieDemo.Models;

namespace CookieDemo.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            int number = 1;
            string value = Request.Cookies["number"];
            if (!String.IsNullOrEmpty(value))
            {
                number = int.Parse(value) + 1;
            }
            
            Response.Cookies.Append("number", $"{number}");
            

            HomePageViewModel vm = new HomePageViewModel
            {
                Number = number
            };
            return View(vm);
        }
    }
}
