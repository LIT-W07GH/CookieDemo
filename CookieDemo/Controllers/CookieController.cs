using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookieDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CookieDemo.Controllers
{
    public class CookieController : Controller
    {
        public IActionResult Index()
        {
            string value = Request.Cookies["random"];
            bool isFirstTime = String.IsNullOrEmpty(value);
            int randomNumber;
            if (isFirstTime)
            {

                Random rnd = new Random();
                randomNumber = rnd.Next(1, 1000);
                Response.Cookies.Append("random", $"{randomNumber}");
            }
            else
            {
                randomNumber = int.Parse(value);
            }

            CookieIndexViewModel vm = new CookieIndexViewModel
            {
                RandomNumber = randomNumber,
                IsFirstTime = isFirstTime
            };
            return View(vm);
        }
    }
}