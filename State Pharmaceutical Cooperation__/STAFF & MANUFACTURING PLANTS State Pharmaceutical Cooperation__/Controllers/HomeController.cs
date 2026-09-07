using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Text;
using STAFF___MANUFACTURING_PLANTS_State_Pharmaceutical_Cooperation__.Models;
using System.Collections.Generic;

namespace STAFF___MANUFACTURING_PLANTS_State_Pharmaceutical_Cooperation__.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string apiBaseUrl = "https://localhost:7168/api/Inventory_Details";

        public HomeController()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7168/api/") };
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.ErrorMessage = "Email and Password are required.";
                return View();
            }

            var response = await _httpClient.GetAsync("StaffManufacturing");
            if (response.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<List<StaffManufacturing>>(await response.Content.ReadAsStringAsync());
                var staff = data?.Find(s => s.email == email && s.password == password);

                if (staff != null)
                {
                    Session["StaffId"] = staff.id;
                    Session["StaffEmail"] = staff.email;
                    return RedirectToAction("Dashboard");
                }
            }

            ViewBag.ErrorMessage = "Invalid Email or Password.";
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Dashboard()
        {
            if (Session["StaffId"] == null)
            {
                return RedirectToAction("Index");
            }

            var response = await _httpClient.GetAsync("Inventory_Details");
            if (response.IsSuccessStatusCode)
            {
                var inventoryList = JsonConvert.DeserializeObject<List<Inventory_Details>>(await response.Content.ReadAsStringAsync());
                ViewBag.StaffEmail = Session["StaffEmail"];
                return View(inventoryList);
            }

            return View(new List<Inventory_Details>());
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
                            return RedirectToAction("Dashboard");
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
            var response = await _httpClient.GetAsync($"Inventory_Details/{id}");
            if (response.IsSuccessStatusCode)
            {
                var inventory = JsonConvert.DeserializeObject<Inventory_Details>(await response.Content.ReadAsStringAsync());
                return View(inventory);
            }
            return HttpNotFound();
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
                    var content = new StringContent(JsonConvert.SerializeObject(inventoryDetails), Encoding.UTF8, "application/json");
                    var response = await _httpClient.PutAsync($"{apiBaseUrl}/{id}", content);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Dashboard");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Unable to update inventory details. Please try again.");
                    }
                }
                return View(inventoryDetails);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while updating inventory details: " + ex.Message);
                return View(inventoryDetails);
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            var response = await _httpClient.GetAsync($"Inventory_Details/{id}");
            if (response.IsSuccessStatusCode)
            {
                var inventory = JsonConvert.DeserializeObject<Inventory_Details>(await response.Content.ReadAsStringAsync());
                return View(inventory);
            }
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _httpClient.DeleteAsync($"Inventory_Details/{id}");
            return RedirectToAction("Dashboard");
        }
    }
}
