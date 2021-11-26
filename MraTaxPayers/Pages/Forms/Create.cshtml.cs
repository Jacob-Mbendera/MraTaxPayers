using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MraTaxPayers.Data;
using MraTaxPayers.HttpService;
using MraTaxPayers.Models;

namespace MraTaxPayers.Pages.Forms
{
    public class CreateModel : PageModel
    {
        //private readonly MraTaxPayers.Data.MraTaxpayerDbContext _context;
        private ApiManager apiManager;

        public CreateModel(ApiManager apiManager)
        {
            this.apiManager = apiManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MraTaxPayer MraTaxPayer { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await AddMraTaxPayer();
            //_context.MraTaxPayers.Add(MraTaxPayer);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public async Task AddMraTaxPayer()
        {
            try
            {
                //var mraTaxPayer = new MraTaxPayer
                //{
                //    TPIN = "20203031",
                //    BusinessCertificateNumber = "MBRS123457",
                //    TradingName = "Sample Trader2",
                //    BusinessRegistrationDate = "2021/11/25",
                //    MobileNumber = "0995900011",
                //    Email = "sampletrader2@gmail.com",
                //    PhysicalLocation = "Nyambagwe",
                //    Username = "jacob@jacobmbendera.com"
                //};

                var result = await apiManager.addMraTaxPayer(MraTaxPayer);

                System.Diagnostics.Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }
    }
}
