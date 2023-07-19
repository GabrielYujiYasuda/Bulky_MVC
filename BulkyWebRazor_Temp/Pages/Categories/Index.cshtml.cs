using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Shared.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public List<CategoryModel> CategoryList { get; set; }

        public IndexModel(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void OnGet()
        {
            CategoryList = _context.Categories.ToList();
        }
    }
}
