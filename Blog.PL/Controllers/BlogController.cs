using Blog.BLL.Interface;
using Blog.BLL.Repo;
using Blog.DAL.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Internal;

namespace Blog.PL.Controllers
{
    public class BlogController : Controller
    {
        private readonly IRepoType<BlogPost> blogposttRepo;

        public BlogController(IRepoType<BlogPost> _blogposttRepo)
        {
            blogposttRepo = _blogposttRepo;
        }
        //GetAll BlogPost
        public IActionResult Index()
        {
            var models = blogposttRepo.GetAll();
            return View(models);
        }
        //Create Blog Post
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        //
        //Create Data
        [HttpPost]
        public async Task<IActionResult> Create(BlogPost model) 
        {
            model.UserId = 1;
            ModelState.Remove("Users");
            ModelState.Remove("Comments");
            if (ModelState.IsValid) 
            {
                blogposttRepo.Add(model);
                var save = await blogposttRepo.Save();
                if (save > 0) 
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Details(int? id) 
        {
            if (id == null) return BadRequest();
            var model = blogposttRepo.Get(id.Value);
            if (model == null) return NotFound();
            return View(model);
        }
        [HttpGet]
        public  IActionResult Edit(int? id) 
        {
            if (id == null) return NotFound();
            var model = blogposttRepo.Get(id.Value);
            if(model == null) return NotFound();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, BlogPost model) 
        {
            if (id != model.Id) return BadRequest();
            model.UserId = 1;
            ModelState.Remove("Users");
            ModelState.Remove("Comments");

            if (ModelState.IsValid) 
            {
                 blogposttRepo.Update(model);
                var res = await blogposttRepo.Save();
                if (res > 0) 
                {
                    return RedirectToAction(nameof(Index));
                }
                
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int? id) 
        {
            if (id == null) return BadRequest();
            var model = blogposttRepo.Get(id.Value);
            if (model == null) return NotFound();
            return View(model);
        }

        //Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id , BlogPost model) 
        {
            if(id!=model.Id) return BadRequest();
            model.UserId = 1;
            ModelState.Remove("Users");
            ModelState.Remove("Comments");
            if (ModelState.IsValid) 
            {
                blogposttRepo.Delete(model);
                var res = await blogposttRepo.Save();
                if (res >0) 
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }

    }
}
