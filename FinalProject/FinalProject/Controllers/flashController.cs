using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject.Controllers
{
    public class flashController : Controller
    {
        // GET: /<controller>/
        public IActionResult ListAll()
        {
            QuestionRepo repo = new QuestionRepo();
            List<Question> question = repo.GetAllQuestions();
            return View(question);
        }
        public IActionResult Index()
        {
            QuestionRepo repo = new QuestionRepo();
            List<Question> question = repo.GetAllQuestions();
            return View(question);
        }
        public IActionResult InsertFlash()
        {
            return View();
        }
        public IActionResult InsertQuestionToDatabase(Question flashToInsert)
        {
            var repo = new QuestionRepo();
            repo.InsertFlash(flashToInsert);
            return RedirectToAction("ListAll");
        }
        public IActionResult DeleteQuestion(int id)
        {
            var repo = new QuestionRepo();
            repo.DeleteQuestion(id);
            return RedirectToAction("ListAll");
        }


        public IActionResult UpdateFlash(int id)
        {
            var repo = new QuestionRepo();
            var question = repo.GetQuestion(id);
            return View(question);  

        }

        public IActionResult UpdateQuestionToDatabase(Question flashToUpdate)
        {
            var repo = new QuestionRepo();
            repo.UpdateQuestion(flashToUpdate);
            return RedirectToAction("ListAll");
        }
    }




}
