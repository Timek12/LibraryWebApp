using LibraryWebRazor.Data;
using LibraryWebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryWebRazor.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category? Category { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if(id != null && id != 0)
            {
                Category = _db.Categories.FirstOrDefault(c => c.Id == id);

            }
        }

        public IActionResult OnPost()
        {
            _db.Update(Category);
            _db.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
