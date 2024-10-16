using Proje1_Portfolyo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje1_Portfolyo.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        Db_PortfolyoEntities2 context = new Db_PortfolyoEntities2();
        public ActionResult ExperienceList()
        {
            var values=context.Tbl_Experience.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateExperience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateExperience(Tbl_Experience experience)
        {
            if(!ModelState.IsValid)
            {
                return View("CreateExperience");
            }
            context.Tbl_Experience.Add(experience);
            context.SaveChanges();
            return RedirectToAction("ExperienceList");

        }

        public ActionResult DeleteExperience(int id)
        {
            var value = context.Tbl_Experience.Find(id);
            context.Tbl_Experience.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ExperienceList");

        }

        [HttpGet]
        public ActionResult UpdateExperience(int id)
        {
            var value = context.Tbl_Experience.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateExperience(Tbl_Experience experience)
        {
            var value = context.Tbl_Experience.Find(experience.ExperienceID);
            value.Title = experience.Title;
            value.Description = experience.Description;
            value.WorkDate = experience.WorkDate;
            value.CompanyName= experience.CompanyName;
            context.SaveChanges();
            return RedirectToAction("ExperienceList");
        }
    }
}