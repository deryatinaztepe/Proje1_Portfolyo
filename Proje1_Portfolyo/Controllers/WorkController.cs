using Proje1_Portfolyo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje1_Portfolyo.Controllers
{
    public class WorkController : Controller
    {
        // GET: Work
        Db_PortfolyoEntities2 context = new Db_PortfolyoEntities2();
        public ActionResult WorkList()
        {
            var values = context.Tbl_Work.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateWork()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult CreateWork(Tbl_Work work)
        {
            context.Tbl_Work.Add(work);
            context.SaveChanges();
            return RedirectToAction("WorkList");
        }

        public ActionResult DeleteWork(int id)
        {
            var value = context.Tbl_Work.Find(id);
            context.Tbl_Work.Remove(value);
            context.SaveChanges();
            return RedirectToAction("WorkList");
        }

        [HttpGet]
        public ActionResult UpdateWork(int id)
        {
            var value = context.Tbl_Work.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateWork(Tbl_Work work)
        {
            var value = context.Tbl_Work.Find(work.WorkID);
            value.Title = work.Title;
            value.Description = work.Description;
            value.ImageUrl =work.ImageUrl;
            value.GithubUrl =work.GithubUrl;
            context.SaveChanges();
            return RedirectToAction("WorkList");
        }

    }
}