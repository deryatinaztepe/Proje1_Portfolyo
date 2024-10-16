using Proje1_Portfolyo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje1_Portfolyo.Controllers
{
    public class ContactController : Controller
    {

        Db_PortfolyoEntities2 context = new Db_PortfolyoEntities2();
        public PartialViewResult PartialContactSideBar()
        {
            return PartialView();
        }
        public PartialViewResult PartialContactAddress()
        {
            ViewBag.description=context.Tbl_Profile.Select(x=>x.Description).FirstOrDefault();
            ViewBag.address=context.Tbl_Profile.Select(x=>x.Address).FirstOrDefault();
            ViewBag.email=context.Tbl_Profile.Select(x=>x.Email).FirstOrDefault();
            ViewBag.phone=context.Tbl_Profile.Select(x=>x.PhoneNumber).FirstOrDefault();
            
            return PartialView();
        }
        public PartialViewResult PartialContactLocation()
        {
            ViewBag.mapLocation=context.Tbl_Profile.Select(x=>x.MapLocation).FirstOrDefault();
            return  PartialView();
        }

    }
}