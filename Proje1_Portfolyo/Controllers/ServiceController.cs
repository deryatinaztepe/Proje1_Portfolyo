using Proje1_Portfolyo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje1_Portfolyo.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        Db_PortfolyoEntities2 context = new Db_PortfolyoEntities2();
        public ActionResult ServiceList()
        {
            var values = context.Tbl_Service.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateService(Tbl_Service service)
        {
            context.Tbl_Service.Add(service);
            context.SaveChanges();
            return RedirectToAction("ServiceList");
        }

        public ActionResult DeleteService(int id)
        {
            var value = context.Tbl_Service.Find(id);
            context.Tbl_Service.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ServiceList");
        }

        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var value = context.Tbl_Service.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateService(Tbl_Service service)
        {
            var value = context.Tbl_Service.Find(service.ServiceID);
            value.Title = service.Title;
            value.Description= service.Description;
            value.Icon= service.Icon;
            context.SaveChanges();
            return RedirectToAction("ServiceList");
        }
    }
}