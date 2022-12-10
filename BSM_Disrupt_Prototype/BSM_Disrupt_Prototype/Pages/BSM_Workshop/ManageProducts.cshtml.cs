using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BSM_Disrupt_Prototype.Data;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace BSM_Disrupt_Prototype.Pages.BSM_Workshop
{
	public class ManageProductsModel : PageModel
    {
        private readonly AppDbContext _db;
        public ManageProductsModel(AppDbContext db)
        {
            _db = db;
        }
        public IList<Products> Products { get; private set; }

        [BindProperty]
        public string Search { get; set; }

        public void OnGet()
        {
            Products = _db.Products.FromSqlRaw("SELECT * FROM Products").ToList();
        }

        public IActionResult OnPostSearch()
        {
            Products = _db.Products
                .FromSqlRaw("SELECT * FROM Products WHERE Name LIKE '" + Search + "%'")
                .ToList();
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int itemID)
        {
            var item = await _db.Products.FindAsync(itemID);
            item.Active = false; //set item as deleted
            _db.Attach(item).State = EntityState.Modified;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new Exception($"Item {item.ID} not found!", e);
            }
            return RedirectToPage();
        }



    }
}
