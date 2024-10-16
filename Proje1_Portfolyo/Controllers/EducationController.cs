using Proje1_Portfolyo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje1_Portfolyo.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        Db_PortfolyoEntities2 context = new Db_PortfolyoEntities2();
        public ActionResult EducationList()
        {
            var values = context.Tbl_Education.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateEducation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEducation(Tbl_Education education)
        {
            context.Tbl_Education.Add(education);
            context.SaveChanges();
            return RedirectToAction("EducationList");
        }

        public ActionResult DeleteEducation(int id)
        {
            var value = context.Tbl_Education.Find(id);
            context.Tbl_Education.Remove(value);
            context.SaveChanges();
            return RedirectToAction("EducationList");
        }
        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var value = context.Tbl_Education.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateEducation(Tbl_Education education )
        {
            var value = context.Tbl_Education.Find(education.EducationID);
            value.Subtitle = education.Subtitle;
            value.Title = education.Title;
            value.EducationDate = education.EducationDate;
            value.Description = education.Description;
         
            context.SaveChanges();
            return RedirectToAction("EducationList");
        }

    }
}