using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public CategoryModel Category { get; set; }

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet(int? id)
        {
            if (id != 0 || id != null)
            {
                Category = _context.Categories.Find(id);
            }
        }
        
        public IActionResult OnPost()
        {
            if (Category == null)
            {
                return Page();
            }

            _context.Categories.Remove(Category);
            _context.SaveChanges();

			TempData["success"] = "Category deleted successfully";

			return RedirectToPage("Index");
        }
    }
}
