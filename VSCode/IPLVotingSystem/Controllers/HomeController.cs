using IPLVotingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IPLVotingSystem.Services;
using Microsoft.AspNetCore.Http;
using IPLVotingSystem.Data;
using Microsoft.EntityFrameworkCore;
using System.Web;
using IPLVotingSystem.Areas;
using System.Linq;
using System.Collections.Generic;

namespace IPLVotingSystem.Controllers
{
    public class HomeController : Controller
    {
        //  private readonly ILogger<HomeController> _logger;

        //  public readonly ILogin login;
        /* public HomeController(ILogin login)
         {
             this.login = login;
         }*/
        ApplicationDbContext _db;
        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Users userlist)
        {
            using(_db)
            {
               var user = _db.users.Single(u => u.UName == userlist.UName && u.Password == userlist.Password);
                if(user != null)
                {
                    if (user.RoleId == 1)
                    {
                        //ViewBag.msg1 = "Admin";
                        /*ISession session;
                        session["UserName"] = user.uname.ToString();*/
                        return RedirectToAction("Index", "AdminUse", new { area = "admin" });
                    }
                    else if(user.RoleId == 2)
                    {
                       return RedirectToAction("Index", "User", new { area = "User" });
//ViewBag.Msg = "User";
                    }
                    else { }
                   //return RedirectToRoute("Indexadmin", "Admin");

               }
            }
            return View();
        }
        
        public IActionResult Register()
        {
        //    ViewData["url"] = url;
            return View();
        }
        [HttpPost]
        public IActionResult Register(Users ulist)
        {
            if(ModelState.IsValid)
            {
                using(_db)
                {
                    _db.users.Add(ulist);
                    _db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = ulist.FullName + " " + " Registered";
       
            }
            return RedirectToAction("Login");
        }

        public IActionResult UserDashbord()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
