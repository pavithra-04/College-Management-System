using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using MVC_01;
using PagedList;

namespace MVC_01.Controllers
{
    public class CollegesController : Controller
    {
        private CollegeDBEntities db = new CollegeDBEntities();

        // GET: Colleges
        public ActionResult Index()
        {
            return View(db.Colleges.ToList());
        }


        [HttpGet]
        public ActionResult Index(string SearchBy, string searchValue)
        {
            try
            {
                var collegeList = db.Colleges.ToList();
                if (collegeList.Count == 0)
                {
                    TempData["InfoMessage"] = "Currently colleges are not available in the Database.";
                }
                else
                {
                    if (string.IsNullOrEmpty(searchValue))
                    {
                        TempData["InfoMessage"] = "Please Provide Search Value";
                        return View(collegeList);

                    }
                    else if (SearchBy == "CollegeName")
                    {

                        var searchByCollege = collegeList.Where(p => p.CollegeName.ToLower().Contains(searchValue.ToLower()));
                        return View(searchByCollege);

                    }
                    else if ((SearchBy == "UniversityName"))
                    {
                        var searchByUniversity = collegeList.Where(p => p.UniversityName.ToLower().Contains(searchValue.ToLower()));
                        return View(searchByUniversity);
                    }
                }
                return View(collegeList);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

       
        // GET: Colleges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            College college = db.Colleges.Find(id);
            if (college == null)
            {
                return HttpNotFound();
            }
            return View(college);
        }

        // GET: Colleges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Colleges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CollegeID,CollegeName,UniversityName,EmailID,City,Country")] College college)
        {
            if (ModelState.IsValid)
            {
                db.Colleges.Add(college);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(college);
        }

        // GET: Colleges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            College college = db.Colleges.Find(id);
            if (college == null)
            {
                return HttpNotFound();
            }
            return View(college);
        }

        // POST: Colleges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CollegeID,CollegeName,UniversityName,EmailID,City,Country")] College college)
        {
            if (ModelState.IsValid)
            {
                db.Entry(college).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(college);
        }

        // GET: Colleges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            College college = db.Colleges.Find(id);
            if (college == null)
            {
                return HttpNotFound();
            }
            return View(college);
        }

        // POST: Colleges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            College college = db.Colleges.Find(id);
            db.Colleges.Remove(college);
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



        //searching

       /* public ActionResult Search(string SearchBy, string searchValue)
        {

            try
            {
                var collegeList = db.Colleges.ToList();
                if (collegeList.Count == 0)
                {
                    TempData["InfoMessage"] = "Currently products not available in the Database.";
                }
                else
                {
                    if (string.IsNullOrEmpty(searchValue))
                    {
                        TempData["InfoMessage"] = "Please Provide Search Value";
                        return View(collegeList);

                    }
                    else if (SearchBy.ToLower() == "CollegeName")
                    {

                        var searchByCollege = collegeList.Where(p => p.CollegeName.ToLower().Contains(searchValue.ToLower()));
                        return View(searchByCollege);

                    }
                    else if ((SearchBy.ToLower() == "UniversityName"))
                    {
                        var searchByUniversity = collegeList.Where(p => p.UniversityName.ToLower().Contains(searchValue.ToLower()));
                        return View(searchByUniversity);
                    }
                }
                return View(collegeList);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }

        }*/



    }
}
