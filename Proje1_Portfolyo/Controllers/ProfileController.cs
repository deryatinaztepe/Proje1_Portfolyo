using Proje1_Portfolyo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje1_Portfolyo.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile

        Db_PortfolyoEntities2 context = new Db_PortfolyoEntities2();
        public ActionResult ProfileList()
        {
            var values = context.Tbl_Profile.ToList();
            return View(values);
        }
      

       
        [HttpGet]
        public ActionResult UpdateProfile(int id)
        {
            var value = context.Tbl_Profile.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateProfile(Tbl_Profile profile)
        {
            var value = context.Tbl_Profile.Find(profile.ProfileID);
            value.Title = profile.Title;
            value.Description = profile.Description;
            value.Address = profile.Address;
            value.Email = profile.Email;
            value.PhoneNumber = profile.PhoneNumber;
            value.Github = profile.Github;
            value.ImageUrl= profile.ImageUrl;
            value.MapLocation = profile.MapLocation;
            
         
            context.SaveChanges();
            return RedirectToAction("ProfileList");
        }

    }
}