namespace Airport.WebApp.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using Airport.Contracts;
    using Airport.DAL;
    using Airport.Models.DomainModels.Entities;
    using Airport.Models.ViewModels;
    using Airport.Services.Repositories;

    public class FlightsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly FlightPanelView flightPanelView;

        private readonly AirportContext db;

        public FlightsController()
        {
            this.flightPanelView = new FlightPanelView();
            this.unitOfWork = new UnitOfWork();
            this.db = new AirportContext();
        }

        // GET: Flights
        public ActionResult Index()
        {
            var flights = this.unitOfWork.Flights.Find(p => true);
            this.flightPanelView.Flights = flights;
            return this.View(this.flightPanelView);
        }

        // GET: Flights/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var flight = this.unitOfWork.Flights.Get(id);
            if (flight == null)
            {
                return this.HttpNotFound();
            }
            return this.View(flight);
        }

        // GET: Flights/Create
        public ActionResult Create()
        {
            this.ViewBag.AirlineId = new SelectList(this.unitOfWork.Airlines.Find(p => true), "Id", "Name");
            this.ViewBag.PortId = new SelectList(this.unitOfWork.Ports.Find(p => true), "Id", "Name");
            return this.View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FlightNumber,FlightType,FlightDate,PortId,Terminal,Gate,AirlineId,FlightStatusId")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                db.Flights.Add(flight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AirlineId = new SelectList(db.Airlines, "AirlineId", "Name", flight.AirlineId);
            ViewBag.FlightStatusId = new SelectList(db.FlightStatuses, "Id", "Name", flight.FlightStatusId);
            ViewBag.PortId = new SelectList(db.Ports, "Id", "Name", flight.PortId);
            return View(flight);
        }

        // GET: Flights/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var flight = this.unitOfWork.Flights.Get(id);
            if (flight == null)
            {
                return this.HttpNotFound();
            }
            ViewBag.AirlineId = new SelectList(db.Airlines, "AirlineId", "Name", flight.AirlineId);
            ViewBag.FlightStatusId = new SelectList(db.FlightStatuses, "Id", "Name", flight.FlightStatusId);
            ViewBag.PortId = new SelectList(db.Ports, "Id", "Name", flight.PortId);
            return View(flight);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FlightNumber,FlightType,FlightDate,PortId,Terminal,Gate,AirlineId,FlightStatusId")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AirlineId = new SelectList(db.Airlines, "AirlineId", "Name", flight.AirlineId);
            ViewBag.FlightStatusId = new SelectList(db.FlightStatuses, "Id", "Name", flight.FlightStatusId);
            ViewBag.PortId = new SelectList(db.Ports, "Id", "Name", flight.PortId);
            return View(flight);
        }

        // GET: Flights/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Flight flight = db.Flights.Find(id);
            db.Flights.Remove(flight);
            db.SaveChanges();
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
