using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using State_Pharmaceutical_Cooperation__.Models;

namespace State_Pharmaceutical_Cooperation__.Controllers
{
    public class Orders_DetailsController : Controller
    {
        private readonly string apiBaseUrl = "https://localhost:7168/api/Orders_Details"; // Your API URL

        // GET: Orders_Details
        public async Task<ActionResult> Orders_DetailsList()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiBaseUrl);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var orders = JsonConvert.DeserializeObject<List<Orders_Details>>(data);
                    return View(orders);
                }
                return View(new List<Orders_Details>());
            }
        }

        // GET: Orders_Details/Details/5
        public async Task<ActionResult> Details(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{apiBaseUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var order = JsonConvert.DeserializeObject<Orders_Details>(data);
                    return View(order);
                }
                return HttpNotFound();
            }
        }

        // GET: Orders_Details/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders_Details/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Orders_Details order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(order), System.Text.Encoding.UTF8, "application/json");
                        HttpResponseMessage response = await client.PostAsync(apiBaseUrl, content);
                        if (response.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Orders_DetailsList");
                        }
                    }
                }
                return View(order);
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while saving the order.");
                return View(order);
            }
        }

        // GET: Orders_Details/Status/5
        public ActionResult Status(int id)
        {
            using (Model5 dbModel15 = new Model5())
            {
                var order = dbModel15.Orders_Details.Find(id);
                if (order == null)
                {
                    return HttpNotFound();
                }
                return View(order);
            }
        }

        // POST: Orders_Details/Status/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Status(int id, string newStatus)
        {
            using (Model5 dbModel15 = new Model5())
            {
                var order = dbModel15.Orders_Details.Find(id);
                if (order == null)
                {
                    return HttpNotFound();
                }

                // Update the status
                order.Status = newStatus;
                dbModel15.Entry(order).State = System.Data.Entity.EntityState.Modified;
                dbModel15.SaveChanges();

                return RedirectToAction("Orders_DetailsList");
            }
        }

        // GET: Orders_Details/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{apiBaseUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var order = JsonConvert.DeserializeObject<Orders_Details>(data);
                    return View(order);
                }
                return HttpNotFound();
            }
        }

        // POST: Orders_Details/Delete/5
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
                        return RedirectToAction("Orders_DetailsList");
                    }
                }
                return RedirectToAction("Orders_DetailsList");
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while deleting the order.");
                return RedirectToAction("Orders_DetailsList");
            }
        }
    }
}