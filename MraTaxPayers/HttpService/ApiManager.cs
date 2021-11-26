using MraTaxPayers.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MraTaxPayers.HttpService
{
    public class ApiManager
    {
        public static string baseUrl = "https://www.mra.mw/sandbox/";
        public static string loginUrl = "programming/challenge/webservice/auth/login";
        public static string logoutUrl = "programming/challenge/webservice/auth/logout";
        public static string taxPayerUrl = "programming/challenge/webservice/Taxpayers/getAll";
        public static string addTaxpayerUrl = "programming/challenge/webservice/Taxpayers/add";
        public static string editTaxpayerUrl = "programming/challenge/webservice/Taxpayers/edit";
        public static string deleteTaxpayerUrl = "programming/challenge/webservice/Taxpayers/delete";


        private HttpClient httpClient;

        public ApiManager(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<MraLoginRoot> loginUser(MraLogin mraLogin)
        {
            HttpContent content = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(mraLogin),
                    Encoding.UTF8,
                    "application/json"
                    );

            var response = await httpClient.PostAsync(loginUrl, content);

            if (response.IsSuccessStatusCode)
            {
                var loginResponseAsJson = await response.Content.ReadAsStringAsync();

                return System.Text.Json.JsonSerializer.Deserialize<MraLoginRoot>(loginResponseAsJson);
            }
            else
            {
                throw new Exception($"{response.StatusCode}");
            }
        }

        public async Task<bool> addMraTaxPayer(MraTaxPayer mraTaxPayer)
        {
            HttpContent content = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(mraTaxPayer),
                    Encoding.UTF8,
                    "application/json"
                    );

            var response = await httpClient.PostAsync(addTaxpayerUrl, content);

            if (response.IsSuccessStatusCode)
            {
               
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<MraTaxPayer>> getTaxPayers()
        {

            var response = await httpClient.GetAsync(taxPayerUrl);

            if (response.IsSuccessStatusCode)
            {

                var loginResponseAsJson = await response.Content.ReadAsStringAsync();

                return System.Text.Json.JsonSerializer.Deserialize<List<MraTaxPayer>>(loginResponseAsJson);
            }
            else
            {
                return new List<MraTaxPayer>();
            }
        }


        public async Task<bool> EditMraTaxPayer(MraTaxPayer mraTaxPayer)
        {
            HttpContent content = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(mraTaxPayer),
                    Encoding.UTF8,
                    "application/json"
                    );

            var response = await httpClient.PostAsync(editTaxpayerUrl, content);

            if (response.IsSuccessStatusCode)
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteTaxPayer (MraTPinRecord mraTPin)
        {
            HttpContent content = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(mraTPin),
                    Encoding.UTF8,
                    "application/json"
                    );

            var response = await httpClient.PostAsync(deleteTaxpayerUrl, content);

            if (response.IsSuccessStatusCode)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
