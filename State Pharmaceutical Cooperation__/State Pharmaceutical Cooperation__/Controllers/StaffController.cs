using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using State_Pharmaceutical_Cooperation__.Models;

namespace State_Pharmaceutical_Cooperation__.Controllers
{
    public class StaffController : Controller
    {
        private readonly string apiBaseUrl = "https://localhost:7168/api/StaffManufacturing"; // Your API URL

        // GET: Staff Manufacturing List
        public async Task<ActionResult> StaffManufacturingList()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiBaseUrl);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var staffList = JsonConvert.DeserializeObject<List<StaffManufacturing>>(data);
                    return View(staffList);
                }
                return View(new List<StaffManufacturing>());
            }
        }

        // GET: Staff/Details/5
        public async Task<ActionResult> Details(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{apiBaseUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var staffMember = JsonConvert.DeserializeObject<StaffManufacturing>(data);
                    return View(staffMember);
                }
                return HttpNotFound();
            }
        }

        // GET: Staff/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staff/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(StaffManufacturing staffManufacturing)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(staffManufacturing), System.Text.Encoding.UTF8, "application/json");
                        HttpResponseMessage response = await client.PostAsync(apiBaseUrl, content);
                        if (response.IsSuccessStatusCode)
                        {
                            return RedirectToAction("StaffManufacturingList");
                        }
                    }
                }
                return View(staffManufacturing);
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while saving the staff.");
                return View(staffManufacturing);
            }
        }

        // GET: Staff/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{apiBaseUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var staffMember = JsonConvert.DeserializeObject<StaffManufacturing>(data);
                    return View(staffMember);
                }
                return HttpNotFound();
            }
        }

        // POST: Staff/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, StaffManufacturing staffManufacturing)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(staffManufacturing), System.Text.Encoding.UTF8, "application/json");
                        HttpResponseMessage response = await client.PutAsync($"{apiBaseUrl}/{id}", content);
                        if (response.IsSuccessStatusCode)
                        {
                            return RedirectToAction("StaffManufacturingList");
                        }
                    }
                }
                return View(staffManufacturing);
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while updating the staff.");
                return View(staffManufacturing);
            }
        }

        // GET: Staff/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{apiBaseUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var staffMember = JsonConvert.DeserializeObject<StaffManufacturing>(data);
                    return View(staffMember);
                }
                return HttpNotFound();
            }
        }

        // POST: Staff/Delete/5
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
                        return RedirectToAction("StaffManufacturingList");
                    }
                }
                return RedirectToAction("StaffManufacturingList");
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while deleting the staff.");
                return RedirectToAction("StaffManufacturingList");
            }
        }
    }
}
