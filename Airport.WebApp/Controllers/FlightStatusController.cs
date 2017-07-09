namespace Airport.WebApp.Controllers
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using Airport.Contracts;
    using Airport.DAL;
    using Airport.Models.DomainModels.Entities;
    using Airport.Services.Repositories;

    public class FlightStatusController : Controller
    {
        private AirportContext db = new AirportContext();

        private readonly IUnitOfWork unitOfWork;

        public FlightStatusController()
        {
            this.unitOfWork = new UnitOfWork();
        }

        // GET: FlightStatus
        public ActionResult Index()
        {
            return this.View(this.unitOfWork.FlightStatuses.Find(p => true));
        }

        // GET: FlightStatus/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var flightStatus = this.unitOfWork.FlightStatuses.Get(id);
            if (flightStatus == null)
            {
                return this.HttpNotFound();
            }
            return this.View(flightStatus);
        }

        // GET: FlightStatus/Create
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: FlightStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] FlightStatus flightStatus)
        {
            if (this.ModelState.IsValid)
            {
                flightStatus.Id = Guid.NewGuid();
                this.unitOfWork.FlightStatuses.Add(flightStatus);
                this.unitOfWork.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(flightStatus);
        }

        // GET: FlightStatus/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var flightStatus = this.unitOfWork.FlightStatuses.Get(id);
            if (flightStatus == null)
            {
                return this.HttpNotFound();
            }
            return this.View(flightStatus);
        }

        // POST: FlightStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] FlightStatus flightStatus)
        {
            if (this.ModelState.IsValid)
            {
                this.unitOfWork.FlightStatuses.Update(flightStatus);
                this.unitOfWork.SaveChanges();
                return this.RedirectToAction("Index");
            }
            return this.View(flightStatus);
        }

        // GET: FlightStatus/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var flightStatus = this.unitOfWork.FlightStatuses.Get(id);
            if (flightStatus == null)
            {
                return this.HttpNotFound();
            }
            return this.View(flightStatus);
        }

        // POST: FlightStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            this.unitOfWork.FlightStatuses.Remove(id);
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
