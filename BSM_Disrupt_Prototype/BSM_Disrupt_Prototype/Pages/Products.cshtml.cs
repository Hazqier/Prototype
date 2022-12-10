using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BSM_Disrupt_Prototype.Data;
using Microsoft.EntityFrameworkCore;

namespace BSM_Disrupt_Prototype.Pages
{
	public class ProductsModel : PageModel
    {
        private readonly AppDbContext _db;
        public ProductsModel(AppDbContext db)
        {
            _db = db;
        }
        public IList<Products> Products { get; private set; }

        [BindProperty]
        public string Search { get; set; }

        public void OnGet()
        {
            Products = _db.Products.FromSqlRaw("SELECT * FROM Products WHERE Active = 1").ToList();
        }

        public IActionResult OnPostSearch()
        {
            Products = _db.Products
                .FromSqlRaw("SELECT * FROM Products WHERE Active = 1 AND Name LIKE '" + Search + "%'")
                .ToList();
            return Page();
        }

    }
}
