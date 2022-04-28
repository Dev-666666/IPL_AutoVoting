using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace IPLVotingSystem.Areas.User.Controllers
{
    [Area("User")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewQuestions()
        {

            return View();
        }
        public IActionResult Feedback()
        {
            return View();
        }
    }
}
