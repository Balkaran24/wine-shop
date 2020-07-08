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

namespace Wine_Shop_Balkaran.Pages.RateList
{
    public class EditModel : PageModel
    {
        private readonly Wine_Shop_Balkaran.Data.Wine_Shop_Balkaran_DbContext _context;

        public EditModel(Wine_Shop_Balkaran.Data.Wine_Shop_Balkaran_DbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RateListMaster RateListMaster { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RateListMaster = await _context.RateListMasters.FirstOrDefaultAsync(m => m.ID == id);

            if (RateListMaster == null)
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

            _context.Attach(RateListMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RateListMasterExists(RateListMaster.ID))
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

        private bool RateListMasterExists(int id)
        {
            return _context.RateListMasters.Any(e => e.ID == id);
        }
    }
}
