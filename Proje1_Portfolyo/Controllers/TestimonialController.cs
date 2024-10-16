using Proje1_Portfolyo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje1_Portfolyo.Controllers
{
    public class TestimonialController : Controller
    {
        // GET: Testimonial
        Db_PortfolyoEntities2 context = new Db_PortfolyoEntities2();
        public ActionResult TestimonialList()
        {
            var values = context.Tbl_Testimonial.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTestimonial(Tbl_Testimonial testimonial)
        {
            context.Tbl_Testimonial.Add(testimonial);
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var value = context.Tbl_Testimonial.Find(id);
            context.Tbl_Testimonial.Remove(value);
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = context.Tbl_Testimonial.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateTestimonial(Tbl_Testimonial testimonial)
        {
            var value = context.Tbl_Testimonial.Find(testimonial.TestimonialID);
            value.Name = testimonial.Name;
            value.Title = testimonial.Title;
            value.Comment = testimonial.Comment;
            value.ImageUrl = testimonial.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
    }
}