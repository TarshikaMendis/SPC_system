using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using State_Pharmaceutical_Cooperation__.Models;

namespace State_Pharmaceutical_Cooperation__.Controllers
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

        // GET: Inventory_Details/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventory_Details/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Inventory_Details inventoryDetails)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(inventoryDetails), System.Text.Encoding.UTF8, "application/json");
                        HttpResponseMessage response = await client.PostAsync(apiBaseUrl, content);
                        if (response.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Inventory_DetailsList");
                        }
                    }
                }
                return View(inventoryDetails);
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while saving inventory details.");
                return View(inventoryDetails);
            }
        }

        // GET: Inventory_Details/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{apiBaseUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var inventoryDetails = JsonConvert.DeserializeObject<Inventory_Details>(data);
                    return View(inventoryDetails);
                }
                return HttpNotFound();
            }
        }

        // POST: Inventory_Details/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Inventory_Details inventoryDetails)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(inventoryDetails), System.Text.Encoding.UTF8, "application/json");
                        HttpResponseMessage response = await client.PutAsync($"{apiBaseUrl}/{id}", content);
                        if (response.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Inventory_DetailsList");
                        }
                    }
                }
                return View(inventoryDetails);
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while updating inventory details.");
                return View(inventoryDetails);
            }
        }

        // GET: Inventory_Details/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{apiBaseUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var inventoryDetails = JsonConvert.DeserializeObject<Inventory_Details>(data);
                    return View(inventoryDetails);
                }
                return HttpNotFound();
            }
        }

        // POST: Inventory_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.DeleteAsync($"{apiBaseUrl}/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Inventory_DetailsList");
                    }
                }
                return RedirectToAction("Inventory_DetailsList");
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while deleting inventory details.");
                return RedirectToAction("Inventory_DetailsList");
            }
        }

        // GET: Inventory_Details/Details/5
        public async Task<ActionResult> Details(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{apiBaseUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var inventoryDetails = JsonConvert.DeserializeObject<Inventory_Details>(data);
                    return View(inventoryDetails);
                }
                return HttpNotFound();
            }
        }
    }
}