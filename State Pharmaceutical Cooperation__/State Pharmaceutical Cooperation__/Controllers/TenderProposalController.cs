using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using State_Pharmaceutical_Cooperation__.Models;

namespace State_Pharmaceutical_Cooperation__.Controllers
{
    public class TenderProposalController : Controller
    {
        private readonly string apiBaseUrl = "https://localhost:7168/api/TenderProposals"; // Your API URL

        // GET: TenderProposal_Details
        public ActionResult TenderProposalList()
        {
            using (Model7 dbModel17 = new Model7())
            {
                return View(dbModel17.TenderProposals.ToList());
            }
        }

        // GET: TenderProposal/Details/5
        public async Task<ActionResult> Details(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{apiBaseUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var tenderProposal = JsonConvert.DeserializeObject<TenderProposal>(data);
                    return View(tenderProposal);
                }
                return HttpNotFound();
            }
        }

        // GET: TenderProposal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TenderProposal/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TenderProposal tenderProposal)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(tenderProposal), System.Text.Encoding.UTF8, "application/json");
                        HttpResponseMessage response = await client.PostAsync(apiBaseUrl, content);
                        if (response.IsSuccessStatusCode)
                        {
                            return RedirectToAction("TenderProposalList");
                        }
                    }
                }
                return View(tenderProposal);
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while saving the Tender Proposal.");
                return View(tenderProposal);
            }
        }

        // GET: proposal_Details/Status/5
        public ActionResult Status(int id)
        {
            using (Model7 dbModel17 = new Model7())
            {
                var tenderproposal = dbModel17.TenderProposals.Find(id);
                if (tenderproposal == null)
                {
                    return HttpNotFound();
                }
                return View(tenderproposal);
            }
        }
        // POST: /Status/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Status(int id, string newStatus)
        {
            using (Model7 dbModel17 = new Model7())
            {
                var tenderproposal = dbModel17.TenderProposals.Find(id);
                if (tenderproposal == null)
                {
                    return HttpNotFound();
                }

                // Update the status
                tenderproposal.Status = newStatus;
                dbModel17.Entry(tenderproposal).State = System.Data.Entity.EntityState.Modified;
                dbModel17.SaveChanges();

                return RedirectToAction("TenderProposalList");
            }
        }

        // GET: TenderProposal/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{apiBaseUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var tenderProposal = JsonConvert.DeserializeObject<TenderProposal>(data);
                    return View(tenderProposal);
                }
                return HttpNotFound();
            }
        }

        // POST: TenderProposal/Delete/5
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
                        return RedirectToAction("TenderProposalList");
                    }
                }
                return RedirectToAction("TenderProposalList");
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while deleting the Tender Proposal.");
                return RedirectToAction("TenderProposalList");
            }
        }
    }
}












