using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject.Controllers
{
    public class flashController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            QuestionRepo repo = new QuestionRepo();
            List<Question> question = repo.GetAllQuestions();
            return View(question);
        }

    }
}
