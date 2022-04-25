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

namespace IPLVotingSystem.Controllers
{
    public class HomeController : Controller
    {
       //  private readonly ILogger<HomeController> _logger;
        ApplicationDbContext _db;
          public HomeController(ApplicationDbContext db)
          {
            _db = db;
          }
  
     //  public readonly ILogin login;
       /* public HomeController(ILogin login)
        {
            this.login = login;
        }*/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Userlist userlist)
        {
            using(_db)
            {
                var user = _db.Userlists.Single(u => u.uname == userlist.uname && u.pass == userlist.pass);
                if(user != null)
                {
                    /*ISession session;
                    session["UserName"] = user.uname.ToString();*/
                    return RedirectToAction("UserDashbord");

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
        public IActionResult Register(Userlist ulist)
        {
            if(ModelState.IsValid)
            {
                using(_db)
                {
                    _db.Userlists.Add(ulist);
                    _db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = ulist.fullname + " " + " Registered";
       
            }
            return View();
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
