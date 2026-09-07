using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using SUPPLIERS_State_pharmaceutical_Cooperation.Models;

namespace SUPPLIERS_State_pharmaceutical_Cooperation.Controllers
{
    public class TenderApprovalsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;

        public TenderApprovalsController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7168/api/TenderApprovals"); // Replace with your API URL
            _apiBaseUrl = "https://localhost:7168/api/TenderApprovals"; // Replace with your API URL
        }

        // GET: TenderApprovals
        public async Task<ActionResult> TenderApprovalsList()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var tenderApprovals = JsonConvert.DeserializeObject<List<TenderApproval>>(data);
                    return View(tenderApprovals);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error fetching tender approvals: " + ex.Message;
            }
            return View(new List<TenderApproval>());
        }

        // GET: TenderApprovals/Create
        public ActionResult Create(int tenderId, string drugName, int quantity)
        {
            // Pass tender details to the view
            ViewBag.TenderID = tenderId;
            ViewBag.DrugName = drugName;
            ViewBag.Quantity = quantity;

            return View();
        }

        // POST: TenderApprovals/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TenderApproval tenderApproval)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(tenderApproval), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync("", content);

                if (response.IsSuccessStatusCode)
                {
                    // Add success message to TempData
                    TempData["SuccessMessage"] = "Tender approved successfully! Check Tender Approvals List to view your tender status.";
                    return RedirectToAction("TenderApprovalsList");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error creating tender approval: " + ex.Message;
            }

            return View(tenderApproval);
        }

        // GET: TenderApprovals/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_apiBaseUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var tenderApproval = JsonConvert.DeserializeObject<TenderApproval>(jsonResponse);
                    return View(tenderApproval);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error fetching tender approval details: " + ex.Message;
            }
            return HttpNotFound();
        }

      

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _httpClient.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
