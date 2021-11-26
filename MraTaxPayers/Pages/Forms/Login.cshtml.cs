using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MraTaxPayers.HttpService;
using MraTaxPayers.Models;

namespace MraTaxPayers.Pages.Forms
{
    public class LoginModel : PageModel
    {
        private ApiManager apiManager;

        public LoginModel(ApiManager manager)
        {
            apiManager = manager;
        }


        [BindProperty]
        public MraLogin Login { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                if (await LoginUserAsync())
                {
                    return RedirectToPage("/Forms/Index");
                }
                
            }
            catch (Exception)
            {

            }

            return RedirectToPage("/Forms/Login");
        }

        public async Task<bool> LoginUserAsync()
        {
            try
            {
                var result = await apiManager.loginUser(new Models.MraLogin
                {
                    Email = Login.Email,
                    Password = Login.Password
                });
                
                if (result.Authenticated)
                 {

                    return true;
                }
                else 
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return false;
            }
        }
    }
}
