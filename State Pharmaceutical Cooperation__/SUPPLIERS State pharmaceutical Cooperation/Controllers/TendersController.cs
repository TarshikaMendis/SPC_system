using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using SUPPLIERS_State_pharmaceutical_Cooperation.Models;

namespace SUPPLIERS_State_pharmaceutical_Cooperation.Controllers
{
    public class TendersController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;

        public TendersController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7168/api/Tenders"); // Replace with actual API URL
            _apiBaseUrl = "https://localhost:7168/api/Tenders"; // Replace with actual API URL
        }

        // GET: Tenders
        public async Task<ActionResult> TendersList()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(""); // Fetch all tenders
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var tenders = JsonConvert.DeserializeObject<List<Tender>>(data);
                return View(tenders);
            }
            return View(new List<Tender>());
        }

        // GET: Tenders/Details/{id}
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_apiBaseUrl}/{id}"); // Fetch tender by ID
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var tender = JsonConvert.DeserializeObject<Tender>(jsonResponse);
                    return View(tender);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error fetching tender details: " + ex.Message;
            }
            return HttpNotFound();
        }

        // GET: Tenders/RedirectToTenderApprovals/{id}
     


        public ActionResult RedirectToTenderApprovals(int id, string drugName, int quantity)
        {
            // Redirect to the TenderApproval form in the appropriate controller (e.g., TenderApprovalController)
            return RedirectToAction("Create", "TenderApprovals", new { tenderId = id, drugName = drugName, quantity = quantity });
        }
    }
}
