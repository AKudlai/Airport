namespace Airport.WebApp.Controllers
{
    using System;
    using System.Net;
    using System.Web.Mvc;

    using Airport.Contracts;
    using Airport.Models.DomainModels.Entities;
    using Airport.Services.Repositories;

    public class AircraftController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public AircraftController()
        {
            this.unitOfWork = new UnitOfWork();
        }

        // GET: Aircraft
        public ActionResult Index()
        {
            return this.View(this.unitOfWork.Aircrafts.Find(p => true));
        }

        // GET: Aircraft/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var aircraft = this.unitOfWork.Aircrafts.Get(id);
            if (aircraft == null)
            {
                return this.HttpNotFound();
            }
            return this.View(aircraft);
        }

        // GET: Aircraft/Create
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: Aircraft/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Model,Photo,SitsPlan,FirstClassSitCount,BusinessClassSitCount,EconomyClassSitCount")] Aircraft aircraft)
        {
            if (this.ModelState.IsValid)
            {
                aircraft.Id = Guid.NewGuid();
                this.unitOfWork.Aircrafts.Add(aircraft);
                this.unitOfWork.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(aircraft);
        }

        // GET: Aircraft/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var aircraft = this.unitOfWork.Aircrafts.Get(id);
            if (aircraft == null)
            {
                return this.HttpNotFound();
            }
            return this.View(aircraft);
        }

        // POST: Aircraft/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Model,Photo,SitsPlan,FirstClassSitCount,BusinessClassSitCount,EconomyClassSitCount")] Aircraft aircraft)
        {
            if (this.ModelState.IsValid)
            {
                this.unitOfWork.Aircrafts.Update(aircraft);
                this.unitOfWork.SaveChanges();
                return this.RedirectToAction("Index");
            }
            return this.View(aircraft);
        }

        // GET: Aircraft/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var aircraft = this.unitOfWork.Aircrafts.Get(id);
            if (aircraft == null)
            {
                return this.HttpNotFound();
            }
            return this.View(aircraft);
        }

        // POST: Aircraft/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            this.unitOfWork.Aircrafts.Remove(id);
            this.unitOfWork.SaveChanges();
            return this.RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.unitOfWork.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
