
using IPLVotingSystem.Services;
using Microsoft.AspNetCore.Http;
using IPLVotingSystem.Data;
using Microsoft.EntityFrameworkCore;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using IPLVotingSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace IPLVotingSystem.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AdminUseController : Controller
    {
        ApplicationDbContext _db;
        public AdminUseController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddQuestionary()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddQuestionary(IFormCollection form)
        {

            //ViewBag.user = form["user"];
            using (_db)
            {
                Options option = new Options();
                Questionary quest = new Questionary();
                quest.Question = form["question"].ToString();
                _db.questionaries.Add(quest);
                _db.SaveChanges();
                var result= _db.questionaries.OrderByDescending(x => x.qId).Take(1).SingleOrDefault();
                option.qId = result.qId;
                option.option1 = form["txtop1"].ToString() ; option.option2 = form["txtop2"].ToString();
                option.option3 = form["txtop3"].ToString(); option.option4 = form["txtop4"].ToString();
              
                _db.options.Add(option);

                int i = _db.SaveChanges();
                if (i > 0)
                {
                     ViewBag.Msg = "Data Saved Suuceessfully.";
                }
            }
            return View();
           // return RedirectToAction("Index");

        }
        public IActionResult ViewQuestionary()
        {

            var question = _db.questionaries.ToList();
             ViewData["qlist"] = question;

           var option= _db.options.ToList();
            ViewBag.olist = option;

            return View();
        }
        [HttpGet]
       public IActionResult EditQuestionary()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EditQuestionary(IFormCollection form)
        {
              Options option = new Options();
              Questionary quest = new Questionary();
            // var inputid = form["txtquestionid"].ToString();
          
            quest.Question = form["question"].ToString();
            //_db.questionaries.Add(quest);
            //_db.SaveChanges();
            //fetch optionid
            var resultq = _db.questionaries.OrderByDescending(x => x.qId).Take(1).SingleOrDefault();
            option.qId = resultq.qId;
            var result = _db.options.OrderByDescending(x => x.optionId).Take(1).SingleOrDefault();
            var opid = result.optionId;
            option.qId = Convert.ToInt32(form["txtquestionid"].ToString());
            option.option1 = form["txtop1"].ToString(); option.option2 = form["txtop2"].ToString();
            option.option3 = form["txtop3"].ToString(); option.option4 = form["txtop4"].ToString();
            _db.options.Add(option);
           
            _db.SaveChanges();

            int i = _db.SaveChanges();
              if (i > 0)
              {
                  ViewBag.Msg = "Edited Suuceessfully.";
              }
            return View();
        }
           // return View();
           // return RedirectToAction("Index");


          
        
        public IActionResult ViewResponce(Responces responces)
        {
           // var responce=_db.responces.
            return View();
        }
        public IActionResult Feedback()
        {
            return View();
        }
    }
}
