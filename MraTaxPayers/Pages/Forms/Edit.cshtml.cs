using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MraTaxPayers.Data;
using MraTaxPayers.HttpService;
using MraTaxPayers.Models;

namespace MraTaxPayers.Pages.Forms
{
    public class EditModel : PageModel
    {
        //private readonly MraTaxPayers.Data.MraTaxpayerDbContext _context;

        private ApiManager apiManager;

        public EditModel(ApiManager manager)
        {
            apiManager = manager;
        }

        [BindProperty]
        public MraTaxPayer MraTaxPayer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var taxyPayers = await apiManager.getTaxPayers();       

            if (taxyPayers.Count == 0)
            {
                return NotFound();
            }

            MraTaxPayer = taxyPayers.Find(m => m.id == id);
            if (MraTaxPayer == null)
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

            try
            {
                var result = await apiManager.EditMraTaxPayer(MraTaxPayer);
                System.Diagnostics.Debug.WriteLine(result);
            }
            catch (Exception)
            {
               
            }

            return RedirectToPage("./Index");
        }

        public async Task EditMraTaxPayer()
        {
            try
            {

                var result = await apiManager.EditMraTaxPayer(MraTaxPayer);

                System.Diagnostics.Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }

        private bool MraTaxPayerExists(int id)
        {
            //return _context.MraTaxPayers.Any(e => e.id == id);
            return false;
        }
    }
}
