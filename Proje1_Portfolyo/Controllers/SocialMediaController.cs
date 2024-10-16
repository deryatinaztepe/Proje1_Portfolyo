using Proje1_Portfolyo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje1_Portfolyo.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia
        Db_PortfolyoEntities2 context = new Db_PortfolyoEntities2();
        public ActionResult SocialMediaList()
        {
            var values = context.Tbl_SocialMedia.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateSocialMedia()
        {
            var values = context.Tbl_SocialMedia.ToList();
            return View(values);
        }

        [HttpPost]
        public ActionResult CreateSocialMedia(Tbl_SocialMedia socialMedia)
        {
            context.Tbl_SocialMedia.Add(socialMedia);
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        public ActionResult SocialMediaStatusChangeToTrue(int id)
        {
            var value = context.Tbl_SocialMedia.Where(x => x.SocialMediaID ==id).FirstOrDefault();
            value.Status= true;
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        public ActionResult SocialMediaStatusChangeToFalse(int id)
        {
            var value = context.Tbl_SocialMedia.Where(x => x.SocialMediaID == id).FirstOrDefault();
            value.Status= false;
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
        public ActionResult DeleteSocialMedia(int id)
        {
            var value = context.Tbl_SocialMedia.Find(id);
            context.Tbl_SocialMedia.Remove(value);
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
    }
}