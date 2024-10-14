using PST2231A1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PST2231A1.Controllers
{
    public class VenuesController : Controller
    {
        private Manager m = new Manager(); //new instance of Manager object

        // GET: Venues
        public ActionResult Index()
        {
            var v = m.VenueGetAll(); //Venues/Index/ - gets all customers
            return View(v);
        }

        // GET: Venues/Details/5
        public ActionResult Details(int? id) 
        {
            var v = m.VenueGetById(id.GetValueOrDefault());  //if null, GetValueOrDefault returns 0
                                                             //else, get the venue by id

            if (v == null)
            {
                return HttpNotFound(); //404 Page error if id is not present
            }
            else
            {
                return View(v); //get the details view
            }
        }

        // GET: Venues/Create
        public ActionResult Create()
        {
            var v = new VenueAddViewModel();
            return View(v);
        }

        // POST: Venues/Create
        [HttpPost]
        public ActionResult Create(VenueAddViewModel venueObj)
        {
            if (!ModelState.IsValid) //validate incoming data
            {
                return View(venueObj); //if invalid, return view and display errors
            }
            try
            {
                var newObj = m.AddNewVenue(venueObj); //new instance of AddNewVenue created

                if (newObj != null)
                {
                    return RedirectToAction("Details", new { id = newObj.VenueId }); //successful addition
                }
                else
                {
                    return View(venueObj); //unsuccessful
                }
            }
            catch
            {
                return View(venueObj); 
            }
        }

        // GET: Venues/Edit/5
        public ActionResult Edit(int id)
        {
            var v = m.VenueGetById(id); //find the id

            if (v != null)
            {
                var existingObj = m.mapper.Map<VenueBaseViewModel, VenueEditFormViewModel>(v);

                return View(existingObj); //display its Edit view
            }
            else
            {
                return null;
            }
        }

        // POST: Venues/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, VenueEditViewModel v)
        {
            try
            {
                if (!ModelState.IsValid) //validate incoming data
                {
                    return RedirectToAction("Edit", new { id = v.VenueId }); //return to Edit page if invalid
                }

                if (v.VenueId != id)
                {
                    return RedirectToAction("Index"); //or to Index page if id doesn't exist
                }

                var editVenue = m.EditVenue(v); //if id is valid, create a new instance and edit changes

                if (editVenue != null)
                {
                    return RedirectToAction("Details", new { id = v.VenueId }); //success
                }
                else
                {
                    return RedirectToAction("Edit", new { id = v.VenueId }); //unsuccessful
                }
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Venues/Delete/5
        public ActionResult Delete(int id)
        {
            var v = m.VenueGetById(id);
            return View(v);  //locate the id, return its delete page
        }

        // POST: Venues/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, VenueBaseViewModel collection)
        {
            try
            {
                m.DeleteVenue(id); //delete the venue

                return RedirectToAction("Index"); //return to Index view
            }
            catch
            {
                return View();
            }
        }
    }
}
