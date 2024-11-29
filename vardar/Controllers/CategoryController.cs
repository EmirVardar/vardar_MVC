using Microsoft.AspNetCore.Mvc;
using vardar.Data;
using vardar.Models;

namespace vardar.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbCentext _db;
        public CategoryController(ApplicationDbCentext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)//entity framework ile categori yaratma
        {
            if(obj.Name ==obj.DisplayOrder.ToString() )
            {
                ModelState.AddModelError("name", "Gösterim sırası isim ile aynı olamaz.");
            }
            
            if (ModelState.IsValid)
            {
            _db.Categories.Add(obj);
            _db.SaveChanges();
				TempData["success"] = "Kategori başarıyla oluşturuldu.";
            return RedirectToAction("Index");
            }
            return View();
            
        }
		public IActionResult Edit(int? id)
		{
            if (id == null|| id==0)
            {
                return NotFound();
            }
            Category categoryFromDb = _db.Categories.Find(id);
            if(categoryFromDb == null)
            {
                return NotFound();
            }
			return View(categoryFromDb);
		}
		[HttpPost]
		public IActionResult Edit(Category obj)//entity framework ile categori yaratma
		{
			

			if (ModelState.IsValid)
			{
				_db.Categories.Update(obj);
				_db.SaveChanges();
				TempData["success"] = "Kategori başarıyla değiştirildi.";
				return RedirectToAction("Index");
			}
			return View();

		}
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Category categoryFromDb = _db.Categories.Find(id);
			if (categoryFromDb == null)
			{
				return NotFound();
			}
			return View(categoryFromDb);
		}
		[HttpPost ,ActionName("Delete")]
		public IActionResult DeletePOST(int? id)//entity framework ile categori yaratma
		{
			Category? obj = _db.Categories.Find(id); 
			if (obj == null) 
			{ return NotFound(); }
			_db.Categories.Remove(obj);
			_db.SaveChanges();
			TempData["success"] = "Kategori başarıyla silindi.";
			return RedirectToAction("Index");

			
			

		}
	}
}
