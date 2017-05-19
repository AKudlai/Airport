using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Airport.Models;
using Airport.DAL;

namespace Airport.WebApp.Controllers
{
    public class HomeController : Controller
    {
        protected AirportContext DbAirportContext = new AirportContext();
        public ActionResult Index()
        {
            IEnumerable<Flight> flights = DbAirportContext.Flights;
            ViewBag.Flights = flights;
            return View();
        }
        [HttpGet]
        public ActionResult AddFlight()
        {
            return View();
        }
        [HttpPost]
        public string AddFlight(Flight flight)
        {
            return "";
        }

    }
}
