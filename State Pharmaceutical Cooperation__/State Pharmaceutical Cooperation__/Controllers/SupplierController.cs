using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using State_Pharmaceutical_Cooperation__.Models;

namespace State_Pharmaceutical_Cooperation__.Controllers
{
    public class SupplierController : Controller
    {
        private readonly string apiBaseUrl = "https://localhost:7168/api/Suppliers"; // Your API URL

        // GET: Supplier/SupplierList
        public async Task<ActionResult> SupplierList()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiBaseUrl);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(data);
                    return View(suppliers);
                }
                return View(new List<Supplier>());
            }
        }

        // GET: Supplier/Details/5
        public async Task<ActionResult> Details(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{apiBaseUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var supplier = JsonConvert.DeserializeObject<Supplier>(data);
                    return View(supplier);
                }
                return HttpNotFound();
            }
        }

        // GET: Supplier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Supplier/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Supplier supplier)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(supplier), System.Text.Encoding.UTF8, "application/json");
                        HttpResponseMessage response = await client.PostAsync(apiBaseUrl, content);
                        if (response.IsSuccessStatusCode)
                        {
                            return RedirectToAction("SupplierList");
                        }
                    }
                }
                return View(supplier);
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while saving the supplier.");
                return View(supplier);
            }
        }

        // GET: Supplier/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{apiBaseUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var supplier = JsonConvert.DeserializeObject<Supplier>(data);
                    return View(supplier);
                }
                return HttpNotFound();
            }
        }

        // POST: Supplier/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Supplier supplier)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(supplier), System.Text.Encoding.UTF8, "application/json");
                        HttpResponseMessage response = await client.PutAsync($"{apiBaseUrl}/{id}", content);
                        if (response.IsSuccessStatusCode)
                        {
                            return RedirectToAction("SupplierList");
                        }
                    }
                }
                return View(supplier);
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while updating the supplier.");
                return View(supplier);
            }
        }

        // GET: Supplier/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{apiBaseUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var supplier = JsonConvert.DeserializeObject<Supplier>(data);
                    return View(supplier);
                }
                return HttpNotFound();
            }
        }

        // POST: Supplier/Delete/5
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
                        return RedirectToAction("SupplierList");
                    }
                }
                return RedirectToAction("SupplierList");
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while deleting the supplier.");
                return RedirectToAction("SupplierList");
            }
        }
    }
}
