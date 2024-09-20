using ITI_Final_Project.Context;
using ITI_Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
namespace ITI_Final_Project.Controllers
{
    public class CategoryController : Controller
    {

        MarketContext db = new MarketContext();

        [HttpGet]
        public IActionResult Index()
        {

            var _Categorys = db.Categorys;
            return View(db.Categorys);
        }

        [HttpGet]
        public IActionResult ViewDetails(int id)
        {

            var _Category = db.Categorys.FirstOrDefault(d => d.CategoryId == id);
            return View(_Category);
        }
       
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            db.Categorys.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var oldCategory = db.Categorys.Find(id);
            if (oldCategory == null)
            {
                return RedirectToAction("Index");
            }
            return View(oldCategory);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            var oldCategory = db.Categorys.FirstOrDefault(c => c.CategoryId == category.CategoryId);
            if (oldCategory == null)
            {
                return RedirectToAction("Index");
            }
            oldCategory.Name = category.Name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var catToDelete = db.Categorys.Find(id);
            if (catToDelete == null)
            {
                return RedirectToAction("Index");
            }
            db.Categorys.Remove(catToDelete);
            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
