using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using System.Web.Mvc;
using System;
using SUPPLIERS_State_pharmaceutical_Cooperation.Models;
using System.Linq;
public class HomeController : Controller
{
    private readonly HttpClient _httpClient;

    public HomeController()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://localhost:7168/api/SuppliersAuth/"); // Update with your API base URL
    }

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

        // Check if the user exists in the Supplier table
        var supplier = db.Suppliers.FirstOrDefault(s => s.Email == email && s.Password == password);
        if (supplier != null)
        {
            // Successful login
            // Set session or authentication cookies here
            Session["SupplierId"] = supplier.Id; // Store the supplier ID in the session
            Session["SupplierEmail"] = supplier.Email; // Store the supplier email in the session

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

    // GET: Home/Register
    public ActionResult Register()
    {
        return View();
    }

    // POST: Home/Register
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Register(string email, string password, string confirmPassword)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
        {
            ViewBag.ErrorMessage = "All fields are required.";
            return View();
        }

        if (password != confirmPassword)
        {
            ViewBag.ErrorMessage = "Passwords do not match.";
            return View();
        }

        var registerData = new { Email = email, Password = password };
        var json = JsonConvert.SerializeObject(registerData);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // Call the SuppliersAuthController register endpoint
        HttpResponseMessage response = await _httpClient.PostAsync("register", content);

        if (response.IsSuccessStatusCode)
        {
            ViewBag.SuccessMessage = "Registration successful. Please login.";
            return RedirectToAction("Index");
        }
        else
        {
            ViewBag.ErrorMessage = "Registration failed. Please try again.";
            return View();
        }
    }

    // GET: Home/Dashboard
    public ActionResult Dashboard()
    {
        // Check if the supplier is logged in
        if (Session["SupplierId"] == null)
        {
            return RedirectToAction("Index");
        }

        return View();
    }

    // GET: Home/Dashboard
    public ActionResult Notifications()
    {
        

        return View();
    }


    public ActionResult Tender()
    {


        return View();
    }
}
