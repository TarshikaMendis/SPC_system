using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using State_Pharmaceutical_Cooperation__.Models;

namespace State_Pharmaceutical_Cooperation__.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using State_Pharmaceutical_Cooperation__.Models;

    public class AdminController : Controller
    {

 // GET: Admin List
public ActionResult AdminList()
        {
            using (Model1 dbmodel = new Model1())
            {
                return View(dbmodel.Admins.ToList());
            }
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Admin admin)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Model1 dbmodel = new Model1())
                    {
                        dbmodel.Admins.Add(admin);
                        dbmodel.SaveChanges();
                    }
                    return RedirectToAction("AdminList");
                }
                return View(admin);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while saving the admin.");
                return View(admin);
            }
        }
        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            using (Model1 dbmodel = new Model1())
            {
                var admin = dbmodel.Admins.Find(id);
                if (admin == null) return HttpNotFound();
                return View(admin);
            }
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Admin admin)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Model1 dbmodel = new Model1())
                    {
                        dbmodel.Entry(admin).State = System.Data.Entity.EntityState.Modified;
                        dbmodel.SaveChanges();
                    }
                    return RedirectToAction("AdminList");
                }
                return View(admin);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while updating the admin.");
                return View(admin);
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            using (Model1 dbmodel = new Model1())
            {
                var admin = dbmodel.Admins.Find(id);
                if (admin == null) return HttpNotFound();
                return View(admin);
            }
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                using (Model1 dbmodel = new Model1())
                {
                    var admin = dbmodel.Admins.Find(id);
                    if (admin != null)
                    {
                        dbmodel.Admins.Remove(admin);
                        dbmodel.SaveChanges();
                    }
                }
                return RedirectToAction("AdminList");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while deleting the admin.");
                return RedirectToAction("AdminList");
            }
        }


        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            using (Model1 dbmodel = new Model1())
            {
                var admin = dbmodel.Admins.Find(id);
                if (admin == null) return HttpNotFound();
                return View(admin);
            }
        }


    }
}