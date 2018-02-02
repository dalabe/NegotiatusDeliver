using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Deliver.Models;

namespace Deliver.Controllers
{
    public class ShipmentsController : Controller
    {
        private DeliverEntities db = new DeliverEntities();

        // GET: Shipments
        public async Task<ActionResult> Index()
        {
            var shipments = db.Shipments.Include(s => s.Vendor);
            return View(await shipments.ToListAsync());
        }

        // GET: Shipments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipment shipment = await db.Shipments.FindAsync(id);
            if (shipment == null)
            {
                return HttpNotFound();
            }
            return View(shipment);
        }

        // GET: Shipments/Create
        public ActionResult Create()
        {
            ViewBag.vendorId = new SelectList(db.Vendors, "id", "vendorName");
            return View();
        }

        // POST: Shipments/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,orderedDate,shipedDate,deliveredDate,trackingNumber,originAddress,originPoint,destinationAddress,destinationPoint,vendorId,lastPointReported,estimatedDeliverDate")] Shipment shipment)
        {
            if (ModelState.IsValid)
            {
                db.Shipments.Add(shipment);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.vendorId = new SelectList(db.Vendors, "id", "vendorName", shipment.vendorId);
            return View(shipment);
        }

        // GET: Shipments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipment shipment = await db.Shipments.FindAsync(id);
            if (shipment == null)
            {
                return HttpNotFound();
            }
            ViewBag.vendorId = new SelectList(db.Vendors, "id", "vendorName", shipment.vendorId);
            return View(shipment);
        }

        // POST: Shipments/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,orderedDate,shipedDate,deliveredDate,trackingNumber,originAddress,originPoint,destinationAddress,destinationPoint,vendorId,lastPointReported,estimatedDeliverDate")] Shipment shipment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shipment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.vendorId = new SelectList(db.Vendors, "id", "vendorName", shipment.vendorId);
            return View(shipment);
        }

        // GET: Shipments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipment shipment = await db.Shipments.FindAsync(id);
            if (shipment == null)
            {
                return HttpNotFound();
            }
            return View(shipment);
        }

        // POST: Shipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Shipment shipment = await db.Shipments.FindAsync(id);
            db.Shipments.Remove(shipment);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
