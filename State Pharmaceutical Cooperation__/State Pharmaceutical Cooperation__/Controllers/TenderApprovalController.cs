using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using State_Pharmaceutical_Cooperation__.Models;

namespace State_Pharmaceutical_Cooperation__.Controllers
{
    public class TenderApprovalController : Controller
    {
        private readonly string apiBaseUrl = "https://localhost:7168/api/TenderApprovals"; // Your API URL

        // GET: TenderApproval
        public async Task<ActionResult> TenderApprovalsList()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiBaseUrl);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var approvals = JsonConvert.DeserializeObject<List<TenderApproval>>(data);
                    return View(approvals);
                }
                return View(new List<TenderApproval>());
            }
        }

        // GET: TenderApproval/Details/5
        public async Task<ActionResult> Details(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{apiBaseUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var approval = JsonConvert.DeserializeObject<TenderApproval>(data);
                    return View(approval);
                }
                return HttpNotFound();
            }
        }

        // GET: TenderApproval/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TenderApproval/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TenderApproval tenderApproval)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(tenderApproval), System.Text.Encoding.UTF8, "application/json");
                        HttpResponseMessage response = await client.PostAsync(apiBaseUrl, content);
                        if (response.IsSuccessStatusCode)
                        {
                            return RedirectToAction("TenderApprovalsList");
                        }
                    }
                }
                return View(tenderApproval);
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while saving the tender approval.");
                return View(tenderApproval);
            }
        }

        // GET: TenderApproval/Status/5
        public ActionResult Status(int id)
        {
            using (Model8 dbModel18 = new Model8())
            {
                var tenderApproval = dbModel18.TenderApprovals.Find(id);
                if (tenderApproval == null)
                {
                    return HttpNotFound();
                }
                return View(tenderApproval);
            }
        }

        // POST: TenderApproval/Status/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Status(int id, string newStatus)
        {
            using (Model8 dbModel18 = new Model8())
            {
                var tenderApproval = dbModel18.TenderApprovals.Find(id);
                if (tenderApproval == null)
                {
                    return HttpNotFound();
                }

                // Update the status
                tenderApproval.Status = newStatus;
                dbModel18.Entry(tenderApproval).State = System.Data.Entity.EntityState.Modified;
                dbModel18.SaveChanges();

                return RedirectToAction("TenderApprovalsList");
            }
        }

        // GET: TenderApproval/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{apiBaseUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var approval = JsonConvert.DeserializeObject<TenderApproval>(data);
                    return View(approval);
                }
                return HttpNotFound();
            }
        }

        // POST: TenderApproval/Delete/5
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
                        return RedirectToAction("TenderApprovalsList");
                    }
                }
                return RedirectToAction("TenderApprovalsList");
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while deleting the tender approval.");
                return RedirectToAction("TenderApprovalsList");
            }
        }
    }
}
