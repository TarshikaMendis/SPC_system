using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using SUPPLIERS_State_pharmaceutical_Cooperation.Models;

namespace SUPPLIERS_State_pharmaceutical_Cooperation.Controllers
{
    public class Inventory_DetailsController : Controller
    {
        private readonly string apiBaseUrl = "https://localhost:7168/api/Inventory_Details"; // Replace with your API URL

        // GET: Inventory_Details
        public async Task<ActionResult> Inventory_DetailsList()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiBaseUrl);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var inventoryDetails = JsonConvert.DeserializeObject<List<Inventory_Details>>(data);
                    return View(inventoryDetails);
                }
                return View(new List<Inventory_Details>());
            }
        }

    }
}
