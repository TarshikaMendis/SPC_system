using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using State_Pharmaceutical_Cooperation__.Models;

namespace State_Pharmaceutical_Cooperation__.Controllers
{
    public class TenderController : Controller
    {
        private readonly string apiBaseUrl = "https://localhost:7168/api/Tenders"; // Your API URL

        // GET: TenderList
        public async Task<ActionResult> TenderList()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiBaseUrl);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var tenders = JsonConvert.DeserializeObject<List<Tender>>(data);
                    return View(tenders);
                }
                return View(new List<Tender>());
            }
        }
        // GET: Tender/Details/5
        public async Task<ActionResult> Details(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{apiBaseUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var tender = JsonConvert.DeserializeObject<Tender>(data);
                    return View(tender);
                }
                return HttpNotFound();
            }
        }

        // GET: Tender/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tender/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Tender tender)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(tender), System.Text.Encoding.UTF8, "application/json");
                        HttpResponseMessage response = await client.PostAsync(apiBaseUrl, content);
                        if (response.IsSuccessStatusCode)
                        {
                            return RedirectToAction("TenderList");
                        }
                    }
                }
                return View(tender);
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while saving the tender.");
                return View(tender);
            }
        }

        // GET: Tender/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{apiBaseUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var tender = JsonConvert.DeserializeObject<Tender>(data);
                    return View(tender);
                }
                return HttpNotFound();
            }
        }

        // POST: Tender/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Tender tender)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(tender), System.Text.Encoding.UTF8, "application/json");
                        HttpResponseMessage response = await client.PutAsync($"{apiBaseUrl}/{id}", content);
                        if (response.IsSuccessStatusCode)
                        {
                            return RedirectToAction("TenderList");
                        }
                    }
                }
                return View(tender);
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while updating the tender.");
                return View(tender);
            }
        }

        // GET: Tender/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{apiBaseUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var tender = JsonConvert.DeserializeObject<Tender>(data);
                    return View(tender);
                }
                return HttpNotFound();
            }
        }

        // POST: Tender/Delete/5
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
                        return RedirectToAction("TenderList");
                    }
                }
                return RedirectToAction("TenderList");
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while deleting the tender.");
                return RedirectToAction("TenderList");
            }
        }

    }
}
