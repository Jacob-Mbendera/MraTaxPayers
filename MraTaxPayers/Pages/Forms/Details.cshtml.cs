using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MraTaxPayers.Data;
using MraTaxPayers.Models;

namespace MraTaxPayers.Pages.Forms
{
    public class DetailsModel : PageModel
    {
        private readonly MraTaxPayers.Data.MraTaxpayerDbContext _context;

        public DetailsModel(MraTaxPayers.Data.MraTaxpayerDbContext context)
        {
            _context = context;
        }

        public MraTaxPayer MraTaxPayer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MraTaxPayer = await _context.MraTaxPayers.FirstOrDefaultAsync(m => m.id == id);

            if (MraTaxPayer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
