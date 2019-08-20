using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            List<Chef> CreatedDishes = dbContext.Chefs.Include(chef=>chef.CreatedDishes).ToList();
            return View(CreatedDishes);
        }
        [HttpGet("new")]
        public IActionResult NewChef()
        {
            return View();
        }

        [HttpPost("newchef")]
        public IActionResult AddChef(Chef newChef)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(newChef);
                dbContext.SaveChanges();
                return Redirect("/");
            }
            else
            {
                return View("NewChef");
            }
        }
/////////////////////////////////////////////////////////////////////////////////
        [HttpGet("dishes")]
        public IActionResult Dishes()
        {
            List<Dish> AllDishes = dbContext.Dishes.Include(dish=>dish.Creator).ToList();
            return View(AllDishes);
        }

        [HttpGet("dishes/new")]
        public IActionResult NewDish()
        {
            List<Chef> AllChefs = dbContext.Chefs.OrderBy(chef=>chef.ChefId).ToList();
            ViewBag.chefs = AllChefs;
            return View();
        }

        [HttpPost("newdish")]
        public IActionResult AddDish(Dish newDish)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(newDish);
                dbContext.SaveChanges();
                return Redirect("/dishes");
            }
            else
            {
                return View("NewDish");
            }
        }












        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
