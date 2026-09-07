using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;


using PHARMACIES_State_pharmaceutical_Cooperation.Models;

namespace PHARMACIES_State_pharmaceutical_Cooperation.Controllers
{
    public class HomeController : Controller
    {
        private readonly string apiBaseUrl = "https://localhost:7168/api/PharmaciesAuth"; // Update with actual API URL
        private readonly HttpClient _httpClient = new HttpClient(); // Add this line

        private Model1 db = new Model1();

        // GET: Home/Index
        public ActionResult Index()
        {
            return View();
        }

        // POST: Home/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.ErrorMessage = "Email and Password are required.";
                return View();
            }

            // Check if the user exists in the Pharmacy table
            var pharmacy = db.Pharmacies.FirstOrDefault(p => p.Email == email && p.Password == password);
            if (pharmacy != null)
            {
                // Successful login
                // Set session or authentication cookies here
                Session["PharmacyId"] = pharmacy.Id; // Store the pharmacy ID in the session
                Session["PharmacyEmail"] = pharmacy.Email; // Store the pharmacy email in the session

                return RedirectToAction("Dashboard"); // Redirect to the dashboard
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Email or Password.";
                return View();
            }
        }

        // GET: Home/Logout
        public ActionResult Logout()
        {
            // Clear the session
            Session.Clear();
            Session.Abandon();

            // Redirect to the login page
            return RedirectToAction("Index");
        }


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.ErrorMessage = "Email and Password are required.";
                return View();
            }

            using (HttpClient client = new HttpClient())
            {
                var payload = new { Email = email, Password = password };
                var jsonContent = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiBaseUrl + "/register", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    ViewBag.SuccessMessage = "Registration successful. Please login.";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorMessage = "Email is already registered.";
                    return View();
                }
            }
        }

        public ActionResult Dashboard()
        {
            if (Session["PharmacyId"] == null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult Notifications()
        {
            ViewBag.Message = "Your notifications page.";
            return View();
        }

        public ActionResult PharmacyNotificationsList()
        {
            return View();
        }
    }
}