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
    public class IndexModel : PageModel
    {
        //private readonly MraTaxPayers.Data.MraTaxpayerDbContext _context;
        private ApiManager apiManager;

        public IndexModel(MraTaxPayers.Data.MraTaxpayerDbContext context, ApiManager apiManager)
        {
            //_context = context;
            this.apiManager = apiManager;
        }

        public IList<MraTaxPayer> MraTaxPayer { get;set; }

        public async Task OnGetAsync()
        {
            //MraTaxPayer = await _context.MraTaxPayers.ToListAsync();
            MraTaxPayer = await apiManager.getTaxPayers();
            await LoginUserAsync();

            
            await GetTaxPayers();
        }

        public async Task LoginUserAsync()
        {
            try
            {
                var result = await apiManager.loginUser(new Models.MraLogin
                {
                    Email = "jacob@jacobmbendera.com",
                    Password = "password000122"
                });

                System.Diagnostics.Debug.WriteLine(result.UserDetails.LastName);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }

        

        public async Task GetTaxPayers()
        {
            try
            {
                var result = await apiManager.getTaxPayers();
                System.Diagnostics.Debug.WriteLine(result.Count);
            }
            catch (Exception e)
            {

                System.Diagnostics.Debug.WriteLine(e);
            }
        }
    }
}
