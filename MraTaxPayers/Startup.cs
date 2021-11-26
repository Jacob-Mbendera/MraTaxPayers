using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MraTaxPayers.Data;

namespace MraTaxPayers
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddDbContext<MraTaxpayerDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MraTaxPayerConnection")));

            services.AddHttpClient<HttpService.ApiManager>(mraHttpClient =>
            {
                mraHttpClient.BaseAddress = new Uri("https://www.mra.mw/sandbox/");

                mraHttpClient.DefaultRequestHeaders.Accept.Clear();

                mraHttpClient.DefaultRequestHeaders.Add("candidateid", "jacob@jacobmbendera.com");
                mraHttpClient.DefaultRequestHeaders.Add("apikey", "3fdb48c5-336b-47f9-87e4-ae73b8036a1c");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            //dbContext.Database.EnsureCreated();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
