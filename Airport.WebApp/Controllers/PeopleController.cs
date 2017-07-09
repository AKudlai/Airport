namespace Airport.WebApp.Controllers
{
    using System;
    using System.Net;
    using System.Web.Mvc;

    using Airport.Contracts;
    using Airport.Models.DomainModels.Entities;
    using Airport.Services.Repositories;

    public class PeopleController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public PeopleController()
        {
            this.unitOfWork = new UnitOfWork();
        }

        // GET: People
        public ActionResult Index()
        {
            return this.View(this.unitOfWork.Persons.Find(p => true));
        }

        // GET: People/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var person = this.unitOfWork.Persons.Get(id);
            if (person == null)
            {
                return this.HttpNotFound();
            }
            return this.View(person);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,DateOfBirsday,Sex,Nationality,PassportSerial,PassportIssueDate,PassportExpireDate")] Person person)
        {
            if (this.ModelState.IsValid)
            {
                person.Id = Guid.NewGuid();
                this.unitOfWork.Persons.Add(person);
                this.unitOfWork.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(person);
        }

        // GET: People/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var person = this.unitOfWork.Persons.Get(id);
            if (person == null)
            {
                return this.HttpNotFound();
            }
            return this.View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,DateOfBirsday,Sex,Nationality,PassportSerial,PassportIssueDate,PassportExpireDate")] Person person)
        {
            if (this.ModelState.IsValid)
            {
                this.unitOfWork.Persons.Update(person);
                this.unitOfWork.SaveChanges();
                return this.RedirectToAction("Index");
            }
            return this.View(person);
        }

        // GET: People/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var person = this.unitOfWork.Persons.Get(id);
            if (person == null)
            {
                return this.HttpNotFound();
            }
            return this.View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            this.unitOfWork.Persons.Remove(id);
            this.unitOfWork.SaveChanges();
            return this.RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
