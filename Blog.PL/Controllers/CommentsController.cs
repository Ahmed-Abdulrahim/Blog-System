using Microsoft.AspNetCore.Mvc;

namespace Blog.PL.Controllers
{
    public class CommentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //Creaet 
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
    }
}
