using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Wine_Shop_Balkaran.Bussiness;
using Wine_Shop_Balkaran.Data;

namespace Wine_Shop_Balkaran.Pages.Wine
{
    public class DeleteModel : PageModel
    {
        private readonly Wine_Shop_Balkaran.Data.Wine_Shop_Balkaran_DbContext _context;

        public DeleteModel(Wine_Shop_Balkaran.Data.Wine_Shop_Balkaran_DbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WineMaster = await _context.WineMasters.FindAsync(id);

            if (WineMaster != null)
            {
                _context.WineMasters.Remove(WineMaster);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
