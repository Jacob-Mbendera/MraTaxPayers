using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MraTaxPayers.Data;
using MraTaxPayers.HttpService;
using MraTaxPayers.Models;

namespace MraTaxPayers.Pages.Forms
{
    public class DeleteModel : PageModel
    {
        private ApiManager apiManager;

        public DeleteModel(ApiManager manager)
        {
            apiManager = manager;
        }

        [BindProperty]
        public MraTaxPayer MraTaxPayer { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxPayers = await apiManager.getTaxPayers();

            if (taxPayers.Count == 0)
            {
                return NotFound();
            }

            MraTaxPayer = taxPayers.Find(m => m.TPIN == id);

            if (MraTaxPayer == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            

            if (MraTaxPayer != null)
            {
                await apiManager.DeleteTaxPayer(new MraTPinRecord { TPIN =id });
            }

            return RedirectToPage("./Index");
        }

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    try
        //    {
        //        var result = await apiManager.DeleteTaxPayer(MraTaxPayer);
        //        System.Diagnostics.Debug.WriteLine(result);
        //    }
        //    catch (Exception)
        //    {

        //    }

        //    return RedirectToPage("./Index");
        //}

        public async Task DeleteMraTaxPayer(MraTPinRecord mraTPin)
        {
            try
            {

                var result = await apiManager.DeleteTaxPayer(mraTPin);

                System.Diagnostics.Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }
    }
}
