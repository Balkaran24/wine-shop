using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wine_Shop_Balkaran.Bussiness;
using Wine_Shop_Balkaran.Data;

namespace Wine_Shop_Balkaran.Pages.Wine
{
    public class EditModel : PageModel
    {
        private readonly Wine_Shop_Balkaran.Data.Wine_Shop_Balkaran_DbContext _context;

        public EditModel(Wine_Shop_Balkaran.Data.Wine_Shop_Balkaran_DbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public WineMaster WineMaster { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WineMaster = await _context.WineMasters.FirstOrDefaultAsync(m => m.ID == id);

            if (WineMaster == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(WineMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WineMasterExists(WineMaster.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WineMasterExists(int id)
        {
            return _context.WineMasters.Any(e => e.ID == id);
        }
    }
}
