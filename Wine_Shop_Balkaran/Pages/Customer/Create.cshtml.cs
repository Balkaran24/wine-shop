using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Wine_Shop_Balkaran.Bussiness;
using Wine_Shop_Balkaran.Data;

namespace Wine_Shop_Balkaran.Pages.Customer
{
    public class CreateModel : PageModel
    {
        private readonly Wine_Shop_Balkaran.Data.Wine_Shop_Balkaran_DbContext _context;

        public CreateModel(Wine_Shop_Balkaran.Data.Wine_Shop_Balkaran_DbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["RateListMasterID"] = new SelectList(_context.RateListMasters, "ID", "Price");
        ViewData["WineMasterID"] = new SelectList(_context.WineMasters, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public CustomerMaster CustomerMaster { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CustomerMasters.Add(CustomerMaster);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
