using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Linq;
using IPLVotingSystem.Models;
using IPLVotingSystem.Data;
using Microsoft.AspNetCore.Http;

namespace IPLVotingSystem.Areas.User.Controllers
{
    [Area("User")]
    public class UserController : Controller
    {
        ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewQuestions(IFormCollection form)
        {
            Options option = new Options();
            Questionary quest = new Questionary();
            var resultq = _db.questionaries.OrderBy(x => x.qId).Take(1).SingleOrDefault();
            option.qId = resultq.qId;
            var result = _db.options.OrderBy(x => x.optionId).Take(1).SingleOrDefault();
            var opid = result.optionId;
            var res = _db.questionaries.ToList();
            var reso = _db.options.ToList();
            ViewBag.showquestion = resultq.Question;
            ViewBag.showq = res;
            ViewBag.showo = reso;
             ViewBag.op1 = result.option1;
             ViewBag.op2 = result.option2;
            ViewBag.op3 = result.option3;
            ViewBag.op4 = result.option4;
           /* var shifts = (from b in _db.questionaries
                          select new Questionary
                          {
                              Question = (string)b.Question
                          }).ToList();
            ViewBag.shift = shifts;*/
            return View();

           
        }
        public IActionResult Feedback()
        {
            return View();
        }
    }
}
