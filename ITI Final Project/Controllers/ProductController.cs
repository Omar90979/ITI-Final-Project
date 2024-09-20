using ITI_Final_Project.Context;
using ITI_Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WebApplication5.Controllers
{
    public class ProductController : Controller
    {

        MarketContext db = new MarketContext();

        [HttpGet]
        public IActionResult Index()
        {
            var _Products = db.Products.Include(pro => pro.Category);
            return View(_Products);
        }

        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            var _Product = db.Products.Include(p => p.Category).FirstOrDefault(pro => pro.ProductId == id);
            return View(_Product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag._Categorys = new SelectList(db.Categorys, "CategoryId", "Name");
            ViewBag.Images = new SelectList(GetImages(), "Value", "Text");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            ModelState.Remove("Category");
            if (!ModelState.IsValid)
            {
                ViewBag._Categorys = new SelectList(db.Categorys, "CategoryId", "Name");
                ViewBag.Images = new SelectList(GetImages(), "Value", "Text");
                return View();
            }

            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = db.Products.Find(id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag._Categorys = new SelectList(db.Categorys, "CategoryId", "Name", product.CategoryId);
            ViewBag.Images = new SelectList(GetImages(), "Value", "Text", product.ImagePath);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                ViewBag._Categorys = new SelectList(db.Categorys, "CategoryId", "Name", product.CategoryId);
                ViewBag.Images = new SelectList(GetImages(), "Value", "Text", product.ImagePath);
                return View(product);
            }

            var existingProduct = db.Products.Find(product.ProductId);
            if (existingProduct == null)
            {
                return RedirectToAction("Index");
            }

          
            existingProduct.Title = product.Title;
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;
            existingProduct.Quantitiy = product.Quantitiy;
            existingProduct.ImagePath = product.ImagePath;
            existingProduct.CategoryId = product.CategoryId;

            db.Products.Update(existingProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var productToDelete = db.Products.Find(id);
            if (productToDelete == null)
            {
                return RedirectToAction("Index");
            }

            
            if (!string.IsNullOrEmpty(productToDelete.ImagePath))
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", productToDelete.ImagePath.TrimStart('/'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            db.Products.Remove(productToDelete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private List<SelectListItem> GetImages()
        {
            var imagesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
            var images = Directory.GetFiles(imagesDirectory).Select(file => new SelectListItem
            {
                Value = "/images/" + Path.GetFileName(file),
                Text = Path.GetFileName(file)                
            }).ToList();

            return images;
        }
    }
}
