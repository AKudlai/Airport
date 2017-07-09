namespace Airport.WebApp.Controllers
{
    using System;
    using System.Net;
    using System.Web.Mvc;

    using Airport.Contracts;
    using Airport.Models.DomainModels.Entities;
    using Airport.Services.Repositories;

    public class PortsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public PortsController()
        {
            this.unitOfWork = new UnitOfWork();
        }

        // GET: Ports
        public ActionResult Index()
        {
            return this.View(this.unitOfWork.Ports.Find(p => true));
        }

        // GET: Ports/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var port = this.unitOfWork.Ports.Get(id);
            if (port == null)
            {
                return this.HttpNotFound();
            }
            return this.View(port);
        }

        // GET: Ports/Create
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: Ports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Photo,Country,LocalityName")] Port port)
        {
            if (this.ModelState.IsValid)
            {
                port.Id = Guid.NewGuid();
                this.unitOfWork.Ports.Add(port);
                this.unitOfWork.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(port);
        }

        // GET: Ports/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var port = this.unitOfWork.Ports.Get(id);
            if (port == null)
            {
                return this.HttpNotFound();
            }
            return this.View(port);
        }

        // POST: Ports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Photo,Country,LocalityName")] Port port)
        {
            if (this.ModelState.IsValid)
            {
                this.unitOfWork.Ports.Update(port);
                this.unitOfWork.SaveChanges();
                return this.RedirectToAction("Index");
            }
            return this.View(port);
        }

        // GET: Ports/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var port = this.unitOfWork.Ports.Get(id);
            if (port == null)
            {
                return this.HttpNotFound();
            }
            return this.View(port);
        }

        // POST: Ports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            this.unitOfWork.Ports.Remove(id);
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
