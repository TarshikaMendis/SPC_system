using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using SUPPLIERS_State_pharmaceutical_Cooperation.Models;

namespace SUPPLIERS_State_pharmaceutical_Cooperation.Controllers
{
    public class TenderProposalController : Controller
    {
        private Model6 db = new Model6();

        // GET: TenderProposal/TenderProposalList
        public ActionResult TenderProposalList()
        {
            var tenderProposals = db.TenderProposals.ToList();
            return View(tenderProposals);
        }


        // GET: TenderProposal/Create
        public ActionResult Create()
        {
            return View();
        }



        // POST: TenderProposal/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TenderProposal tenderProposal)
        {
            if (ModelState.IsValid)
            {

                db.TenderProposals.Add(tenderProposal);

                db.SaveChanges();
                return RedirectToAction("TenderProposalList");

            }
            return View(tenderProposal);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}