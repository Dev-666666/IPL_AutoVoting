using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using System.Collections.Concurrent;
using System.Threading.Channels;
using System.Linq;
using IPLVotingSystem.Models;
using IPLVotingSystem.Data;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace IPLVotingSystem.Controllers
{
    public class AccountController : Microsoft.AspNetCore.Mvc.Controller
    {
        AddDbcon dbcon;

        public AccountController(AddDbcon dbContext)
        {
            dbcon = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public IActionResult Register(Users ulist)
        {
           /* dbcon.Users.Add(ulist);
            dbcon.SaveChanges();*/
            return View();
        }
    }
}
