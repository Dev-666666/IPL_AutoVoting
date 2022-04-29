
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
//using System.Web.Mvc;

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
            ViewData["olist"] = option;

            return View();
        }
        [HttpGet]
       public IActionResult EditQuestionary(int qid)
        {
            var quest = _db.questionaries.Where(q => q.qId == qid).SingleOrDefault();
            var opt = _db.options.Where(x => x.qId == qid).SingleOrDefault();
            ViewData["id"]= qid;
            ViewBag.Question = quest.Question;
            ViewBag.QuestionId = quest.qId;
            ViewBag.Option1 = opt.option1;
            ViewBag.Option2 = opt.option2;
            ViewBag.Option3 = opt.option3;
            ViewBag.Option4 = opt.option4;
            
            return View();
        }
        [HttpPost]
        public IActionResult EditQuestionary(IFormCollection form)
        {
              Options option = new Options();
              Questionary quest = new Questionary();
            // var inputid = form["txtquestionid"].ToString();
          
            quest.Question = form["question"].ToString();
            quest.qId = Convert.ToInt32(form["txtquestionid"]);
           // var newq = quest.Question; 
            var resultq = _db.questionaries.OrderByDescending(x => x.qId == quest.qId).Take(1).SingleOrDefault();
            resultq.Question = quest.Question;
            //_db.questionaries.Add(newq);
           // _db.SaveChanges();

            //fetch optionid



            var result = _db.options.OrderByDescending(x => x.qId==resultq.qId).Take(1).SingleOrDefault();
            //var opid = result.optionId;
           // option.qId = Convert.ToInt32(form["txtquestionid"].ToString());
            result.option1 = form["txtop1"].ToString(); result.option2 = form["txtop2"].ToString();
            result.option3 = form["txtop3"].ToString(); result.option4 = form["txtop4"].ToString();
            //_db.options.Add(option);
           
           int ans= _db.SaveChanges();
            if(ans==1)
            return RedirectToAction("ViewQuestionary");


            return View();
        }
           // return View();
           // return RedirectToAction("Index");


          
        
        public IActionResult ViewResponce(Responces responces)
        {
            // var responce=_db.responces.
           
            return View();
        }
        [HttpGet]
        public IActionResult DeletQuestionary(int qid)
        {
            var quest = _db.questionaries.Where(q => q.qId == qid).Take(1).SingleOrDefault();
            var opt = _db.options.Where(x => x.qId == quest.qId).Take(1).SingleOrDefault();
            ViewData["id"] = qid;
            ViewBag.Question = quest.Question;
            ViewBag.QuestionId = quest.qId;
            ViewBag.Option1 = opt.option1;
            ViewBag.Option2 = opt.option2;
            ViewBag.Option3 = opt.option3;
            ViewBag.Option4 = opt.option4;

            return View();
        }
        [HttpPost]
        [ActionName("DeletQuestionary")]
        public IActionResult DeletQuestionaryCon(IFormCollection form)
        {
            int id = Convert.ToInt32(form["txtquestionid"]);
            var delq = _db.questionaries.Where(q => q.qId == id ).SingleOrDefault();
            var delo = _db.options.Where(o => o.qId == delq.qId).SingleOrDefault();

            if(delq != null && delo != null)
            {
                _db.Remove(delo);
                _db.Remove(delq);
            }
             int res=_db.SaveChanges();
            if (res == 1)
                ViewBag.Msg = "<script> alert'Record Deleted' </script>";
            
            return RedirectToAction("ViewQuestionary");

           
           // return View();


        }
        public IActionResult Feedback()
        {

            return View();
        }
    }
}
