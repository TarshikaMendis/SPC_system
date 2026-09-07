using System;
using System.Linq;
using System.Web.Mvc;
using PHARMACIES_State_pharmaceutical_Cooperation.Models;

namespace PHARMACIES_State_pharmaceutical_Cooperation.Controllers
{
    public class Inventory_DetailsController : Controller
    {
        // GET: Inventory_Details
        public ActionResult Inventory_DetailsList()
        {
            using (Model4 db = new Model4()) // Inventory_Details from Model4
            {
                return View(db.Inventory_Details.ToList());
            }
        }

        // GET: Inventory_Details/Details/5
        public ActionResult Details(int id)
        {
            using (Model4 db = new Model4()) // Use Model4 for Inventory
            {
                var inventoryDetails = db.Inventory_Details.Find(id);
                if (inventoryDetails == null) return HttpNotFound();
                return View(inventoryDetails);
            }
        }
        // GET: Inventory_Details/OrderNow/5
        public ActionResult OrderNow(int id)
        {
            using (Model4 db = new Model4())
            {
                var inventoryItem = db.Inventory_Details.Find(id);
                if (inventoryItem == null)
                {
                    return HttpNotFound();
                }

                // Pre-fill the order form with data from the inventory item
                var orderDetails = new Orders_Details
                {
                    Drug_Name = inventoryItem.Drug_Name,
                    Batch_Number = inventoryItem.Batch_Number,
                    Unit_Price = decimal.Parse(inventoryItem.Unit_Price) // Convert string to decimal
                };

                return View(orderDetails);
            }
        }

        // POST: Inventory_Details/OrderNow
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OrderNow(Orders_Details orderDetails)
        {
            if (ModelState.IsValid)
            {
                using (Model4 db = new Model4())
                {
                    // Set additional order details
                    orderDetails.Order_Date = DateTime.Now;
                    orderDetails.Total_Cost = orderDetails.Quantity_Ordered * orderDetails.Unit_Price;
                    orderDetails.Status = "Pending";

                    // Save the order to the database
                    db.Orders_Details.Add(orderDetails);
                    db.SaveChanges();

                    // Set success message in TempData
                    TempData["SuccessMessage"] = "Order placed success! Go Order Details and view order.";

                    // Redirect to the inventory list after successful order placement
                    return RedirectToAction("Inventory_DetailsList");
                }
            }

            // If the model state is invalid, return the view with validation errors
            return View(orderDetails);
        }
    

       // GET: Orders_Details
        public ActionResult Orders_DetailsList()
        {
            using (Model5 db6 = new Model5())  // Ensure correct context name
            {
                return View(db6.Orders_Details.ToList());  // Fetching orders details
            }
        }


        // GET: Orders_Details/Details/5
        public ActionResult Details_Order(int id)
        {
            using (Model5 db6 = new Model5())
            {
                var OrdersDetails = db6.Orders_Details.Find(id);
                if (OrdersDetails == null) return HttpNotFound();
                return View(OrdersDetails);
            }
        }
    }
    }
