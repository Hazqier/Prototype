using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BSM_Disrupt_Prototype.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BSM_Disrupt_Prototype.Pages.BSM_Workshop
{
	public class CreateModel : PageModel
    {

        private AppDbContext _db;

        [BindProperty]
        public Products Prod { get; set; }

        public CreateModel(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) { return Page(); }
            Prod.Active = true;
            foreach (var file in Request.Form.Files)
            {
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                Prod.ImageData = ms.ToArray();

                ms.Close();
                ms.Dispose();
            }

            _db.Products.Add(Prod);
            await _db.SaveChangesAsync();
            return RedirectToPage("/BSM_Workshop/Create");
        }

        public void OnGet()
        {
        }
    }
}
