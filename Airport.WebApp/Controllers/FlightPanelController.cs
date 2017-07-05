namespace Airport.WebApp.Controllers
{
    using System.Net;
    using System.Web.Mvc;

    using Airport.Contracts;
    using Airport.Models.ViewModels;
    using Airport.Services;

    public class FlightPanelController : Controller
    {
        private readonly IFlightPanel flightPanel;

        public FlightPanelController()
        {
            this.flightPanel = new FlightPanel();
        }

        // GET: FlightPanel
        public ActionResult Index()
        {
            return this.View(this.flightPanel.GetFlights());
        }

        // GET: FlightPanel/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // flightPanel = this.flightPanel.();
            return this.View();
        }

        // GET: FlightPanel/Create
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: FlightPanel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FlightNumberId,FlightDate,Port,Airline,Terminal,FlightStatus,Gate")] FlightPanelView flight)
        {
            if (this.ModelState.IsValid)
            {
                this.flightPanel.AddFlight(flight);
                return this.RedirectToAction("Index");
            }
                return this.View();
        }

        // GET: FlightPanel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FlightPanel/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightPanel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FlightPanel/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
