using Microsoft.Ajax.Utilities;
using Microsoft.JScript;
using Microsoft.PowerBI.Api;
using Proje1_Portfolyo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using Context = Microsoft.Ajax.Utilities.Context;

namespace Proje1_Portfolyo.Controllers
{
    public class LoginController : Controller
    {
        Db_PortfolyoEntities2 context = new Db_PortfolyoEntities2();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            //Context c = new Context();
            //var kullaniciinfo=c.Admins.FirstOrDefault(x=>x.KullaniciAdi==p.KullaniciAdi && x.Sifre==p.Sifre);
            //var value = context.Tbl_Admin.Where(x => x.KullaniciAdi==p.kullaniciadi ).FirstOrDefault();
            //if (kullaniciadi != null)
            //{
            //    return RedirectToAction("About", "About");
            //}
            //else
            //{
            //    return RedirectToAction("Index");
            //}
            return View();
        }
    }
}