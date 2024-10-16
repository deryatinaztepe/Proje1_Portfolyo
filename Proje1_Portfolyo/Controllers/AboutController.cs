using Proje1_Portfolyo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proje1_Portfolyo.Controllers;

namespace Proje1_Portfolyo.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        Db_PortfolyoEntities2 context=new Db_PortfolyoEntities2();
        public ActionResult About()
        {
            var values = context.Tbl_About.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAbout(Tbl_About about)
        {
            context.Tbl_About.Add(about);
            context.SaveChanges();
            return RedirectToAction("About");
        }

        public ActionResult DeleteAbout(int id)
        {
            var value = context.Tbl_About.Find(id);
            context.Tbl_About.Remove(value);
            context.SaveChanges();
            return RedirectToAction("About");
        }
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = context.Tbl_About.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateAbout(Tbl_About about)
        {
            var value = context.Tbl_About.Find(about.AboutID);
            value.Title = about.Title;
            value.Detail = about.Detail;
            value.ImageUrl= about.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("About");
        }

    }
}