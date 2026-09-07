using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using State_Pharmaceutical_Cooperation__.Models;

namespace State_Pharmaceutical_Cooperation__.Controllers
{
    public class PharmacyController : Controller
    {
        private readonly string apiBaseUrl = "https://localhost:7168/api/Pharmacies"; // Your API URL

        // GET: Pharmacy/PharmacyList
        public async Task<ActionResult> PharmacyList()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiBaseUrl);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var pharmacies = JsonConvert.DeserializeObject<List<Pharmacy>>(data);
                    return View(pharmacies);
                }
                return View(new List<Pharmacy>());
            }
        }

        // GET: Pharmacy/Details/5
        public async Task<ActionResult> Details(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{apiBaseUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var pharmacy = JsonConvert.DeserializeObject<Pharmacy>(data);
                    return View(pharmacy);
                }
                return HttpNotFound();
            }
        }

        // GET: Pharmacy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pharmacy/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Pharmacy pharmacy)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(pharmacy), System.Text.Encoding.UTF8, "application/json");
                        HttpResponseMessage response = await client.PostAsync(apiBaseUrl, content);
                        if (response.IsSuccessStatusCode)
                        {
                            return RedirectToAction("PharmacyList");
                        }
                    }
                }
                return View(pharmacy);
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while saving the Pharmacy.");
                return View(pharmacy);
            }
        }

        // GET: Pharmacy/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{apiBaseUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var pharmacy = JsonConvert.DeserializeObject<Pharmacy>(data);
                    return View(pharmacy);
                }
                return HttpNotFound();
            }
        }

        // POST: Pharmacy/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Pharmacy pharmacy)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(pharmacy), System.Text.Encoding.UTF8, "application/json");
                        HttpResponseMessage response = await client.PutAsync($"{apiBaseUrl}/{id}", content);
                        if (response.IsSuccessStatusCode)
                        {
                            return RedirectToAction("PharmacyList");
                        }
                    }
                }
                return View(pharmacy);
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while updating the Pharmacy.");
                return View(pharmacy);
            }
        }

        // GET: Pharmacy/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{apiBaseUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var pharmacy = JsonConvert.DeserializeObject<Pharmacy>(data);
                    return View(pharmacy);
                }
                return HttpNotFound();
            }
        }

        // POST: Pharmacy/Delete/5
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
                        return RedirectToAction("PharmacyList");
                    }
                }
                return RedirectToAction("PharmacyList");
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while deleting the Pharmacy.");
                return RedirectToAction("PharmacyList");
            }
        }
    }
}
