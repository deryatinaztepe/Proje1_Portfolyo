using Proje1_Portfolyo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje1_Portfolyo.Controllers
{
    
    public class DefaultController : Controller
    {
        // GET: Default
        Db_PortfolyoEntities2 context = new Db_PortfolyoEntities2();
        public ActionResult Index()
        {
            List<SelectListItem> values = (from x in context.Tbl_Category.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public ActionResult Index(Tbl_Message message)
        {
            message.SendDate= DateTime.Parse(DateTime.Now.ToShortDateString());
            message.IsRead = false;
            context.Tbl_Message.Add(message);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialHeader()
        {
            ViewBag.title=context.Tbl_About.Select(x => x.Title).FirstOrDefault();
            ViewBag.detail=context.Tbl_About.Select(x => x.Detail).FirstOrDefault();
            ViewBag.imageUrl=context.Tbl_About.Select(x => x.ImageUrl).FirstOrDefault();


            ViewBag.address=context.Tbl_Profile.Select(x => x.Address).FirstOrDefault();
            ViewBag.email=context.Tbl_Profile.Select(x => x.Email).FirstOrDefault();
            ViewBag.phone=context.Tbl_Profile.Select(x => x.PhoneNumber).FirstOrDefault();
            ViewBag.github=context.Tbl_Profile.Select(x => x.Github).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialAbout()
        {
            ViewBag.title=context.Tbl_Profile.Select(x=>x.Title).FirstOrDefault();
            ViewBag.description=context.Tbl_Profile.Select(x=>x.Description).FirstOrDefault();
            ViewBag.phone=context.Tbl_Profile.Select(x=>x.PhoneNumber).FirstOrDefault();
            ViewBag.email=context.Tbl_Profile.Select(x=>x.Email).FirstOrDefault();
            ViewBag.imageUrl=context.Tbl_Profile.Select(x=>x.ImageUrl).FirstOrDefault();
           

            return PartialView();
        }
        public PartialViewResult PartialEducation()
        {
            var values = context.Tbl_Education.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }

        public PartialViewResult PartialSkill()
        {
            var values=context.Tbl_Skill.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialSocialMedia() 
        { 
          var values=context.Tbl_SocialMedia.Where(x=>x.Status==true).ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialExperience()
        {
            var values = context.Tbl_Experience.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialService()
        {
            var values = context.Tbl_Service.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialWork()
        {
            var values = context.Tbl_Work.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialTestimonial()
        {
            var values = context.Tbl_Testimonial.ToList();
            return PartialView(values);
        }
    }
}