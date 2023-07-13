using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context; //means DB

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<CategoryModel> objCategoryList = _context.Categories.ToList();

            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(CategoryModel obj)
        {
            if (obj.Name != null && obj.Name.Equals(obj.DisplayOrder.ToString()))
            {
                ModelState.AddModelError("name", "The Name can not match with the Display Order");
            }

            if (ModelState.IsValid)
            {
                _context.Categories.Add(obj);
                _context.SaveChanges();

                TempData["success"] = "Category created successfully";

				return RedirectToAction("Index", "Category");
            }

            return View();
        }

		public IActionResult Edit(int? id)
		{

            if (id == null || id == 0)
            {
                return NotFound();
            }

            CategoryModel? categoryChosen = _context.Categories.FirstOrDefault(categ => categ.Id == id);

            if (categoryChosen == null)
            {
                return NotFound();
            }

			return View(categoryChosen);
		}

		[HttpPost]
		public IActionResult Edit(CategoryModel obj)
		{
            if (ModelState.IsValid) 
            {
                _context.Categories.Update(obj);
                _context.SaveChanges();

				TempData["success"] = "Category updated successfully";

				return RedirectToAction("Index", "Category");
            }

            return View();
		}

		public IActionResult Delete(int? id)
		{

			if (id == null || id == 0)
			{
				return NotFound();
			}

			CategoryModel? categoryChosen = _context.Categories.FirstOrDefault(categ => categ.Id == id);

			if (categoryChosen == null)
			{
				return NotFound();
			}

			return View(categoryChosen);
		}


		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePOST(int? id)
		{
            CategoryModel? category = _context.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
			_context.SaveChanges();

			TempData["success"] = "Category deleted successfully";

			return RedirectToAction("Index");
		}
	}
}
