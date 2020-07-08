using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Wine_Shop_Balkaran.Bussiness;
using Wine_Shop_Balkaran.Data;

namespace Wine_Shop_Balkaran.Pages.Customer
{
    public class DetailsModel : PageModel
    {
        private readonly Wine_Shop_Balkaran.Data.Wine_Shop_Balkaran_DbContext _context;

        public DetailsModel(Wine_Shop_Balkaran.Data.Wine_Shop_Balkaran_DbContext context)
        {
            _context = context;
        }

        public CustomerMaster CustomerMaster { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CustomerMaster = await _context.CustomerMasters
                .Include(c => c.RateListMaster)
                .Include(c => c.WineMaster).FirstOrDefaultAsync(m => m.ID == id);

            if (CustomerMaster == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
