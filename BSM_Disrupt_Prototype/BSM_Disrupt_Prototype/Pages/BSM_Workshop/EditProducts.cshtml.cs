using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BSM_Disrupt_Prototype.Data;
using Microsoft.EntityFrameworkCore;

namespace BSM_Disrupt_Prototype.Pages.BSM_Workshop
{
	public class EditProductsModel : PageModel
    {
        [BindProperty]
        public Products Item { get; set; }

        private readonly AppDbContext _db;
        public EditProductsModel(AppDbContext db) { _db = db; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Item = await _db.Products.FindAsync(id);
            if (Item == null)
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostSaveAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Attach(Item).State = EntityState.Modified;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new Exception($"Item {Item.ID} not found!", e);
            }
            return RedirectToPage("/Index");
        }


    }
}
