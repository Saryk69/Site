using MainWeb.Data;
using MainWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace MainWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            // Insted of [var && .ToList()] we will use =>
            IEnumerable<Category> objCategoryList = _db.Categories.ToList();  
            return View(objCategoryList);
        }

        // Get action method for category
        public IActionResult Create()
        {
            return View();
        }

        // POST action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString()) 
            {
                ModelState.AddModelError("name","The DisplayOrder cannet match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        // New edit button
        // GET aciton
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            // Ask later about u=> u.Id == id
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
            // 2.0 version

            if (categoryFromDb == null) { return NotFound(); }
            return View(categoryFromDb);
        }

        // POST action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannet match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        // New delete button
        // GET aciton
        // Nonsense
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            // Ask later about u=> u.Id == id
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
            // 2.0 version

            if (categoryFromDb == null) { return NotFound(); }
            return View(categoryFromDb);
        }

        // Delete Button
        // POST action
        // ?????
        // Don't know what is up whit that
        // [HttpPost,ActionName("Delete")]
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Categories.Find(id);
            if (obj == null) 
            {
                return NotFound(); 
            }
            else
            {
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                TempData["success"] = "Category deleted successfully";
                return RedirectToAction("Index");   
            }
            
        }
    }
}
