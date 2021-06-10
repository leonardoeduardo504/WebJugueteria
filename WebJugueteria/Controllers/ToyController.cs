using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using WebJugueteria.Models;
using WebJugueteria.Repository;

namespace WebJugueteria.Controllers
{
    public class ToyController : Controller
    {      
        // GET: Toy
        public ActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/ApiToy");
                response.EnsureSuccessStatusCode();
                List<Toy> toys = response.Content.ReadAsAsync<List<Toy>>().Result;
                ViewBag.Title = "All Toys";
                return View(toys);
            }
            catch (Exception)
            {
                throw;
            }
            //return View(db.Toys.ToList());
        }

        // GET: Toy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/ApiToy/Get?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Toy toy = response.Content.ReadAsAsync<Toy>().Result;

            if (toy == null)
            {
                return HttpNotFound();
            }
            ViewBag.Title = "Toy";
            return View(toy);
        }

        // GET: Toy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Toy/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,AgeRestriction,Description,Company,Price")] Toy toy)
        {
            if (ModelState.IsValid)
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/ApiToy/Create", toy);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }

            return View(toy);
        }

        // GET: Toy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/ApiToy/Get?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Toy toy = response.Content.ReadAsAsync<Toy>().Result;
            ViewBag.Title = "Toy";
            if (toy == null)
            {
                return HttpNotFound();
            }
            return View(toy);
        }

        // POST: Toy/Edit/5        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,AgeRestriction,Description,Company,Price")] Toy toy)
        {
            if (ModelState.IsValid)
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PutResponse("api/ApiToy/Update", toy);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            return View(toy);
        }

        // GET: Toy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/ApiToy/Get?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Toy toy = response.Content.ReadAsAsync<Toy>().Result;

            if (toy == null)
            {
                return HttpNotFound();
            }
            return View(toy);
        }

        // POST: Toy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/ApiToy/Delete?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }
    }
}
